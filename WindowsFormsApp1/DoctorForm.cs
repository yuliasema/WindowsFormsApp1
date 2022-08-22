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
    public partial class DoctorForm : Form
    {
        string name;

        public DoctorForm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = $@"Добро пожаловать, {name}!";
            label.Location = new Point(10, 10);
            label.Font = new Font("Microsoft Sans Serif", 18);
            label.Size = new Size(300, 50);
            Controls.Add(label);

            Label label1 = new Label();
            label1.Text = "Список клиентов: ";
            label1.Location = new Point(10, 60);
            label1.Font = new Font("Microsoft Sans Serif", 16);
            label1.Size = new Size(300, 40);
            Controls.Add(label1);

            List<string> clients = new List<string>();
            clients = ClassSQL.Select($@"SELECT DISTINCT owner_name FROM Owners o, OwnService ow WHERE ow.owner_id=o.owner_id");
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


            Label label2 = new Label();
            label2.Text = "Список услуг: ";
            label2.Location = new Point(310, 60);
            label2.Font = new Font("Microsoft Sans Serif", 16);
            label2.Size = new Size(300, 40);
            Controls.Add(label2);
            List<string> services = new List<string>();
            services = ClassSQL.Select($@"SELECT service_name FROM Services");
            y = 110;
            for (int i = 0; i < services.Count; i++)
            {
                LinkLabel label3 = new LinkLabel();
                label3.Text = services[i];
                label3.Location = new Point(320, y+100);
                label3.Font = new Font("Microsoft Sans Serif", 14);
                label3.Size = new Size(200, 30);
                label3.Click += (s, a) => {
                    WhoSignedFormcs whoSigned = new WhoSignedFormcs(label3.Text);
                    whoSigned.ShowDialog();
                };
                y = +10;
                Controls.Add(label3);
            }

            Button buttonAdd = new Button();
            buttonAdd.Text = "Добавить услугу";
            buttonAdd.Location = new Point(310, y + 250);
            buttonAdd.Font = new Font("Microsoft Sans Serif", 12);
            buttonAdd.Size = new Size(100, 60);
            buttonAdd.Click += (s, a) =>
            {
                AddServiceForm addServiceForm = new AddServiceForm();
                addServiceForm.ShowDialog();
            };
            Controls.Add(buttonAdd);

            Button buttonDelete = new Button();
            buttonDelete.Text = "Удалить услугу";
            buttonDelete.Location = new Point(420, y + 250);
            buttonDelete.Font = new Font("Microsoft Sans Serif", 12);
            buttonDelete.Size = new Size(100, 60);
            buttonDelete.Click += (s, a) =>
            {
                DeleteServiceForm deleteServiceForm = new DeleteServiceForm();
                deleteServiceForm.ShowDialog();
            };
            Controls.Add(buttonDelete);
        }
    }
}
