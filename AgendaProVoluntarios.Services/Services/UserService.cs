using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.ViewModels;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Repositories.Repositories;
using AgendaProVoluntarios.Services.Auth;
using AgendaProVoluntarios.Services.Interfaces;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace AgendaProVoluntarios.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserViewModel(user.FullName, user.Email);
        }

        public async Task AddAsync(NewUserInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate, passwordHash, inputModel.RoleId);

            await _userRepository.AddAsync(user);
            throw new NotImplementedException();
        }

        public async Task<LoginUserViewModel> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(password);

            // Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, passwordHash);

            // se não existir, errro no login
            if (user == null) return null;

            // Se existir, gera o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, "Adm");

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
