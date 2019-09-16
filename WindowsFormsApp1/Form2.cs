using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public List<List<String>> inventory_database;
        private Form1 FORM1;
        private DataManager DM;


        public Form2(Form1 f1, DataManager datamanager)
        {
            InitializeComponent();
            FORM1 = f1;
            DM = datamanager;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Location = screen.Bounds.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Add")
            {

                /*string get_current_data = "";
                foreach (string line in File.ReadLines(FORM1.database_source_file))
                {
                    if (line != "")
                    {
                        get_current_data = get_current_data + line + "\n";
                    }
                }*/

                List<string> addlist = new List<string> (new string[14]);

                textLOCATION.Text = CleanCommas(textLOCATION.Text);
                textTYPE.Text = CleanCommas(textTYPE.Text);
                textNUMBER.Text = CleanCommas(textNUMBER.Text);

                if (int.TryParse(textNUMBER.Text, out int testout) == false)
                {
                    textNUMBER.Text = "";
                }

                textMAC.Text = CleanCommas(textMAC.Text);
                textMAKE.Text = CleanCommas(textMAKE.Text);
                textMODEL.Text = CleanCommas(textMODEL.Text);
                textVERSION.Text = CleanCommas(textVERSION.Text);
                textSERIAL.Text = CleanCommas(textSERIAL.Text);
                textOS.Text = CleanCommas(textOS.Text);
                textUSER.Text = CleanCommas(textUSER.Text);
                textDEPARTMENT.Text = CleanCommas(textDEPARTMENT.Text);
                textCOMMENTS.Text = CleanCommas(textCOMMENTS.Text);

                addlist[0] = textLOCATION.Text;
                addlist[1] = textTYPE.Text;
                addlist[2] = textNUMBER.Text;
                addlist[3] = textMAC.Text;
                addlist[4] = textMAKE.Text;
                addlist[5] = textMODEL.Text;
                addlist[6] = textVERSION.Text;
                addlist[7] = textSERIAL.Text;
                addlist[8] = textOS.Text;
                addlist[9] = textUSER.Text;
                addlist[10] = textDEPARTMENT.Text;

                if (checkBox1.Checked == true)
                {
                    addlist[11] = "";
                }

                else
                {
                    addlist[11] = monthCalendar1.SelectionRange.Start.ToShortDateString();
                }

                addlist[12] = textCOMMENTS.Text;
                addlist[13] = comboRETIRED.Text;

                DM.inventory_database.Add(addlist);
                //FORM1.RefreshList();
                //FORM1.RefreshCombos();

                Sorting sortingnotification = new Sorting();
                sortingnotification.label1.Text = "Refreshing Inventory";
                sortingnotification.Show();
                sortingnotification.Refresh();
                sortingnotification.TopMost = true;
                sortingnotification.Activate();

                DatabaseManager dbm = new DatabaseManager();
                DM.inventory_database = dbm.SortDatabase(DM.inventory_database, FORM1.sort_mode);

                FORM1.RefreshCombos();
                FORM1.RefreshList();

                sortingnotification.Close();

                FORM1.changes_to_data = true;

                this.Close();
            }

            if (button1.Text == "Edit")
            {


                textLOCATION.Text = CleanCommas(textLOCATION.Text);
                textTYPE.Text = CleanCommas(textTYPE.Text);
                textNUMBER.Text = CleanCommas(textNUMBER.Text);

                if (int.TryParse(textNUMBER.Text, out int testout) == false)
                {
                    textNUMBER.Text = "";
                }

                textMAC.Text = CleanCommas(textMAC.Text);
                textMAKE.Text = CleanCommas(textMAKE.Text);
                textMODEL.Text = CleanCommas(textMODEL.Text);
                textVERSION.Text = CleanCommas(textVERSION.Text);
                textSERIAL.Text = CleanCommas(textSERIAL.Text);
                textOS.Text = CleanCommas(textOS.Text);
                textUSER.Text = CleanCommas(textUSER.Text);
                textDEPARTMENT.Text = CleanCommas(textDEPARTMENT.Text);
                textCOMMENTS.Text = CleanCommas(textCOMMENTS.Text);

                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][0] = textLOCATION.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][1] = textTYPE.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][2] = textNUMBER.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][3] = textMAC.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][4] = textMAKE.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][5] = textMODEL.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][6] = textVERSION.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][7] = textSERIAL.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][8] = textOS.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][9] = textUSER.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][10] = textDEPARTMENT.Text;

                if (checkBox1.Checked == true)
                {
                    DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][11] = "";
                }

                else
                {
                    DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][11] = monthCalendar1.SelectionRange.Start.ToShortDateString();

                }

                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][12] = textCOMMENTS.Text;
                DM.inventory_database[FORM1.listbox_tracker[FORM1.track_selected_index]][13] = comboRETIRED.Text;

                FORM1.RefreshList();
                FORM1.RefreshCombos();

                if (FORM1.dataOUTPUT.Rows.Count != 0)
                {
                    if (FORM1.track_selected_index == 0)
                    {
                        FORM1.track_selected_index = 0;
                    }

                    if (FORM1.dataOUTPUT.Rows.Count <= FORM1.track_selected_index)
                    {
                        FORM1.track_selected_index = FORM1.dataOUTPUT.Rows.Count - 1;
                    }

                    FORM1.dataOUTPUT.Rows[FORM1.track_selected_index].Cells[0].Selected = true;
                }

                FORM1.changes_to_data = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                monthCalendar1.Visible = false;
            }

            else if (checkBox1.Checked == false)
            {
                monthCalendar1.Visible = true;
            }
        }

        private string CleanCommas(string check_string)
        {
            string return_string = "";
            int x = 0;
            char[] get_chars = check_string.ToCharArray();

            while (x < get_chars.Length)
            {
                if (get_chars[x].ToString() == ",")
                {
                    return_string += "";
                }

                else
                {
                    return_string += get_chars[x].ToString();
                }
                x++;
            }
            return return_string;
        }

        //###################### TEXT BOX COMMA HANDLING ####################
        private void textLOCATION_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textTYPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textNUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textMAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textMAKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textMODEL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textVERSION_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textSERIAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textUSER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textDEPARTMENT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void textCOMMENTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }
    }
}
