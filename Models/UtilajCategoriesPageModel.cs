using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Models
{
    public class UtilajCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectBunContext context,
        Utilaj utilaj)
        {
            var allCategories = context.Category;
            var utilajCategories = new HashSet<int>(
            utilaj.UtilajCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = utilajCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateUtilajCategories(ProiectBunContext context,
        string[] selectedCategories, Utilaj utilajToUpdate)
        {
            if (selectedCategories == null)
            {
                utilajToUpdate.UtilajCategories = new List<UtilajCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var utilajCategories = new HashSet<int>
            (utilajToUpdate.UtilajCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!utilajCategories.Contains(cat.ID))
                    {
                        utilajToUpdate.UtilajCategories.Add(
                        new UtilajCategory
                        {
                            UtilajID = utilajToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (utilajCategories.Contains(cat.ID))
                    {
                        UtilajCategory courseToRemove
                        = utilajToUpdate
                        .UtilajCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}