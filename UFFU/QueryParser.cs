using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UFFU
{
    public partial class mFm
    {
        private static List<string> KeywordList = new List<string>();
        private static List<string> OperatorList = new List<string>();


        private void InitiallizeKeywordList()
        {
            try
            {
                KeywordList.Add("SELECT");
                KeywordList.Add("FROM");
                KeywordList.Add("INSERT");
                KeywordList.Add("INTO");
                KeywordList.Add("VALUES");
                KeywordList.Add("UPDATE");
                KeywordList.Add("SET");
                KeywordList.Add("WHERE");
                KeywordList.Add("GROUP");
                KeywordList.Add("ORDER");
                KeywordList.Add("BY");
                KeywordList.Add("DESC");
                KeywordList.Add("ASC");
                KeywordList.Add("AND");
                KeywordList.Add("OR");
                KeywordList.Add("ON");
                KeywordList.Add("INNER");
                KeywordList.Add("OUTER");
                KeywordList.Add("LEFT");
                KeywordList.Add("JOIN");
                KeywordList.Add("TOP");
                KeywordList.Add("ISNULL");
                KeywordList.Add("COUNT");
                KeywordList.Add("SUM");
            }
            catch (Exception ex)
            {
            }
        }

        private void InitiallizeOperatorList()
        {
            try
            {
                OperatorList.Add("=");
                OperatorList.Add("<>");
                OperatorList.Add("<=");
                OperatorList.Add(">=");
                OperatorList.Add("<");
                OperatorList.Add(">");
                OperatorList.Add("(");
                OperatorList.Add(")");
                OperatorList.Add("IN");
                OperatorList.Add("LIKE");
                OperatorList.Add("BETWEEN");
                OperatorList.Add("AS");
                OperatorList.Add("*");
            }
            catch (Exception ex)
            {
            }
        }

        private static string ClearString(string strValue)
        {
            string retValue = string.Empty;
            try
            {
                retValue = Regex.Replace(strValue, @"\t|\n|\r", " ");
                retValue = retValue.Replace("[dbo].", " ").Replace("dbo.", " ");
            }
            catch (Exception ex)
            {
                retValue = strValue;
            }
            return retValue;
        }

        private static string AppliedQuotes(string strValue)
        {
            string retValue = string.Empty;
            try
            {
                // retValue = Regex.Replace(strValue, "[|]", """")
                retValue = strValue.Replace("[", "\"").Replace("]", "\"");
            }
            catch (Exception ex)
            {
                retValue = strValue;
            }
            return retValue;
        }

        private static string AppliedFunctions(string strValue)
        {
            string retValue = string.Empty;
            try
            {
                retValue = Regex.Replace(strValue, "ISNULL", "IFNULL");
                retValue = Regex.Replace(retValue, "GETDATE", "CURRENT_TIMESTAMP");
            }
            catch (Exception ex)
            {
                retValue = strValue;
            }
            return retValue;
        }

        private static string ReplaceString(string strValue)
        {
            string retValue = string.Empty;
            try
            {
                switch (strValue.ToUpper())
                {
                    case "GETDATE":
                        {
                            retValue = "GETDATE()";
                            break;
                            break;
                        }

                    default:
                        {
                            retValue = strValue;
                            break;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
            return retValue;
        }

        private static string QueryParsing1(string Query)
        {
            string retValue = "";
            try
            {
                string[] arrTemp = Query.Split(' ', '\n', '(', ')');
                bool flgAfterSelect = false;
                bool flgAfterFrom = false;
                bool flgAfterWhere = false;
                bool flgFirstField = true;
                bool flgWhereRightSide = false;
                bool flgFromRightEqual = false;
                bool flgFromRightAs = false;
                bool flgAfterGroupBy = false;
                bool flgGroupByFirstField = true;
                bool flgTopFound = false;
                bool flgIsnullFunction = false;
                bool flgAfterOrderBy = false;
                bool flgCountFunction = false;
                bool flgSumFunction = false;
                bool flgOrder = false;
                bool flgGroup = false;
                bool flgAfterInsert = false;
                bool flgAfterValue = false;
                bool flgTableFound = true;
                bool flgAfterValueFirstField = true;
                bool flgAfterUpdate = false;
                bool flgAfterSet = false;
                bool flgExpressionRightSide = false;

                List<string> WordList = new List<string>();
                foreach (var Word in arrTemp)
                {
                    string TempWord = ClearString(Word.Trim());
                    if (string.IsNullOrEmpty(TempWord))
                        continue;
                    if (string.IsNullOrWhiteSpace(TempWord))
                        continue;
                    WordList.Add(TempWord.Trim());
                }

                if (WordList[0].ToUpper().Trim() == "SELECT")
                {
                    int Counter = 0;
                    int funcCounter = 0;
                    foreach (var Word in WordList)
                    {
                        Counter += 1;
                        string Tempword = Word.Trim();
                        if (flgIsnullFunction)
                        {
                            funcCounter += 1;
                            if (funcCounter != 5)
                                continue;
                            else
                                flgIsnullFunction = false;
                        }
                        if (flgCountFunction)
                        {
                            funcCounter += 1;
                            if (funcCounter != 4)
                                continue;
                            else
                                flgCountFunction = false;
                        }
                        if (flgSumFunction)
                        {
                            funcCounter += 1;
                            if (funcCounter != 4)
                                continue;
                            else
                                flgSumFunction = false;
                        }
                        if (KeywordList.Contains(Tempword.ToUpper()))
                        {
                            if (Tempword.ToUpper() == "SELECT")
                            {
                                retValue = (Tempword + Convert.ToString(" ")) + Environment.NewLine;
                                flgAfterSelect = true;
                            }
                            else if (Tempword.ToUpper() == "FROM")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " " + Environment.NewLine;
                                flgAfterFrom = true;
                            }
                            else if (Tempword.ToUpper() == "WHERE")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " " + Environment.NewLine;
                                flgAfterWhere = true;
                            }
                            else if (Tempword.ToUpper() == "GROUP")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " ";
                                flgGroup = true;
                            }
                            else if (Tempword.ToUpper() == "ORDER")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " ";
                                flgOrder = true;
                            }
                            else if (Tempword.ToUpper() == "BY")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " " + Environment.NewLine;
                                if (flgGroup)
                                {
                                    flgGroup = false;
                                    flgAfterGroupBy = true;
                                }
                                if (flgOrder)
                                {
                                    flgOrder = false;
                                    flgAfterOrderBy = true;
                                }
                            }
                            else if (Tempword.ToUpper() == "ISNULL")
                            {
                                if (!WordList[Counter].Contains('.'))
                                {
                                    if (flgFirstField)
                                    {
                                        retValue += " " + Tempword.Replace("ISNULL", "IFNULL") + "( \"" + WordList[Counter].Replace(",", string.Empty) + "\", " + WordList[Counter + 1] + ") AS " + WordList[Counter + 3] + Environment.NewLine + "\t";
                                        flgFirstField = false;
                                    }
                                    else
                                        retValue += ", " + Tempword.Replace("ISNULL", "IFNULL") + "( \"" + WordList[Counter].Replace(",", string.Empty) + "\", " + WordList[Counter + 1] + ") AS " + WordList[Counter + 3] + Environment.NewLine + "\t";
                                }
                                else if (flgFirstField)
                                {
                                    string[] AliasArray = WordList[Counter].Trim().Split('.');
                                    retValue += " " + Tempword.Replace("ISNULL", "IFNULL") + "( " + AliasArray[0] + ".\"" + AliasArray[1].Replace(",", string.Empty) + "\", " + WordList[Counter + 1] + ") AS " + WordList[Counter + 3];
                                    flgFirstField = false;
                                }
                                else
                                {
                                    string[] AliasArray = WordList[Counter].Trim().Split('.');
                                    retValue += ", " + Tempword.Replace("ISNULL", "IFNULL") + "( " + AliasArray[0] + ".\"" + AliasArray[1].Replace(",", string.Empty) + "\", " + WordList[Counter + 1] + ") AS " + WordList[Counter + 3];
                                }
                                flgIsnullFunction = true;
                                funcCounter = 0;
                            }
                            else if (Tempword.ToUpper() == "COUNT")
                            {
                                if (flgFirstField)
                                {
                                    retValue += " " + "COUNT(*) AS " + WordList[Counter + 2] + " ";
                                    flgFirstField = false;
                                }
                                else
                                    retValue += ", " + "COUNT(*) AS " + WordList[Counter + 2] + " ";
                                flgCountFunction = true;
                                funcCounter = 0;
                            }
                            else if (Tempword.ToUpper() == "SUM")
                            {
                                if (!WordList[Counter].Contains('.'))
                                {
                                    if (flgFirstField)
                                    {
                                        retValue += " " + "SUM(" + WordList[Counter] + "\")" + " AS " + WordList[Counter + 2] + " ";
                                        flgFirstField = false;
                                    }
                                    else
                                        retValue += ", " + "SUM(" + WordList[Counter] + "\")" + " AS " + WordList[Counter + 2] + " ";
                                }
                                else if (flgFirstField)
                                {
                                    string[] AliasArray = WordList[Counter].Trim().Split('.');
                                    retValue += " " + "SUM(" + AliasArray[0] + "." + "\"" + AliasArray[1] + "\")" + " AS " + WordList[Counter + 2] + " ";
                                    flgFirstField = false;
                                }
                                else
                                {
                                    string[] AliasArray = WordList[Counter].Trim().Split('.');
                                    retValue += ", " + "SUM(" + AliasArray[0] + "." + "\"" + AliasArray[1] + "\")" + " AS " + WordList[Counter + 2] + " ";
                                }
                                flgSumFunction = true;
                                funcCounter = 0;
                            }
                            else if (Tempword.ToUpper() == "AND" || Tempword.ToUpper() == "OR" || Tempword.ToUpper() == "LIKE" || Tempword.ToUpper() == "ON" || Tempword.ToUpper() == "TOP" || Tempword.ToUpper() == "ASC" || Tempword.ToUpper() == "DESC" || Tempword.ToUpper() == "ORDER" || Tempword.ToUpper() == "GROUP" || Tempword.ToUpper() == "INNER" || Tempword.ToUpper() == "OUTER" || Tempword.ToUpper() == "LEFT" || Tempword.ToUpper() == "JOIN")
                            {
                                retValue += (Convert.ToString(" ") + Tempword) + " ";
                                if (Tempword.Trim().ToUpper() == "TOP")
                                    flgTopFound = true;
                            }
                        }
                        else if (!OperatorList.Contains(Tempword.ToUpper()))
                        {
                            // #Region "Between Select & From"
                            if (flgAfterSelect && !flgAfterFrom)
                            {
                                if (flgTopFound)
                                {
                                    retValue += " " + Tempword.Trim().ToUpper() + " ";
                                    flgTopFound = false;
                                    continue;
                                }
                                if (flgFirstField)
                                {
                                    if (!Tempword.Contains('.'))
                                    {
                                        retValue += "\"" + Tempword.Trim() + "\"";
                                        flgFirstField = false;
                                    }
                                    else
                                    {
                                        string[] AliasArray = Tempword.Trim().Split('.');
                                        retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                        flgFirstField = false;
                                    }
                                }
                                else if (!Tempword.Contains('.'))
                                    retValue += ", " + "\"" + Tempword.Trim() + "\"";
                                else
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += ", " + AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                }
                            }
                            else if (flgAfterFrom && !flgAfterWhere && !flgAfterGroupBy && !flgAfterOrderBy)
                            {
                                if (!flgFromRightEqual && flgFromRightAs)
                                {
                                    retValue += Tempword.Trim();
                                    flgFromRightAs = false;
                                }
                                else if (!flgFromRightAs && flgFromRightEqual)
                                {
                                    flgFromRightEqual = false;
                                    if (!Tempword.Contains('.'))
                                        retValue += "\"" + Tempword.Trim() + "\"";
                                    else
                                    {
                                        string[] AliasArray = Tempword.Trim().Split('.');
                                        retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                    }
                                }
                                else if (!Tempword.Contains('.'))
                                    retValue += "\"" + Tempword.Trim() + "\"";
                                else
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                }
                            }
                            else if (flgAfterWhere && !flgAfterGroupBy && !flgAfterOrderBy)
                            {
                                if (flgWhereRightSide)
                                {
                                    retValue += Tempword.Trim();
                                    flgWhereRightSide = false;
                                }
                                else if (!Tempword.Trim().Contains('.'))
                                    retValue += "\"" + Tempword.Trim() + "\"";
                                else
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                }
                            }
                            else if (flgAfterGroupBy)
                            {
                                if (!Tempword.Trim().Contains('.'))
                                {
                                    if (flgGroupByFirstField)
                                    {
                                        retValue += "\"" + Tempword.Trim() + "\" ";
                                        flgGroupByFirstField = false;
                                    }
                                    else
                                        retValue += " , \"" + Tempword.Trim() + "\"";
                                }
                                else if (flgGroupByFirstField)
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\" ";
                                    flgGroupByFirstField = false;
                                }
                                else
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += " , " + AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                }
                            }
                            else if (flgAfterOrderBy)
                            {
                                if (!Tempword.Trim().Contains('.'))
                                    retValue += "\"" + Tempword.Trim() + "\"";
                                else
                                {
                                    string[] AliasArray = Tempword.Trim().Split('.');
                                    retValue += AliasArray[0] + ".\"" + AliasArray[1] + "\"";
                                }
                            }
                        }
                        else
                        {
                            if (flgAfterFrom && flgAfterWhere)
                            {
                                if (OperatorList.Contains(Tempword.Trim().ToUpper()))
                                    flgWhereRightSide = true;
                            }
                            if (flgAfterFrom && !flgAfterWhere)
                            {
                                if (OperatorList.Contains(Tempword.Trim().ToUpper()))
                                {
                                    if (Tempword.Trim().ToUpper() == "=")
                                        flgFromRightEqual = true;
                                    else if (Tempword.Trim().ToUpper() == "AS")
                                        flgFromRightAs = true;
                                }
                            }
                            retValue += " " + Tempword.Trim() + " ";
                        }
                    }
                }

                if (WordList[0].ToUpper().Trim() == "INSERT")
                {
                    int Counter = 0;
                    foreach (var Word in WordList)
                    {
                        string Tempword = Word.Trim();

                        // #Region "Keyword Logic"
                        if (KeywordList.Contains(Tempword.ToUpper()))
                        {
                            if (Tempword.ToUpper() == "INSERT")
                                retValue = Tempword.ToUpper() + " ";
                            else if (Tempword.ToUpper() == "INTO")
                            {
                                retValue += " " + Tempword.ToUpper() + " " + Environment.NewLine;
                                flgAfterInsert = true;
                            }
                            else if (Tempword.ToUpper() == "VALUES")
                            {
                                retValue += ")" + Environment.NewLine + Tempword.ToUpper() + " " + Environment.NewLine + "(" + Environment.NewLine;
                                flgAfterValue = true;
                            }
                        }
                        else if (!OperatorList.Contains(Tempword.ToUpper()))
                        {
                            // #Region "Between Insert & Value"
                            if (flgAfterInsert && !flgAfterValue)
                            {
                                if (flgTableFound)
                                {
                                    retValue += (Convert.ToString("\t" + "\"") + Tempword) + "\" " + Environment.NewLine + "(" + Environment.NewLine;
                                    flgTableFound = false;
                                }
                                else if (flgFirstField)
                                {
                                    retValue += (Convert.ToString("\t" + "\"") + Tempword) + "\" " + Environment.NewLine;
                                    flgFirstField = false;
                                }
                                else
                                    retValue += (Convert.ToString("\t" + ", \"") + Tempword) + "\"" + Environment.NewLine;
                            }
                            else if (flgAfterInsert && flgAfterValue)
                            {
                                if (flgAfterValueFirstField)
                                {
                                    retValue += "\t" + ReplaceString(Tempword) + Environment.NewLine;
                                    flgAfterValueFirstField = false;
                                }
                                else
                                    retValue += "\t" + ", " + ReplaceString(Tempword) + Environment.NewLine;
                            }
                        }
                        else
                                                // #End Region

                                                // #Region "Operator Logic"
                                                if (Tempword == "=")
                            retValue += (Convert.ToString(" ") + Tempword) + " ";
                        else if (Tempword == "(")
                            retValue += (Convert.ToString(" ") + Tempword) + " ";
                        else if (Tempword == ")")
                            retValue += (Convert.ToString(" ") + Tempword) + " ";
                        // #End Region

                        Counter += 1;
                    }
                    retValue += ")";
                }

                if (WordList[0].ToUpper().Trim() == "UPDATE")
                {
                    foreach (var Word in WordList)
                    {
                        string TempWord = Word.Trim();
                        // #Region "Keyword Logic"

                        if (KeywordList.Contains(TempWord.ToUpper()))
                        {
                            if (TempWord.ToUpper() == "UPDATE")
                            {
                                retValue = TempWord.ToUpper() + Environment.NewLine;
                                flgAfterUpdate = true;
                            }
                            else if (TempWord.ToUpper() == "SET")
                            {
                                retValue += TempWord.ToUpper() + Environment.NewLine;
                                flgAfterSet = true;
                            }
                            else if (TempWord.ToUpper() == "WHERE")
                            {
                                retValue += TempWord.ToUpper() + Environment.NewLine;
                                flgAfterWhere = true;
                            }
                            else if (TempWord.ToUpper() == "AND" || TempWord.ToUpper() == "OR")
                                retValue += " " + TempWord.ToUpper() + " ";
                        }
                        else if (!OperatorList.Contains(TempWord.ToUpper()))
                        {
                            // #Region "Between Update & Set"
                            if (flgAfterUpdate && !flgAfterSet && !flgAfterWhere)
                            {
                                if (!TempWord.Contains('.'))
                                    retValue += "\t" + "\"" + TempWord.Trim() + "\"" + Environment.NewLine;
                                else
                                {
                                    string[] AliasArray = TempWord.Trim().Split('.');
                                    retValue += "\t" + AliasArray[0] + ".\"" + AliasArray[1] + "\"" + Environment.NewLine;
                                }
                            }
                            else if (flgAfterUpdate && flgAfterSet && !flgAfterWhere)
                            {
                                if (flgExpressionRightSide)
                                {
                                    if (TempWord.ToUpper() == "GETDATE")
                                        retValue += " GETDATE() ," + Environment.NewLine;
                                    else
                                        retValue += (Convert.ToString(" ") + TempWord) + " ," + Environment.NewLine;
                                    flgExpressionRightSide = false;
                                }
                                else
                                {
                                    retValue += (Convert.ToString("\t" + "\"") + TempWord) + "\" ";
                                    flgExpressionRightSide = true;
                                }
                            }
                            else if (flgAfterUpdate && flgAfterSet && flgAfterWhere)
                            {
                                if (flgExpressionRightSide)
                                {
                                    if (TempWord.ToUpper() == "GETDATE")
                                        retValue += " GETDATE() ," + Environment.NewLine;
                                    else
                                        retValue += (Convert.ToString(" ") + TempWord) + " " + Environment.NewLine;
                                    flgExpressionRightSide = false;
                                }
                                else
                                {
                                    retValue += (Convert.ToString("\t" + "\"") + TempWord) + "\" ";
                                    flgExpressionRightSide = true;
                                }
                            }
                        }
                        else
                                                // #End Region

                                                // #Region "Operator Logic"
                                                if (TempWord == "=")
                        {
                            retValue += (Convert.ToString(" ") + TempWord) + " ";
                            flgExpressionRightSide = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retValue = "Error In Parsing." + ex.Message;
            }
            return retValue;
        }

        public static string QueryParsing(string strQuery)
        {
            string retValue;
            try
            {
                string QueryAfterClearString, QueryAfterQuoteApplied, QueryAfterFuntionApplied;

                QueryAfterClearString = ClearString(strQuery);
                QueryAfterQuoteApplied = AppliedQuotes(QueryAfterClearString);
                QueryAfterFuntionApplied = AppliedFunctions(QueryAfterQuoteApplied);
                retValue = QueryAfterFuntionApplied;
            }
            catch (Exception ex)
            {
                retValue = "Error in parsing. " + ex.Message;
            }
            return retValue;
        }
    }

}
