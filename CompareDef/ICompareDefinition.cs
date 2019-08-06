using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDef
{
    public interface ICompareDefinition
    {
        List<string> Compare(List<string> lines1, List<string> lines2);
    }
}
