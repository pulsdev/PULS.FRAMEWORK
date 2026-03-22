namespace Puls.Cloud.Framework.Authentication.Contracts
{
	public interface IFakeJwtTokenGenerator
	{
		string GenerateToken(Dictionary<string, string> claims, TimeSpan expiry);
	}
}
