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
                int delsiPocet;
                int kratsiPocet;
                int delta;
                int flag0;

                List<string> kratsiList;
                List<string> delsiList;

                if (lines1.Count > lines2.Count)
                {
                    delsiPocet = lines1.Count;
                    kratsiPocet = lines2.Count;

                    delsiList = lines1;
                    kratsiList = lines2;
                }
                else
                {
                    delsiPocet = lines2.Count;
                    kratsiPocet = lines1.Count;

                    delsiList = lines2;
                    kratsiList = lines1;
                }

                delta = delsiPocet - kratsiPocet;

                flag0 = delta;

                Console.WriteLine($"pocatecni delta = {delta}");

                for (int I = 0, J = 0; I < kratsiPocet; I++, J++/*, Console.WriteLine($"I={I}, J={J}")*/)
                {
                    if (!kratsiList[I].Equals(delsiList[J]))
                    {
                        // v okamziku, kdy se radky nerovnaji, tak se posouvej v delsim listu o 1 az do delta a hledej shodu
                        // v pripade ze nenajdes shodu, byly nektere radky vlozeny a nektere byly pouze upraveny
                        // tady bych se oprel o hledani podobnosti na zaklade napr. Levenshteinova algoritmu

                        if (flag0 > 0)
                        {
                            for ( /*pracuju s inicializovanou promennou*/ ; J <= (I+delta); J++, flag0--/*, Console.WriteLine($"J={J}, delta={delta}")*/)
                            {
                                if (!kratsiList[I].Equals(delsiList[J]))

                                    yield return $"difference at the line {J + 1} having value of `{delsiList[J]}`";

                                else

                                    break;
                            } 
                        }
                        else
                        {
                            yield return $"{kratsiList[I]} => {delsiList[J]}";
                        }
                    }
                }
            }
        }
    }
}
