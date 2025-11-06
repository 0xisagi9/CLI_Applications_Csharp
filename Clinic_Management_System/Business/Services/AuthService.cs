using Clinic_Management_System.Business.Models;
using Clinic_Management_System.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Business.Services;

internal class AuthService(UserRepository userRepo)
{
    private readonly UserRepository _userRepo = userRepo;

    public void SignUp(User user)
    {
        if (_userRepo.ExistByEmail(user.Email!))
            throw new Exception("Email Already Exist");

        _userRepo.Add(user);
    }

    public User Login(string email, string password)
    {

        var user = _userRepo.GetByEmail(email) ?? throw new Exception("User Not Found");
        if (!user.IsActive)
            throw new Exception("Account is Deactivated");
        if (user.Password != password)
            throw new Exception("Invalid Password");

        return user;
    }

    public void DeactivateUser(int userId)
    {
        var user = _userRepo.GetById(userId);
        if (user != null)
            throw new Exception("User Not Found");
        if (!user.IsActive)
            throw new Exception("User Already Deactivated");

        _userRepo.Delete(userId);
    }


    private bool IsValidUser(string email, string password)
    {
        var user = _userRepo.GetByEmail(email);
        return user != null && user.Password == password && user.IsActive;
    }

}
