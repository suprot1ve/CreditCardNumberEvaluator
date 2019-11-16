using CreditCardNumberEvaluator;
using NUnit.Framework;

namespace CreditCardNumberEvaluatorTest
{
	class CorrectCardNumberTests
	{
		private CardNumberEvaluator _evaluator;

		[SetUp]
		public void SetUp() => _evaluator = new CardNumberEvaluator();

		[Test]
		public void CardNumberStartWithZeroTest() => Assert.IsFalse(_evaluator.IsValidCardNumber("04929804463622139"));
		[Test]
		public void CardNumberIsLongerThanMaxTest() => Assert.IsFalse(_evaluator.IsValidCardNumber("49298044000063622139"));
		[Test]
		public void CardNumberIsShorterThanMinTest() => Assert.IsFalse(_evaluator.IsValidCardNumber("49298044634"));
		[Test]
		public void CardNumberIsOnlyDigitsTest() => Assert.IsFalse(_evaluator.IsValidCardNumber("gg4929804463622139"));
	}
}
