namespace ClassLibrary1
{
    public class Class1 : IClass1
    {

        /** In theory, this solution would work for all numbers up to int.MaxValue, which is 2,147,483,647.
            However, due to performance of machines, this is an impractical maximum. This solution should work 
            up to 100 thousand (100,000) without significant notice of the performance loss. If the customer
            did need to produce lists over that 100 thousand mark, we would need to rewrite this to allow for 
            paging, where they would be able to request how many on the result set and we could call into this
            method with a change in the lower and upper bounds to provide for those pages. 
        **/
        public ICollection<string> PrintValue(int start, int max, List<Tuple<int, string>> rules)
        {
            IList<string> printedValues = [];
            if (rules is null)
            {
                rules = new List<Tuple<int, string>>();
            }
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
                printedValues.Add(ruleValue);
            }

            return printedValues;          
                
        }
    }
}
