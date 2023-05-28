using SE_G7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_G7
{
    public partial class FrmInfo : Form
    {
        private Student student;
        public FrmInfo(Student student)
        {

            InitializeComponent();
            this.student = student;

            txtId.Text = student.Id.ToString();
            txtName.Text = student.Name;
            txtSurname.Text = student.Surname;
            txtEmail.Text = student.Email;
            txtPhone.Text = student.Phone;
            txtHomeUniv.Text = student.Home_university;
            txtFacAdd.Text = student.Faculty_address;
            txtFieldStu.Text = student.Field_of_study;

        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
