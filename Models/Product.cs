namespace ListBoxDemo.Models
{
    /// <summary>
    /// 产品模型类，用于展示ListBox的数据绑定、分组和排序功能
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 产品类别，用于数据分组示例
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// 产品图片路径
        /// </summary>
        public string ImagePath { get; set; } = string.Empty;
    }
} 