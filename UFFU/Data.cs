using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace UFFU
{
    public partial class mFm
    {

        #region Variables

        public static string strInnerMessage = string.Empty;
        public static string strOuterMessage = string.Empty;
        public static string strLastQuery = string.Empty;

        public enum mfmHashTypes { mfm160 = 1, mfm256 = 2, mfm512 = 3 }
        public enum FormatType { Currency = 1, Number = 2 }
        public enum PrecisionValue { Zero = 1, One = 2, Two = 3, Three = 4, Four = 5, Five = 6, Six = 7 }
        public enum GroupType { Local = 1, International = 2 }


        #endregion

        #region Functions

        private static bool ExecuteQuerySQL(string strQuery, string conStr)
        {
            bool retValue = false;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                com = new SqlCommand(strQuery, con);
                Int32 RowSet = -1;
                RowSet = com.ExecuteNonQuery();
                if (RowSet >= 0)
                    retValue = true;
                else if (RowSet < 0)
                    retValue = false;
            }
            catch (Exception ex)
            {
                strInnerMessage = ex.Message;
                retValue = false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return retValue;
        }

        private static DataTable ExecuteQueryDtSQL(string strQuery, string strCon)
        {
            DataTable retdt = new DataTable();
            SqlConnection Con = new SqlConnection(strCon);
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                // Dim Com As SqlCommand = New SqlCommand(strQuery, Con)
                SqlDataAdapter ComAdapter = new SqlDataAdapter(strQuery, Con);
                ComAdapter.Fill(retdt);
            }
            catch (Exception ex)
            {
                strInnerMessage = ex.Message;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return retdt;
        }

        private static string ExecuteQueryScalerSQL(string strQuery, string strCon)
        {
            string retValue = string.Empty;
            SqlConnection Con = new SqlConnection(strCon);
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                SqlCommand Com = new SqlCommand(strQuery, Con);
                retValue = Com.ExecuteScalar().ToString();
                if (string.IsNullOrEmpty(retValue))
                    retValue = "0";
            }
            catch (Exception ex)
            {
                retValue = string.Empty;
                strInnerMessage = ex.Message;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return retValue;
        }

        private static bool ExecuteQueryHANA(string strQuery, string conStr)
        {
            bool retValue = false;
            OdbcConnection con = new OdbcConnection(conStr);
            OdbcCommand com;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                com = new OdbcCommand(strQuery, con);
                Int32 RowSet = -1;
                RowSet = com.ExecuteNonQuery();
                if (RowSet > 0)
                    retValue = true;
                else if (RowSet <= 0)
                    retValue = false;
            }
            catch (Exception ex)
            {
                strInnerMessage = ex.Message;
                retValue = false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return retValue;
        }

        private static DataTable ExecuteQueryDtHANA(string strQuery, string conStr)
        {
            DataTable retdt = new DataTable();
            OdbcConnection Con = new OdbcConnection(conStr);
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                OdbcDataAdapter ComAdapter = new OdbcDataAdapter(strQuery, Con);
                ComAdapter.Fill(retdt);
            }
            catch (Exception ex)
            {
                strInnerMessage = ex.Message;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return retdt;
        }

        private static string ExecuteQueryScalerHANA(string strQuery, string conStr)
        {
            string retValue = string.Empty;
            OdbcConnection Con = new OdbcConnection(conStr);
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                OdbcCommand Com = new OdbcCommand(strQuery, Con);

                retValue = Com.ExecuteScalar().ToString();
                if (string.IsNullOrEmpty(retValue))
                    retValue = "0";
            }
            catch (Exception ex)
            {
                strInnerMessage = ex.Message;
                retValue = string.Empty;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return retValue;
        }

        #endregion

        #region Share Functions

        public static bool ExecuteQuery(string prmQuery, string prmConString, bool prmHanaToggle)
        {
            bool result = false;
            try
            {
                if (prmHanaToggle)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                strOuterMessage = ex.Message;
                result = false;
            }
            return result;
        }

        public static string ExecuteQueryScaler(string strQuery, string strCon, bool HanaToggle = false)
        {
            string retValue = string.Empty;
            try
            {
                if (HanaToggle)
                {
                    strLastQuery = "";//QueryParsing(strQuery);
                    retValue = ExecuteQueryScalerHANA(strLastQuery, strCon);
                }
                else
                {
                    strLastQuery = strQuery;
                    retValue = ExecuteQueryScalerSQL(strQuery, strCon);
                }
            }
            catch (Exception ex)
            {
                strOuterMessage = ex.Message;
                retValue = "0";
            }
            return retValue;
        }

        public static DataTable ExecuteQueryDt(string strQuery, string strCon, bool HanaToggle = false)
        {
            DataTable retValue = new DataTable();
            try
            {
                if (HanaToggle)
                {
                    strLastQuery = "";// QueryParsing(strQuery);
                    retValue = ExecuteQueryDtHANA(strLastQuery, strCon);
                }
                else
                {
                    strLastQuery = strQuery;
                    retValue = ExecuteQueryDtSQL(strQuery, strCon);
                }
            }
            catch (Exception ex)
            {
                strOuterMessage = ex.Message;
            }
            return retValue;
        }

        public static string mfmEncryption(string pInputString)
        {
            string strReturnValue = "";
            try
            {
                byte[] ByteArrayInput = Encoding.Unicode.GetBytes(pInputString);
                RijndaelManaged myCipher = new RijndaelManaged();
                myCipher.BlockSize = 256;
                myCipher.KeySize = 256;
                myCipher.Padding = PaddingMode.ISO10126;
                myCipher.Mode = CipherMode.CBC;
                // myCipher.Key = Encoding.Unicode.GetBytes("Muhammad Faisal Maqsood")
                // myCipher.IV = Encoding.Unicode.GetBytes("Muhammad Maqsood Alam")
                SHA512Managed HashFromPhrase = new SHA512Managed();
                byte[] BytesFromPhrase = Encoding.Unicode.GetBytes("Muhammad Faisal Maqsood");
                byte[] BytesFromHashPhrase = HashFromPhrase.ComputeHash(BytesFromPhrase);
                byte[] ByteKey = new byte[32];
                byte[] ByteIV = new byte[32];
                for (int i = 0; i <= 31; i++)
                {
                    ByteKey[i] = BytesFromHashPhrase[i];
                    ByteIV[i] = BytesFromHashPhrase[i + 32];
                }
                myCipher.Key = ByteKey;
                myCipher.IV = ByteIV;
                ICryptoTransform myCryptoTransform = myCipher.CreateEncryptor();
                strReturnValue = Convert.ToBase64String(myCryptoTransform.TransformFinalBlock(ByteArrayInput, 0, ByteArrayInput.Length));
            }
            // strReturnValue = strReturnValue.Replace("-", "")
            catch (Exception ex)
            {
                strReturnValue = ex.Message;
            }
            return strReturnValue;
        }

        public static string mfmDecryption(string pInputString)
        {
            string strReturnValue = "";
            try
            {
                byte[] ByteArrayInput = Convert.FromBase64String(pInputString);
                RijndaelManaged myCipher = new RijndaelManaged();
                myCipher.KeySize = 256;
                myCipher.BlockSize = 256;
                myCipher.Padding = PaddingMode.ISO10126;
                myCipher.Mode = CipherMode.CBC;
                // myCipher.Key = Encoding.Unicode.GetBytes("Muhammad Faisal Maqsood")
                // myCipher.IV = Encoding.Unicode.GetBytes("Muhammad Maqsood Alam")
                SHA512Managed HashFromPhrase = new SHA512Managed();
                byte[] BytesFromPhrase = Encoding.Unicode.GetBytes("Muhammad Faisal Maqsood");
                byte[] BytesFromHashPhrase = HashFromPhrase.ComputeHash(BytesFromPhrase);
                byte[] ByteKey = new byte[32];
                byte[] ByteIV = new byte[32];
                for (int i = 0; i <= 31; i++)
                {
                    ByteKey[i] = BytesFromHashPhrase[i];
                    ByteIV[i] = BytesFromHashPhrase[i + 32];
                }
                myCipher.Key = ByteKey;
                myCipher.IV = ByteIV;
                ICryptoTransform myCryptoTransform = myCipher.CreateDecryptor();
                strReturnValue = Encoding.Unicode.GetString(myCryptoTransform.TransformFinalBlock(ByteArrayInput, 0, ByteArrayInput.Length));
            }
            catch (Exception ex)
            {
                strReturnValue = ex.Message;
            }
            return strReturnValue;
        }

        public static string mfmGetHash(string pInputString, mfmHashTypes pHashType)
        {
            string strReturnValue = "";
            try
            {
                if (pHashType == mfmHashTypes.mfm160)
                {
                    SHA1Managed oAlgorithim = new SHA1Managed();
                    byte[] oBinaryForm = oAlgorithim.ComputeHash(Encoding.Unicode.GetBytes(pInputString));
                    strReturnValue = BitConverter.ToString(oBinaryForm).Replace("-", "");
                }
                if (pHashType == mfmHashTypes.mfm256)
                {
                    SHA256Managed oAlgorithim = new SHA256Managed();
                    byte[] oBinaryForm = oAlgorithim.ComputeHash(Encoding.Unicode.GetBytes(pInputString));
                    strReturnValue = BitConverter.ToString(oBinaryForm).Replace("-", "");
                }
                if (pHashType == mfmHashTypes.mfm512)
                {
                    SHA512Managed oAlgorithim = new SHA512Managed();
                    byte[] oBinaryForm = oAlgorithim.ComputeHash(Encoding.Unicode.GetBytes(pInputString));
                    strReturnValue = BitConverter.ToString(oBinaryForm).Replace("-", "");
                }
            }
            catch (Exception ex)
            {
                strReturnValue = "Exception";
            }
            return strReturnValue;
        }

        public static PCDataInfo mfmGetPCCode()
        {
            PCDataInfo oPCData = new PCDataInfo();
            try
            {
                string strProcessorName, strProcessorManufacturer, strHardDiskName, strHardDiskModel, strHardDiskSerial, strOSBuild, strOSName, strOSDate, strCardName, strNetworkdAddress;
                DateTime dtOSDate;

                var oProcessor = new ManagementObjectSearcher("Select * From Win32_Processor").Get().Cast<ManagementObject>().FirstOrDefault();
                strProcessorName = Convert.ToString(oProcessor.GetPropertyValue("Name"));
                strProcessorManufacturer = Convert.ToString(oProcessor.GetPropertyValue("Manufacturer"));


                var oHardDisk = new ManagementObjectSearcher("Select * From Win32_DiskDrive").Get().Cast<ManagementObject>().FirstOrDefault();
                strHardDiskName = Convert.ToString(oHardDisk.GetPropertyValue("Manufacturer"));
                strHardDiskModel = Convert.ToString(oHardDisk.GetPropertyValue("Model"));
                strHardDiskSerial = Convert.ToString(oHardDisk.GetPropertyValue("SerialNumber"));

                var oOS = new ManagementObjectSearcher("Select * From Win32_OperatingSystem").Get().Cast<ManagementObject>().FirstOrDefault();
                strOSBuild = Convert.ToString(oOS.GetPropertyValue("BuildNumber"));
                strOSName = Convert.ToString(oOS.GetPropertyValue("Caption"));
                strOSDate = Convert.ToString(oOS.GetPropertyValue("InstallDate"));
                dtOSDate = new DateTime(Convert.ToInt32(strOSDate.Substring(0, 4)), Convert.ToInt32(strOSDate.Substring(4, 2)), Convert.ToInt32(strOSDate.Substring(6, 2)));

                var oNetworkCard = new ManagementObjectSearcher("Select * From Win32_NetworkAdapter Where AdapterType='Ethernet 802.3'").Get().OfType<ManagementObject>().FirstOrDefault();
                strCardName = Convert.ToString(oNetworkCard.GetPropertyValue("Name"));
                var oNetworkAddress = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Name='" + strCardName + "'").Get().OfType<ManagementObject>().FirstOrDefault();
                strNetworkdAddress = Convert.ToString(oNetworkAddress.GetPropertyValue("MACAddress"));

                oPCData.PCName = Environment.MachineName;
                oPCData.ProcessorName = strProcessorName;
                oPCData.ProcessorManufacturer = strProcessorManufacturer;
                oPCData.HDName = strHardDiskName;
                oPCData.HDModel = strHardDiskModel;
                oPCData.HDSerial = strHardDiskSerial;
                oPCData.OSName = strOSName;
                //oPCData.OSBuild = strOSBuild;
                oPCData.OSDate = dtOSDate;
                oPCData.MacAddress = strNetworkdAddress;
            }
            catch (Exception ex)
            {
                oPCData.PCName = "Exception";
            }
            return oPCData;
        }

        public static string mfmGetSystemID()
        {
            string retString = string.Empty;
            try
            {
                PCDataInfo oPCInfo = new PCDataInfo();
                string OpenString, EncryptedString;
                oPCInfo = mfmGetPCCode();
                OpenString = $"{oPCInfo.ProcessorName}@{oPCInfo.HDSerial.Trim()}@{oPCInfo.MacAddress}@{oPCInfo.OSName}";
                EncryptedString = mfmGetHash(OpenString, mfmHashTypes.mfm160);
                retString = EncryptedString;
            }
            catch (Exception ex)
            {
                retString = "Unable to generate System Identification.";
            }
            return retString;
        }

        public static string mfmVerifyLicense(string pHash)
        {
            string flgReturn = "Verification Failed";
            try
            {
                string openString = mfmDecryption(pHash);
                string localHash = mfmGetSystemID();
                char charValue = '@';
                string[] openArray = openString.Split(charValue);
                if (openArray.Count() == 3)
                {
                    string pSID = openArray[0];
                    DateTime pFromDate = new DateTime(Convert.ToInt32(openArray[1].Substring(0, 4)), Convert.ToInt32(openArray[1].Substring(4, 2)), Convert.ToInt32(openArray[1].Substring(6, 2)));
                    DateTime pToDate = new DateTime(Convert.ToInt32(openArray[2].Substring(0, 4)), Convert.ToInt32(openArray[2].Substring(4, 2)), Convert.ToInt32(openArray[2].Substring(6, 2)));
                    if (localHash == pSID)
                    {
                        if (pFromDate <= DateTime.Now & pToDate >= DateTime.Now)
                            flgReturn = "Verification Succeded";
                        else
                            flgReturn = "License Expired";
                    }
                    else
                        flgReturn = "Invalid License: System not valid.";
                }
                else
                    flgReturn = "Invalid License";
            }
            catch (Exception ex)
            {
                flgReturn = "Verification Failed";
            }
            return flgReturn;
        }

        public static string mfmGenerateLicense(string pSID, DateTime pFromDate, DateTime pToDate)
        {
            string retLicense;
            try
            {
                string openValue = pSID + "@" + pFromDate.ToString("yyyyMMdd") + "@" + pToDate.ToString("yyyyMMdd");
                retLicense = mfmEncryption(openValue);
            }
            catch (Exception ex)
            {
                retLicense = "No License";
            }
            return retLicense;
        }


        #endregion

    }

    public class PCDataInfo
    {
        public string PCName { get; set; } = string.Empty;
        public string ProcessorName { get; set; } = string.Empty;
        public string ProcessorManufacturer { get; set; } = string.Empty;
        public string HDName { get; set; } = string.Empty;
        public string HDModel { get; set; } = string.Empty;
        public string HDSerial { get; set; } = string.Empty;
        public string OSName { get; set; } = string.Empty;
        public DateTime OSDate { get; set; }
        public string MacAddress { get; set; } = string.Empty;

    }
}

