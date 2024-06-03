using Application.Products.Create;
using Application.Products.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Common;

namespace Web.API.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ISender mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IReadOnlyList<ProductResponse>> GetAll()
    {
        var productsResult = await _mediator.Send(new GetAllProductsQuery());

        return productsResult;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] CreateProductCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult;
    }
}