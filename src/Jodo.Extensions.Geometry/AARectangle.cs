﻿// Copyright (c) 2022 Joseph J. Short
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

using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct AARectangle<N> :
            IEquatable<AARectangle<N>>,
            IFormattable,
            IProvider<IBitConverter<AARectangle<N>>>,
            IProvider<IRandom<AARectangle<N>>>,
            IProvider<IStringParser<AARectangle<N>>>,
            ITwoDimensional<AARectangle<N>, N>,
            IRotatable<Rectangle<N>, Angle<N>, Vector2<N>>,
            ISerializable
        where N : struct, INumeric<N>
    {
        private const string Symbol = "□";

        public readonly Vector2<N> Center;
        public readonly Vector2<N> Dimensions;

        public N Bottom => Center.Y - (Dimensions.Y / Cast<N>.ToNumeric(2));
        public N Height => Dimensions.Y;
        public N Left => Center.X - (Dimensions.X / Cast<N>.ToNumeric(2));
        public N Right => Center.X + (Dimensions.X / Cast<N>.ToNumeric(2));
        public N Top => Center.Y + (Dimensions.Y / Cast<N>.ToNumeric(2));
        public N Width => Dimensions.X;

        public Vector2<N> BottomCenter => GetBottomCenter(Center, Dimensions);
        public Vector2<N> BottomLeft => GetBottomLeft(Center, Dimensions);
        public Vector2<N> BottomRight => GetBottomRight(Center, Dimensions);
        public Vector2<N> LeftCenter => GetLeftCenter(Center, Dimensions);
        public Vector2<N> RightCenter => GetRightCenter(Center, Dimensions);
        public Vector2<N> TopCenter => GetTopCenter(Center, Dimensions);
        public Vector2<N> TopLeft => GetTopLeft(Center, Dimensions);
        public Vector2<N> TopRight => GetTopRight(Center, Dimensions);


        private AARectangle(Vector2<N> center, Vector2<N> dimensions)
        {
            Center = center;
            Dimensions = dimensions;
        }

        private AARectangle(N centerX, N centerY, N width, N height)
        {
            Center = new Vector2<N>(centerX, centerY);
            Dimensions = new Vector2<N>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<N>)info.GetValue(nameof(Center), typeof(Vector2<N>)),
            (Vector2<N>)info.GetValue(nameof(Dimensions), typeof(Vector2<N>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2<N>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<N>));
        }

        public N GetArea() => Math<N>.Abs(Dimensions.X * Dimensions.Y);
        public ReadOnlySpan<Vector2<N>> GetVertices() => new[] { BottomLeft, BottomRight, TopRight, TopLeft };

        public AARectangle<N> Grow(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions + delta);
        public AARectangle<N> Grow((N, N) delta) => Grow((Vector2<N>)delta);
        public AARectangle<N> Grow(N deltaX, N deltaY) => Grow(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Grow(N delta) => Grow(new Vector2<N>(delta, delta));
        public AARectangle<N> Shrink(Vector2<N> delta) => new AARectangle<N>(Center, Dimensions - delta);
        public AARectangle<N> Shrink((N, N) delta) => Shrink((Vector2<N>)delta);
        public AARectangle<N> Shrink(N deltaX, N deltaY) => Shrink(new Vector2<N>(deltaX, deltaY));
        public AARectangle<N> Shrink(N delta) => Shrink(new Vector2<N>(delta, delta));
        public AARectangle<N> Translate(Vector2<N> delta) => new AARectangle<N>(Center + delta, Dimensions);

        public bool Contains(Vector2<N> point) => point.X >= Left && point.X <= Right && point.Y >= Bottom && point.Y <= Top;

        public bool Contains(AARectangle<N> other) => throw new NotImplementedException();
        public bool IntersectsWith(AARectangle<N> other) => Left < other.Right && Right > other.Left && Bottom < other.Top && Top > other.Bottom;

        public AARectangle<N> RotateRight() => new AARectangle<N>(Center, (Dimensions.Y, Dimensions.X));

        public Rectangle<N> Rotate(Angle<N> angle) => new Rectangle<N>(Center, Dimensions, angle);
        public Rectangle<N> RotateAround(Vector2<N> pivot, Angle<N> angle) => new Rectangle<N>(Center.RotateAround(pivot, angle), Dimensions, angle);

        public (N, N, N, N) Convert() => this;
        public AARectangle<TOther> Convert<TOther>(Func<N, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<N> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<N> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions);
        public override string ToString() => $"{Symbol}({Center}, {Dimensions})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({Center.ToString(format, formatProvider)}, {Dimensions.ToString(format, formatProvider)})";

        public static bool TryParse(string value, out AARectangle<N> result)
            => Try.Run(() => Parse(value), out result);

        public static bool TryParse(string value, NumberStyles style, IFormatProvider? provider, out AARectangle<N> result)
            => Try.Run(() => Parse(value, style, provider), out result);

        public static AARectangle<N> Parse(string value)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new AARectangle<N>(
                    Vector2<N>.Parse(parts[0]),
                    Vector2<N>.Parse(parts[1]));
            if (parts.Length == 4)
                return new AARectangle<N>(
                    StringParser<N>.Parse(parts[0]),
                    StringParser<N>.Parse(parts[1]),
                    StringParser<N>.Parse(parts[2]),
                    StringParser<N>.Parse(parts[2]));
            else throw new FormatException();
        }

        public static AARectangle<N> Parse(string value, NumberStyles style, IFormatProvider? provider)
        {
            var parts = StringUtilities.ParseVectorParts(value.Replace(Symbol, string.Empty));
            if (parts.Length == 2)
                return new AARectangle<N>(
                    Vector2<N>.Parse(parts[0], style, provider),
                    Vector2<N>.Parse(parts[1], style, provider));
            if (parts.Length == 4)
                return new AARectangle<N>(
                    StringParser<N>.Parse(parts[0], style, provider),
                    StringParser<N>.Parse(parts[1], style, provider),
                    StringParser<N>.Parse(parts[2], style, provider),
                    StringParser<N>.Parse(parts[2], style, provider));
            else throw new FormatException();
        }

        public static AARectangle<N> FromCenter(Vector2<N> center, Vector2<N> dimensions) => new AARectangle<N>(center, dimensions);
        public static AARectangle<N> FromBottomLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromBottomRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromLeftCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromRightCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopLeft(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopCenter(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<N> FromTopRight(Vector2<N> bottomLeft, Vector2<N> dimensions) => new AARectangle<N>(GetBottomLeft(bottomLeft, dimensions), dimensions);

        private static Vector2<N> GetBottomCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetBottomLeft(Vector2<N> center, Vector2<N> dimensions) => center - (dimensions / Numeric<N>.Two);
        private static Vector2<N> GetBottomRight(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y - (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetLeftCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y);
        private static Vector2<N> GetRightCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X + (dimensions.X / Numeric<N>.Two), center.Y);
        private static Vector2<N> GetTopCenter(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X, center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetTopLeft(Vector2<N> center, Vector2<N> dimensions) => new Vector2<N>(center.X - (dimensions.X / Numeric<N>.Two), center.Y + (dimensions.Y / Numeric<N>.Two));
        private static Vector2<N> GetTopRight(Vector2<N> center, Vector2<N> dimensions) => center + (dimensions / Numeric<N>.Two);

        public static bool operator ==(AARectangle<N> left, AARectangle<N> right) => left.Equals(right);
        public static bool operator !=(AARectangle<N> left, AARectangle<N> right) => !(left == right);
        public static implicit operator AARectangle<N>((N, N, N, N) value) => new AARectangle<N>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (N, N, N, N)(AARectangle<N> value) => (value.Center.X, value.Center.Y, value.Dimensions.X, value.Dimensions.Y);
        public static implicit operator AARectangle<N>((Vector2<N>, Vector2<N>) value) => new AARectangle<N>(value.Item1, value.Item2);
        public static implicit operator (Vector2<N>, Vector2<N>)(AARectangle<N> value) => (value.Center, value.Dimensions);

        Vector2<N> ITwoDimensional<AARectangle<N>, N>.GetCenter() => Center;
        AARectangle<N> ITwoDimensional<AARectangle<N>, N>.GetBounds() => this;
        ReadOnlySpan<Vector2<N>> ITwoDimensional<AARectangle<N>, N>.GetVertices(int pointsPerRadian) => GetVertices();

        IBitConverter<AARectangle<N>> IProvider<IBitConverter<AARectangle<N>>>.GetInstance() => Utilities.Instance;
        IRandom<AARectangle<N>> IProvider<IRandom<AARectangle<N>>>.GetInstance() => Utilities.Instance;
        IStringParser<AARectangle<N>> IProvider<IStringParser<AARectangle<N>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<AARectangle<N>>,
           IRandom<AARectangle<N>>,
           IStringParser<AARectangle<N>>
        {
            public readonly static Utilities Instance = new Utilities();

            AARectangle<N> IRandom<AARectangle<N>>.Next(Random random)
            {
                throw new NotImplementedException();
            }

            AARectangle<N> IRandom<AARectangle<N>>.Next(Random random, AARectangle<N> bound1, AARectangle<N> bound2)
            {
                throw new NotImplementedException();
            }

            AARectangle<N> IStringParser<AARectangle<N>>.Parse(string s)
            {
                throw new NotImplementedException();
            }

            AARectangle<N> IStringParser<AARectangle<N>>.Parse(string s, NumberStyles style, IFormatProvider? provider)
            {
                throw new NotImplementedException();
            }

            AARectangle<N> IBitConverter<AARectangle<N>>.Read(IReadOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }

            void IBitConverter<AARectangle<N>>.Write(AARectangle<N> value, IWriteOnlyStream<byte> stream)
            {
                throw new NotImplementedException();
            }
        }
    }
}
