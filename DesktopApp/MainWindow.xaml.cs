using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DesktopApp
{
    public enum Sex
    {
        Male,
        Female
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            CbcEntries = new List<Components.FormEntry>();
            Tab2Entries = new List<Components.FormEntry>();
            InitializeTabEntries();
            UpdateLimits();

            PatientRefBy = "Dr. Prabej Kaushar";
        }

        private string m_patientName;
        public string PatientName
        {
            get { return m_patientName; }
            set 
            {
                m_patientName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PatientName)));
            }
        }

        private Sex m_patientSex;
        public Sex PatientSex
        {
            get { return m_patientSex; }
            set 
            {
                m_patientSex = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PatientSex)));

                UpdateLimits();
            }
        }

        private string m_patientPhone;
        public string PatientPhone
        {
            get { return m_patientPhone; }
            set 
            { 
                m_patientPhone = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PatientPhone)));
            }
        }

        private string m_patientAddress;
        public string PatientAddress
        {
            get { return m_patientAddress; }
            set 
            { 
                m_patientAddress = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PatientAddress)));
            }
        }

        private string m_patientRefBy;
        public string PatientRefBy
        {
            get { return m_patientRefBy; }
            set 
            { 
                m_patientRefBy = value; 
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PatientRefBy)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //=====================================================================================

        List<Components.FormEntry> CbcEntries;
        List<Components.FormEntry> Tab2Entries;
        

        //CBC tab buttons:
        private void CBCAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void CBCClearButtonClicked(object sender, RoutedEventArgs e)
        {
            foreach (var item in CbcEntries)
            {
                item.FieldValue = null;
            }
            RefreshPrintPreview();
        }

        //Tab 2 buttons:
        private void Tab2AddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void Tab2ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            foreach (var item in Tab2Entries)
            {
                item.FieldValue = null;
            }
            RefreshPrintPreview();
        }

        //Tab 3 buttons:
        private void Tab3ClearButtonClicked(object sender, RoutedEventArgs e)
        {

        }
        private void Tab3AddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }

        //Global buttons:
        private void PrintButtonClicked(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            if(pDialog.ShowDialog() == true)
            {
                pDialog.PrintVisual(PrintPreview.PrintableArea, "PageToPrint");
            }
        }
        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientName = "";
            PatientSex = Sex.Male;
            PatientPhone = "";
            PatientAddress = "";

            foreach (var item in CbcEntries) { item.FieldValue = null; }
            foreach (var item in Tab2Entries) { item.FieldValue = null; }


            RefreshPrintPreview();
        }

        //=====================================================================================

        private void InitializeTabEntries()
        {
            //CBC tab:
            CbcEntries.Add(HaemoglobinInput);
            CbcEntries.Add(WbcInput);
            CbcEntries.Add(RbcInput);
            CbcEntries.Add(PlateletsInput);
            CbcEntries.Add(NeutrophilInput);
            CbcEntries.Add(LymphocyteInput);
            CbcEntries.Add(EosinophilInput);
            CbcEntries.Add(MonocyteInput);
            CbcEntries.Add(BasophilInput);

            //Tab 2:
            Tab2Entries.Add(Test1Input);
            Tab2Entries.Add(Test2Input);
            Tab2Entries.Add(Test3Input);
        }
        private void RefreshPrintPreview()
        {
            PrintPreview.MainStack.Children.Clear();

            //CBC:
            foreach (var item in CbcEntries)
            {
                if (item.FieldValue == null) continue;

                var newEntry = new Components.PrintableEntry();
                newEntry.Title.Text = item.FieldString;
                newEntry.Value.Text = item.FieldValue.ToString();

                PrintPreview.MainStack.Children.Add(newEntry);
            }

            //Tab 2:
            foreach (var item in Tab2Entries)
            {
                if (item.FieldValue == null) continue;

                var newEntry = new Components.PrintableEntry();
                newEntry.Title.Text = item.FieldString;
                newEntry.Value.Text = item.FieldValue.ToString();

                PrintPreview.MainStack.Children.Add(newEntry);
            }
        }

        private void UpdateLimits()
        {
            switch (PatientSex)
            {
                case Sex.Male:
                    {
                        //CBC:
                        SetFormFieldRange(HaemoglobinInput, 3, 4);
                        SetFormFieldRange(WbcInput,         3, 4);
                        SetFormFieldRange(RbcInput,         3, 4);
                        SetFormFieldRange(PlateletsInput,   3, 4);
                        SetFormFieldRange(NeutrophilInput,  3, 4);
                        SetFormFieldRange(LymphocyteInput,  3, 4);
                        SetFormFieldRange(EosinophilInput,  3, 4);
                        SetFormFieldRange(MonocyteInput,    3, 4);
                        SetFormFieldRange(BasophilInput,    3, 4);

                        //Tab 2:
                        SetFormFieldRange(Test1Input, 8, 9);
                        SetFormFieldRange(Test2Input, 8, 9);
                        SetFormFieldRange(Test3Input, 8, 9);

                    }
                    break;
                case Sex.Female:
                    {
                        //CBC:
                        SetFormFieldRange(HaemoglobinInput, 4, 9);
                        SetFormFieldRange(WbcInput,         4, 9);
                        SetFormFieldRange(RbcInput,         4, 9);
                        SetFormFieldRange(PlateletsInput,   4, 9);
                        SetFormFieldRange(NeutrophilInput,  5, 9);
                        SetFormFieldRange(LymphocyteInput,  5, 9);
                        SetFormFieldRange(EosinophilInput,  6, 9);
                        SetFormFieldRange(MonocyteInput,    7, 9);
                        SetFormFieldRange(BasophilInput,    7, 9);

                        //Tab 2:
                       SetFormFieldRange(Test1Input, 88, 98);
                       SetFormFieldRange(Test2Input, 88, 98);
                       SetFormFieldRange(Test3Input, 88, 98);

                    }
                    break;
                default:
                    {
                        
                    }
                    break;
            }
        }
        private void SetFormFieldRange(Components.FormEntry entry, float low, float high)
        {
            entry.Range = new Components.FormFieldRange(low, high);
        }
    }

    public class EnumBindingSourceExt : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSourceExt(Type enumType)
        {
            if(enumType == null) throw new Exception("enumType cannot be null");
            if (!enumType.IsEnum) throw new Exception("enumType has to be an enum");

            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }


}
