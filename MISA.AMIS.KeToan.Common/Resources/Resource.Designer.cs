﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.AMIS.KeToan.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.AMIS.KeToan.Common.Resources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Catched an exception.
        /// </summary>
        public static string DevMsg_Exception {
            get {
                return ResourceManager.GetString("DevMsg_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ngày sinh không được lớn hơn ngày hiện tại.
        /// </summary>
        public static string Error_DateOfBirth {
            get {
                return ResourceManager.GetString("Error_DateOfBirth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã phòng ban đã tồn tại.
        /// </summary>
        public static string Error_DepartmentCodeNotDuplicates {
            get {
                return ResourceManager.GetString("Error_DepartmentCodeNotDuplicates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã đơn vị không được phép để trống.
        /// </summary>
        public static string Error_DepartmentCodeNotEmpty {
            get {
                return ResourceManager.GetString("Error_DepartmentCodeNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên đơn vị không được phép để trống.
        /// </summary>
        public static string Error_DepartmentNameNotEmpty {
            get {
                return ResourceManager.GetString("Error_DepartmentNameNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email không đúng định dạng.
        /// </summary>
        public static string Error_EmailNotValidate {
            get {
                return ResourceManager.GetString("Error_EmailNotValidate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên đã tồn tại.
        /// </summary>
        public static string Error_EmployeeCodeNotDuplicates {
            get {
                return ResourceManager.GetString("Error_EmployeeCodeNotDuplicates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên không được phép để trống.
        /// </summary>
        public static string Error_EmployeeCodeNotEmpty {
            get {
                return ResourceManager.GetString("Error_EmployeeCodeNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên nhân viên không được phép để trống.
        /// </summary>
        public static string Error_EmployeeNameNotEmpty {
            get {
                return ResourceManager.GetString("Error_EmployeeNameNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp.
        /// </summary>
        public static string Error_Exception {
            get {
                return ResourceManager.GetString("Error_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu truyền vào không hợp lệ.
        /// </summary>
        public static string Error_Validate {
            get {
                return ResourceManager.GetString("Error_Validate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://openapi.misa.com.vn/errorcode/misa-001.
        /// </summary>
        public static string MoreInfo_Exception {
            get {
                return ResourceManager.GetString("MoreInfo_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra! Vui lòng liên hệ với MISA để được trợ giúp.
        /// </summary>
        public static string UserMsg_Exception {
            get {
                return ResourceManager.GetString("UserMsg_Exception", resourceCulture);
            }
        }
    }
}
