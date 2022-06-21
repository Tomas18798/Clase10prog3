using System;
using System.Collections.Generic;

namespace Api.Data
{
    public partial class Province
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country? Country { get; set; }
    }
}
