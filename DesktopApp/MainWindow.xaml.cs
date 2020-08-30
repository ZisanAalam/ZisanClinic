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
                        SetLowerLimit(HaemoglobinInput, 3);
                        SetLowerLimit(WbcInput,         3);
                        SetLowerLimit(RbcInput,         3);
                        SetLowerLimit(PlateletsInput,   3);
                        SetLowerLimit(NeutrophilInput,  3);
                        SetLowerLimit(LymphocyteInput,  3);
                        SetLowerLimit(EosinophilInput,  3);
                        SetLowerLimit(MonocyteInput,    3);
                        SetLowerLimit(BasophilInput,    3);

                        SetHigherLimit(HaemoglobinInput, 4);
                        SetHigherLimit(WbcInput,         4);
                        SetHigherLimit(RbcInput,         4);
                        SetHigherLimit(PlateletsInput,   4);
                        SetHigherLimit(NeutrophilInput,  4);
                        SetHigherLimit(LymphocyteInput,  4);
                        SetHigherLimit(EosinophilInput,  4);
                        SetHigherLimit(MonocyteInput,    4);
                        SetHigherLimit(BasophilInput,    4);

                        //Tab 2:
                        SetLowerLimit(Test1Input, 8);
                        SetLowerLimit(Test2Input, 8);
                        SetLowerLimit(Test3Input, 8);

                        SetHigherLimit(Test1Input, 9);
                        SetHigherLimit(Test2Input, 9);
                        SetHigherLimit(Test3Input, 9);

                    }
                    break;
                case Sex.Female:
                    {
                        //CBC:
                        SetLowerLimit(HaemoglobinInput, 4);
                        SetLowerLimit(WbcInput,         4);
                        SetLowerLimit(RbcInput,         4);
                        SetLowerLimit(PlateletsInput,   4);
                        SetLowerLimit(NeutrophilInput,  5);
                        SetLowerLimit(LymphocyteInput,  5);
                        SetLowerLimit(EosinophilInput,  6);
                        SetLowerLimit(MonocyteInput,    7);
                        SetLowerLimit(BasophilInput,    7);

                        SetHigherLimit(HaemoglobinInput, 9);
                        SetHigherLimit(WbcInput,         9);
                        SetHigherLimit(RbcInput,         9);
                        SetHigherLimit(PlateletsInput,   9);
                        SetHigherLimit(NeutrophilInput,  9);
                        SetHigherLimit(LymphocyteInput,  9);
                        SetHigherLimit(EosinophilInput,  9);
                        SetHigherLimit(MonocyteInput,    9);
                        SetHigherLimit(BasophilInput,    9);

                        //Tab 2:
                        SetLowerLimit(Test1Input, 88);
                        SetLowerLimit(Test2Input, 88);
                        SetLowerLimit(Test3Input, 88);

                        SetHigherLimit(Test1Input, 98);
                        SetHigherLimit(Test2Input, 98);
                        SetHigherLimit(Test3Input, 98);

                    }
                    break;
                default:
                    {
                        
                    }
                    break;
            }
        }
        private void SetLowerLimit(Components.FormEntry entry, float value)
        {
            entry.Range = new Components.FormFieldRange(value, entry.Range.higherRange);
        }
        private void SetHigherLimit(Components.FormEntry entry, float value)
        {
            entry.Range = new Components.FormFieldRange(entry.Range.lowerRange, value);
        }

        private void Tab3ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            foreach (var item in Tab2Entries)
            {
                item.FieldValue = null;
            }
            RefreshPrintPreview();
        }

        private void Tab3AddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
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
