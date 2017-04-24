using System;
using System.Data;
using System.Collections.Generic;

using WikEasyUIDemo.Model;
namespace WikEasyUIDemo.BLL
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        private readonly WikEasyUIDemo.DAL.User dal = new WikEasyUIDemo.DAL.User();
        public User()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WikEasyUIDemo.Model.User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WikEasyUIDemo.Model.User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WikEasyUIDemo.Model.User GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WikEasyUIDemo.Model.User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WikEasyUIDemo.Model.User> DataTableToList(DataTable dt)
        {
            List<WikEasyUIDemo.Model.User> modelList = new List<WikEasyUIDemo.Model.User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                WikEasyUIDemo.Model.User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new WikEasyUIDemo.Model.User();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    model.UserPwd = dt.Rows[n]["UserPwd"].ToString();
                    if (dt.Rows[n]["Role"].ToString() != "")
                    {
                        model.Role = int.Parse(dt.Rows[n]["Role"].ToString());
                    }
                    model.IsAdmin = dt.Rows[n]["IsAdmin"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

