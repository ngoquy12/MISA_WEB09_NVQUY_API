using Dapper;
using MISA.AMIS.KeToan.Common;
using MySqlConnector;

namespace MISA.AMIS.KeToan.DL.DepartmentDL
{
    public class DepartmentDL : BaseDL<Department>, IDepartmentDL
    {
        /// <summary>
        ///API Thấy thông tin của tất cả phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// Created By: NVQUY(13/11/2022)
        //public IEnumerable<dynamic> GetAllDepartment()
        //{
        //    //Khởi tạo kết nối tới Db MySQL
        //    var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

        //    // Chuẩn bị câu lệnh SQL
        //    string storedProcedureName = "Proc_department_GetAll";

        //    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //    var departments = mysqlConnection.Query<Department>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

        //    //Xử lý kết quả trả về từ DB

        //    //Trả về dữ liệu cho client nếu thành công
        //    if (departments != null)
        //    {
        //        return departments;
        //    }
        //    //Trả về lỗi nếu thất bại
        //    return new List<Department>();
        //}

        ///// <summary>
        /////API Lấy thông tin phòng ban theo ID 
        ///// </summary>
        ///// <returns>Thông tin 1 phòng ban</returns>
        ///// Created By : NVQUY(13/11/2022)
        //public Department GetDepartmentByID(Guid departmentID)
        //{
        //    //Khởi tạo kết nối tới Db MySQL
        //    var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

        //    // Chuẩn bị câu lệnh SQL
        //    string storedProcedureName = "Proc_department_GetByID";
        //    //Chuẩn bị tham số đầu vào 
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@DepartmentID", departmentID);
        //    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //    var department = mysqlConnection.QueryFirstOrDefault<Department>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //    //Trả về dữ liệu cho client 

        //    return department;
        //}

        ///// <summary>
        ///// API Thêm mới một phòng ban
        ///// </summary>
        ///// <param name="department"></param>
        ///// <returns></returns>
        //public int InsertDepartment(Department department)
        //{

        //    //Khởi tạo kết nối tới Db MySQL
        //    string connectionString = "Server=localhost;Port=3306;Database=misa.web09.tcdn.nvquy1;Uid=root;Pwd=22121944;";
        //    var mySqlConnection = new MySqlConnection(connectionString);
        //    // Chuẩn bị câu lệnh SQL
        //    string storedProcedureName = "Proc_department_Insert";
        //    //Chuẩn bị tham số đầu vào 
        //    var parameters = new DynamicParameters();
        //    var newDepartmentID = Guid.NewGuid();
        //    parameters.Add("@DepartmentID", newDepartmentID);
        //    parameters.Add("@DepartmentCode", department.DepartmentCode);
        //    parameters.Add("@DepartmentName", department.DepartmentName);
        //    parameters.Add("@CreatedDate", department.CreatedDate);
        //    parameters.Add("@CreatedBy", department.CreatedBy);
        //    parameters.Add("@ModifiedDate", department.ModifiedDate);
        //    parameters.Add("@ModifiedBy", department.ModifiedBy);
        //    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //    int numberOfRowsAffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

        //    //Trả về dữ liệu cho client nếu thành công

        //    return numberOfRowsAffected;

        //}
        ///// <summary>
        ///// API sửa thông tin phòng ban theo ID
        ///// </summary>
        ///// <param name="departmentID">ID của phòng ban</param>
        ///// <param name="department">Đối tượng phòng ban được sửa</param>
        ///// <returns>1: Nếu cập nhật thành công, 0: Nếu cập nhật thất bại</returns>
        ///// Created By : NVQUY(13/11/2022)
        //public int UpdateDepartmentByID(Guid departmentID, Department department)
        //{
        //    //Khởi tạo kết nối tới Db MySQL
        //    string connectionString = "Server=localhost;Port=3306;Database=misa.web09.tcdn.nvquy1;Uid=root;Pwd=22121944;";
        //    var mySqlConnection = new MySqlConnection(connectionString);
        //    // Chuẩn bị câu lệnh SQL
        //    string storedProcedureName = "Proc_department_UpdateByID";
        //    //Chuẩn bị tham số đầu vào 
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@DepartmentCode", department.DepartmentCode);
        //    parameters.Add("@DepartmentName", department.DepartmentName);
        //    parameters.Add("@ModifiedDate", department.ModifiedDate);
        //    parameters.Add("@ModifiedBy", department.ModifiedBy);
        //    parameters.Add("@DepartmentID", departmentID);
        //    //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //    var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //    //Trả về kết quả
        //    return result;
        //}
       
    }
}
