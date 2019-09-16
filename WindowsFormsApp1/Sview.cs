using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Sview : Form
    {
        Form1 FORM1;
        DataManager DM;

        public Sview(Form1 f1, DataManager dm)
        {
            InitializeComponent();
            FORM1 = f1;
            DM = dm;
            PopulateView();
        }

        private void PopulateView()
        {
            dataOUTPUT.ColumnCount = 14;

            dataOUTPUT.Rows.Add("LOCATION", "TYPE", "NUMBER", "MAC", "MAKE", "MODEL", "VERSION", "SERIAL", "OS", "USER", "DEPARTMENT", "PURCHASE DATE", "COMMENTS", "RETIRED");
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[0].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[1].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[2].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[3].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[4].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[5].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[6].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[7].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[8].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[9].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[10].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[11].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[12].Style.BackColor = Color.LightGray;
            dataOUTPUT.Rows[dataOUTPUT.RowCount - 1].Cells[13].Style.BackColor = Color.LightGray;

            for (int i = 0; i < FORM1.listbox_tracker.Count(); i++)
            {
                dataOUTPUT.Rows.Add(DM.inventory_database[FORM1.listbox_tracker[i]][0], DM.inventory_database[FORM1.listbox_tracker[i]][1], DM.inventory_database[FORM1.listbox_tracker[i]][2], DM.inventory_database[FORM1.listbox_tracker[i]][3], DM.inventory_database[FORM1.listbox_tracker[i]][4], DM.inventory_database[FORM1.listbox_tracker[i]][5], DM.inventory_database[FORM1.listbox_tracker[i]][6], DM.inventory_database[FORM1.listbox_tracker[i]][7], DM.inventory_database[FORM1.listbox_tracker[i]][8], DM.inventory_database[FORM1.listbox_tracker[i]][9], DM.inventory_database[FORM1.listbox_tracker[i]][10], DM.inventory_database[FORM1.listbox_tracker[i]][11], DM.inventory_database[FORM1.listbox_tracker[i]][12], DM.inventory_database[FORM1.listbox_tracker[i]][13]);       
            }
        }

        private void Sview_Load(object sender, EventArgs e)
        {
            dataOUTPUT.Width = this.Width - 50;
            dataOUTPUT.Height = this.Height - 60;
            dataOUTPUT.DoubleBuffered(true);
        }

        private void Sview_Resize(object sender, EventArgs e)
        {
            dataOUTPUT.Width = this.Width - 50;
            dataOUTPUT.Height = this.Height - 60;
        }
    }
}
