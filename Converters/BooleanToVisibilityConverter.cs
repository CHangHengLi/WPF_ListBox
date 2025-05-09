using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ListBoxDemo.Converters
{
    /// <summary>
    /// 布尔值转可见性转换器
    /// 将布尔值转换为Visibility枚举值
    /// 当值为true时返回Visible，否则返回Collapsed
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 将布尔值转换为Visibility枚举值
        /// </summary>
        /// <param name="value">要转换的源数据</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域信息</param>
        /// <returns>转换后的值，true对应Visible，false对应Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 处理布尔值
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            
            // 处理对象引用 - 非null为Visible，null为Collapsed
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 将Visibility枚举值转换回布尔值
        /// </summary>
        /// <param name="value">要转换的目标数据</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域信息</param>
        /// <returns>转换后的值，Visible对应true，其他值对应false</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }
    }

    /// <summary>
    /// 布尔值反转可见性转换器
    /// 将布尔值转换为Visibility枚举值，但结果与BooleanToVisibilityConverter相反
    /// 当值为false时返回Visible，否则返回Collapsed
    /// </summary>
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 将布尔值转换为Visibility枚举值
        /// </summary>
        /// <param name="value">要转换的源数据</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域信息</param>
        /// <returns>转换后的值，false对应Visible，true对应Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 处理布尔值
            if (value is bool boolValue)
            {
                return !boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            
            // 处理对象引用 - null为Visible，非null为Collapsed
            return value == null ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 将Visibility枚举值转换回布尔值
        /// </summary>
        /// <param name="value">要转换的目标数据</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域信息</param>
        /// <returns>转换后的值，Visible对应false，其他值对应true</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility != Visibility.Visible;
        }
    }
} 