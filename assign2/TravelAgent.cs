using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assign2
{

    /***Code should be written for placing the order, time of the order, number of rooms, encoding and placing the string in multi-cell buffer***/
    class TravelAgent
    {
        public void travelAgentfunction()
        {
            //HotelSupplier hs = new HotelSupplier();
            for (Int32 i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Int32 p = HotelSupplier.getPrice();
                Console.WriteLine("Hotel{0} has everyday low price: ${1} each", Thread.CurrentThread.Name, p);
            }
        }

        public void discountPrice(Int32 p)
        {  // Event handler
            Console.WriteLine("hotel {0} price got decreased : as low as ${1} each", Thread.CurrentThread.Name, p);
        }
    }
}
