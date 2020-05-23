using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Prova.MedGrupo.Application.Interfaces;
using Prova.MedGrupo.Application.ViewModels;
using Prova.MedGrupo.Domain.Entities;
using Prova.MedGrupo.Domain.Enums;
using Prova.MedGrupo.Domain.Interfaces;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Framework.Interfaces.Data;
using Prova.MedGrupo.Resources;

namespace Prova.MedGrupo.Application.Services
{
    public class ContatosAppService : IContatosAppService
    {
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoValidations _contatoValidations;

        public ContatosAppService(
            IMapper mapper,
            INotificationContext notificationContext,
            IUnitOfWork unitOfWork,
            IContatoRepository contatoRepository,
            IContatoValidations contatoValidations)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _contatoRepository = contatoRepository;
            _contatoValidations = contatoValidations;
        }

        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.Get());
        }

        public async Task<ContatoViewModel> GetById(int id)
        {
            return _mapper.Map<ContatoViewModel>(await _contatoRepository.FindById(id));
        }

        public async Task<int> Create(ContatoViewModel viewModel)
        {
            if (!Validate(viewModel))
            {
                return default;
            }
            var contato = _mapper.Map<Contato>(viewModel);
            try
            {
                if (await _contatoValidations.Validate(contato))
                {
                    await _contatoRepository.AddAsync(contato);
                    await _unitOfWork.CommitAsync();
                    _notificationContext.AddSuccess(TextResource.ContatoCriadoSucesso);
                    _unitOfWork.Untrack(contato); // Hack pro teste não dar erro de Track ao atualizar
                    return contato.Id;
                }
            }
            catch
            {
                ///TODO: Criar mecanismo para logar exceptions
                _notificationContext.AddError(TextResource.ContatoErroCriar);
            }
            return default;
        }

        public async Task<bool> Update(ContatoViewModel viewModel)
        {
            if (!Validate(viewModel))
            {
                return default;
            }
            var contato = _mapper.Map<Contato>(viewModel);
            try
            {
                if (await _contatoValidations.Validate(contato))
                {
                    _contatoRepository.Update(contato);
                    await _unitOfWork.CommitAsync();
                    _notificationContext.AddSuccess(TextResource.ContatoAtualizadoSucesso);
                    return true;
                }
            }
            catch
            {
                ///TODO: Criar mecanismo para logar exceptions
                _notificationContext.AddError(TextResource.ContatoErroAtualizar);
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var contato = await _contatoRepository.FindById(id);
                _contatoRepository.Remove(contato);
                await _unitOfWork.CommitAsync();
                _notificationContext.AddSuccess(TextResource.ContatoExcluidoSucesso);
                return true;
            }
            catch
            {
                ///TODO: Criar mecanismo para logar exceptions
                _notificationContext.AddError(TextResource.ContatoErroExcluir);
                return false;
            }
        }

        private bool Validate(ContatoViewModel viewModel)
        {
            if (!Enum.GetNames(typeof(ESexo)).Select(x => x.ToLower()).Contains(viewModel.Sexo.ToLower()))
            {
                _notificationContext.AddError(TextResource.SexoInvalido);
                return false;
            }
            return true;
        }
    }
}