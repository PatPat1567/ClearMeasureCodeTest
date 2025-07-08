using ClassLibrary1;
using NuGet.Frameworks;
using Xunit.Sdk;

namespace Library.Tests
{
    public class UnitTest1
    {
        private readonly IClass1 classLibrary;

        public UnitTest1()
        {
            classLibrary = new Class1();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 10)]
        [InlineData(1, 50)]
        [InlineData(1, 100)]
        public void ReturnsAListOfNumbersWhenNoRulesProvided(int min, int max)
        {
            var values = classLibrary.PrintValue(min, max, null);

            Assert.True(values.All(x => x == values.ElementAt(int.Parse(x) - min)));
        }

        [Theory]
        [InlineData(3, "patrick")]
        [InlineData(5, "towle")]
        public void ReturnsRuleResultWhenRuleValueIsEvaluated(int ruleValue, string ruleResult)
        {
            var rules = new List<Tuple<int, string>>
            {
                new(ruleValue, ruleResult)
            };
            var min = 1;

            var values = classLibrary.PrintValue(1, ruleValue, rules);

            Assert.Equal(ruleResult, values.ElementAt(ruleValue - min));
        }

        [Fact]
        public void ReturnsConcatinatedResultsWhenMultipleRulesAreEvaluated()
        {
            var rules = new List<Tuple<int, string>>
            {
                new(3, "patrick"),
                new(5, "towle")
            };
            var min = 1;
            var max = 15;

            var values = classLibrary.PrintValue(min, max, rules);

            Assert.Equal("patricktowle", values.ElementAt(max - min));
        }

        [Fact]
        public void ReturnsCorrectListWhenProvidedRules()
        {
            var rule1 = new Tuple<int, string>(3, "patrick");
            var rule2 = new Tuple<int, string>(5, "towle");
            var rules = new List<Tuple<int, string>>
            {
                rule1, rule2
            };
            var min = 1;
            var max = 100;

            var values = classLibrary.PrintValue(1, 100, rules);

            for (var x = min; x <= max; x++)
            {
                if (x % rule1.Item1 == 0)
                {
                    Assert.Contains(rule1.Item2, values.ElementAt(x - min));
                }
                if (x % rule2.Item1 == 0)
                {
                    Assert.Contains(rule2.Item2, values.ElementAt(x - min));
                }
                if (x % 3 != 0 && x % 5 != 0)
                {
                    Assert.Contains(x.ToString(), values.ElementAt(x - min));
                }
            }
        }

        [Fact]
        public void ReturnsCorrectListWhenProvidedManyRules()
        {
            var rule1 = new Tuple<int, string>(3, "patrick");
            var rule2 = new Tuple<int, string>(5, "towle");
            var rule3 = new Tuple<int, string>(7, "Jeffrey");
            var rules = new List<Tuple<int, string>>
            {
                rule1, rule2,  rule3
            };
            var min = 1;
            var max = 100;

            var values = classLibrary.PrintValue(1, 100, rules);

            for (var x = min; x <= max; x++)
            {
                if (x % rule1.Item1 == 0)
                {
                    Assert.Contains(rule1.Item2, values.ElementAt(x - min));
                }
                if (x % rule2.Item1 == 0)
                {
                    Assert.Contains(rule2.Item2, values.ElementAt(x - min));
                }
                if (x % rule3.Item1 == 0)
                {
                    Assert.Contains(rule3.Item2, values.ElementAt(x - min));
                }
                if (x % rule1.Item1 != 0 && x % rule2.Item1 != 0 && x % rule3.Item1 != 0)
                {
                    Assert.Contains(x.ToString(), values.ElementAt(x - min));
                }
            }
        }

        [Fact]
        public void ReturnsAnEmptyListWhenMaxValueIsBelowStart()
        {
            var values = classLibrary.PrintValue(1, 0, null);

            Assert.Empty(values);
        }
    }
}