using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.KeToan.BL;
using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.Common.Resources;

namespace MISA.AMIS.KeToan.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field
        private IBaseBL<T> _baseBL;
        #endregion
        #region Constructorm
        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion
        /// <summary>
        ///API Thấy thông tin của tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: NVQUY(13/11/2022)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                var records = _baseBL.GetAllRecords();
                //Trả về giá trị cho 
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                return StatusCode(StatusCodes.Status200OK, new List<T>());

                //Try catch để bắt exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return HandleException(ex);
            }
        }
        /// <summary>
        /// API Lấy thông tin bản ghi theo ID 
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin bản ghi theo ID </returns>
        ///Created By : NVQUY(13/11/2022)
        [HttpGet("{recordID}")]
        public IActionResult GetRecordByID(Guid recordID)
        {
            try
            {
                var record = _baseBL.GetRecordByID(recordID);
                //Xử lý kết quả trả về
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                return StatusCode(StatusCodes.Status404NotFound);

                //Try catch để bắt exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return HandleException(ex);
            }
        }
        /// <summary>
        ///API Xóa thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="employeeID">ID của bản ghi muốn xóa </param>
        /// <returns>1: Nếu xóa thành công, 0: Nếu xóa thất bại</returns>
        /// Created by : NVQUY(13/11/2022) 
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecordByID(Guid recordID)
        {
            try
            {
                var result = _baseBL.DeleteRecordByID(recordID);

                //Xử lý kết quả trả về từ DB
                //Trả về dữ liệu cho client nếu thành công
                if (result > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                //Trả về lỗi nếu thất bại
                return StatusCode(StatusCodes.Status500InternalServerError);

                //Try catch để bắt exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return HandleException(ex);
            }
        }


        /// <summary>
        /// API Thêm mới một nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần thêm mới</param>
        /// <returns>ID của nhân viên cần thêm mới</returns>
        /// 201: Thêm mới thành công
        /// 400 : Dữ liệu đầu vào không hợp lệ
        /// 500 : Xảy ra exeption
        /// Created by: NVQUY(3/11/2022)
        //[HttpPost]
        //public IActionResult InsertEmployee([FromBody] Employee employee)
        //{
        //    try
        //    {
        //        //var error = new ErrorService();
        //        //var errorData = new Dictionary<string, string>();
        //        //var errorMsgs = new List<string>();
        //        ////Các trường bắt buộc nhập
        //        ////Validate dữ liệu trả về mã 400 kèm các thông tin lỗi
        //        ////1. Kiểm tra các trường bắt buộc nhập
        //        ////1.1. Thông tin mã nhân viên không được phép để trống
        //        //if (string.IsNullOrEmpty(employee.EmployeeCode))
        //        //{
        //        //    errorData.Add("EmployeeCode", Resource.Error_EmployeeNameNotEmpty);
        //        //    error.UserMsg = Resource.Error_EmployeeCodeNotEmpty;
        //        //    return BadRequest(error);

        //        //}
        //        //////1.2. Kiểm tra mã nhập vào đã tồn tại chưa
        //        //if (CheckEmployeeCode(employee.EmployeeCode))
        //        //{
        //        //    errorData.Add("EmployeeCode", Resource.Error_EmployeeCodeNotDuplicates);
        //        //    error.UserMsg = Resource.Error_EmployeeCodeNotDuplicates;
        //        //    return BadRequest(error);
        //        //}
        //        /////1.3. Thông tin tên nhân viên không đuọc phép để trống
        //        //if (string.IsNullOrEmpty(employee.EmpoyeeName))
        //        //{
        //        //    errorData.Add("EmployeeName", Resource.Error_EmployeeNameNotEmpty);
        //        //    error.UserMsg = Resource.Error_EmployeeNameNotEmpty;

        //        //    return BadRequest(error);

        //        //}

        //        ///1.4. Mã đơn vị không được phép để trống
        //        //if (string.IsNullOrEmpty((employee.DepartmentID).ToString()))
        //        //{
        //        //    errorData.Add("DepartmentID", Resource.Error_DepartmentNameNotEmpty);
        //        //    error.UserMsg = Resource.Error_DepartmentNameNotEmpty;
        //        //    return BadRequest(error);

        //        //}
        //        ///1.4. Ngày sinh không được lơn hơn ngày hiện tại
        //        //DateTime now = new DateTime();
        //        //DateTime dateOfBirth = new DateTime(employee.DateOfBirth);
        //        //var result= DateTime.Compare(dateOfBirth, now);

        //        //if((employee.DateOfBirth) > now)
        //        //{
        //        //    errorMsgs.Add(Resources.ResourceVN.Error_DateOfBirth);
        //        //}

        //        ////1.5. Email phải đúng định dạng
        //        //if (!IsValidEmail(email: employee.Email))
        //        //{
        //        //    errorData.Add("Email", Resource.Error_EmailNotValidate);
        //        //    error.UserMsg = Resource.Error_EmailNotValidate;
        //        //    return BadRequest(error);

        //        //}
        //        //////Đếm số lỗi kiểm tra dữ liệu
        //        //if (errorData.Count > 0)
        //        //{
        //        //    error.UserMsg = Resource.Error_Validate;
        //        //    error.Data = errorData;
        //        //    return BadRequest(error);
        //        //}
        //        //Khởi tạo kết nối tới Db MySQL


        //        //Xử lý kết quả trả về từ DB

        //        //Trả về dữ liệu cho client nếu thành công

        //        var newEmployeeID = _employeeBL.InsertEmployee(employee);

        //        return StatusCode(StatusCodes.Status201Created, newEmployeeID);

        //        //Try catch để bắt exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return HandleException(ex);
        //    }

        ////}
        /////// <summary>
        /////// Xử lý Exception
        /////// </summary>
        /////// <param name="ex">Tên exception</param>
        /////// <returns>Mã 500 và thông tin exception</returns>

        private IActionResult HandleException(Exception ex)
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
        /////// <summary>
        /////// API sửa thông tin nhân viên theo nhân viên theo ID
        /////// </summary>
        /////// <param name="employeeID">Mã nhân viên muốn sửa</param>
        /////// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /////// <returns>ID của nhân vine muốn sửa</returns>
        /////// Created by : NVQUY(3/11/2022)
        ////[HttpPut("{employeeID}")]
        ////public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        ////{
        ////    try
        ////    {
        ////        //var error = new ErrorService();
        ////        //var errorData = new Dictionary<string, string>();
        ////        //var errorMsgs = new List<string>();
        ////        ////Các trường bắt buộc nhập
        ////        ////Validate dữ liệu trả về mã 400 kèm các thông tin lỗi
        ////        ////1. Kiểm tra các trường bắt buộc nhập
        ////        ////1.1. Thông tin mã nhân viên không được phép để trống
        ////        //if (string.IsNullOrEmpty(employee.EmployeeCode))
        ////        //{
        ////        //    errorData.Add("EmployeeCode", Resource.Error_EmployeeNameNotEmpty);
        ////        //    error.UserMsg = Resource.Error_EmployeeCodeNotEmpty;
        ////        //    return BadRequest(error);

        ////        //}
        ////        //////1.2. Kiểm tra mã nhập vào đã tồn tại chưa
        ////        //if (CheckEmployeeCode(employee.EmployeeCode))
        ////        //{
        ////        //    errorData.Add("EmployeeCode", Resource.Error_EmployeeCodeNotDuplicates);
        ////        //    error.UserMsg = Resource.Error_EmployeeCodeNotDuplicates;
        ////        //    return BadRequest(error);
        ////        //}
        ////        /////1.3. Thông tin tên nhân viên không đuọc phép để trống
        ////        //if (string.IsNullOrEmpty(employee.EmpoyeeName))
        ////        //{
        ////        //    errorData.Add("EmployeeName", Resource.Error_EmployeeNameNotEmpty);
        ////        //    error.UserMsg = Resource.Error_EmployeeNameNotEmpty;

        ////        //    return BadRequest(error);

        ////        //}
        ////        ///1.4. Mã đơn vị không được phép để trống
        ////        //if (string.IsNullOrEmpty((employee.DepartmentID).ToString()))
        ////        //{
        ////        //    errorData.Add("DepartmentID", Resource.Error_DepartmentNameNotEmpty);
        ////        //    error.UserMsg = Resource.Error_DepartmentNameNotEmpty;
        ////        //    return BadRequest(error);

        ////        //}
        ////        ///1.4. Ngày sinh không được lơn hơn ngày hiện tại
        ////        //DateTime now = new DateTime();
        ////        //DateTime dateOfBirth = new DateTime(employee.DateOfBirth);
        ////        //var result= DateTime.Compare(dateOfBirth, now);

        ////        //if((employee.DateOfBirth) > now)
        ////        //{
        ////        //    errorMsgs.Add(Resources.ResourceVN.Error_DateOfBirth);
        ////        //}

        ////        ////1.5. Email phải đúng định dạng
        ////        //if (!IsValidEmail(email: employee.Email))
        ////        //{
        ////        //    errorData.Add("Email", Resource.Error_EmailNotValidate);
        ////        //    error.UserMsg = Resource.Error_EmailNotValidate;
        ////        //    return BadRequest(error);

        ////        //}
        ////        //////Đếm số lỗi kiểm tra dữ liệu
        ////        //if (errorData.Count > 0)
        ////        //{
        ////        //    error.UserMsg = Resource.Error_Validate;
        ////        //    error.Data = errorData;
        ////        //    return BadRequest(error);
        ////        //}
        ////        //Khởi tạo kết nối tới Db MySQL
        ////        _employeeBL.UpdateEmployee(employeeID, employee);
        ////        //Xử lý kết quả trả về từ DB

        ////        return StatusCode(StatusCodes.Status200OK, employeeID);

        ////        //Try catch để bắt exception
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Console.WriteLine(ex);
        ////        return HandleException(ex);
        ////    }
        ////}

        /////// <summary>
        /////// Kiểm tra trùng mã nhân viên
        /////// </summary>
        /////// <param name="employeeCode">Mã nhân viên nhập từ người dùng</param>
        /////// <returns>True: Nếu mã đã tồn tại , False: Nếu mã chưa tồn tại</returns>
        /////// Created by: NVQUY(3/10/2022)
        ////private bool CheckEmployeeCode(string employeeCode)
        ////{
        ////    //Khởi tạo kết nối tới Db MySQL
        ////    string connectionString = "Server=localhost;Port=3306;Database=misa.web09.tcdn.nvquy1;Uid=root;Pwd=22121944;";
        ////    var mySqlConnection = new MySqlConnection(connectionString);
        ////    string storedProcedureName = "Proc_employee_GetEmployeeCode";
        ////    //Chuẩn bị tham số đầu vào 
        ////    var parameters = new DynamicParameters();
        ////    parameters.Add("@EmployeeCode", employeeCode);
        ////    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        ////    var employee = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        ////    //Trả về dữ liệu cho client nếu thành công
        ////    if (employee != null)
        ////    {
        ////        return true;
        ////    }
        ////    //Trả về lỗi nếu thất bại
        ////    return false;
        ////}

        /////// <summary>
        /////// Kiểm tra định dạng email
        /////// </summary>
        /////// <param name="email">Email nhập vào từ người dùng</param>
        /////// <returns>True: Nếu email đúng định dạng, False: Nếu email sai định dạng</returns>
        private bool IsValidEmail(string email)
        {
            string emailTrimed = email.Trim();

            if (!string.IsNullOrEmpty(emailTrimed))
            {
                bool hasWhitespace = emailTrimed.Contains(" ");

                int indexOfAtSign = emailTrimed.LastIndexOf('@');

                if (indexOfAtSign > 0 && !hasWhitespace)
                {
                    string afterAtSign = emailTrimed.Substring(indexOfAtSign + 1);

                    int indexOfDotAfterAtSign = afterAtSign.LastIndexOf('.');

                    if (indexOfDotAfterAtSign > 0 && afterAtSign.Substring(indexOfDotAfterAtSign).Length > 1)
                        return true;
                }
            }
            return false;
        }

     
    
        ///////API Xóa nhiều nhân viên theo ID
        /////// </summary>
        /////// <param name="listEmployeeID">Danh sách ID của những nhân viên cần xóa</param>
        /////// <returns>Status Code 200</returns>
        /////// Created by : NVQUY(3/11/2022)
        ////[HttpPost("{deletePath}")]
        ////public IActionResult DeleteMultipleEmployee([FromBody] ListEmployeeID listEmployeeID)
        ////{
        ////    //Khởi tạo kết nối tới Db MySQL
        ////    string connectionString = "Server=localhost;Port=3306;Database=misa.web09.tcdn.nvquy1;Uid=root;Pwd=22121944;";
        ////    var mySqlConnection = new MySqlConnection(connectionString);
        ////    mySqlConnection.Open();
        ////    // Chuẩn bị câu lệnh SQL
        ////    string storedProcedureName = "Proc_employee_Delete";

        ////    var trans = mySqlConnection.BeginTransaction();
        ////    try
        ////    {
        ////        //Chuẩn bị tham số đầu vào
        ////        foreach (var employeeID in listEmployeeID.employeeIDs)
        ////        {
        ////            var parameters = new DynamicParameters();
        ////            parameters.Add("@EmployeeID", employeeID);
        ////            mySqlConnection.Execute(storedProcedureName, parameters, trans, commandType: System.Data.CommandType.StoredProcedure);
        ////        }
        ////        trans.Commit();

        ////        //Xử lý kết quả trả về từ DB
        ////        return StatusCode(200, listEmployeeID.employeeIDs.Count);
        ////        //Try catch để bắt exception
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        trans.Rollback();
        ////        Console.WriteLine(ex.Message);
        ////        return HandleException(ex);
        ////    }
        ////}

    }
}
