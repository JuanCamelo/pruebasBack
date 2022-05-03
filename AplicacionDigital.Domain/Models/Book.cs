using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionDigital.Domain.Models
{
    public partial class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public int? NumberPages { get; set; }
        public Guid Publisher { get; set; }
        public Guid Authors { get; set; }

        public virtual Author AuthorsNavigation { get; set; }
        public virtual Publisher PublisherNavigation { get; set; }
    }
}
