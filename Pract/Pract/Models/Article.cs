using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pract.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Название статьи")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Ссылка на изображение")]
        public string ImageLink { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Содержимое статьи статьи (вставьте html-код)")]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Дата")]
        public DateTime Date { get; set; }
    }
}