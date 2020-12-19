using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Models
{
    public class VerseModel
    {
        [Required]
        [DisplayName("Testament")]
        [DefaultValue("")]
        public string Testament { get; set; }

        [Required]
        [DisplayName("Book")]
        [DefaultValue("")]
        public string Book { get; set; }

        [Required]
        [DisplayName("Chapter")]
        [DefaultValue("")]
        public int Chapter { get; set; }

        [Required]
        [DisplayName("Verse")]
        [DefaultValue("")]
        public int Verse { get; set; }

        [DisplayName("Text")]
        [StringLength(500, MinimumLength = 5)]
        [DefaultValue("")]
        public string Text { get; set; }
    }
}