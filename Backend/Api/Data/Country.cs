using System;
using System.Collections.Generic;

namespace Api.Data
{
    public partial class Country
    {
        public Country()
        {
            Provinces = new HashSet<Province>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
