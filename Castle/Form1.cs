using System;
using System.Drawing;
using System.Windows.Forms;

namespace Castle
{
    public partial class Form1 : Form
    {
        Graphics g;
        CastleFeatures castle;
        EnemyArmy army;
        World world;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            world = new World(400, 400, 150, 150);
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            int defArchers = Convert.ToInt32(textBoxDefArchers.Text);
            int defCavalery = Convert.ToInt32(textBoxDefCavalery.Text);
            int defSwords = Convert.ToInt32(textBoxDefSwords.Text);

            Random rnd = new Random();
            double width1 = rnd.NextDouble() * (world.WorldOut.WorldWidth - 20);
            double height1 = rnd.NextDouble() * (world.WorldOut.WorldHeight - 20);

            int enemySwords = Convert.ToInt32(textBoxSwords.Text);
            int enemyCavalery = Convert.ToInt32(textBoxCavalery.Text);
            int enemyArchers = Convert.ToInt32(textBoxArchers.Text);

            double width = rnd.NextDouble() * (world.WorldOut.WorldWidth - 20);
            double height = rnd.NextDouble() * (world.WorldOut.WorldHeight - 20);

            if (width1 > 140 || height1 > 140)
            {
                width1 = 100;
                height1 = 100;
            }
            for (int i = 0; i < defSwords; i++)
            {
                world.AddDefender(new WarriorDefSwordes(world, width1, height1));
            }

            for (int i = 0; i < defArchers; i++)
            {
                world.AddDefender(new WarriorDefArchers(world, width1, height1));
            }

            for (int i = 0; i < defCavalery; i++)
            {
                world.AddDefender(new WarriorDefCavalery(world, width1, height1));
            }

            if (width < 160 || height < 160)
            {
                width = 400;
                height = 400;
            }
            for (int i = 0; i < enemySwords; i++)
            {
                world.AddEnemy(new WarriorEnemySwordes(world, width, height));
            }
            for (int i = 0; i < enemyArchers; i++)
            {
                world.AddEnemy(new WarriorEnemyArchers(world, width, height));
            }

            for (int i = 0; i < enemyCavalery; i++)
            {
                world.AddEnemy(new WarriorEnemyCavalery(world, width, height));
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            world.Action();
            this.Invalidate();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // рисование замка
            float height = Convert.ToSingle(world.WorldCastle.WorldHeight);
            float width = Convert.ToSingle(world.WorldCastle.WorldWidth);

            e.Graphics.FillRectangle(Brushes.CornflowerBlue, 0, 0, height + 20, width + 20);
            world.Draw(e.Graphics);

        }


        private void buttonParams_Click(object sender, EventArgs e)
        {
            int water = Convert.ToInt32(textBoxWater.Text);
            int bread = Convert.ToInt32(textBoxBread.Text);
            int beer = Convert.ToInt32(textBoxBeer.Text);
            int meat = Convert.ToInt32(textBoxMeat.Text);

            int defArchers = Convert.ToInt32(textBoxDefArchers.Text);
            int defCavalery = Convert.ToInt32(textBoxDefCavalery.Text);
            int defSwords = Convert.ToInt32(textBoxDefSwords.Text);

            castle = new CastleFeatures(water, bread, beer, meat,
                                    defArchers, defSwords, defCavalery);

            int enemySwords = Convert.ToInt32(textBoxSwords.Text);
            int enemyCavalery = Convert.ToInt32(textBoxCavalery.Text);
            int enemyArchers = Convert.ToInt32(textBoxArchers.Text);

            army = new EnemyArmy(enemySwords, enemyArchers, enemyCavalery);
        }
    }
}
