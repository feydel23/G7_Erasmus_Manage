using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    internal class UserDisplayer
    {
        public void DisplayInfo(Form1 form, Form2 form, UserFormInfo current_UserFormInfo)
    {
        if (current_UserForm != null && form != null)
        {
            form.Controls["FullNameTextBox"].Text = current_UserFormInfo.FullName;
            form.Controls["YearOfBirthTextBox"].Text = current_UserFormInfo.YearOfBirth;
            form.Controls["CityTextBox"].Text = current_UserFormInfo.City;
            form.Controls["FacultyTextBox"].Text = current_UserFormInfo.Faculty;
            form.Controls["RoleTextBox"].Text = current_UserFormInfo.Role;
            form.Controls["SpecificAttributesTextBox"].Text = current_UserFormInfo.SpecificAttributes;
        }
        else
        {
            Console.WriteLine("Error: current_UserForm is null or form is null");
        }
    }
}
