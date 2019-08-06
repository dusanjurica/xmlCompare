using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDef
{
    public interface ICompareDefinition
    {
        List<string> GetDifferences(List<string> lines1, List<string> lines2);
    }
}
