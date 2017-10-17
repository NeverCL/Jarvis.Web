using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Jarvis.Core.Module;
using Module.Domain.Entities;

namespace Jarvis.Core.Company
{
    /// <summary>
    /// 企业信息
    /// </summary>
    public class Company : CreateEntity
    {
        /// <summary>
        /// 第三方唯一编码
        /// </summary>
        public string ThirdCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 统一信用代码
        /// </summary>
        [StringLength(128)]
        public string TrustCode { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [StringLength(128)]
        public string Mobile { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(128)]
        public string Address { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        [StringLength(128)]
        public string Site { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        [StringLength(128)]
        public string LegalUser { get; set; }

        /// <summary>
        /// 注册资金
        /// </summary>
        [StringLength(128)]
        public string RegisteredCapital { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisteredTime { get; set; }
    }
}
