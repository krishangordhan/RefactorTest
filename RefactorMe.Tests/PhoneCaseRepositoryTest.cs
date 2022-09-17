using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data.Implementation;
using System.Collections.Generic;
using System.Linq;


namespace RefactorMe.Tests
{
    [TestClass]
    public class PhoneCaseRepositoryTest
    {
        [TestMethod]
        public void CheckIfRepositoryReturnsAValue()
        {
            IList<PhoneCase> phoneCases = new PhoneCaseRepository().GetAll().ToList();

            Assert.IsTrue(phoneCases.Count > 0);
        }

        [TestMethod]
        public void CheckIfRepositoryReturnsAllData()
        {
            IList<PhoneCase> phoneCases = new PhoneCaseRepository().GetAll().ToList();

            Assert.IsTrue(phoneCases.Count == 2);
        }

        [TestMethod]
        public void CheckIfPhoneHasAllDataValues()
        {
            IList<PhoneCase> phoneCases = new PhoneCaseRepository().GetAll().ToList();

            PhoneCase phoneCase = phoneCases.FirstOrDefault(p => p.Name == "Amazon Fire Burgundy Phone Case");

            Assert.IsNotNull(phoneCase);
            Assert.IsTrue(phoneCase.Material == "PVC");
            Assert.IsTrue(phoneCase.TargetPhone == "Amazon Fire");
            Assert.IsTrue(phoneCase.Colour == "Burgundy");
            Assert.IsTrue(phoneCase.Price == 14);
        }
    }
}
