using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoA3s.Util
{
    public class ValidadorCPF
    {
        // Método público para validar CPF
        public static bool ValidarCPF(string cpf)
        {
            // Remover caracteres não numéricos do CPF
            cpf = RemoverCaracteresNaoNumericos(cpf);

            // Verificar se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificar se todos os dígitos do CPF são iguais
            if (TodosDigitosIguais(cpf))
                return false;

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * int.Parse(cpf[i].ToString());
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            // Verificar se o primeiro dígito verificador está correto
            if (digitoVerificador1 != int.Parse(cpf[9].ToString()))
                return false;

            // Calcular o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * int.Parse(cpf[i].ToString());
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verificar se o segundo dígito verificador está correto
            if (digitoVerificador2 != int.Parse(cpf[10].ToString()))
                return false;

            // CPF válido
            return true;
        }

        // Método para remover caracteres não numéricos do CPF
        private static string RemoverCaracteresNaoNumericos(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        // Método para verificar se todos os dígitos do CPF são iguais
        private static bool TodosDigitosIguais(string cpf)
        {
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                    return false;
            }
            return true;
        }
    }
}
