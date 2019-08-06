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

            CollectionAssert.AreEqual(diffs, dComparer.GetDifferences(l1, l2));
        }
    }
}