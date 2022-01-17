using System.Windows.Forms;

namespace Digger
{
    public static class Game
    {
  //      private const string mapWithPlayerTerrain = @"
     
  //P  
     
  //   ";
        private const string mapWithPlayerTerrain = @"
 TTT 
 TPT 
 TTT 
     ";

        private const string mapWithPlayerTerrainSackGold = @"
PTTGTT TS
TST  TST 
TTTTTTST 
T TSTS T 
T TTTG S 
TSTSTT   ";

        private const string mapWithPlayerTerrainSackGoldMonster = @"
PTTGTT TST
TST  TSTTM
TTT TTSTTT
T TSTS TTT
T TTTGMSTS
T TMT M TS
TSTSTTMTTT
S TTST  TG
 TGST MTTT
 T  TMTTTT";

        public static ICreature[,] Map;
        public static int Scores;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGold);
        }
    }
}