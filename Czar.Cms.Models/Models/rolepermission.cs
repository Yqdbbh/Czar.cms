/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：角色权限表                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 16:31:15                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：rolepermission                                     
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
	/// 角色权限表
	/// </summary>
	[Table("rolepermission")]
	public class rolepermission
	{
		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 菜单主键
		/// <summary>
		[Required]
		public Int32 MENUID { get; set;}

		/// <summary>
		/// 操作类型（功能权限）
		/// <summary>
		[MaxLength(128)]
		public String PERMISSION { get; set;}

		/// <summary>
		/// 角色主键
		/// <summary>
		[Required]
		public Int32 ROLEID { get; set;}


	}
}
