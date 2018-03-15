using System;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class PermissionSet
    {
        public PermissionSet()
        {
            _token = 0;
        }
        
        public PermissionSet(int token)
        {
            if (ValidateToken(token))
            {
                ParseToken(token);
                _token = token;
            }
            else
            {
                _token = 0;
            }
        }

        internal bool _isCustomer;
        public bool IsCustomer { get { return _isCustomer; } set { _isCustomer = value; RefreshToken(); } }

        internal bool _isManager;
        public bool IsManager { get { return _isManager; } set { _isManager = value; RefreshToken(); } }

        internal bool _isStockClerk;
        public bool IsStockClerk { get { return _isStockClerk; } set { _isStockClerk = value; RefreshToken(); } }

        internal bool _isWorkSpecialist;
        public bool IsWorkSpecialist { get { return _isWorkSpecialist; } set { _isWorkSpecialist = value; RefreshToken(); } }

        internal int _token;
        public int Token { get { return _token; } }

        private void RefreshToken()
        {
            int _tokenValue = 0;

            if (IsCustomer)
                _tokenValue = _tokenValue + (int)Permission.Customer;
            if (IsManager)
                _tokenValue = _tokenValue + (int)Permission.Manager;

            _token = _tokenValue;
        }

        private void ParseToken(int token)
        {
            int _validationToken = token;
            int _iteration = 5;
            while (_iteration >= 1)
            {
                if (Math.Pow(_validationToken, 1 / (double)_iteration) >= 2)
                {
                    switch ((int)Math.Pow(2.0,_iteration))
                    {
                        case (int)Permission.Customer: _isCustomer = true;
                            break;
                        case (int)Permission.Manager: _isManager = true;
                            break;
                    }
                }

                _iteration--;
            }
        }

        public Permission? GetHighestPermission()
        {
            int _validationToken = Token;
            int _iteration = 5;
            while (_iteration >= 1)
            {
                if (Math.Pow(_validationToken, 1 / (double)_iteration) >= 2)
                {
                    switch ((int)Math.Pow(2.0, _iteration))
                    {
                        case (int)Permission.Manager: return Permission.Manager;
                        case (int)Permission.Customer: return Permission.Customer;
                    }
                }

                _iteration--;
            }

            return null;
        }

        private bool ValidateToken(int token)
        {
            //Parse out all powers of two 
            int _validationToken = token;
            int _iteration = 5;
            while (_iteration >= 1)
            {
                if (Math.Pow(_validationToken, 1 / (double)_iteration) >= 2)
                {
                    _validationToken = _validationToken - (int)Math.Pow(2, _iteration);
                }

                _iteration--;
            }

            //check for a remainder
            if(_validationToken > 0)
            {
                return false;
            }

            return true;
        }
    }
}
