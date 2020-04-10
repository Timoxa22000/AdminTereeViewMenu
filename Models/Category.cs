using System.Collections.Generic;

namespace AdminTereeViewMenu.Models
{
    /// <summary>
    /// Категория товаров
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id категории
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Дочерние категории
        /// </summary>
        public virtual IEnumerable<Category> ChildCategories { get; set; }

        public Category()
        {
            ChildCategories = new List<Category>();
        }

        /// <summary>
        /// Является-ли категория базовой
        /// </summary>
        public bool Base { get; set; } = false;
    }
}
