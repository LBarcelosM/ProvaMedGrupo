using System.Collections.Generic;
using Prova.MedGrupo.Framework.Interfaces.Data;

namespace Prova.MedGrupo.Framework.Interfaces
{
    public interface IResult
    {
        bool Success { get; set; }
        IEnumerable<INotification> Notifications { get; set; }
        object Data { get; set; }
    }
}