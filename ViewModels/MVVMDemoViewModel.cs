using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// MVVM模式演示ViewModel，展示如何在MVVM模式下使用ListBox实现增删改查功能
    /// </summary>
    public class MVVMDemoViewModel : ViewModelBase
    {
        // 列表项集合
        private ObservableCollection<ListItem> _items = new();
        // 当前选中的列表项
        private ListItem? _selectedItem;

        /// <summary>
        /// 构造函数，初始化示例数据和命令
        /// </summary>
        public MVVMDemoViewModel()
        {
            // 初始化一些示例数据
            for (int i = 1; i <= 10; i++)
            {
                _items.Add(new ListItem { Id = i, Title = $"项目 {i}" });
            }

            // 初始化命令
            AddItemCommand = new RelayCommand(AddNewItem);
            RemoveItemCommand = new RelayCommand<ListItem>(RemoveItem, CanRemoveItem);
            
            // 默认选中第一个项目
            SelectedItem = Items.FirstOrDefault();
        }

        /// <summary>
        /// 列表项集合属性
        /// </summary>
        public ObservableCollection<ListItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        /// <summary>
        /// 当前选中的列表项属性
        /// 当选中项变化时，可以触发其他业务逻辑
        /// </summary>
        public ListItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value) && value != null)
                {
                    // 此处可以添加选择变更后的业务逻辑
                    Console.WriteLine($"选中了: {value.Title}");
                }
            }
        }

        /// <summary>
        /// 添加项目命令
        /// </summary>
        public ICommand AddItemCommand { get; }

        /// <summary>
        /// 移除项目命令
        /// </summary>
        public ICommand RemoveItemCommand { get; }

        /// <summary>
        /// 添加新项目方法
        /// 创建一个ID自增的新项目并添加到集合
        /// </summary>
        private void AddNewItem()
        {
            // 找出当前最大ID并加1作为新项目的ID
            int nextId = Items.Count > 0 ? Items.Max(i => i.Id) + 1 : 1;
            Items.Add(new ListItem { Id = nextId, Title = $"新项目 {nextId}" });
        }

        /// <summary>
        /// 移除项目方法
        /// </summary>
        /// <param name="item">要移除的项目</param>
        private void RemoveItem(ListItem item)
        {
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        /// <summary>
        /// 判断项目是否可以移除
        /// </summary>
        /// <param name="item">要检查的项目</param>
        /// <returns>如果项目不为null，则可以移除</returns>
        private bool CanRemoveItem(ListItem item)
        {
            return item != null;
        }
    }

    /// <summary>
    /// 列表项模型类，用于MVVM模式演示
    /// </summary>
    public class ListItem
    {
        /// <summary>
        /// 列表项ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 列表项标题
        /// </summary>
        public string Title { get; set; } = string.Empty;
    }
} 