using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertOrderCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _orderId;
        private readonly SqlParameter _orderEntryDate;
        private readonly SqlParameter _orderFulfillDate;
        private readonly SqlParameter _orderStatusId;
        private readonly SqlParameter _personId;

        public InsertOrderCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertOrderCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblOrder]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _orderId = CreateParameter("orderId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _orderEntryDate = CreateParameter("orderEntryDate", SqlDbType.DateTime, ParameterDirection.Input);
            _orderFulfillDate = CreateParameter("orderFulfillDate", SqlDbType.DateTime, ParameterDirection.Input);
            _orderStatusId = CreateParameter("orderStatusId", SqlDbType.Int, ParameterDirection.Input);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_orderId);
            sqlParameterCollection.Add(_orderEntryDate);
            sqlParameterCollection.Add(_orderFulfillDate);
            sqlParameterCollection.Add(_orderStatusId);
            sqlParameterCollection.Add(_personId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid OrderId
        {
            get { return (Guid)_orderId.Value; }
            set { _orderId.Value = value; }
        }

        public DateTime OrderEntryDate
        {
            get { return (DateTime)_orderEntryDate.Value; }
            set { _orderEntryDate.Value = value; }
        }

        public DateTime? OrderFulfillDate
        {
            get { return (DateTime?)_orderFulfillDate.Value; }
            set { _orderFulfillDate.Value = value; }
        }

        public int OrderStatusId
        {
            get { return (int)_orderStatusId.Value; }
            set { _orderStatusId.Value = value; }
        }

        public Guid PersonId
        {
            get { return (Guid)_personId.Value; }
            set { _personId.Value = value; }
        }
    }
}

