using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
namespace WikEasyUIDemo.DAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class User
    {
        public User()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TUser");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WikEasyUIDemo.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TUser(");
            strSql.Append("UserName,RealName,UserPwd,Role,IsAdmin,Email)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@RealName,@UserPwd,@Role,@IsAdmin,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@IsAdmin", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.Role;
            parameters[4].Value = model.IsAdmin;
            parameters[5].Value = model.Email;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WikEasyUIDemo.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TUser set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("UserPwd=@UserPwd,");
            strSql.Append("Role=@Role,");
            strSql.Append("IsAdmin=@IsAdmin,");
            strSql.Append("Email=@Email");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@IsAdmin", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.Role;
            parameters[4].Value = model.IsAdmin;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TUser ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WikEasyUIDemo.Model.User GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,RealName,UserPwd,Role,IsAdmin,Email from TUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            WikEasyUIDemo.Model.User model = new WikEasyUIDemo.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                if (ds.Tables[0].Rows[0]["Role"].ToString() != "")
                {
                    model.Role = int.Parse(ds.Tables[0].Rows[0]["Role"].ToString());
                }
                model.IsAdmin = ds.Tables[0].Rows[0]["IsAdmin"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,RealName,UserPwd,Role,IsAdmin,Email ");
            strSql.Append(" FROM TUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UserName,RealName,UserPwd,Role,IsAdmin,Email ");
            strSql.Append(" FROM TUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "User";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

