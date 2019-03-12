/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章分类                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 18:05:41                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：articlecategory                                     
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
	/// 文章分类
	/// </summary>
	[Table("articlecategory")]
	public class articlecategory
	{
		/// <summary>
		/// 类别深度
		/// <summary>
		public Int32? CLASSLAYER { get; set;}

		/// <summary>
		/// 类别ID列表(逗号分隔开)
		/// <summary>
		[MaxLength(128)]
		public String CLASSLIST { get; set;}

		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 分类图标
		/// <summary>
		[MaxLength(128)]
		public String IMAGEURL { get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public Int64 ISDELETED { get; set;}

		/// <summary>
		/// 父分类ID
		/// <summary>
		[Required]
		public Int32 PARENTID { get; set;}

		/// <summary>
		/// 分类SEO描述
		/// <summary>
		[MaxLength(512)]
		public String SEODESCRIPTION { get; set;}

		/// <summary>
		/// 分类SEO关键字
		/// <summary>
		[MaxLength(256)]
		public String SEOKEYWORDS { get; set;}

		/// <summary>
		/// 分类SEO标题
		/// <summary>
		[MaxLength(128)]
		public String SEOTITLE { get; set;}

		/// <summary>
		/// 排序
		/// <summary>
		[Required]
		public Int32 SORT { get; set;}

		/// <summary>
		/// 分类标题
		/// <summary>
		[Required]
		[MaxLength(128)]
		public String TITLE { get; set;}


	}
}
