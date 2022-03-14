using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Client
    {
        private int _clientID;
        private string _companyName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _phone;
        private string _email;
        private string _userName;
        private string _password;
        private bool _active;
        private SQLHelper _db;


        public int ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
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
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }



        public Client()
        {
            _db = new SQLHelper();
        }

        public Client(DataRow dr)
        {
            this.ClientID = (int)dr["clientID"];
            this.CompanyName = dr["CompanyName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.State = dr["State"].ToString();
            this.Phone = dr["Phone"].ToString();
            this.Email = dr["Email"].ToString();
            this.UserName = dr["UserName"].ToString();
            this.Password = dr["Password"].ToString();
            this.Active = Convert.ToBoolean(dr["Active"].ToString());
            _db = new SQLHelper();
        }

        public int InsertClient()
        {
            string sql = "insert into client(companyName, street, suburb, postcode, state, phone, email, @userName, @password, active) " +
                " values(@CompanyName, @Street, @Suburb, @PostCode, @State, @Phone, @Email,@UserName, @Password, @Active)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[9];
            objParams[0] = new SqlParameter("@ClientID", DbType.String);
            objParams[0].Value = this.ClientID;
            objParams[1] = new SqlParameter("@CompanyName", DbType.String);
            objParams[1].Value = this.CompanyName;
            objParams[2] = new SqlParameter("@Street", DbType.String);
            objParams[2].Value = this.Street;
            objParams[3] = new SqlParameter("@Suburb", DbType.String);
            objParams[3].Value = this.Suburb;
            objParams[4] = new SqlParameter("@PostCode", DbType.String);
            objParams[4].Value = this.PostCode;
            objParams[5] = new SqlParameter("@State", DbType.String);
            objParams[5].Value = this.State;
            objParams[6] = new SqlParameter("@Phone", DbType.String);
            objParams[6].Value = this.Phone;
            objParams[7] = new SqlParameter("@Email", DbType.String);
            objParams[7].Value = this.Email;
            objParams[8] = new SqlParameter("@UserName", DbType.String);
            objParams[8].Value = this.UserName;
            objParams[9] = new SqlParameter("@Password", DbType.String);
            objParams[9].Value = this.Password;
            objParams[10] = new SqlParameter("@Active", DbType.String);
            objParams[10].Value = this.Active;
            int result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int UpdateClient()
        {
            int result = -1;
            string sql = "UPDATE client set " +
                "companyName = @CompanyName, " +
                "street =  @Street, " +
                "suburb =  @Suburb, " +
                "postCode = @PostCode, " +
                "state =  @State, " +
                "phone = @Phone, " +
                "email = @Email, " +
                "userName = @UserName, " +
                "password = @Password, " +
                "active = @Active, " +
                " WHERE clientID = @ClientID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[9];
            objParams[0] = new SqlParameter("@clientID", DbType.String);
            objParams[0].Value = this.ClientID;
            objParams[1] = new SqlParameter("@CompanyName", DbType.String);
            objParams[1].Value = this.CompanyName;
            objParams[2] = new SqlParameter("@Street", DbType.String);
            objParams[2].Value = this.Street;
            objParams[3] = new SqlParameter("@Suburb", DbType.String);
            objParams[3].Value = this.Suburb;
            objParams[4] = new SqlParameter("@PostCode", DbType.String);
            objParams[4].Value = this.PostCode;
            objParams[5] = new SqlParameter("@State", DbType.String);
            objParams[5].Value = this.State;
            objParams[6] = new SqlParameter("@Phone", DbType.String);
            objParams[6].Value = this.Phone;
            objParams[7] = new SqlParameter("@Email", DbType.String);
            objParams[7].Value = this.Email;
            objParams[8] = new SqlParameter("@UserName", DbType.String);
            objParams[8].Value = this.UserName;
            objParams[9] = new SqlParameter("@Password", DbType.String);
            objParams[9].Value = this.Password;
            objParams[10] = new SqlParameter("@Active", DbType.String);
            objParams[10].Value = this.Active;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int DeleteClient()
        {
            int result = -1;
            string sql = "DELETE FROM Client WHERE clientID = @ClientID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClientID", DbType.Int32);
            objParams[0].Value = this.ClientID;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}
