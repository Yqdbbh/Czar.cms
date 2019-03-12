/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 16:31:15                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：comment                                     
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
	/// 
	/// </summary>
	[Table("comment")]
	public class comment
	{
		[Required]
		public DateTime add_time { get; set;}

		[Required]
		[MaxLength(255)]
		public String content { get; set;}

		[Required]
		public Int32 content_id { get; set;}

		[Key]
		public Int32 Id{ get; set;}


	}
}
