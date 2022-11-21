using Dapper;
using MISA.AMIS.KeToan.Common;
using MySqlConnector;


namespace MISA.AMIS.KeToan.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {   
        #region Method
        /// <summary>
        /// Lấy thông tin tất cả bản ghỉ
        /// </summary>
        /// <returns>Thông tin tất cả bản ghi</returns>
        /// Created By : NVQUY(13/11/2022)
        public IEnumerable<T> GetAllRecords()
        {
            //Khởi tạo kết nối tới Db MySQL
            string storedProcedureName = String.Format(Procudure.GET_ALL, typeof(T).Name);
            // Chuẩn bị câu lệnh SQL
            var records = new List<T>();
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
                records = (List<T>)mysqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
            //Trả về dữ liệu 
            return records;
        }

        /// <summary>
        /// Lấy thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="employeeID">ID của bản ghi muốn lấy</param>
        /// <returns>Thông tin của một bản ghi</returns>
        /// Created By: NVQUY(13/11/2022)
        public T GetRecordByID(Guid recordID)
        {

            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procudure.GET_BY_ID, typeof(T).Name);
            //Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);
            //Khởi tạo kết nối tới Db MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
                var employee = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                //Thực hiện trả về giá trị
                return employee;
            }
        }
        /// <summary>
        /// Xóa thông tin một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>1: Nếu xoá thành công, 0: Nếu xóa thất bại</returns>
        /// Created By : NVQUY(13/11/2022)
        public int DeleteRecordByID(Guid recordID)
        {
            // Chuẩn bị câu lệnh SQL
            string storedProcedureName = String.Format(Procudure.DELETE_BY_ID, typeof(T).Name);
            //Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);
            //Khởi tạo kết nối tới Db MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
                var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                //Thực hiện trả về giá trị
                return result;
            }
        }

        public IEnumerable<T> InsertRecord(T objects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> UpdateRecord(T objects, Guid recodID)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<T> InsertRecord(T objects)
        //{
        //    // Chuẩn bị câu lệnh SQL
        //    string storedProcedureName = String.Format(Procudure.INSERT, typeof(T).Name);
        //    //Chuẩn bị tham số đầu vào 
        //    var parameters = new DynamicParameters();
        //    parameters.Add($"@{typeof(T).Name}ID", recordID);
        //    //Khởi tạo kết nối tới Db MySQL
        //    using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
        //    {
        //        //Thực hiện gọi vào DB để chạy lệnh SQL với tham số đầu vào ở trên
        //        var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //        //Thực hiện trả về giá trị
        //        return result;
        //    }
        //}
        #endregion
    }
}


