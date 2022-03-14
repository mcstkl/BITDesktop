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
    public class Staff
    {
        private int _staffID;
        private string _firstName;
        private string _lastName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _phone;
        private string _email;
        private string _userName;
        private string _password;
        private string _staffType;
        private bool _active;
        private SQLHelper _db;


        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
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
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
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
        public string StaffType
        {
            get { return _staffType; }
            set { _staffType = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }



        public Staff()
        {
            _db = new SQLHelper();
        }

        public Staff(DataRow dr)
        {
            this.StaffID = (int)dr["StaffID"];
            this.FirstName = dr["FirstName"].ToString();
            this.LastName = dr["LastName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.State = dr["State"].ToString();
            this.Phone = dr["Phone"].ToString();
            this.Email = dr["Email"].ToString();
            this.UserName = dr["UserName"].ToString(); ;
            this.Password = dr["Password"].ToString();
            this.StaffType = dr["StaffType"].ToString();
            this.Active = Convert.ToBoolean(dr["Active"].ToString());
            _db = new SQLHelper();
        }

        public int InsertStaff()
        {
            string sql = "insert into staff(firstName, lastName, street, suburb, postcode, state, phone, email, userName, password, staffType, active) " +
                " values(@FirstName, @LastName,@Street, @Suburb, @PostCode,@State, @Phone, @Email,@UserName, @Password, @StaffType, @Active)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[13];
            objParams[0] = new SqlParameter("@StaffID", DbType.String);
            objParams[0].Value = this.StaffID;
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
            objParams[6] = new SqlParameter("@State", DbType.String);
            objParams[6].Value = this.State;
            objParams[7] = new SqlParameter("@Phone", DbType.String);
            objParams[7].Value = this.Phone;
            objParams[8] = new SqlParameter("@Email", DbType.String);
            objParams[8].Value = this.Email;
            objParams[9] = new SqlParameter("@UserName", DbType.String);
            objParams[9].Value = this.UserName;
            objParams[10] = new SqlParameter("@Password", DbType.String);
            objParams[10].Value = this.Password;
            objParams[11] = new SqlParameter("@StaffType", DbType.String);
            objParams[11].Value = this.StaffType;
            objParams[12] = new SqlParameter("@Active", DbType.String);
            objParams[12].Value = this.Active;
            int result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int UpdateStaff()
        {
            int result = -1;
            string sql = "UPDATE staff set " +
                "firstName = @FirstName, " +
                "lastName =  @LastName, " +
                "street = @Street, " +
                "suburb =  @Suburb," +
                "postCode = @PostCode, " +
                "state =  @State, " +
                "phone = @Phone, " +
                "email =  @Email, " +
                "userName = @UserName, " +
                "password =  @Password, " +
                "staffType = @StaffType, " +
                "active = @Active, " +
                " WHERE staffID = @StaffID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[13];
            objParams[0] = new SqlParameter("@StaffID", DbType.String);
            objParams[0].Value = this.StaffID;
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
            objParams[6] = new SqlParameter("@State", DbType.String);
            objParams[6].Value = this.State;
            objParams[7] = new SqlParameter("@Phone", DbType.String);
            objParams[7].Value = this.Password;
            objParams[8] = new SqlParameter("@Email", DbType.String);
            objParams[8].Value = this.Email;
            objParams[9] = new SqlParameter("@UserName", DbType.String);
            objParams[9].Value = this.UserName;
            objParams[10] = new SqlParameter("@Password", DbType.String);
            objParams[10].Value = this.Password;
            objParams[11] = new SqlParameter("@StaffType", DbType.String);
            objParams[11].Value = this.StaffType;
            objParams[12] = new SqlParameter("@Active", DbType.String);
            objParams[12].Value = this.Active;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int DeleteStaff()
        {
            int result = -1;
            string sql = "DELETE FROM Staff WHERE StaffID = @StaffID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@StaffID", DbType.Int32);
            objParams[0].Value = this.StaffID;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}




