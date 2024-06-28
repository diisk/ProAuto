using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAuto.Helpers
{
    public class Mensagens
    {
        public const String ERRO_CAMPO_OBRIGATORIO = "Campo obrigatório, favor preencher.";
        public const String ERRO_CPF_INVALIDO = "Formato do CPF inválido.";
        public const String ERRO_TELEFONE_INVALIDO = "Formato do telefone inválido.";
        public const String ERRO_DADOS_INVALIDOS = "Dados inválidos, favor confirmar CPF e placa do veículo.";
        public const String ERRO_CPF_CADASTRADO = "Já existe um associado cadastrado com esse CPF.";
        public const String ERRO_VEICULO_CADASTRADO = "Veículo já cadastrado no sistema.";

    }
}