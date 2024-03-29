﻿namespace ValhallaVault.Data.Models
{
    public class SegmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
        public List<SubcategoryModel>? Subcategories { get; set; } = new();

    }
}
