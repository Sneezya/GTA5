using static WBO.SigScan;
using static WBO.GetAddress;
using static WBO.Bools;

namespace WBO
{
    internal static class Player
    {
        public static void ToggleGodMode()
        {
            player_godmode = pGodmode ? 0 : 1;
            pGodmode = !pGodmode;
        }
        public static void ToggleLooperEnabled()
        {
            IsLooperEnabled = !IsLooperEnabled;
        }




        public static string player_collision_ = "2C";
        public static string wanted_level_ = "8E8";
        public static string player_health_ = "280";
        public static string player_max_health_ = "284";
        public static string player_armor_ = "150C";
        public static string player_godmode_ = "189";
        public static string run_speed_ = "D50";
        public static string swim_speed_ = "1D0";
        public static string stealth_speed_ = "1EC";
        public static string frame_flags_ = "279";
        public static string ragdoll_ = "1098";
        public static string seatbelt_ = "143C";

        public static string player_coord_x_ = "50";
        public static string player_visual_coord_x_ = "90";
        public static string player_coord_y_ = "54";
        public static string player_visual_coord_y_ = "94";
        public static string player_coord_z_ = "58";
        public static string player_visual_coord_z_ = "98";
        public static string iRockstarID_ = "104";

        public static int seatbelt
        {
            get => MemLib.ReadInt(CPed + "+" + seatbelt_);
            set => MemLib.WriteMemory(CPed + "+" + seatbelt_, "int", value.ToString());
        }
        public static int ragdoll
        {
            get => MemLib.ReadInt(CPed + "+" + ragdoll_);
            set => MemLib.WriteMemory(CPed + "+" + ragdoll_, "int", value.ToString());
        }
        public static string iRockstarID
        {
            get => MemLib.ReadString(CPlayerInfo + "+" + iRockstarID_);
            
        }
        public static float player_coord_z
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_z_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_z_, "float", value.ToString());
        }
        public static float player_coord_y
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_y_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_y_, "float", value.ToString());
        }
        public static float player_coord_x
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_x_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_x_, "float", value.ToString());
        }
        public static float player_visual_coord_z
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_z_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_z_, "float", value.ToString());
        }
        public static float player_visual_coord_y
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_y_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_y_, "float", value.ToString());
        }
        public static float player_visual_coord_x
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_x_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_x_, "float", value.ToString());
        }
     
        public static int frame_flags
        {
            get => MemLib.ReadInt(CPlayerInfo + "+" + frame_flags_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", value.ToString());
        }

        public static float player_collision
        {
            get => MemLib.ReadFloat(Collision5 + "+" + player_collision_);
            set => MemLib.WriteMemory(Collision5 + "+" + player_collision_, "float", value.ToString());
        }
        public static int wanted_level
        {
            get => MemLib.ReadInt(CPlayerInfo + "+" + wanted_level_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + wanted_level_, "int", value.ToString());
        }
        public static float player_health
        {
            get => MemLib.ReadFloat(CPed + "+" + player_health_);
            set => MemLib.WriteMemory(CPed + "+" + player_health_, "float", value.ToString());
        }
        public static float player_max_health
        {
            get => MemLib.ReadFloat(CPed + "+" + player_max_health_);
            set => MemLib.WriteMemory(CPed + "+" + player_max_health_, "float", value.ToString());
        }
        public static float player_armor
        {
            get => MemLib.ReadFloat(CPed + "+" + player_armor_);
            set => MemLib.WriteMemory(CPed + "+" + player_armor_, "float", value.ToString());
        }
        public static int player_godmode
        {
            get => MemLib.ReadInt(CPed + "+" + player_godmode_);
            set => MemLib.WriteMemory(CPed + "+" + player_godmode_, "int", value.ToString());
        }
        public static float run_speed
        {
            get => MemLib.ReadFloat(CPlayerInfo + "+" + run_speed_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + run_speed_, "float", value.ToString());
        }
        public static float swim_speed
        {
            get => MemLib.ReadFloat(CPlayerInfo + "+" + swim_speed_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + swim_speed_, "float", value.ToString());
        }
        public static float stealth_speed
        {
            get => MemLib.ReadFloat(CPlayerInfo + "+" + stealth_speed_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + stealth_speed_, "float", value.ToString());
        }
    }
}
