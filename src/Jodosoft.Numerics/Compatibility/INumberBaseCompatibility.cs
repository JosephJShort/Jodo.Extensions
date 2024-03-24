// Copyright (c) 2023 Joe Lawry-Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Unicode;
using Jodosoft.Primitives.Compatibility;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>
    ///     Defines the base of other number types.
    ///     This is a subsitute for <see href="https://learn.microsoft.com/en-us/dotnet/api/system.numerics.inumberbase-1?view=net-7.0">System.Numerics.INumberBase&lt;Self&gt;</see>
    ///     for targets before NET 7.0, promoting a near-compatible implementation for targets without static abstract methods.
    /// </summary>
    /// <typeparam name="T">The type that implements the interface.</typeparam>
    public interface INumberBaseCompatibility<T>
        where T : INumberBase<T>?, new()
    {
        /// <summary>Gets the value <c>1</c> for the type.</summary>
        /*static abstract*/
        T One { get; }

        /// <summary>Gets the radix, or base, for the type.</summary>
        /*static abstract*/
        int Radix { get; }

        /// <summary>Gets the value <c>0</c> for the type.</summary>
        /*static abstract*/
        T Zero { get; }

        /// <summary>Computes the absolute of a value.</summary>
        /// <param name="value">The value for which to get its absolute.</param>
        /// <returns>The absolute of <paramref name="value" />.</returns>
        /// <exception cref="OverflowException">The absolute of <paramref name="value" /> is not representable by <typeparamref name="T" />.</exception>
        /*static abstract*/
        T Abs(T value);

        /// <summary>Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value" /> is not representable by <typeparamref name="T" />.</exception>
        /*static virtual but now abstract*/
        T CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />, saturating if <paramref name="value" /> falls outside the representable range of <typeparamref name="T" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
       /*static virtual but now abstract*/
        T CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />, truncating if <paramref name="value" /> falls outside the representable range of <typeparamref name="T" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
         /*static virtual but now abstract*/
        T CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>, new();

        /// <summary>Determines if a value is in its canonical representation.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is in its canonical representation; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsCanonical(T value);

        /// <summary>Determines if a value represents a complex value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a complex number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where either <c>a</c> or <c>b</c> is zero. In other words, it excludes real numbers and pure imaginary numbers.</remarks>
        /*static abstract*/
        bool IsComplexNumber(T value);

        /// <summary>Determines if a value represents an even integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an even integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>2.0</c> will return <c>true</c> while <c>2.2</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger(T)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is not even nor odd.</para>
        /// </remarks>
        /*static abstract*/
        bool IsEvenInteger(T value);

        /// <summary>Determines if a value is finite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is finite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsInfinity(T)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        /*static abstract*/
        bool IsFinite(T value);

        /// <summary>Determines if a value represents a pure imaginary value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a pure imaginary number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where <c>a</c> is non-zero, as that number is not purely imaginary.</remarks>
        /*static abstract*/
        bool IsImaginaryNumber(T value);

        /// <summary>Determines if a value is infinite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is infinite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsFinite(T)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        /*static abstract*/
        bool IsInfinity(T value);

        /// <summary>Determines if a value represents an integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an integer; otherwise, <c>false</c>.</returns>
        /// <remarks>This correctly handles floating-point values and so <c>2.0</c> and <c>3.0</c> will return <c>true</c> while <c>2.2</c> and <c>3.3</c> will return <c>false</c>.</remarks>
        /*static abstract*/
        bool IsInteger(T value);

        /// <summary>Determines if a value is NaN.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is NaN; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsNaN(T value);

        /// <summary>Determines if a value represents a negative real number.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> represents negative zero or a negative real number; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>If this type has signed zero, then <c>-0</c> is also considered negative.</para>
        ///     <para>This function returning <c>false</c> does not imply that <see cref="IsPositive(T)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</para>
        /// </remarks>
        /*static abstract*/
        bool IsNegative(T value);

        /// <summary>Determines if a value is negative infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is negative infinity; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsNegativeInfinity(T value);

        /// <summary>Determines if a value is normal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is normal; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsNormal(T value);

        /// <summary>Determines if a value represents an odd integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an odd integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>3.0</c> will return <c>true</c> while <c>3.3</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger(T)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is neither even nor odd.</para>
        /// </remarks>
        /*static abstract*/
        bool IsOddInteger(T value);

        /// <summary>Determines if a value represents zero or a positive real number.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> represents (positive) zero or a positive real number; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>If this type has signed zero, then <c>-0</c> is not considered positive, but <c>+0</c> is.</para>
        ///     <para>This function returning <c>false</c> does not imply that <see cref="IsNegative(T)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</para>
        /// </remarks>
        /*static abstract*/
        bool IsPositive(T value);

        /// <summary>Determines if a value is positive infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is positive infinity; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsPositiveInfinity(T value);

        /// <summary>Determines if a value represents a real value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a real number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>true</c> for a complex number <c>a + bi</c> where <c>b</c> is zero.</remarks>
        /*static abstract*/
        bool IsRealNumber(T value);

        /// <summary>Determines if a value is subnormal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is subnormal; otherwise, <c>false</c>.</returns>
        /*static abstract*/
        bool IsSubnormal(T value);

        /// <summary>Determines if a value is zero.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is zero; otherwise, <c>false</c>.</returns>
        /// <remarks>This function treats both positive and negative zero as zero and so will return <c>true</c> for <c>+0.0</c> and <c>-0.0</c>.</remarks>
        /*static abstract*/
        bool IsZero(T value);

        /// <summary>Compares two values to compute which is greater.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{TSelf}" /> this method matches the IEEE 754:2019 <c>maximumMagnitude</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        /*static abstract*/
        T MaxMagnitude(T x, T y);

        /// <summary>Compares two values to compute which has the greater magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{TSelf}" /> this method matches the IEEE 754:2019 <c>maximumMagnitudeNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        /*static abstract*/
        T MaxMagnitudeNumber(T x, T y);

        /// <summary>Compares two values to compute which is lesser.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{TSelf}" /> this method matches the IEEE 754:2019 <c>minimumMagnitude</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        /*static abstract*/
        T MinMagnitude(T x, T y);

        /// <summary>Compares two values to compute which has the lesser magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{TSelf}" /> this method matches the IEEE 754:2019 <c>minimumMagnitudeNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        /*static abstract*/
        T MinMagnitudeNumber(T x, T y);

        /// <summary>Parses a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="s" /> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="T" />.</exception>
        /*static abstract*/
        T Parse(string s, NumberStyles style, IFormatProvider? provider);

        /// <summary>Parses a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="T" />.</exception>
        /*static abstract*/
        T Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider);

        // Removed
        // TryConvertFromChecked<TOther>
        // TryConvertFromSaturating<TOther>
        // TryConvertFromTruncating<TOther>
        // TryConvertToChecked<TOther>
        // TryConvertToSaturating<TOther>
        // TryConvertToTruncating<TOther>

        /// <summary>Tries to parse a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /*static abstract*/
        bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result);

        /// <summary>Tries to parse a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /*static abstract*/
        bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result);

        /// <summary>Tries to parse a span of UTF-8 characters into a value.</summary>
        /// <param name="utf8Text">The span of UTF-8 characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="utf8Text" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="utf8Text" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="utf8Text" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="utf8Text" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        static virtual bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result)
        {
            // Convert text using stackalloc for <= 256 characters and ArrayPool otherwise

            char[]? utf16TextArray;
            scoped Span<char> utf16Text;
            int textMaxCharCount = Encoding.UTF8.GetMaxCharCount(utf8Text.Length);

            if (textMaxCharCount < 256)
            {
                utf16TextArray = null;
                utf16Text = stackalloc char[256];
            }
            else
            {
                utf16TextArray = ArrayPool<char>.Shared.Rent(textMaxCharCount);
                utf16Text = utf16TextArray.AsSpan(0, textMaxCharCount);
            }

            OperationStatus utf8TextStatus = Utf8.ToUtf16(utf8Text, utf16Text, out _, out int utf16TextLength, replaceInvalidSequences: false);

            if (utf8TextStatus != OperationStatus.Done)
            {
                result = default;
                return false;
            }
            utf16Text = utf16Text.Slice(0, utf16TextLength);

            // Actual operation

            bool succeeded = T.TryParse(utf16Text, style, provider, out result);

            // Return rented buffers if necessary

            if (utf16TextArray != null)
            {
                ArrayPool<char>.Shared.Return(utf16TextArray);
            }

            return succeeded;
        }

        static T IUtf8SpanParsable<T>.Parse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider)
        {
            // Convert text using stackalloc for <= 256 characters and ArrayPool otherwise

            char[]? utf16TextArray;
            scoped Span<char> utf16Text;
            int textMaxCharCount = Encoding.UTF8.GetMaxCharCount(utf8Text.Length);

            if (textMaxCharCount < 256)
            {
                utf16TextArray = null;
                utf16Text = stackalloc char[256];
            }
            else
            {
                utf16TextArray = ArrayPool<char>.Shared.Rent(textMaxCharCount);
                utf16Text = utf16TextArray.AsSpan(0, textMaxCharCount);
            }

            OperationStatus utf8TextStatus = Utf8.ToUtf16(utf8Text, utf16Text, out _, out int utf16TextLength, replaceInvalidSequences: false);

            if (utf8TextStatus != OperationStatus.Done)
            {
                ThrowHelper.ThrowFormatInvalidString();
            }
            utf16Text = utf16Text.Slice(0, utf16TextLength);

            // Actual operation

            T result = T.Parse(utf16Text, provider);

            // Return rented buffers if necessary

            if (utf16TextArray != null)
            {
                ArrayPool<char>.Shared.Return(utf16TextArray);
            }

            return result;
        }

        static bool IUtf8SpanParsable<T>.TryParse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider, [MaybeNullWhen(returnValue: false)] out T result)
        {
            // Convert text using stackalloc for <= 256 characters and ArrayPool otherwise

            char[]? utf16TextArray;
            scoped Span<char> utf16Text;
            int textMaxCharCount = Encoding.UTF8.GetMaxCharCount(utf8Text.Length);

            if (textMaxCharCount < 256)
            {
                utf16TextArray = null;
                utf16Text = stackalloc char[256];
            }
            else
            {
                utf16TextArray = ArrayPool<char>.Shared.Rent(textMaxCharCount);
                utf16Text = utf16TextArray.AsSpan(0, textMaxCharCount);
            }

            OperationStatus utf8TextStatus = Utf8.ToUtf16(utf8Text, utf16Text, out _, out int utf16TextLength, replaceInvalidSequences: false);

            if (utf8TextStatus != OperationStatus.Done)
            {
                result = default;
                return false;
            }
            utf16Text = utf16Text.Slice(0, utf16TextLength);

            // Actual operation

            bool succeeded = T.TryParse(utf16Text, provider, out result);

            // Return rented buffers if necessary

            if (utf16TextArray != null)
            {
                ArrayPool<char>.Shared.Return(utf16TextArray);
            }

            return succeeded;
        }
    }
}

#endif
