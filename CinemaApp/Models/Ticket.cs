
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string TicketDescription { get; set; }
        [Required]
        public string TicketImage { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public DateTime ValidDate { get; set; }   
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }

        public List<MovieGenre> MoviesGenres;
        public MovieGenre? SelectedGenre { get; set; }
        public Ticket()
        {
            DateTime temp = DateTime.Now;
            ValidDate = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, temp.Second);


        }
        
    }
}
