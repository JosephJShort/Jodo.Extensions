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

using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics.Compatibility
{
    public static class SubtractionOperatorsExtensions
    {
        /// <summary>Subtracts two values to compute their difference.</summary>
        /// <param name="left">The value from which <paramref name="right" /> is subtracted.</param>
        /// <param name="right">The value which is subtracted from <paramref name="left" />.</param>
        /// <returns>The difference of <paramref name="right" /> subtracted from <paramref name="left" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Subtract<T, TOther, TResult>(this T left, TOther right) where T : ISubtractionOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left - right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, ISubtractionOperatorsCompatibility<T, TOther, TResult>>().Subtract(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="Subtract{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Subtract<T, TOther, TResult>(this ISubtractionOperators<T, TOther, TResult> left, TOther right) where T : ISubtractionOperators<T, TOther, TResult>, new()
            => Subtract<T, TOther, TResult>((T)left, right);
    }
}
