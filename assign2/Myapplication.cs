using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assign2
{
    class Myapplication
    {
        public void Main(String[] args)
        {
            HotelSupplier hotel=new HotelSupplier();
            Thread pricing =new Thread(new ThreadStart(hotel.pricingModel));
            pricing.Start();
            TravelAgent agent=new TravelAgent();
            HotelSupplier.priceCut+=new PriceCutEvent(agent.discountPrice);
            Thread[] agents = new Thread[5];
            for (int i = 0; i < 5; i++)
            {   // Start 5 agent threads
                agents[i] = new Thread(new  ThreadStart(agent.travelAgentfunction));
                agents[i].Name = (i + 1).ToString();
                agents[i].Start();
            }
        }
    }
}
