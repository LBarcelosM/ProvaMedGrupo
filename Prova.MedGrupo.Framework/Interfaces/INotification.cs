using Prova.MedGrupo.Framework.Enums;

namespace Prova.MedGrupo.Framework.Interfaces
{
    public interface INotification
    {
        ENotificationType NotificationType { get; set; }
        string Message { get; set; }
    }
}