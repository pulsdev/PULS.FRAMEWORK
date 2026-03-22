namespace Puls.Cloud.Framework.SymmetricEncryption;

public interface ISymmetricEncryption
{
    string Encrypt(string value);
    string Encrypt(byte[] value);
    string Decrypt(byte[] value);
    byte[] Decrypt(string encrypted);
}
