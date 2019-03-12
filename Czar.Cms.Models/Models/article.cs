/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章表                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 16:31:15                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：article                                     
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
	/// 文章表
	/// </summary>
	[Table("article")]
	public class article
	{
		/// <summary>
		/// 添加人ID
		/// <summary>
		[Required]
		public Int32 ADDMANAGERID { get; set;}

		/// <summary>
		/// 添加时间
		/// <summary>
		[Required]
		public DateTime ADDTIME { get; set;}

		/// <summary>
		/// 作者
		/// <summary>
		[MaxLength(64)]
		public String AUTHOR { get; set;}

		/// <summary>
		/// 分类ID
		/// <summary>
		[Required]
		public Int32 CATEGORYID { get; set;}

		/// <summary>
		/// 文章内容
		/// <summary>
		[MaxLength(65535)]
		public String CONTENT { get; set;}

		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 图片地址
		/// <summary>
		[MaxLength(128)]
		public String IMAGEURL { get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public Int64 ISDELETED { get; set;}

		/// <summary>
		/// 是否发布
		/// <summary>
		[Required]
		public Int64 ISPUBLISH { get; set;}

		/// <summary>
		/// 是否热门
		/// <summary>
		[Required]
		public Int64 ISRED { get; set;}

		/// <summary>
		/// 是否轮播显示
		/// <summary>
		[Required]
		public Int64 ISSLIDE { get; set;}

		/// <summary>
		/// 是否置顶
		/// <summary>
		[Required]
		public Int64 ISTOP { get; set;}

		/// <summary>
		/// 修改人ID
		/// <summary>
		public Int32? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public DateTime? MODIFYTIME { get; set;}

		/// <summary>
		/// SEO描述
		/// <summary>
		[MaxLength(512)]
		public String SEODESCRIPTION { get; set;}

		/// <summary>
		/// SEO关键字
		/// <summary>
		[MaxLength(256)]
		public String SEOKEYWORD { get; set;}

		/// <summary>
		/// SEO标题
		/// <summary>
		[MaxLength(128)]
		public String SEOTITLE { get; set;}

		/// <summary>
		/// 排序
		/// <summary>
		[Required]
		public Int32 SORT { get; set;}

		/// <summary>
		/// 来源
		/// <summary>
		[MaxLength(128)]
		public String SOURCE { get; set;}

		/// <summary>
		/// 文章标题
		/// <summary>
		[Required]
		[MaxLength(128)]
		public String TITLE { get; set;}

		/// <summary>
		/// 浏览次数
		/// <summary>
		[Required]
		public Int32 VIEWCOUNT { get; set;}


	}
}
