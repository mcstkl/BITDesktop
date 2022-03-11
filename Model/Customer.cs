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
    public class Customer
    {
        private int _customerID;
        private string _companyName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _email;
        private string _phone;
        private bool _deleted;
        private SQLHelper _db;


        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
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
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }



        public Customer()
        {
            _db = new SQLHelper();
        }

        public Customer(DataRow dr)
        {
            this.CustomerID = (int)dr["CustomerID"];
            this.CompanyName = dr["CompanyName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.State = dr["State"].ToString();
            this.Phone = dr["Phone"].ToString();
            this.Email = dr["Email"].ToString();
            this.Deleted = Convert.ToBoolean(dr["Deleted"].ToString());
            _db = new SQLHelper();
        }

        public int InsertCustomer()
        {
            string sql = "insert into customer(companyName, street, suburb, postcode, state, phone, email, deleted) " +
                " values(@CompanyName, @Street, @Suburb, @PostCode, @State, @Phone, @Email, @Deleted)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[9];
            objParams[0] = new SqlParameter("@CustomerID", DbType.String);
            objParams[0].Value = this.CustomerID;
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
            objParams[8] = new SqlParameter("@Deleted", DbType.String);
            objParams[8].Value = this.Deleted;
            int result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int UpdateCustomer()
        {
            int result = -1;
            string sql = "UPDATE Customer set " +
                "companyName = @CompanyName, " +
                "street =  @Street, " +
                "suburb =  @Suburb, " +
                "postCode = @PostCode, " +
                "state =  @State, " +
                "phone = @Phone, " +
                "email = @Email, " +
                "deleted = @Deleted, " +
                " WHERE customerID = @CustomerID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[9];
            objParams[0] = new SqlParameter("@CustomerID", DbType.String);
            objParams[0].Value = this.CustomerID;
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
            objParams[8] = new SqlParameter("@Deleted", DbType.String);
            objParams[8].Value = this.Deleted;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int DeleteCustomer()
        {
            int result = -1;
            string sql = "DELETE FROM Customer WHERE customerID = @CustomerID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@CustomerID", DbType.Int32);
            objParams[0].Value = this.CustomerID;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}
