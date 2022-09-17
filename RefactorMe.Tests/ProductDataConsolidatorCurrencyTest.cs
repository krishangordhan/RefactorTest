using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductDataConsolidatorCurrencyTest
    {
     
        [TestMethod]
        public void CheckIfValueMatchesEuroConversion()
        {
            List<Product> products = ProductDataConsolidator.Get();
            List<Product> productsInEuros = ProductDataConsolidator.GetInEuros();

            Product product = products.FirstOrDefault(p => p.Name.Equals("Amazon Fire Burgundy Phone Case"));
            Product productInEuro = productsInEuros.FirstOrDefault(p => p.Name.Equals("Amazon Fire Burgundy Phone Case"));

            Assert.IsNotNull(product);
            Assert.IsNotNull(productInEuro);

            Assert.AreEqual(product.Price * GetCurrencyConversionFactor.EuroValue, productInEuro.Price);
        }

        [TestMethod]
        public void CheckIfValueMatchesUSDConversion()
        {
            List<Product> products = ProductDataConsolidator.Get();
            List<Product> productsInUSD = ProductDataConsolidator.GetInUSDollars();

            Product product = products.FirstOrDefault(p => p.Name.Equals("Amazon Fire Burgundy Phone Case"));
            Product productInEuro = productsInUSD.FirstOrDefault(p => p.Name.Equals("Amazon Fire Burgundy Phone Case"));

            Assert.IsNotNull(product);
            Assert.IsNotNull(productInEuro);

            Assert.AreEqual(product.Price * GetCurrencyConversionFactor.USDValue, productInEuro.Price);
        }
    }
}