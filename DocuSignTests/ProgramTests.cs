using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuSign.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /*
         * In all of these unit tests an Input stream is prvodided for success and failure
         * We must inspect each validation function For both success and failure
         */

        [TestMethod()]
        public void Rule2Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "6", "6", "2", "1", "7" };
            int resSuccess = Program.Rule2(INPUTSuccess);
            int resFail = Program.Rule2(INPUTFail);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFail, 2);
        }

        [TestMethod()]
        public void Rule3and4Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "3", "6", "2", "1", "7" };
            int resSuccess = Program.Rule3and4(INPUTSuccess);
            int resFail = Program.Rule3and4(INPUTFail);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFail, 2);
        }

        [TestMethod()]
        public void Rule5and6Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFailPants = { "HOT", "8", "1", "4", "2", "6", "7" };
            string[] INPUTFailSocks = { "COLD", "8", "1", "4", "3", "6", "7" };
            int resSuccess = Program.Rule5and6(INPUTSuccess);
            int PantFail = Program.Rule5and6(INPUTFailPants);
            int SocksFail = Program.Rule5and6(INPUTFailSocks);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(PantFail, 5);
            Assert.AreEqual(SocksFail, 4);
        }

        [TestMethod()]
        public void Rule7Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6","4", "2","1","7" };
            string[] INPUTFailhead = { "HOT", "8", "2", "6", "1", "4", "7" };
            string[] INPUTFailJacket = { "COLD", "8", "6", "3", "5", "4", "2", "1", "7" };
            int resSuccess = Program.Rule7(INPUTSuccess);
            int resFailhead = Program.Rule7(INPUTFailhead);
            int resFailJack = Program.Rule7(INPUTFailJacket);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFailhead, 2);
            Assert.AreEqual(resFailJack, 4);
        }

        [TestMethod()]
        public void Rule8Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "6", "6", "2", "7", "1" };
            int resSuccess = Program.Rule8(INPUTSuccess);
            int resFail = Program.Rule8(INPUTFail);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFail, 5);
        }

        [TestMethod()]
        public void Rule9Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "6", "6", "2", "bar", "1" };
            int resSuccess = Program.Rule9(INPUTSuccess);
            int resFail = Program.Rule9(INPUTFail);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFail, 5);
        }

    }
}