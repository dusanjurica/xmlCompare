using Microsoft.VisualStudio.TestTools.UnitTesting;
using DusanCompareLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DusanCompareLib.Tests
{
    [TestClass()]
    public class DusanCompareDefinitionTests
    {
        public List<string> l1 { get; set; }
        public List<string> l2 { get; set; }

        public DusanCompareDefinition dComparer { get; set; }

        public DusanCompareDefinitionTests()
        {
            Console.WriteLine("Initializing testrunner with data.");

            //l1 = File.ReadAllLines(@"../../lines1.txt").ToList();

            //l2 = File.ReadAllLines(@"../../lines2.txt").ToList();

            dComparer = new DusanCompareDefinition();
        }

        [TestMethod()]
        public void GetDifferencesTest_bothSidesAreEqual_expectsEmptyList()
        {
            l1 = new List<string>
            {
                "a",
                "b",
                "c"
            };

            l2 = new List<string>
            {
                "a",
                "b",
                "c"

            };

            List<string> diffs = new List<string>();

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

        [TestMethod()]
        public void GetDifferencesTest_differentSidesSameLength_expectsListWithDifferences()
        {
            l1 = new List<string>
            {
                "a",
                "b",
                "c"
            };

            l2 = new List<string>
            {
                "a",
                "b",
                "d"
            };

            List<string> diffs = new List<string> { "c => d" };

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

        [TestMethod()]
        public void GetDifferencesTest_almostSameSidesDifferentLengths_expectsListWithDifferences()
        {
            l1 = new List<string>
            {
                "a",
                "b",
                "c",
                "e"
            };

            l2 = new List<string>
            {
                "a", // 1
                "b", // 2
                "c", // 3
                "d", // 4
                "e"  // 5
            };

            List<string> diffs = new List<string>
            {
                "difference at the line 4 having value of `d`"
            };

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

        [TestMethod()]
        public void GetDifferencesTest_differentSidesDifferentLengthsDataConsistent_expectsListWithDifferences()
        {
            l1 = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
            };

            l2 = new List<string>
            {
                "a",
                "b2",
                "c",
                "d",
                "X0", // extra element
                "X1", // extra element
                "e",
                "f",
                "g",
            };

            List<string> diffs = new List<string>
            {
                "b => b2",
                "difference at the line 5 having value of `X0`",
                "difference at the line 6 having value of `X1`"
            };

            foreach (var item in dComparer.GetDifferences(l1, l2))
            {
                Console.WriteLine(item);
            }

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }


        [TestMethod()]
        public void GetDifferencesTest_almostSameSidesDifferentLengthsDataAtRandom_expectsListWithDifferences()
        {
            List<string> l1 = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",

            };

            List<string> l2 = new List<string>
            {
                "a",
                "b",
                "X0", // extra element
                "c",
                "d",
                "e",
                "f",
                "X1", // extra element
                "g",

            };

            List<string> diffs = new List<string>
            {
                "difference at the line 3 having value of `X0`",
                "difference at the line 8 having value of `X1`"
            };

            foreach (var item in dComparer.GetDifferences(l1, l2))
            {
                Console.WriteLine(item.ToString());
            }

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }


        [TestMethod()]
        public void GetDifferencesTest_differentSidesDifferentLengthsDataAtRandom_expectsListWithDifferences()
        {
            List<string> l1 = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
            };

            List<string> l2 = new List<string>
            {
                "a",
                "b",
                "X0", // extra element
                "c",
                "d2",
                "e",
                "f",
                "X1", // extra element
                "g",
            };

            List<string> diffs = new List<string>
            {
                "difference at the line 3 having value of `X0`",
                "d => d2",
                "difference at the line 8 having value of `X1`"
            };

            foreach (var item in dComparer.GetDifferences(l1, l2))
            {
                Console.WriteLine(item.ToString());
            }

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

        [TestMethod()]
        public void GetDifferencesTest_loadTwoSimilarFiles_expectsListWithDifferences()
        {
            List<string> l1 = File.ReadAllLines(@"../../lines1.txt").ToList();
            List<string> l2 = File.ReadAllLines(@"../../lines2.txt").ToList();

            List<string> diffs = new List<string>
            {
                // prazdny, ponevadz poradne nevim co v tech souborech je
                "<url value=\"*.www.centrum.cz/*\"/> => <url value=\"*.www.google.cz/*\"/>",
                "<hide>0</hide> => <hide>1</hide>",
                "difference at the line 36 having value of `<extra>extra line</extra>`"
            };

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

    }
}