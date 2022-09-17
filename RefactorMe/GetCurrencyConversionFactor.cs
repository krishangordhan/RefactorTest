using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public class GetCurrencyConversionFactor
    {
        public static double EuroValue { get { return 0.67; } } // It would generally get these values from an API why it is seperated in its own class.

        public static double USDValue { get { return 0.76; } }

        public static double NZValue { get { return 1.0; } }
    }
}
