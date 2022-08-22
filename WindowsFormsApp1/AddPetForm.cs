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
    public partial class AddPetForm : Form
    {
        string owner_name;
        public AddPetForm(string owner_name)
        {
            InitializeComponent();
            this.owner_name = owner_name;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string type = TypeBox.Text;
            decimal owner_id = ClassSQL.SelectId($@"SELECT owner_id FROM Owners where owner_name = '{owner_name}'");
            ClassSQL.Insert($@"INSERT INTO Pets (pet_name, pet_type, pet_owner_id) VALUES ('{name}','{type}','{owner_id}')");
            this.Hide();
        }

        private void AddPetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
