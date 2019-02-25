﻿using System;

namespace RGB.NET.Core
{
    public static class RGBColor
    {
        #region Getter

        /// <summary>
        /// Gets the A component value of this <see cref="Color"/> as byte in the range [0..255].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetA(this Color color) => color.A.GetByteValueFromPercentage();

        /// <summary>
        /// Gets the R component value of this <see cref="Color"/> as byte in the range [0..255].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetR(this Color color) => color.R.GetByteValueFromPercentage();

        /// <summary>
        /// Gets the G component value of this <see cref="Color"/> as byte in the range [0..255].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetG(this Color color) => color.G.GetByteValueFromPercentage();

        /// <summary>
        /// Gets the B component value of this <see cref="Color"/> as byte in the range [0..255].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetB(this Color color) => color.B.GetByteValueFromPercentage();

        /// <summary>
        /// Gets the A, R, G and B component value of this <see cref="Color"/> as byte in the range [0..255].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static (byte a, byte r, byte g, byte b) GetRGBBytes(this Color color)
            => (color.GetA(), color.GetR(), color.GetG(), color.GetB());

        /// <summary>
        /// Gets the A, R, G and B component value of this <see cref="Color"/> as percentage in the range [0..1].
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static (double a, double r, double g, double b) GetRGB(this Color color)
            => (color.A, color.R, color.G, color.B);

        #endregion

        #region Manipulation

        #region Add

        /// <summary>
        /// Adds the given RGB values to this color.
        /// </summary>
        /// <param name="r">The red value to add.</param>
        /// <param name="g">The green value to add.</param>
        /// <param name="b">The blue value to add.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color AddRGB(this Color color, int r = 0, int g = 0, int b = 0)
            => new Color(color.A, color.GetR() + r, color.GetG() + g, color.GetB() + b);

        /// <summary>
        /// Adds the given RGB-percent values to this color.
        /// </summary>
        /// <param name="r">The red value to add.</param>
        /// <param name="g">The green value to add.</param>
        /// <param name="b">The blue value to add.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color AddRGB(this Color color, double r = 0, double g = 0, double b = 0)
            => new Color(color.A, color.R + r, color.G + g, color.B + b);

        /// <summary>
        /// Adds the given alpha value to this color.
        /// </summary>
        /// <param name="a">The alpha value to add.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color AddA(this Color color, int a)
            => new Color(color.GetA() + a, color.R, color.G, color.B);

        /// <summary>
        /// Adds the given alpha-percent value to this color.
        /// </summary>
        /// <param name="a">The alpha value to add.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color AddA(this Color color, double a)
            => new Color(color.A + a, color.R, color.G, color.B);

        #endregion

        #region Subtract

        /// <summary>
        /// Subtracts the given RGB values to this color.
        /// </summary>
        /// <param name="r">The red value to subtract.</param>
        /// <param name="g">The green value to subtract.</param>
        /// <param name="b">The blue value to subtract.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SubtractRGB(this Color color, int r = 0, int g = 0, int b = 0)
            => new Color(color.A, color.GetR() - r, color.GetG() - g, color.GetB() - b);

        /// <summary>
        /// Subtracts the given RGB values to this color.
        /// </summary>
        /// <param name="r">The red value to subtract.</param>
        /// <param name="g">The green value to subtract.</param>
        /// <param name="b">The blue value to subtract.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SubtractRGB(this Color color, double r = 0, double g = 0, double b = 0)
            => new Color(color.A, color.R - r, color.G - g, color.B - b);

        /// <summary>
        /// Subtracts the given alpha value to this color.
        /// </summary>
        /// <param name="a">The alpha value to subtract.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SubtractA(this Color color, int a)
            => new Color(color.GetA() - a, color.R, color.G, color.B);

        /// <summary>
        /// Subtracts the given alpha-percent value to this color.
        /// </summary>
        /// <param name="a">The alpha value to subtract.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SubtractA(this Color color, double aPercent)
            => new Color(color.A - aPercent, color.R, color.G, color.B);

        #endregion

        #region Multiply

        /// <summary>
        /// Multiplies the given RGB values to this color.
        /// </summary>
        /// <param name="r">The red value to multiply.</param>
        /// <param name="g">The green value to multiply.</param>
        /// <param name="b">The blue value to multiply.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color MultiplyRGB(this Color color, double r = 1, double g = 1, double b = 1)
            => new Color(color.A, color.R * r, color.G * g, color.B * b);

        /// <summary>
        /// Multiplies the given alpha value to this color.
        /// </summary>
        /// <param name="a">The alpha value to multiply.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color MultiplyA(this Color color, double a)
            => new Color(color.A * a, color.R, color.G, color.B);

        #endregion

        #region Divide

        /// <summary>
        /// Divides the given RGB values to this color.
        /// </summary>
        /// <param name="r">The red value to divide.</param>
        /// <param name="g">The green value to divide.</param>
        /// <param name="b">The blue value to divide.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color DivideRGB(this Color color, double r = 1, double g = 1, double b = 1)
            => new Color(color.A, color.R / r, color.G / g, color.B / b);

        /// <summary>
        /// Divides the given alpha value to this color.
        /// </summary>
        /// <param name="a">The alpha value to divide.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color DivideA(this Color color, double a)
            => new Color(color.A / a, color.R, color.G, color.B);

        #endregion

        #region Set

        /// <summary>
        /// Sets the given RGB value of this color.
        /// </summary>
        /// <param name="r">The red value to set.</param>
        /// <param name="g">The green value to set.</param>
        /// <param name="b">The blue value to set.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SetRGB(this Color color, byte? r = null, byte? g = null, byte? b = null)
            => new Color(color.A, r ?? color.GetR(), g ?? color.GetG(), b ?? color.GetB());

        /// <summary>
        /// Sets the given RGB value of this color.
        /// </summary>
        /// <param name="r">The red value to set.</param>
        /// <param name="g">The green value to set.</param>
        /// <param name="b">The blue value to set.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SetRGB(this Color color, int? r = null, int? g = null, int? b = null)
            => new Color(color.A, r ?? color.GetR(), g ?? color.GetG(), b ?? color.GetB());

        /// <summary>
        /// Sets the given RGB value of this color.
        /// </summary>
        /// <param name="r">The red value to set.</param>
        /// <param name="g">The green value to set.</param>
        /// <param name="b">The blue value to set.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SetRGB(this Color color, double? r = null, double? g = null, double? b = null)
            => new Color(color.A, r ?? color.R, g ?? color.G, b ?? color.B);

        /// <summary>
        /// Sets the given alpha value of this color.
        /// </summary>
        /// <param name="a">The alpha value to set.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SetA(this Color color, int a) => new Color(a, color.R, color.G, color.B);

        /// <summary>
        /// Sets the given alpha value of this color.
        /// </summary>
        /// <param name="a">The alpha value to set.</param>
        /// <returns>The new color after the modification.</returns>
        public static Color SetA(this Color color, double a) => new Color(a, color.R, color.G, color.B);

        #endregion

        #endregion

        #region Conversion

        /// <summary>
        /// Gets the current color as a RGB-HEX-string.
        /// </summary>
        /// <returns>The RGB-HEX-string.</returns>
        public static string AsRGBHexString(this Color color, bool leadingHash = true) => (leadingHash ? "#" : "") + ConversionHelper.ToHex(color.GetR(), color.GetG(), color.GetB());

        /// <summary>
        /// Gets the current color as a ARGB-HEX-string.
        /// </summary>
        /// <returns>The ARGB-HEX-string.</returns>
        public static string AsARGBHexString(this Color color, bool leadingHash = true) => (leadingHash ? "#" : "") + ConversionHelper.ToHex(color.GetA(), color.GetR(), color.GetG(), color.GetB());

        #endregion

        #region Factory

        /// <summary>
        /// Creates a new instance of the <see cref="T:RGB.NET.Core.Color" /> struct using a HEX-string. 
        /// </summary>
        /// <param name="hexString">The HEX-representation of the color.</param>
        /// <returns>The color created from the HEX-string.</returns>
        public static Color FromHexString(string hexString)
        {
            if ((hexString == null) || (hexString.Length < 6))
                throw new ArgumentException("Invalid hex string", nameof(hexString));

            if (hexString[0] == '#')
                hexString = hexString.Substring(1);

            byte[] data = ConversionHelper.HexToBytes(hexString);
            if (data.Length == 3)
                return new Color(data[0], data[1], data[2]);
            if (data.Length == 4)
                return new Color(data[0], data[1], data[2], data[3]);

            throw new ArgumentException("Invalid hex string", nameof(hexString));
        }

        #endregion
    }
}