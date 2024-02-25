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
    /// <summary>Defines a mechanism for performing bitwise operations over two values.</summary>
    /// <typeparam name="TSelf">The type that implements this interface.</typeparam>
    /// <typeparam name="TOther">The type that will is used in the operation with <typeparamref name="TSelf" />.</typeparam>
    /// <typeparam name="TResult">The type that contains the result of <typeparamref name="TSelf" /> op <typeparamref name="TOther" />.</typeparam>
    public interface IBitwiseOperators<TSelf, TOther, TResult>
        where TSelf : IBitwiseOperators<TSelf, TOther, TResult>?, new()
    {
        /// <summary>Computes the bitwise-and of two values.</summary>
        /// <param name="left">The value to and with <paramref name="right" />.</param>
        /// <param name="right">The value to and with <paramref name="left" />.</param>
        /// <returns>The bitwise-and of <paramref name="left" /> and <paramref name="right" />.</returns>
        TResult LogicalAnd(TSelf? left, TOther? right);

        /// <summary>Computes the bitwise-or of two values.</summary>
        /// <param name="left">The value to or with <paramref name="right" />.</param>
        /// <param name="right">The value to or with <paramref name="left" />.</param>
        /// <returns>The bitwise-or of <paramref name="left" /> and <paramref name="right" />.</returns>
        TResult LogicalOr(TSelf? left, TOther? right);

        /// <summary>Computes the exclusive-or of two values.</summary>
        /// <param name="left">The value to xor with <paramref name="right" />.</param>
        /// <param name="right">The value to xorwith <paramref name="left" />.</param>
        /// <returns>The exclusive-or of <paramref name="left" /> and <paramref name="right" />.</returns>
        TResult LogicalExclusiveOr(TSelf? left, TOther? right);

        /// <summary>Computes the ones-complement representation of a given value.</summary>
        /// <param name="value">The value for which to compute its ones-complement.</param>
        /// <returns>The ones-complement of <paramref name="value" />.</returns>
        TResult BitwiseComplement(TSelf? value);
    }
}

#endif
