/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：管理日志                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 16:31:15                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：managerlog                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// 复制自yilezhu
	/// 2019-03-12 16:31:15
	/// 管理日志
	/// </summary>
	[Table("managerlog")]
	public class managerlog
	{
		/// <summary>
		/// 操作类型
		/// <summary>
		[MaxLength(32)]
		public String ACTIONTYPE { get; set;}

		/// <summary>
		/// 操作IP
		/// <summary>
		[MaxLength(64)]
		public String ADDIP { get; set;}

		/// <summary>
		/// 操作人ID
		/// <summary>
		[Required]
		public Int32 ADDMANAGEID { get; set;}

		/// <summary>
		/// 操作人名称
		/// <summary>
		[MaxLength(64)]
		public String ADDMANAGERNICKNAME { get; set;}

		/// <summary>
		/// 操作时间
		/// <summary>
		[Required]
		public DateTime ADDTIME { get; set;}

		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 备注
		/// <summary>
		[MaxLength(256)]
		public String REMARK { get; set;}


	}
}
