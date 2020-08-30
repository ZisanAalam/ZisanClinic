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

        private FormFieldRange m_range;
        public FormFieldRange Range
        {
            get { return m_range; }
            set 
            { 
                m_range = value; 
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Range)));
            }
        }

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(string), typeof(FormEntry), new PropertyMetadata("%"));



        public event PropertyChangedEventHandler PropertyChanged = (sender, e)=>{};
    }

    public struct FormFieldRange
    {
        public FormFieldRange(float lower, float higher)
        {
            this.lowerRange = lower;
            this.higherRange = higher;
        }

        public float lowerRange;
        public float higherRange;
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
    public class RangeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FormFieldRange range = (FormFieldRange)value;
            string output = range.lowerRange.ToString() + " - " + range.higherRange.ToString();
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
