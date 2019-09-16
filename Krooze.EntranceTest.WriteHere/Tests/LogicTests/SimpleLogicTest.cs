using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge
            decimal taxs = new decimal();

            taxs = cruise.TotalValue - cruise.CabinValue - cruise.PortCharge;
            
            return taxs;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list

            bool disc = new bool();
            decimal value1 = new decimal();
            decimal value2 = new decimal();
            decimal result = new decimal();
         

            foreach (var item in cruise.PassengerCruise)
            {
                if (item.PassengerCode.Equals("1"))
                {
                    value1 = item.Cruise.CabinValue;

                }
                else if (item.PassengerCode.Equals("2"))
                {
                    value2 = item.Cruise.CabinValue;
                }

            }

            if (value1 > value2)
            {
                return true;


            }
            else {
                return false;
            }
                  
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200
            
            int parc_max = 12;
            int min_value = 200;
            int result = 0;
            int preco = Convert.ToInt32(fullPrice);

            result = preco / min_value;

            if (result < parc_max && result > 0)
            {
                return result;
            }
            else if (result.Equals(0))

                return 1;

            else
            {
                return parc_max;
            }

        }
    }
}
