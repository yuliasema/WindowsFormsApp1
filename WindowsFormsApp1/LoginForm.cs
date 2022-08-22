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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            string login = LogBox.Text;
            string pass = PassBox.Text;
            bool stop = false;
            List<string> list = new List<string>();
            list = ClassSQL.Select($@"SELECT doctor_name FROM Doctors WHERE doctor_login='{login}' AND doctor_pass='{pass}'");
            if (list.Count == 0)
            {
                list = ClassSQL.Select($@"SELECT owner_name FROM Owners WHERE owner_login='{login}' AND owner_pass='{pass}'");
            }
            else
            {
                this.Hide();
                DoctorForm doctorForm = new DoctorForm(list[0]);
                doctorForm.ShowDialog();
                stop = true;
                

            }
            if (list.Count == 0)
            {
                MessageBox.Show("неверный логин или пароль");
            }
            else
            {
                if (!stop)
                {
                    this.Hide();
                    OwnerForm ownerForm = new OwnerForm(list[0]);
                    ownerForm.ShowDialog();
                }

            }
        }
    }
}
