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

using Jodosoft.Primitives.Compatibility.Jodosoft.Primitives.Compatibility;

#if HAS_SPANS && !NET7_0_OR_GREATER

namespace Jodosoft.Primitives.Compatibility
{
    /// <summary>Defines a mechanism for parsing a span of characters to a value.</summary>
    /// <typeparam name="TSelf">The type that implements this interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility with <c>System.ISpanParsable</c> for .NET targets below .NET 7.
    /// </remarks>
    public interface ISpanParsable<TSelf>
        : IProvider<ISpanParsableCompatibility<TSelf>>,
          IParsable<TSelf>
        where TSelf : ISpanParsable<TSelf>?, new()
    {
    }
}

#endif
