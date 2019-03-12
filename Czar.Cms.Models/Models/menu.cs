/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：菜单表                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 18:05:41                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：menu                                     
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
	/// 菜单表
	/// </summary>
	[Table("menu")]
	public class menu
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
		/// 显示名称
		/// <summary>
		[MaxLength(128)]
		public String DISPLAYNAME { get; set;}

		/// <summary>
		/// 图标地址
		/// <summary>
		[MaxLength(128)]
		public String ICONURL { get; set;}

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
		/// 是否显示
		/// <summary>
		[Required]
		public Int64 ISDISPLAY { get; set;}

		/// <summary>
		/// 是否系统默认
		/// <summary>
		[Required]
		public Int64 ISSYSTEM { get; set;}

		/// <summary>
		/// 链接地址
		/// <summary>
		[MaxLength(128)]
		public String LINKURL { get; set;}

		/// <summary>
		/// 修改人
		/// <summary>
		public Int32? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public DateTime? MODIFYTIME { get; set;}

		/// <summary>
		/// 名称
		/// <summary>
		[Required]
		[MaxLength(32)]
		public String NAME { get; set;}

		/// <summary>
		/// 父菜单ID
		/// <summary>
		[Required]
		public Int32 PARENTID { get; set;}

		/// <summary>
		/// 操作权限（按钮权限时使用）
		/// <summary>
		[MaxLength(256)]
		public String PERMISSION { get; set;}

		/// <summary>
		/// 排序数字
		/// <summary>
		public Int32? SORT { get; set;}


	}
}
