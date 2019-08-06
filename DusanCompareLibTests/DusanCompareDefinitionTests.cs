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
        public void GetDifferences_almostSameSidesDifferentLengths_expectsListWithDifferences()
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
                "a",
                "b",
                "c",
                "d",
                "e"
            };

            List<string> diffs = new List<string>
            {
                "extra line with [d] on it"
            };

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }

        [TestMethod()]
        public void GetDifferences_differentSidesDifferentLengths_expectsListWithDifferences()
        {
            l1 = new List<string>
            {
                "a",
                "x",
                "c",
                "e"
            };

            l2 = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e"
            };

            List<string> diffs = new List<string>
            {
                "x => b",
                "l2 has extra line with `d` on it"
            };

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2).ToList());
        }
    }
}