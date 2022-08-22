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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string login = LoginBox.Text;
            string pass = PassBox.Text;
            
            if (IsADoctor.Checked)
            {
                ClassSQL.Insert($@"INSERT INTO Doctors (doctor_name, doctor_login, doctor_pass) VALUES ('{name}','{login}','{pass}')");
            }
            else
            {
                ClassSQL.Insert($@"INSERT INTO Owners (owner_name, owner_login, owner_pass) VALUES ('{name}','{login}','{pass}')");
            }
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
