using System.Collections;
using System.Collections.Generic;

namespace Prova.MedGrupo.Tests.Moq
{
    public class NomesInvalidosMoq : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "" };
            yield return new object[] { "AA" };
            yield return new object[] { "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}