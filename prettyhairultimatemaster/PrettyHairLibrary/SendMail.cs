using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class MailServer
    {

        public int EmailsSent {get; set;}
        public MailServer()
        {
            EmailsSent = 0;
        }

        public void Subscribe(OrderRepository orderRepository)
        {
            orderRepository.Tick += new OrderRepository.TickHandler(Send);
        }

        public void Send(OrderRepository orderRepository, EventArgs eventArgs)
        {
            // Email STMP not implemented
            EmailsSent++; 
        }
    }
}
