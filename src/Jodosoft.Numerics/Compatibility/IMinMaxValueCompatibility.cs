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

using System;

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines a mechanism for getting the minimum and maximum value of a type.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface IMinMaxValueCompatibility<T>
        where T : IMinMaxValue<T>?, new()
    {
        /// <summary>Gets the minimum value of the current type.</summary>
        /// <remarks>Use <see cref="Number.MinValue{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.MinValue to ensure forward-compatibility.")]
        T MinValue { get; }

        /// <summary>Gets the maximum value of the current type.</summary>
        /// <remarks>Use <see cref="Number.MaxValue{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.MaxValue to ensure forward-compatibility.")]
        T MaxValue { get; }
    }
}

#endif
