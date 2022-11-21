using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.BL;
using MISA.AMIS.KeToan.Common.Resources;
using Dapper;
using MySqlConnector;
using System.Text.RegularExpressions;
using MISA.AMIS.KeToan.Common.Entities.DTO;
using System.ComponentModel.DataAnnotations;
using MISA.AMIS.KeToan.DL;

namespace MISA.AMIS.KeToan.API.Controllers
{
    [ApiController]
    public class EmployeesController : BasesController<Employee>
    {
        #region Field
        private IEmployeeBL _employeeBL;

        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        #endregion


        /// <summary>
        /// api lấy danh sách nhân viên theo bộ lọc và phân trang
        /// </summary>
        /// <param name = "keyword" > từ khóa muốn tìm kiếm</param>
        /// <param name = "limit" > số bản ghi muốn lấy</param>
        /// <param name = "offset" > vị trí bắt đầu lấy</param>
        /// <returns>danh sách nhân viên và tổng số bản ghi</returns>
        /// created by : nvquy(3/11/2022)
        [HttpGet("filter")]
        public IActionResult getEmployeeByFilterAndPaging(
            [FromQuery] string? keyword,
            [FromQuery] int limit = 10,
            [FromQuery] int offset = 0)
        {
            try
            {
                var employees = _employeeBL.getEmployeeByFilterAndPaging(keyword, limit, offset);
                return StatusCode(StatusCodes.Status200OK, employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return handleException(ex);
            }
        }
        /// <summary>
        /// api thêm mới một nhân viên
        /// </summary>
        /// <param name="employee">đối tượng nhân viên cần thêm mới</param>
        /// <returns>id của nhân viên cần thêm mới</returns>
        /// 201: thêm mới thành công
        /// 400 : dữ liệu đầu vào không hợp lệ
        /// 500 : xảy ra exeption
        /// created by: nvquy(3/11/2022)
        [HttpPost]
        public IActionResult insertEmployee([FromBody] Employee employee)
        {
            try
            {
                var error = new ErrorService();
                var errorData = new Dictionary<string, string>();
                var errorMsgs = new List<string>();
                //các trường bắt buộc nhập
                //validate dữ liệu trả về mã 400 kèm các thông tin lỗi
                //1. kiểm tra các trường bắt buộc nhập
                //1.1. thông tin mã nhân viên không được phép để trống
                if (string.IsNullOrEmpty(employee.EmployeeCode))
                {
                    errorData.Add("employeecode", Resource.Error_EmployeeNameNotEmpty);
                    error.UserMsg = Resource.Error_EmployeeCodeNotEmpty;
                    return BadRequest(error);

                }
                //1.2. kiểm tra mã nhập vào đã tồn tại chưa
                if (checkEmployeeCode(employee.EmployeeCode))
                {
                    errorData.Add("employeecode", Resource.Error_EmployeeCodeNotDuplicates);
                    error.UserMsg = Resource.Error_EmployeeCodeNotDuplicates;
                    return BadRequest(error);
                }
                ///1.3. thông tin tên nhân viên không đuọc phép để trống
                if (string.IsNullOrEmpty(employee.EmployeeName))
                {
                    errorData.Add("employeename", Resource.Error_EmployeeNameNotEmpty);
                    error.UserMsg = Resource.Error_EmployeeNameNotEmpty;

                    return BadRequest(error);
                }

                ///1.4. mã đơn vị không được phép để trống
                //if (string.isnullorempty((employee.departmentid).tostring()))
                //{
                //    errordata.add("departmentid", resource.error_departmentnamenotempty);
                //    error.usermsg = resource.error_departmentnamenotempty;
                //    return badrequest(error);


                ////1.5. email phải đúng định dạng
                if (!EmailIsValid(email: employee.Email))
                {
                    errorData.Add("email", Resource.Error_EmailNotValidate);
                    error.UserMsg = Resource.Error_EmailNotValidate;
                    return BadRequest(error);

                }
                ////đếm số lỗi kiểm tra dữ liệu
                if (errorData.Count > 0)
                {
                    error.UserMsg = Resource.Error_Validate;
                    error.Data = errorData;
                    return BadRequest(error);
                }
                //khởi tạo kết nối tới db mysql


                //xử lý kết quả trả về từ db

                //trả về dữ liệu cho client nếu thành công

                var newEmployeeID = _employeeBL.insertemployee(employee);

                return StatusCode(StatusCodes.Status201Created, newEmployeeID);

                //try catch để bắt exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return handleException(ex);
            }
        }

        ///// <summary>
        ///// xử lý exception
        ///// </summary>
        ///// <param name="ex">tên exception</param>
        ///// <returns>mã 500 và thông tin exception</returns>

        private IActionResult handleException(Exception ex)
        {
            var error = new ErrorService();
            error.ErrorCode = (int)ErrorCode.ExceptionCode;
            error.DevMsg = ex.Message;
            error.UserMsg = Resource.Error_Exception;
            error.MoreInfo = Resource.MoreInfo_Exception;
            error.TraceId = HttpContext.TraceIdentifier;
            error.Data = ex.Data;
            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
        ///// <summary>
        ///// api sửa thông tin nhân viên theo nhân viên theo id
        ///// </summary>
        ///// <param name="employeeid">mã nhân viên muốn sửa</param>
        ///// <param name="employee">đối tượng nhân viên muốn sửa</param>
        ///// <returns>id của nhân vine muốn sửa</returns>
        ///// created by : nvquy(3/11/2022)
        //[HttpPut("{employeeID}")]
        //public IActionResult updateEmployee([FromRoute] Guid employeeID,
        //    [FromBody] Employee employee)
        //{
        //    try
        //    {
        //        var error = new ErrorService();
        //        var errorData = new Dictionary<string, string>();
        //        var errorMsgs = new List<string>();
        //        ////các trường bắt buộc nhập
        //        ////validate dữ liệu trả về mã 400 kèm các thông tin lỗi
        //        ////1. kiểm tra các trường bắt buộc nhập
        //        ////1.1. thông tin mã nhân viên không được phép để trống
        //        if (string.IsNullOrEmpty(employee.EmployeeCode))
        //        {
        //            errorData.Add("employeecode", Resource.Error_EmployeeNameNotEmpty);
        //            error.UserMsg = Resource.Error_EmployeeCodeNotEmpty;
        //            return BadRequest(error);

        //            //}
        //            //////1.2. kiểm tra mã nhập vào đã tồn tại chưa
        //            if (checkEmployeeCode(employee.EmployeeCode))
        //            {
        //                errorData.Add("employeecode", Resource.Error_EmployeeCodeNotDuplicates);
        //                error.UserMsg = Resource.Error_EmployeeCodeNotDuplicates;
        //                return BadRequest(error);
        //            }
        //            /////1.3. thông tin tên nhân viên không đuọc phép để trống
        //            if (string.IsNullOrEmpty(employee.EmployeeName))
        //            {
        //                errorData.Add("employeename", Resource.Error_EmployeeNameNotEmpty);
        //                error.UserMsg = Resource.Error_EmployeeNameNotEmpty;
        //                return BadRequest(error);

        //                //}
        //                ///1.4. mã đơn vị không được phép để trống
        //                //if (string.isnullorempty((employee.departmentid).tostring()))
        //                //{
        //                //    errordata.add("departmentid", resource.error_departmentnamenotempty);
        //                //    error.usermsg = resource.error_departmentnamenotempty;
        //                //    return badrequest(error);


        //                ////1.5. email phải đúng định dạng
        //                if (!EmailIsValid(email: employee.Email))
        //                {
        //                    errorData.Add("email", Resource.Error_EmailNotValidate);
        //                    error.UserMsg = Resource.Error_EmailNotValidate;
        //                    return BadRequest(error);

        //                }
        //                ////đếm số lỗi kiểm tra dữ liệu
        //                if (errorData.Count > 0)
        //                {
        //                    error.UserMsg = Resource.Error_Validate;
        //                    error.Data = errorData;
        //                    return BadRequest(error);
        //                }
        //                //khởi tạo kết nối tới db mysql
        //                _employeebl.updateemployee(employeeID, employee);
        //                //xử lý kết quả trả về từ db

        //                return StatusCode(StatusCodes.Status200OK, employeeID);

        //                //try catch để bắt exception
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return handleexception(ex);
        //    }
        //}

        ///// <summary>
        ///// kiểm tra trùng mã nhân viên
        ///// </summary>
        ///// <param name="employeecode">mã nhân viên nhập từ người dùng</param>
        ///// <returns>true: nếu mã đã tồn tại , false: nếu mã chưa tồn tại</returns>
        ///// created by: nvquy(3/10/2022)
        private bool checkEmployeeCode(string employeeCode)
        {
            //khởi tạo kết nối tới db mysql
            string connectionString = "server=localhost;port=3306;database=misa.web09.tcdn.nvquy1;uid=root;pwd=22121944;";
            var mysqlconnection = new MySqlConnection(connectionString);
            string storedprocedurename = "Proc_employee_GetEmployeeCode";
            //chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("@employeecode", employeeCode);
            //thực hiện gọi vào db để chạy lệnh sql với tham số đầu vào ở trên
            var employee = mysqlconnection.QueryFirstOrDefault<string>(storedprocedurename, parameters, commandType: System.Data.CommandType.StoredProcedure);

            //trả về dữ liệu cho client nếu thành công
            if (employee != null)
            {
                return true;
            }
            //trả về lỗi nếu thất bại
            return false;
        }

        ///// <summary>
        ///// kiểm tra định dạng email
        ///// </summary>
        ///// <param name="email">email nhập vào từ người dùng</param>
        ///// <returns>true: nếu email đúng định dạng, false: nếu email sai định dạng</returns>
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///api xóa nhiều nhân viên theo id
        /// </summary>
        /// <param name="listemployeeid">danh sách id của những nhân viên cần xóa</param>
        /// <returns>status code 200</returns>
        /// created by : nvquy(3/11/2022)
        [HttpPost("{deletepath}")]
        public IActionResult deleteMultipleEmployee([FromBody] ListEmployeeID listEmployeeID)
        {
            //khởi tạo kết nối tới db mysql
            var mysqlconnection = new MySqlConnection(DatabaseContext.ConnectionString);
            mysqlconnection.Open();
            // chuẩn bị câu lệnh sql
            string storedprocedurename = "proc_employee_DeleteByID";

            var trans = mysqlconnection.BeginTransaction();
            try
            {
                //chuẩn bị tham số đầu vào
                foreach (var employeeID in listEmployeeID.employeeIDs)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@employeeid", employeeID);
                    mysqlconnection.Execute(storedprocedurename, parameters, trans, commandType: System.Data.CommandType.StoredProcedure);
                }
                trans.Commit();

                //xử lý kết quả trả về từ db
                return StatusCode(200, listEmployeeID.employeeIDs.Count);
                //try catch để bắt exception
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.Message);
                return handleException(ex);
            }
        }


        /// <summary>
        /// Kiểm tra dữ liệu nhập vào từ người dùng
        /// </summary>
        /// <param name="employee">Dữ liệu nhập vào đối tượng nhân viên</param>
        /// <returns>True: Nếu dữ liệu nhập vào đúng, False: Nếu dữ liệu nhập vào sai</returns>
        /// Created By : NVQUY(13/11/2022)
        private ServiceResponse ValidateRequestData(Employee employee)
        {
            var properties = typeof(Employee).GetProperties();
            var validateFailures = new List<string>();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(employee);
                var requiredAttribute = (RequiredAttribute?)Attribute.GetCustomAttribute(property,
                    typeof(RequireHttpsAttribute));
                if (requiredAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    validateFailures.Add(requiredAttribute.ErrorMessage);
                }
            }
            if (validateFailures.Count > 0)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = validateFailures
                };
            }
            return new ServiceResponse
            {
                Success = true
            };
        }
    }
}


