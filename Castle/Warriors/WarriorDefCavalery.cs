using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Castle
{
    // защитники кавалерия
    public class WarriorDefCavalery : WarriorDef
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
                        targetX = RandomXDef;
                        targetY = RandomYDef;
                        state = WarriorState.Moving;
                        Action();
                    }
                    break;
                case WarriorState.SearchingAndFighting:
                    {
                        WarriorEnemyArchers warArch = FindNearestWarrior<WarriorEnemyArchers>();
                        WarriorEnemySwordes warSwor = FindNearestWarrior<WarriorEnemySwordes>();
                        WarriorEnemyCavalery warCav = FindNearestWarrior<WarriorEnemyCavalery>();

                        if (warCav != null)
                        {
                            targetX = warCav.X;
                            targetY = warCav.Y;
                            MoveTo(targetX, targetY, 5);
                            if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                            {
                                warCav.Health -= 0.08;

                                state = WarriorState.Moving;
                            }
                        }
                        else state = WarriorState.Moving;

                        if (warSwor != null)
                        {
                            targetX = warSwor.X;
                            targetY = warSwor.Y;
                            MoveTo(targetX, targetY, 5);
                            if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                            {
                                warSwor.Health -= 0.08;

                                state = WarriorState.Moving;
                            }
                        }
                        else state = WarriorState.Moving;

                        if (warArch != null)
                        {
                            targetX = warArch.X;
                            targetY = warArch.Y;
                            MoveTo(targetX, targetY, 5);
                            if (Math.Abs(X - targetX) < 0.001 && Math.Abs(Y - targetY) < 0.001)
                            {
                                warArch.Health -= 0.08;

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
                            targetX = RandomXDef;
                            targetY = RandomYDef;
                        }
                        MoveTo(targetX, targetY, rnd.Next(1, 5));
                        if (!World.Supplies())
                            if (CastleFeatures.SecurityLevel <= 60)
                                state = WarriorState.SearchingAndFighting;
                    }
                    break;
                case WarriorState.Stop:
                    break;
            }
        }

        public override void Draw(Graphics g)
        {
            Color c = Color.Red;
            using (Brush b = new SolidBrush(c))
            {
                g.FillRectangle(b, -3, -3, 10, 10);
            }
        }

        public WarriorDefCavalery(IWorld world, double x, double y)
          : base(world, x, y)
        {
            Health = 1;
        }
    }
}
