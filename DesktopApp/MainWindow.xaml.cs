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
            CoagulationEntries = new List<Components.FormEntry>();
            RFTEntries = new List<Components.FormEntry>();
            LFTEntries = new List<Components.FormEntry>();
            LipidEntries = new List<Components.FormEntry>();
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
        List<Components.FormEntry> CoagulationEntries;
        List<Components.FormEntry> RFTEntries;
        List<Components.FormEntry> LFTEntries;
        List<Components.FormEntry> LipidEntries;


        //Function for clear entires
        private void ClearEntries(List<Components.FormEntry> entries)
        {
            foreach (var item in entries)
            {
                item.FieldValue = null;
            }
        }
        //CBC tab buttons:
        private void CBCAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void CBCClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ClearEntries(CbcEntries);
            RefreshPrintPreview();
        }

        //Coagulation Profile buttons:
        private void CoagulationAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void CoagulationClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ClearEntries(CoagulationEntries);
            RefreshPrintPreview();
        }

        //RFT buttons:
        private void RFTAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void RFTClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ClearEntries(RFTEntries);
            RefreshPrintPreview();

        }

        //LFT buttons:
        private void LFTAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void LFTClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ClearEntries(LFTEntries);
            RefreshPrintPreview();

        }

        //Lipid Profile buttons:
        private void LipidAddButtonClicked(object sender, RoutedEventArgs e)
        {
            RefreshPrintPreview();
        }
        private void LipidClearButtonClicked(object sender, RoutedEventArgs e)
        {
            ClearEntries(LipidEntries);
            RefreshPrintPreview();

        }


        //Global buttons:
        private void PrintButtonClicked(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            if (pDialog.ShowDialog() == true)
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
            foreach (var item in CoagulationEntries) { item.FieldValue = null; }
            foreach (var item in RFTEntries) { item.FieldValue = null; }
            foreach (var item in LFTEntries) { item.FieldValue = null; }
            foreach (var item in LipidEntries) { item.FieldValue = null; }

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
            CbcEntries.Add(ESRInput);
            CbcEntries.Add(PCVInput);
            CbcEntries.Add(MCVInput);
            CbcEntries.Add(MCHInput);
            CbcEntries.Add(MCHCInput);


            //Coagulation Tab:
            CoagulationEntries.Add(BleedingTimeInput);
            CoagulationEntries.Add(ClottingTimeInput);
            CoagulationEntries.Add(ProthrombinTimeInput);

            //RFT Tab:
            RFTEntries.Add(UreaInput);
            RFTEntries.Add(CreatinineInput);
            RFTEntries.Add(SodiumInput);
            RFTEntries.Add(PotassiumInput);

            //LFT Tab
            LFTEntries.Add(BilirubinInput);
            LFTEntries.Add(DirectInput);
            LFTEntries.Add(TotalProtienInput);
            LFTEntries.Add(AlbuminInput);
            LFTEntries.Add(GlobulinInput);
            LFTEntries.Add(AGRatioInput);
            LFTEntries.Add(SGPTInput);
            LFTEntries.Add(SGOTInput);
            LFTEntries.Add(AlkalinePhosphataseInput);

            //Lipid Profile Tab
            LipidEntries.Add(CholesterolInput);
            LipidEntries.Add(TriglycerideInput);
            LipidEntries.Add(HDLInput);
            LipidEntries.Add(LDLInput);
            LipidEntries.Add(VLDLInput);

        }

        private void RefreshForTab(List<Components.FormEntry> entries)
        {

            foreach (var item in entries)
            {
                if (item.FieldValue == null) continue;

                var newEntry = new Components.PrintableEntry();
                newEntry.Title.Text = item.FieldString;
                newEntry.Value.Text = item.FieldValue.ToString();

                PrintPreview.MainStack.Children.Add(newEntry);
            }
        }

        private void RefreshPrintPreview()
        {
            PrintPreview.MainStack.Children.Clear();

            //CBC:
            RefreshForTab(CbcEntries);

            //Coagulation:
            RefreshForTab(CoagulationEntries);

            //RFT
            RefreshForTab(RFTEntries);

            //LFT
            RefreshForTab(LFTEntries);

            //Lipid Profile
            RefreshForTab(LipidEntries);
        }

        private void UpdateLimits()
        {
            switch (PatientSex)
            {
                case Sex.Male:
                    {
                        //CBC:
                        SetFormFieldRange(HaemoglobinInput, 13, 18);
                        SetFormFieldRange(ESRInput, 0, 10);
                        SetFormFieldRange(PCVInput, 40, 54);

                        //RFT
                        SetFormFieldRange(CreatinineInput, 0.8f, 1.4f);
                    }
                    break;
                case Sex.Female:
                    {
                        //CBC:
                        SetFormFieldRange(HaemoglobinInput, 11, 16);
                        SetFormFieldRange(ESRInput, 0, 20);
                        SetFormFieldRange(PCVInput, 36, 46);

                        //RFT
                        SetFormFieldRange(CreatinineInput, 0.8f, 1.2f);
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
            if (enumType == null) throw new Exception("enumType cannot be null");
            if (!enumType.IsEnum) throw new Exception("enumType has to be an enum");

            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
