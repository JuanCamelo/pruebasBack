using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionDigital.Domain.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string City { get; set; }
        public string Gmail { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
