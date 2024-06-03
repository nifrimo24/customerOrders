using Customers.Common;
using Domain.Customers;
using MediatR;

namespace Application.Customers.GetAll;


internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<CustomerResponse>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<IReadOnlyList<CustomerResponse>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

        return customers.Select(customer => new CustomerResponse(
                customer.Id,
                customer.FullName
            )).ToList();
    }
}