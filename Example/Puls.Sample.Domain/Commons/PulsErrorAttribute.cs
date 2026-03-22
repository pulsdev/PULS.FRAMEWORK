namespace Puls.Sample.Domain.Commons
{
    public class PulsErrorAttribute : Attribute
    {
        public string Message { get; private set; } = null!;

        public PulsErrorAttribute(string message)
        {
            Message = message;
        }
    }
}