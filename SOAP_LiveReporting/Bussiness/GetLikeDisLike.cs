using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetLikeDisLike : SqlHelper
    {
        public Bussiness.AuthResponse Add_Like(DataClass.Like_DisLikeData obj)
        {
            string[,] param = {{"UploadVideoIDF",obj.VideoIDF.ToString()},
                                {"status",obj.Status.ToString()}, {"UserID",obj.UserID.ToString()}};
            MEMBERS.SQLReturnValue M = ExecuteProcWithMessageValue("ADD_LIKE_DISLIKE", param, true);
            return new Bussiness.AuthResponse(M.ValueFromSQL, M.MessageFromSQL);
        }
    }
}