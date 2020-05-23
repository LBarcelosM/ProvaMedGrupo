using System.Collections.Generic;
using Prova.MedGrupo.Framework.Enums;

namespace Prova.MedGrupo.Framework.Interfaces
{
    public interface INotificationContext
    {
        void Add(INotification notification);
        void Add(ENotificationType notificationType, string message);
        void AddSuccess(string message);
        void AddError(string message);
        void Clear();
        bool Successfully { get; }
        IEnumerable<INotification> ErrorNotifications { get; }
        IEnumerable<INotification> AllNotifications { get; }
    }
}