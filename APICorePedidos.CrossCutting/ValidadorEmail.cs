using System;
using System.Text.RegularExpressions;

namespace APICorePedidos.CrossCutting
{
    public static class ValidadorEmail
    {
        public static Boolean EmailValido(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            string pat = @"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(cpf);
            return m.Success;
        }
    }
}
