using Products.Common;
using MediatR;

namespace Application.Products.GetAll;

public record GetAllProductsQuery() : IRequest<IReadOnlyList<ProductResponse>>;