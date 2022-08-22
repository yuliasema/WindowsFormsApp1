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
    public partial class AboutClientForm : Form
    {
        string name;
        public AboutClientForm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void AboutClientForm_Load(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = name;
            label.Location = new Point(30, 20);
            label.Font = new Font("Microsoft Sans Serif", 16);
            label.Size = new Size(80, 40);
            Controls.Add(label);

            Label label1 = new Label();
            label1.Text = "Питомцы:";
            label1.Location = new Point(10, 60);
            label1.Font = new Font("Microsoft Sans Serif", 12);
            label1.Size = new Size(100, 40);
            Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "Прививки:";
            label2.Location = new Point(150, 60);
            label2.Font = new Font("Microsoft Sans Serif", 12);
            label2.Size = new Size(100, 40);
            Controls.Add(label2);

            List <string> pets = new List<string>();
            pets = ClassSQL.Select($@"SELECT pet_name FROM Pets p, Owners o WHERE p.pet_owner_id=o.owner_id AND o.owner_name = '{name}'");
            int y = 100;
            for(int i = 0; i <pets.Count; i++)
            {
                Label label3 = new Label();
                label3.Text = pets[i];
                label3.Location = new Point(10, y);
                label3.Font = new Font("Microsoft Sans Serif", 10);
                label3.Size = new Size(50, 30);
                Controls.Add(label3);
                List <string> vac = new List<string>();
                vac = ClassSQL.Select($@"SELECT vac_name FROM Pets p, Vaccinations v, VacPet vp WHERE v.vac_id=vp.vac_id AND p.pet_id=vp.pet_id AND p.pet_name='{pets[i]}'");
                for (int j = 0; j<vac.Count; j++)
                {
                    Label label4 = new Label();
                    label4.Text = vac[j] + ", ";
                    label4.Location = new Point(150, y);
                    label4.Font = new Font("Microsoft Sans Serif", 10);
                    label4.Size = new Size(150, 30);
                    Controls.Add(label4);
                    y += 30;

                }

                y += 30;
            }
            Button addVac = new Button();
            addVac.Text = "+ прививка" ;
            addVac.Location = new Point(100, y);
            addVac.Font =  new Font("Microsoft Sans Serif", 10);
            addVac.Size = new Size(100, 30);
            addVac.Click += (s, a) =>
            {
                AddVac add = new AddVac(name);
                add.ShowDialog();
            };
            Controls.Add(addVac);
        }
    }
}
