using System;
using System.Linq;
using System.Reactive.Linq;
using NUnit.Framework;
using MorseCodeInterpreter;
using System.Reactive.Subjects;

namespace MorseCodeInterpreterTests
{
    [TestFixture]
    public class MorseCodeInterpreterTests
    {
        private Subject<char> _source;
        private string _translated;

        [SetUp]
        public void SetUp()
        {
            _source = new Subject<char>();
            var result = _source.TranslateMorseCode();
            _translated = string.Empty;
            result.Subscribe(xs => xs.ToArray().Subscribe(ys => _translated +=  ys.Last()));
        }


        [Test]
        public void ShouldParseADotAsAnE()
        {
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("E", _translated);
        }

        [Test]
        public void ShouldParseTwoDotsAsAnI()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("I", _translated);
        }

        [Test]
        public void ShouldParseThreeDotsAsAnS()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("S", _translated);
        }

        [Test]
        public void ShouldParseFourDotsAsAnH()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("H", _translated);
        }

        [Test]
        public void ShouldParseFiveDotsAsA5()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("5", _translated);
        }

        [Test]
        public void ShouldParseSixDotsAsUndefined()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseADotAndADashAsAnA()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("A", _translated);
        }

        [Test]
        public void ShouldParseADotAndTwoDashesAsaW()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("W", _translated);
        }

        [Test]
        public void ShouldParseADotAndThreeDashesAsaJ()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("J", _translated);
        }

        [Test]
        public void ShouldParseADotAndFourDashesAsa1()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("1", _translated);
        }

        [Test]
        public void ShouldParseADotAndFiveDashesAsUndefined()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseTwoDotsAndADashAsAnU()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("U", _translated);
        }

        [Test]
        public void ShouldParseTwoDotsAndATwoDashesAsUndefined()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseThreeDotsAndOneDashasaV()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("V", _translated);
        }

        [Test]
        public void ShouldParseThreeDotsAndTwoDashesAsA3()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("3", _translated);
        }

        [Test]
        public void ShouldParseThreeDotsAndThreeDashesAsAUndefined()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseADashAsaT()
        {
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("T", _translated);
        }

        [Test]
        public void ShouldParseADashAndADotAsAnN()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("N", _translated);
        }

        [Test]
        public void ShouldParseADashAndTwoDotsAsaD()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("D", _translated);
        }

        [Test]
        public void ShouldParseADashAndThreeDotsAsaB()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("B", _translated);
        }

        [Test]
        public void ShouldParseADashAndFourDotsAsa6()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("6", _translated);
        }

        [Test]
        public void ShouldParseADashAndFiveDotsAsUndefined()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseTwoDashesAsAnM()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("M", _translated);
        }

        [Test]
        public void ShouldParseTwoDashesAndADotAsaG()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("G", _translated);
        }

        [Test]
        public void ShouldParseTwoDashesAndTwoDotsAsaZ()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("Z", _translated);
        }

        [Test]
        public void ShouldParseTwoDashesAndThreeDotsAsa7()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("7", _translated);
        }

        [Test]
        public void ShouldParseTwoDashesAndFourDotsAsUndefined()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseThreeDashesAsAnO()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("O", _translated);
        }

        [Test]
        public void ShouldParseThreeDashesAndADotAsUndefined()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("", _translated);
        }

        [Test]
        public void ShouldParseDashDotDashAsaK()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("K", _translated);
        }

        [Test]
        public void ShouldParseDashDotDashDotAsaC()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("C", _translated);
        }

        [Test]
        public void ShouldParseDotDotDashDotAsanF()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("F", _translated);
        }

        [Test]
        public void ShouldParseDotDashDotAsAnR()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("R", _translated);
        }

        [Test]
        public void ShouldParseDotDashDotDotAsL()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("L", _translated);
        }

        [Test]
        public void ShouldParseDotDashDashAsW()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("W", _translated);
        }

        [Test]
        public void ShouldParseDotDashDashDotAsP()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("P", _translated);
        }

        [Test]
        public void ShouldParseDashDashDotDashAsQ()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("Q", _translated);
        }

        [Test]
        public void ShouldParseFourDotsAndOneDashAsa4()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("4", _translated);
        }

        [Test]
        public void ShouldParseTwoDotsAndThreeDashesAs2()
        {
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("2", _translated);
        }

        [Test]
        public void ShouldParseThreeDashesAndTwoDotsAs8()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("8", _translated);
        }

        [Test]
        public void ShouldParseFourDashesAndOneDotAs9()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("9", _translated);
        }

        [Test]
        public void ShouldParseFiveDashesAsZero()
        {
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("0", _translated);
        }

        [Test]
        public void ShouldParsedDashDotDotDashAsX()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("X", _translated);
        }

        [Test]
        public void ShouldParsedDashDotDashDashAsY()
        {
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext('-');
            _source.OnCompleted();
            Assert.AreEqual("Y", _translated);
        }

        [Test]
        public void ShouldParseTwoChars()
        {
            _source.OnNext('.');
            _source.OnNext('-');
            _source.OnNext(' ');
            _source.OnNext('-');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnNext('.');
            _source.OnCompleted();
            Assert.AreEqual("AB", _translated);
        }

        [Test]
        public void ShouldParseHello()
        {
            foreach (var ch in ".... . .-.. .-.. ---")
                _source.OnNext(ch);
            _source.OnCompleted();
            Assert.AreEqual("HELLO", _translated);
        }
    }
}
