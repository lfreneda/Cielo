using Cielo.Enums;

namespace Cielo.Requests.Entities
{
    public class CreateTransactionOptions
    {
        public CreateTransactionOptions(AuthorizationType authorizationType, bool capture = false,
            bool generateToken = false)
        {
            AuthorizationType = authorizationType;
            Capture = capture;
            GenerateToken = generateToken;
        }

        public AuthorizationType AuthorizationType { get; private set; }
        public bool Capture { get; private set; }
        public bool GenerateToken { get; private set; }
    }
}