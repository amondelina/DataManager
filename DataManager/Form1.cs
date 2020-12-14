using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using Models;

namespace DataManager
{
    public partial class Form1 : Form
    {
        Contacts contacts;
        ServiceLayer.ServiceLayer sl;
        public Form1()
        {
            InitializeComponent();
            sl = new ServiceLayer.ServiceLayer();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            numericUpDownAddress.Value = rnd.Next() % 1000 + 1;
            numericUpDownEmail.Value = rnd.Next() % 1000 + 1;
            numericUpDownPhone.Value = rnd.Next() % 1000 + 1;
        }

        private void buttonObject_Click(object sender, EventArgs e)
        {
            contacts = sl.CreateContacts(decimal.ToInt32(numericUpDownPhone.Value),
                                         decimal.ToInt32(numericUpDownAddress.Value), 
                                         decimal.ToInt32(numericUpDownEmail.Value));
            textBoxXML.Text = sl.CreateXML(contacts);
            buttonFile.Enabled = true;
            textBoxName.Enabled = true;
            var name = "";
            var rnd = new Random();
            var c = rnd.Next()%10 + 1;
            for (int i = 0; i < c; i++)
                name += (char)(rnd.Next() % 26 + 'a');
            textBoxName.Text = name;
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            sl.CreateFile(textBoxName.Text, textBoxXML.Text, ".xml");
            textBoxXML.Text = "";
            textBoxName.Text = "";
            textBoxName.Enabled = false;
            buttonFile.Enabled = false;
        }
    }
}
