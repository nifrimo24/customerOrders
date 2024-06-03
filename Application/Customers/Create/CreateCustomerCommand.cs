using MediatR;

namespace Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    string LastName
) : IRequest<int>;
