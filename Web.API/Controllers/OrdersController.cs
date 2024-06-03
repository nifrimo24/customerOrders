using Application.Orders.Create;
using Application.Orders.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Common;

namespace Web.API.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ISender mediator, ILogger<OrdersController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IReadOnlyList<OrderResponse>> GetAll()
    {
        var ordersResult = await _mediator.Send(new GetAllOrdersQuery());

        return ordersResult;
    }

    [HttpPost]
    public async Task<string> Create([FromBody] CreateOrderCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult;
    }

}