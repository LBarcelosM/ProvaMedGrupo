using System.Collections.Generic;
using System.Linq;
using Prova.MedGrupo.Framework.Enums;
using Prova.MedGrupo.Framework.Interfaces;

namespace Prova.MedGrupo.Framework.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private IList<INotification> _notifications;
        public bool Successfully => !(_notifications?.Any(x => x.NotificationType == ENotificationType.Error)).GetValueOrDefault();
        public IEnumerable<INotification> ErrorNotifications => _notifications?.Where(x => x.NotificationType == ENotificationType.Error);
        public IEnumerable<INotification> AllNotifications => _notifications;

        public NotificationContext()
        {
            Clear();
        }

        public void Clear() => _notifications = new List<INotification>();

        public void Add(INotification notification)
        {
            _notifications.Add(notification);
        }

        public void Add(ENotificationType notificationType, string message)
        {
            _notifications.Add(new Notification
            {
                NotificationType = notificationType,
                Message = message
            });
        }

        public void AddSuccess(string message)
        {
            Add(ENotificationType.Success, message);
        }

        public void AddError(string message)
        {
            Add(ENotificationType.Error, message);
        }
    }
}