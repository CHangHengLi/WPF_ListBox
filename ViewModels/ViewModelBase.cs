using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListBoxDemo.ViewModels
{
    /// <summary>
    /// ViewModel基类，实现INotifyPropertyChanged接口
    /// 用于支持WPF数据绑定的属性通知机制
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性变更事件，当属性值改变时触发
        /// 通知UI界面更新对应的绑定
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 触发属性变更通知
        /// </summary>
        /// <param name="propertyName">变更的属性名，默认使用调用者的成员名</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // 调用所有注册的事件处理程序
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置属性值并通知变更
        /// </summary>
        /// <typeparam name="T">属性类型</typeparam>
        /// <param name="field">字段引用</param>
        /// <param name="value">新的属性值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>如果值已更改，则返回 true，否则返回 false</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            // 如果新值与旧值相等，则不更新
            if (Equals(field, value)) return false;
            
            // 更新字段值
            field = value;
            
            // 触发属性变更通知
            OnPropertyChanged(propertyName);
            
            return true;
        }
    }
} 