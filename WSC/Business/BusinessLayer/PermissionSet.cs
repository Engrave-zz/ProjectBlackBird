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

        internal bool _isSalesPerson;
        public bool IsSalesPerson { get { return _isSalesPerson; } set { _isSalesPerson = value; RefreshToken(); } }

        internal bool _isOperationsManager;
        public bool IsOperationsManager { get { return _isOperationsManager; } set { _isOperationsManager = value; RefreshToken(); } }

        internal bool _isStockClerk;
        public bool IsStockClerk { get { return _isStockClerk; } set { _isStockClerk = value; RefreshToken(); } }

        internal bool _isWorkSpecialist;
        public bool IsWorkSpecialist { get { return _isWorkSpecialist; } set { _isWorkSpecialist = value; RefreshToken(); } }

        internal int _token;
        public int Token { get { return _token; } }

        private void RefreshToken()
        {
            int _tokenValue = 0;

            if (IsSalesPerson)
                _tokenValue = _tokenValue + (int)Permission.SalesPerson;
            if (IsStockClerk)
                _tokenValue = _tokenValue + (int)Permission.StockClerk;
            if (IsOperationsManager)
                _tokenValue = _tokenValue + (int)Permission.OperationsManager;
            if (IsWorkSpecialist)
                _tokenValue = _tokenValue + (int)Permission.WorkSpecialist;

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
                        case (int)Permission.StockClerk: _isStockClerk = true;
                            break;
                        case (int)Permission.SalesPerson: _isSalesPerson = true;
                            break;
                        case (int)Permission.OperationsManager: _isOperationsManager = true;
                            break;
                        case (int)Permission.WorkSpecialist: _isWorkSpecialist = true;
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
                        case (int)Permission.OperationsManager: return Permission.OperationsManager;
                        case (int)Permission.SalesPerson: return Permission.SalesPerson;
                        case (int)Permission.WorkSpecialist: return Permission.WorkSpecialist;
                        case (int)Permission.StockClerk: return Permission.StockClerk;
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
