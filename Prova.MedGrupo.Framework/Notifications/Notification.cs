using Prova.MedGrupo.Framework.Enums;
using Prova.MedGrupo.Framework.Interfaces;

namespace Prova.MedGrupo.Framework.Notifications
{
    public class Notification : INotification
    {
        public ENotificationType NotificationType { get; set; }
        public string Message { get; set; }
    }
}