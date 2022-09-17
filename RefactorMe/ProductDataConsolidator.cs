using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {

        /**
         * Get of All
         *          Get of each repository (we can generalise this)
         *          
         *          Pass through currency factor, make currency a factor. Functionalise these.
         *          
         *          Pass through generic to make a product.
         */

        public static List<Product> Get() {
            return GetData(GetCurrencyConversionFactor.NZValue);
        }

        public static List<Product> GetInUSDollars() {
            return GetData(GetCurrencyConversionFactor.USDValue);
        }

        public static List<Product> GetInEuros() {
            return GetData(GetCurrencyConversionFactor.EuroValue);
        }

        private static List<Product> GetData(double currencyValue)
        {
            List<Product> products = new List<Product>();
            Product product;

            List<Lawnmower> lawnMowers = new LawnmowerRepository().GetAll().ToList();
            if (lawnMowers != null)
            {
                foreach (Lawnmower lawnMower in lawnMowers)
                {
                    product = MakeProduct(lawnMower.Id, lawnMower.Name, lawnMower.Price, lawnMower, currencyValue);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }

            List<PhoneCase> phoneCases = new PhoneCaseRepository().GetAll().ToList();
            if (phoneCases != null)
            {
                foreach (PhoneCase phoneCase in phoneCases)
                {
                    product = MakeProduct(phoneCase.Id, phoneCase.Name, phoneCase.Price, phoneCase, currencyValue);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }

            List<TShirt> tShirts = new TShirtRepository().GetAll().ToList();
            if (tShirts != null)
            {
                foreach (TShirt tShirt in tShirts)
                {
                    product = MakeProduct(tShirt.Id, tShirt.Name, tShirt.Price, tShirt, currencyValue);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        private static Product MakeProduct(Guid id, string name, double price, Object genericProduct, double currencyValue = 1)
        {
            string type;
            if(genericProduct is Lawnmower) // We would get this value normally from the class itself as it would be an attribute, and I would make Lawnmower extend Product.
            {
               type = "Lawnmower";
            }
            else if (genericProduct is PhoneCase)
            {
                type = "Phone Case";
            }
            else if (genericProduct is TShirt)
            {
                type = "T-Shirt";
            }
            else
            {
                // Throw exception type not supported.
                return null;
            }

            if (currencyValue <= 0)
            {
                // Throw invalid currency for product.
                return null;
            }

            Product product = new Product()
            {
                Id = id,
                Name = name,
                Price = price * currencyValue,
                Type = type
            };

            return product;
        }
    }
}