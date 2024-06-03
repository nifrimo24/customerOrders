using Domain.Customers;
using Domain.Primitives;
using MediatR;

namespace Application.Customers.Delete;

internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetByIdAsync(command.Id) is not Customer customer)
            throw new ArgumentNullException(nameof(customer));
        
        _customerRepository.Delete(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return command.Id;
    }
}
