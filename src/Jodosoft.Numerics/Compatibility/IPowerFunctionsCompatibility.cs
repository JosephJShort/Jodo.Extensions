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
    /// <summary>Defines support for power functions.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IPowerFunctionsCompatibility<T>
        where T : IPowerFunctions<T>?, new()
    {
        /// <summary>Computes a value raised to a given power.</summary>
        /// <param name="x">The value which is raised to the power of <paramref name="x" />.</param>
        /// <param name="y">The power to which <paramref name="x" /> is raised.</param>
        /// <returns><paramref name="x" /> raised to the power of <paramref name="y" />.</returns>
        T Pow(T x, T y);
    }
}

#endif
