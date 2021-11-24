using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Categories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services.levelListServices
{
    public class CreateLevelList
    {
        /// <summary>
        /// Create List category with level
        /// </summary>
        /// <param name="source">List<Category></param>
        /// <param name="prefix">Character to create level</param>
        /// <param name="hasNonParentItemt"></param>
        /// <returns></returns>
        public List<CategoryModel> CreateList(List<CategoryModel> source, bool hasNonParentItemt = false, string prefix = "&emsp;&emsp;")
        {
            var sourceListModel = source.Where(m => m.ParentCategoryId == null).ToList();

            var listResult = new List<CategoryModel>();

            if (hasNonParentItemt)
            {
                listResult.Add(new CategoryModel() { Id = -1, Title = "Không có danh mục cha" });
            }

            RenameAddResult(sourceListModel, listResult, prefix);

            return listResult;
        }

        public void RemoveChildren(CategoryModel removeModel, List<CategoryModel> source)
        {
            source.RemoveAll(c => c.Id == removeModel.Id);

            if (removeModel.CategoryChildren != null)
            {
                foreach(CategoryModel model in removeModel.CategoryChildren)
                {
                    RemoveChildren(model, source);
                }
            }
        }

        private void RenameAddResult(List<CategoryModel> source, List<CategoryModel> destination, string prefix, int level = 0)
        {
            string thisPrefix = string.Concat(Enumerable.Repeat(prefix, level));

            foreach (CategoryModel model in source)
            {
                destination.Add(new CategoryModel()
                {
                    Id = model.Id,
                    Title = thisPrefix + model.Title,
                    Content = model.Content,
                    Slug = model.Slug,
                    CategoryChildren = model.CategoryChildren,
                    ParentCategoryId = model.ParentCategoryId,
                    ParentCategory = model.ParentCategory
                });

                if (model.CategoryChildren != null)
                {
                    RenameAddResult(model.CategoryChildren, destination, prefix, level + 1);
                }
            }
        }
    }
}
