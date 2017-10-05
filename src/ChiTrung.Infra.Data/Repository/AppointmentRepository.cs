using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Domain.Options;
using Microsoft.Extensions.Options;
using Dapper;

namespace ChiTrung.Infra.Data.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DatabaseOptions _options;
        private string _connectionString = string.Empty;

        public AppointmentRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _options = databaseOptions.Value;
            _connectionString = !string.IsNullOrWhiteSpace(_options.ConnectionString) ? _options.ConnectionString : throw new ArgumentNullException(nameof(_options.ConnectionString));
        }                

        public async Task<IEnumerable<dynamic>> GetEmployeeSchedule(DateTime desiredTime)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CheckEmployeeHasOtherAppointments(DateTime desiredTime, string desiredEmpolyee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description, os.Name as status, 
                        oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl, 
						a.Street as street, a.City as city, a.Country as country, a.State as state, a.ZipCode as zipcode
                        FROM ordering.Orders o
                        INNER JOIN ordering.Address a ON o.AddressId = a.Id 
                        LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid 
                        LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                        WHERE o.Id=@id"
                        , new { desiredTime }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        public async Task<IEnumerable<dynamic>> GetOppointmentScheduleByDesiredTime(DateTime desiredTime)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> GetAppointmentsOfEmployeeByDesiredTime(DateTime desiredTime, string desiredEmpolyee)
        {
            throw new NotImplementedException();
        }

        private dynamic MapOrderItems(dynamic result)
        {
            dynamic order = new ExpandoObject();

            order.ordernumber = result[0].ordernumber;
            order.date = result[0].date;
            order.status = result[0].status;
            order.description = result[0].description;
            order.street = result[0].street;
            order.city = result[0].city;
            order.zipcode = result[0].zipcode;
            order.country = result[0].country;

            order.orderitems = new List<dynamic>();
            order.total = 0;

            foreach (dynamic item in result)
            {
                dynamic orderitem = new ExpandoObject();
                orderitem.productname = item.productname;
                orderitem.units = item.units;
                orderitem.unitprice = item.unitprice;
                orderitem.pictureurl = item.pictureurl;

                order.total += item.units * item.unitprice;
                order.orderitems.Add(orderitem);
            }

            return order;
        }
    }
}
