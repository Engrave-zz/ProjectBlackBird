using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class OrderData
    {
        public static List<Order> GetAll()
        {
            List<Order> orderList = new List<Order>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrdersCommand objectCommand = new GetOrdersCommand(objectConnection))
                {
                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderList;
                        }

                        using (OrderSqlDataReader objectSqlDataReader = new OrderSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Order order = objectSqlDataReader.Order;
                                orderList.Add(order);
                            }
                        }
                    }
                }
            }

            return orderList;
        }

        public static List<Order> GetByOrderId(Guid orderId)
        {
            List<Order> orderList = new List<Order>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderByOrderId objectCommand = new GetOrderByOrderId(objectConnection))
                {
                    objectCommand.OrderId = orderId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderList;
                        }

                        using (OrderSqlDataReader objectSqlDataReader = new OrderSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Order order = objectSqlDataReader.Order;
                                orderList.Add(order);
                            }
                        }
                    }
                }
            }

            return orderList;
        }

        public static List<Order> GetOrderByLastName(string lastName)
        {
            List<Order> orderList = new List<Order>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderByLastName objectCommand = new GetOrderByLastName(objectConnection))
                {
                    objectCommand.LastName = lastName;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderList;
                        }

                        using (OrderSqlDataReader objectSqlDataReader = new OrderSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Order order = objectSqlDataReader.Order;
                                orderList.Add(order);
                            }
                        }
                    }
                }
            }

            return orderList;
        }
        
        public static List<Order> GetByOrderStatusId(int orderStatusId)
        {
            List<Order> orderList = new List<Order>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderByOrderStatusId objectCommand = new GetOrderByOrderStatusId(objectConnection))
                {
                    objectCommand.OrderStatusId = orderStatusId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderList;
                        }

                        using (OrderSqlDataReader objectSqlDataReader = new OrderSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Order order = objectSqlDataReader.Order;
                                orderList.Add(order);
                            }
                        }
                    }
                }
            }

            return orderList;
        }

        public static List<Order> GetByInventoryItemId(Guid inventoryItemId)
        {
            List<Order> orderList = new List<Order>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetOrderByInventoryItemId objectCommand = new GetOrderByInventoryItemId(objectConnection))
                {
                    objectCommand.InventoryItemId = inventoryItemId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return orderList;
                        }

                        using (OrderSqlDataReader objectSqlDataReader = new OrderSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Order order = objectSqlDataReader.Order;
                                orderList.Add(order);
                            }
                        }
                    }
                }
            }

            return orderList;
        }

        public static int UpdateByOrderId(Guid personId, Guid orderId, DateTime orderEntryDate, DateTime orderFulfillDate
            , int orderStatusId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateOrderByOrderIdCommand objectCommand = new UpdateOrderByOrderIdCommand(objectConnection))
                {
                    objectCommand.PersonId = personId;
                    objectCommand.OrderId = orderId;
                    objectCommand.OrderEntryDate = orderEntryDate;
                    objectCommand.OrderFulfillDate = orderFulfillDate;
                    objectCommand.OrderStatusId = orderStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByOrderId(Order order)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdateOrderByOrderIdCommand objectCommand = new UpdateOrderByOrderIdCommand(objectConnection))
                {
                    objectCommand.PersonId = order.PersonId;
                    objectCommand.OrderId = order.OrderId;
                    objectCommand.OrderEntryDate = order.OrderEntryDate;
                    objectCommand.OrderFulfillDate = order.OrderFulfillDate;
                    objectCommand.OrderStatusId = order.OrderStatusId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int InsertOrder(Order order)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertOrderCommand objectCommand = new InsertOrderCommand(objectConnection))
                {
                    objectCommand.OrderId = order.OrderId;
                    objectCommand.OrderEntryDate = order.OrderEntryDate;
                    objectCommand.OrderFulfillDate = order.OrderFulfillDate;
                    objectCommand.OrderStatusId = order.OrderStatusId;
                    objectCommand.PersonId = order.PersonId;
                    
                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }
    }
}
