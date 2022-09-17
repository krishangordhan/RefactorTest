using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Collections.Generic;
using System.Linq;


namespace RefactorMe.Tests
{
    [TestClass]
    public class LawnmowerRepositoryTest
    {
        [TestMethod]
        public void CheckIfRepositoryReturnsAValue()
        {
            IList<Lawnmower> lawnMowers = new LawnmowerRepository().GetAll().ToList();

            Assert.IsTrue(lawnMowers.Count > 0);
        }

        [TestMethod]
        public void CheckIfRepositoryReturnsAllData()
        {
            IList<Lawnmower> lawnMowers = new LawnmowerRepository().GetAll().ToList();

            Assert.IsTrue(lawnMowers.Count == 3);
        }

        [TestMethod]
        public void CheckIfLawnMowerHasAllDataValues()
        {
            IList<Lawnmower> lawnMowers = new LawnmowerRepository().GetAll().ToList();

            Lawnmower lawnMower = lawnMowers.FirstOrDefault(l => l.Name.Equals("Fisher Price's My First Lawnmower"));

            Assert.IsNotNull(lawnMower);
            Assert.IsTrue(lawnMower.IsVehicle == false);
            Assert.IsTrue(lawnMower.FuelEfficiency.Equals("Ultimate"));
            Assert.IsTrue(lawnMower.Price == 45.0);
        }
    }
}
