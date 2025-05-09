using ListBoxDemo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// 产品ViewModel，管理产品数据并提供分组和排序视图
    /// 用于展示ListBox的复杂数据绑定、数据分组和排序功能
    /// </summary>
    public class ProductViewModel : ViewModelBase
    {
        // 产品集合
        private ObservableCollection<Product> _products = new();
        // 按类别分组的视图
        private ICollectionView? _groupedProductsView;
        // 按价格排序的视图
        private ICollectionView? _sortedProductsView;

        /// <summary>
        /// 构造函数，初始化产品数据和视图
        /// </summary>
        public ProductViewModel()
        {
            InitializeProducts();
            SetupCollectionViews();
        }

        /// <summary>
        /// 产品集合属性
        /// </summary>
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        /// <summary>
        /// 按类别分组的产品视图
        /// 展示如何使用CollectionView实现数据分组
        /// </summary>
        public ICollectionView? GroupedProductsView
        {
            get => _groupedProductsView;
            set => SetProperty(ref _groupedProductsView, value);
        }

        /// <summary>
        /// 按价格排序的产品视图
        /// 展示如何使用CollectionView实现数据排序
        /// </summary>
        public ICollectionView? SortedProductsView
        {
            get => _sortedProductsView;
            set => SetProperty(ref _sortedProductsView, value);
        }

        /// <summary>
        /// 初始化产品数据
        /// </summary>
        private void InitializeProducts()
        {
            // 添加示例产品数据
            Products.Add(new Product { Id = 1, Name = "笔记本电脑", Price = 5999, Category = "电子产品", ImagePath = "/ListBoxDemo;component/Resources/laptop.png" });
            Products.Add(new Product { Id = 2, Name = "机械键盘", Price = 299, Category = "配件", ImagePath = "/ListBoxDemo;component/Resources/keyboard.png" });
            Products.Add(new Product { Id = 3, Name = "无线鼠标", Price = 129, Category = "配件", ImagePath = "/ListBoxDemo;component/Resources/mouse.png" });
            Products.Add(new Product { Id = 4, Name = "显示器", Price = 1299, Category = "电子产品", ImagePath = "/ListBoxDemo;component/Resources/monitor.png" });
            Products.Add(new Product { Id = 5, Name = "手机", Price = 2999, Category = "电子产品", ImagePath = "/ListBoxDemo;component/Resources/phone.png" });
            Products.Add(new Product { Id = 6, Name = "耳机", Price = 499, Category = "配件", ImagePath = "/ListBoxDemo;component/Resources/headphones.png" });
        }

        /// <summary>
        /// 设置集合视图，用于分组和排序
        /// </summary>
        private void SetupCollectionViews()
        {
            // 分组视图设置
            GroupedProductsView = CollectionViewSource.GetDefaultView(Products);
            GroupedProductsView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            // 排序视图设置
            SortedProductsView = CollectionViewSource.GetDefaultView(Products);
            SortedProductsView.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
        }
    }
} 