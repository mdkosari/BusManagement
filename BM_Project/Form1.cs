using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_Project_1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pas;
            user = Convert.ToString(User.Text);
            pas = Convert.ToString(Pas.Text);
            if ((user=="mohammad"&&pas=="kosari")||(user == "Mohammad" && pas == "Kosari")|| (user == "MOHAMMAD" && pas == "KOSARI")|| (user == "محمد" && pas == "کوثری"))
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                error.Text =Convert.ToString("نام کاربری یا رمز عبور اشتباه است");
                error.ForeColor = Color.Red;
            }
            
        }
    }
}
