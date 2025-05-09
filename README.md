# WPF ListBox控件示例项目

## 项目介绍

本项目是基于WPF（Windows Presentation Foundation）技术的ListBox控件学习示例程序，采用.NET Core 8.0开发。项目演示了WPF ListBox控件的各种常用功能和高级特性，是学习WPF ListBox控件的理想参考资源。
![image](https://github.com/user-attachments/assets/1824765f-b507-4530-9040-50481aa6bd1b)

## 开发环境

- IDE：Visual Studio 2022
- 框架：.NET Core 8.0
- 平台：Windows

## 项目结构

项目采用完整的MVVM（Model-View-ViewModel）架构设计：

- `Models`：数据模型层，包含应用程序的数据实体
- `ViewModels`：视图模型层，负责业务逻辑和数据处理
- `Views`：视图层，负责用户界面展示
- `Converters`：值转换器，用于数据绑定时的转换逻辑
- `Resources`：资源文件，包含样式、模板等资源定义

## 功能模块

项目包含八个功能演示页面，每个页面展示ListBox的不同特性：

1. **基本用法**：展示ListBox的基本创建和使用方式，包括XAML和代码两种方式
2. **选择模式**：演示ListBox的三种选择模式（单选、多选、扩展选择）
3. **数据模板**：展示如何使用DataTemplate自定义ListBox项的外观
4. **复杂对象绑定**：演示如何将复杂对象集合绑定到ListBox
5. **数据分组**：展示使用CollectionView实现数据分组功能
6. **自定义样式**：展示使用ItemContainerStyle自定义ListBox项样式
7. **可编辑列表项**：演示实现支持编辑的ListBox项
8. **MVVM模式**：展示基于MVVM模式使用ListBox进行增删改操作

## 项目特点

- 完整的MVVM架构实现
- 详细的代码注释，每个类、属性、方法都有XML文档注释
- 双栏布局界面，左侧为导航列表，右侧为具体功能演示
- 实现了左侧导航列表与右侧内容区域的双向绑定

## 使用方法

1. 使用Visual Studio 2022打开WPF_ListBox.sln解决方案文件
2. 确保已安装.NET Core 8.0 SDK
3. 编译并运行项目
4. 通过左侧导航列表，点击不同的功能项，查看右侧对应的功能演示

## 注意事项

- 多选模式下，需要按住Ctrl键才能选择多个项目
- 扩展选择模式下，可以使用Shift键选择一个范围的项目

## 贡献

欢迎提交Issue或Pull Request来完善本项目。 
