using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.Model
{
    public class Contractor : IComparable
    {
        private int _contractorID;
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _phone;
        private string _email;
        private string _userName;
        private string _profile = "../Images/placeholder-profile.png";
        private string _password = "pw";
        private Decimal _contractorRating;
        private Decimal _payRate;
        private bool _active;
        private SQLHelper _db;


        public int ContractorID
        {
            get { return _contractorID; }
            set { _contractorID = value; }
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
        public string FullName
        {
            get { return _firstName + " " + _lastName+"\t".PadRight(2); }
            set { _fullName = value; }
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
        public string Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Decimal ContractorRating
        {
            get { return _contractorRating; }
            set { _contractorRating = value; }
        }
        public Decimal PayRate
        {
            get { return _payRate; }
            set { _payRate = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }



        public Contractor()
        {
            _db = new SQLHelper();
        }

        public Contractor(DataRow dr)
        {
            this.ContractorID = (int)dr["ContractorID"];
            this.FirstName = dr["FirstName"].ToString();
            this.LastName = dr["LastName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.State = dr["State"].ToString();
            this.Phone = dr["Phone"].ToString();
            this.Email = dr["Email"].ToString();
            this.UserName = dr["UserName"].ToString();
            this.Password = dr["Password"].ToString();
            this.ContractorRating = Convert.ToDecimal(dr["ContractorRating"].ToString());
            this.PayRate = Convert.ToDecimal(dr["PayRate"].ToString());
            this.Profile = dr["Profile"].ToString();
            this.Active = Convert.ToBoolean(dr["Active"].ToString());
            _db = new SQLHelper();
        }

        public int InsertContractor()
        {
            try
            {
                string sql = "insert into contractor(firstName, lastName, street, suburb, postcode, state, phone, email, " +
                    " userName, password, contractorRating, payRate, profile, active) " +
                    " values(@FirstName, @LastName,@Street, @Suburb, @PostCode, @State, @Phone, @Email, " +
                    " @UserName, @Password, @ContractorRating, @PayRate, @Profile, @Active)";
                SqlParameter[] objParams;
                objParams = new SqlParameter[15];
                objParams[0] = new SqlParameter("@ContractorID", DbType.String);
                objParams[0].Value = this.ContractorID;
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
                objParams[11] = new SqlParameter("@ContractorRating", DbType.Decimal);
                objParams[11].Value = this.ContractorRating;
                objParams[12] = new SqlParameter("@PayRate", DbType.Decimal);
                objParams[12].Value = this.PayRate;
                objParams[13] = new SqlParameter("@Profile", DbType.String);
                objParams[13].Value = this.Profile; 
                objParams[14] = new SqlParameter("@Active", DbType.String);
                objParams[14].Value = this.Active;
                int result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not insert Contractor", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;  
            }
        }
        public int UpdateContractor()
        {
            try
            {
                int result = -1;
                string sql = "UPDATE Contractor set " +
                    "firstName = @FirstName, " +
                    "lastName =  @LastName, " +
                    "street = @Street, " +
                    "suburb =  @Suburb," +
                    "postCode = @PostCode, " +
                    "state =  @State, " +
                    "phone = @Phone, " +
                    "email = @Email, " +
                    "userName = @UserName, " +
                    "password =  @Password, " +
                    "contractorRating =  @ContractorRating, " +
                    "payRate =  @PayRate, " +
                    "profile =  @Profile, " +
                    "active = @Active " +
                    " WHERE contractorID = @ContractorID";
                SqlParameter[] objParams;
                objParams = new SqlParameter[15];
                objParams[0] = new SqlParameter("@ContractorID", DbType.String);
                objParams[0].Value = this.ContractorID;
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
                objParams[11] = new SqlParameter("@ContractorRating", DbType.Decimal);
                objParams[11].Value = this.ContractorRating;
                objParams[12] = new SqlParameter("@PayRate", DbType.Decimal);
                objParams[12].Value = this.PayRate;
                objParams[13] = new SqlParameter("@Profile", DbType.String);
                objParams[13].Value = this.Profile;
                objParams[14] = new SqlParameter("@Active", DbType.String);
                objParams[14].Value = this.Active;
                result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not update Contractor", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public int DeleteContractor()
        {
            try
            {
                int result = -1;
                string sql = "DELETE FROM Contractor WHERE contractorID = @ContractorID";
                SqlParameter[] objParams;
                objParams = new SqlParameter[1];
                objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
                objParams[0].Value = this.ContractorID;
                result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }catch(Exception ex)
            {
                MessageBox.Show("Could not delete Contractor", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public int CompareTo(object obj)
        {
            return ContractorRating.CompareTo(((Contractor)obj).ContractorRating);
        }
    }
}

