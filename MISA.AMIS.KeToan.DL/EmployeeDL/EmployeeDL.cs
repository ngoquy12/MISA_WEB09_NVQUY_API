using Dapper;
using MISA.AMIS.KeToan.Common;
using MySqlConnector;

namespace MISA.AMIS.KeToan.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        public int deleteMultipleEmployee(ListEmployeeID listEmployeeID)
        {
            //khởi tạo kết nối tới db mysql
            string connectionString = "server=localhost;port=3306;database=misa.web09.tcdn.nvquy1;uid=root;pwd=22121944;";
            var mysqlconnection = new MySqlConnection(connectionString);
            mysqlconnection.Open();
            // chuẩn bị câu lệnh sql
            string storedprocedurename = "proc_employee_delete";
            var trans = mysqlconnection.BeginTransaction();
            foreach (var employeeID in listEmployeeID.employeeIDs)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@employeeid", employeeID);
                mysqlconnection.Execute(storedprocedurename, parameters, trans, commandType: System.Data.CommandType.StoredProcedure);
            }
            trans.Commit();
            return listEmployeeID.employeeIDs.Count;
        }

        public PagingResult getEmployeeByFilterAndPaging(
            string? keyword,
            int limit = 10, 
            int offset = 0)
        {
            //khởi tạo kết nối tới db mysql
            var mysqlconnection = new MySqlConnection(DatabaseContext.ConnectionString);
            // chuẩn bị câu lệnh sql
            string storedprocedurename = "proc_employee_searchandpaging";
            //chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("@keyword", keyword);
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            //thực hiện gọi vào db để chạy lệnh sql với tham số đầu vào ở trên
            var employes = mysqlconnection.QueryMultiple(storedprocedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);

            //xử lý kết quả trả về từ db
            //trả về dữ liệu cho client nếu thành công

            var listemployee = employes.Read<Employee>().ToList();
            var totalcount = listemployee.Count();

            return new PagingResult
            {
                Data = listemployee,
                TotalCount = totalcount
            };
        }
    }

}

