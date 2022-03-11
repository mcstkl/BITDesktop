using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BITServices.DAL;

namespace BITServices.Model
{
    public class Coordinator
    {
        private int _coordinatorID;
        private string _firstName;
        private string _lastName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _email;
        private string _phone;
        private string _dateOfBirth;
        private string _userName;
        private string _password;
        private bool _admin;
        private bool _deleted;
        private SQLHelper _db;


        public int CoordinatorID
        {
            get { return _coordinatorID; }
            set { _coordinatorID = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Suburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }



        public Coordinator()
        {
            _db = new SQLHelper();
        }

        public Coordinator(DataRow dr)
        {
            this.CoordinatorID = (int)dr["CoordinatorID"];
            this.FirstName = dr["FirstName"].ToString();
            this.LastName = dr["LastName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.Phone = dr["Phone"].ToString();
            this.UserName = dr["UserName"].ToString();
            this.Password = dr["Password"].ToString();
            this.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString()).ToShortDateString(); ;
            this.Email = dr["Email"].ToString();
            this.Admin = Convert.ToBoolean(dr["Admin"].ToString());
            this.Deleted = Convert.ToBoolean(dr["Deleted"].ToString());
            _db = new SQLHelper();
        }

        public int InsertCoordinator()
        {
            string sql = "insert into coordinator(firstName, lastName, street, suburb, postcode, userName, password, dateOfBirth, email, admin, deleted) " +
                " values(@FirstName, @LastName,@Street, @Suburb, @PostCode,@UserName, @Password, @DateOfBirth,@Email, @Admin, @Deleted)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[12];
            objParams[0] = new SqlParameter("@CoordinatorID", DbType.String);
            objParams[0].Value = this.CoordinatorID;
            objParams[1] = new SqlParameter("@FirstName", DbType.String);
            objParams[1].Value = this.FirstName;
            objParams[2] = new SqlParameter("@LastName", DbType.String);
            objParams[2].Value = this.LastName;
            objParams[3] = new SqlParameter("@Street", DbType.String);
            objParams[3].Value = this.Street;
            objParams[4] = new SqlParameter("@Suburb", DbType.String);
            objParams[4].Value = this.Suburb;
            objParams[5] = new SqlParameter("@PostCode", DbType.String);
            objParams[5].Value = this.PostCode;
            objParams[6] = new SqlParameter("@UserName", DbType.String);
            objParams[6].Value = this.UserName;
            objParams[7] = new SqlParameter("@Password", DbType.String);
            objParams[7].Value = this.Password;
            objParams[8] = new SqlParameter("@DateOfBirth", DbType.String);
            objParams[8].Value = this.DateOfBirth;
            objParams[9] = new SqlParameter("@Email", DbType.String);
            objParams[9].Value = this.Email;
            objParams[10] = new SqlParameter("@Admin", DbType.String);
            objParams[10].Value = this.Admin;
            objParams[11] = new SqlParameter("@Deleted", DbType.String);
            objParams[11].Value = this.Deleted;
            int result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int UpdateCoordinator()
        {
            int result = -1;
            string sql = "UPDATE Categories set " +
                "firstName = @FirstName, " +
                "lastName =  @LastName, " +
                "street = @Street, " +
                "suburb =  @Suburb," +
                "postCode = @PostCode, " +
                "userName =  @UserName, " +
                "password = @Password, " +
                "dateOfBirth =  @DateOfBirth, " +
                "email = @Email, " +
                "admin =  @Admin, " +
                "deleted = @Deleted, " +
                " WHERE categoryID = @CategoryId";
            SqlParameter[] objParams;
            objParams = new SqlParameter[12];
            objParams[0] = new SqlParameter("@CoordinatorID", DbType.String);
            objParams[0].Value = this.CoordinatorID;
            objParams[1] = new SqlParameter("@FirstName", DbType.String);
            objParams[1].Value = this.FirstName;
            objParams[2] = new SqlParameter("@LastName", DbType.String);
            objParams[2].Value = this.LastName;
            objParams[3] = new SqlParameter("@Street", DbType.String);
            objParams[3].Value = this.Street;
            objParams[4] = new SqlParameter("@Suburb", DbType.String);
            objParams[4].Value = this.Suburb;
            objParams[5] = new SqlParameter("@PostCode", DbType.String);
            objParams[5].Value = this.PostCode;
            objParams[6] = new SqlParameter("@UserName", DbType.String);
            objParams[6].Value = this.UserName;
            objParams[7] = new SqlParameter("@Password", DbType.String);
            objParams[7].Value = this.Password;
            objParams[8] = new SqlParameter("@DateOfBirth", DbType.String);
            objParams[8].Value = this.DateOfBirth;
            objParams[9] = new SqlParameter("@Email", DbType.String);
            objParams[9].Value = this.Email;
            objParams[10] = new SqlParameter("@Admin", DbType.String);
            objParams[10].Value = this.Admin;
            objParams[11] = new SqlParameter("@Deleted", DbType.String);
            objParams[11].Value = this.Deleted;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int DeleteCoordinator()
        {
            int result = -1;
            string sql = "DELETE FROM Coordinator WHERE coordinatorID = @CoordinatorID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@CoordinatorID", DbType.Int32);
            objParams[0].Value = this.CoordinatorID;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}




