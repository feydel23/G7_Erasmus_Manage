using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erasmus_Manager
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileD ofd = new OpenFileD();
            ofd.Filter = "txt files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UserFileReader filereader = new UserFileReader();
                
                string file = ofd.FileName;
                string text = System.IO.File.ReadAllText(file);
                MessageBox.Show(text);
            }
        }
    }
}
