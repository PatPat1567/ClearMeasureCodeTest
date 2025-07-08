using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IClass1
    {
        ICollection<string> PrintValue(int start, int max, List<Tuple<int, string>> rules);
    }
}
