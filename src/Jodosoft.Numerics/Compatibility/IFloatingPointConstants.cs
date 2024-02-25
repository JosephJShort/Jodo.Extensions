﻿// Copyright (c) 2023 Joe Lawry-Short
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

using System;

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines support for floating-point constants.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    public interface IFloatingPointConstants<TSelf>
        : INumberBase<TSelf>
        where TSelf : IFloatingPointConstants<TSelf>?, new()
    {
        /// <summary>Gets the mathematical constant <c>e</c>.</summary>
        /// <remarks>Use <see cref="MathN.E{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.E")]
        TSelf E { get; }

        /// <summary>Gets the mathematical constant <c>pi</c>.</summary>
        /// <remarks>Use <see cref="MathN.Pi{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Pi")]
        TSelf Pi { get; }

        /// <summary>Gets the mathematical constant <c>tau</c>.</summary>
        /// <remarks>Use <see cref="MathN.Tau{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Tau")]
        TSelf Tau { get; }
    }
}

#endif
