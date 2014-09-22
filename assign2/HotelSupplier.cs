using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assign2
{
    public  delegate void PriceCutEvent(Int32 pr);

    /***Code should be written for counting number of pricecuts***/
    public class HotelSupplier 
    {
       
        static Random rng=new Random();
        public static event PriceCutEvent priceCut;

        private static Int32 currentPrice=500;

        public static Int32 getPrice() //to know current price
        {
            return currentPrice;
        }
        public static void changePrice(Int32 price) //trigger event when price is changed(reduced)
        {
            if(price<currentPrice)
            {
                if(priceCut!=null)
                    priceCut(price);
            }

            currentPrice=price;
        }

        public void pricingModel() //to generate a random price
        {
                  for (Int32 i = 0; i < 50; i++)            {                Thread.Sleep(500);	                     Int32 p = rng.Next(5, 10);                 HotelSupplier.changePrice(p);            }
        }

    }
}
