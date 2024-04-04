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

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    public static class FloatingPointExtensions
    {
        /*
        /// <summary>Writes the current exponent, in big-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteExponentBigEndian<T>(this T instance, byte[] destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current exponent, in big-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current exponent should be written.</param>
        /// <param name="startIndex">The starting index at which the exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteExponentBigEndian<T>(this T instance, byte[] destination, int startIndex) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentBigEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current exponent, in big-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteExponentBigEndian<T>(this T instance, Span<byte> destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current exponent, in little-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteExponentLittleEndian<T>(this T instance, byte[] destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current exponent, in little-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current exponent should be written.</param>
        /// <param name="startIndex">The starting index at which the exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteExponentLittleEndian<T>(this T instance, byte[] destination, int startIndex) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentLittleEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current exponent, in little-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteExponentLittleEndian<T>(this T instance, Span<byte> destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteExponentLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in big-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteSignificandBigEndian<T>(this T instance, byte[] destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in big-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current significand should be written.</param>
        /// <param name="startIndex">The starting index at which the significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteSignificandBigEndian<T>(this T instance, byte[] destination, int startIndex) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandBigEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in big-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteSignificandBigEndian<T>(this T instance, Span<byte> destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in little-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteSignificandLittleEndian<T>(this T instance, byte[] destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in little-endian format, to a given array.</summary>
        /// <param name="destination">The array to which the current significand should be written.</param>
        /// <param name="startIndex">The starting index at which the significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteSignificandLittleEndian<T>(this T instance, byte[] destination, int startIndex) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandLittleEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current significand, in little-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteSignificandLittleEndian<T>(this T instance, Span<byte> destination) where T : IFloatingPoint<T>, new()
        {
            if (!instance.TryWriteSignificandLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }
        */
    }
}

#endif
