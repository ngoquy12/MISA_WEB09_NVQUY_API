using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.BL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Craeted By: NVQUY(13/11/2022)
        public IEnumerable<T> GetAllRecords();
        /// <summary>
        /// Lấy thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin của một bản ghi</returns>
        /// Created By: NVQUY(13/11/2022)
        public T GetRecordByID(Guid recordID);
        /// <summary>
        /// Xóa thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>1: Nếu xoá thành công, 0: Nếu xóa thất bại</returns>
        /// Created By : NVQUY(13/11/2022)
        public int DeleteRecordByID(Guid recordID);
    }
}
