using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;

public class CreateShoeCommandHandler : IRequestHandler<CreateShoeCommand, int>
{
    private readonly IShoeRepository _repository;
    private readonly IUserRepository _userRepository;

    public CreateShoeCommandHandler(IShoeRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateShoeCommand request, CancellationToken cancellationToken)
    {
        var shoe = request.Dto.Adapt<Domain.Entities.Shoe>();

        if (_userRepository.GetUserId is null)
            throw new NotFoundException($"User with id '{_userRepository.GetUserId}' not found");

        shoe.UserId = _userRepository.GetUserId.Value;

        await _repository.CreateAsync(shoe);

        return shoe.Id;
    }
}