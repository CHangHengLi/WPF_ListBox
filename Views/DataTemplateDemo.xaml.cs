using System.Collections.Generic;
using System.Windows.Controls;

namespace ListBoxDemo.Views
{
    public partial class DataTemplateDemo : UserControl
    {
        public DataTemplateDemo()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            // 初始化简单字符串数据源
            List<string> simpleItems = new List<string>
            {
                "项目1",
                "项目2",
                "项目3",
                "项目4",
                "项目5"
            };
            SimpleTemplateListBox.ItemsSource = simpleItems;

            // 初始化复杂数据项
            InitializeColorItems();
        }

        private void InitializeColorItems()
        {
            var items = new List<ColorItem>
            {
                new ColorItem { Name = "红色", Description = "热情、活力的基本色", Color = "Red", RgbValue = "255, 0, 0" },
                new ColorItem { Name = "绿色", Description = "代表生命和希望的色彩", Color = "Green", RgbValue = "0, 255, 0" },
                new ColorItem { Name = "蓝色", Description = "沉稳冷静的代表色", Color = "Blue", RgbValue = "0, 0, 255" },
                new ColorItem { Name = "黄色", Description = "明亮快乐的色彩", Color = "Yellow", RgbValue = "255, 255, 0" },
                new ColorItem { Name = "紫色", Description = "神秘高贵的组合色", Color = "Purple", RgbValue = "128, 0, 128" }
            };
            
            ComplexTemplateListBox.ItemsSource = items;
        }
    }

    public class ColorItem
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string RgbValue { get; set; } = string.Empty;
    }
} 