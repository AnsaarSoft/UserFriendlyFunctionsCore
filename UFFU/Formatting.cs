using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UFFU
{
    public partial class mFm
    {

        #region Exposed Functions

        public static string ApplyFormat(string Value, FormatType Type, PrecisionValue Precision, GroupType Grouping)
        {
            string retValue = "0.0";
            try
            {
                CultureInfo myCulture = new CultureInfo("en-US");
                string myType = string.Empty;
                switch (Grouping)
                {
                    case GroupType.Local:
                        {
                            myCulture.NumberFormat.CurrencyGroupSizes = new int[] { 3, 2, 2, 2 };
                            break;
                        }

                    case GroupType.International:
                        {
                            myCulture.NumberFormat.CurrencyGroupSizes = new int[] { 3, 3, 3, 3 };
                            break;
                        }
                }

                if (Type == FormatType.Currency & Precision == PrecisionValue.Zero)
                    myType = "{0:0}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.One)
                    myType = "{0:C}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.Two)
                    myType = "{0:C2}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.Three)
                    myType = "{0:C3}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.Four)
                    myType = "{0:C4}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.Five)
                    myType = "{0:C5}";
                else if (Type == FormatType.Currency & Precision == PrecisionValue.Six)
                    myType = "{0:C6}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Zero)
                    myType = "{0:0}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.One)
                    myType = "{0:D}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Two)
                    myType = "{0:D2}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Three)
                    myType = "{0:D3}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Four)
                    myType = "{0:D4}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Five)
                    myType = "{0:D5}";
                else if (Type == FormatType.Number & Precision == PrecisionValue.Six)
                    myType = "{0:D6}";
                retValue = string.Format(myCulture, myType, Convert.ToDecimal(Value));
            }
            catch (Exception ex)
            {
                retValue = "0.00";
            }
            return retValue;
        }

        public static string ApplyFormat(string Value, string Type, UInt16 Precision)
        {
            string retValue = "0";
            string DotZero = "";
            string CurrencyValue = "C";
            if (Precision != 0)
            {
                switch (Precision)
                {
                    case 1:
                        {
                            DotZero = ".0";
                            CurrencyValue = "C";
                            break;
                        }

                    case 2:
                        {
                            DotZero = ".00";
                            CurrencyValue = "C2";
                            break;
                        }

                    case 3:
                        {
                            DotZero = ".000";
                            CurrencyValue = "C3";
                            break;
                        }

                    case 4:
                        {
                            DotZero = ".0000";
                            CurrencyValue = "C4";
                            break;
                        }

                    case 5:
                        {
                            DotZero = ".00000";
                            CurrencyValue = "C5";
                            break;
                        }

                    case 6:
                        {
                            DotZero = ".000000";
                            CurrencyValue = "C6";
                            break;
                        }
                }
            }
            try
            {
                switch (Type.ToUpper())
                {
                    case "D":
                        {
                            retValue = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:#,##,0" + DotZero + "}", Convert.ToDecimal(Value));
                            break;
                        }

                    case "PKD":
                    case "PK":
                        {
                            retValue = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-IN"), "{0:#,##,0" + DotZero + "}", Convert.ToDecimal(Value));
                            break;
                        }

                    case "USD":
                        {
                            NumberFormatInfo myNumberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
                            int[] myIntSizes = new[] { 3, 3, 3, 3 };
                            myNumberFormatInfo.CurrencyGroupSizes = myIntSizes;
                            retValue = Convert.ToUInt64(Value).ToString(CurrencyValue, myNumberFormatInfo);
                            break;
                        }

                    case "PER":
                    case "%":
                        {
                            retValue = string.Format("{0:##0" + DotZero + " %}", Convert.ToDecimal(Value));
                            break;
                        }

                    case "PKR":
                        {
                            NumberFormatInfo myNumberFormatInfo = new CultureInfo("ur-PK", false).NumberFormat;
                            int[] myIntSizes = new[] { 3, 2, 2, 2 };
                            myNumberFormatInfo.CurrencyGroupSizes = myIntSizes;
                            retValue = Convert.ToUInt64(Value).ToString(CurrencyValue, myNumberFormatInfo);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                retValue = "0";
            }
            return retValue;
        }

        public static string RemoveFormat(string value)
        {
            string retValue = "";
            try
            {
                // retValue = value.Replace(",", "")
                foreach (char CharValue in value)
                {
                    
                    int CharInt = Convert.ToInt32(CharValue);
                    if ((CharInt >= 48 & CharInt <= 57) | CharInt == 46)
                        retValue = retValue + CharValue;
                }
            }
            catch (Exception ex)
            {
                retValue = "0.0";
            }
            return retValue;
        }

        #endregion

    }
}
