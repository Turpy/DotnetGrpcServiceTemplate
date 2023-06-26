using Grpc.Core;
using WebService.V1;

namespace WebService.Services.V1;

/// <summary>
/// Performs greetings
/// </summary>
public sealed class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    /// <summary>
    /// Creates a new instance to perform greetings
    /// </summary>
    /// <param name="logger">Logs messages for this instance</param>
    public GreeterService(ILogger<GreeterService> logger) => _logger = logger;

    /// <summary>
    /// Replies with a Hello greeting
    /// </summary>
    /// <param name="request">Details about the request</param>
    /// <param name="context">Context about the call</param>
    /// <returns>A hello reply</returns>
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context) =>
        Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
}
