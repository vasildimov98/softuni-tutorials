using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQDemo.Data.Models
{
    [Keyless]
    public partial class TownViewModel
    {
        [StringLength(50)]
        public string TownName { get; set; }
        public int? CountOfAddresses { get; set; }
    }
}
