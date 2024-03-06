﻿using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models
{
	public class SubcategoryModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int SegmentId { get; set; }
		public SegmentModel? Segment { get; set; }
		public List<QuestionModel>? Questions { get; set; }

	}
}
