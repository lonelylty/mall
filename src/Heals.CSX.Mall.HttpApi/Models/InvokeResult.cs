using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Heals.CSX.Mall.Models
{
    public class InvokeResult<T> : IActionResult
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public ErrorCode Code { get; set; } = ErrorCode.Success;


        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 审计数据
        /// </summary>
        [JsonIgnore]
        public object DataForAudit { get; set; }

        /// <summary>
        /// 初始化一个对象 ResultDto 实例
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public InvokeResult(T data = default, ErrorCode code = ErrorCode.Success, string message = null)
        {
            Data = data;
            Code = code;
            Message = (message ?? ((Enum)(object)code).GetDescription());
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = 200;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            await response.WriteAsync(JsonConvert.SerializeObject(this, settings), default);
        }
    }
}
