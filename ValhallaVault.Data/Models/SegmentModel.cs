﻿namespace ValhallaVault.Data.Models
{
    public class SegmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public int CategoryModelId { get; set; }
        public CategoryModel? Category { get; set; }
        public List<SubcategoryModel>? Subcategories { get; set; }
        public List<int> SubcategoryIds { get; set; }
    }
}