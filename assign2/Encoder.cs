using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assign2
{
    public class Encoder
    {
        private String encodedString;
        
        public Encoder(OrderClass Order)
        {
            try
            {
                encodedString = Convert.ToString(Order.getSenderId()) + "/" + Convert.ToString(Order.getCardNo()) + "/" + Convert.ToString(Order.getReceiverId())
                    + "/" + Convert.ToString(Order.getAmount());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while Encoding " + e.Message.ToString() + "\n");
            }
        }

        public string getStringFromObject()
        {
            return encodedString;
        }
    }
}
