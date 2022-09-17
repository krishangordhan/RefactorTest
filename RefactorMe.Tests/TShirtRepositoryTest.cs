using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Collections.Generic;
using System.Linq;


namespace RefactorMe.Tests
{
    [TestClass]
    public class TShirtRepositoryTest
    {
        [TestMethod]
        public void CheckIfRepositoryReturnsAValue()
        {
            IList<TShirt> tShirts = new TShirtRepository().GetAll().ToList();

            Assert.IsTrue(tShirts.Count > 0);
        }

        [TestMethod]
        public void CheckIfRepositoryReturnsAllData()
        {
            IList<TShirt> tShirts = new TShirtRepository().GetAll().ToList();

            Assert.IsTrue(tShirts.Count == 3);
        }

        [TestMethod]
        public void CheckIfTShirtHasAllDataValues()
        {
            IList<TShirt> tShirts = new TShirtRepository().GetAll().ToList();

            TShirt tShirt = tShirts.FirstOrDefault(p => p.Name == "Disney Sleeping Beauty T-Shirt");

            Assert.IsNotNull(tShirt);
            Assert.IsTrue(tShirt.ShirtText == "Mirror mirror on the wall...");
            Assert.IsTrue(tShirt.Colour == "Green");
            Assert.IsTrue(tShirt.Price == 10.0);
        }
    }
}
