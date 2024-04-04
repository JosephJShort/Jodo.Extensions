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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Fix64N
        : IAdditionOperators<Fix64N, Fix64N, Fix64N>,
          IAdditiveIdentity<Fix64N, Fix64N>,
          IBinaryInteger<Fix64N>,
          IBinaryNumber<Fix64N>,
          IBitwiseOperators<Fix64N, Fix64N, Fix64N>,
          IComparable,
          IComparable<Fix64N>,
          IComparisonOperators<Fix64N, Fix64N, bool>,
          IConvertible,
          IDecrementOperators<Fix64N>,
          IDeserializationCallback,
          IDivisionOperators<Fix64N, Fix64N, Fix64N>,
          IEqualityOperators<Fix64N, Fix64N, bool>,
          IEquatable<Fix64N>,
          IExponentialFunctions<Fix64N>,
          IFloatingPoint<Fix64N>,
          IFloatingPointConstants<Fix64N>,
          IFormattable,
          IHyperbolicFunctions<Fix64N>,
          IIncrementOperators<Fix64N>,
          ILogarithmicFunctions<Fix64N>,
          IMinMaxValue<Fix64N>,
          IModulusOperators<Fix64N, Fix64N, Fix64N>,
          IMultiplicativeIdentity<Fix64N, Fix64N>,
          IMultiplyOperators<Fix64N, Fix64N, Fix64N>,
          INumber<Fix64N>,
          INumberBase<Fix64N>,
          IParsable<Fix64N>,
          IPowerFunctions<Fix64N>,
          IRootFunctions<Fix64N>,
          ISerializable,
          ISignedNumber<Fix64N>,
          ISubtractionOperators<Fix64N, Fix64N, Fix64N>,
          ITrigonometricFunctions<Fix64N>,
          IUnaryNegationOperators<Fix64N, Fix64N>,
          IUnaryPlusOperators<Fix64N, Fix64N>,
          IUnsignedNumber<Fix64N>
#if HAS_SPANS
        , ISpanFormattable,
          ISpanParsable<Fix64N>
#endif
    {
        private static int Radix => 2;
        private static Fix64N AdditiveIdentity => Zero;
        private static Fix64N MultiplicativeIdentity => One;
        private static Fix64N NegativeOne => new Fix64N(-ScalingFactor);
        private static Fix64N One => new Fix64N(ScalingFactor);
        private static Fix64N Zero => new Fix64N(0);
        private static Fix64N E => new Fix64N(ScaledE);
        private static Fix64N Pi => new Fix64N(ScaledPi);
        private static Fix64N Tau => new Fix64N(ScaledTau);

        public static readonly Fix64N Epsilon = new Fix64N(1);
        public static readonly Fix64N MaxValue = new Fix64N(long.MaxValue);
        public static readonly Fix64N MinValue = new Fix64N(long.MinValue);

        private const long ScalingFactor = 1_000_000;
        private const long ScaledPi = 3_141_592;
        private const long ScaledTau = 6_283_185;
        private const long ScaledE = 2_718_281;

        private readonly long _scaledValue;

        private Fix64N(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private Fix64N(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Fix64N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Fix64N), _scaledValue);
        void IDeserializationCallback.OnDeserialization(object? _) { }

        public int CompareTo(Fix64N other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is Fix64N other ? CompareTo(other) : 1;
        public bool Equals(Fix64N other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is Fix64N other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => Scaled.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider? provider) => Scaled.ToString(_scaledValue, ScalingFactor, provider);
        public string ToString(string format) => ((double)this).ToString(format);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            {
                if (formatProvider == null) return ToString();
                return ToString(formatProvider);
            }
            if (formatProvider == null) return ToString(format);

            return ((double)this).ToString(format, formatProvider);
        }

        public static long GetScalingFactor() => ScalingFactor;
        public static long GetScaledValue(Fix64N value) => value._scaledValue;
        public static bool TryParse(string? s, IFormatProvider? provider, out Fix64N result) => s == null ? (result = default) != default : FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => s == null ? (result = default) != default : FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string? s, NumberStyles style, out Fix64N result) => s == null ? (result = default) != default : FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string? s, out Fix64N result) => s == null ? (result = default) != default : FuncExtensions.Try(() => Parse(s), out result);
        public static Fix64N Parse(string s) => new Fix64N(Scaled.Parse(s, ScalingFactor, null, null));
        public static Fix64N Parse(string s, IFormatProvider? provider) => new Fix64N(Scaled.Parse(s, ScalingFactor, null, provider));
        public static Fix64N Parse(string s, NumberStyles style) => (Fix64N)double.Parse(s, style);
        public static Fix64N Parse(string s, NumberStyles style, IFormatProvider? provider) => (Fix64N)double.Parse(s, style, provider);

        private static bool IsCanonical(Fix64N _) => true;
        private static bool IsComplexNumber(Fix64N _) => false;
        private static bool IsEvenInteger(Fix64N value) => IsInteger(value) && value._scaledValue / ScalingFactor % 2 == 0;
        private static bool IsFinite(Fix64N _) => true;
        private static bool IsImaginaryNumber(Fix64N _) => false;
        private static bool IsInfinity(Fix64N _) => false;
        private static bool IsInteger(Fix64N value) => value._scaledValue % ScalingFactor == 0;
        private static bool IsNaN(Fix64N _) => false;
        private static bool IsNegative(Fix64N value) => value._scaledValue < 0;
        private static bool IsNegativeInfinity(Fix64N _) => false;
        private static bool IsNormal(Fix64N value) => value._scaledValue != 0;
        private static bool IsOddInteger(Fix64N value) => IsInteger(value) && value._scaledValue / ScalingFactor % 2 == 1;
        private static bool IsPositive(Fix64N value) => value._scaledValue > 0;
        private static bool IsPositiveInfinity(Fix64N _) => false;
        private static bool IsPow2(Fix64N value) => IsInteger(value) && (value._scaledValue & (value._scaledValue - 1)) == 0 && value._scaledValue > 0;
        private static bool IsRealNumber(Fix64N _) => true;
        private static bool IsSubnormal(Fix64N _) => false;
        private static bool IsZero(Fix64N value) => value._scaledValue == 0;
        private static bool TryConvertFromChecked<TOther>(TOther value, out Fix64N result) => throw new NotImplementedException();
        private static bool TryConvertFromSaturating<TOther>(TOther value, out Fix64N result) => throw new NotImplementedException();
        private static bool TryConvertFromTruncating<TOther>(TOther value, out Fix64N result) => throw new NotImplementedException();
        private static bool TryConvertToChecked<TOther>(Fix64N value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToSaturating<TOther>(Fix64N value, out TOther result) => throw new NotImplementedException();
        private static bool TryConvertToTruncating<TOther>(Fix64N value, out TOther result) => throw new NotImplementedException();
        private static Fix64N Abs(Fix64N value) => value._scaledValue < 0 ? -value : value;
        private static Fix64N Acos(Fix64N x) => (Fix64N)Math.Acos((double)x);
        private static Fix64N Acosh(Fix64N x) => (Fix64N)MathShim.Acosh((double)x);
        private static Fix64N AcosPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Asin(Fix64N x) => (Fix64N)Math.Asin((double)x);
        private static Fix64N Asinh(Fix64N x) => (Fix64N)MathShim.Asinh((double)x);
        private static Fix64N AsinPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Atan(Fix64N x) => (Fix64N)Math.Atan((double)x);
        private static Fix64N Atan2(Fix64N y, Fix64N x) => (Fix64N)Math.Atan2((double)y, (double)x);
        private static Fix64N Atan2Pi(Fix64N y, Fix64N x) => throw new NotImplementedException();
        private static Fix64N Atanh(Fix64N x) => (Fix64N)MathShim.Atanh((double)x);
        private static Fix64N AtanPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N BitDecrement(Fix64N x) => throw new NotImplementedException();
        private static Fix64N BitIncrement(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Cbrt(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Cos(Fix64N x) => (Fix64N)Math.Cos((double)x);
        private static Fix64N Cosh(Fix64N x) => (Fix64N)Math.Cosh((double)x);
        private static Fix64N CosPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Exp(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Exp10(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Exp2(Fix64N x) => throw new NotImplementedException();
        private static Fix64N FusedMultiplyAdd(Fix64N left, Fix64N right, Fix64N addend) => throw new NotImplementedException();
        private static Fix64N Hypot(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N Ieee754Remainder(Fix64N left, Fix64N right) => throw new NotImplementedException();
        private static Fix64N LeadingZeroCount(Fix64N value) => throw new NotImplementedException();
        private static Fix64N Log(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Log(Fix64N x, Fix64N newBase) => throw new NotImplementedException();
        private static Fix64N Log10(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Log2(Fix64N value) => throw new NotImplementedException();
        private static Fix64N MaxMagnitude(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N MaxMagnitudeNumber(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N MinMagnitude(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N MinMagnitudeNumber(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N PopCount(Fix64N value) => throw new NotImplementedException();
        private static Fix64N Pow(Fix64N x, Fix64N y) => throw new NotImplementedException();
        private static Fix64N ReadBigEndian(byte[] source, bool isUnsigned) => throw new NotImplementedException();
        private static Fix64N ReadBigEndian(byte[] source, int startIndex, bool isUnsigned) => throw new NotImplementedException();
        private static Fix64N ReadLittleEndian(byte[] source, bool isUnsigned) => throw new NotImplementedException();
        private static Fix64N ReadLittleEndian(byte[] source, int startIndex, bool isUnsigned) => throw new NotImplementedException();
        private static Fix64N RootN(Fix64N x, int n) => throw new NotImplementedException();
        private static Fix64N RotateLeft(Fix64N value, int rotateAmount) => throw new NotImplementedException();
        private static Fix64N RotateRight(Fix64N value, int rotateAmount) => throw new NotImplementedException();
        private static Fix64N Round(Fix64N x, int digits, MidpointRounding mode) => throw new NotImplementedException();
        private static Fix64N ScaleB(Fix64N x, int n) => throw new NotImplementedException();
        private static Fix64N Sin(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Sinh(Fix64N x) => throw new NotImplementedException();
        private static Fix64N SinPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Sqrt(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Tan(Fix64N x) => throw new NotImplementedException();
        private static Fix64N Tanh(Fix64N x) => throw new NotImplementedException();
        private static Fix64N TanPi(Fix64N x) => throw new NotImplementedException();
        private static Fix64N TrailingZeroCount(Fix64N value) => throw new NotImplementedException();
        private static int CompareTo(Fix64N value, Fix64N other) => throw new NotImplementedException();
        private static int CompareTo(Fix64N value, object? obj) => throw new NotImplementedException();
        private static int GetByteCount() => throw new NotImplementedException();
        private static int GetExponentByteCount(Fix64N value) => throw new NotImplementedException();
        private static int GetExponentShortestBitLength(Fix64N value) => throw new NotImplementedException();
        private static int GetShortestBitLength() => throw new NotImplementedException();
        private static int GetSignificandBitLength(Fix64N value) => throw new NotImplementedException();
        private static int GetSignificandByteCount(Fix64N value) => throw new NotImplementedException();
        private static int ILogB(Fix64N x) => throw new NotImplementedException();
        private static void SinCos(Fix64N x, out Fix64N sin, out Fix64N cos) => throw new NotImplementedException();
        private static void SinCosPi(Fix64N x, out Fix64N sinPi, out Fix64N cosPi) => throw new NotImplementedException();

        private static bool ToBoolean(Fix64N value, IFormatProvider? _) => value._scaledValue != 0;
        private static byte ToByte(Fix64N value, IFormatProvider? _) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.Default);
        private static char ToChar(Fix64N value, IFormatProvider? provider) => ((IConvertible)Scaled.ToDouble(value._scaledValue, ScalingFactor)).ToChar(provider);
        private static DateTime ToDateTime(Fix64N value, IFormatProvider? provider) => ((IConvertible)Scaled.ToDouble(value._scaledValue, ScalingFactor)).ToDateTime(provider);
        private static decimal ToDecimal(Fix64N value, IFormatProvider? _) => (decimal)value._scaledValue / ScalingFactor;
        private static double ToDouble(Fix64N value, IFormatProvider? _) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        private static float ToSingle(Fix64N value, IFormatProvider? _) => (float)value._scaledValue / ScalingFactor;
        private static int ToInt32(Fix64N value, IFormatProvider? _) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.Default);
        private static long ToInt64(Fix64N value, IFormatProvider? _) => value._scaledValue / ScalingFactor;
        private static object ToType(Fix64N value, Type conversionType, IFormatProvider? provider) => value.ToTypeDefault(conversionType, provider);
        private static sbyte ToSByte(Fix64N value, IFormatProvider? _) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.Default);
        private static short ToInt16(Fix64N value, IFormatProvider? _) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.Default);
        private static TypeCode GetTypeCode() => throw new NotImplementedException();
        private static uint ToUInt32(Fix64N value, IFormatProvider? _) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.Default);
        private static ulong ToUInt64(Fix64N value, IFormatProvider? _) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, Conversion.Default);
        private static ushort ToUInt16(Fix64N value, IFormatProvider? _) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.Default);

#if HAS_SPANS
        private static bool TryFormat(Fix64N value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Fix64N result) => throw new NotImplementedException();
        private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => throw new NotImplementedException();
        private static bool TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => throw new NotImplementedException();
        private static bool TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => throw new NotImplementedException();
        private static bool TryWriteBigEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteExponentBigEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteExponentLittleEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteLittleEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteSignificandBigEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static bool TryWriteSignificandLittleEndian(Fix64N value, Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
        private static Fix64N Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => throw new NotImplementedException();
        private static Fix64N Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => throw new NotImplementedException();
        private static Fix64N ReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned) => throw new NotImplementedException();
        private static Fix64N ReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned) => throw new NotImplementedException();
#endif

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static Fix64N FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
            {
                return new Fix64N(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator Fix64N(ulong value) => new Fix64N((long)(value * ScalingFactor));
        [CLSCompliant(false)] public static implicit operator Fix64N(sbyte value) => new Fix64N(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64N(uint value) => new Fix64N(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64N(ushort value) => new Fix64N(value * ScalingFactor);
        public static explicit operator Fix64N(decimal value) => new Fix64N((long)(value * ScalingFactor));
        public static explicit operator Fix64N(double value) => FromDouble(value);
        public static explicit operator Fix64N(float value) => new Fix64N((long)(value * ScalingFactor));
        public static explicit operator Fix64N(long value) => new Fix64N(value * ScalingFactor);
        public static explicit operator Fix64N(UFix64 value) => new Fix64N((long)UFix64.GetScaledValue(value));
        public static implicit operator Fix64N(byte value) => new Fix64N(value * ScalingFactor);
        public static implicit operator Fix64N(int value) => new Fix64N(value * ScalingFactor);
        public static implicit operator Fix64N(short value) => new Fix64N(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(Fix64N value) => (sbyte)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator uint(Fix64N value) => (uint)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ulong(Fix64N value) => (ulong)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ushort(Fix64N value) => (ushort)(value._scaledValue / ScalingFactor);
        public static explicit operator byte(Fix64N value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(Fix64N value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(Fix64N value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(Fix64N value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(Fix64N value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(Fix64N value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(Fix64N value) => (short)(value._scaledValue / ScalingFactor);

        public static bool operator !=(Fix64N left, Fix64N right) => left._scaledValue != right._scaledValue;
        public static bool operator <(Fix64N left, Fix64N right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(Fix64N left, Fix64N right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(Fix64N left, Fix64N right) => left._scaledValue == right._scaledValue;
        public static bool operator >(Fix64N left, Fix64N right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(Fix64N left, Fix64N right) => left._scaledValue >= right._scaledValue;
        public static Fix64N operator %(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue % right._scaledValue);
        public static Fix64N operator &(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue & right._scaledValue);
        public static Fix64N operator -(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue - right._scaledValue);
        public static Fix64N operator --(Fix64N value) => new Fix64N(value._scaledValue - ScalingFactor);
        public static Fix64N operator -(Fix64N value) => new Fix64N(-value._scaledValue);
        public static Fix64N operator *(Fix64N left, Fix64N right) => new Fix64N(Scaled.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64N operator /(Fix64N left, Fix64N right) => new Fix64N(Scaled.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64N operator ^(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue ^ right._scaledValue);
        public static Fix64N operator |(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue | right._scaledValue);
        public static Fix64N operator ~(Fix64N value) => new Fix64N(~value._scaledValue);
        public static Fix64N operator +(Fix64N left, Fix64N right) => new Fix64N(left._scaledValue + right._scaledValue);
        public static Fix64N operator +(Fix64N value) => value;
        public static Fix64N operator ++(Fix64N value) => new Fix64N(value._scaledValue + ScalingFactor);
        public static Fix64N operator <<(Fix64N left, int right) => new Fix64N(left._scaledValue << right);
        public static Fix64N operator >>(Fix64N left, int right) => new Fix64N(left._scaledValue >> right);
        public static Fix64N operator >>>(Fix64N left, int right) => new Fix64N(left._scaledValue >>> right);

        #region Numerics implementation

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IConvertible.ToBoolean(IFormatProvider? provider) => ToBoolean(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEquatable<Fix64N>.Equals(Fix64N other) => Equals(this, other);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] byte IConvertible.ToByte(IFormatProvider? provider) => ToByte(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] char IConvertible.ToChar(IFormatProvider? provider) => ToChar(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ToDateTime(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] decimal IConvertible.ToDecimal(IFormatProvider? provider) => ToDecimal(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] double IConvertible.ToDouble(IFormatProvider? provider) => ToDouble(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] float IConvertible.ToSingle(IFormatProvider? provider) => ToSingle(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IBinaryInteger<Fix64N>.GetByteCount() => GetByteCount();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IBinaryInteger<Fix64N>.GetShortestBitLength() => GetShortestBitLength();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IComparable.CompareTo(object? obj) => CompareTo(this, obj);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IComparable<Fix64N>.CompareTo(Fix64N other) => CompareTo(this, other);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IConvertible.ToInt32(IFormatProvider? provider) => ToInt32(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<Fix64N>.GetExponentByteCount() => GetExponentByteCount(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<Fix64N>.GetExponentShortestBitLength() => GetExponentShortestBitLength(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<Fix64N>.GetSignificandBitLength() => GetSignificandBitLength(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] int IFloatingPoint<Fix64N>.GetSignificandByteCount() => GetSignificandByteCount(this);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] long IConvertible.ToInt64(IFormatProvider? provider) => ToInt64(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ToType(this, conversionType, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] sbyte IConvertible.ToSByte(IFormatProvider? provider) => ToSByte(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] short IConvertible.ToInt16(IFormatProvider? provider) => ToInt16(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] TypeCode IConvertible.GetTypeCode() => GetTypeCode();
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] uint IConvertible.ToUInt32(IFormatProvider? provider) => ToUInt32(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ulong IConvertible.ToUInt64(IFormatProvider? provider) => ToUInt64(this, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] ushort IConvertible.ToUInt16(IFormatProvider? provider) => ToUInt16(this, provider);
#if HAS_SPANS
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryInteger<Fix64N>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryInteger<Fix64N>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<Fix64N>.TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteExponentBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<Fix64N>.TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteExponentLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<Fix64N>.TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten) => TryWriteSignificandBigEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IFloatingPoint<Fix64N>.TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten) => TryWriteSignificandLittleEndian(this, destination, out bytesWritten);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) => TryFormat(this, destination, out charsWritten, format, provider);
#endif

#if HAS_SYSTEM_NUMERICS
        static Fix64N IAdditiveIdentity<Fix64N, Fix64N>.AdditiveIdentity => AdditiveIdentity;
        static Fix64N IFloatingPointConstants<Fix64N>.E => E;
        static Fix64N IFloatingPointConstants<Fix64N>.Pi => Pi;
        static Fix64N IFloatingPointConstants<Fix64N>.Tau => Tau;
        static Fix64N IMinMaxValue<Fix64N>.MaxValue => MaxValue;
        static Fix64N IMinMaxValue<Fix64N>.MinValue => MinValue;
        static Fix64N IMultiplicativeIdentity<Fix64N, Fix64N>.MultiplicativeIdentity => MultiplicativeIdentity;
        static Fix64N INumberBase<Fix64N>.One => One;
        static Fix64N INumberBase<Fix64N>.Zero => Zero;
        static Fix64N ISignedNumber<Fix64N>.NegativeOne => NegativeOne;
        static int INumberBase<Fix64N>.Radix => Radix;

        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static (Fix64N Sin, Fix64N Cos) ITrigonometricFunctions<Fix64N>.SinCos(Fix64N x) { SinCos(x, out Fix64N sin, out Fix64N cos); return (sin, cos); }
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static (Fix64N SinPi, Fix64N CosPi) ITrigonometricFunctions<Fix64N>.SinCosPi(Fix64N x) { SinCosPi(x, out Fix64N sinPi, out Fix64N cosPi); return (sinPi, cosPi); }
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryInteger<Fix64N>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => TryReadBigEndian(source, isUnsigned, out value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryInteger<Fix64N>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => TryReadLittleEndian(source, isUnsigned, out value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IBinaryNumber<Fix64N>.IsPow2(Fix64N value) => IsPow2(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsCanonical(Fix64N value) => IsCanonical(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsComplexNumber(Fix64N value) => IsComplexNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsEvenInteger(Fix64N value) => IsEvenInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsFinite(Fix64N value) => IsFinite(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsImaginaryNumber(Fix64N value) => IsImaginaryNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsInfinity(Fix64N value) => IsInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsInteger(Fix64N value) => IsInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsNaN(Fix64N value) => IsNaN(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsNegative(Fix64N value) => IsNegative(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsNegativeInfinity(Fix64N value) => IsNegativeInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsNormal(Fix64N value) => IsNormal(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsOddInteger(Fix64N value) => IsOddInteger(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsPositive(Fix64N value) => IsPositive(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsPositiveInfinity(Fix64N value) => IsPositiveInfinity(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsRealNumber(Fix64N value) => IsRealNumber(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsSubnormal(Fix64N value) => IsSubnormal(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.IsZero(Fix64N value) => IsZero(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertFromChecked<TOther>(TOther value, out Fix64N result) => TryConvertFromChecked(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertFromSaturating<TOther>(TOther value, out Fix64N result) => TryConvertFromSaturating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertFromTruncating<TOther>(TOther value, out Fix64N result) => TryConvertFromTruncating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertToChecked<TOther>(Fix64N value, out TOther result) => TryConvertToChecked(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertToSaturating<TOther>(Fix64N value, out TOther result) => TryConvertToSaturating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryConvertToTruncating<TOther>(Fix64N value, out TOther result) => TryConvertToTruncating(value, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => TryParse(s, style, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool INumberBase<Fix64N>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => TryParse(s, style, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool IParsable<Fix64N>.TryParse(string? s, IFormatProvider? provider, out Fix64N result) => TryParse(s, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static bool ISpanParsable<Fix64N>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Fix64N result) => TryParse(s, provider, out result);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.LeadingZeroCount(Fix64N value) => LeadingZeroCount(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.PopCount(Fix64N value) => PopCount(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadBigEndian(byte[] source, bool isUnsigned) => ReadBigEndian(source, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadBigEndian(byte[] source, int startIndex, bool isUnsigned) => ReadBigEndian(source, startIndex, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned) => ReadBigEndian(source, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadLittleEndian(byte[] source, bool isUnsigned) => ReadLittleEndian(source, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadLittleEndian(byte[] source, int startIndex, bool isUnsigned) => ReadLittleEndian(source, startIndex, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.ReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned) => ReadLittleEndian(source, isUnsigned);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.RotateLeft(Fix64N value, int rotateAmount) => RotateLeft(value, rotateAmount);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.RotateRight(Fix64N value, int rotateAmount) => RotateRight(value, rotateAmount);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryInteger<Fix64N>.TrailingZeroCount(Fix64N value) => TrailingZeroCount(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IBinaryNumber<Fix64N>.Log2(Fix64N value) => Log2(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IExponentialFunctions<Fix64N>.Exp(Fix64N x) => Exp(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IExponentialFunctions<Fix64N>.Exp10(Fix64N x) => Exp10(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IExponentialFunctions<Fix64N>.Exp2(Fix64N x) => Exp2(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IFloatingPoint<Fix64N>.Round(Fix64N x, int digits, MidpointRounding mode) => Round(x, digits, mode);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Acosh(Fix64N x) => Acosh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Asinh(Fix64N x) => Asinh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Atanh(Fix64N x) => Atanh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Cosh(Fix64N x) => Cosh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Sinh(Fix64N x) => Sinh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IHyperbolicFunctions<Fix64N>.Tanh(Fix64N x) => Tanh(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ILogarithmicFunctions<Fix64N>.Log(Fix64N x) => Log(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ILogarithmicFunctions<Fix64N>.Log(Fix64N x, Fix64N newBase) => Log(x, newBase);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ILogarithmicFunctions<Fix64N>.Log10(Fix64N x) => Log10(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ILogarithmicFunctions<Fix64N>.Log2(Fix64N x) => Log2(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.Abs(Fix64N value) => Abs(value);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.MaxMagnitude(Fix64N x, Fix64N y) => MaxMagnitude(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.MaxMagnitudeNumber(Fix64N x, Fix64N y) => MaxMagnitudeNumber(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.MinMagnitude(Fix64N x, Fix64N y) => MinMagnitude(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.MinMagnitudeNumber(Fix64N x, Fix64N y) => MinMagnitudeNumber(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N INumberBase<Fix64N>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IParsable<Fix64N>.Parse(string s, IFormatProvider? provider) => Parse(s, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IPowerFunctions<Fix64N>.Pow(Fix64N x, Fix64N y) => Pow(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IRootFunctions<Fix64N>.Cbrt(Fix64N x) => Cbrt(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IRootFunctions<Fix64N>.Hypot(Fix64N x, Fix64N y) => Hypot(x, y);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IRootFunctions<Fix64N>.RootN(Fix64N x, int n) => RootN(x, n);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N IRootFunctions<Fix64N>.Sqrt(Fix64N x) => Sqrt(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ISpanParsable<Fix64N>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, provider);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Acos(Fix64N x) => Acos(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.AcosPi(Fix64N x) => AcosPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Asin(Fix64N x) => Asin(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.AsinPi(Fix64N x) => AsinPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Atan(Fix64N x) => Atan(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.AtanPi(Fix64N x) => AtanPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Cos(Fix64N x) => Cos(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.CosPi(Fix64N x) => CosPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Sin(Fix64N x) => Sin(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.SinPi(Fix64N x) => SinPi(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.Tan(Fix64N x) => Tan(x);
        [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] static Fix64N ITrigonometricFunctions<Fix64N>.TanPi(Fix64N x) => TanPi(x);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IAdditionOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<IAdditionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IAdditiveIdentityCompatibility<Fix64N, Fix64N> IProvider<IAdditiveIdentityCompatibility<Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBinaryIntegerCompatibility<Fix64N> IProvider<IBinaryIntegerCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBinaryNumberCompatibility<Fix64N> IProvider<IBinaryNumberCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool> IProvider<IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IDecrementOperatorsCompatibility<Fix64N> IProvider<IDecrementOperatorsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IDivisionOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<IDivisionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IEqualityOperatorsCompatibility<Fix64N, Fix64N, bool> IProvider<IEqualityOperatorsCompatibility<Fix64N, Fix64N, bool>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IExponentialFunctionsCompatibility<Fix64N> IProvider<IExponentialFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IFloatingPointCompatibility<Fix64N> IProvider<IFloatingPointCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IFloatingPointConstantsCompatibility<Fix64N> IProvider<IFloatingPointConstantsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IHyperbolicFunctionsCompatibility<Fix64N> IProvider<IHyperbolicFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IIncrementOperatorsCompatibility<Fix64N> IProvider<IIncrementOperatorsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ILogarithmicFunctionsCompatibility<Fix64N> IProvider<ILogarithmicFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMinMaxValueCompatibility<Fix64N> IProvider<IMinMaxValueCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IModulusOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<IModulusOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMultiplicativeIdentityCompatibility<Fix64N, Fix64N> IProvider<IMultiplicativeIdentityCompatibility<Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IMultiplyOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<IMultiplyOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] INumberBaseCompatibility<Fix64N> IProvider<INumberBaseCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IParsableCompatibility<Fix64N> IProvider<IParsableCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IPowerFunctionsCompatibility<Fix64N> IProvider<IPowerFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IRootFunctionsCompatibility<Fix64N> IProvider<IRootFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IShiftOperatorsCompatibility<Fix64N, int, Fix64N> IProvider<IShiftOperatorsCompatibility<Fix64N, int, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISignedNumberCompatibility<Fix64N> IProvider<ISignedNumberCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISubtractionOperatorsCompatibility<Fix64N, Fix64N, Fix64N> IProvider<ISubtractionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ITrigonometricFunctionsCompatibility<Fix64N> IProvider<ITrigonometricFunctionsCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IUnaryNegationOperatorsCompatibility<Fix64N, Fix64N> IProvider<IUnaryNegationOperatorsCompatibility<Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] IUnaryPlusOperatorsCompatibility<Fix64N, Fix64N> IProvider<IUnaryPlusOperatorsCompatibility<Fix64N, Fix64N>>.GetInstance() => StaticCompatibility.Instance;
#if HAS_SPANS
        [MethodImpl(MethodImplOptions.AggressiveInlining)] ISpanParsableCompatibility<Fix64N> IProvider<ISpanParsableCompatibility<Fix64N>>.GetInstance() => StaticCompatibility.Instance;
#endif
        private sealed class StaticCompatibility
            : IAdditionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              IAdditiveIdentityCompatibility<Fix64N, Fix64N>,
              IBinaryIntegerCompatibility<Fix64N>,
              IBinaryNumberCompatibility<Fix64N>,
              IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>,
              IDecrementOperatorsCompatibility<Fix64N>,
              IDivisionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              IEqualityOperatorsCompatibility<Fix64N, Fix64N, bool>,
              IExponentialFunctionsCompatibility<Fix64N>,
              IFloatingPointCompatibility<Fix64N>,
              IFloatingPointConstantsCompatibility<Fix64N>,
              IHyperbolicFunctionsCompatibility<Fix64N>,
              IIncrementOperatorsCompatibility<Fix64N>,
              ILogarithmicFunctionsCompatibility<Fix64N>,
              IMinMaxValueCompatibility<Fix64N>,
              IModulusOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              IMultiplicativeIdentityCompatibility<Fix64N, Fix64N>,
              IMultiplyOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              INumberBaseCompatibility<Fix64N>,
              IParsableCompatibility<Fix64N>,
              IPowerFunctionsCompatibility<Fix64N>,
              IRootFunctionsCompatibility<Fix64N>,
              IShiftOperatorsCompatibility<Fix64N, int, Fix64N>,
              ISignedNumberCompatibility<Fix64N>,
#if HAS_SPANS
              ISpanParsableCompatibility<Fix64N>,
#endif
              ISubtractionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>,
              ITrigonometricFunctionsCompatibility<Fix64N>,
              IUnaryNegationOperatorsCompatibility<Fix64N, Fix64N>,
              IUnaryPlusOperatorsCompatibility<Fix64N, Fix64N>
        {
            public static readonly StaticCompatibility Instance = new StaticCompatibility();

            Fix64N IAdditiveIdentityCompatibility<Fix64N, Fix64N>.AdditiveIdentity => AdditiveIdentity;
            Fix64N IFloatingPointConstantsCompatibility<Fix64N>.E => E;
            Fix64N IFloatingPointConstantsCompatibility<Fix64N>.Pi => Pi;
            Fix64N IFloatingPointConstantsCompatibility<Fix64N>.Tau => Tau;
            Fix64N IMinMaxValueCompatibility<Fix64N>.MaxValue => MaxValue;
            Fix64N IMinMaxValueCompatibility<Fix64N>.MinValue => MinValue;
            Fix64N IMultiplicativeIdentityCompatibility<Fix64N, Fix64N>.MultiplicativeIdentity => MultiplicativeIdentity;
            Fix64N INumberBaseCompatibility<Fix64N>.One => One;
            Fix64N INumberBaseCompatibility<Fix64N>.Zero => Zero;
            Fix64N ISignedNumberCompatibility<Fix64N>.NegativeOne => NegativeOne;
            int INumberBaseCompatibility<Fix64N>.Radix => Radix;

            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryNumberCompatibility<Fix64N>.IsPow2(Fix64N value) => IsPow2(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>.IsGreaterThan(Fix64N left, Fix64N right) => left > right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>.IsGreaterThanOrEqualTo(Fix64N left, Fix64N right) => left >= right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>.IsLessThan(Fix64N left, Fix64N right) => left < right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IComparisonOperatorsCompatibility<Fix64N, Fix64N, bool>.IsLessThanOrEqualTo(Fix64N left, Fix64N right) => left <= right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperatorsCompatibility<Fix64N, Fix64N, bool>.IsEqualTo(Fix64N left, Fix64N right) => left == right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IEqualityOperatorsCompatibility<Fix64N, Fix64N, bool>.IsNotEqualTo(Fix64N left, Fix64N right) => left != right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsCanonical(Fix64N value) => IsCanonical(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsComplexNumber(Fix64N value) => IsComplexNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsEvenInteger(Fix64N value) => IsEvenInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsFinite(Fix64N value) => IsFinite(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsImaginaryNumber(Fix64N value) => IsImaginaryNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsInfinity(Fix64N value) => IsInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsInteger(Fix64N value) => IsInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsNaN(Fix64N value) => IsNaN(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsNegative(Fix64N value) => IsNegative(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsNegativeInfinity(Fix64N value) => IsNegativeInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsNormal(Fix64N value) => IsNormal(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsOddInteger(Fix64N value) => IsOddInteger(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsPositive(Fix64N value) => IsPositive(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsPositiveInfinity(Fix64N value) => IsPositiveInfinity(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsRealNumber(Fix64N value) => IsRealNumber(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsSubnormal(Fix64N value) => IsSubnormal(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.IsZero(Fix64N value) => IsZero(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertFromChecked<TOther>(TOther value, out Fix64N result) => TryConvertFromChecked(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertFromSaturating<TOther>(TOther value, out Fix64N result) => TryConvertFromSaturating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertFromTruncating<TOther>(TOther value, out Fix64N result) => TryConvertFromTruncating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertToChecked<TOther>(Fix64N value, out TOther result) => TryConvertToChecked(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertToSaturating<TOther>(Fix64N value, out TOther result) => TryConvertToSaturating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryConvertToTruncating<TOther>(Fix64N value, out TOther result) => TryConvertToTruncating(value, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => TryParse(s, style, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IParsableCompatibility<Fix64N>.TryParse(string? s, IFormatProvider? provider, out Fix64N result) => TryParse(s, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IAdditionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.Add(Fix64N left, Fix64N right) => left + right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.LeadingZeroCount(Fix64N value) => LeadingZeroCount(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.PopCount(Fix64N value) => PopCount(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadBigEndian(byte[] source, bool isUnsigned) => ReadBigEndian(source, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadBigEndian(byte[] source, int startIndex, bool isUnsigned) => ReadBigEndian(source, startIndex, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadLittleEndian(byte[] source, bool isUnsigned) => ReadLittleEndian(source, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadLittleEndian(byte[] source, int startIndex, bool isUnsigned) => ReadLittleEndian(source, startIndex, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.RotateLeft(Fix64N value, int rotateAmount) => RotateLeft(value, rotateAmount);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.RotateRight(Fix64N value, int rotateAmount) => RotateRight(value, rotateAmount);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.TrailingZeroCount(Fix64N value) => TrailingZeroCount(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryNumberCompatibility<Fix64N>.Log2(Fix64N value) => Log2(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.BitwiseComplement(Fix64N value) => ~value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.LogicalAnd(Fix64N left, Fix64N right) => left & right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.LogicalExclusiveOr(Fix64N left, Fix64N right) => left ^ right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBitwiseOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.LogicalOr(Fix64N left, Fix64N right) => left | right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IDecrementOperatorsCompatibility<Fix64N>.Decrement(Fix64N value) => value--;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IDivisionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.Divide(Fix64N left, Fix64N right) => left / right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IExponentialFunctionsCompatibility<Fix64N>.Exp(Fix64N x) => Exp(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IExponentialFunctionsCompatibility<Fix64N>.Exp10(Fix64N x) => Exp10(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IExponentialFunctionsCompatibility<Fix64N>.Exp2(Fix64N x) => Exp2(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IFloatingPointCompatibility<Fix64N>.Round(Fix64N x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Acosh(Fix64N x) => Acosh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Asinh(Fix64N x) => Asinh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Atanh(Fix64N x) => Atanh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Cosh(Fix64N x) => Cosh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Sinh(Fix64N x) => Sinh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IHyperbolicFunctionsCompatibility<Fix64N>.Tanh(Fix64N x) => Tanh(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IIncrementOperatorsCompatibility<Fix64N>.Increment(Fix64N value) => value++;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ILogarithmicFunctionsCompatibility<Fix64N>.Log(Fix64N x) => Log(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ILogarithmicFunctionsCompatibility<Fix64N>.Log(Fix64N x, Fix64N newBase) => Log(x, newBase);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ILogarithmicFunctionsCompatibility<Fix64N>.Log10(Fix64N x) => Log10(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ILogarithmicFunctionsCompatibility<Fix64N>.Log2(Fix64N x) => Log2(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IModulusOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.Remainder(Fix64N left, Fix64N right) => left % right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IMultiplyOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.Multiply(Fix64N left, Fix64N right) => left * right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.Abs(Fix64N value) => Abs(value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.MaxMagnitude(Fix64N x, Fix64N y) => MaxMagnitude(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.MaxMagnitudeNumber(Fix64N x, Fix64N y) => MaxMagnitudeNumber(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.MinMagnitude(Fix64N x, Fix64N y) => MinMagnitude(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.MinMagnitudeNumber(Fix64N x, Fix64N y) => MinMagnitudeNumber(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IParsableCompatibility<Fix64N>.Parse(string s, IFormatProvider? provider) => Parse(s, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IPowerFunctionsCompatibility<Fix64N>.Pow(Fix64N x, Fix64N y) => Pow(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IRootFunctionsCompatibility<Fix64N>.Cbrt(Fix64N x) => Cbrt(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IRootFunctionsCompatibility<Fix64N>.Hypot(Fix64N x, Fix64N y) => Hypot(x, y);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IRootFunctionsCompatibility<Fix64N>.RootN(Fix64N x, int n) => RootN(x, n);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IRootFunctionsCompatibility<Fix64N>.Sqrt(Fix64N x) => Sqrt(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IShiftOperatorsCompatibility<Fix64N, int, Fix64N>.LeftShift(Fix64N value, int shiftAmount) => value << shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IShiftOperatorsCompatibility<Fix64N, int, Fix64N>.RightShift(Fix64N value, int shiftAmount) => value >> shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IShiftOperatorsCompatibility<Fix64N, int, Fix64N>.UnsignedRightShift(Fix64N value, int shiftAmount) => value >>> shiftAmount;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ISubtractionOperatorsCompatibility<Fix64N, Fix64N, Fix64N>.Subtract(Fix64N left, Fix64N right) => left - right;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Acos(Fix64N x) => Acos(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.AcosPi(Fix64N x) => AcosPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Asin(Fix64N x) => Asin(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.AsinPi(Fix64N x) => AsinPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Atan(Fix64N x) => Atan(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.AtanPi(Fix64N x) => AtanPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Cos(Fix64N x) => Cos(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.CosPi(Fix64N x) => CosPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Sin(Fix64N x) => Sin(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.SinPi(Fix64N x) => SinPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.Tan(Fix64N x) => Tan(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ITrigonometricFunctionsCompatibility<Fix64N>.TanPi(Fix64N x) => TanPi(x);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IUnaryNegationOperatorsCompatibility<Fix64N, Fix64N>.Negative(Fix64N value) => -value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IUnaryPlusOperatorsCompatibility<Fix64N, Fix64N>.Positive(Fix64N value) => +value;
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Tuple<Fix64N, Fix64N> ITrigonometricFunctionsCompatibility<Fix64N>.SinCos(Fix64N x) { SinCos(x, out Fix64N sin, out Fix64N cos); return new Tuple<Fix64N, Fix64N>(sin, cos); }
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Tuple<Fix64N, Fix64N> ITrigonometricFunctionsCompatibility<Fix64N>.SinCosPi(Fix64N x) { SinCosPi(x, out Fix64N sinPi, out Fix64N cosPi); return new Tuple<Fix64N, Fix64N>(sinPi, cosPi); }
#if HAS_SPANS
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryIntegerCompatibility<Fix64N>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => TryReadBigEndian(source, isUnsigned, out value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool IBinaryIntegerCompatibility<Fix64N>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out Fix64N value) => TryReadLittleEndian(source, isUnsigned, out value);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool INumberBaseCompatibility<Fix64N>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Fix64N result) => TryParse(s, style, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] bool ISpanParsableCompatibility<Fix64N>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Fix64N result) => TryParse(s, provider, out result);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned) => ReadBigEndian(source, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N IBinaryIntegerCompatibility<Fix64N>.ReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned) => ReadLittleEndian(source, isUnsigned);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N INumberBaseCompatibility<Fix64N>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
            [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)] Fix64N ISpanParsableCompatibility<Fix64N>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, provider);
#endif
        }
#endif
        #endregion
    }
}
