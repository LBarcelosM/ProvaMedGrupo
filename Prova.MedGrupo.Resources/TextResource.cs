using System;

namespace Prova.MedGrupo.Resources
{
    public static class TextResource
    {
        public static string InternalServerError => "Ocorreu um erro interno no servidor!";
        public static string NomeInvalido => "O nome deve conter entre 3 e 128 caracteres.";
        public static string DataNascimentoInvalida => "A data de nascimento deve ser menor ou igual a {0}.";
        public static string SexoInvalido => "Sexo inválido, os valores aceitos são [SMasculino|Feminino].";
        public static string ContatoErroJaExisteComMesmoNome => "Existe um contato cadastrado com o nome informado.";
        public static string ContatoCriadoSucesso => "Contado criado com sucesso.";
        public static string ContatoErroCriar => "Erro ao criar contato.";
        public static string ContatoAtualizadoSucesso => "Dados do contato atualizados com sucesso.";
        public static string ContatoErroAtualizar => "Erro ao atualizar dados do contato.";
        public static string ContatoExcluidoSucesso => "Contato excluído com sucesso.";
        public static string ContatoErroExcluir => "Erro ao excluir contato.";
    }
}
