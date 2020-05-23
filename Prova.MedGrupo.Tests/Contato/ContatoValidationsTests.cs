using System;
using System.Threading.Tasks;
using Prova.MedGrupo.Domain.Interfaces;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Resources;
using Prova.MedGrupo.Tests.Moq;
using Xunit;

namespace Prova.MedGrupo.Tests.Contato
{
    public class ContatoValidationsTests : ContatoTests
    {
        private readonly IContatoValidations _contatoValidations;
        private readonly IContatoRepository _contatoRepository;
        public ContatoValidationsTests(
            INotificationContext notificationContext,
            IContatoValidations contatoValidations,
            IContatoRepository contatoRepository)
        : base(notificationContext)
        {
            _contatoValidations = contatoValidations;
            _contatoRepository = contatoRepository;
        }

        [Fact]
        public async Task Deve_validar_com_sucesso_novo_Contato()
        {
            var contato = CreateContato();
            Assert.True(await _contatoValidations.Validate(contato));
        }

        [Theory]
        [ClassData(typeof(DatasNascimentoInvalidasMoq))]
        public async Task Deve_invalidar_Contato_com_datas_invalidas(DateTime dataNascimento)
        {
            var contato = CreateContato(dataNascimento: dataNascimento);
            Assert.False(await _contatoValidations.Validate(contato));
            var errorMessage = string.Format(TextResource.DataNascimentoInvalida, DateTime.Now.ToString("dd/MM/yyyy"));
            Assert.Contains(NotificationContext.ErrorNotifications, x => x.Message == errorMessage);
        }

        [Fact]
        public async Task Deve_invalidar_Contato_existente_com_mesmo_nome()
        {
            var contato = CreateContato();
            await _contatoRepository.AddAsync(contato);
            var contatoNomeDuplicado = Domain.Entities.Contato.Factory.CreateWithId(int.MaxValue, contato.Nome, contato.DataNascimento, contato.Sexo);
            Assert.True(await _contatoValidations.Validate(contatoNomeDuplicado));
        }

        [Theory]
        [ClassData(typeof(NomesInvalidosMoq))]
        public async Task Deve_invalidar_Contato_com_nomes_invalidos(string nome)
        {
            var contato = CreateContato(nome: nome);
            Assert.False(await _contatoValidations.Validate(contato));
            Assert.Contains(NotificationContext.ErrorNotifications, x => x.Message == TextResource.NomeInvalido);
        }
    }
}