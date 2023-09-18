using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        public static Form1 form;
        AbstractFactory f;
        AbstractFactory f1;
        AbstractFactory f2;

        private void button1_Click(object sender, EventArgs e)
        {

            f = new FactoryOffRoadRacing();
            f.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1 = new FactoryTrackRacing();
            f1.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f2 = new FactoryDirtRacing();
            f2.play();
        }
    }
}
