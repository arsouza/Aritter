using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class UserClient : Entity
    {
        public UserClient(Client client, UserAccount user)
            : this()
        {
            Client = client;
            ClientId = client.Id;

            UserAccount = user;
            UserAccountId = user.Id;
        }

        private UserClient()
            : base()
        {
        }

        public int ClientId { get; private set; }
        public int UserAccountId { get; private set; }
        public virtual UserAccount UserAccount { get; private set; }
        public virtual Client Client { get; private set; }
    }
}
