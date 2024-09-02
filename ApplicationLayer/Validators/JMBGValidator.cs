using DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ApplicationLayer.Validators
{
    public class JMBGValidator
    {
        public static bool ValidateJMBG(long jmbg)
        {
            string jmbgStr = jmbg.ToString("D13");

            if (jmbgStr.Length != 13)
                return false;

            //if(IsExist(jmbg))
            //    return false;

            string dd = jmbgStr.Substring(0, 2); //dan
            string mm = jmbgStr.Substring(2, 2); //mesec
            string yyy = jmbgStr.Substring(4, 3); //godina (3 cifre)
            string rr = jmbgStr.Substring(7, 2); //region rodjenja
            string bbb = jmbgStr.Substring(9, 3); //pol
            string k = jmbgStr.Substring(12, 1); //kontrolna cifra


            if (jmbgStr[4] == '0')
            {
                if (!DateTime.TryParse($"2{yyy}-{mm}-{dd}", out DateTime dateOfBirth))
                    return false;
            }
            else if (jmbgStr[4] == '9')
            {
                if (!DateTime.TryParse($"1{yyy}-{mm}-{dd}", out DateTime dateOfBirth))
                    return false;
            }
            else
            {
                return false;
            }


            int regionCode = int.Parse(rr);
            if (regionCode < 0 || regionCode > 99) 
                return false;

            int genderNum = int.Parse(bbb);
            if (genderNum < 0 || genderNum > 999)
                return false;

            int controlNum = int.Parse(k);
            int l = CalculateControlNumber(jmbgStr.Substring(0, 12));
            if (controlNum != l)
                return false;

            return true;
        }

        private static int CalculateControlNumber(string jmbgStrWithoutK)
        {
            int[] x = jmbgStrWithoutK.Select(d => int.Parse(d.ToString())).ToArray();

            int sum = 7 * (x[0] + x[6]) + 6 * (x[1] + x[7]) + 5 * (x[2] + x[8]) + 4 * (x[3] + x[9]) + 3 * (x[4] + x[10]) + 2 * (x[4] + x[11]);

            int l = 11 - (sum % 11);

            if (l > 9) l = 0;

            return l;
        }

        private static bool IsExist(long jmbg)
        {

            return true;
        }
    }
}
