using System;
namespace WikEasyUIDemo.Model
{
    /// <summary>
    /// User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User
    {
        public User()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _realname;
        private string _userpwd;
        private int? _role;
        private string _isadmin;
        private string _email;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Role
        {
            set { _role = value; }
            get { return _role; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsAdmin
        {
            set { _isadmin = value; }
            get { return _isadmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        #endregion Model

    }
}

