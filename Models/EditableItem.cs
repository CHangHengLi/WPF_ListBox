using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListBoxDemo.Models
{
    /// <summary>
    /// 可编辑项目模型类，实现了INotifyPropertyChanged接口以支持数据绑定的双向更新
    /// 用于可编辑列表项示例
    /// </summary>
    public class EditableItem : INotifyPropertyChanged
    {
        // 文本内容字段
        private string _text = string.Empty;
        // 是否处于编辑状态字段
        private bool _isEditing;

        /// <summary>
        /// 项目文本内容
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 是否处于编辑状态
        /// 当值为true时，UI将显示文本框进行编辑
        /// 当值为false时，UI将显示只读文本
        /// </summary>
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 属性变更事件，当属性值改变时触发
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 触发属性变更通知
        /// </summary>
        /// <param name="propertyName">变更的属性名，默认使用调用者的成员名</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 