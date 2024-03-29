﻿using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ValhallaVault.Data.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        public string? Info { get; set; }
        public string Name { get; set; } = null!;
        public List<SegmentModel>? Segments { get; set; } = new();
    }
}
