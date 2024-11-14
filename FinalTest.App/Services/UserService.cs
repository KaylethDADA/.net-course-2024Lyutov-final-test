using AutoMapper;
using FinalTest.App.Dtos.Users;
using FinalTest.App.Interfaces.Repositories;
using FinalTest.Domain.Entities;
using System.Linq.Expressions;

namespace FinalTest.App.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> AddUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetAsync(u => u.Email == request.Email, null, null, cancellationToken);
            if (existingUser.Any())
            {
                throw new ArgumentException("Пользователь с таким Email уже существует.");
            }

            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user, cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("Пользователь не найден.");
            }

            existingUser.Update(request.FullName, request.Email);
            await _userRepository.UpdateAsync(existingUser, cancellationToken);

            return _mapper.Map<UserResponse>(existingUser);
        }
        public async Task<UserResponse> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<ICollection<UserResponse>> GetUsersAsync(
            PagedUsersRequest request,
            CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<Expression<Func<User, bool>>>(request);
            var userList = await _userRepository.GetAsync(filter, request.PageNumber, request.PageSize, cancellationToken);
            return _mapper.Map<ICollection<UserResponse>>(userList);
        }

        public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            if (user == null)
            {
                throw new KeyNotFoundException("Пользователь не найден.");
            }

            await _userRepository.DeleteAsync(user, cancellationToken);
        }
    }
}
