using prmToolkit.NotificationPattern;

namespace VendasLyncas.Domain.Entities
{
    public abstract class EntidadeBase : Notifiable
    {
        public int Id { get; private set; }
    }
}
