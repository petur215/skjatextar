using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace skjatextar.Models
{
    public class TranslationViewModel
    {
        public TranslationViewModel()
        {
            DateLastEdited = DateTime.Now;
            Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Gaman", Value = "Gaman" });
            Categories.Add(new SelectListItem { Text = "Spenna", Value = "Spenna" });
            Categories.Add(new SelectListItem { Text = "Ævintýri", Value = "Ævintýri" });
            Categories.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            Categories.Add(new SelectListItem { Text = "Dramatík", Value = "Dramatík" });
            Categories.Add(new SelectListItem { Text = "Hrollvekja", Value = "Hrollvekja" });
            Categories.Add(new SelectListItem { Text = "Barnaefni", Value = "Barnaefni" });
            Categories.Add(new SelectListItem { Text = "-Veldu flokk-", Value = "", Selected = true });
            
        }

        public int ID { get; set; }

        [Required(ErrorMessage= "Title is required")]
        public string Title { get; set; }
        public int LikeCount { get; set; }

        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "You need to choose a category")]
        public string Category { get; set; }
        
        public DateTime DateLastEdited { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}