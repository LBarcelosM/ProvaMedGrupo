using System;
using System.Linq;
using System.Threading.Tasks;
using Prova.MedGrupo.Application.Interfaces;
using Prova.MedGrupo.Domain.Enums;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Resources;
using Xunit;

namespace Prova.MedGrupo.Tests.Contato
{
    public class ContatosAppServiceTests : ContatoTests
    {
        private readonly IContatosAppService _contatosAppService;

        public ContatosAppServiceTests(
            INotificationContext notificationContext,
            IContatosAppService contatosAppService)
            : base(notificationContext)
        {
            _contatosAppService = contatosAppService;
        }

        [Fact]
        public async Task Deve_cadastrar_com_sucesso_novo_Contato()
        {
            var contatoViewModel = CreateViewModel();
            Assert.True(await _contatosAppService.Create(contatoViewModel) > 0);
            Assert.True(NotificationContext.Successfully);
        }

        [Fact]
        public async Task Deve_atualizar_Contato_com_sucesso()
        {
            var nome = "TestAtualizar";
            var contatoViewModel = CreateViewModel(nome: nome);
            var id = await _contatosAppService.Create(contatoViewModel);
            contatoViewModel.Id = id;
            contatoViewModel.Nome = $"{contatoViewModel.Nome}_XXXXXX";
            Assert.True(await _contatosAppService.Update(contatoViewModel));
            Assert.True(NotificationContext.Successfully);
        }

        [Fact]
        public async Task Deve_excluir_Contato_com_sucesso()
        {
            var nome = "TestExclusao";
            var contatoViewModel = CreateViewModel(nome: nome);
            var id = await _contatosAppService.Create(contatoViewModel);
            Assert.True(await _contatosAppService.Delete(id));
            Assert.True(NotificationContext.Successfully);
        }

        [Fact]
        public async Task Deve_invalidar_cadastro_de_novo_Contato_com_sexo_invalido()
        {
            var contatoViewModel = CreateViewModel();
            contatoViewModel.Sexo = "XXXX";
            Assert.False(await _contatosAppService.Create(contatoViewModel) > 0);
            Assert.False(NotificationContext.Successfully);
            Assert.Contains(NotificationContext.ErrorNotifications, x => x.Message == TextResource.SexoInvalido);
        }

        [Fact]
        public async Task Deve_invalidar_atualizacao_de_Contato_com_sexo_invalido()
        {
            var nome = "TestAtualizarSexoInvalido";
            var contatoViewModel = CreateViewModel(nome: nome);
            var id = await _contatosAppService.Create(contatoViewModel);
            contatoViewModel.Id = id;
            contatoViewModel.Nome = $"{contatoViewModel.Nome}_XXXXXX";
            contatoViewModel.Sexo = "A";
            Assert.False(await _contatosAppService.Update(contatoViewModel));
            Assert.False(NotificationContext.Successfully);
            Assert.Contains(NotificationContext.ErrorNotifications, x => x.Message == TextResource.SexoInvalido);
            // Assert.True(await _contatosAppService.Update(contatoViewModel));
            // Assert.True(NotificationContext.Successfully);
        }
    }
}