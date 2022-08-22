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
    public partial class OwnerForm : Form
    {
        string name;
        public OwnerForm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void OwnerForm_Load(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = $@"Добро пожаловать, {name}!";
            label.Location = new Point(10, 10);
            label.Font = new Font("Microsoft Sans Serif", 18);
            label.Size = new Size(300, 50);
            Controls.Add(label);

            Label label1 = new Label();
            label1.Text = "Список питомцев: ";
            label1.Location = new Point(10, 60);
            label1.Font = new Font("Microsoft Sans Serif", 16);
            label1.Size = new Size(300, 40);
            Controls.Add(label1);
            List<string> pets = new List<string>();
            pets = ClassSQL.Select($@"SELECT pet_name FROM Pets p, Owners o WHERE owner_name = '{name}' AND o.owner_id=p.pet_owner_id");
            int y = 110;
            for (int i = 0; i < pets.Count; i++)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Text= pets[i];
                linkLabel.Location = new Point(20, y);
                linkLabel.Font = new Font("Microsoft Sans Serif", 14);
                linkLabel.Size = new Size(200, 30);

                linkLabel.Click += (s,a) => { AboutPetForm aboutPetForm = new AboutPetForm(linkLabel.Text, name);
                    aboutPetForm.ShowDialog();
                };
                y = +30;
                Controls.Add(linkLabel);
            }

            Button button = new Button();
            button.Text = "Добавить питомца";
            button.Location = new Point(20, y+110);
            button.Font = new Font("Microsoft Sans Serif", 14);
            button.Size = new Size(200, 30);
            button.Click += (s, a) =>
            {
                AddPetForm addPetForm = new AddPetForm(name);
                addPetForm.ShowDialog();
            };
            Controls.Add(button);


            Label label2 = new Label();
            label2.Text = "Записаться на услугу";
            label2.Location = new Point(400,60);
            label2.Font = new Font("Microsoft Sans Serif", 16);
            label2.Size = new Size(400, 30);
            Controls.Add(label2);

            ComboBox services = new ComboBox();
            List<string> serv = new List<string>();
            serv = ClassSQL.Select("SELECT service_name FROM Services");
            int j = 0;
            foreach (string servType in serv)
            {
                services.Items.Insert(j, servType);
                j++;
            }
            services.Location = new Point(400, 120);
            services.Font= new Font("Microsoft Sans Serif", 14);
            services.Size = new Size(200, 200);
            Controls.Add(services);


            Button button1 = new Button();
            button1.Text = "Записаться";
            button1.Location = new Point(400, 210);
            button1.Font = new Font("Microsoft Sans Serif", 14);
            button1.Size = new Size(200, 30);
            button1.Click += (s, a) =>
            {
                decimal owner_id = ClassSQL.SelectId($@"SELECT owner_id FROM Owners where owner_name = '{name}'");
                decimal service_id = ClassSQL.SelectId($@"SELECT service_id FROM Services where service_name = '{services.Text}'");
                ClassSQL.Insert($@"INSERT INTO OwnService (owner_id, service_id) VALUES ('{owner_id}','{service_id}')");
            };
            Controls.Add(button1);





        }


    }
}
