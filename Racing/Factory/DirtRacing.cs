using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public class DirtPlayerCar : AbstractPlayerCar
    {

        public override void start()
        {
            model = new PictureBox();
            model.Image = ((Image)Properties.Resources.ResourceManager.GetObject("Dirt1"));
            model.SizeMode = PictureBoxSizeMode.AutoSize;
            speed = 7;
        }
        public override void show(Form form)
        {
            form.Controls.Add(model);
        }
        public override void win(Form form)
        {
            MessageBox.Show("Ти переміг!");

            form.Close();
        }
        public override void move(Timer timer, float gripCoef, int endRoad, Form form)
        {
            model.Left += (int)(speed * gripCoef);
            if (model.Right >= endRoad)
            {
                timer.Enabled = false;
                win(form);
            }
        }
    }
    public class DirtEnemyCar : AbstractEnemyCar
    {
        public override void start()
        {
            model = new PictureBox();
            model.Image = ((Image)Properties.Resources.ResourceManager.GetObject("Dirt2"));
            model.SizeMode = PictureBoxSizeMode.AutoSize;
            model.Top += 300;
            speed = 10;
        }
        public override void show(Form form)
        {
            form.Controls.Add(model);
        }
        public override void win(Form form)
        {

            MessageBox.Show("Ти програв");
            form.Close();

        }
        public override void move(float gripCoef, int endRoad, Form form)
        {
            vidlik = new Timer();
            vidlik.Interval = 50;
            vidlik.Enabled = true;
            vidlik.Tick += PowerTimer_Tick;

            void PowerTimer_Tick(object sender, EventArgs e)
            {
                model.Left += (int)(speed * gripCoef);
                if (form.IsDisposed)
                {
                    vidlik.Enabled = false;
                    form.Dispose();
                }
                if (model.Right >= endRoad)
                {
                    vidlik.Enabled = false;
                    win(form);

                }
            }
        }

    }

    public class DirtRoad : AbstractRoad
    {
        public override void start(Form form)
        {
            GripCoefficient = 0.5f;
            road1 = new PictureBox();
            road2 = new PictureBox();
            road1.Height = 15;
            road2.Height = 15;
            road1.Width = form.ClientRectangle.Width;
            road2.Width = form.ClientRectangle.Width;

        }
        public override void show(Form form, PictureBox playerCar, PictureBox enemyCar)
        {
            road1.BackgroundImage = ((Image)Properties.Resources.ResourceManager.GetObject("Dirt_Road"));
            road2.BackgroundImage = ((Image)Properties.Resources.ResourceManager.GetObject("Dirt_Road"));
            road1.Top = playerCar.Bottom;
            road2.Top = enemyCar.Bottom;

            form.Controls.Add(road1);
            form.Controls.Add(road2);
        }
    }
    public class FactoryDirtRacing : AbstractFactory
    {

        public override AbstractPlayerCar CreatePlayerCar()
        {
            return new DirtPlayerCar();
        }
        public override AbstractEnemyCar CreateEnemyCar()
        {
            return new DirtEnemyCar();
        }
        public override AbstractRoad CreateRoad()
        {
            return new DirtRoad();
        }
       
        public override void play()
        {
            Form form1 = new Form();
            form1.Text="DirtRacing Level";
            form1.BackColor = Color.White;
            form1.Width = 1000;
            form1.Height = 500;
            pc = CreatePlayerCar();
            ec = CreateEnemyCar();
            r = CreateRoad();
            r.start(form1);
            pc.start();
            pc.show(form1);
            ec.start();
            ec.show(form1);
            ec.move(r.GripCoefficient, r.road1.Right, form1);
            r.show(form1, pc.model, ec.model);
            form1.KeyDown += P_area_KeyDown;
            void P_area_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode.ToString() == "D"))
                {
                    pc.move(ec.vidlik, r.GripCoefficient, r.road1.Right, form1);
                }
            }
            form1.Show();
        }


    }
} 
