﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public Program prgm = new Program();
        [TestMethod()]
        public void Rule2Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "6", "6", "2", "1", "7" };
            //var prgm = new Program();
            int resSuccess = prgm.Rule2(INPUTSuccess);
            int resFail = prgm.Rule2(INPUTFail);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(resFail, 2);
        }

        [TestMethod()]
        public void Rule5and6Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFailPants = { "HOT", "8", "1", "4", "2", "6", "7" };
            string[] INPUTFailSocks = { "COLD", "8", "1", "4", "3", "6", "7" };
            //var prgm = new Program();
            int resSuccess = prgm.Rule5and6(INPUTSuccess);
            int PantFail = prgm.Rule5and6(INPUTFailPants);
            int SocksFail = prgm.Rule5and6(INPUTFailSocks);
            Assert.AreEqual(resSuccess, -1);
            Assert.AreEqual(PantFail, 5);
            Assert.AreEqual(SocksFail, 4);
        }

        [TestMethod()]
        public void Rule7Test()
        {
            string[] INPUTSuccess = { "HOT", "8", "6", "4", "2", "1", "7" };
            string[] INPUTFail = { "HOT", "8", "1", "4", "2", "6", "7" };
            //var prgm = new Program();
            int resSuccess = prgm.Rule7(INPUTSuccess);
            Assert.AreEqual(resSuccess, -1);
        }
    }
}