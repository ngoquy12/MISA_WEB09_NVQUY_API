using Dapper;
using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.Common.Resources;
using System.Collections.Generic;
using System;


namespace MISA.AMIS.KeToan.DL
{
    public interface IEmployeeDL : IBaseDL<Employee>
    {
        /// <summary>
        /// api lấy danh sách nhân viên theo bộ lọc và phân trang
        /// </summary>
        /// <param name = "keyword" > từ khóa muốn tìm kiếm</param>
        /// <param name = "limit" > số bản ghi muốn lấy</param>
        /// <param name = "offset" > vị trí bắt đầu lấy</param>
        /// <returns>danh sách nhân viên và tổng số bản mghi</returns>
        /// created by : nvquy(13/11/2022)
        public PagingResult getEmployeeByFilterAndPaging(
                string? keyword,
                int limit = 10,
                int offset = 0);
        /// <summary>
        ///API xóa nhiều nhân viên theo id
        /// </summary>
        /// <param name="listemployeeid">danh sách id của những nhân viên cần xóa</param>
        /// <returns>status code 200 và số lượng bản ghi đã xóa/returns>
        /// created by : nvquy(3/11/2022)
        public int deleteMultipleEmployee(ListEmployeeID listEmployeeID);
    }
}


