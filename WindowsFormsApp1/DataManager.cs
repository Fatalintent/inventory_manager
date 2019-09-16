using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public class DataManager
    {
        
        public List<List<String>> inventory_database = new List<List<string>>();
        public List<List<bool>> highlight_list = new List<List<bool>>();
        public string database_source_file = "";
        public bool checkcancel = false;
        public string sort_mode = "number";
        public bool changes_to_data = false;
        Form1 FORM1;

        public DataManager(Form1 f1)
        {
            FORM1 = f1;
        }

        public List<int> filter_results(string loc, string type, string num, string mac, string make, string model, string version, string serial, string os, string user, string dept, DateTime cal, string comments, bool datecheck, int dateradio, bool retiredcheck, List<List<String>> inventory_database, bool narrow)
        {

            List<int> filtered_list = new List<int>();
            highlight_list.Clear();

            bool locfound = false;
            bool typefound = false;
            bool numfound = false;
            bool macfound = false;
            bool makefound = false;
            bool modelfound = false;
            bool versionfound = false;
            bool serialfound = false;
            bool osfound = false;
            bool userfound = false;
            bool deptfound = false;
            bool datefound = false;
            bool commentsfound = false;

            if (narrow == true)
            {
                for (int i = 0; i < inventory_database.Count(); i++)
                {
                    locfound = false;
                    typefound = false;
                    numfound = false;
                    macfound = false;
                    makefound = false;
                    modelfound = false;
                    versionfound = false;
                    serialfound = false;
                    osfound = false;
                    userfound = false;
                    deptfound = false;
                    datefound = false;
                    commentsfound = false;

                    bool filtered = false;
                    bool bad_found = false;

                    if (retiredcheck == false)
                    {
                        if (inventory_database[i][13].ToLower() == "t\n" || inventory_database[i][13].ToLower() == "t")
                        {
                            bad_found = true;
                        }
                    }

                    if (retiredcheck == true)
                    {
                        if (inventory_database[i][13].ToLower() == "f\n" || inventory_database[i][13].ToLower() == "f")
                        {
                            bad_found = true;
                        }
                    }

                    if (bad_found == false)
                    {
                        if (loc == "" && type == "" && num == "" && mac == "" && make == "" && model == "" && version == "" && serial == "" && os == "" && user == "" && dept == "" && datecheck == false && comments == "")
                        {
                            filtered = true;
                        }
                        else
                        {
                            if (loc != "")
                            {
                                if (inventory_database[i][0].ToLower().Contains(loc.ToLower()))
                                {
                                    filtered = true;
                                    locfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (type != "")
                            {
                                if (inventory_database[i][1].ToLower().Contains(type.ToLower()))
                                {
                                    filtered = true;
                                    typefound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (num != "")
                            {
                                if (inventory_database[i][2].ToLower().Contains(num.ToLower()))
                                {
                                    filtered = true;
                                    numfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (mac != "")
                            {
                                if (inventory_database[i][3].ToLower().Contains(mac.ToLower()))
                                {
                                    filtered = true;
                                    macfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (make != "")
                            {
                                if (inventory_database[i][4].ToLower().Contains(make.ToLower()))
                                {
                                    filtered = true;
                                    makefound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (model != "")
                            {
                                if (inventory_database[i][5].ToLower().Contains(model.ToLower()))
                                {
                                    filtered = true;
                                    modelfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (version != "")
                            {
                                if (inventory_database[i][6].ToLower().Contains(version.ToLower()))
                                {
                                    filtered = true;
                                    versionfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (serial != "")
                            {
                                if (inventory_database[i][7].ToLower().Contains(serial.ToLower()))
                                {
                                    filtered = true;
                                    serialfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (os != "")
                            {
                                if (inventory_database[i][8].ToLower().Contains(os.ToLower()))
                                {
                                    filtered = true;
                                    osfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (user != "")
                            {
                                if (inventory_database[i][9].ToLower().Contains(user.ToLower()))
                                {
                                    filtered = true;
                                    userfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (dept != "")
                            {
                                if (inventory_database[i][10].ToLower().Contains(dept.ToLower()))
                                {
                                    filtered = true;
                                    deptfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (datecheck == true)
                            {
                                if (inventory_database[i][11] != "")
                                {
                                    DateTime crap;
                                    if (DateTime.TryParse(inventory_database[i][11], out crap))
                                    {
                                        DateTime converted_date = DateTime.Parse(inventory_database[i][11]);

                                        if (dateradio == 0)
                                        {
                                            if (converted_date == cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                            else
                                            {
                                                bad_found = true;
                                            }
                                        }

                                        if (dateradio == 1)
                                        {
                                            if (converted_date < cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                            else
                                            {
                                                bad_found = true;
                                            }
                                        }

                                        if (dateradio == 2)
                                        {
                                            if (converted_date > cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                            else
                                            {
                                                bad_found = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }


                            if (comments != "")
                            {
                                if (inventory_database[i][12].ToLower().Contains(comments.ToLower()))
                                {
                                    filtered = true;
                                    commentsfound = true;
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }
                        }
                    }

                    if (bad_found == true)
                    {
                        filtered = false;
                        //dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[0].Style.BackColor = buttonLOCATIONCOLOR.BackColor;
                    }

                    if (filtered == true)
                    {
                        filtered_list.Add(i);
                        List<bool> colorlist = new List<bool>();

                        colorlist.Add(locfound);
                        colorlist.Add(typefound);
                        colorlist.Add(numfound);
                        colorlist.Add(macfound);
                        colorlist.Add(makefound);
                        colorlist.Add(modelfound);
                        colorlist.Add(versionfound);
                        colorlist.Add(serialfound);
                        colorlist.Add(osfound);
                        colorlist.Add(userfound);
                        colorlist.Add(deptfound);
                        colorlist.Add(datefound);
                        colorlist.Add(commentsfound);

                        highlight_list.Add(colorlist);
                    }
                }
            }

            else
            {
                for (int i = 0; i < inventory_database.Count(); i++)
                {
                    locfound = false;
                    typefound = false;
                    numfound = false;
                    macfound = false;
                    makefound = false;
                    modelfound = false;
                    versionfound = false;
                    serialfound = false;
                    osfound = false;
                    userfound = false;
                    deptfound = false;
                    datefound = false;
                    commentsfound = false;

                    bool filtered = false;
                    bool bad_found = false;

                    if (retiredcheck == false)
                    {
                        if (inventory_database[i][13].ToLower() == "t\n" || inventory_database[i][13].ToLower() == "t")
                        {
                            bad_found = true;
                        }
                    }

                    if (retiredcheck == true)
                    {
                        if (inventory_database[i][13].ToLower() == "f\n" || inventory_database[i][13].ToLower() == "f")
                        {
                            bad_found = true;
                        }
                    }

                    if (bad_found == false)
                    {
                        if (loc == "" && type == "" && num == "" && mac == "" && make == "" && model == "" && version == "" && serial == "" && os == "" && user == "" && dept == "" && datecheck == false && comments == "")
                        {
                            filtered = true;
                        }
                        else
                        {
                            if (loc != "")
                            {
                                if (inventory_database[i][0].ToLower().Contains(loc.ToLower()))
                                {
                                    filtered = true;
                                    locfound = true;
                                }
                            }

                            if (type != "")
                            {
                                if (inventory_database[i][1].ToLower().Contains(type.ToLower()))
                                {
                                    filtered = true;
                                    typefound = true;
                                }
                            }

                            if (num != "")
                            {
                                if (inventory_database[i][2].ToLower().Contains(num.ToLower()))
                                {
                                    filtered = true;
                                    numfound = true;
                                }
                            }

                            if (mac != "")
                            {
                                if (inventory_database[i][3].ToLower().Contains(mac.ToLower()))
                                {
                                    filtered = true;
                                    macfound = true;
                                }
                            }

                            if (make != "")
                            {
                                if (inventory_database[i][4].ToLower().Contains(make.ToLower()))
                                {
                                    filtered = true;
                                    makefound = true;
                                }
                            }

                            if (model != "")
                            {
                                if (inventory_database[i][5].ToLower().Contains(model.ToLower()))
                                {
                                    filtered = true;
                                    modelfound = true;
                                }
                            }

                            if (version != "")
                            {
                                if (inventory_database[i][6].ToLower().Contains(version.ToLower()))
                                {
                                    filtered = true;
                                    versionfound = true;
                                }
                            }

                            if (serial != "")
                            {
                                if (inventory_database[i][7].ToLower().Contains(serial.ToLower()))
                                {
                                    filtered = true;
                                    serialfound = true;
                                }
                            }

                            if (os != "")
                            {
                                if (inventory_database[i][8].ToLower().Contains(os.ToLower()))
                                {
                                    filtered = true;
                                    osfound = true;
                                }
                            }

                            if (user != "")
                            {
                                if (inventory_database[i][9].ToLower().Contains(user.ToLower()))
                                {
                                    filtered = true;
                                    userfound = true;
                                }
                            }

                            if (dept != "")
                            {
                                if (inventory_database[i][10].ToLower().Contains(dept.ToLower()))
                                {
                                    filtered = true;
                                    deptfound = true;
                                }
                            }

                            if (datecheck == true)
                            {
                                if (inventory_database[i][11] != "")         
                                {
                                    DateTime crap;
                                    if (DateTime.TryParse(inventory_database[i][11], out crap))
                                    {
                                        DateTime converted_date = DateTime.Parse(inventory_database[i][11]);

                                        if (dateradio == 0)
                                        {
                                            if (converted_date == cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                        }

                                        if (dateradio == 1)
                                        {
                                            if (converted_date < cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                        }

                                        if (dateradio == 2)
                                        {
                                            if (converted_date > cal)
                                            {
                                                filtered = true;
                                                datefound = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        datefound = false;
                                        filtered = false;
                                    }
                                }
                                else
                                {
                                    bad_found = true;
                                }
                            }

                            if (comments != "")
                            {
                                if (inventory_database[i][12].ToLower().Contains(comments.ToLower()))
                                {
                                    filtered = true;
                                    commentsfound = true;
                                }
                            }

                            if (locfound == false && typefound == false && numfound == false && macfound == false && makefound == false && modelfound == false && versionfound == false && serialfound == false && osfound == false && userfound == false && deptfound == false && datefound == false && commentsfound == false)
                            {
                                bad_found = true;
                            }
                        }
                    }

                    //this seems redundant
                    if (bad_found == true)
                    {
                        filtered = false;
                        //dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[0].Style.BackColor = buttonLOCATIONCOLOR.BackColor;
                    }

                    if (filtered == true)
                    {
                        filtered_list.Add(i);
                        List<bool> colorlist = new List<bool>();

                        colorlist.Add(locfound);
                        colorlist.Add(typefound);
                        colorlist.Add(numfound);
                        colorlist.Add(macfound);
                        colorlist.Add(makefound);
                        colorlist.Add(modelfound);
                        colorlist.Add(versionfound);
                        colorlist.Add(serialfound);
                        colorlist.Add(osfound);
                        colorlist.Add(userfound);
                        colorlist.Add(deptfound);
                        colorlist.Add(datefound);
                        colorlist.Add(commentsfound);

                        highlight_list.Add(colorlist);
                    }
                }
            }

            return filtered_list;
        }

        public void SaveInventoryAs()
        {
            bool saved_okay = false;
            string saveas_file = "";

            if (inventory_database.Count > 0)
            {
                int row = 0;
                int col = 0;
                string record_line = "";
                string save_file = "";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Inventory Management Data|*.imd";
                saveFileDialog1.Title = "Save";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    save_file = saveFileDialog1.FileName;
                    saveas_file = save_file;
                    StreamWriter SW = new StreamWriter(save_file);
                    database_source_file = save_file;
                    while (row < inventory_database.Count())
                    {
                        while (col < inventory_database[0].Count())
                        {
                            if (col + 1 == inventory_database[0].Count())
                            {
                                record_line += inventory_database[row][col];
                            }
                            else
                            {
                                record_line += inventory_database[row][col] + ",";
                            }

                            col++;
                        }
                        SW.WriteLine(record_line);
                        record_line = "";
                        col = 0;
                        row++;
                    }

                    SW.Close();

                    //MessageBox.Show("Inventory File: " + save_file + " has been saved.");
                    saved_okay = true;
                    FORM1.Text = FORM1.program_title + database_source_file;
                }

                //If the save dialog name returned is nothing, why do anything?
                else
                {
                    FORM1.Text = FORM1.program_title + database_source_file;
                }
            }
            else
            {
                MessageBox.Show("This inventory has no records and cannot be saved.");
            }

            //CloseInventory();

            if (saved_okay == true)
            {
                database_source_file = saveas_file;
                FORM1.changes_to_data = false;
                UpdateInventory();
            }
        }

        public void SaveInventory()
        {
            if (database_source_file != "")
            {
                int listitems = 0;
                StreamWriter SW = new StreamWriter(database_source_file); // database_source_file

                while (listitems < inventory_database.Count)
                {
                    SW.WriteLine(inventory_database[listitems][0] + "," + inventory_database[listitems][1] + "," + inventory_database[listitems][2] + "," + inventory_database[listitems][3] + "," + inventory_database[listitems][4] + "," + inventory_database[listitems][5] + "," + inventory_database[listitems][6] + "," + inventory_database[listitems][7] + "," + inventory_database[listitems][8] + "," + inventory_database[listitems][9] + "," + inventory_database[listitems][10] + "," + inventory_database[listitems][11] + "," + inventory_database[listitems][12] + "," + inventory_database[listitems][13]);
                    listitems++;
                }
                SW.Close();
                FORM1.changes_to_data = false;
                MessageBox.Show(database_source_file + " has been saved.");        
            }

            else
            {
                if (inventory_database.Count > 0)
                {
                    int row = 0;
                    int col = 0;
                    string record_line = "";
                    string save_file = "";


                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Inventory Management Data|*.imd";
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.ShowDialog();

                    if (saveFileDialog1.FileName != "")
                    {
                        save_file = saveFileDialog1.FileName;
                        StreamWriter SW = new StreamWriter(save_file);
                        database_source_file = save_file;
                        while (row < inventory_database.Count())
                        {
                            while (col < inventory_database[0].Count())
                            {
                                if (col + 1 == inventory_database[0].Count())
                                {
                                    record_line += inventory_database[row][col];
                                }
                                else
                                {
                                    record_line += inventory_database[row][col] + ",";
                                }

                                col++;
                            }
                            SW.WriteLine(record_line);
                            record_line = "";
                            col = 0;
                            row++;
                        }

                        SW.Close();
                        //CloseInventory();
                        FORM1.changes_to_data = false;
                        MessageBox.Show("Inventory File: " + save_file + " has been saved.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("This inventory has no records and cannot be saved.");
                }
            }
        }

        public void RunBackup()
        {
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\BACKUPS");

            int listitems = 0;
            StreamWriter SW = new StreamWriter(Application.StartupPath + @"\BACKUPS\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".imd"); // database_source_file

            while (listitems < inventory_database.Count)
            {
                SW.WriteLine(inventory_database[listitems][0] + "," + inventory_database[listitems][1] + "," + inventory_database[listitems][2] + "," + inventory_database[listitems][3] + "," + inventory_database[listitems][4] + "," + inventory_database[listitems][5] + "," + inventory_database[listitems][6] + "," + inventory_database[listitems][7] + "," + inventory_database[listitems][8] + "," + inventory_database[listitems][9] + "," + inventory_database[listitems][10] + "," + inventory_database[listitems][11] + "," + inventory_database[listitems][12] + "," + inventory_database[listitems][13]);
                listitems++;
            }
            SW.Close();

            MessageBox.Show("Database has been backed up to the BACKUPS folder as a timestamped copy.\n\n NOTE: THIS BACKUP WILL BACKUP ALL UNSAVED CHANGES MADE. IF YOU HAVE MADE ANY CHANGES THAT YOU ARE UNSURE ABOUT PLEASE BE AWARE OF THIS BEFORE RELYING ON THIS QUICK BACKUP.");
        }

        public bool OpenInventory()
        {
            bool result = false;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Inventory Manager Data(*.imd)| *.imd";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FORM1.DisplayNotification();
                database_source_file = openFileDialog1.FileName;

                result = UpdateInventory();
                
            }
            return result;
        }

        public void CloseInventory()
        {
            //This is the reset method. Everything needs to be reset as if the program has restarted.
            inventory_database = new List<List<string>>();
            highlight_list = new List<List<bool>>();
            database_source_file = "";

            FORM1.toolStripStatusLabel1.Text = "";
            FORM1.toolStripStatusLabel2.Text = "";

            checkcancel = false;
            sort_mode = "number";
            changes_to_data = false;

            FORM1.listbox_tracker = new List<int>();
            FORM1.track_selected_index = 0;
            FORM1.Text = FORM1.program_title;
            sort_mode = "number";
            changes_to_data = false;

            FORM1.ClearFilters();
            FORM1.DisableControls();
            FORM1.dataOUTPUT.Rows.Clear();
            FORM1.changes_to_data = false;

        }

        public bool UpdateInventory()
        {

            bool valid_check = true;

            inventory_database.Clear();
            foreach (string line in File.ReadLines(database_source_file))
            {
                if (line != "")
                {
                    List<string> get_line_list = line.Split(',').ToList();
                    if (get_line_list.Count == 14)
                    {
                        inventory_database.Add(get_line_list);
                    }

                    else
                    {        
                        MessageBox.Show("This inventory csv is not valid. Inventory csv files can only have 14 columns. A row was found with " + get_line_list.Count() + ". Further information on the specific line is: " + line);
                        valid_check = false;
                        CloseInventory();
                        break;
                    }
                }
            }

            if (valid_check == true)
            {
                DatabaseManager dbm = new DatabaseManager();
                inventory_database = dbm.SortDatabase(inventory_database, sort_mode);
            }         

            return valid_check;
        }

        //public void ExportEntireDatabase()
        //{
        //    int row = 0;
        //    int col = 0;
        //    string title_string = "";
        //    string record_line = "";
        //    string export_file = "";

        //    bool[] cols = new bool[14];
        //    int report_col_count = 0;

        //    for (int i = 0; i < 14; i++)
        //    {
        //        cols[i] = true;
        //    }

        //    //make sure to sort by number for entire database just in case before exporting

        //    title_string = "LOCATION, TYPE, NUMBER, MAC, MAKE, MODEL, VERSION, SERIAL, OS, USER, DEPARTMENT, PURCHASE DATE, COMMENTS, RETIRED"; 

        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.Filter = "Comma Delimited Values|*.csv";
        //    saveFileDialog1.Title = "Save as .csv (Compatible with Excel)";
        //    saveFileDialog1.ShowDialog();

        //    if (saveFileDialog1.FileName != "")
        //    {
        //        export_file = saveFileDialog1.FileName;
        //        StreamWriter SW = new StreamWriter(export_file);
        //        SW.WriteLine(title_string);
        //        int report_current_col = 0;
        //        while (row < FORM1.dataOUTPUT.RowCount)
        //        {
        //            while (col < FORM1.dataOUTPUT.ColumnCount)
        //            {
        //                if (cols[col] == true)
        //                {
        //                    //Console.WriteLine((col + 1) + " : " + report_col_count + " : " + report_current_col);
        //                    if (report_current_col + 1 == report_col_count) //if (col + 1 == report_col_count)
        //                    {
        //                        record_line += FORM1.dataOUTPUT[col, row].Value.ToString();
        //                    }
        //                    else
        //                    {
        //                        record_line += FORM1.dataOUTPUT[col, row].Value.ToString() + ",";
        //                    }
        //                    report_current_col++;
        //                }
        //                col++;
        //            }
        //            report_current_col = 0;

        //            SW.WriteLine(record_line);
        //            record_line = "";
        //            col = 0;
        //            row++;
        //        }

        //        SW.Close();

        //        MessageBox.Show("Entire Database: " + export_file + " has been exported as a .csv file. (Compatible with Excel)");

        //    }
        //}
    }
}