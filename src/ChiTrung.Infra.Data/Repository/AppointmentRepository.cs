using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using Dapper;
using ChiTrung.Infra.Data.Context;
using Microsoft.Extensions.Configuration;

namespace ChiTrung.Infra.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public AppointmentRepository(TigersContext context, IConfiguration config)
            : base(context)
        {
            this._config = config;
            _connectionString = this._config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<dynamic>> GetEmployeeSchedule(DateTime desiredTime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                  @"SELECT employee.first_name, employee.last_name, schedule.from, schedule.to
                    FROM schedule, employee
                    WHERE schedule.employee_id = employee.id
                    AND schedule.from >= @desired_time
                    AND schedule.to <= @desired_time 
                    AND IsDeleted = 0"
                        , new { desiredTime }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapEmployeeScheduleItems(result);
            }
        }

        public async Task<int> CheckEmployeeHasOtherAppointments(DateTime desiredTime, string desiredEmpolyee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"SELECT COUNT(*) AS appointment_no
                     FROM appointment, employee
                     WHERE appointment.employee_id = employee.id
                     AND appointment.start_time >= @desired_time
                     AND appointment.end_time_expected <= @desired_time
                     AND appointment.employee_id = @desired_employee
                     AND IsDeleted = 0"
                        , new { desiredTime, desiredEmpolyee }
                    );

                return MapAppointmentNo(result);
            }
        }

        public async Task<IEnumerable<dynamic>> GetOppointmentScheduleByDesiredTime(DateTime desiredTime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"SELECT a.desired_time, a.employees_working, b.appointments_set
                     FROM  ( SELECT @desired_time AS ""desired_time"", COUNT(*) AS employees_working FROM schedule
                            WHERE schedule.from >= @desired_time
                            AND schedule.to <= @desired_time
                            AND schedule.IsDeleted = 0
                     ) AS a
                     LEFT JOIN
                     (
                        SELECT @desired_time AS ""desired_time"", COUNT(*) AS appointments_set
                        FROM appointment, employee
                        WHERE appointment.employee_id = employee.id
                        AND appointment.start_time >= @desired_time
                        AND appointment.end_time_expected <= @desired_time
                        AND appointment.IsDeleted = 0
                     ) AS b ON a.desired_time = b.desired_time"
                        , new { desiredTime }
                     );

                return MapOppointmentScheduleItems(result);
            }
        }

        public async Task<IEnumerable<dynamic>> GetAppointmentsOfEmployeeByDesiredTime(DateTime desiredTime, string desiredEmpolyee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"SELECT client.client_name, appointment.start_time, appointment.end_time_expected
                     FROM appointment, client
                     WHERE appointment.client_id = client.id
                     AND Date(appointment.start_time) = Date(@desired_time)
                     AND appointment.employee_id = @selected_employee
                     AND appointment.IsDeleted == false
                     AND client.IsDeleted = 0"
                        , new { desiredTime, desiredEmpolyee }
                     );

                return MapAppointmentsOfEmployeeItems(result);

            }
        }

        private dynamic MapEmployeeScheduleItems(dynamic result)
        {
            dynamic employeeSchedule = new ExpandoObject();
            employeeSchedule.items = new List<dynamic>();

            foreach (dynamic item in result)
            {
                dynamic employeeScheduleItem = new ExpandoObject();
                employeeScheduleItem.productname = item.productname;
                employeeScheduleItem.units = item.units;
                employeeScheduleItem.unitprice = item.unitprice;
                employeeScheduleItem.pictureurl = item.pictureurl;

                employeeSchedule.items.Add(employeeScheduleItem);
            }

            return employeeSchedule;
        }

        private dynamic MapOppointmentScheduleItems(dynamic result)
        {
            dynamic oppointmentSchedule = new ExpandoObject();
            oppointmentSchedule.items = new List<dynamic>();

            foreach (dynamic item in result)
            {
                dynamic oppointmentScheduleItem = new ExpandoObject();
                oppointmentScheduleItem.productname = item.productname;
                oppointmentScheduleItem.units = item.units;
                oppointmentScheduleItem.unitprice = item.unitprice;
                oppointmentScheduleItem.pictureurl = item.pictureurl;

                oppointmentSchedule.items.Add(oppointmentScheduleItem);
            }

            return oppointmentSchedule;
        }

        private dynamic MapAppointmentsOfEmployeeItems(dynamic result)
        {
            dynamic appointmentsOfEmployee = new ExpandoObject();
            appointmentsOfEmployee.items = new List<dynamic>();

            foreach (dynamic item in result)
            {
                dynamic appointmentsOfEmployeeItem = new ExpandoObject();
                appointmentsOfEmployeeItem.productname = item.productname;
                appointmentsOfEmployeeItem.units = item.units;
                appointmentsOfEmployeeItem.unitprice = item.unitprice;
                appointmentsOfEmployeeItem.pictureurl = item.pictureurl;

                appointmentsOfEmployee.items.Add(appointmentsOfEmployeeItem);
            }

            return appointmentsOfEmployee;
        }

        private int MapAppointmentNo(dynamic result)
        {
            int appointmentNo = result[0].appointment_no;

            return appointmentNo;
        }
    }
}
