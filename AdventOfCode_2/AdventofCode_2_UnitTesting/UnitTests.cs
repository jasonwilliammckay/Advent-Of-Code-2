using System;
using System.IO;
using AdventOfCode_2;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventofCode_2_UnitTesting
{
    [TestClass]
    public class Program_UnitTests
    {
        List<GiftBox> giftBoxes;

        [TestInitialize]
        public void testInit()
        {
            giftBoxes = new List<GiftBox>();
        }

        // file input tests

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_getData_invalidFile()
        {
            Program.getData("../../invalidFileName.txt");
        }

        [TestMethod]
        public void Test_getData_emptyFile()
        // should process an empty file without doing anything
        {
            Program.getData("../../input_empty.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_getData_malformedFile()
        {
            Program.getData("../../input_malformed.txt");
        }

        [TestMethod]
        public void Test_getData_validFile()
        {
            Program.getData("../../input_valid_zero.txt");
        }

        // wrapping paper tests

        [TestMethod]
        public void Test_processWrappingPaper_zeroes()
        {
            giftBoxes.Add(new GiftBox(0, 0, 0));
            Assert.AreEqual(Program.processWrappingPaper(giftBoxes), 0);
        }

        [TestMethod]
        public void Test_processWrappingPaper_valid_asGiven()
        {
            giftBoxes.Add(new GiftBox(2, 3, 4));
            Assert.AreEqual(Program.processWrappingPaper(giftBoxes), 58);
        }

        [TestMethod]
        public void Test_processWrappingPaper_valid_inputsReversed()
        { // to make sure the 'smallest sides' logic works
            giftBoxes.Add(new GiftBox(4, 3, 2));
            Assert.AreEqual(Program.processWrappingPaper(giftBoxes), 58);
        }

        [TestMethod]
        public void Test_processWrappingPaper_valid_sameSides()
        {
            giftBoxes.Add(new GiftBox(2, 2, 2));
            Assert.AreEqual(Program.processWrappingPaper(giftBoxes), 28);
            // sides = 8 + 8 + 8, slack = 4, total = 28
        }

        [TestMethod]
        public void Test_processWrappingPaper_negativeValues()
        {// assume negative values should be regarded as positive
            giftBoxes.Add(new GiftBox(-2, -3, -4));
            Assert.AreEqual(Program.processWrappingPaper(giftBoxes), 58);
        }

        // ribbon tests

        [TestMethod]
        public void Test_processRibbon_zeroes()
        {
            giftBoxes.Add(new GiftBox(0, 0, 0));
            Assert.AreEqual(Program.processRibbon(giftBoxes), 0);
        }

        [TestMethod]
        public void Test_processRibbon_negative()
        { // assume negative values should be regarded as positive
            giftBoxes.Add(new GiftBox(-2, -3, -4));
            Assert.AreEqual(Program.processRibbon(giftBoxes), 34);
        }

        [TestMethod]
        public void Test_processRibbon_valid_asGiven()
        {
            giftBoxes.Add(new GiftBox(2, 3, 4));
            Assert.AreEqual(Program.processRibbon(giftBoxes), 34);
        }

        [TestMethod]
        public void Test_processRibbon_valid_reversed()
        {
            giftBoxes.Add(new GiftBox(4, 3, 2));
            Assert.AreEqual(Program.processRibbon(giftBoxes), 34);
        }

        [TestMethod]
        public void Test_processRibbon_valid_sameSides()
        {
            giftBoxes.Add(new GiftBox(2, 2, 2));
            Assert.AreEqual(Program.processRibbon(giftBoxes), 16);
            // wrap = 2+2+2+2, bow = 2*2*2, total = 16
        }
    }
}
