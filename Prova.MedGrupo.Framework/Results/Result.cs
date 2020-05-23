using System.Collections.Generic;
using Prova.MedGrupo.Framework.Interfaces;

namespace Prova.MedGrupo.Framework.Results
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public IEnumerable<INotification> Notifications { get; set; }
        public object Data { get; set; }
    }
}