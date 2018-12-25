﻿using System.Collections.Generic;
using System.Linq;
using RGB.NET.Core;

namespace RGB.NET.Devices.WS281X.Arduino
{
    // ReSharper disable once InconsistentNaming
    /// <inheritdoc />
    /// <summary>
    /// Represents the update-queue performing updates for arduino WS2812 devices.
    /// </summary>
    public class ArduinoWS2812USBUpdateQueue : SerialPortUpdateQueue<byte[]>
    {
        #region Constants

        private static readonly byte[] COUNT_COMMAND = { 0x01 };
        private static readonly byte[] UPDATE_COMMAND = { 0x02 };
        private static readonly byte[] ASK_PROMPT_COMMAND = { 0x0F };

        #endregion

        #region Properties & Fields

        private readonly Dictionary<int, byte[]> _dataBuffer = new Dictionary<int, byte[]>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ArduinoWS2812USBUpdateQueue"/> class.
        /// </summary>
        /// <param name="updateTrigger">The update trigger used by this queue.</param>
        /// <param name="portName">The name of the serial-port to connect to.</param>
        /// <param name="baudRate">The baud-rate used by the serial-connection.</param>
        public ArduinoWS2812USBUpdateQueue(IDeviceUpdateTrigger updateTrigger, string portName, int baudRate = 115200)
            : base(updateTrigger, portName, baudRate)
        { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnStartup(object sender, CustomUpdateData customData)
        {
            base.OnStartup(sender, customData);
            
            SendCommand(ASK_PROMPT_COMMAND); // Get initial prompt
        }

        /// <inheritdoc />
        protected override IEnumerable<byte[]> GetCommands(Dictionary<object, Color> dataSet)
        {
            foreach (IGrouping<int, ((int channel, int key), Color Value)> channelData in dataSet.Select(x => (((int channel, int key))x.Key, x.Value))
                                                                                                 .GroupBy(x => x.Item1.channel))
            {
                int channel = channelData.Key;
                if (!_dataBuffer.TryGetValue(channel, out byte[] dataBuffer) || (dataBuffer.Length != ((dataSet.Count * 3) + 1)))
                    _dataBuffer[channel] = dataBuffer = new byte[(dataSet.Count * 3) + 1];

                dataBuffer[0] = (byte)((channel << 4) | UPDATE_COMMAND[0]);
                int i = 1;
                foreach ((byte _, byte r, byte g, byte b) in channelData.OrderBy(x => x.Item1.key)
                                                                        .Select(x => x.Value))
                {
                    dataBuffer[i++] = r;
                    dataBuffer[i++] = g;
                    dataBuffer[i++] = b;
                }
                yield return dataBuffer;
            }

            yield return UPDATE_COMMAND;
        }

        /// <inheritdoc />
        protected override void SendCommand(byte[] command) => SerialPort.Write(command, 0, command.Length);

        internal IEnumerable<(int channel, int ledCount)> GetChannels()
        {
            if (!SerialPort.IsOpen)
                SerialPort.Open();

            SerialPort.DiscardInBuffer();
            SendCommand(ASK_PROMPT_COMMAND);

            SerialPort.ReadTo(Prompt);
            SendCommand(COUNT_COMMAND);
            int channelCount = SerialPort.ReadByte();

            for (int i = 1; i <= channelCount; i++)
            {
                SerialPort.ReadTo(Prompt);
                byte[] channelLedCountCommand = { (byte)((i << 4) | COUNT_COMMAND[0]) };
                SendCommand(channelLedCountCommand);
                int ledCount = SerialPort.ReadByte();
                if (ledCount > 0)
                    yield return (i, ledCount);
            }
        }

        #endregion
    }
}
