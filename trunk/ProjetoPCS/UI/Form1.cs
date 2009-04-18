using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesBasicas;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empregado func = new Empregado();
            Empregado super = new Empregado();
            Empregado super2 = new Empregado();
            func.Nome = "Jefferson";
            func.Supervisor = super;

            super.Nome = "supervisor de jeff";

            super2.Nome = "supervisor de super";

            super.Supervisor = super2;

            MessageBox.Show(func.Nome+"\n"+ func.Supervisor.Nome);

            MessageBox.Show(super.Nome + "\n" + super.Supervisor.Nome);

        }
    }
}
