using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2
{
    class OrderClass
    {
        private String senderId;
        private Int32 cardNo;
        private Int32 Amount;
        private String receiverId;
       public String getSenderId()
        {
            return senderId;
        }
       public String getReceiverId()
       {
           return receiverId;
       }
       public Int32 getAmount()
       {
           return Amount;

       }
       public Int32 getCardNo()
       {
           return cardNo;

       }
        public void setSenderId(String sId)
        {
            senderId=sId;
        }
        public void setReceiverId(String rId)
        {
            receiverId = rId;
        }
        public void setCardNo(Int32 cno)
        {
            cardNo = cno;
        }
        public void setAmount(Int32 amt)
        {
            Amount = amt;
        }
    }
}
