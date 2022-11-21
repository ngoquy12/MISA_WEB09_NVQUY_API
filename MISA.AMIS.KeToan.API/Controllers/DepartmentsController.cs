using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.KeToan.BL;
using MISA.AMIS.KeToan.BL.DepartmentBL;
using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.Common.Resources;
using MySqlConnector;

namespace MISA.AMIS.KeToan.API.Controllers
{
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        #region Field
        private IDepartmentBL _departmentBL;
        #endregion
        #region Constructor
        public DepartmentsController(IDepartmentBL departmentBL) :base(departmentBL)
        {
            _departmentBL = departmentBL;
        }
        #endregion

        //#region Field
        //private IDepartmentBL _departmentBL;
        //#endregion
        //#region Constructor
        //public DepartmentsController(IDepartmentBL departmentBL)
        //{
        //    _departmentBL = departmentBL;
        //}
        //#endregion
        ///// <summary>
        /////API Thấy thông tin của tất cả phòng ban
        ///// </summary>
        ///// <returns>Danh sách nhân viên</returns>
        ///// Created By: NVQUY(3/11/2022)
        //[HttpGet]
        //public IActionResult GetAllDepartment()
        //{
        //    try
        //    {
        //        var departments = _departmentBL.GetAllDepartment();

        //        //Trả về dữ liệu cho client nếu thành công

        //        if (departments != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, departments);
        //        }
        //        return StatusCode(StatusCodes.Status200OK, new List<Department>());
        //        //Try catch để bắt exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return HandleException(ex);
        //    }
        //}
        ///// <summary>
        /////API Lấy thông tin phòng ban theo ID 
        ///// </summary>
        ///// <returns>Thông tin 1 phòng ban</returns>
        ///// Created By : NVQUY(3/11/2022)
        //[HttpGet("{departmentID}")]
        //public IActionResult GetDepartmentByID([FromRoute] Guid departmentID)
        //{
        //    try
        //    {
        //        //Khởi tạo kết nối tới Db MySQL
        //        var department = _departmentBL.GetDepartmentByID(departmentID);
        //        //Xử lý kết quả trả về từ DB

        //        //Trả về dữ liệu cho client nếu thành công
        //        if (department != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, department);
        //        }
        //        //Trả về lỗi nếu thất bại
        //        return StatusCode(StatusCodes.Status404NotFound);
        //        //Try catch để bắt exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return HandleException(ex);
        //    }
        //}
        ///// <summary>
        ///// Thêm mới một phòng ban
        ///// </summary>
        ///// <param name"department"></param>
        ///// <returns>Mã phòng ban vừa được thêm</returns>
        //[HttpPost]
        //public IActionResult InsertDepartment([FromBody] Department department)
        //{
        //    try
        //    {
        //        //var error = new ErrorService();
        //        //var errorData = new Dictionary<string, string>();
        //        //var errorMsgs = new List<string>();
        //        //////Các trường bắt buộc nhập
        //        //////Validate dữ liệu trả về mã 400 kèm các thông tin lỗi
        //        //////1. Kiểm tra các trường bắt buộc nhập
        //        //////1.1. Thông tin mã phòng ban không được phép để trống
        //        //if (string.IsNullOrEmpty(department.DepartmentCode))
        //        //{
        //        //    errorData.Add("DepartmentCode", Resource.Error_DepartmentCodeNotEmpty);
        //        //    error.UserMsg = Resource.Error_DepartmentCodeNotEmpty;
        //        //    return BadRequest(error);

        //        //}
        //        //////1.2. Kiểm tra mã nhập vào đã tồn tại chưa
        //        //if (CheckDepartmentCode(department.DepartmentCode))
        //        //{
        //        //    errorData.Add("DepartmentCode", Resource.Error_DepartmentCodeNotDuplicates);
        //        //    error.UserMsg = Resource.Error_DepartmentCodeNotDuplicates;
        //        //    return BadRequest(error);
        //        //}
        //        /////1.3. Thông tin tên phòng ban không được phép để trống
        //        //if (string.IsNullOrEmpty(department.DepartmentName))
        //        //{
        //        //    errorData.Add("DepartmentName", Resource.Error_DepartmentNameNotEmpty);
        //        //    error.UserMsg = Resource.Error_DepartmentNameNotEmpty;
        //        //    return BadRequest(error);

        //        //}
        //        //////Đếm số lỗi kiểm tra dữ liệu
        //        //if (errorData.Count > 0)
        //        //{
        //        //    error.UserMsg = Resource.Error_Validate;
        //        //    error.Data = errorData;
        //        //    return BadRequest(error);
        //        //}
        //        var newDepartmentID= _departmentBL.InsertDepartment(department);

        //        //Trả về dữ liệu cho client nếu thành công

        //        return StatusCode(StatusCodes.Status200OK, newDepartmentID);

        //        //Try catch để bắt exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return HandleException(ex);
        //    }

        //}
        ///// <summary>
        ///// Kiểm tra trùng mã phòng ban
        ///// </summary>
        ///// <param name="departmentCode">Mã phòng ban nhập từ người dùng</param>
        ///// <returns>True: Nếu mã đã tồn tại , False: Nếu mã chưa tồn tại</returns>
        ///// Created by: NVQUY(3/10/2022)
        //private bool CheckDepartmentCode(string departmentCode)
        //{
        //    //Khởi tạo kết nối tới Db MySQL
        //    string connectionString = "Server=localhost;Port=3306;Database=misa.web09.tcdn.nvquy1;Uid=root;Pwd=22121944;";
        //    var mySqlConnection = new MySqlConnection(connectionString);
        //    string storedProcedureName = "Proc_department_GetDepartmentCode";
        //    //Chuẩn bị tham số đầu vào 
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@DepartmentCode", departmentCode);
        //    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //    var result = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //    //Trả về dữ liệu cho client nếu thành công
        //    if (result != null)
        //    {
        //        return true;
        //    }
        //    //Trả về lỗi nếu thất bại
        //    return false;
        //}
        ///// <summary>
        ///// Xử lý Exception
        ///// </summary>
        ///// <param name="ex">Tên exception</param>
        ///// <returns>Mã 500 và thông tin exception</returns>
        /////

        ///// <summary>
        ///// API sửa thông tin phòng ban theo ID
        ///// </summary>
        ///// <param name="departmentID">Mã phòng ban muốn sửa</param>
        ///// <param name="department">Đối tượng phòng ban muốn sửa</param>
        ///// <returns>Đối tượng phòng ban đã sửa</returns>
        ///// Created by : NVQUY(3/11/2022)
        //[HttpPut("{departmentID}")]
        //public IActionResult UpdateDepartmentByID([FromRoute] Guid departmentID, [FromBody] Department department)
        //{
        //    try
        //    {
        //        //var error = new ErrorService();
        //        //var errorData = new Dictionary<string, string>();
        //        //var errorMsgs = new List<string>();
        //        //////Các trường bắt buộc nhập
        //        //////Validate dữ liệu trả về mã 400 kèm các thông tin lỗi
        //        //////1. Kiểm tra các trường bắt buộc nhập
        //        //////1.1. Thông tin mã phòng ban không được phép để trống
        //        //if (string.IsNullOrEmpty(department.DepartmentCode))
        //        //{
        //        //    errorData.Add("DepartmentCode", Resource.Error_DepartmentCodeNotEmpty);
        //        //    error.UserMsg = Resource.Error_DepartmentCodeNotEmpty;
        //        //    return BadRequest(error);
        //        //}
        //        //////1.2. Kiểm tra mã nhập vào đã tồn tại chưa
        //        //if (CheckDepartmentCode(department.DepartmentCode))
        //        //{
        //        //    errorData.Add("DepartmentCode", Resource.Error_DepartmentCodeNotDuplicates);
        //        //    error.UserMsg = Resource.Error_DepartmentCodeNotDuplicates;
        //        //    return BadRequest(error);
        //        //}
        //        /////1.3. Thông tin tên phòng ban không được phép để trống
        //        //if (string.IsNullOrEmpty(department.DepartmentName))
        //        //{
        //        //    errorData.Add("DepartmentName", Resource.Error_DepartmentNameNotEmpty);
        //        //    error.UserMsg = Resource.Error_DepartmentNameNotEmpty;
        //        //    return BadRequest(error);
        //        //}
        //        //////Đếm số lỗi kiểm tra dữ liệu
        //        //if (errorData.Count > 0)
        //        //{
        //        //    error.UserMsg = Resource.Error_Validate;
        //        //    error.Data = errorData;
        //        //    return BadRequest(error);
        //        //}

        //        //Xử lý kết quả trả về từ DB
        //        var result = _departmentBL.UpdateDepartmentByID(departmentID, department);
        //        return StatusCode(StatusCodes.Status200OK, result);
        //        //Try catch để bắt exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return HandleException(ex);

        //    }
        //}
        //private IActionResult HandleException(Exception ex)
        //{
        //    var error = new ErrorService();
        //    error.ErrorCode = (int)ErrorCode.ExceptionCode;
        //    error.DevMsg = ex.Message;
        //    error.UserMsg = Resource.Error_Exception;
        //    error.MoreInfo = Resource.MoreInfo_Exception;
        //    error.TraceId = HttpContext.TraceIdentifier;
        //    error.Data = ex.Data;
        //    return StatusCode(StatusCodes.Status500InternalServerError, error);

        //}
    }
}

