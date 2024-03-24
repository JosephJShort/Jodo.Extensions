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
    /// <summary>Defines support for logarithmic functions.</summary>
    /// <remarks>
    ///     This is a shim for <see href="https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Numerics/ILogarithmicFunctions.cs">System.Numerics.ILogarithmicFunctions&lt;TSelf&gt;</see>
    ///     for targets below .NET 7.
    /// </remarks>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface ILogarithmicFunctionsCompatibility<T>
        where T : ILogarithmicFunctions<T>?, new()
    {
        /// <summary>Computes the natural (<c>base-E</c>) logarithm of a value.</summary>
        /// <remarks>Use <see cref="MathN.Log{T}(T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Log to ensure compatibility with all .NET targets.")]
        T Log(T x);

        /// <summary>Computes the logarithm of a value in the specified base.</summary>
        /// <remarks>Use <see cref="MathN.Log{T}(T, T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Log to ensure compatibility with all .NET targets.")]
        T Log(T x, T newBase);

        /// <summary>Computes the base-2 logarithm of a value.</summary>
        /// <remarks>Use <see cref="MathN.Log2{T}(T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Log2 to ensure compatibility with all .NET targets.")]
        T Log2(T x);

        /// <summary>Computes the base-10 logarithm of a value.</summary>
        /// <remarks>Use <see cref="MathN.Log10{T}(T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Log10 to ensure compatibility with all .NET targets.")]
        T Log10(T x);
    }
}

#endif
