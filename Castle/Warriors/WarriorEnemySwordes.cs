using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Castle
{
    // Противник мечники
    public class WarriorEnemySwordes : WarriorEnemy
    {
        public override void Action()
        {
            if (!Living)
            {
                return;
            }

            switch (state)
            {
                case WarriorState.Start:
                    {
                        // начальное состояние
                        targetX = RandomX;
                        targetY = RandomY;
                        if (targetX < 160 || targetY < 160)
                        {
                            targetX = 400;
                            targetY = 400;
                        }
                        state = WarriorState.Moving;
                        Action();
                    }
                    break;
                case WarriorState.SearchingAndFighting:
                    {
                        WarriorDefSwordes war = FindNearestWarrior<WarriorDefSwordes>();
                        if (war != null)
                        {
                            targetX = RandomX;
                            targetY = RandomY;

                            MoveTo(targetX, targetY, 5);
                            if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                            {
                                war.Health -= 0.02;

                                state = WarriorState.Moving;
                            }
                        }
                        else state = WarriorState.Moving;
                        break;
                    }
                case WarriorState.Moving:
                    {
                        // продолжаем ходить
                        if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                        {
                            // но если пришли к месту, к которому направлялись, то определяем новое место, куда пойдем
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
                            if (CastleFeatures.SecurityLevel <= 55)
                                state = WarriorState.SearchingAndFighting;
                    }
                    break;
                case WarriorState.Stop:
                    break;
            }
        }

        public override void Draw(Graphics g)
        {
            Color c = Color.Green;
            using (Brush b = new SolidBrush(c))
            {
                g.FillEllipse(b, -3, -3, 10, 10);
            }
        }

        public WarriorEnemySwordes(IWorld world, double x, double y)
          : base(world, x, y)
        {
            Health = 1;
        }
    }
}
