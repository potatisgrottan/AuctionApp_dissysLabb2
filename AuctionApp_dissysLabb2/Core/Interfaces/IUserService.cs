namespace AuctionApp_dissysLabb2.Core.Interfaces;

public interface IUserService
{
        User? GetUserById(string id);
        User? GetUserByUsername(string username);
}