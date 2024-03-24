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
using System.Diagnostics.CodeAnalysis;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines a mechanism for getting the additive identity of a given type.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    /// <typeparam name="TResult">The type that contains the additive identify of <typeparamref name="T" />.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    [SuppressMessage("csharpsquid", "S3246:Generic type parameters should be co/contravariant when possible.", Justification = "Mirroring the .NET API.")]
    public interface IAdditiveIdentityCompatibility<T, TResult>
        where T : IAdditiveIdentity<T, TResult>?, new()
    {
        /// <summary>Gets the additive identity of the current type.</summary>
        /// <remarks>Use <see cref="Number.AdditiveIdentity{T}"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.AdditiveIdentity to ensure compatibility with all .NET targets.")]
        TResult AdditiveIdentity { get; }
    }
}

#endif
