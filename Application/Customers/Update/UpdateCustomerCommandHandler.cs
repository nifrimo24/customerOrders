using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;

namespace Application.Customers.Update;

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (!await _customerRepository.ExistsAsync(command.Id))
        {
            throw new ArgumentNullException(nameof(command.Id));
        }

        var updateCustomer = await _customerRepository.GetByIdAsync(command.Id);

        updateCustomer.Name = command.Name;
        updateCustomer.LastName = command.LastName;        

        

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return updateCustomer.Id;
    }
}
