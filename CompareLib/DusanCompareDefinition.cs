using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompareDef;

namespace DusanCompareLib
{
    public class DusanCompareDefinition : ICompareDefinition
    {
        public IEnumerable<string> GetDifferences(List<string> lines1, List<string> lines2)
        {
            // pokud maji byt sekvence stejne, vyuziju extension SequenceEqual
            if (lines1.SequenceEqual(lines2))
                yield break;

            // pokud jsou sekvence stejne dlouhe, projedu je jednoduchym for cyklem
            else if (lines1.Count == lines2.Count)
            {
                int delka = lines1.Count;
                for (int i = 0; i < delka; i++)
                {
                    if (!lines1[i].Equals(lines2[i]))
                    {
                        yield return $"{lines1[i]} => {lines2[i]}";
                    }
                }
            }

            // pokud delky sekvenci nejsou stejne
            else if (lines1.Count != lines2.Count)
            {
                // zajisti pocty radku obou sekvenci a rozdil mezi nimi
                int delsi;
                int kratsi;
                int delta;

                if (lines1.Count > lines2.Count)
                {
                    delsi = lines1.Count;
                    kratsi = lines2.Count;
                }
                else
                {
                    delsi = lines2.Count;
                    kratsi = lines1.Count;
                }

                delta = delsi - kratsi;

                // todo : iterace

                yield return "Difference 1";
                yield return "Difference 2";
                yield return "Difference 3";
                yield return "Difference 4";
            }
                
        }
    }
}
