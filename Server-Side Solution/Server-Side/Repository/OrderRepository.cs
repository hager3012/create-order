using Server_Side.DTOs;
using Server_Side.Repository.Contract;
using System.Data.SqlClient;
using System.Data;
namespace Server_Side.Repository

{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private string ConfigurationString; 
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConfigurationString = _configuration.GetConnectionString("DefaultConnection");
        }
        public string? AddOrder(OrdersDTo orders)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationString))
            {
                SqlCommand command = new SqlCommand("Sp_InsertOrderWithDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerName", orders.customerName);
                command.Parameters.AddWithValue("@OrderDate", orders.orderDate);
                command.Parameters.AddWithValue("@OrderTotal", orders.Total);
                DataTable ordersDetailsTable = new DataTable();
                ordersDetailsTable.Columns.Add("ProductName", typeof(string));
                ordersDetailsTable.Columns.Add("Quantity", typeof(int));
                ordersDetailsTable.Columns.Add("Price", typeof(decimal));
                foreach (var item in orders.OrderDetails)
                {
                    ordersDetailsTable.Rows.Add(item.productName, item.quantity, item.price);
                }
                SqlParameter parameter = command.Parameters.AddWithValue("@OrderDetails", ordersDetailsTable);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.orderDetailsType";
                connection.Open();
                SqlDataReader sqlData = command.ExecuteReader();
                while (sqlData.Read())
                {
                    string? status = sqlData["Status"].ToString();
                    connection.Close();
                    if (status is not null)
                        return status;
                }

            }
            return null; 
        }

      
    }
}
