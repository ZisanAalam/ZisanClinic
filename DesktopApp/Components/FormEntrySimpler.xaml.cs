using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DesktopApp.Components
{
    public partial class FormEntrySimpler : UserControl, INotifyPropertyChanged
    {
        public FormEntrySimpler()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string FieldString
        {
            get { return (string)GetValue(FieldStringProperty); }
            set { SetValue(FieldStringProperty, value); }
        }
        public static readonly DependencyProperty FieldStringProperty = DependencyProperty.Register("FieldString", typeof(string), typeof(FormEntrySimpler), new PropertyMetadata(""));


        private string fieldValue;
        public string FieldValue
        {
            get { return fieldValue; }
            set 
            { 
                fieldValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FieldValue)));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }

    public class StringToUIStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nullableString = (string)value;
            if (nullableString != null)
            {
                return nullableString;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nullableString = (string)value;
            if (string.IsNullOrEmpty(nullableString) || string.IsNullOrWhiteSpace(nullableString))
            {
                return null;
            }
            else
            {
                return nullableString;
            }
        }
    }
    public class StringToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = (string)value;
            if (stringValue == null)
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
