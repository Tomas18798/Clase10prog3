using System;
using System.Collections.Generic;

namespace Api.Data
{
    public partial class Address
    {
        public int Id { get; set; }
        public string? Direction { get; set; }
        public int? ProvinceId { get; set; }
        public int? UserId { get; set; }

        public virtual Province? Province { get; set; }
        public virtual User? User { get; set; }
    }
}
