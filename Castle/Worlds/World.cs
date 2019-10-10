using System;
using System.Collections.Generic;
using System.Drawing;

namespace Castle
{
    public class World:IWorld
    {
        public ICollection<IWorldObject> Defenders { get; set; }

        public ICollection<IWorldObject> Enemies { get; set; } 


        public IOptions WorldOut
        {
            get;
            private set;
        }


        public IOptions WorldCastle
        {
            get;
            private set;
        }


        public bool IsAlive
        {
            get
            {
                return true;
            }
        }


        public World(double worldWidthOut, double worldHeightOut, 
            double worldWidth, double worldHeight)
        {
            WorldOut = new Enemy(worldWidthOut, worldHeightOut);
            WorldCastle = new Defenders(worldWidth, worldHeight);
            Enemies = new LinkedList<IWorldObject>();
            Defenders = new LinkedList<IWorldObject>();
        }
        

        public void AddEnemy(IWorldObject obj)
        {
            Enemies.Add(obj);
        }


        public void AddDefender(IWorldObject obj)
        {
            Defenders.Add(obj);
        }


        public void Action()
        {
            // у всех объектов "мира" вызываем активность
            foreach (IWorldObject obj in Enemies)
            {
                obj.Action();
            }

            foreach (IWorldObject obj in Defenders)
            {
                obj.Action();
            }

            // удаляем "погибшие" объекты
            var tempObject = new LinkedList<IWorldObject>();
            foreach (IWorldObject obj in Enemies)
            {
                if (obj.IsAlive)
                {
                    tempObject.AddLast(obj);
                }
            }
            Enemies = tempObject;

            var tempObjects = new LinkedList<IWorldObject>();
            foreach (IWorldObject obj in Defenders)
            {
                if (obj.IsAlive)
                {
                    tempObjects.AddLast(obj);
                }
            }
            Defenders = tempObjects;

            CastleFeatures.SecurityLevel -= 0.1;
            CastleFeatures.Water -= 0.01 * Defenders.Count;
            CastleFeatures.Bread -= 0.01 * Defenders.Count;
            CastleFeatures.Beer -= 0.01 * Defenders.Count;
            CastleFeatures.Meat -= 0.01 * Defenders.Count;
        }


        public bool Supplies()
        {
            return CastleFeatures.Water > 0 && CastleFeatures.Bread > 0 && 
                CastleFeatures.Beer > 0 && CastleFeatures.Meat > 0;
        }


        public void Draw(Graphics g)
        {
            foreach (IWorldObject obj in Enemies)
            {
                g.ResetTransform();
                g.TranslateTransform(Convert.ToInt32(obj.X), Convert.ToInt32(obj.Y));
                obj.Draw(g);
            }
            foreach (IWorldObject obj in Defenders)
            {
                g.ResetTransform();
                g.TranslateTransform(Convert.ToInt32(obj.X), Convert.ToInt32(obj.Y));
                obj.Draw(g);
            }
        } 
    }
}
