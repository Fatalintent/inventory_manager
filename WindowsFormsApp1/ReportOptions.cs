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
    public partial class ReportOptions : Form
    {

        Form1 FORM1;
        DataManager DM;


        public ReportOptions(Form1 form1, DataManager dm)
        {
            InitializeComponent();
            FORM1 = form1;
            DM = dm;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int row = 0;
            //int col = 0;
            string title_string = "";
            string record_line = "";
            string export_file = "";

            bool[] cols = new bool[14];
            int report_col_count = 0;

            for (int i = 0; i < 14; i++)
            {
                cols[i] = false;
            }


            if (checkLOCATION.Checked == true)
            {
                if (checkTYPE.Checked == true || checkNUMBER.Checked == true || checkMAC.Checked == true || checkMAKE.Checked == true || checkMODEL.Checked == true || checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "LOCATION,";
                }

                else { title_string += "LOCATION"; }
                cols[0] = true;
                report_col_count++;
            }

            if (checkTYPE.Checked == true)
            {
                if (checkNUMBER.Checked == true || checkMAC.Checked == true || checkMAKE.Checked == true || checkMODEL.Checked == true || checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "TYPE,";
                }

                else { title_string += "TYPE"; }
                cols[1] = true;
                report_col_count++;
            }

            if (checkNUMBER.Checked == true)
            {
                if (checkMAC.Checked == true || checkMAKE.Checked == true || checkMODEL.Checked == true || checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "NUMBER,";
                }

                else { title_string += "NUMBER"; }
                cols[2] = true;
                report_col_count++;
            }

            if (checkMAC.Checked == true)
            {
                if (checkMAKE.Checked == true || checkMODEL.Checked == true || checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "MAC,";
                }

                else { title_string += "MAC"; }
                cols[3] = true;
                report_col_count++;
            }

            if (checkMAKE.Checked == true)
            {
                if (checkMODEL.Checked == true || checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "MAKE,";
                }

                else { title_string += "MAKE"; }
                cols[4] = true;
                report_col_count++;
            }

            if (checkMODEL.Checked == true)
            {
                if (checkVERSION.Checked == true || checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "MODEL,";
                }

                else { title_string += "MODEL"; }
                cols[5] = true;
                report_col_count++;
            }

            if (checkVERSION.Checked == true)
            {
                if (checkSERIAL.Checked == true || checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "VERSION,";
                }

                else { title_string += "VERSION"; }
                cols[6] = true;
                report_col_count++;
            }

            if (checkSERIAL.Checked == true)
            {
                if (checkOS.Checked == true || checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "SERIAL,";
                }

                else { title_string += "SERIAL"; }
                cols[7] = true;
                report_col_count++;
            }

            if (checkOS.Checked == true)
            {
                if (checkUSER.Checked == true || checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "OS,";
                }

                else { title_string += "OS"; }
                cols[8] = true;
                report_col_count++;
            }

            if (checkUSER.Checked == true)
            {
                if (checkDEPARTMENT.Checked == true || checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "USER,";
                }

                else { title_string += "USER"; }
                cols[9] = true;
                report_col_count++;
            }

            if (checkDEPARTMENT.Checked == true)
            {
                if (checkPURCHASEDATE.Checked == true || checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "DEPARTMENT,";
                }

                else { title_string += "DEPARTMENT"; }
                cols[10] = true;
                report_col_count++;
            }

            if (checkPURCHASEDATE.Checked == true)
            {
                if (checkCOMMENTS.Checked == true || checkRETIRED.Checked == true)
                {
                    title_string += "PURCHASE DATE,";
                }

                else { title_string += "PURCHASE DATE"; }
                cols[11] = true;
                report_col_count++;
            }

            if (checkCOMMENTS.Checked == true)
            {
                if (checkRETIRED.Checked == true)
                {
                    title_string += "COMMENTS,";
                }

                else { title_string += "COMMENTS"; }
                cols[12] = true;
                report_col_count++;
            }

            if (checkRETIRED.Checked == true)
            {
                title_string += "RETIRED";
                cols[13] = true;
                report_col_count++;
            }

            

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Comma Delimited Values|*.csv";
            saveFileDialog1.Title = "Save as .csv (Compatible with Excel)";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                export_file = saveFileDialog1.FileName;
                StreamWriter SW = new StreamWriter(export_file);
                SW.WriteLine(title_string);
                int report_current_col = 0;

                if (radioButton1.Checked == true)
                {
                    for (int row = 0; row < DM.inventory_database.Count(); row++)
                    {
                        //SW.WriteLine(DM.inventory_database[FORM1.listbox_tracker[i]][0] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][1] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][2] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][3] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][4] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][5] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][6] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][7] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][8] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][9] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][10] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][11] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][12] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][13]);
                        for (int col = 0; col < 14; col++)
                        {
                            if (cols[col] == true)
                            {
                                if (report_current_col + 1 == report_col_count)
                                {
                                    record_line += DM.inventory_database[row][col];
                                }
                                else
                                {
                                    record_line += DM.inventory_database[row][col] + ",";
                                }
                                report_current_col++;
                            }
                        }
                        report_current_col = 0;
                        SW.WriteLine(record_line);
                        record_line = "";
                    }
                }

                else if (radioButton2.Checked == true)
                {

                    for (int row = 0; row < FORM1.listbox_tracker.Count(); row++)
                    {
                        //SW.WriteLine(DM.inventory_database[FORM1.listbox_tracker[i]][0] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][1] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][2] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][3] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][4] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][5] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][6] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][7] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][8] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][9] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][10] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][11] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][12] + "," + DM.inventory_database[FORM1.listbox_tracker[i]][13]);
                        for (int col = 0; col < 14; col++)
                        {
                            if (cols[col] == true)
                            {
                                if (report_current_col + 1 == report_col_count)
                                {
                                    record_line += DM.inventory_database[FORM1.listbox_tracker[row]][col];
                                }
                                else
                                {
                                    record_line += DM.inventory_database[FORM1.listbox_tracker[row]][col] + ",";
                                }
                                report_current_col++;
                            }
                        }
                        report_current_col = 0;
                        SW.WriteLine(record_line);
                        record_line = "";
                    }
                }
                
                SW.Close();
                MessageBox.Show("Report: " + export_file + " has been exported as a .csv file. (Compatible with Excel)");
                this.Close();
            }
        }
           

        private void ReportOptions_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Location = screen.Bounds.Location;
            radioButton2.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}