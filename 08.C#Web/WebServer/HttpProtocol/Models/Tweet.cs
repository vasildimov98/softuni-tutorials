using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HttpProtocol.Models
{
    public partial class Tweet
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string User { get; set; }
        [StringLength(250)]
        public string VaskoTweet { get; set; }
    }
}
