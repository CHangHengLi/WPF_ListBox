using ListBoxDemo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListBoxDemo.Views
{
    public partial class EditableItemsDemo : UserControl
    {
        public EditableItemsDemo()
        {
            InitializeComponent();
        }

        private void EditTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is EditableItem item)
            {
                if (e.Key == Key.Enter)
                {
                    // 保存编辑并结束编辑状态
                    item.IsEditing = false;
                    e.Handled = true;
                }
                else if (e.Key == Key.Escape)
                {
                    // 取消编辑
                    item.IsEditing = false;
                    e.Handled = true;
                }
            }
        }

        private void EditTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is EditableItem item)
            {
                // 当文本框失去焦点时结束编辑状态
                item.IsEditing = false;
            }
        }
    }
} 