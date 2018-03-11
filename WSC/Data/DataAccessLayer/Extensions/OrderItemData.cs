using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class OrderItemData
    {
        public static List<OrderItem> GetByOrderItemId(Guid orderItemId)
        {
            List<OrderItem> orderItemList = new List<OrderItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderItemByOrderItemIdCommand objectCommand = new GetOrderItemByOrderItemIdCommand(objectConnection))
                {
                    objectCommand.OrderItemId = orderItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderItemList;
                        }

                        using (OrderItemSqlDataReader objectSqlDataReader = new OrderItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                OrderItem orderItem = objectSqlDataReader.OrderItem;
                                orderItemList.Add(orderItem);
                            }
                        }
                    }
                }
            }

            return orderItemList;
        }

        public static List<OrderItem> GetByOrderId(Guid orderId)
        {
            List<OrderItem> orderItemList = new List<OrderItem>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderItemByOrderIdCommand objectCommand = new GetOrderItemByOrderIdCommand(objectConnection))
                {
                    objectCommand.OrderId = orderId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderItemList;
                        }

                        using (OrderItemSqlDataReader objectSqlDataReader = new OrderItemSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                OrderItem orderItem = objectSqlDataReader.OrderItem;
                                orderItemList.Add(orderItem);
                            }
                        }
                    }
                }
            }

            return orderItemList;
        }
    }
}
