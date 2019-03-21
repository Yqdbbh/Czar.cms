/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：管理员角色表                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 18:05:41                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：managerrole                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// 复制自yilezhu
	/// 2019-03-12 18:05:41
	/// 管理员角色表
	/// </summary>
	[Table("managerrole")]
	public class managerrole
	{
		/// <summary>
		/// 添加人
		/// <summary>
		[Required]
		public Int32 ADDMANAGERID { get; set;}

		/// <summary>
		/// 添加时间
		/// <summary>
		[Required]
		public DateTime ADDTIME { get; set;}

		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public Int64 ISDELETE { get; set;}

		/// <summary>
		/// 是否系统默认
		/// <summary>
		[Required]
		public Int64 ISSYSTEM { get; set;}

		/// <summary>
		/// 修改人
		/// <summary>
		public Int32? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public DateTime? MODIFYTIME { get; set;}

		/// <summary>
		/// 备注
		/// <summary>
		[MaxLength(128)]
		public String REMARK { get; set;}

		/// <summary>
		/// 角色名称
		/// <summary>
		[Required]
		[MaxLength(64)]
		public String ROLENAME { get; set;}

		/// <summary>
		/// 角色类型1超管2系管
		/// <summary>
		[Required]
		public Int32 ROLETYPE { get; set;}

        /// <summary>
        /// 菜单ID数组  
        /// </summary>
        public virtual int[] MenuIds { get; set; }
    }
}
