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

#if !HAS_SYSTEM_NUMERICS && HAS_SPANS

namespace Jodosoft.Numerics.Compatibility
{
    public static class BinaryIntegerExtensions
    {
        /// <summary>Writes the current value, in big-endian format, to a given array.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The array to which the current value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteBigEndian<T>(this T instance, byte[] destination) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current value, in big-endian format, to a given array.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The array to which the current value should be written.</param>
        /// <param name="startIndex">The starting index at which the value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteBigEndian<T>(this T instance, byte[] destination, int startIndex) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteBigEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current value, in big-endian format, to a given span.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The span to which the current value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteBigEndian<T>(this T instance, Span<byte> destination) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteBigEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current value, in little-endian format, to a given array.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The array to which the current value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteLittleEndian<T>(this T instance, byte[] destination) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current value, in little-endian format, to a given array.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The array to which the current value should be written.</param>
        /// <param name="startIndex">The starting index at which the value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" /> starting at <paramref name="startIndex" />.</returns>
        public static int WriteLittleEndian<T>(this T instance, byte[] destination, int startIndex) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteLittleEndian(destination.AsSpan(startIndex), out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }

        /// <summary>Writes the current value, in little-endian format, to a given span.</summary>
        /// <param name="instance"></param>
        /// <param name="destination">The span to which the current value should be written.</param>
        /// <returns>The number of bytes written to <paramref name="destination" />.</returns>
        public static int WriteLittleEndian<T>(this T instance, Span<byte> destination) where T : IBinaryInteger<T>, new()
        {
            if (!instance.TryWriteLittleEndian(destination, out int bytesWritten))
            {
                throw new ArgumentException("Destination is too short.", nameof(destination));
            }
            return bytesWritten;
        }
    }
}

#endif
