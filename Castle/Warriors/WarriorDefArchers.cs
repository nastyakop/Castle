using System;
using System.Drawing;


namespace Castle
{
    public class WarriorDefArchers : WarriorDef
    {
        public WarriorDefArchers(IWorld world, double x, double y)
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
                    targetX = RandomXDef;
                    targetY = RandomYDef;
                    if (targetX > 140 && targetY > 140)
                    {
                        targetX = 100;
                        targetY = 100;
                    }
                    state = WarriorState.Moving;
                    Action();
                    break;
                case WarriorState.SearchingAndFighting:
                    WarriorEnemyArchers warArchers = FindNearestWarrior<WarriorEnemyArchers>();
                    WarriorEnemySwordes warSwords = FindNearestWarrior<WarriorEnemySwordes>();
                    WarriorEnemyCavalery warCavalery = FindNearestWarrior<WarriorEnemyCavalery>();

                    if (warArchers != null)
                    {
                        targetX = warArchers.X;
                        targetY = warArchers.Y;
                        MoveTo(targetX, targetY, 5);
                        if (Math.Abs(X - targetX) < 0.001 &&
                            Math.Abs(Y - targetY) < 0.001)
                        {
                            warArchers.Health -= 0.08;

                            state = WarriorState.Moving;
                        }
                    }
                    else state = WarriorState.Moving;

                    if (warSwords != null)
                    {
                        targetX = warSwords.X;
                        targetY = warSwords.Y;
                        MoveTo(targetX, targetY, 5);
                        if (Math.Abs(X - targetX) < 0.001 &&
                            Math.Abs(Y - targetY) < 0.001)
                        {
                            warSwords.Health -= 0.08;

                            state = WarriorState.Moving;
                        }
                    }
                    else state = WarriorState.Moving;

                    if (warCavalery != null)
                    {
                        targetX = warCavalery.X;
                        targetY = warCavalery.Y;
                        MoveTo(targetX, targetY, 5);
                        if (Math.Abs(X - targetX) < 0.001 &&
                            Math.Abs(Y - targetY) < 0.001)
                        {
                            warCavalery.Health -= 0.08;

                            state = WarriorState.Moving;
                        }
                    }
                    else state = WarriorState.Moving;
                    break;

                case WarriorState.Moving:
                    if (Math.Abs(X - targetX) < 0.001 &&
                        Math.Abs(Y - targetY) < 0.001)
                    {
                        targetX = RandomXDef;
                        targetY = RandomYDef;
                        if (targetX > 140 || targetY > 140)
                        {
                            targetX = 100;
                            targetY = 100;
                        }
                    }
                    MoveTo(targetX, targetY, rnd.Next(1, 5));
                    if (!World.Supplies())
                    {
                        if (CastleFeatures.SecurityLevel < 80)
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
            Color c = Color.Red;
            using (Brush b = new SolidBrush(c))
            {
                g.FillPie(b, 1, 1, 30, 30, 30, 30);
            }
        }
    }
}
