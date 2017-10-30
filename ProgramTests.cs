using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projekt.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void OdczytTest()
        {
            string komendaDobra = "SELECT FROM WHERE ORDER BY";
            string komendaDobraCzesciowo = "SELECT FROM";
            string komendaZla = "FROM SELECT";
            bool sprawdzacz = true;
            bool sprawdzaczZly = false;
            Program program = new Program();
            Assert.AreEqual(sprawdzacz, Program.Odczyt(komendaDobra));
            Assert.AreEqual(sprawdzacz, Program.Odczyt(komendaDobraCzesciowo));
            Assert.AreEqual(sprawdzaczZly, Program.Odczyt(komendaZla));
        }
    }
}