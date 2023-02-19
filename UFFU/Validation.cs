using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UFFU
{
    public partial class mFm
    {
        public static bool IsInteger(string pValue, string pType = "32")
        {
            bool retvalue = false;
            try
            {
                if (pType == "32")
                {
                    Int32 x;
                    x = Int32.Parse(pValue);
                }
                if (pType == "16")
                {
                    Int16 x;
                    x = Int16.Parse(pValue);
                }
                if (pType == "64")
                {
                    Int64 x;
                    x = Int64.Parse(pValue);
                }   
                retvalue = true;
            }
            catch (Exception ex)
            {
                retvalue = false;
            }
            return retvalue;
        }

        public static bool IsDecimal(string pValue)
        {
            bool retvalue = false;
            try
            {
                decimal x = 0;
                x = decimal.Parse(pValue);
                retvalue = true;
            }
            catch (Exception ex)
            {
                retvalue = false;
            }
            return retvalue;
        }

        public static bool IsEmail(string pValue)
        {
            bool retvalue = false;
            try
            {
                // Dim emailpattern As String = "^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
                string emailpattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(emailpattern);
                if (regex.IsMatch(pValue))
                    retvalue = true;
                else
                    retvalue = false;
            }
            catch (Exception ex)
            {
                retvalue = false;
            }
            return retvalue;
        }

        public static bool IsAlphabet(string pValue)
        {
            bool retvalue = false;
            try
            {
                string alphabetspattern = "^[a-zA-Z]+$";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(alphabetspattern);
                if (regex.IsMatch(pValue))
                    retvalue = true;
                else
                    retvalue = false;
            }
            catch (Exception ex)
            {
                retvalue = false;
            }
            return retvalue;
        }

        public static bool IsNumber(string pValue)
        {
            bool retvalue = false;
            try
            {
                string pattren = "^[0-9]+$";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattren);
                if (regex.IsMatch(pValue))
                    retvalue = true;
                else
                    retvalue = false;
            }
            catch (Exception ex)
            {
                retvalue = false;
            }
            return retvalue;
        }

        public static bool IsEven(string pValue)
        {
            bool retValue = false;
            try
            {
                Int64 number;
                number = Convert.ToInt64(pValue);
                if (number % 2 == 0)
                    retValue = true;
                else
                    retValue = false;
            }
            catch (Exception ex)
            {
                retValue = false;
            }
            return retValue;
        }

        public static bool IsNullObject(object pValue)
        {
            bool retValue = false;
            try
            {
                if (pValue is null)
                    retValue = false;
                else
                    retValue = true;
            }
            catch (Exception ex)
            {
                retValue = false;
            }
            return retValue;
        }

        public static bool IsDatetime(string pValue)
        {
            bool retValue = false;
            try
            {
                DateTime x;
                retValue = DateTime.TryParse(pValue, CultureInfo.InvariantCulture, DateTimeStyles.None, out x);
            }
            catch (Exception ex)
            {
                retValue = false;
            }
            return retValue;
        }

        public static bool StringSize(string pValue, UInt16 pSize)
        {
            bool ReturnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(pValue))
                {
                    if (pValue.Length <= pSize)
                        ReturnValue = true;
                    else
                        ReturnValue = false;
                }
                else
                    ReturnValue = false;
            }
            catch (Exception ex)
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
    }

}
