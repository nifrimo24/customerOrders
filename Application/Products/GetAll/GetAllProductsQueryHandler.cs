using Domain.Products;
using MediatR;
using Products.Common;

namespace Application.Products.GetAll;


internal sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<IReadOnlyList<ProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Product> products = await _productRepository.GetAll();

        return products.Select(product => new ProductResponse(
                product.Id,
                product.Name,
                product.UnitPrice
            )).ToList();
    }
}