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

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines support for floating-point constants.</summary>
    /// <typeparam name="T">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IFloatingPointConstantsCompatibility<T>
        where T : IFloatingPointConstants<T>?, new()
    {
        /// <summary>Gets the mathematical constant <c>e</c>.</summary>
        /// <remarks>Use <see cref="MathN2.E{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.E to ensure forward-compatibility.")]
        T E { get; }

        /// <summary>Gets the mathematical constant <c>pi</c>.</summary>
        /// <remarks>Use <see cref="MathN2.Pi{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Pi to ensure forward-compatibility.")]
        T Pi { get; }

        /// <summary>Gets the mathematical constant <c>tau</c>.</summary>
        /// <remarks>Use <see cref="MathN2.Tau{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Tau to ensure forward-compatibility.")]
        T Tau { get; }
    }
}

#endif
