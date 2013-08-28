using Cielo.Enums;

namespace Cielo.Requests
{
    public class CreateTransactionOptions
    {
        public AuthorizationType AuthorizationType { get; private set; }
        public bool Capture { get; private set; }
        public bool GenerateToken { get; private set; }

        public CreateTransactionOptions(AuthorizationType authorizationType, bool capture = false, bool generateToken = false)
        {
            AuthorizationType = authorizationType;
            Capture = capture;
            GenerateToken = generateToken;
        }
    }
}