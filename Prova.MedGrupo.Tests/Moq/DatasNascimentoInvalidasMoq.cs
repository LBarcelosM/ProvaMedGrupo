using System;
using System.Collections;
using System.Collections.Generic;

namespace Prova.MedGrupo.Tests.Moq
{
    public class DatasNascimentoInvalidasMoq : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DateTime.Now.AddDays(1) };
            yield return new object[] { DateTime.MinValue };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}