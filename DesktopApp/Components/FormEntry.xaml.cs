using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DesktopApp.Components
{
    public partial class FormEntry : UserControl, INotifyPropertyChanged
    {
        public FormEntry()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string FieldString
        {
            get { return (string)GetValue(FieldStringProperty); }
            set { SetValue(FieldStringProperty, value); }
        }
        public static readonly DependencyProperty FieldStringProperty = DependencyProperty.Register("FieldString", typeof(string), typeof(FormEntry), new PropertyMetadata(""));

        private float? m_fieldValue;
        public float? FieldValue
        {
            get { return m_fieldValue; }
            set
            {
                m_fieldValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FieldValue)));
            }
        }

        public float LowerRange
        {
            get { return (float)GetValue(LowerRangeProperty); }
            set { SetValue(LowerRangeProperty, value); }
        }
        public static readonly DependencyProperty LowerRangeProperty = DependencyProperty.Register("LowerRange", typeof(float), typeof(FormEntry), new PropertyMetadata(0.0f));

        public float UpperRange
        {
            get { return (float)GetValue(UpperRangeProperty); }
            set { SetValue(UpperRangeProperty, value); }
        }
        public static readonly DependencyProperty UpperRangeProperty = DependencyProperty.Register("UpperRange", typeof(float), typeof(FormEntry), new PropertyMetadata(0.0f));

        public event PropertyChangedEventHandler PropertyChanged = (sender, e)=>{};
    }

    public class FloatToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float? nullableFloat = (float?)value;
            if (nullableFloat != null)
            {
                return nullableFloat.ToString();
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nullableFloatString = (string)value;
            if (string.IsNullOrEmpty(nullableFloatString) || string.IsNullOrWhiteSpace(nullableFloatString))
            {
                return null;
            }
            else
            {
                float returnValue;
                if(float.TryParse(nullableFloatString, out returnValue))
                {
                    return returnValue;
                }
                else
                {
                    return null;
                }

            }
        }
    }
    public class FloatToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float? floatValue = (float?)value;
            if(floatValue == null)
            {
                return Brushes.LightGray;
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
