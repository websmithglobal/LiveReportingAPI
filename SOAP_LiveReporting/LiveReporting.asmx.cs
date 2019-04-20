using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using SOAP_LiveReporting;
using _SqlHelper;
using System.Web.Script.Serialization;
using SOAP_LiveReporting.Bussiness;
using SOAP_LiveReporting.DataClass;
using System.Net;
using System.IO;
namespace SOAP_LiveReporting
{
    [WebService(Namespace = "http://livereporting.in")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1, Name = "LiveReporting")]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class LiveReporting : System.Web.Services.WebService
    {

        #region Private Members
        public DataClass.UserAuthntication SecureAuthentication;
        protected DataClass.UserLogin chkLogin;
        public Bussiness.SaveUploadVideoTaxdata UploadContext;
        public AddcontactUsLR Addcon;
        #endregion
        protected string Serialize(object Object)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(Object);
        }

        #region UserLoginAuth
        [WebMethod(Description = "Check authenticate parameters.")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string CheckAuthentication()
        {
            if (string.IsNullOrEmpty(SecureAuthentication.UserName) || string.IsNullOrEmpty(SecureAuthentication.Password))
            {
                return "{\"Authentication\" : " + Serialize(new AuthResponse(0, "Authentication information not blank")) + "}";
            }
            if (SecureAuthentication.UserName.Length > 50 || SecureAuthentication.Password.Length > 50)
            {
                return "{\"Authentication\" : " + Serialize(new AuthResponse(0, "invalid field length")) + "}";
            }
            if (SecureAuthentication != null)
            {
                MEMBERS.SQLReturnValue M1;
                M1 = CheckLoginReturnUserId(SecureAuthentication);
                if (M1.ValueFromSQL > 0)
                {
                    return "{\"Authentication\" : " + Serialize(new AuthResponse(int.Parse(M1.MessageFromSQL), "Success")) + "}";
                }
                else
                    return "{\"Authentication\" : " + Serialize(new AuthResponse(0, M1.ValueFromSQL == -1 ? "Authentication is NULL" : "Invalid Authentication")) + "}";
            }
            return "{\"Authentication\" : " + Serialize(new AuthResponse(0, "Authentication information not provided.")) + "}";
        }
        public MEMBERS.SQLReturnValue CheckLoginReturnUserId(UserAuthntication Auth)
        {
            chkLogin = new DataClass.UserLogin();
            MEMBERS.SQLReturnValue M;
            M = chkLogin.CheckUserLogin(Auth);
            return M;
        }

        #endregion

        #region GetClient
        [WebMethod(Description = "Retrive Client Information..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProfile(int UserID)
        {
            GetClientData proc = new GetClientData();
            return "{\"Profile\" : " + Serialize(proc.GetUserInformation(UserID)) + "}";
        }
        #endregion

        #region State
        [WebMethod(Description = "Retrive State List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetStateList()
        {
            if (SecureAuthentication != null)
            {

                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetState proc = new GetState();
                    return "{\"StateList\" : " + Serialize(proc.GetSTateList()) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region City
        [WebMethod(Description = "Retrive City List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCityList(int StateIDF)
        {

            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetCity proc = new GetCity();
                    return "{\"CityList\" : " + Serialize(proc.GetCityList(StateIDF)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region AreaOfCity
        [WebMethod(Description = "Retrive AreaOfCity List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAreaList(int CityIDF)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetAreaOfCity proc = new GetAreaOfCity();
                    return "{\"CityList\" : " + Serialize(proc.GetAreaList(CityIDF)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region MainCategory
        [WebMethod(Description = "Retrive MainCategories List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCategoriesList()
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetCategories proc = new GetCategories();
                    return "{\"CategoriesList\" : " + Serialize(proc.GetCategoriesList()) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region SubCategory
        [WebMethod(Description = "Retrive SubCategory List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetSubCategoriesList(int IncidentCategoryIDF)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetSubCategories proc = new GetSubCategories();
                    return "{\"SubCategoryList\" : " + Serialize(proc.GetSubCategoriesList(IncidentCategoryIDF)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Know your law
        [WebMethod(Description = "Retrive KnowYourLaw..!")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetKnowYourLaw()
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetKnowYourLaw proc = new GetKnowYourLaw();
                    return "{\"KnowYourLaw\" : " + Serialize(proc.GetKnowYourLawList()) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region LikeDisLike
        [WebMethod(Description = "add Like Dislike")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddVideoLikeDisLike(DataClass.Like_DisLikeData obj)
        {
            if (string.IsNullOrEmpty(obj.VideoIDF.ToString()) || string.IsNullOrEmpty(obj.Status.ToString()))
            {
                return Serialize(new AuthResponse(0, "Parameters Is NULL")) + "}";
            }
            if (SecureAuthentication != null)
            {
                try
                {
                    int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                    if (Output > 0)
                    {
                        Bussiness.AuthResponse o = new AuthResponse();
                        return Serialize(new Bussiness.GetLikeDisLike().Add_Like(obj)) + "}";
                    }
                    else
                        return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
                }
                catch (Exception ex)
                {
                    return Serialize(new AuthResponse(0, "internal server error"));
                }

            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region UserVideoComments
        [WebMethod(Description = "Retrive UserVideo Comments List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUserVideoComments(int VikdeoIDF)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetVideoComments proc = new GetVideoComments();
                    return "{\"UserVideoComments\" : " + Serialize(proc.GetUserVideoComments(VikdeoIDF)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Add ContactUs

        [WebMethod(Description = "Add Contact Us.")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UserAddContact(AddcontactUsLR AdLR)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    UserContact addpro = new UserContact();
                    int OutSave = UserContact.Add_ConatctUS(AdLR).ValueFromSQL;
                    if (OutSave == 1)
                    {
                        return "{\"ContactUs\" : " + Serialize(new AuthResponse(1, "Success")) + "}";
                    }
                    else
                    {
                        return "{\"ContactUs\" : " + Serialize(new AuthResponse(0, "Failed..!")) + "}";
                    }

                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region GetBanner
        [WebMethod(Description = "Retrive GetBanner List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetBannerList()
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetBannerLR proc = new GetBannerLR();
                    return "{\"BannerList\" : " + Serialize(proc.GetYourBanner()) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion


        #region Get Video
        [WebMethod(Description = "Retrive Video List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetALLVideo_ByCategory(int IncidentCategoryIDF, int UserID)
        {
            if (SecureAuthentication != null)
            {
                if (string.IsNullOrEmpty(IncidentCategoryIDF.ToString()))
                {
                    return "{\"VideoInformation\" : " + Serialize("IncidentCategoryIDF Is NULL") + "}";
                }
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetVideoInfomation proc = new GetVideoInfomation();
                    return "{\"VideoInformation\" : " + Serialize(proc.Get_Video_InfoLR(IncidentCategoryIDF, UserID)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Upload Videos
        [WebMethod(Description = "Upload Video.")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Upload_Video(UploadVIdeo UploadLR)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    UploadVideo_Insert addpro = new UploadVideo_Insert();
                    MEMBERS.SQLReturnValue M;
                    if (UploadLR.video_path != null)
                    {
                        M = UploadVideo_Insert.Add_Upload_Videos(UploadLR);
                        if (M.ValueFromSQL > 0)
                        {
                            return "{\"Authentication\" : " + Serialize(new AuthResponse(1, "Success.!")) + "}";
                        }
                    }
                    else
                    {
                        return "{\"Authentication\" : " + Serialize(new AuthResponse(0, "Upload Video Path Invalid plz try again.!!")) + "}";
                    }
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }

        #endregion

        #region SignUp
        [WebMethod(Description = "Users Singup")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Users_SignUp(DataSingup obj)
        {

            MEMBERS.SQLReturnValue M;
            DataSingup Singobj = new DataSingup();
            if (string.IsNullOrEmpty(obj.Mobile) || string.IsNullOrEmpty(obj.FirstName) || string.IsNullOrEmpty(obj.Password) || string.IsNullOrEmpty(obj.LastName) || string.IsNullOrEmpty(obj.EmailId))
            {
                return "{\"Singup\" : " + Serialize(new AuthResponse(0, "Paramters is NULL")) + "}";
            }
            M = Singup.Insert_Update_Client(obj);
            if (M.ValueFromSQL > 0)
            {
                return "{\"Singup\" : " + Serialize(new AuthResponse(M.ValueFromSQL, M.MessageFromSQL)) + "}";
            }
            else
            {
                return "{\"Singup\" : " + Serialize(new AuthResponse(0, M.MessageFromSQL)) + "}";
            }

        }
        #endregion

        #region SocialUserData
        [WebMethod(Description = "Social Media User Singup")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SocialMedia_UserSingup(DataSocialMedia obj)
        {
            MEMBERS.SQLReturnValue M;
            M = SocialMedia.AUTHFacebookLogin(obj);
            if (M.ValueFromSQL > 0)
            {
                return "{\"SocialMedia\" : " + Serialize(new AuthResponse(M.ValueFromSQL, M.MessageFromSQL)) + "}";
            }
            else
            {
                return "{\"SocialMedia\" : " + Serialize(new AuthResponse(0, "Social Media login Failed Please Try Again emailid not valid.")) + "}";
            }

        }
        #endregion

        #region Video Comments
        [WebMethod(Description = "Users Video Comments")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string LRUserVideoComments(DataVideoComments obj)
        {
            MEMBERS.SQLReturnValue M;
            if (string.IsNullOrEmpty(obj.Msg))
            {
                return "{\"Comments\" : " + Serialize(new AuthResponse(0, "Msg is NULL")) + "}";
            }
            M = GetSaveVideoComments.Insert_Update_Comments(obj);
            if (M.ValueFromSQL > 0)
            {
                return "{\"Comments\" : " + Serialize(new AuthResponse(1, "Success.!")) + "}";
            }
            else
            {
                return "{\"Comments\" : " + Serialize(new AuthResponse(0, "Failed.!")) + "}";
            }
        }
        #endregion

        #region ForgotPassword
        [WebMethod(Description = "Forgot Password")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ForgotPassword(DataForgotPassword obj)
        {
            if (SecureAuthentication != null)
            {
                try
                {
                    int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                    if (Output > 0)
                    {
                        Bussiness.AuthResponse o = new AuthResponse();
                        return Serialize(new Bussiness.GetForgotPassword().ForgotPassword(obj)) + "}";
                    }
                    else
                        return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
                }
                catch (Exception ex)
                {
                    return Serialize(new AuthResponse(0, ex.Message));
                }

            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        //#region UploadPicture
        //[WebMethod(Description = "Upload Videos & Story")]
        //[SoapDocumentMethod(Binding = "LiveReporting")]
        //[SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string UploadPicture(DataClass.UploadVIdeo obj)
        //{
        //    if (SecureAuthentication != null)
        //    {
        //        int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
        //        if (Output > 0)
        //        {
        //            MEMBERS.SQLReturnValue M;
        //            M = GetUploadVideo.Insert_Update_UploadVideo(obj);
        //            if (M.ValueFromSQL > 0)
        //            {
        //                for (int i = 0; i < obj.SubImages.Count; i++)
        //                {
        //                    obj.UploadedVideoIDP = M.ValueFromSQL;
        //                    obj.video_path = obj.SubImages[i].ToString();
        //                    GetUploadVideoPath.Save_Video_Path(obj);
        //                }
        //                return "{\"UploadPicture\" : " + Serialize(new AuthResponse(1, "Thanks for sharing your Story, it Will be LIVE soon!!")) + "}";
        //            }
        //            else
        //            {
        //                return "{\"UploadPicture\" : " + Serialize(new AuthResponse(0, M.MessageFromSQL)) + "}";
        //            }
        //        }
        //        else
        //            return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));


        //    }
        //    return Serialize(new AuthResponse(0, "Authentication information not provided."));
        //}
        //#endregion

        [SoapHeader("UploadContext", Direction = SoapHeaderDirection.In)]
        [WebMethod(Description = "Upload Video & Picture Story")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string MultipleUploadVideo(DataClass.UploadVIdeo obj)
        {
            string taxFilePath = string.Empty;
            string path = string.Empty;
            if (this.UploadContext.ObjAuth == null)
            {
                return Serialize(new AuthResponse(0, "Authentication information not provided."));
            }
            if (this.UploadContext == null)
            {
                return Serialize(new AuthResponse(0, "Taxdata Header Invalid"));
            }
            int Output = CheckLoginReturnUserId(UploadContext.ObjAuth).ValueFromSQL;
            if (Output > 0)
            {
                MEMBERS.SQLReturnValue M;
                M = GetUploadVideo.Insert_Update_UploadVideo(obj);
                if (M.ValueFromSQL > 0)
                {
                    foreach (SaveUploadVideoClass file in this.UploadContext.taxdata)
                    {
                        if (obj.UploadTypeID == 2)
                        {
                            path = base.Server.MapPath("StoriesALL/");
                        }
                        else if (obj.UploadTypeID == 1)
                        {
                            path = base.Server.MapPath("VideoALL/");
                        }
                        string str3 = path + "/" + file.Name.Split(new char[] { '|' })[0].Replace(' ', '_');
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            Directory.CreateDirectory(path);
                        }
                        else if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        object obj2 = taxFilePath;
                        taxFilePath = string.Concat(new object[] { obj2, obj.UserID, "/", file.Name.Replace(' ', '_'), "," });
                        byte[] bytes = this.Decryptdata(file.Content);
                        System.IO.File.WriteAllBytes(str3, bytes);
                        if (obj.UploadTypeID == 2)
                        {
                            obj.UploadedVideoIDP = M.ValueFromSQL;
                            obj.video_path = file.Name;
                            GetUploadVideoPath.Save_Video_Path(obj);
                        }
                        else if (obj.UploadTypeID == 1)
                        {
                            obj.UploadedVideoIDP = M.ValueFromSQL;
                            obj.video_path = file.Name;
                            obj.IncidentSubCategoryIDF = obj.IncidentSubCategoryIDF;
                            obj.IncidentCategoryIDF = obj.IncidentCategoryIDF;
                            obj.thumbpath = "NA";
                            GetUploadVideoPath.Save_Video_Path(obj);
                        }
                        new SendFCM().sendFCMNotification(M.MessageFromSQL, obj.UploadTitle, "Thanks for uploading your news. It will be LIVE shortly, after screaning!!");
                    }
                    return "{\"UploadDone\" : " + Serialize(new AuthResponse(1, "Thanks for uploading your news. It will be LIVE shortly, after screaning!!")) + "}";
                }
                return "{\"UploadDone\" : " + Serialize(new AuthResponse(0, "Uploading Failed!")) + "}";

            }
            else
                return Serialize(new AuthResponse(0, "Authentication information not provided."));

        }
        private byte[] Decryptdata(string encryptpwd)
        {
            return Convert.FromBase64String(encryptpwd);
        }

        #region Get Story
        [WebMethod(Description = "Retrive Story Pic List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetStoryPic(int UserID)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetStory proc = new GetStory();
                    return "{\"StoryList\" : " + Serialize(proc.Get_StoryPic(UserID)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region SearchVideoStory
        [WebMethod(Description = "Searching Story / video Pic List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SearchVideoStory(string Keyword, int Type, int UserID)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    if (Type == 1)
                    {
                        GetSearchVideoStory proc = new GetSearchVideoStory();
                        return "{\"VideoInformation\" : " + Serialize(proc.SearchByVideoStory(Keyword, Type, UserID)) + "}";
                    }
                    else
                    {
                        GetSearchVideoStory proc = new GetSearchVideoStory();
                        return "{\"StoryList\" : " + Serialize(proc.Get_StoryPic(Keyword, Type, UserID)) + "}";
                    }

                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Save Blog
        [WebMethod(Description = "Add Blog")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string AddBlog(DataClass.DataAddBlog obj)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    MEMBERS.SQLReturnValue M;
                    M = GetAddBlog.Insert_Update_Blog(obj);
                    new SendFCM().sendFCMNotification(M.MessageFromSQL, obj.title, "Thanks for uploading your Blog. It will be LIVE Now,Thanks for using LiveReporting!!");
                    return Serialize(new AuthResponse(M.ValueFromSQL, "Thanks for uploading your Blog. It will be LIVE Now,Thanks for using LiveReporting!!"));
                    
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Get Blog
        [WebMethod(Description = "Get Blog")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetBlog(int mainid, string Search)
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetBlog proc = new GetBlog();
                    return "{\"BlogList\" : " + Serialize(proc.GetBlogList(mainid, Search)) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region GetMobileBanner
        [WebMethod(Description = "Retrive Get Mobile Banner List..")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetMobileBannerList()
        {
            if (SecureAuthentication != null)
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetBannerLR proc = new GetBannerLR();
                    return "{\"BannerList\" : " + Serialize(proc.GetMobileBanner()) + "}";
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            return Serialize(new AuthResponse(0, "Authentication information not provided."));
        }
        #endregion

        #region Update IMEI
        [WebMethod(Description = "Update IMEI")]
        [SoapDocumentMethod(Binding = "LiveReporting")]
        [SoapHeader("SecureAuthentication", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateIMEI(DataIMEI obj)
        {
            if (string.IsNullOrEmpty(obj.Mainid.ToString()) || string.IsNullOrEmpty(obj.IMEI.ToString()))
            {
                return Serialize(new AuthResponse(0, "Parameters is NULL"));
            }
            try
            {
                int Output = CheckLoginReturnUserId(SecureAuthentication).ValueFromSQL;
                if (Output > 0)
                {
                    GetIMEI proc = new GetIMEI();
                    return Serialize(proc.Save_IMEI(obj));
                }
                else
                    return Serialize(new AuthResponse(0, Output == -1 ? "Authentication is NULL" : "Invalid Authentication"));
            }
            catch (Exception ex)
            {
                return Serialize(new AuthResponse(0, "internal server error"));
            }
        }
        #endregion
    }
}