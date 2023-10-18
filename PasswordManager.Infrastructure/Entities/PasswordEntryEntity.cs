namespace PasswordManager.Infrastructure.Entities;

public class PasswordEntryEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Website { get; set; }
    public string Password { get; set; }
    public UserEntity User { get; set; }
    public int UserId { get; set; }
}