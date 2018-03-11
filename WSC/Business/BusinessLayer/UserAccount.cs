using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class UserAccount : Employee
    {
        public UserAccount(string userName, string password, bool isHashed)
            : base()
        {
            _userAccountId = Guid.NewGuid();
            _userName = userName;
            if (isHashed)
                _password = password;
            else
                _password = CalculateHash(password);
        }

        public UserAccount(Guid userId, Guid personId, string userName, string password, 
            PermissionSet permissionSet, bool isHashed)
            : base()
        {
            _userAccountId = userId;
            base.PersonId = personId;
            _userName = userName;
            _permissionSet = permissionSet;
            if (isHashed)
                _password = password;
            else
                _password = CalculateHash(password);
        }

        internal Guid _userAccountId;
        public Guid UserAccountId { get { return _userAccountId; } set { _userAccountId = value; } }

        public new Guid PersonId { get { return base.PersonId; } set { base.PersonId = value; } }

        internal string _password;
        public string PasswordHash { get { return _password; } set { _password = CalculateHash(value); } }

        internal string _userName;
        public string UserName { get { return _userName; } set { _userName = value; } }

        internal PermissionSet _permissionSet;
        public PermissionSet PermissionSet { get { return (_permissionSet != null) ? _permissionSet : new PermissionSet(); } set { _permissionSet = value; } }

        public Permission? HighestPermission { get { return PermissionSet.GetHighestPermission(); } }

        private string CalculateHash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
 
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        //Compare plain text to inputted pw hash
        public bool MatchPassword(string password, string passwordHash)
        {
            if (CalculateHash(password) == passwordHash)
                return true;

            return false;
        }
        //Compare inputted hash to object password
        public bool MatchPassword(string password)
        {
            if (PasswordHash == CalculateHash(password))
                return true;

            return false;
        }

        public void ClearPermissionSet()
        {
            PermissionSet = new PermissionSet();
        }
    }
}
