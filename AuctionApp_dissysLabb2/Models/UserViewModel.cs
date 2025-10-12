using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;

namespace AuctionApp_dissysLabb2.Models;

public class UserViewModel
{
    public string Name{get;set;}
    
    public string Email {get;set;}
    
    public string Role {get;set;}

    public static UserViewModel FromUser(User user)
    {
        return new UserViewModel()
        {
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}