﻿// Copyright (c) 2022 Joseph J. Short
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

using Jodo.Primitives.Tests;

namespace Jodo.Numerics.Tests
{
    public static class ByteNTests
    {
        public sealed class BitConvertTests : BitConvertTestBase<ByteN> { }
        public sealed class NumericBitConvertTests : NumericBitConvertTestBase<ByteN> { }
        public sealed class NumericCastTests : NumericCastTestBase<ByteN> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<ByteN> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ByteN> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<ByteN> { }
        public sealed class NumericMathTests : NumericMathTestBase<ByteN> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<ByteN> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<ByteN> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<ByteN> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ByteN> { }
        public sealed class NumericTests : NumericTestBase<ByteN> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<ByteN> { }
        public sealed class ObjectTests : ObjectTestBase<ByteN> { }
        public sealed class RandomTests : RandomTestBase<ByteN> { }
        public sealed class SerializableTests : SerializableTestBase<ByteN> { }
        public sealed class StringConvertTests : StringConvertTestBase<ByteN> { }
    }
}
