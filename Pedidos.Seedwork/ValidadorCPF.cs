using System;
using System.Text.RegularExpressions;

namespace APICorePedidos.CrossCutting
{
    public static class ValidadorCPF
    {
        public static Boolean CPFValido(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            string pat = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(cpf);
            return m.Success;
        }
    }
}
