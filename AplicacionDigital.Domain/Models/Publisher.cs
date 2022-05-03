using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionDigital.Domain.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MaxiBooks { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
