using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace dotnet.Controllers;

[Route("[controller]")]
[ApiController]
public class GreetingsController : ControllerBase
{
    private readonly ILogger<GreetingsController> _logger;
    private readonly Counter _counter;
    private readonly Counter _counter2;

    public GreetingsController(ILogger<GreetingsController> logger)
    {
        _counter = Metrics.CreateCounter("greetings_given", "The amount of greetings given", new []{"language"});
        _counter2 = Metrics.CreateCounter("greetings_given", "amount", "language");

        _logger = logger;
    }


    [HttpGet("hello")]
    public string English()
    {
        _counter.WithLabels("english").Inc();
        _logger.LogInformation("Hello requested");
        return "hello";
    }

    [HttpGet("gutentag")]
    public string German()
    {
        _counter.WithLabels("german").Inc();
        _counter2.WithLabels("test").Inc();
        _logger.LogInformation("Gutentag requested");
        return "gutentag";
    }
}
