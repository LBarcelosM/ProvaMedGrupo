using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prova.MedGrupo.Application.Interfaces;
using Prova.MedGrupo.Application.ViewModels;
using Prova.MedGrupo.Framework.Interfaces;

namespace Prova.MedGrupo.WebApi.Controlles
{
    [Route("api/contatos")]
    public class ContatosController : BaseController
    {
        private readonly IContatosAppService _contatosAppService;
        public ContatosController(
            INotificationContext notificationContext,
            IContatosAppService contatosAppService) : base(notificationContext)
        {
            _contatosAppService = contatosAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await TryExecuteAsync(_contatosAppService.GetAll());
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await TryExecuteAsync(_contatosAppService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContatoViewModel viewModel)
        {
            return await TryExecuteAsync(_contatosAppService.Create(viewModel));
        }

        [HttpPut, Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContatoViewModel viewModel)
        {
            return await TryExecuteAsync(_contatosAppService.Update(viewModel));
        }

        [HttpDelete, Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await TryExecuteAsync(_contatosAppService.Delete(id));
        }
    }
}