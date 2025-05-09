using ListBoxDemo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// 可编辑项目的ViewModel，用于管理可编辑列表项示例
    /// 展示如何实现ListBox中项目的编辑、添加和删除功能
    /// </summary>
    public class EditableItemsViewModel : ViewModelBase
    {
        // 可编辑项目集合
        private ObservableCollection<EditableItem> _editableItems = new();

        /// <summary>
        /// 可编辑项目集合属性
        /// </summary>
        public ObservableCollection<EditableItem> EditableItems
        {
            get => _editableItems;
            set => SetProperty(ref _editableItems, value);
        }

        /// <summary>
        /// 编辑命令，将项目切换到编辑状态
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// 添加命令，添加新的可编辑项目
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// 删除命令，删除指定的可编辑项目
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// 构造函数，初始化示例数据和命令
        /// </summary>
        public EditableItemsViewModel()
        {
            // 初始化一些示例数据
            for (int i = 1; i <= 5; i++)
            {
                EditableItems.Add(new EditableItem { Text = $"项目 {i}" });
            }

            // 初始化命令
            EditCommand = new RelayCommand<EditableItem>(EditItem);
            AddCommand = new RelayCommand(AddItem);
            DeleteCommand = new RelayCommand<EditableItem>(DeleteItem);
        }

        /// <summary>
        /// 编辑项目方法，将指定项目切换到编辑状态
        /// </summary>
        /// <param name="item">要编辑的项目</param>
        private void EditItem(EditableItem item)
        {
            if (item != null)
            {
                item.IsEditing = true;
            }
        }

        /// <summary>
        /// 添加项目方法，创建新项目并添加到集合
        /// </summary>
        private void AddItem()
        {
            int count = EditableItems.Count;
            EditableItems.Add(new EditableItem { Text = $"新项目 {count + 1}" });
        }

        /// <summary>
        /// 删除项目方法，从集合中移除指定项目
        /// </summary>
        /// <param name="item">要删除的项目</param>
        private void DeleteItem(EditableItem item)
        {
            if (item != null)
            {
                EditableItems.Remove(item);
            }
        }
    }
} 