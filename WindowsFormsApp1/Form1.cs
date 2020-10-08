using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Reflection;

namespace WindowsFormsApp1
{
    //766 936 purchasedate checking
    public partial class Form1 : Form
    {
        public List<int> listbox_tracker = new List<int>();
        public int track_selected_index = 0;
        public string program_title = "Inventory Manager - 1.3";
        public string sort_mode = "number";
        public bool changes_to_data = false;
        bool report_mode = false;
        string report_type = "";
        DataManager DM;
        Sorting SN;

        public Form1()
        {
            InitializeComponent();
            //this.Size(1819, 1050);
            //this.Width = 97;
            //this.Height = 695;
            //979 651
            //MessageBox.Show(this.Width + " " + this.Height);

            DM = new DataManager(this);
        }

        private void number_rows()
        {
            foreach (DataGridViewRow row in dataOUTPUT.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        public void DisplayNotification()
        {
            SN = new Sorting();
            SN.label1.Text = "Loading";
            SN.Show();
            SN.Refresh();
            SN.TopMost = true;
            SN.Activate();
        }

        public void CloseNotification()
        {
            SN.Close();
        }
        private void AdjustSize()
        {
            dataOUTPUT.Width = this.Width - 400;
            dataOUTPUT.Height = this.Height - 120; //90
        }
        private void UpdateInventory()
        {
            sort_mode = "Loading";
            DisplayNotification();

            if (DM.UpdateInventory() == true)
            {
                RefreshCombos();
                RefreshList();
                EnableControls();
                this.Text = program_title + " | " + DM.database_source_file;
            }
            CloseNotification();
        }
        private void CloseInventory()
        {
            listbox_tracker = new List<int>();
            track_selected_index = 0;
            dataOUTPUT.Rows.Clear();
            DisableControls();
        }

        private void OpenInventory()
        {

            if (DM.OpenInventory() == true)
            {
                EnableControls();
                this.Text = program_title + " | " + DM.database_source_file;
                RefreshCombos();
                RefreshList();
                CloseNotification();
            }  
        }

        public void RecordSort()
        {
            DisplayNotification();
            DatabaseManager dbm = new DatabaseManager();
            DM.inventory_database = dbm.SortDatabase(DM.inventory_database, sort_mode);
            RefreshList();
            CloseNotification();
        }

        public void ClearFilters()
        {
            DisplayNotification();
            comboLOCATION.Text = "";
            comboTYPE.Text = "";
            comboNUMBER.Text = "";
            comboMAC.Text = "";
            comboMAKE.Text = "";
            comboMODEL.Text = "";
            comboVERSION.Text = "";
            comboSERIAL.Text = "";
            comboOS.Text = "";
            comboUSER.Text = "";
            comboDEPARTMENT.Text = "";
            checkPURCHASEDATE.Checked = false;
            textCOMMENTS.Text = "";
            CloseNotification();
            RefreshList();
        }
        public void DeleteRecord()
        {
            if (dataOUTPUT.Rows.Count == 0)
            {
                MessageBox.Show("No item was selected from the list. Please select a value to edit.");
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD?: " + dataOUTPUT[0, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[1, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[2, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[3, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[4, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[5, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[6, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[7, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[8, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[9, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[10, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[11, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[12, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() + " | " + dataOUTPUT[13, dataOUTPUT.CurrentCell.RowIndex].Value.ToString(), "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    track_selected_index = dataOUTPUT.CurrentRow.Index;
                    DM.inventory_database.RemoveAt(listbox_tracker[track_selected_index]);
                    RefreshList();
                    RefreshCombos();
                    changes_to_data = true;
                }
            }
        }

        public void AddRecord()
        {
            Form2 AddForm = new Form2(this, DM);
            AddForm.button1.Text = "Add";
            AddForm.comboRETIRED.SelectedIndex = 1;
            AddForm.Text = "Add New Record";
            AddForm.ShowDialog();
        }

        public void EditRecord()
        {
            if (dataOUTPUT.Rows.Count == 0)
            {
                MessageBox.Show("No item was selected from the list. Please select a value to edit.");
            }

            else
            {
                Form2 EditForm = new Form2(this, DM);
                track_selected_index = dataOUTPUT.CurrentRow.Index;

                EditForm.textLOCATION.Text = dataOUTPUT[0, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textTYPE.Text = dataOUTPUT[1, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textNUMBER.Text = dataOUTPUT[2, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textMAC.Text = dataOUTPUT[3, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textMAKE.Text = dataOUTPUT[4, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textMODEL.Text = dataOUTPUT[5, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textVERSION.Text = dataOUTPUT[6, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textSERIAL.Text = dataOUTPUT[7, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textOS.Text = dataOUTPUT[8, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textUSER.Text = dataOUTPUT[9, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.textDEPARTMENT.Text = dataOUTPUT[10, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();

                if (dataOUTPUT[11, dataOUTPUT.CurrentCell.RowIndex].Value.ToString() == "")
                {
                    EditForm.checkBox1.Checked = true;
                }

                else
                {
                    if (IsDateTime(dataOUTPUT[11, dataOUTPUT.CurrentCell.RowIndex].Value.ToString()) == true)
                    {
                        EditForm.monthCalendar1.SetDate(DateTime.Parse(dataOUTPUT[11, dataOUTPUT.CurrentCell.RowIndex].Value.ToString()));
                    }

                    else
                    {
                        dataOUTPUT[11, dataOUTPUT.CurrentCell.RowIndex].Value = "";
                        EditForm.checkBox1.Checked = true;
                    }
                }

                EditForm.textCOMMENTS.Text = dataOUTPUT[12, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.comboRETIRED.Text = dataOUTPUT[13, dataOUTPUT.CurrentCell.RowIndex].Value.ToString();
                EditForm.button1.Text = "Edit";
                EditForm.Text = "Edit Record";
                EditForm.ShowDialog();
            }
        }

        public void RefreshList()
        {
            bool datecheck = false;
            int radiodate = 0;
            bool retiredcheck = false;
            List<int> filter_tracker = new List<int>();
            List<int> report_tracker = new List<int>();
            //List<int> _tracker = new List<int>();

            dataOUTPUT.Rows.Clear();
            dataOUTPUT.ColumnCount = 14;

            if (checkPURCHASEDATE.Checked)
                datecheck = true;

            if (radioPURCHASEDATEEQUAL.Checked)
                radiodate = 0;

            if (radioPURCHASEDATENEWER.Checked)
                radiodate = 2;

            if (radioPURCHASEDATEOLDER.Checked)
                radiodate = 1;

            if (checkRETIRED.Checked)
                retiredcheck = true;

            listbox_tracker.Clear();

            if (report_mode == false)
            {
                listbox_tracker = DM.filter_results(comboLOCATION.Text, comboTYPE.Text, comboNUMBER.Text, comboMAC.Text, comboMAKE.Text, comboMODEL.Text, comboVERSION.Text, comboSERIAL.Text, comboOS.Text, comboUSER.Text, comboDEPARTMENT.Text, DateTime.Parse(monthCalendar1.SelectionRange.Start.ToShortDateString()), textCOMMENTS.Text, datecheck, radiodate, retiredcheck, DM.inventory_database);
            }

            if (report_mode == true)
            {
                report_tracker = DM.report_filter(report_type, comboLOCATION.Text, comboTYPE.Text, comboNUMBER.Text, comboMAC.Text, comboMAKE.Text, comboMODEL.Text, comboVERSION.Text, comboSERIAL.Text, comboOS.Text, comboUSER.Text, comboDEPARTMENT.Text, DateTime.Parse(monthCalendar1.SelectionRange.Start.ToShortDateString()), textCOMMENTS.Text, datecheck, radiodate, retiredcheck, DM.inventory_database);
                filter_tracker = DM.filter_results(comboLOCATION.Text, comboTYPE.Text, comboNUMBER.Text, comboMAC.Text, comboMAKE.Text, comboMODEL.Text, comboVERSION.Text, comboSERIAL.Text, comboOS.Text, comboUSER.Text, comboDEPARTMENT.Text, DateTime.Parse(monthCalendar1.SelectionRange.Start.ToShortDateString()), textCOMMENTS.Text, datecheck, radiodate, retiredcheck, DM.inventory_database);
                listbox_tracker = DM.consolidate_lists(report_tracker, filter_tracker);
            }

            for (int i = 0; i < listbox_tracker.Count(); i++) { dataOUTPUT.Rows.Add(DM.inventory_database[listbox_tracker[i]][0], DM.inventory_database[listbox_tracker[i]][1], DM.inventory_database[listbox_tracker[i]][2], DM.inventory_database[listbox_tracker[i]][3], DM.inventory_database[listbox_tracker[i]][4], DM.inventory_database[listbox_tracker[i]][5], DM.inventory_database[listbox_tracker[i]][6], DM.inventory_database[listbox_tracker[i]][7], DM.inventory_database[listbox_tracker[i]][8], DM.inventory_database[listbox_tracker[i]][9], DM.inventory_database[listbox_tracker[i]][10], DM.inventory_database[listbox_tracker[i]][11], DM.inventory_database[listbox_tracker[i]][12], DM.inventory_database[listbox_tracker[i]][13]); }
            
            toolStripStatusLabel1.Text = "Total Records in Inventory: " + DM.inventory_database.Count();
            toolStripStatusLabel2.Text = "Total Records in Current View: " + dataOUTPUT.Rows.Count;

            number_rows();
        }

        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }

        public void RefreshCombos()
        {
            int x = 0;

            string oldLOCATION = comboLOCATION.Text;
            string oldTYPE = comboTYPE.Text;
            string oldNUMBER = comboNUMBER.Text;
            string oldMAC = comboMAC.Text;
            string oldMAKE = comboMAKE.Text;
            string oldMODEL = comboMODEL.Text;
            string oldVERSION = comboVERSION.Text;
            string oldSERIAL = comboSERIAL.Text;
            string oldOS = comboOS.Text;
            string oldUSER = comboUSER.Text;
            string oldDEPARTMENT = comboDEPARTMENT.Text;

            comboLOCATION.Items.Clear();
            comboTYPE.Items.Clear();
            comboNUMBER.Items.Clear();
            comboMAC.Items.Clear();
            comboMAKE.Items.Clear();
            comboMODEL.Items.Clear();
            comboVERSION.Items.Clear();
            comboSERIAL.Items.Clear();
            comboOS.Items.Clear();
            comboUSER.Items.Clear();
            comboDEPARTMENT.Items.Clear();

            comboLOCATION.Text = "";
            comboTYPE.Text = "";
            comboNUMBER.Text = "";
            comboMAC.Text = "";
            comboMAKE.Text = "";
            comboMODEL.Text = "";
            comboVERSION.Text = "";
            comboSERIAL.Text = "";
            comboOS.Text = "";
            comboUSER.Text = "";
            comboDEPARTMENT.Text = "";

            List<string> list_LOCATION = new List<string>(0);
            List<string> list_TYPE = new List<string>(0);
            List<string> list_NUMBER = new List<string>(0);
            List<string> list_MAC = new List<string>(0);
            List<string> list_MAKE = new List<string>(0);
            List<string> list_MODEL = new List<string>(0);
            List<string> list_VERSION = new List<string>(0);
            List<string> list_SERIAL = new List<string>(0);
            List<string> list_OS = new List<string>(0);
            List<string> list_USER = new List<string>(0);
            List<string> list_DEPARTMENT = new List<string>(0);
            List<string> list_PURCHASEDATE = new List<string>(0);

            while (x < DM.inventory_database.Count)
            {
                bool found = false;

                foreach (string item in list_LOCATION)
                    if (item == DM.inventory_database[x][0]) { found = true; }

                if (found == false) { list_LOCATION.Add(DM.inventory_database[x][0]); }

                found = false;

                foreach (string item in list_TYPE)
                    if (item == DM.inventory_database[x][1]) { found = true; }

                if (found == false) { list_TYPE.Add(DM.inventory_database[x][1]); }

                found = false;

                foreach (string item in list_NUMBER)
                    if (item == DM.inventory_database[x][2]) { found = true; }

                if (found == false) { list_NUMBER.Add(DM.inventory_database[x][2]); }
           
                found = false;

                foreach (string item in list_MAC)
                    if (item == DM.inventory_database[x][3]) { found = true; }

                if (found == false) { list_MAC.Add(DM.inventory_database[x][3]); }

                found = false;

                foreach (string item in list_MAKE)
                    if (item == DM.inventory_database[x][4]) { found = true; }


                if (found == false) { list_MAKE.Add(DM.inventory_database[x][4]); }

                found = false;

                foreach (string item in list_MODEL)
                    if (item == DM.inventory_database[x][5]) { found = true; }


                if (found == false) { list_MODEL.Add(DM.inventory_database[x][5]); }

                found = false;

                foreach (string item in list_VERSION)
                    if (item == DM.inventory_database[x][6]) { found = true; }


                if (found == false) { list_VERSION.Add(DM.inventory_database[x][6]); }

                found = false;

                foreach (string item in list_SERIAL)
                    if (item == DM.inventory_database[x][7]) { found = true; }


                if (found == false) { list_SERIAL.Add(DM.inventory_database[x][7]); }

                found = false;

                foreach (string item in list_OS)
                    if (item == DM.inventory_database[x][8]) { found = true; }


                if (found == false) { list_OS.Add(DM.inventory_database[x][8]); }

                found = false;

                foreach (string item in list_USER)
                    if (item == DM.inventory_database[x][9]) { found = true; }


                if (found == false) { list_USER.Add(DM.inventory_database[x][9]); }

                found = false;

                foreach (string item in list_DEPARTMENT)
                    if (item == DM.inventory_database[x][10]) { found = true; }


                if (found == false) { list_DEPARTMENT.Add(DM.inventory_database[x][10]); }

                x++;
            }
            foreach (var item in list_LOCATION) { comboLOCATION.Items.Add(item); }
            foreach (var item in list_TYPE) { comboTYPE.Items.Add(item); }
            foreach (var item in list_NUMBER) { comboNUMBER.Items.Add(item); }
            foreach (var item in list_MAC) { comboMAC.Items.Add(item); }
            foreach (var item in list_MAKE) { comboMAKE.Items.Add(item); }
            foreach (var item in list_MODEL) { comboMODEL.Items.Add(item); }
            foreach (var item in list_VERSION) { comboVERSION.Items.Add(item); }
            foreach (var item in list_SERIAL) { comboSERIAL.Items.Add(item); }
            foreach (var item in list_OS) { comboOS.Items.Add(item); }
            foreach (var item in list_USER) { comboUSER.Items.Add(item); }
            foreach (var item in list_DEPARTMENT) { comboDEPARTMENT.Items.Add(item); }

            foreach (string item in list_LOCATION)
                if (item == oldLOCATION) { comboLOCATION.Text = item; }

            foreach (string item in list_TYPE)
                if (item == oldTYPE) { comboTYPE.Text = item; }

            foreach (string item in list_NUMBER)
                if (item == oldNUMBER) { comboNUMBER.Text = item; }

            foreach (string item in list_MAC)
                if (item == oldMAC) { comboMAC.Text = item; }

            foreach (string item in list_MAKE)
                if (item == oldMAKE) { comboMAKE.Text = item; }

            foreach (string item in list_MODEL)
                if (item == oldMODEL) { comboMODEL.Text = item; }

            foreach (string item in list_TYPE)
                if (item == oldVERSION) { comboVERSION.Text = item; }

            foreach (string item in list_SERIAL)
                if (item == oldSERIAL) { comboSERIAL.Text = item; }

            foreach (string item in list_OS)
                if (item == oldOS) { comboOS.Text = item; }

            foreach (string item in list_USER)
                if (item == oldUSER) { comboUSER.Text = item; }

            foreach (string item in list_DEPARTMENT)
                if (item == oldDEPARTMENT) { comboDEPARTMENT.Text = item; }
        }

        public void DisableControls()
        {
            toolStripButtonAddRecord.Enabled = false;
            toolStripButtonEditRecord.Enabled = false;
            toolStripButtonDeleteRecord.Enabled = false;
            checkPURCHASEDATE.Enabled = false;
            radioPURCHASEDATEEQUAL.Enabled = false;
            radioPURCHASEDATENEWER.Enabled = false;
            radioPURCHASEDATEOLDER.Enabled = false;
            monthCalendar1.Enabled = false;
            toolStripButtonSearchSelected.Enabled = false;
            toolStripButtonClearFilters.Enabled = false;
            checkRETIRED.Enabled = false;

            comboLOCATION.Enabled = false;
            comboTYPE.Enabled = false;
            comboNUMBER.Enabled = false;
            comboMAC.Enabled = false;
            comboMAKE.Enabled = false;
            comboMODEL.Enabled = false;
            comboVERSION.Enabled = false;
            comboSERIAL.Enabled = false;
            comboOS.Enabled = false;
            comboUSER.Enabled = false;
            comboDEPARTMENT.Enabled = false;
            textCOMMENTS.Enabled = false;

            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            recordsToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            sortToolStripMenuItem.Enabled = false;
            quickBackupToolStripMenuItem.Enabled = false;
            exportToolStripMenuItem1.Enabled = false;

            groupBox2.Enabled = false;

            comboLOCATION.Items.Clear();
            comboTYPE.Items.Clear();
            comboNUMBER.Items.Clear();
            comboMAC.Items.Clear();
            comboMAKE.Items.Clear();
            comboMODEL.Items.Clear();
            comboVERSION.Items.Clear();
            comboSERIAL.Items.Clear();
            comboOS.Items.Clear();
            comboUSER.Items.Clear();
            comboDEPARTMENT.Items.Clear();

            comboLOCATION.Text = "";
            comboTYPE.Text = "";
            comboNUMBER.Text = "";
            comboMAC.Text = "";
            comboMAKE.Text = "";
            comboMODEL.Text = "";
            comboVERSION.Text = "";
            comboSERIAL.Text = "";
            comboOS.Text = "";
            comboUSER.Text = "";
            comboDEPARTMENT.Text = "";
            textCOMMENTS.Text = "";
        }

        private void EnableControls()
        {
            toolStripButtonAddRecord.Enabled = true;
            toolStripButtonEditRecord.Enabled = true;
            toolStripButtonDeleteRecord.Enabled = true;
            checkPURCHASEDATE.Enabled = true;
            radioPURCHASEDATEEQUAL.Enabled = true;
            radioPURCHASEDATENEWER.Enabled = true;
            radioPURCHASEDATEOLDER.Enabled = true;
            monthCalendar1.Enabled = true;
            toolStripButtonSearchSelected.Enabled = true;
            toolStripButtonClearFilters.Enabled = true;
            checkRETIRED.Enabled = true;

            comboLOCATION.Enabled = true;
            comboTYPE.Enabled = true;
            comboNUMBER.Enabled = true;
            comboMAC.Enabled = true;
            comboMAKE.Enabled = true;
            comboMODEL.Enabled = true;
            comboVERSION.Enabled = true;
            comboSERIAL.Enabled = true;
            comboOS.Enabled = true;
            comboUSER.Enabled = true;
            comboDEPARTMENT.Enabled = true;
            textCOMMENTS.Enabled = true;

            saveToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
            recordsToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            sortToolStripMenuItem.Enabled = true;
            quickBackupToolStripMenuItem.Enabled = true;
            exportToolStripMenuItem1.Enabled = true;
            groupBox2.Enabled = true;
        }
        //CONTROLS CODE

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = program_title;
            DisableControls();
            dataOUTPUT.Width = this.Width - 440;
            dataOUTPUT.Height = this.Height - 80;
            this.MinimumSize = new System.Drawing.Size(979, 695);
            dataOUTPUT.DoubleBuffered(true);
            dataOUTPUT.ColumnCount = 14;
            dataOUTPUT.Columns[0].Name = "Location";
            dataOUTPUT.Columns[1].Name = "Type";
            dataOUTPUT.Columns[2].Name = "Number";
            dataOUTPUT.Columns[3].Name = "MAC Address";
            dataOUTPUT.Columns[4].Name = "Make";
            dataOUTPUT.Columns[5].Name = "Model";
            dataOUTPUT.Columns[6].Name = "Version";
            dataOUTPUT.Columns[7].Name = "Serial";
            dataOUTPUT.Columns[8].Name = "OS";
            dataOUTPUT.Columns[9].Name = "Assigned To";
            dataOUTPUT.Columns[10].Name = "Department";
            dataOUTPUT.Columns[11].Name = "Purchase Date";
            dataOUTPUT.Columns[12].Name = "Comments";
            dataOUTPUT.Columns[13].Name = "Retired";

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";

            foreach (DataGridViewColumn column in dataOUTPUT.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            AdjustSize();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) { track_selected_index = dataOUTPUT.CurrentRow.Index; }

        private void checkPURCHASEDATE_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private Color GetNewColor(Color current_color)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return colorDialog1.Color;

            }
            return current_color;
        }

        // ################################ COMBO SELECTED INDEX CHANGE ##############
        #region
        private void comboLOCATION_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboNUMBER_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboMAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboMAKE_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboMODEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboVERSION_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboSERIAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboUSER_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void comboDEPARTMENT_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        #endregion

        // ################################ PURCHASE DATE RADIO BUTTONS ##############
        #region
        private void radioPURCHASEDATEEQUAL_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void radioPURCHASEDATENEWER_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void radioPURCHASEDATEOLDER_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshList();
        }
        #endregion

        private void buttonSEARCHSELECTEDONLY_Click(object sender, EventArgs e)
        {
            int row;
            int col;

            row = dataOUTPUT.CurrentCell.RowIndex;
            col = dataOUTPUT.CurrentCell.ColumnIndex;

           if (col == 0)
           {
                int i = 0;
                while (i < comboLOCATION.Items.Count)
                {
                    if (comboLOCATION.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboLOCATION.SelectedIndex = i;
                        break;
                    }
                    i++;
                }          
           }

            if (col == 1)
            {
                int i = 0;
                while (i < comboTYPE.Items.Count)
                {
                    if (comboTYPE.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboTYPE.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 2)
            {
                int i = 0;
                while (i < comboNUMBER.Items.Count)
                {
                    if (comboNUMBER.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboNUMBER.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 3)
            {
                int i = 0;
                while (i < comboMAC.Items.Count)
                {
                    if (comboMAC.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMAC.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 4)
            {
                int i = 0;
                while (i < comboMAKE.Items.Count)
                {
                    if (comboMAKE.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMAKE.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 5)
            {
                int i = 0;
                while (i < comboMODEL.Items.Count)
                {
                    if (comboMODEL.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMODEL.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 6)
            {
                int i = 0;
                while (i < comboVERSION.Items.Count)
                {
                    if (comboVERSION.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboVERSION.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 7)
            {
                int i = 0;
                while (i < comboSERIAL.Items.Count)
                {
                    if (comboSERIAL.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboSERIAL.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 8)
            {
                int i = 0;
                while (i < comboOS.Items.Count)
                {
                    if (comboOS.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboOS.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 9)
            {
                int i = 0;
                while (i < comboUSER.Items.Count)
                {
                    if (comboUSER.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboUSER.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 10)
            {
                int i = 0;
                while (i < comboDEPARTMENT.Items.Count)
                {
                    if (comboDEPARTMENT.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboDEPARTMENT.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 11)
            {
                monthCalendar1.SetDate(DateTime.Parse(dataOUTPUT.CurrentRow.Cells[col].Value.ToString()));
                checkPURCHASEDATE.Checked = true;
            }
        }

        private void buttonCLEARFILTERS_Click(object sender, EventArgs e) { ClearFilters(); }

        private void radioNARROWRESULTS_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void radioEXPANDRESULTS_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void Form1_Resize(object sender, EventArgs e) { AdjustSize(); }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DM.SaveInventory();
            this.Text = program_title + " | " + DM.database_source_file;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e) { AddRecord(); }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) { EditRecord(); }

        private void checkNARROWRESULTS_CheckedChanged(object sender, EventArgs e) { RefreshList(); }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) { DeleteRecord(); }
        private void spreadsheetViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sview sv = new Sview(this, DM);
            sv.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            if (DM.inventory_database.Count > 0 && changes_to_data == true)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save the changes to your current inventory before closing it?", "Save Current Inventory?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    int listitems = 0;
                    StreamWriter SW = new StreamWriter(DM.database_source_file); // database_source_file

                    while (listitems < DM.inventory_database.Count)
                    {
                        SW.WriteLine(DM.inventory_database[listitems][0] + "," + DM.inventory_database[listitems][1] + "," + DM.inventory_database[listitems][2] + "," + DM.inventory_database[listitems][3] + "," + DM.inventory_database[listitems][4] + "," + DM.inventory_database[listitems][5] + "," + DM.inventory_database[listitems][6] + "," + DM.inventory_database[listitems][7] + "," + DM.inventory_database[listitems][8] + "," + DM.inventory_database[listitems][9] + "," + DM.inventory_database[listitems][10] + "," + DM.inventory_database[listitems][11] + "," + DM.inventory_database[listitems][12] + "," + DM.inventory_database[listitems][13]);
                        listitems++;
                    }
                    SW.Close();

                    DM.CloseInventory();
                    OpenInventory();
                }
                else if (dialogResult == DialogResult.No)
                {
                    DM.CloseInventory();
                    OpenInventory();
                }
            }
            else
            {
                DM.CloseInventory();
                OpenInventory();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DM.inventory_database.Count > 0 && changes_to_data == true)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save the changes to your current inventory before closing it?", "Save Current Inventory?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    DM.SaveInventory();
                    DM.CloseInventory();
                }
                else if (dialogResult == DialogResult.No)
                {
                    DM.CloseInventory();
                }
            }
            else
            {
                DM.CloseInventory();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DM.inventory_database.Count > 0 && changes_to_data == true)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save the changes to your current inventory before closing it?", "Save Current Inventory?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    DM.SaveInventory();
                    DM.CloseInventory();
                }
                else if (dialogResult == DialogResult.No)
                {
                    DM.CloseInventory();
                }
            }
            else
            {
                DM.CloseInventory();
                EnableControls();
            }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is planned and will come in a future version.");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DM.SaveInventoryAs();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DM.inventory_database.Count > 0 && changes_to_data == true)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save the changes to your current inventory before closing it?", "Save Current Inventory?", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    DM.SaveInventory();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //DM.CloseInventory();
                }

                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void numberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "number";
            RecordSort();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "location";
            RecordSort();
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "type";
            RecordSort();
        }

        private void mACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "mac";
            RecordSort();
        }

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "make";
            RecordSort();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "model";
            RecordSort();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "version";
            RecordSort();
        }

        private void serialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "serial";
            RecordSort();
        }

        private void oSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "os";
            RecordSort();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "assigned";
            RecordSort();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "department";
            RecordSort();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort_mode = "date";
            RecordSort();
        }

        private void quickBackupToolStripMenuItem_Click(object sender, EventArgs e) { DM.RunBackup(); }

        private void button1_Click(object sender, EventArgs e) { EditRecord(); }

        private void comboUSER_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboLOCATION_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboTYPE_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboNUMBER_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboMAC_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboMAKE_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboMODEL_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboVERSION_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboSERIAL_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboOS_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }

        private void comboDEPARTMENT_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }


        private void button3_Click(object sender, EventArgs e) { DeleteRecord(); }

        private void button2_Click(object sender, EventArgs e) { AddRecord(); }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportOptions ReportForm = new ReportOptions(this, DM);
            ReportForm.Show();
        }

        private void textCOMMENTS_KeyUp(object sender, KeyEventArgs e) { RefreshList(); }
        private void ToolStripButton1_Click(object sender, EventArgs e) { AddRecord(); }
        private void ToolStripButton2_Click(object sender, EventArgs e) { EditRecord(); }
        private void ToolStripButton3_Click(object sender, EventArgs e) { DeleteRecord(); }

        private void ToolStripButton5_Click(object sender, EventArgs e) { ClearFilters(); }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            int row;
            int col;

            row = dataOUTPUT.CurrentCell.RowIndex;
            col = dataOUTPUT.CurrentCell.ColumnIndex;

            if (col == 0)
            {
                int i = 0;
                while (i < comboLOCATION.Items.Count)
                {
                    if (comboLOCATION.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboLOCATION.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 1)
            {
                int i = 0;
                while (i < comboTYPE.Items.Count)
                {
                    if (comboTYPE.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboTYPE.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 2)
            {
                int i = 0;
                while (i < comboNUMBER.Items.Count)
                {
                    if (comboNUMBER.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboNUMBER.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 3)
            {
                int i = 0;
                while (i < comboMAC.Items.Count)
                {
                    if (comboMAC.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMAC.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 4)
            {
                int i = 0;
                while (i < comboMAKE.Items.Count)
                {
                    if (comboMAKE.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMAKE.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 5)
            {
                int i = 0;
                while (i < comboMODEL.Items.Count)
                {
                    if (comboMODEL.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboMODEL.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 6)
            {
                int i = 0;
                while (i < comboVERSION.Items.Count)
                {
                    if (comboVERSION.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboVERSION.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 7)
            {
                int i = 0;
                while (i < comboSERIAL.Items.Count)
                {
                    if (comboSERIAL.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboSERIAL.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 8)
            {
                int i = 0;
                while (i < comboOS.Items.Count)
                {
                    if (comboOS.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboOS.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 9)
            {
                int i = 0;
                while (i < comboUSER.Items.Count)
                {
                    if (comboUSER.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboUSER.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 10)
            {
                int i = 0;
                while (i < comboDEPARTMENT.Items.Count)
                {
                    if (comboDEPARTMENT.Items[i].ToString() == dataOUTPUT.CurrentRow.Cells[col].Value.ToString())
                    {
                        comboDEPARTMENT.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            if (col == 11)
            {
                monthCalendar1.SetDate(DateTime.Parse(dataOUTPUT.CurrentRow.Cells[col].Value.ToString()));
                checkPURCHASEDATE.Checked = true;
            }
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnLocationClear_Click(object sender, EventArgs e) 
        { 
            comboLOCATION.Text = "";
            RefreshList();
        }

        private void btnTypeClear_Click(object sender, EventArgs e) 
        { 
            comboTYPE.Text = "";
            RefreshList();
        }

        private void btnNumberClear_Click(object sender, EventArgs e) 
        { 
            comboNUMBER.Text = "";
            RefreshList();
        }

        private void btnMACClear_Click(object sender, EventArgs e) 
        { 
            comboMAC.Text = "";
            RefreshList();
        }

        private void btnMakeClear_Click(object sender, EventArgs e) 
        { 
            comboMAKE.Text = "";
            RefreshList();
        }

        private void btnModelClear_Click(object sender, EventArgs e)
        {
            comboMODEL.Text = "";
            RefreshList();
        }

        private void btnVersionClear_Click(object sender, EventArgs e)
        {
            comboVERSION.Text = "";
            RefreshList();
        }

        private void btnSerialClear_Click(object sender, EventArgs e)
        {
            comboSERIAL.Text = "";
            RefreshList();
        }

        private void btnOSClear_Click(object sender, EventArgs e)
        {
            comboOS.Text = "";
            RefreshList();
        }

        private void btnUserClear_Click(object sender, EventArgs e)
        {
            comboUSER.Text = "";
            RefreshList();
        }

        private void btnDepartmentClear_Click(object sender, EventArgs e)
        {
            comboDEPARTMENT.Text = "";
            RefreshList();
        }

        private void btnCommentsClear_Click(object sender, EventArgs e)
        {
            textCOMMENTS.Text = "";
            RefreshList();
        }

        private void numbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_mode = true;
            report_type = "number";
            RefreshList();
            reportingToolStripMenuItem.BackColor = Color.Red;
            sort_mode = "number";
            RecordSort();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_mode = true;
            report_type = "user";
            RefreshList();
            reportingToolStripMenuItem.BackColor = Color.Red;
            sort_mode = "assigned";
            RecordSort();
        }

        private void serialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_mode = true;
            report_type = "serial";
            RefreshList();
            reportingToolStripMenuItem.BackColor = Color.Red;
            sort_mode = "serial";
            RecordSort();
        }

        private void turnReportingOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_mode = false;
            RefreshList();
            reportingToolStripMenuItem.BackColor = Color.FromArgb(244, 244, 244);
            sort_mode = "number";
            RecordSort();
        }


    }
}