using Customers.Common;
using MediatR;

namespace Application.Customers.GetAll;

public record GetAllCustomersQuery() : IRequest<IReadOnlyList<CustomerResponse>>;