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
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines the base of other number types.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
    /// </remarks>
    public interface INumberBase<TSelf> :
        IProvider<INumberBaseCompatibility<TSelf>>,
        IAdditionOperators<TSelf, TSelf, TSelf>,
        IAdditiveIdentity<TSelf, TSelf>,
        IDecrementOperators<TSelf>,
        IDivisionOperators<TSelf, TSelf, TSelf>,
        IEquatable<TSelf>,
        IEqualityOperators<TSelf, TSelf, bool>,
        IIncrementOperators<TSelf>,
        IMultiplicativeIdentity<TSelf, TSelf>,
        IMultiplyOperators<TSelf, TSelf, TSelf>,
#if HAS_SPANS
        ISpanFormattable,
        ISpanParsable<TSelf>,
#else
        IFormattable,
        IParsable<TSelf>,
#endif
        ISubtractionOperators<TSelf, TSelf, TSelf>,
        IUnaryPlusOperators<TSelf, TSelf>,
        IUnaryNegationOperators<TSelf, TSelf>
    where TSelf : INumberBase<TSelf>?, new()
    {
    }
}

#endif
