using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace skjatextar.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }    // spenna, drama, grín etc.
        //public string type { get; set; }    // kvikmynd, þáttur, skrípó etc.
    }
}