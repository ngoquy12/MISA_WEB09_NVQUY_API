using Dapper;
using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.Common.Resources;
using MySqlConnector;

namespace MISA.AMIS.KeToan.DL.DepartmentDL
{
    public interface IDepartmentDL : IBaseDL<Department>
    {
        ///// <summary>
        /////API Thấy thông tin của tất cả phòng ban
        ///// </summary>
        ///// <returns>Danh sách nhân viên</returns>
        ///// Created By: NVQUY(3/11/2022)
        //public IEnumerable<dynamic> GetAllDepartment();

        ///// <summary>
        /////API Lấy thông tin phòng ban theo ID 
        ///// </summary>
        ///// <returns>Thông tin 1 phòng ban</returns>
        ///// Created By : NVQUY(3/11/2022)
        //public Department GetDepartmentByID(Guid departmentID);

        ///// <summary>
        ///// API Thêm mới một phòng ban
        ///// </summary>
        ///// <param name"department"></param>
        ///// <returns>Mã phòng ban vừa được thêm</returns>

        //public int InsertDepartment(Department department);
        ///// <summary>
        ///// API sửa thông tin phòng ban theo ID
        ///// </summary>
        ///// <param name="departmentID">Mã phòng ban muốn sửa</param>
        ///// <param name="department">Đối tượng phòng ban muốn sửa</param>
        ///// <returns>1: Nếu cập nhật thành công, 0: Nếu cập nhật thất bại</returns>
        ///// Created by : NVQUY(3/11/2022)
        //public int UpdateDepartmentByID(Guid departmentID, Department department);
    }
}
