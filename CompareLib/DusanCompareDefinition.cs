using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompareDef;

namespace CompareLib
{
    public class DusanCompareDefinition : ICompareDefinition
    {
        public List<string> Compare(List<string> lines1, List<string> lines2)
        {
            return new List<string>
            {
                "Difference 1",
                "Difference 2",
                "Difference 3",
                "Difference 4"
            };
        }
    }
}
