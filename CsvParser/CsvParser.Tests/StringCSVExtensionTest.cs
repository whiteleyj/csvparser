namespace CsvParser.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CsvParser;

    [TestClass]
    public class StringCSVExtensionTest
    {
        //[TestMethod()]
        //[Timeout(500)]
        //[Ignore]  // Integration Test
        //public void SpeedTest()
        //{
        //    for (int i = 0; i < _lines.Length; i++)
        //    {
        //        var names = StringCsvExtension.ParseCSV(_lines[i]);
        //        Assert.AreEqual(9, names.Count);
        //    }
        //}

        [TestMethod()]
        public void Parse_A_Single_Entry()
        {
            var names = StringCsvExtension.ParseCSV("Mark");
            Assert.IsTrue(names.Count == 1);
            Assert.AreEqual(names[0], "Mark");
        }

        [TestMethod()]
        public void Parse_Multiple_Entries()
        {
            var names = StringCsvExtension.ParseCSV("Mark,Mike,Dave");
            Assert.IsTrue(names.Count == 3);
            Assert.AreEqual("Mark", names[0]);
            Assert.AreEqual("Mike", names[1]);
            Assert.AreEqual("Dave", names[2]);
        }

        [TestMethod()]
        public void Parse_A_Pipe_Delimited_Entry()
        {
            var names = StringCsvExtension.ParseCSV("Mark|Mike|Dave", '|');
            Assert.IsTrue(names.Count == 3);
            Assert.AreEqual(names[0], "Mark");
            Assert.AreEqual(names[1], "Mike");
            Assert.AreEqual(names[2], "Dave");
        }

        [TestMethod()]
        public void Parse_A_Single_Pipe_Delimited_Entry()
        {
            var names = StringCsvExtension.ParseCSV("Mark|", '|');
            Assert.IsTrue(names.Count == 2);
            Assert.AreEqual(names[0], "Mark");
            Assert.AreEqual(names[1], "");
        }

        [TestMethod()]
        public void Quoted_Values()
        {
            var names = StringCsvExtension.ParseCSV("\"Marky,Mark\",3,100.00");
            Assert.IsTrue(names.Count == 3);
            Assert.AreEqual(names[0], "Marky,Mark");
            Assert.AreEqual(names[1], "3");
            Assert.AreEqual(names[2], "100.00");
        }

        [TestMethod()]
        public void Multiple_Quoted_Values()
        {
            var names = StringCsvExtension.ParseCSV("\"Marky,Mark\",\"Mike\",\"Dave\"");
            Assert.IsTrue(names.Count == 3);
            Assert.AreEqual(names[0], "Marky,Mark");
            Assert.AreEqual(names[1], "Mike");
            Assert.AreEqual(names[2], "Dave");
        }

        // TODO: Get these working.
        //[TestMethod()]
        //public void Trim_Space_Between_Commas_And_Quotes()
        //{
        //    RecordParser parse = new RecordParser();

        //    // note the comma space (", ")
        //    var names = parse.ParseCSV("Mark, \"Mike\"");
        //    Assert.IsTrue(names.Count == 2);
        //    Assert.AreEqual(names[0], "Mark");
        //    Assert.AreEqual(names[1], "Mike");
        //}

        //[TestMethod()]
        //public void Trim_Space_Between_Quote_And_Comma()
        //{
        //    RecordParser parse = new RecordParser();

        //    // note the comma space (", ")
        //    var names = parse.ParseCSV("\"Mark\" ,Mike");
        //    Assert.IsTrue(names.Count == 2);
        //    Assert.AreEqual(names[0], "Mark");
        //    Assert.AreEqual(names[1], "Mike");
        //}

        [TestMethod()]
        public void Escaped_Quote()
        {
            var names = StringCsvExtension.ParseCSV("\"Inter\"\"rupting Quote\"");
            Assert.IsTrue(names.Count == 1);
            Assert.AreEqual(names[0], "Inter\"rupting Quote");
        }

        [TestMethod()]
        public void Escaped_Quote_Only_Works()
        {
            var names = StringCsvExtension.ParseCSV("\"Inter\"\"rupting Quote\"");
            Assert.IsTrue(names.Count == 1);
            Assert.AreEqual(names[0], "Inter\"rupting Quote");
        }
    }
}
