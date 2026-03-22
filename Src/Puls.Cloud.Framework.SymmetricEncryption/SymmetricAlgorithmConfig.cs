using System.Security.Cryptography;

namespace Puls.Cloud.Framework.SymmetricEncryption;

internal class SymmetricAlgorithmConfig 
{
    public CipherMode CipherMode { get; set; }
    public PaddingMode PaddingMode { get; set; }
    public string HexKey { get; init; }

    public SymmetricAlgorithmConfig(string hexKey)
    {
        HexKey = hexKey;
    }
}
