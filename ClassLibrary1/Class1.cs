namespace ClassLibrary1
{
    public class Class1 : IClass1
    {
        public IDictionary<int, string> PrintValue(int start, int max, List<Tuple<int, string>> rules)
        {
            IDictionary<int, string> printedValues = new Dictionary<int, string>();
            for (var x = start; x <= max; x++)
            {
                var ruleValue = "";
                foreach (var rule in rules)
                {
                    if (x % rule.Item1 == 0)
                    {
                        ruleValue += rule.Item2;
                    }
                }
                if (string.IsNullOrEmpty(ruleValue))
                {
                    ruleValue = x.ToString();
                }
                printedValues.Add(x, ruleValue);
            }

            return printedValues;          
                
        }
    }
}
