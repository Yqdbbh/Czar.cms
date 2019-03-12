using Czar.Cms.IRepository;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; //GetService<T>
using System.Collections.Generic;
using System.Text;
using Xunit;
using Czar.Cms.Models;
using System.Linq;

namespace Czar.Cms.Test
{
    public class TestBaseRepostory
    {
        [Fact]
        public void BaseRepostoryTest()
        {
            IServiceProvider serviceProvider = Common.BuildService();
            IarticlecategoryRepository iarticlecategory = serviceProvider.GetService<IarticlecategoryRepository>();
            var category1 = new articlecategory
            {
                TITLE = "随笔",
                PARENTID = 0,
                CLASSLAYER = 0,
                CLASSLIST = "",
                SORT = 0,
                IMAGEURL = "",
                SEOTITLE = "随笔seoTitle",
                SEODESCRIPTION = "随笔SeoDescription",
                SEOKEYWORDS = "随笔SeoKeyWord",
                ISDELETED = 0,
            };
            var category2 = new articlecategory
            {
                TITLE = "散文",
                PARENTID = 0,
                CLASSLAYER = 0,
                CLASSLIST = "",
                SORT = 0,
                IMAGEURL = "",
                SEOTITLE = "散文seoTitle",
                SEODESCRIPTION = "散文SeoDescription",
                SEOKEYWORDS = "散文SeoKeyWord",
                ISDELETED = 0,
            };
            var category3 = new articlecategory
            {
                TITLE = "诗歌",
                PARENTID = 0,
                CLASSLAYER = 0,
                CLASSLIST = "",
                SORT = 0,
                IMAGEURL = "",
                SEOTITLE = "诗歌seoTitle",
                SEODESCRIPTION = "诗歌SeoDescription",
                SEOKEYWORDS = "诗歌SeoKeyWord",
                ISDELETED = 0,
            };
            var category1id = iarticlecategory.Insert(category1);
            var category2id = iarticlecategory.Insert(category2);
            var category3id = iarticlecategory.Insert(category3);
            var categorylist = iarticlecategory.GetList();
            Assert.True(3 == categorylist.Count());
        }

    }
}
