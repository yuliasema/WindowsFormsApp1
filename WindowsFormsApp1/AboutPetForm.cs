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
    public partial class AboutPetForm : Form
    {
        public AboutPetForm(string name_pet, string name_owner)
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list = ClassSQL.Select($@"SELECT pet_name, pet_type FROM Pets JOIN Owners ON Pets.pet_owner_id=Owners.owner_id WHERE pet_name = '{name_pet}' AND owner_name='{name_owner}'");
            int y = 10;
            for (int i=0; i<list.Count; i++)
            {
                Label label = new Label();
                label.Text = list[i];
                label.Location = new Point(y, 20);
                label.Font = new Font("Microsoft Sans Serif", 14);
                label.Size = new Size(80, 40);
                Controls.Add(label);
                y += 80;
            }
            Label label1 = new Label();
            label1.Text = "Прививки:";
            label1.Location = new Point(10, 60);
            label1.Font = new Font("Microsoft Sans Serif", 12);
            label1.Size = new Size(100, 40);
            Controls.Add(label1);

            list = ClassSQL.Select($@"SELECT vac_name FROM Vaccinations v, VacPet vp, Pets p JOIN Owners o ON p.pet_owner_id=o.owner_id WHERE vp.pet_id=p.pet_id AND vp.vac_id = v.vac_id AND p.pet_name = '{name_pet}' AND o.owner_name='{name_owner}'");
            y = 110;
            for (int i = 0; i < list.Count; i++)
            {
                Label label = new Label();
                label.Text = list[i]+", ";
                label.Location = new Point(y, 60);
                label.Font = new Font("Microsoft Sans Serif", 12);
                label.Size = new Size(160, 30);
                Controls.Add(label);
                y += 80;
            }

        }

        private void AboutPetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
