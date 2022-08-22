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
    public partial class DeleteServiceForm : Form
    {
        public DeleteServiceForm()
        {
            InitializeComponent();
            List<string> services = new List<string>();
            services = ClassSQL.Select("SELECT service_name FROM Services");
            int k = 0;
            foreach (string serviceType in services)
            {
                DeleteCombo.Items.Insert(k, serviceType);
                k++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ClassSQL.Insert($@"DELETE FROM Services WHERE service_name = '{DeleteCombo.Text}'");
            this.Hide();
        }
    }
}
