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
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

#nullable enable

namespace Jodosoft.Numerics.Tests
{
    /// <summary>
    /// Represents a decimal fixed-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ExampleNumber :
          IComparable,
          IConvertible,
          IBinaryFloatingPointIeee754<ExampleNumber>,
          IBinaryInteger<ExampleNumber>,
          IComparable<ExampleNumber>,
          IEquatable<ExampleNumber>,
          IMinMaxValue<ExampleNumber>,
          ISignedNumber<ExampleNumber>,
          IUnsignedNumber<ExampleNumber>,
#if HAS_SPANS
          ISpanFormattable,
#endif
          IDeserializationCallback,
          ISerializable
    {
        private static int Radix => throw new NotImplementedException();
        private static ExampleNumber AdditiveIdentity => throw new NotImplementedException();
        private static ExampleNumber MultiplicativeIdentity => throw new NotImplementedException();
        private static ExampleNumber NegativeOne => throw new NotImplementedException();
        private static ExampleNumber One => throw new NotImplementedException();
        private static ExampleNumber Zero => throw new NotImplementedException();
        private static ExampleNumber E => throw new NotImplementedException();
        private static ExampleNumber Pi => throw new NotImplementedException();
        private static ExampleNumber Tau => throw new NotImplementedException();
        private static ExampleNumber NaN => throw new NotImplementedException();

        public static ExampleNumber Epsilon => throw new NotImplementedException();
        public static ExampleNumber MaxValue => throw new NotImplementedException();
        public static ExampleNumber MinValue => throw new NotImplementedException();

        private ExampleNumber(SerializationInfo info, StreamingContext context) => throw new NotImplementedException();
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => throw new NotImplementedException();
        void IDeserializationCallback.OnDeserialization(object? sender) => throw new NotImplementedException();

        private static void SinCos(ExampleNumber x, out ExampleNumber sin, out ExampleNumber cos) => throw new NotImplementedException();
        private static void SinCosPi(ExampleNumber x, out ExampleNumber sinPi, out ExampleNumber cosPi) => throw new NotImplementedException();
        private static bool Equals(ExampleNumber value, ExampleNumber other) => throw new NotImplementedException();
        private static bool Equals(ExampleNumber value, object? obj) => throw new NotImplementedException();
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
        private static bool IsPow2(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsRealNumber(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsSubnormal(ExampleNumber value) => throw new NotImplementedException();
        private static bool IsZero(ExampleNumber value) => throw new NotImplementedException();
        private static bool ToBoolean(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static bool TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => throw new NotImplementedException();
        private static bool TryParse(string? s, IFormatProvider? provider, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => throw new NotImplementedException();
        private static byte ToByte(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static char ToChar(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static DateTime ToDateTime(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static decimal ToDecimal(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static double ToDouble(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static ExampleNumber Abs(ExampleNumber value) => throw new NotImplementedException();
        private static ExampleNumber Acos(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Acosh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber AcosPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Asin(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Asinh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber AsinPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Atan(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Atan2(ExampleNumber y, ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Atan2Pi(ExampleNumber y, ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Atanh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber AtanPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber BitDecrement(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber BitIncrement(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Cbrt(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Cos(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Cosh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber CosPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Exp(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Exp10(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Exp2(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber FusedMultiplyAdd(ExampleNumber left, ExampleNumber right, ExampleNumber addend) => throw new NotImplementedException();
        private static ExampleNumber Hypot(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber Ieee754Remainder(ExampleNumber left, ExampleNumber right) => throw new NotImplementedException();
        private static ExampleNumber Log(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Log(ExampleNumber x, ExampleNumber newBase) => throw new NotImplementedException();
        private static ExampleNumber Log10(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Log2(ExampleNumber value) => throw new NotImplementedException();
        private static ExampleNumber MaxMagnitude(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MinMagnitude(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber NegativeInfinity => throw new NotImplementedException();
        private static ExampleNumber NegativeZero => throw new NotImplementedException();
        private static ExampleNumber Parse(string s, IFormatProvider? provider) => throw new NotImplementedException();
        private static ExampleNumber Parse(string s, NumberStyles style, IFormatProvider? provider) => throw new NotImplementedException();
        private static ExampleNumber PopCount(ExampleNumber value) => throw new NotImplementedException();
        private static ExampleNumber PositiveInfinity => throw new NotImplementedException();
        private static ExampleNumber Pow(ExampleNumber x, ExampleNumber y) => throw new NotImplementedException();
        private static ExampleNumber RootN(ExampleNumber x, int n) => throw new NotImplementedException();
        private static ExampleNumber Round(ExampleNumber x, int digits, MidpointRounding mode) => throw new NotImplementedException();
        private static ExampleNumber ScaleB(ExampleNumber x, int n) => throw new NotImplementedException();
        private static ExampleNumber Sin(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Sinh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber SinPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Sqrt(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Tan(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber Tanh(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber TanPi(ExampleNumber x) => throw new NotImplementedException();
        private static ExampleNumber TrailingZeroCount(ExampleNumber value) => throw new NotImplementedException();
        private static float ToSingle(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static int CompareTo(ExampleNumber value, ExampleNumber other) => throw new NotImplementedException();
        private static int CompareTo(ExampleNumber value, object? obj) => throw new NotImplementedException();
        private static int GetByteCount() => throw new NotImplementedException();
        private static int GetExponentByteCount(ExampleNumber value) => throw new NotImplementedException();
        private static int GetExponentShortestBitLength(ExampleNumber value) => throw new NotImplementedException();
        private static int GetHashCode(ExampleNumber value) => throw new NotImplementedException();
        private static int GetShortestBitLength() => throw new NotImplementedException();
        private static int GetSignificandBitLength(ExampleNumber value) => throw new NotImplementedException();
        private static int GetSignificandByteCount(ExampleNumber value) => throw new NotImplementedException();
        private static int ILogB(ExampleNumber x) => throw new NotImplementedException();
        private static int ToInt32(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static long ToInt64(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static object ToType(ExampleNumber value, Type conversionType, IFormatProvider? provider) => throw new NotImplementedException();
        private static sbyte ToSByte(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static short ToInt16(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static string ToString(ExampleNumber value) => throw new NotImplementedException();
        private static string ToString(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static string ToString(ExampleNumber value, string? format, IFormatProvider? formatProvider) => throw new NotImplementedException();
        private static TypeCode GetTypeCode() => throw new NotImplementedException();
        private static uint ToUInt32(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static ulong ToUInt64(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();
        private static ushort ToUInt16(ExampleNumber value, IFormatProvider? provider) => throw new NotImplementedException();

#if HAS_SPANS
        private static bool TryFormat(ExampleNumber value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => throw new NotImplementedException();
        private static bool TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => throw new NotImplementedException();
        private static bool TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => throw new NotImplementedException();
        private static bool TryWriteBigEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteExponentBigEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteExponentLittleEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteLittleEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteSignificandBigEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteSignificandLittleEndian(ExampleNumber value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static ExampleNumber Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => throw new NotImplementedException();
        private static ExampleNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => throw new NotImplementedException();
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
        public static ExampleNumber operator -(ExampleNumber value) => throw new NotImplementedException();
        public static ExampleNumber operator --(ExampleNumber value) => throw new NotImplementedException();
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
        public static ExampleNumber operator >>>(ExampleNumber left, int right) => throw new NotImplementedException();

        #region Numerics implementation

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IConvertible.ToBoolean(IFormatProvider? provider) => ToBoolean(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEquatable<ExampleNumber>.Equals(ExampleNumber other) => Equals(this, other);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] byte IConvertible.ToByte(IFormatProvider? provider) => ToByte(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] char IConvertible.ToChar(IFormatProvider? provider) => ToChar(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ToDateTime(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] decimal IConvertible.ToDecimal(IFormatProvider? provider) => ToDecimal(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] double IConvertible.ToDouble(IFormatProvider? provider) => ToDouble(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] float IConvertible.ToSingle(IFormatProvider? provider) => ToSingle(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IBinaryInteger<ExampleNumber>.GetByteCount() => GetByteCount();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IBinaryInteger<ExampleNumber>.GetShortestBitLength() => GetShortestBitLength();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IComparable.CompareTo(object? obj) => CompareTo(this, obj);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IComparable<ExampleNumber>.CompareTo(ExampleNumber other) => CompareTo(this, other);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IConvertible.ToInt32(IFormatProvider? provider) => ToInt32(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<ExampleNumber>.GetExponentByteCount() => GetExponentByteCount(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<ExampleNumber>.GetExponentShortestBitLength() => GetExponentShortestBitLength(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<ExampleNumber>.GetSignificandBitLength() => GetSignificandBitLength(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<ExampleNumber>.GetSignificandByteCount() => GetSignificandByteCount(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] long IConvertible.ToInt64(IFormatProvider? provider) => ToInt64(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ToType(this, conversionType, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object? obj) => Equals(this, obj);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => GetHashCode(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => ToString(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] sbyte IConvertible.ToSByte(IFormatProvider? provider) => ToSByte(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] short IConvertible.ToInt16(IFormatProvider? provider) => ToInt16(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] string IConvertible.ToString(IFormatProvider? provider) => ToString(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToString(this, format, formatProvider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] TypeCode IConvertible.GetTypeCode() => GetTypeCode();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] uint IConvertible.ToUInt32(IFormatProvider? provider) => ToUInt32(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ulong IConvertible.ToUInt64(IFormatProvider? provider) => ToUInt64(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ushort IConvertible.ToUInt16(IFormatProvider? provider) => ToUInt16(this, provider);
#if HAS_SPANS
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryInteger<ExampleNumber>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryInteger<ExampleNumber>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<ExampleNumber>.TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteExponentBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<ExampleNumber>.TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteExponentLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<ExampleNumber>.TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteSignificandBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<ExampleNumber>.TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteSignificandLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) => TryFormat(this, destination, out charsWritten, format, provider);
#endif

#if HAS_SYSTEM_NUMERICS
        static ExampleNumber IAdditiveIdentity<ExampleNumber, ExampleNumber>.AdditiveIdentity => AdditiveIdentity;
        static ExampleNumber IFloatingPointConstants<ExampleNumber>.E => E;
        static ExampleNumber IFloatingPointConstants<ExampleNumber>.Pi => Pi;
        static ExampleNumber IFloatingPointConstants<ExampleNumber>.Tau => Tau;
        static ExampleNumber IFloatingPointIeee754<ExampleNumber>.Epsilon => Epsilon;
        static ExampleNumber IFloatingPointIeee754<ExampleNumber>.NaN => NaN;
        static ExampleNumber IFloatingPointIeee754<ExampleNumber>.NegativeInfinity => NegativeInfinity;
        static ExampleNumber IFloatingPointIeee754<ExampleNumber>.NegativeZero => NegativeZero;
        static ExampleNumber IFloatingPointIeee754<ExampleNumber>.PositiveInfinity => PositiveInfinity;
        static ExampleNumber IMinMaxValue<ExampleNumber>.MaxValue => MaxValue;
        static ExampleNumber IMinMaxValue<ExampleNumber>.MinValue => MinValue;
        static ExampleNumber IMultiplicativeIdentity<ExampleNumber, ExampleNumber>.MultiplicativeIdentity => MultiplicativeIdentity;
        static ExampleNumber INumberBase<ExampleNumber>.One => One;
        static ExampleNumber INumberBase<ExampleNumber>.Zero => Zero;
        static ExampleNumber ISignedNumber<ExampleNumber>.NegativeOne => NegativeOne;
        static int INumberBase<ExampleNumber>.Radix => Radix;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static (ExampleNumber Sin, ExampleNumber Cos) ITrigonometricFunctions<ExampleNumber>.SinCos(ExampleNumber x) { SinCos(x, out ExampleNumber sin, out ExampleNumber cos); return (sin, cos); }
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static (ExampleNumber SinPi, ExampleNumber CosPi) ITrigonometricFunctions<ExampleNumber>.SinCosPi(ExampleNumber x) { SinCosPi(x, out ExampleNumber sinPi, out ExampleNumber cosPi); return (sinPi, cosPi); }
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryInteger<ExampleNumber>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => TryReadBigEndian(source, isUnsigned, out value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryInteger<ExampleNumber>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => TryReadLittleEndian(source, isUnsigned, out value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryNumber<ExampleNumber>.IsPow2(ExampleNumber value) => IsPow2(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsCanonical(ExampleNumber value) => IsCanonical(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsComplexNumber(ExampleNumber value) => IsComplexNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsEvenInteger(ExampleNumber value) => IsEvenInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsFinite(ExampleNumber value) => IsFinite(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsImaginaryNumber(ExampleNumber value) => IsImaginaryNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsInfinity(ExampleNumber value) => IsInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsInteger(ExampleNumber value) => IsInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNaN(ExampleNumber value) => IsNaN(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNegative(ExampleNumber value) => IsNegative(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNegativeInfinity(ExampleNumber value) => IsNegativeInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsNormal(ExampleNumber value) => IsNormal(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsOddInteger(ExampleNumber value) => IsOddInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsPositive(ExampleNumber value) => IsPositive(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsPositiveInfinity(ExampleNumber value) => IsPositiveInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsRealNumber(ExampleNumber value) => IsRealNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsSubnormal(ExampleNumber value) => IsSubnormal(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.IsZero(ExampleNumber value) => IsZero(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => TryConvertFromChecked(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromSaturating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromTruncating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => TryConvertToChecked(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => TryConvertToSaturating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => TryConvertToTruncating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<ExampleNumber>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IParsable<ExampleNumber>.TryParse(string? s, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool ISpanParsable<ExampleNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IBinaryInteger<ExampleNumber>.PopCount(ExampleNumber value) => PopCount(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IBinaryInteger<ExampleNumber>.TrailingZeroCount(ExampleNumber value) => TrailingZeroCount(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IBinaryNumber<ExampleNumber>.Log2(ExampleNumber value) => Log2(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IExponentialFunctions<ExampleNumber>.Exp(ExampleNumber x) => Exp(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IExponentialFunctions<ExampleNumber>.Exp10(ExampleNumber x) => Exp10(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IExponentialFunctions<ExampleNumber>.Exp2(ExampleNumber x) => Exp2(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPoint<ExampleNumber>.Round(ExampleNumber x, int digits, MidpointRounding mode) => Round(x, digits, mode);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.Atan2(ExampleNumber y, ExampleNumber x) => Atan2(y, x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.Atan2Pi(ExampleNumber y, ExampleNumber x) => Atan2Pi(y, x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.BitDecrement(ExampleNumber x) => BitDecrement(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.BitIncrement(ExampleNumber x) => BitIncrement(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.FusedMultiplyAdd(ExampleNumber left, ExampleNumber right, ExampleNumber addend) => FusedMultiplyAdd(left, right, addend);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.Ieee754Remainder(ExampleNumber left, ExampleNumber right) => Ieee754Remainder(left, right);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IFloatingPointIeee754<ExampleNumber>.ScaleB(ExampleNumber x, int n) => ScaleB(x, n);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Acosh(ExampleNumber x) => Acosh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Asinh(ExampleNumber x) => Asinh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Atanh(ExampleNumber x) => Atanh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Cosh(ExampleNumber x) => Cosh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Sinh(ExampleNumber x) => Sinh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IHyperbolicFunctions<ExampleNumber>.Tanh(ExampleNumber x) => Tanh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ILogarithmicFunctions<ExampleNumber>.Log(ExampleNumber x) => Log(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ILogarithmicFunctions<ExampleNumber>.Log(ExampleNumber x, ExampleNumber newBase) => Log(x, newBase);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ILogarithmicFunctions<ExampleNumber>.Log10(ExampleNumber x) => Log10(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ILogarithmicFunctions<ExampleNumber>.Log2(ExampleNumber x) => Log2(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Abs(ExampleNumber value) => Abs(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MaxMagnitude(ExampleNumber x, ExampleNumber y) => MaxMagnitude(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MaxMagnitudeNumber(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MinMagnitude(ExampleNumber x, ExampleNumber y) => MinMagnitude(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MinMagnitudeNumber(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber INumberBase<ExampleNumber>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IParsable<ExampleNumber>.Parse(string s, IFormatProvider? provider) => Parse(s, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IPowerFunctions<ExampleNumber>.Pow(ExampleNumber x, ExampleNumber y) => Pow(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IRootFunctions<ExampleNumber>.Cbrt(ExampleNumber x) => Cbrt(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IRootFunctions<ExampleNumber>.Hypot(ExampleNumber x, ExampleNumber y) => Hypot(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IRootFunctions<ExampleNumber>.RootN(ExampleNumber x, int n) => RootN(x, n);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber IRootFunctions<ExampleNumber>.Sqrt(ExampleNumber x) => Sqrt(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ISpanParsable<ExampleNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Acos(ExampleNumber x) => Acos(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.AcosPi(ExampleNumber x) => AcosPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Asin(ExampleNumber x) => Asin(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.AsinPi(ExampleNumber x) => AsinPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Atan(ExampleNumber x) => Atan(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.AtanPi(ExampleNumber x) => AtanPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Cos(ExampleNumber x) => Cos(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.CosPi(ExampleNumber x) => CosPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Sin(ExampleNumber x) => Sin(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.SinPi(ExampleNumber x) => SinPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.Tan(ExampleNumber x) => Tan(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static ExampleNumber ITrigonometricFunctions<ExampleNumber>.TanPi(ExampleNumber x) => TanPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static int IFloatingPointIeee754<ExampleNumber>.ILogB(ExampleNumber x) => ILogB(x);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IAdditionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<IAdditionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IAdditiveIdentityCompatibility<ExampleNumber, ExampleNumber> IProvider<IAdditiveIdentityCompatibility<ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBinaryIntegerCompatibility<ExampleNumber> IProvider<IBinaryIntegerCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBinaryNumberCompatibility<ExampleNumber> IProvider<IBinaryNumberCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool> IProvider<IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IDecrementOperatorsCompatibility<ExampleNumber> IProvider<IDecrementOperatorsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IDivisionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<IDivisionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IEqualityOperatorsCompatibility<ExampleNumber, ExampleNumber, bool> IProvider<IEqualityOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IExponentialFunctionsCompatibility<ExampleNumber> IProvider<IExponentialFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IFloatingPointCompatibility<ExampleNumber> IProvider<IFloatingPointCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IFloatingPointConstantsCompatibility<ExampleNumber> IProvider<IFloatingPointConstantsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IFloatingPointIeee754Compatibility<ExampleNumber> IProvider<IFloatingPointIeee754Compatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IHyperbolicFunctionsCompatibility<ExampleNumber> IProvider<IHyperbolicFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IIncrementOperatorsCompatibility<ExampleNumber> IProvider<IIncrementOperatorsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ILogarithmicFunctionsCompatibility<ExampleNumber> IProvider<ILogarithmicFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMinMaxValueCompatibility<ExampleNumber> IProvider<IMinMaxValueCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IModulusOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<IModulusOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMultiplicativeIdentityCompatibility<ExampleNumber, ExampleNumber> IProvider<IMultiplicativeIdentityCompatibility<ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMultiplyOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<IMultiplyOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] INumberBaseCompatibility<ExampleNumber> IProvider<INumberBaseCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IParsableCompatibility<ExampleNumber> IProvider<IParsableCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IPowerFunctionsCompatibility<ExampleNumber> IProvider<IPowerFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IRootFunctionsCompatibility<ExampleNumber> IProvider<IRootFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber> IProvider<IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISignedNumberCompatibility<ExampleNumber> IProvider<ISignedNumberCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISubtractionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber> IProvider<ISubtractionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ITrigonometricFunctionsCompatibility<ExampleNumber> IProvider<ITrigonometricFunctionsCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IUnaryNegationOperatorsCompatibility<ExampleNumber, ExampleNumber> IProvider<IUnaryNegationOperatorsCompatibility<ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IUnaryPlusOperatorsCompatibility<ExampleNumber, ExampleNumber> IProvider<IUnaryPlusOperatorsCompatibility<ExampleNumber, ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
#if HAS_SPANS
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISpanParsableCompatibility<ExampleNumber> IProvider<ISpanParsableCompatibility<ExampleNumber>>.GetInstance() => StaticCompatibility.Instance;
#endif
        private class StaticCompatibility
            : IAdditionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              IAdditiveIdentityCompatibility<ExampleNumber, ExampleNumber>,
              IBinaryIntegerCompatibility<ExampleNumber>,
              IBinaryNumberCompatibility<ExampleNumber>,
              IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>,
              IDecrementOperatorsCompatibility<ExampleNumber>,
              IDivisionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              IEqualityOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>,
              IExponentialFunctionsCompatibility<ExampleNumber>,
              IFloatingPointCompatibility<ExampleNumber>,
              IFloatingPointConstantsCompatibility<ExampleNumber>,
              IFloatingPointIeee754Compatibility<ExampleNumber>,
              IHyperbolicFunctionsCompatibility<ExampleNumber>,
              IIncrementOperatorsCompatibility<ExampleNumber>,
              ILogarithmicFunctionsCompatibility<ExampleNumber>,
              IMinMaxValueCompatibility<ExampleNumber>,
              IModulusOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              IMultiplicativeIdentityCompatibility<ExampleNumber, ExampleNumber>,
              IMultiplyOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              INumberBaseCompatibility<ExampleNumber>,
              IParsableCompatibility<ExampleNumber>,
              IPowerFunctionsCompatibility<ExampleNumber>,
              IRootFunctionsCompatibility<ExampleNumber>,
              IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber>,
              ISignedNumberCompatibility<ExampleNumber>,
#if HAS_SPANS
              ISpanParsableCompatibility<ExampleNumber>,
#endif
              ISubtractionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>,
              ITrigonometricFunctionsCompatibility<ExampleNumber>,
              IUnaryNegationOperatorsCompatibility<ExampleNumber, ExampleNumber>,
              IUnaryPlusOperatorsCompatibility<ExampleNumber, ExampleNumber>
        {
            public static readonly StaticCompatibility Instance = new StaticCompatibility();

            ExampleNumber IAdditiveIdentityCompatibility<ExampleNumber, ExampleNumber>.AdditiveIdentity => AdditiveIdentity;
            ExampleNumber IFloatingPointConstantsCompatibility<ExampleNumber>.E => E;
            ExampleNumber IFloatingPointConstantsCompatibility<ExampleNumber>.Pi => Pi;
            ExampleNumber IFloatingPointConstantsCompatibility<ExampleNumber>.Tau => Tau;
            ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.Epsilon => Epsilon;
            ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.NaN => NaN;
            ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.NegativeInfinity => NegativeInfinity;
            ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.NegativeZero => NegativeZero;
            ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.PositiveInfinity => PositiveInfinity;
            ExampleNumber IMinMaxValueCompatibility<ExampleNumber>.MaxValue => MaxValue;
            ExampleNumber IMinMaxValueCompatibility<ExampleNumber>.MinValue => MinValue;
            ExampleNumber IMultiplicativeIdentityCompatibility<ExampleNumber, ExampleNumber>.MultiplicativeIdentity => MultiplicativeIdentity;
            ExampleNumber INumberBaseCompatibility<ExampleNumber>.One => One;
            ExampleNumber INumberBaseCompatibility<ExampleNumber>.Zero => Zero;
            ExampleNumber ISignedNumberCompatibility<ExampleNumber>.NegativeOne => NegativeOne;
            int INumberBaseCompatibility<ExampleNumber>.Radix => Radix;

            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryNumberCompatibility<ExampleNumber>.IsPow2(ExampleNumber value) => IsPow2(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsGreaterThan(ExampleNumber left, ExampleNumber right) => left > right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsGreaterThanOrEqualTo(ExampleNumber left, ExampleNumber right) => left >= right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsLessThan(ExampleNumber left, ExampleNumber right) => left < right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsLessThanOrEqualTo(ExampleNumber left, ExampleNumber right) => left <= right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsEqualTo(ExampleNumber left, ExampleNumber right) => left == right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperatorsCompatibility<ExampleNumber, ExampleNumber, bool>.IsNotEqualTo(ExampleNumber left, ExampleNumber right) => left != right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsCanonical(ExampleNumber value) => IsCanonical(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsComplexNumber(ExampleNumber value) => IsComplexNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsEvenInteger(ExampleNumber value) => IsEvenInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsFinite(ExampleNumber value) => IsFinite(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsImaginaryNumber(ExampleNumber value) => IsImaginaryNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsInfinity(ExampleNumber value) => IsInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsInteger(ExampleNumber value) => IsInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsNaN(ExampleNumber value) => IsNaN(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsNegative(ExampleNumber value) => IsNegative(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsNegativeInfinity(ExampleNumber value) => IsNegativeInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsNormal(ExampleNumber value) => IsNormal(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsOddInteger(ExampleNumber value) => IsOddInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsPositive(ExampleNumber value) => IsPositive(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsPositiveInfinity(ExampleNumber value) => IsPositiveInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsRealNumber(ExampleNumber value) => IsRealNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsSubnormal(ExampleNumber value) => IsSubnormal(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.IsZero(ExampleNumber value) => IsZero(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertFromChecked<TOther>(TOther value, out ExampleNumber result) => TryConvertFromChecked(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertFromSaturating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromSaturating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertFromTruncating<TOther>(TOther value, out ExampleNumber result) => TryConvertFromTruncating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertToChecked<TOther>(ExampleNumber value, out TOther result) => TryConvertToChecked(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertToSaturating<TOther>(ExampleNumber value, out TOther result) => TryConvertToSaturating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryConvertToTruncating<TOther>(ExampleNumber value, out TOther result) => TryConvertToTruncating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IParsableCompatibility<ExampleNumber>.TryParse(string? s, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IAdditionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.Add(ExampleNumber left, ExampleNumber right) => left + right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBinaryIntegerCompatibility<ExampleNumber>.PopCount(ExampleNumber value) => PopCount(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBinaryIntegerCompatibility<ExampleNumber>.TrailingZeroCount(ExampleNumber value) => TrailingZeroCount(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBinaryNumberCompatibility<ExampleNumber>.Log2(ExampleNumber value) => Log2(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.BitwiseComplement(ExampleNumber value) => ~value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.LogicalAnd(ExampleNumber left, ExampleNumber right) => left & right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.LogicalExclusiveOr(ExampleNumber left, ExampleNumber right) => left ^ right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IBitwiseOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.LogicalOr(ExampleNumber left, ExampleNumber right) => left | right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IDecrementOperatorsCompatibility<ExampleNumber>.Decrement(ExampleNumber value) => value--;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IDivisionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.Divide(ExampleNumber left, ExampleNumber right) => left / right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IExponentialFunctionsCompatibility<ExampleNumber>.Exp(ExampleNumber x) => Exp(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IExponentialFunctionsCompatibility<ExampleNumber>.Exp10(ExampleNumber x) => Exp10(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IExponentialFunctionsCompatibility<ExampleNumber>.Exp2(ExampleNumber x) => Exp2(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointCompatibility<ExampleNumber>.Round(ExampleNumber x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.Atan2(ExampleNumber y, ExampleNumber x) => Atan2(y, x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.Atan2Pi(ExampleNumber y, ExampleNumber x) => Atan2Pi(y, x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.BitDecrement(ExampleNumber x) => BitDecrement(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.BitIncrement(ExampleNumber x) => BitIncrement(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.FusedMultiplyAdd(ExampleNumber left, ExampleNumber right, ExampleNumber addend) => FusedMultiplyAdd(left, right, addend);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.Ieee754Remainder(ExampleNumber left, ExampleNumber right) => Ieee754Remainder(left, right);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IFloatingPointIeee754Compatibility<ExampleNumber>.ScaleB(ExampleNumber x, int n) => ScaleB(x, n);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Acosh(ExampleNumber x) => Acosh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Asinh(ExampleNumber x) => Asinh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Atanh(ExampleNumber x) => Atanh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Cosh(ExampleNumber x) => Cosh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Sinh(ExampleNumber x) => Sinh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IHyperbolicFunctionsCompatibility<ExampleNumber>.Tanh(ExampleNumber x) => Tanh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IIncrementOperatorsCompatibility<ExampleNumber>.Increment(ExampleNumber value) => value++;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ILogarithmicFunctionsCompatibility<ExampleNumber>.Log(ExampleNumber x) => Log(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ILogarithmicFunctionsCompatibility<ExampleNumber>.Log(ExampleNumber x, ExampleNumber newBase) => Log(x, newBase);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ILogarithmicFunctionsCompatibility<ExampleNumber>.Log10(ExampleNumber x) => Log10(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ILogarithmicFunctionsCompatibility<ExampleNumber>.Log2(ExampleNumber x) => Log2(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IModulusOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.Remainder(ExampleNumber left, ExampleNumber right) => left % right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IMultiplyOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.Multiply(ExampleNumber left, ExampleNumber right) => left * right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.Abs(ExampleNumber value) => Abs(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.MaxMagnitude(ExampleNumber x, ExampleNumber y) => MaxMagnitude(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.MaxMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MaxMagnitudeNumber(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.MinMagnitude(ExampleNumber x, ExampleNumber y) => MinMagnitude(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.MinMagnitudeNumber(ExampleNumber x, ExampleNumber y) => MinMagnitudeNumber(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IParsableCompatibility<ExampleNumber>.Parse(string s, IFormatProvider? provider) => Parse(s, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IPowerFunctionsCompatibility<ExampleNumber>.Pow(ExampleNumber x, ExampleNumber y) => Pow(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IRootFunctionsCompatibility<ExampleNumber>.Cbrt(ExampleNumber x) => Cbrt(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IRootFunctionsCompatibility<ExampleNumber>.Hypot(ExampleNumber x, ExampleNumber y) => Hypot(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IRootFunctionsCompatibility<ExampleNumber>.RootN(ExampleNumber x, int n) => RootN(x, n);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IRootFunctionsCompatibility<ExampleNumber>.Sqrt(ExampleNumber x) => Sqrt(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber>.LeftShift(ExampleNumber value, int shiftAmount) => value << shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber>.RightShift(ExampleNumber value, int shiftAmount) => value >> shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IShiftOperatorsCompatibility<ExampleNumber, int, ExampleNumber>.UnsignedRightShift(ExampleNumber value, int shiftAmount) => value >>> shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ISubtractionOperatorsCompatibility<ExampleNumber, ExampleNumber, ExampleNumber>.Subtract(ExampleNumber left, ExampleNumber right) => left - right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Acos(ExampleNumber x) => Acos(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.AcosPi(ExampleNumber x) => AcosPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Asin(ExampleNumber x) => Asin(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.AsinPi(ExampleNumber x) => AsinPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Atan(ExampleNumber x) => Atan(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.AtanPi(ExampleNumber x) => AtanPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Cos(ExampleNumber x) => Cos(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.CosPi(ExampleNumber x) => CosPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Sin(ExampleNumber x) => Sin(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.SinPi(ExampleNumber x) => SinPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.Tan(ExampleNumber x) => Tan(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ITrigonometricFunctionsCompatibility<ExampleNumber>.TanPi(ExampleNumber x) => TanPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IUnaryNegationOperatorsCompatibility<ExampleNumber, ExampleNumber>.Negative(ExampleNumber value) => -value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber IUnaryPlusOperatorsCompatibility<ExampleNumber, ExampleNumber>.Positive(ExampleNumber value) => +value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPointIeee754Compatibility<ExampleNumber>.ILogB(ExampleNumber x) => ILogB(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Tuple<ExampleNumber, ExampleNumber> ITrigonometricFunctionsCompatibility<ExampleNumber>.SinCos(ExampleNumber x) { SinCos(x, out ExampleNumber sin, out ExampleNumber cos); return new Tuple<ExampleNumber, ExampleNumber>(sin, cos); }
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Tuple<ExampleNumber, ExampleNumber> ITrigonometricFunctionsCompatibility<ExampleNumber>.SinCosPi(ExampleNumber x) { SinCosPi(x, out ExampleNumber sinPi, out ExampleNumber cosPi); return new Tuple<ExampleNumber, ExampleNumber>(sinPi, cosPi); }
#if HAS_SPANS
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryIntegerCompatibility<ExampleNumber>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => TryReadBigEndian(source, isUnsigned, out value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryIntegerCompatibility<ExampleNumber>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out ExampleNumber value) => TryReadLittleEndian(source, isUnsigned, out value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<ExampleNumber>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, style, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanParsableCompatibility<ExampleNumber>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ExampleNumber result) => TryParse(s, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber INumberBaseCompatibility<ExampleNumber>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ExampleNumber ISpanParsableCompatibility<ExampleNumber>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, provider);
#endif
        }
#endif
        #endregion
    }
}
