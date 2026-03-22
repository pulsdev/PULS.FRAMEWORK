namespace Puls.Cloud.Framework.SymmetricEncryption;

public interface IBinaryToTextConverter
{
    string Encode(byte[] input);
    byte[] Decode(string text);
}
