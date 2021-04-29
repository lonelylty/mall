using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Heals.CSX.Mall.Models
{
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 创建失败
        /// </summary>
        [Description("创建失败")]
        CreateFail = 400001,

        /// <summary>
        /// 修改失败
        /// </summary>
        [Description("修改失败")]
        UpdateFail = 400002,

        /// <summary>
        /// 删除失败
        /// </summary>
        [Description("删除失败")]
        DeleteFail = 400003,

        /// <summary>
        /// 登录失败
        /// </summary>
        [Description("登录失败")]
        LoginFail = 400004,


        /// <summary>
        /// 参数格式错误
        /// </summary>
        [Description("参数格式错误")]
        FormatError = 400005,

        /// <summary>
        /// 无数据
        /// </summary>
        [Description("无数据")]
        Empty = 400006,

        /// <summary>
        /// 未授权
        /// </summary>
        [Description("未授权")]
        Unauthorized = 400007,

        /// <summary>
        /// 数据库异常
        /// </summary>
        [Description("数据库异常")]
        DataBaseError = 400008,

        /// <summary>
        /// 用户数据错误
        /// </summary>
        [Description("用户数据错误")]
        UserData = 400009,

        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        SystemException = 400010,

        /// <summary>
        /// 未知错误
        /// </summary>
        [Description("未知错误")]
        Unknown = 400011,

        /// <summary>
        /// 修改密码失败
        /// </summary>
        [Description("修改密码失败")]
        ModifyPasswordFail = 400012,

        /// <summary>
        /// 主键重复
        /// </summary>
        [Description("主键重复")]
        DuplicateKey = 400013,

        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误")]
        VerificationCode = 400014

    }
}
