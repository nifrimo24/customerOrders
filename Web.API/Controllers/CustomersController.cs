using Application.Customers.Create;
using Application.Customers.Delete;
using Application.Customers.GetAll;
using Application.Customers.Update;
using Customers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ISender mediator, ILogger<CustomersController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IReadOnlyList<CustomerResponse>> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());

        return customersResult;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] CreateCustomerCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult;
    }

    [HttpPut("{id}")]
    public async Task<int> Update(int id, [FromBody] UpdateCustomerCommand command)
    {
        var updateResult = await _mediator.Send(command);
        return updateResult;
    }

    [HttpDelete("{id}")]
    public async Task<int> Delete(int id)
    {
        return await _mediator.Send(new DeleteCustomerCommand(id));
    }
}