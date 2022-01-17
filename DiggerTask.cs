using System.Windows.Forms;


namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.
    class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() == "Digger.png")
                return true;
            else
                return false;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            int xres = 0, yres = 0;
            if (Game.KeyPressed == Keys.Right)
            {

                if (Game.MapWidth > x + 1)
                    if (Game.Map[x + 1, y] == null || Game.Map[x + 1, y].ToString() != "Digger.Sack")
                        xres += 1;
            }
            if (Game.KeyPressed == Keys.Left)
            {

                if (0 <= x - 1)
                    if (Game.Map[x - 1, y] == null || Game.Map[x - 1, y].ToString() != "Digger.Sack")
                        xres -= 1;
            }
            if (Game.KeyPressed == Keys.Up)
            {
                if (0 <= y - 1)
                    if (Game.Map[x, y-1] == null || Game.Map[x, y - 1].ToString() != "Digger.Sack")
                        yres -= 1;
            }
            if (Game.KeyPressed == Keys.Down)
            {
                if (Game.MapHeight > y + 1)
                    if ( Game.Map[x, y+1] == null || Game.Map[x, y + 1].ToString() != "Digger.Sack" )
                        yres += 1;
            }
            return new CreatureCommand { DeltaX = xres, DeltaY = yres};
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return -1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }
    class Sack : ICreature
    {
        bool isFall = false;
        bool superFall = false;
        public CreatureCommand Act(int x, int y)
        {

                if (y + 1 < Game.MapHeight)
                if(Game.Map[x, y + 1] == null || (Game.Map[x, y + 1].ToString() == "Digger.Player" && isFall))
                {
                    Game.Map[x, y + 1] = null;
                    if (isFall) superFall = true;
                    isFall = true;
                    return new CreatureCommand { DeltaY = 1 };
                }
                else
                {
                    isFall = false;
                    if (superFall)
                        return new CreatureCommand { TransformTo = new Gold() };
                }
                else if (superFall)
                return new CreatureCommand { TransformTo = new Gold() };


            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() == "Digger.png")
                return true;
            else
                return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() == "Digger.png")
            {
                Game.Scores += 10;
                return true;
            }
            else
                return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }
}
