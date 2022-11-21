using MISA.AMIS.KeToan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.DL
{
    public interface IBaseDL<T>
    {
        #region Method
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
       /// <summary>
       /// Thêm mới một bản ghi
       /// </summary>
       /// <param name="objects">Đối tượng cần được thêm mới</param>
       /// <returns>ID của đối tượng được thêm mới</returns>
       /// Created By : NVQUY(13/11/2022)
        public IEnumerable<T> InsertRecord(T objects);
       /// <summary>
       /// Cập nhật một bản ghi theo ID
       /// </summary>
       /// <param name="objects">Đối tượng cần cập nhật</param>
       /// <param name="recodID">Id của đối tượng cần cập nhật</param>
       /// <returns>1: Nếu cập nhật thành công, 0: Nếu cập nhật thất bại</returns>
       /// Created By : NVQUY(13/11/2022)
        public IEnumerable<T> UpdateRecord(T objects, Guid recodID);

        #endregion

    }
}
