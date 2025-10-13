namespace AuctionApp_dissysLabb2.Core;

public class User
{
    public string Name{get;set;}
    
    public int Id { get; set; }
    public string Email {get;set;}
    public string Role {get;set;}
    

    public User(){}
    public User(int id, string name, string email)
    {
       Name = name;
       Id = id;
       Email = email;
    }
}