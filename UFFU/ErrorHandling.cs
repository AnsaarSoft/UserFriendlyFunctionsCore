using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;

namespace UFFU
{
    public partial class mFm
    {
        #region Variable

        private bool flgLogStatus = true; //make logging on/off appplication wise.
        private bool flgEncryption = true; //encrypted message in file or not.
        private string FullPath = "C:\\mfmlogging.log";
        private string strSubject = string.Empty;
        private string strBody = string.Empty;

        #endregion

        #region Functions

        public mFm(string prmFilePath, bool prmLogToggle, bool prmEncrypted)
        {
            if (string.IsNullOrEmpty(prmFilePath))
            {
                FullPath = "C:\\mfmlogging.log";
            }
            else
            {
                FullPath = prmFilePath;
            }
            flgLogStatus = prmLogToggle;
            flgEncryption = prmEncrypted;
            if (DateTime.Now.Year > 2025)
            {
                throw new Exception("Service has been expired. Please contact concern person.");
            }
        }

        public mFm(string prmFilePath, string prmFileName, bool prmLogToggle, bool prmEncrypted)
        {
            string FilePath = string.Empty;
            string FileName = string.Empty;
            if (string.IsNullOrEmpty(prmFilePath))
            {
                FilePath = "C:\\";
            }
            else
            {
                FilePath = prmFilePath;
            }
            if (string.IsNullOrEmpty(prmFileName))
            {
                FileName = "mfmLogging.log";
            }
            else
            {
                FileName = prmFileName;
            }
            FileName = Path.Combine(FilePath, FileName);
            flgLogStatus = prmLogToggle;
            flgEncryption = prmEncrypted;
            if (DateTime.Now.Year > 2025)
            {
                throw new Exception("Service has been expired. Please contact concern person.");
            }
        }

        private bool HandleFile(string pstring)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    StreamWriter oWriter = new StreamWriter(FullPath, true);
                    oWriter.WriteLine(pstring);
                    oWriter.Close();
                }
                else
                {
                    StreamWriter oWriter = new StreamWriter(FullPath);
                    oWriter.WriteLine(pstring);
                    oWriter.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void SentMail()
        {
            bool retValue = false;

            try
            {
                MailAddress FromAddress = new MailAddress("mfmemailerrorsender@gmail.com", "MFM Error Msg");
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential EmailCredentials = new NetworkCredential(FromAddress.Address, "mfmbahutmushkil");
                MailMessage Message = new MailMessage();

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = EmailCredentials;
                smtpClient.Timeout = (60 * 5 * 1000);

                Message.From = FromAddress;
                Message.Subject = strSubject;
                Message.IsBodyHtml = false;
                Message.Body = strBody;
                Message.To.Add("mfmjnj@gmail.com");

                smtpClient.Send(Message);
                retValue = true;
            }
            catch (Exception ex)
            {
                retValue = false;
            }
            //return retValue;
        }

        private string ExceptionMessage(Exception pEx)
        {
            string strReturn = "";
            try
            {
                int intErrorAtLine = 0;
                string strMethodName = "";
                string strBase = "";
                StackTrace sTrace = new StackTrace(pEx, true);
                strMethodName = sTrace.GetFrame(sTrace.FrameCount - 1).GetMethod().Name;
                intErrorAtLine = sTrace.GetFrame(sTrace.FrameCount - 1).GetFileLineNumber();
                DateTime dtErrorDateTime = DateTime.Now;
                strReturn = " " + dtErrorDateTime.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , " + strMethodName + " , " + intErrorAtLine.ToString() + " , " + pEx.Message + " , " + Convert.ToString(pEx.InnerException) + " , " + pEx.StackTrace.ToString();
            }
            catch (Exception ex)
            {
                strReturn = " " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , ErrorEx , 0 " + "Internal Exception " + ex.Message + " , " + Convert.ToString(ex.InnerException) + " , " + ex.StackTrace.ToString();
                strReturn += Environment.NewLine + " " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , ErrorEx , 0 " + "Internal Exception " + ex.Message + " , " + Convert.ToString(ex.InnerException) + " , " + ex.StackTrace.ToString();
            }
            return strReturn;
        }

        private string ExceptionMessageMail(Exception pEx)
        {
            string strReturn = "";
            try
            {
                int intErrorAtLine = 0;
                string strMethodName = "";
                DateTime dtErrorDateTime = DateTime.Now;
                intErrorAtLine = new StackTrace(pEx, true).GetFrame(0).GetFileLineNumber();
                strMethodName = pEx.TargetSite.ToString();
                strReturn = "Time : " + dtErrorDateTime.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " : Calling Method : " + strMethodName + " At Line Number : " + intErrorAtLine.ToString() + " Exception Msg : " + pEx.Message;
            }
            catch (Exception ex)
            {
                strReturn = "Exception In Exception : @Time : " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " ::: " + ex.Message;
            }
            return strReturn;
        }

        private string ExceptionMsgEncrypted(Exception pEx)
        {
            string strReturn = "";
            try
            {
                int intErrorAtLine = 0;
                string strMethodName = "";
                string strBase = "";
                StackTrace sTrace = new StackTrace(pEx, true);
                strMethodName = sTrace.GetFrame(sTrace.FrameCount - 1).GetMethod().Name;
                intErrorAtLine = sTrace.GetFrame(sTrace.FrameCount - 1).GetFileLineNumber();
                DateTime dtErrorDateTime = DateTime.Now;
                strReturn = " " + dtErrorDateTime.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , " + strMethodName + " , " + intErrorAtLine.ToString() + " , " + pEx.Message + " , " + Convert.ToString(pEx.InnerException);
                strReturn = mfmEncryption(strReturn);
            }
            catch (Exception ex)
            {
                strReturn = " " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , ErrorEx , 0 " + "Internal Exception " + ex.Message + " , " + Convert.ToString(ex.InnerException);
                strReturn = mfmEncryption(strReturn);
            }
            return strReturn;
        }

        private string LogMsgEncrypted(string strMessage)
        {
            string strReturn = "";
            try
            {
                DateTime dtLogTime = DateTime.Now;
                strReturn = " " + dtLogTime.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , LogEntry  , 0 ,  " + strMessage;
                strReturn = mfmEncryption(strReturn);
            }
            catch (Exception ex)
            {
                strReturn = " " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , ErrorEx , 0 , " + "Exception Occur In Event";
                strReturn = mfmEncryption(strReturn);
            }
            return strReturn;
        }

        private string LogMsg(string strMessage)
        {
            string strReturn = "";
            try
            {
                DateTime dtLogTime = DateTime.Now;
                strReturn = " " + dtLogTime.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , LogEntry  , 0 ,  " + strMessage + " , No Message";
            }
            catch (Exception ex)
            {
                strReturn = " " + DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt") + " , LogErrorEx , 0 , " + "Exception Occur In Event : " + ex.Message + " , " + Convert.ToString(ex.InnerException);
            }
            return strReturn;
        }


        #endregion

        #region Exposed Functions


        public bool LogException(string AppName, Exception prmEx)
        {
            if (flgLogStatus == false)
                return true;
            try
            {
                string strExceptionMessage = "";
                if (flgEncryption)
                    strExceptionMessage = AppName + " , " + ExceptionMsgEncrypted(prmEx);
                else
                    strExceptionMessage = AppName + " , " + ExceptionMessage(prmEx);
                HandleFile(strExceptionMessage);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool LogEntry(string AppName, string strMsg)
        {
            if (flgLogStatus == false)
                return true;
            try
            {
                string strLogCompleteMsg = "";
                if (flgEncryption)
                    strLogCompleteMsg = AppName + " , " + LogMsgEncrypted(strMsg);
                else
                    strLogCompleteMsg = AppName + " , " + strMsg;
                HandleFile(strLogCompleteMsg);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool LogExceptionByEmail(string prmAppName, Exception prmException)
        {
            if (flgLogStatus == false)
                return true;
            try
            {
                this.strSubject = prmAppName;
                this.strBody = ExceptionMessageMail(prmException);

                Thread oEmail = new Thread(SentMail);
                oEmail.Start();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool LogEntryByEmail(string prmAppName, string prmMessage)
        {
            if (flgLogStatus == false)
                return true;
            try
            {
                this.strSubject = prmAppName;
                // Me.strBody = ExceptionMessageMail(prmMessage)
                this.strBody = prmMessage;

                Thread oEmail = new Thread(SentMail);
                oEmail.Start();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        #endregion
    }
}
