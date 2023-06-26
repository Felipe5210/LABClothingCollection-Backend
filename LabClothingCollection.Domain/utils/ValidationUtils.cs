using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.utils
{
    public class ValidationUtils
    {
        public static bool IsCpfOrCnpjValid(string document)
        {
            document = Regex.Replace(document, "[^0-9]", "");

            switch (document.Length)
            {
                case 11:
                case 14:
                    return true;
                default:
                    return false;
            }
        }
    }
}