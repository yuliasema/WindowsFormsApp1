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
    public partial class WhoSignedFormcs : Form
    {
        string name;
        public WhoSignedFormcs(string name)
        {
            InitializeComponent();
            this.name = name;

            Label lbl = new Label();
            lbl.Text = "На процедуру "+name+" записались:";
            lbl.Location = new Point(10, 10);
            lbl.Font = new Font("Microsoft Sans Serif", 14);
            lbl.Size = new Size(300, 50);
            Controls.Add(lbl);

            List<string> clients = new List<string>();
            clients = ClassSQL.Select($@"SELECT DISTINCT owner_name FROM Owners o, OwnService ow, Services s WHERE ow.owner_id=o.owner_id AND s.service_name = '{name}' AND ow.service_id= s.service_id");
            int y = 110;
            for (int i = 0; i < clients.Count; i++)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Text = clients[i];
                linkLabel.Location = new Point(20, y);
                linkLabel.Font = new Font("Microsoft Sans Serif", 14);
                linkLabel.Size = new Size(200, 30);

                linkLabel.Click += (s, a) => {
                    AboutClientForm aboutClientForm = new AboutClientForm(linkLabel.Text);
                    aboutClientForm.ShowDialog();
                };
                y = +30;
                Controls.Add(linkLabel);
            }


        }

        private void WhoSignedFormcs_Load(object sender, EventArgs e)
        {

        }
    }
}
