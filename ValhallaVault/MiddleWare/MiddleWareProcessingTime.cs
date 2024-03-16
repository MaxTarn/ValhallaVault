using System.Diagnostics;

namespace ValhallaVault.MiddleWare;

public class MiddleWareProcessingTime
{
    private readonly RequestDelegate _next;
    private readonly Stopwatch _stopwatch;
    private long _totalProcessingTime;

    public MiddleWareProcessingTime(RequestDelegate next)
    {
        _next = next;
        _stopwatch = new Stopwatch();
        _totalProcessingTime = 0;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //Starts measuaring time
        _stopwatch.Restart();

        //calls next middleWare in line
        await _next(context);

        //stops the stopwatch
        _stopwatch.Stop();
        //
        long elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

        //adds the time taken for the current request to the total time
        _totalProcessingTime += elapsedMilliseconds;

        //logs the 
        Console.WriteLine($"Request took {elapsedMilliseconds} milliseconds. Total time Processing {_totalProcessingTime} miliseconds");
    }

    public void PrintTotalProcessingTime()
    {
        // Print out the total processing time
        Console.WriteLine($"Total processing time: {_totalProcessingTime} milliseconds");
    }
}

