using System;
using System.Drawing;


namespace Castle
{
    public class WarriorEnemyCavalery : WarriorEnemy
    {
        public WarriorEnemyCavalery(IWorld world, double x, double y)
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
                    WarriorDefCavalery war = FindNearestWarrior<WarriorDefCavalery>();
                    if (war != null)
                    {
                        targetX = RandomX;
                        targetY = RandomY;

                        MoveTo(targetX, targetY, 5);
                        if (Math.Abs(X - targetX) < 0.001 &&
                            Math.Abs(Y - targetY) < 0.001)
                        {
                            war.Health -= 0.02;

                            state = WarriorState.Moving;
                        }
                    }
                    else state = WarriorState.Moving;
                    break;
                case WarriorState.Moving:
                    if (Math.Abs(X - targetX) < 0.001 &&
                        Math.Abs(Y - targetY) < 0.001)
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
                        if (CastleFeatures.SecurityLevel <= 59)
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
                g.FillRectangle(b, -3, -3, 10, 10);
            }
        }
    }
}
