using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BARIŞ_YILDIZ
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DecimationMethod form2 = new DecimationMethod();
            form2.Show();
            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            YolŞifrelemeDeşifreMethod form3 = new YolŞifrelemeDeşifreMethod();
            form3.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
