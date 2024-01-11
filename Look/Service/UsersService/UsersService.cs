using AutoMapper;
using Azure.Core;
using Look.DataContext;
using Look.Dtos;
using Look.Model;
using Microsoft.EntityFrameworkCore;

namespace Look.Service.UsersService
{
    public class UsersService : IUsersInterface
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public UsersService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CheckUserExistence(string userName, string password)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            try
            {
                var UserWithTheName = _context.Users.SingleOrDefault(u => u.Username == userName);

                if (UserWithTheName != null && BCrypt.Net.BCrypt.Verify(password, UserWithTheName.Password))
                {
                    serviceResponse.Dados = true;
                    serviceResponse.Sucesso = true;

                }
                else
                {
                    serviceResponse.Dados = false;
                    serviceResponse.Mensagem = "Nome de usuário ou senha incorretos.";
                    serviceResponse.Sucesso = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Dados = false;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Users>>> CreateUser(CreateUserDto userDto)
        {
            ServiceResponse<List<Users>> serviceResponse = new ServiceResponse<List<Users>>();

            try
            {
                if (_context.Users.Any(u => u.Username == userDto.Username))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Username já em uso. Escolha outro.";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password); 
                    Users newUser = _mapper.Map<Users>(userDto);
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Users.ToList();
                    serviceResponse.Sucesso = true;
                    serviceResponse.Mensagem = "Usuário Cadastrado";
                }

            }catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Users>>> GetUsers()
        {
            ServiceResponse<List<Users>> serviceResponse = new ServiceResponse<List<Users>>();
            try
            {
                serviceResponse.Dados = _context.Users.ToList();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
