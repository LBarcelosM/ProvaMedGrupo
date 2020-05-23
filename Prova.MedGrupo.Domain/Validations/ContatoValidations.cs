using System.Threading.Tasks;
using FluentValidation.Results;
using Prova.MedGrupo.Domain.Entities;
using Prova.MedGrupo.Domain.Interfaces;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Resources;

namespace Prova.MedGrupo.Domain.Validations
{
    public class ContatoValidations : IContatoValidations
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly INotificationContext _notificationContext;

        public ContatoValidations(
            IContatoRepository contatoRepository,
            INotificationContext notificationContext)
        {
            _contatoRepository = contatoRepository;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Validate(Contato contato)
        {
            var validator = new ContatoValidator();
            var validationResult = await validator.ValidateAsync(contato);
            if (validationResult.IsValid)
            {
                if (await _contatoRepository.Exists(contato.Nome, contato.Id))
                {
                    _notificationContext.AddError(TextResource.ContatoErroJaExisteComMesmoNome);
                }
            }
            else
            {
                CreateErrorNotifications(validationResult);
            }
            return _notificationContext.Successfully;
        }

        private void CreateErrorNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notificationContext.AddError(error.ErrorMessage);
            }
        }
    }
}