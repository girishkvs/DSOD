using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2
{
    /***Didn't handle the cases to send confirmation***/
    public class OrderProcessing
    {
        private string senderId;
        private string receiverId;
        private int numOfRooms;
        private int cardNo;
        private double tax = 0.3;
        private int locationCharge = 70;
        private int totalAmount;
        private int unitPrice;
        private string creditCardValidityStatus;

        public OrderProcessing(OrderClass Order)
        {
            senderId = Order.getSenderId();
            receiverId = Order.getReceiverId();
            numOfRooms = Order.getAmount();
            cardNo = Order.getCardNo();
        }

        public void orderProcessMethod()
        {
            unitPrice = HotelSupplier.getPrice();
            int priceOfRooms = unitPrice * numOfRooms;
            totalAmount = priceOfRooms + (int)(priceOfRooms * tax) + locationCharge;

            //call Bank Service to validate the credit card
            creditCardValidityStatus = "Valid";

            Console.WriteLine("Order Received by Thread ID - " + receiverId + "\n" + "Order Placed by Thread ID - " + senderId + "\n" + "No. of rooms = " + numOfRooms +
                "\n" + "Credit Card Number = " + cardNo + "\n" + "Total Amount of Charge = " + totalAmount + "\n" + "Credi Card Validity Status = " + creditCardValidityStatus + "\n");
        }

    }
}
