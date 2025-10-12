namespace AuctionApp_dissysLabb2.Core;

public class User
{
    public string Name{get;set;}
    private string Password{get;set;}
    
    public int Id { get; set; }
    public string Email {get;set;}
    public string Role {get;set;}
    

    public User(){}
    public User(int id, string name,  string password, string email, string role)
    {
       Name = name;
       Password = password;
       Id = id;
       Email = email;
       Role = role;
    }


    public bool changePassword(string oldPassword, string newPassword)
    {
        if(oldPassword!=Password) return false;
        Password = newPassword;
        return true;
    }
}