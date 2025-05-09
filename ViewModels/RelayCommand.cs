using System;
using System.Windows.Input;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// 命令实现类，用于在MVVM模式中绑定UI元素的Command属性
    /// 无参数版本
    /// </summary>
    public class RelayCommand : ICommand
    {
        // 存储执行命令的动作委托
        private readonly Action _execute;
        // 存储判断命令是否可执行的委托
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="execute">命令执行的动作</param>
        /// <param name="canExecute">判断命令是否可执行的函数，可选</param>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            // 确保execute不为null，否则抛出异常
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// 命令可执行状态变更事件
        /// 当命令可执行状态变更时触发
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            // 使用WPF内置的CommandManager管理可执行状态变更事件
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 判断命令是否可执行
        /// </summary>
        /// <param name="parameter">命令参数，此版本忽略</param>
        /// <returns>如果命令可执行返回true，否则返回false</returns>
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="parameter">命令参数，此版本忽略</param>
        public void Execute(object? parameter) => _execute();
    }

    /// <summary>
    /// 命令实现类，用于在MVVM模式中绑定UI元素的Command属性
    /// 带泛型参数版本
    /// </summary>
    /// <typeparam name="T">命令参数类型</typeparam>
    public class RelayCommand<T> : ICommand
    {
        // 存储执行命令的动作委托
        private readonly Action<T> _execute;
        // 存储判断命令是否可执行的委托
        private readonly Predicate<T>? _canExecute;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="execute">命令执行的动作</param>
        /// <param name="canExecute">判断命令是否可执行的函数，可选</param>
        public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            // 确保execute不为null，否则抛出异常
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// 命令可执行状态变更事件
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 判断命令是否可执行
        /// </summary>
        /// <param name="parameter">命令参数</param>
        /// <returns>如果命令可执行返回true，否则返回false</returns>
        public bool CanExecute(object? parameter)
        {
            // 如果参数为null且T是值类型，则命令不能执行
            if (parameter == null && typeof(T).IsValueType)
                return false;
            
            // 如果没有设置canExecute，或者canExecute返回true，则命令可执行
            return _canExecute == null || _canExecute((T)parameter!);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="parameter">命令参数</param>
        public void Execute(object? parameter) => _execute((T)parameter!);
    }
} 