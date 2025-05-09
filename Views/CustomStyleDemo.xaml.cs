using System.Collections.Generic;
using System.Windows.Controls;

namespace ListBoxDemo.Views
{
    public partial class CustomStyleDemo : UserControl
    {
        public CustomStyleDemo()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            List<string> items = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                items.Add($"样式示例项 {i}");
            }

            StyledListBox.ItemsSource = items;
            AlternatingListBox.ItemsSource = items;
        }
    }
} 