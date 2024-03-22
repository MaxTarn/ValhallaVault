//namespace ValhallaTest
//{
//public class ValhallaUnitTest
//{
//    public DisplayCategory displayCategory { get; set; }

//    [Theory]
//    [InlineData(0, false)]
//    [InlineData(74, false)]
//    [InlineData(76, true)]
//    public void AccessNextSegment(int precentageComplete, bool expectedOutcome)
//    {
//        //Arrange     ---- Segmentet innan har olika grad av avklarade procent
//        var previousSegment = new SegmentContainer
//        {
//            PercentageComplete = precentageComplete
//        };

//        //Act
//        var result = displayCategory.CanProgress(previousSegment);

//        //Assert
//        Assert.Equal(expectedOutcome, result);

//    }
//}


// }
//private bool CanProgress(SegmentContainer? segment)
//{
//    Check if the previous segment exists
//    if (Category.Segments.IndexOf(segment) > 0)
//    {
//        var previousSegment = Category.Segments[Category.Segments.IndexOf(segment) - 1];
//        return previousSegment.PercentageComplete >= 75.0;
//    }
//    return true; // First segment can always be accessed
//}