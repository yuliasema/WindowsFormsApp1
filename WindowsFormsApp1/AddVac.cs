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
    public partial class AddVac : Form
    {
        public AddVac(string owner_name)
        {
            InitializeComponent();
            List<string> vacs = new List<string>();
            vacs = ClassSQL.Select("SELECT vac_name FROM Vaccinations");
            int k = 0;
            foreach (string vacType in vacs)
            {
                VacCombo.Items.Insert(k, vacType);
                k++;
            }

            List<string> pets = new List<string>();
            vacs = ClassSQL.Select($@"SELECT pet_name FROM Pets p, Owners o Where owner_name = '{owner_name}' AND o.owner_id = p.pet_owner_id");
            int l = 0;
            foreach (string vacType in vacs)
            {
                PetCombo.Items.Insert(l, vacType);
                l++;
            }

        }

        private void AddVac_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            decimal vac_id = ClassSQL.SelectId($@"SELECT vac_id FROM Vaccinations where vac_name = '{VacCombo.Text}'");
            decimal pet_id = ClassSQL.SelectId($@"SELECT pet_id FROM Pets where pet_name = '{PetCombo.Text}'");
            ClassSQL.Insert($@"INSERT INTO VacPet (vac_id, pet_id) VALUES ('{vac_id}','{pet_id}')");
            this.Hide();
        }
    }
}
