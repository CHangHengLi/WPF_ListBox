using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// 主窗口的ViewModel，管理主界面的数据和导航
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        // 当前选中的演示项目

        private DemoItem? _selectedDemo;
        // 当前选中的索引
        private int _selectedIndex;
        // 所有演示项目的集合
        private ObservableCollection<DemoItem> _demos = new();

        /// <summary>
        /// 构造函数，初始化演示数据
        /// </summary>
        public MainViewModel()
        {
            InitializeDemos();
        }

        /// <summary>
        /// 所有演示项目的集合，用于左侧列表显示
        /// </summary>
        public ObservableCollection<DemoItem> Demos
        {
            get => _demos;
            set => SetProperty(ref _demos, value);
        }

        /// <summary>
        /// 当前选中的演示项目，用于控制右侧内容区域显示的内容
        /// 通过绑定到TabControl的SelectedIndex实现导航功能
        /// </summary>
        public DemoItem? SelectedDemo
        {
            get => _selectedDemo;
            set
            {
                if (SetProperty(ref _selectedDemo, value))
                {
                    // 当SelectedDemo变化时，同步更新SelectedIndex
                    if (_selectedDemo != null)
                    {
                        SelectedIndex = Demos.IndexOf(_selectedDemo);
                    }
                }
            }
        }

        /// <summary>
        /// 当前选中项目的索引，用于绑定到TabControl的SelectedIndex
        /// </summary>
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    // 当SelectedIndex变化时，同步更新SelectedDemo
                    if (_selectedIndex >= 0 && _selectedIndex < Demos.Count)
                    {
                        _selectedDemo = Demos[_selectedIndex];
                        OnPropertyChanged(nameof(SelectedDemo));
                    }
                }
            }
        }

        /// <summary>
        /// 初始化所有演示项目数据
        /// </summary>
        private void InitializeDemos()
        {
            // 添加各种ListBox功能演示项目
            Demos.Add(new DemoItem { Title = "基本用法", Description = "ListBox的基本创建和使用方式" });
            Demos.Add(new DemoItem { Title = "选择模式", Description = "不同的选择模式：单选、多选、扩展选择" });
            Demos.Add(new DemoItem { Title = "数据模板", Description = "使用DataTemplate自定义ListBox项的外观" });
            Demos.Add(new DemoItem { Title = "复杂对象绑定", Description = "如何绑定复杂对象集合到ListBox" });
            Demos.Add(new DemoItem { Title = "数据分组", Description = "使用CollectionView实现数据分组" });
            Demos.Add(new DemoItem { Title = "自定义样式", Description = "使用ItemContainerStyle自定义ListBox项样式" });
            Demos.Add(new DemoItem { Title = "可编辑列表项", Description = "实现支持编辑的ListBox项" });
            Demos.Add(new DemoItem { Title = "MVVM模式", Description = "基于MVVM模式使用ListBox进行增删改操作" });
            
            // 初始化时默认选中第一项
            if (Demos.Count > 0)
            {
                SelectedDemo = Demos[0];
                SelectedIndex = 0;
            }
        }
    }

    /// <summary>
    /// 演示项目模型类，用于主窗口左侧的导航列表
    /// </summary>
    public class DemoItem
    {
        /// <summary>
        /// 演示项目标题
        /// </summary>
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// 演示项目描述
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
} 