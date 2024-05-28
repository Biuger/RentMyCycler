using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> UserExist(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return (user != null);
    }

    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        var user = new Users
        {
            Username = userDto.Username, 
            Birthdate = userDto.Birthdate,
            Adress = userDto.Adress,
            Cycling_preferences = userDto.Cycling_preferences,
            Image = userDto.Image,
            Email = userDto.Email,
            Password = userDto.Password,
            Admin = userDto.Admin,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        user = await _userRepository.SaveAsync(user);
        userDto.id = user.id;
        return userDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(userDto.id);
        

        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.Username = userDto.Username;
        user.Birthdate = userDto.Birthdate;
        user.Adress = userDto.Adress;
        user.Cycling_preferences = userDto.Cycling_preferences;
        user.Image = userDto.Image;
        user.Email = userDto.Email;
        user.Password = userDto.Password;
        user.Admin = userDto.Admin;
        user.UpdatedBy = "";
        user.UpdatedDate = DateTime.Now;
        await _userRepository.UpdateAsync(user);
        return userDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var usersDto = users.Select(c => new UserDto(c)).ToList();

        return usersDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("User not found");
        var userDto = new UserDto(user);
        return userDto;
    }
    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var category = await _userRepository.GetByName(name, id);

        return category != null;
    }
    
    public async Task<UserDto> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetLogin(email, password);
        if (user == null || user.Password != password)
        {
            throw new Exception("User or password incorrect");
        }
        return new UserDto(user);
    }
}