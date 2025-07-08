namespace ClassLibrary1
{
    public class Class1 : IClass1
    {
        public ICollection<string> PrintValue(int start, int max, List<Tuple<int, string>> rules)
        {
            IDictionary<int, string> printedValues = new Dictionary<int, string>();
            if (rules is null)
            {
                rules = new List<Tuple<int, string>>();
            }
            for (var x = start; x <= max; x++)
            {
                // Add unit tests
                // Clean up so it doesn't hang when passed int.max
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

            return printedValues.Values;          
                
        }
    }
}
