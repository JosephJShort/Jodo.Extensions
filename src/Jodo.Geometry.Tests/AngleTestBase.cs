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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public abstract class AngleTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            Angle<TNumeric> input1 = Random.NextVariant<Angle<TNumeric>>();
            Angle<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<Angle<TNumeric>>());

            //act
            //assert
            AssertSame.Outcome(
                () => input1.Equals(input2),
                () => input1.Equals((object)input2),
                () => input1 == input2,
                () => !(input1 != input2));
        }

        [Test]
        public void Degrees_FromDegrees_SameAsOriginal()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            TNumeric result = Angle.FromDegrees(input).Degrees;

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Cos_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Cos(subject.GetRadians()),
                () => subject.Cos());
        }

        [Test, Repeat(RandomVariations)]
        public void Cosh_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Cosh(subject.GetRadians()),
                () => subject.Cosh());
        }

        [Test, Repeat(RandomVariations)]
        public void Sin_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Sin(subject.GetRadians()),
                () => subject.Sin());
        }

        [Test, Repeat(RandomVariations)]
        public void Sinh_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Sinh(subject.GetRadians()),
                () => subject.Sinh());
        }

        [Test, Repeat(RandomVariations)]
        public void Tan_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Tan(subject.GetRadians()),
                () => subject.Tan());
        }

        [Test, Repeat(RandomVariations)]
        public void Tanh_RandomValues_SameAsMathN()
        {
            //arrange
            Angle<TNumeric> subject = Random.NextVariant<Angle<TNumeric>>();

            //act
            //assert
            AssertSame.Outcome(
                () => MathN.Tanh(subject.GetRadians()),
                () => subject.Tanh());
        }
    }
}
