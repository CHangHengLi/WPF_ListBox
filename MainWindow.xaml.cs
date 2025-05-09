using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using ListBoxDemo.ViewModels;

namespace ListBoxDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateListBoxByCode_Click(object sender, RoutedEventArgs e)
    {
        // 创建ListBox控件
        ListBox myListBox = new ListBox();
        myListBox.Width = 200;
        myListBox.Height = 150;

        // 添加项目
        myListBox.Items.Add("项目1");
        myListBox.Items.Add("项目2");
        myListBox.Items.Add("项目3");
        myListBox.Items.Add("项目4");
        myListBox.Items.Add("项目5");

        // 将ListBox添加到容器中
        CodeCreatedListBoxContainer.Child = myListBox;
    }

    private void GetSelections_Click(object sender, RoutedEventArgs e)
    {
        // 获取单选模式的选择
        if (SingleSelectionListBox.SelectedItem != null)
        {
            if (SingleSelectionListBox.SelectedItem is ListBoxItem item && item.Content != null)
            {
                SingleSelectionResult.Text = item.Content.ToString();
            }
            else
            {
                SingleSelectionResult.Text = "无";
            }
        }
        else
        {
            SingleSelectionResult.Text = "无";
        }

        // 获取多选模式的选择
        if (MultipleSelectionListBox.SelectedItems.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var selectedItem in MultipleSelectionListBox.SelectedItems)
            {
                if (selectedItem is ListBoxItem item && item.Content != null)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(item.Content.ToString());
                }
            }
            MultipleSelectionResult.Text = sb.Length > 0 ? sb.ToString() : "无";
        }
        else
        {
            MultipleSelectionResult.Text = "无";
        }

        // 获取扩展选择模式的选择
        if (ExtendedSelectionListBox.SelectedItems.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var selectedItem in ExtendedSelectionListBox.SelectedItems)
            {
                if (selectedItem is ListBoxItem item && item.Content != null)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(item.Content.ToString());
                }
            }
            ExtendedSelectionResult.Text = sb.Length > 0 ? sb.ToString() : "无";
        }
        else
        {
            ExtendedSelectionResult.Text = "无";
        }
    }

    /// <summary>
    /// TabControl选择变更事件处理，用于同步更新ViewModel中的SelectedIndex属性
    /// </summary>
    /// <param name="sender">事件源</param>
    /// <param name="e">事件参数</param>
    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // 确保DataContext是MainViewModel类型
        if (DataContext is MainViewModel viewModel)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                // 同步TabControl的选中索引到ViewModel
                viewModel.SelectedIndex = tabControl.SelectedIndex;
            }
        }
    }

    /// <summary>
    /// 处理多选模式ListBox的鼠标按下事件，确保只有在按住Ctrl键时才能多选
    /// </summary>
    private void MultipleSelectionListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        // 如果没有按住Ctrl键，强制使用单选行为
        if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
        {
            ListBoxItem item = ItemsControl.ContainerFromElement((ListBox)sender, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                MultipleSelectionListBox.SelectedItems.Clear();
                item.IsSelected = true;
                e.Handled = true;
            }
        }
    }
}