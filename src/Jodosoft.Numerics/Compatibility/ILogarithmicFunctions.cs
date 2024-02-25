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
    /// <summary>Defines support for logarithmic functions.</summary>
    /// <typeparam name="TSelf">The type that implements this interface.</typeparam>
    public interface ILogarithmicFunctions<TSelf>
        : IFloatingPointConstants<TSelf>
        where TSelf : ILogarithmicFunctions<TSelf>?, new()
    {
        /// <summary>Computes the natural (<c>base-E</c>) logarithm of a value.</summary>
        /// <param name="x">The value whose natural logarithm is to be computed.</param>
        /// <returns><c>log<sub>e</sub>(<paramref name="x" />)</c></returns>
        TSelf Log(TSelf x);

        /// <summary>Computes the logarithm of a value in the specified base.</summary>
        /// <param name="x">The value whose logarithm is to be computed.</param>
        /// <param name="newBase">The base in which the logarithm is to be computed.</param>
        /// <returns><c>log<sub><paramref name="newBase" /></sub>(<paramref name="x" />)</c></returns>
        TSelf Log(TSelf x, TSelf newBase);

        /// <summary>Computes the base-2 logarithm of a value.</summary>
        /// <param name="x">The value whose base-2 logarithm is to be computed.</param>
        /// <returns><c>log<sub>2</sub>(<paramref name="x" />)</c></returns>
        TSelf Log2(TSelf x);

        /// <summary>Computes the base-10 logarithm of a value.</summary>
        /// <param name="x">The value whose base-10 logarithm is to be computed.</param>
        /// <returns><c>log<sub>10</sub>(<paramref name="x" />)</c></returns>
        TSelf Log10(TSelf x);

        /*
        /// <summary>Computes the natural (<c>base-E</c>) logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the natural logarithm.</param>
        /// <returns><c>log<sub>e</sub>(<paramref name="x" /> + 1)</c></returns>
        static virtual TSelf LogP1(TSelf x) => TSelf.Log(x + TSelf.One);

        /// <summary>Computes the base-2 logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the base-2 logarithm.</param>
        /// <returns><c>log<sub>2</sub>(<paramref name="x" /> + 1)</c></returns>
        static virtual TSelf Log2P1(TSelf x) => TSelf.Log2(x + TSelf.One);

        /// <summary>Computes the base-10 logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the base-10 logarithm.</param>
        /// <returns><c>log<sub>10</sub>(<paramref name="x" /> + 1)</c></returns>
        static virtual TSelf Log10P1(TSelf x) => TSelf.Log10(x + TSelf.One);*/
    }
}

#endif
