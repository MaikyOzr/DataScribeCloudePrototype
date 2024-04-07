﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Pptx : IFileEntity
    {
        [Key]
        public int Id { get; set; }
        public string PptxUrl { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Pptx> GetEnumerator()
        {
            yield return this;
        }
    }
}
