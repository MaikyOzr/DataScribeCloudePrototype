﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Pdf
    {
        [Key]
        public int PDFId { get; set; }
        public string PDFUrl { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Pdf> GetEnumerator()
        {
            yield return this;
        }
    }
}
