namespace MISA.AMIS.KeToan.Common
{
    public class ErrorService
    {
        /// <summary>
        /// Mã mỗi
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Thông báo lỗi cho dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// Thông báo lỗi cho người dùng
        /// </summary>
        public string UserMsg { get; set; }
        /// <summary>
        /// Thông tin chi tiết exception
        /// </summary>
        public string MoreInfo { get; set; }
        /// <summary>
        /// Id lỗi exception
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// Trả về đối tượng bao gồm các lỗi xảy ra
        /// </summary>
        public Object Data { get; set; }  
    }
}
