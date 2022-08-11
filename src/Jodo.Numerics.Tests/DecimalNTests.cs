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

using System;
using FluentAssertions;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public sealed class DecimalNTests : GlobalFixtureBase
    {
        public sealed class BitConvertTests : BitConvertTestsBase<DecimalN> { }
        public sealed class CastTests : CastTests<DecimalN> { }
        public sealed class ConvertTests : ConvertTests<DecimalN> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<DecimalN> { }
        public sealed class MathFloatingPoint : MathTestsBase.FloatingPoint<DecimalN> { }
        public sealed class MathGeneral : MathTestsBase.General<DecimalN> { }
        public sealed class MathReal : MathTestsBase.Real<DecimalN> { }
        public sealed class MathSigned : MathTestsBase.SingedOnly<DecimalN> { }
        public sealed class NumericGeneral : NumericTestsBase.General<DecimalN> { }
        public sealed class NumericReal : NumericTestsBase.Real<DecimalN> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<DecimalN> { }
        public sealed class NumericWrapperTests : NumericWrapperTestsBase.General<DecimalN, decimal> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<DecimalN> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<DecimalN> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<DecimalN> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<DecimalN> { }

        [Test, Repeat(RandomVariations)]
        public void IsFinite_RandomValue_AlwaysTrue()
        {
            //arrange
            byte[] bytes = BitConvert.GetBytes<DecimalN>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            DecimalN input = BitConvert.FromBytes<DecimalN>(bytes);

            //act
            bool result = Numeric.IsFinite(input);

            //assert
            result.Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void IsInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConvert.GetBytes<DecimalN>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            DecimalN input = BitConvert.FromBytes<DecimalN>(bytes);

            //act
            bool result = Numeric.IsInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsPositiveInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConvert.GetBytes<DecimalN>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            DecimalN input = BitConvert.FromBytes<DecimalN>(bytes);

            //act
            bool result = Numeric.IsPositiveInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNegativeInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConvert.GetBytes<DecimalN>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            DecimalN input = BitConvert.FromBytes<DecimalN>(bytes);

            //act
            bool result = Numeric.IsNegativeInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNaN_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConvert.GetBytes<DecimalN>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            DecimalN input = Random.NextNumeric<DecimalN>();

            //act
            bool result = Numeric.IsNaN(input);

            //assert
            result.Should().BeFalse();
        }
    }
}
