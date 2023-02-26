using static WBO.SigScan;
using static WBO.GetAddress;


namespace WBO
{
    internal static class Roulette
    {
        public static string roulette_left_table_ = "4D0";
        public static string roulette_right_table_ = "4D8";
        public static string roulette_table_bet_ = "970";


        public static int roulette_left_table
        {
            get => MemLib.ReadInt(Roulette3 + "+" + roulette_left_table_);
            set => MemLib.WriteMemory(Roulette3 + "+" + roulette_left_table_, "int", value.ToString());
        }
        public static int roulette_right_table
        {
            get => MemLib.ReadInt(Roulette3 + "+" + roulette_right_table_);
            set => MemLib.WriteMemory(Roulette3 + "+" + roulette_right_table_, "int", value.ToString());
        }
        public static int roulette_table_bet
        {
            get => MemLib.ReadInt(Roulette3 + "+" + roulette_table_bet_);
            set => MemLib.WriteMemory(Roulette3 + "+" + roulette_table_bet_, "int", value.ToString());
        }
    }
}
