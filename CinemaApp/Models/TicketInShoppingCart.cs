using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class TicketInShoppingCart
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Cart ShoppingCart { get; set; }
    }
}
