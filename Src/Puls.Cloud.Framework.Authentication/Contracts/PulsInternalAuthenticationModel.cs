namespace Puls.Cloud.Framework.Authentication.Contracts;

public class PulsInternalAuthenticationModel
{
	public bool IsAuthorized { get; set; }
	public List<PulsClaimItem>? Claims { get; set; }
}