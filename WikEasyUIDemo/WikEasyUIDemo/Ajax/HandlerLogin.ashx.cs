﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Web.SessionState;
namespace WikEasyUIDemo.Ajax
{
    /// <summary>
    /// HandlerLogin 的摘要说明
    /// </summary>
    public class HandlerLogin : IHttpHandler,IReadOnlySessionState
    {
        string userName = "";
        string userPwd = "";     

        public void ProcessRequest(HttpContext context)
        {
         
            context.Response.ContentType = "text/plain";
            

            userName = context.Request.Form["username"].ToString();
            userPwd= context.Request.Form["userpwd"].ToString();         
            context.Response.Write(CheckLogin(userName,userPwd));        

        }
        private string CheckLogin(string uname, string upwd)
        {
            BLL.User bll = new BLL.User();
            DataTable dt = bll.GetList("UserName='"+uname+"' and UserPwd='"+upwd+"'").Tables[0];
            if (dt.Rows.Count > 0)
            {
              
                return "0";//登录成功
            }
            else
                return "1";
            
           
 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}