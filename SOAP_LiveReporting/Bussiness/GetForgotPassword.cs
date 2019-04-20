using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetForgotPassword : SqlHelper
    {
        public Bussiness.AuthResponse ForgotPassword(DataClass.DataForgotPassword obj)
        {
            string[,] param = { { "EmailId", obj.EmailId.ToString() } };
            MEMBERS.SQLReturnValue M = ExecuteProcWithMessageValue("Get_ForgetPassword_apps", param, true);
            if (M.ValueFromSQL == 1)
            {
                #region SendForgetwd
                string MailToUser = @"<table width='600' border='0' align='center' cellpadding='10' cellspacing='0' style='border: 4px solid #01A0E2; font-family: Arial, Helvetica, sans-serif; font-size: 13px;'>
                    <tr>
                        <td height='223' colspan='2' align='center' style='background-image: url(http://apexmedconnect.com/images/belt_bg.jpg); background-repeat: repeat-x; background-position: center;'>
                            <img src='http://livereporting.in/WaterMarkImg/logo-V13.png'  title='LiveReporting.in' alt='livereporting' />
                        </td>
                    </tr>
                    <tr>
                        <td width='196'>
                            <h2 align='center'>
                                Forget Password</h2>
                            <p align='center'>
                                your password is : " + M.MessageFromSQL + @"
                            </p>
                        </td>
                    </tr>
                </table>";
                #endregion
                SendMail SM = new SendMail();
                SM.SendMailForgetIn(obj.EmailId, MailToUser);
                return new Bussiness.AuthResponse(1, "Please Confirm that you would link to reset password for the account shown below.we will send your Mail id with password.");
            }
            else
            {
                return new Bussiness.AuthResponse(0, M.MessageFromSQL);
            }
        }
    }
}