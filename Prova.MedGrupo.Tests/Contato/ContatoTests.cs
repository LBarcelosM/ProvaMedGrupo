using System;
using Prova.MedGrupo.Application.ViewModels;
using Prova.MedGrupo.Domain.Enums;
using Prova.MedGrupo.Framework.Interfaces;

namespace Prova.MedGrupo.Tests.Contato
{
    public abstract class ContatoTests
    {
        protected INotificationContext NotificationContext;
        public ContatoTests(INotificationContext notificationContext)
        {
            NotificationContext = notificationContext;
        }

        protected ContatoViewModel CreateViewModel(
            int id = default,
            string nome = "Teste",
            DateTime? dataNascimento = null,
            ESexo sexo = ESexo.Masculino)
        {
            dataNascimento = dataNascimento ?? DateTime.Now.AddYears(-10);
            return new ContatoViewModel
            {
                Id = id,
                Nome = nome,
                DataNascimento = dataNascimento.Value,
                Sexo = Enum.GetName(typeof(ESexo), sexo)
            };
        }

        protected Domain.Entities.Contato CreateContato(
            string nome = "Teste",
            DateTime? dataNascimento = null,
            ESexo sexo = ESexo.Masculino)
        {
            dataNascimento = dataNascimento ?? DateTime.Now.AddYears(-10);
            return new Domain.Entities.Contato(nome, dataNascimento.Value, sexo);
        }
    }
}