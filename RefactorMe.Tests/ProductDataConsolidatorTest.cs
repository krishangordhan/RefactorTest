using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductDataConsolidatorTest
    {
      
        // I would normally have a setup function that would create test data for this.
        // Because the data is static I will leave it as it is.

        [TestMethod]
        // This would normally be my initial connection test functionality. This is to simulate that.
        public void CheckIfProductsReturnsAValue()
        {
            List<Product> products = ProductDataConsolidator.Get(); // I would prefer not to call this every test as we don't modify the data its not needed.

            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void CheckAllDataIsREeturned()
        {
            List<Product> products = ProductDataConsolidator.Get();

            Assert.IsTrue(products.Count == 8);
        }

        [TestMethod]
        public void CheckReturnContainsOneOfEachProduct()
        {
            List<Product> products = ProductDataConsolidator.Get();

            Assert.IsTrue(products.Any(p => p.Type.Equals("Lawnmower")));
            Assert.IsTrue(products.Any(p => p.Type.Equals("Phone Case")));
            Assert.IsTrue(products.Any(p => p.Type.Equals("T-Shirt")));
        }

        [TestMethod]
        public void CheckProductData()
        {
            List<Product> products = ProductDataConsolidator.Get();

            Assert.IsTrue(products.Any(p => p.Name.Equals("New York Yankees T-Shirt")));
            Assert.IsTrue(products.Any(p => p.Price == 8.0));
        }
    }
}