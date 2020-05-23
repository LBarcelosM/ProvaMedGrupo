using System;
using Prova.MedGrupo.Domain.Enums;
using Prova.MedGrupo.Framework.Interfaces.Data;

namespace Prova.MedGrupo.Domain.Entities
{
    public class Contato : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }
        public int Idade { get { return new DateTime(DateTime.Now.Subtract(DataNascimento).Ticks).Year - 1; } }

        protected Contato() { }

        public Contato(string nome, DateTime dataNascimento, ESexo sexo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }

        public static class Factory
        {
            public static Contato CreateWithId(int id, string nome, DateTime dataNascimento, ESexo sexo)
            {
                return new Contato
                {
                    Id = id,
                    Nome = nome,
                    DataNascimento = dataNascimento,
                    Sexo = sexo
                };
            }
        }
    }
}