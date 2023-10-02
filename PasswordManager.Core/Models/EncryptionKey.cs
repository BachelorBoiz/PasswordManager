namespace PasswordManager.Core.Models;

public class EncryptionKey
{
    public byte[] Key { get; set; }
    public byte[] IV { get; set; }
}