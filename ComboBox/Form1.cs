using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XDocument documents = new XDocument();

        private void Form1_Load(object sender, EventArgs e)
        {
            var documents = XDocument.Load("List.xml");
            comboBox1.DisplayMember = "PrinterText";
            comboBox1.ValueMember = "PrinterID";

            comboBox1.DataSource = documents.Root.Descendants("key").Select(x => new
            {
                PrinterText = x.Attribute("Text").Value,
                PrinterID = x.Attribute("ID").Value
                }).ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        { 
        MessageBox.Show(comboBox1.SelectedValue as dynamic);
        }
    }
}
