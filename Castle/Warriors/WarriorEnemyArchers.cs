using System;
using System.Drawing;


namespace Castle
{
    public class WarriorEnemyArchers : WarriorEnemy
    {
        public WarriorEnemyArchers(IWorld world, double x, double y)
          : base(world, x, y)
        {
            Health = 1;
        }


        public override void Action()
        {
            if (!IsAlive)
            {
                return;
            }
            switch (state)
            {
                case WarriorState.Start:
                    targetX = RandomX;
                    targetY = RandomY;
                    if (targetX < 160 || targetY < 160)
                    {
                        targetX = 400;
                        targetY = 400;
                    }
                    state = WarriorState.Moving;
                    Action();
                    break;
                case WarriorState.SearchingAndFighting:
                    WarriorDefArchers war = FindNearestWarrior<WarriorDefArchers>();
                    if (war != null)
                    {
                        targetX = war.X;
                        targetY = war.Y;
                        MoveTo(targetX, targetY, 5);
                        if (Math.Abs(X - targetX) < 0.001 &&
                            Math.Abs(Y - targetY) < 0.001)
                        {
                            war.Health -= 0.01;
                            state = WarriorState.Moving;
                        }
                    }
                    else state = WarriorState.Moving;
                    break;                
                case WarriorState.Moving:
                    if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                    {
                        targetX = RandomX;
                        targetY = RandomY;
                        if (targetX < 200 && targetY < 200)
                        {
                            targetX = 400;
                            targetY = 400;
                        }
                    }
                    MoveTo(targetX, targetY, rnd.Next(1, 5));
                    if (!World.Supplies())
                    {
                        if (CastleFeatures.SecurityLevel <= 80)
                        {
                            state = WarriorState.SearchingAndFighting;
                        }
                    }
                    break;
                case WarriorState.Stop:
                    break;
                default:
                    break;
            }
        }


        public override void Draw(Graphics g)
        {
            Color c = Color.Green;
            using (Brush b = new SolidBrush(c))
            {
                g.FillPie(b, 1, 1, 30, 30, 30, 30);
            }
        }


        public void Shooting(Graphics g, float x1, float y1, float x2, float y2)
        {
            Color c = Color.Black;
            using (Pen b = new Pen(c))
            {
                g.DrawLine(b, x1, y1, x2, y2);
            }
        }

    }
}
