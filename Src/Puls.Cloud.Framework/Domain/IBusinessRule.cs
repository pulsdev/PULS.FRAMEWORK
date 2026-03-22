using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Domain;

public interface IBusinessRule
{
    Task<bool> IsBrokenAsync();

    string Message { get; }
}
