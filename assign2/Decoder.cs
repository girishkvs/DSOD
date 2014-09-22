using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assign2
{
    public class Decoder
    {
        private String [] splitEncodedString = new String[4];
        private OrderClass Order = new OrderClass();
        
        public Decoder(String encodedString)
        {
            splitEncodedString = encodedString.Split('/');
        }

        public OrderClass getObjectFromString()
        {
            try
            {
                Order.setSenderId(splitEncodedString[0]);
                Order.setCardNo(Convert.ToInt32(splitEncodedString[1]));
                Order.setReceiverId(splitEncodedString[2]);
                Order.setAmount(Convert.ToInt32(splitEncodedString[3]));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while Decoding" + e.Message.ToString() + "\n");
            }
            return Order;
        }
    }
}
