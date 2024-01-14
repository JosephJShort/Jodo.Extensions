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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics.Tests
{
    public readonly struct ExampleNumber : INumberBase<ExampleNumber>
    {
        private bool Equals(ExampleNumber other) => throw new NotImplementedException();

        private static ExampleNumber One => throw new NotImplementedException();
        private static int Radix => throw new NotImplementedException();
        private static ExampleNumber Zero => throw new NotImplementedException();
        private static ExampleNumber AdditiveIdentity => throw new NotImplementedException();
        private static ExampleNumber MultiplicativeIdentity => throw new NotImplementedException();

        public override bool Equals(object obj) => throw new NotImplementedException();
        public override int GetHashCode() => throw new NotImplementedException();

        private static ExampleNumber Abs(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsCanonical(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsComplexNumber(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsEvenInteger(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsFinite(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsImaginaryNumber(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsInfinity(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsInteger(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsNaN(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsNegative(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsNegativeInfinity(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsNormal(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsOddInteger(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsPositive(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsPositiveInfinity(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsRealNumber(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsSubnormal(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsZero(ExampleNumber value) => throw new NotImplementedException();
        private static ExampleNumber MaxMagnitude(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MinMagnitude(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber Parse(string s, NumberStyles style, IFormatProvider provider) => throw new NotImplementedException();
        private static bool TryParse([NotNullWhen(true)] string s, NumberStyles style, IFormatProvider provider, [MaybeNullWhen(false)] out ExampleNumber result) => throw new NotImplementedException();
        private string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();
        private static bool TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static ExampleNumber Parse(string s, IFormatProvider provider) => throw new NotImplementedException();
        private static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, [MaybeNullWhen(false)] out ExampleNumber result) => throw new NotImplementedException();

#if HAS_SPANS
        private static ExampleNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, [MaybeNullWhen(false)] out ExampleNumber result) => throw new NotImplementedException();
        private bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider) => throw new NotImplementedException();
        private static ExampleNumber Parse(ReadOnlySpan<char> s, IFormatProvider provider) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, [MaybeNullWhen(false)] out ExampleNumber result) => throw new NotImplementedException();
#endif

        public static bool operator !=(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static bool operator <(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static bool operator <=(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static bool operator ==(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static bool operator >(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static bool operator >=(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator %(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator &(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator -(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator --(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator -(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator *(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator /(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator ^(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator |(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator ~(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator +(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        public static ExampleNumber operator +(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator ++(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator <<(ExampleNumber left, int right) => throw new NotImplementedException();
        public static ExampleNumber operator >>(ExampleNumber left, int right) => throw new NotImplementedException();

        #region INumberBase

        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEquatable<ExampleNumber>.Equals(ExampleNumber other) => Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] string IFormattable.ToString(string format, IFormatProvider formatProvider) => ToString(format, formatProvider);

#if HAS_SYSTEM_NUMERICS
        static ExampleNumber INumberBase<ExampleNumber>.One => One;
        static int INumberBase<ExampleNumber>.Radix => Radix;
        static ExampleNumber INumberBase<ExampleNumber>.Zero => Zero;
        static ExampleNumber IAdditiveIdentity<ExampleNumber, ExampleNumber>.AdditiveIdentity => AdditiveIdentity;
        static ExampleNumber IMultiplicativeIdentity<ExampleNumber, ExampleNumber>.MultiplicativeIdentity => MultiplicativeIdentity;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Abs(ExampleNumber value) => Abs(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsCanonical(ExampleNumber value) => IsCanonical(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsComplexNumber(ExampleNumber value) => IsComplexNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsEvenInteger(ExampleNumber value) => IsEvenInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsFinite(ExampleNumber value) => IsFinite(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsImaginaryNumber(ExampleNumber value) => IsImaginaryNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsInfinity(ExampleNumber value) => IsInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsInteger(ExampleNumber value) => IsInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNaN(ExampleNumber value) => IsNaN(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNegative(ExampleNumber value) => IsNegative(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNegativeInfinity(ExampleNumber value) => IsNegativeInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNormal(ExampleNumber value) => IsNormal(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsOddInteger(ExampleNumber value) => IsOddInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsPositive(ExampleNumber value) => IsPositive(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsPositiveInfinity(ExampleNumber value) => IsPositiveInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsRealNumber(ExampleNumber value) => IsRealNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsSubnormal(ExampleNumber value) => IsSubnormal(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsZero(ExampleNumber value) => IsZero(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MaxMagnitude(ExampleNumber x, ExampleNumber y) => MaxMagnitude(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MaxMagnitudeNumber(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MinMagnitude(ExampleNumber x, ExampleNumber y) => MinMagnitude(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MinMagnitudeNumber(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => TryConvertFromChecked(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromSaturating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromTruncating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => TryConvertToChecked(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => TryConvertToSaturating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => TryConvertToTruncating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryParse(string s, NumberStyles style, IFormatProvider provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ISpanParsable<ExampleNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider provider) => Parse(s, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool ISpanParsable<ExampleNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out ExampleNumber result) => TryParse(s, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IParsable<ExampleNumber>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IParsable<ExampleNumber>.TryParse(string s, IFormatProvider provider, out ExampleNumber result) => TryParse(s, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider) => TryFormat(destination, out charsWritten, format, provider);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IAdditionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.operator +(ExampleNumber left, ExampleNumber right) => left + right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IDecrementOperators<ExampleNumber>.operator --(ExampleNumber value) => value--;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IDivisionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.operator /(ExampleNumber left, ExampleNumber right) => left / right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IEqualityOperators<ExampleNumber, ExampleNumber, bool>.operator ==(ExampleNumber left, ExampleNumber right) => left == right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IEqualityOperators<ExampleNumber, ExampleNumber, bool>.operator !=(ExampleNumber left, ExampleNumber right) => left != right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IIncrementOperators<ExampleNumber>.operator ++(ExampleNumber value) => value++;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IMultiplyOperators<ExampleNumber, ExampleNumber, ExampleNumber>.operator *(ExampleNumber left, ExampleNumber right) => left * right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ISubtractionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.operator -(ExampleNumber left, ExampleNumber right) => left - right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IUnaryNegationOperators<ExampleNumber, ExampleNumber>.operator -(ExampleNumber value) => -value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IUnaryPlusOperators<ExampleNumber, ExampleNumber>.operator +(ExampleNumber value) => +value;
#else
        ExampleNumber INumberBase<ExampleNumber>.One => One;
        int INumberBase<ExampleNumber>.Radix => Radix;
        ExampleNumber INumberBase<ExampleNumber>.Zero => Zero;
        ExampleNumber IAdditiveIdentity<ExampleNumber, ExampleNumber>.AdditiveIdentity => AdditiveIdentity;
        ExampleNumber IMultiplicativeIdentity<ExampleNumber, ExampleNumber>.MultiplicativeIdentity => MultiplicativeIdentity;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.Abs(ExampleNumber value) => Abs(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsCanonical(ExampleNumber value) => IsCanonical(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsComplexNumber(ExampleNumber value) => IsComplexNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsEvenInteger(ExampleNumber value) => IsEvenInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsFinite(ExampleNumber value) => IsFinite(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsImaginaryNumber(ExampleNumber value) => IsImaginaryNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsInfinity(ExampleNumber value) => IsInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsInteger(ExampleNumber value) => IsInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsNaN(ExampleNumber value) => IsNaN(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsNegative(ExampleNumber value) => IsNegative(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsNegativeInfinity(ExampleNumber value) => IsNegativeInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsNormal(ExampleNumber value) => IsNormal(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsOddInteger(ExampleNumber value) => IsOddInteger(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsPositive(ExampleNumber value) => IsPositive(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsPositiveInfinity(ExampleNumber value) => IsPositiveInfinity(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsRealNumber(ExampleNumber value) => IsRealNumber(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsSubnormal(ExampleNumber value) => IsSubnormal(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.IsZero(ExampleNumber value) => IsZero(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.MaxMagnitude(ExampleNumber x, ExampleNumber y) => MaxMagnitude(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MaxMagnitudeNumber(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.MinMagnitude(ExampleNumber x, ExampleNumber y) => MinMagnitude(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MinMagnitudeNumber(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => TryConvertFromChecked(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromSaturating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromTruncating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => TryConvertToChecked(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => TryConvertToSaturating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => TryConvertToTruncating(value, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryParse(string s, NumberStyles style, IFormatProvider provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IParsable<ExampleNumber>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IParsable<ExampleNumber>.TryParse(string s, IFormatProvider provider, out ExampleNumber result) => TryParse(s, provider, out result);

#if HAS_SPANS
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBase<ExampleNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBase<ExampleNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider) => TryFormat(destination, out charsWritten, format, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ISpanParsable<ExampleNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider provider) => Parse(s, provider);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanParsable<ExampleNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out ExampleNumber result) => TryParse(s, provider, out result);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IAdditionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.Add(ExampleNumber left, ExampleNumber right) => left + right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IDecrementOperators<ExampleNumber>.Decrement(ExampleNumber value) => value--;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IDivisionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.Divide(ExampleNumber left, ExampleNumber right) => left / right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperators<ExampleNumber, ExampleNumber, bool>.IsEqualTo(ExampleNumber left, ExampleNumber right) => left == right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperators<ExampleNumber, ExampleNumber, bool>.IsNotEqualTo(ExampleNumber left, ExampleNumber right) => left != right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IIncrementOperators<ExampleNumber>.Increment(ExampleNumber value) => value++;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IMultiplyOperators<ExampleNumber, ExampleNumber, ExampleNumber>.Multiply(ExampleNumber left, ExampleNumber right) => left * right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ISubtractionOperators<ExampleNumber, ExampleNumber, ExampleNumber>.Subtract(ExampleNumber left, ExampleNumber right) => left - right;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IUnaryPlusOperators<ExampleNumber, ExampleNumber>.Positive(ExampleNumber value) => +value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IUnaryNegationOperators<ExampleNumber, ExampleNumber>.Negative(ExampleNumber value) => -value;
#endif

        #endregion
    }
}
