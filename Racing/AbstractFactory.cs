using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public abstract class AbstractPlayerCar
    {
        public PictureBox model;
        public double speed;
        abstract public void start();
        abstract public void show(Form form);
        abstract public void win(Form form);
        abstract public void move(Timer timer, float gripCoef, int endRoad, Form form);
    }
    public abstract class AbstractEnemyCar
    {
        public PictureBox model;
        public double speed;
        public Timer vidlik;
        abstract public void start();
        abstract public void show(Form form);
        abstract public void win(Form form);
        abstract public void move(float gripCoef, int endRoad, Form form);
    }
    public abstract class AbstractRoad
    {
        public float GripCoefficient;
        public Color color;
        public PictureBox road1;
        public PictureBox road2;
        abstract public void start(Form form);
        abstract public void show(Form form, PictureBox playerCar, PictureBox enemyCar);
    }
    public abstract class AbstractFactory
    {

        public AbstractPlayerCar pc;
        public AbstractEnemyCar ec;
        public AbstractRoad r;
        abstract public AbstractPlayerCar CreatePlayerCar();
        abstract public AbstractEnemyCar CreateEnemyCar();
        abstract public AbstractRoad CreateRoad();
        abstract public void play();
    }
}
