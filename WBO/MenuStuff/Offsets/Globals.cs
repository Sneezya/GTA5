using static WBO.SigScan;

namespace WBO
{
    internal static class Globals
    {

        
        public static string Global_RP_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x10).ToString("X2");
        public static string Global_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x0).ToString("X2");
        public static string Global_CMFailMoney_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x105F0).ToString("X2");
        public static string Global_CMFailRP_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x10640).ToString("X2");
        public static string Global_JobRPCap_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0xDDC0).ToString("X2");
        public static string Global_AS_vehCooldown_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CCB8).ToString("X2");
        public static string Global_AS_cChance_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CCC0).ToString("X2");

        public static string Global_AS_Pay1_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CCF0).ToString("X2");
        public static string Global_AS_Pay_Vis1_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CD08).ToString("X2");
        public static string Global_AS_Pay2_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CCF8).ToString("X2");
        public static string Global_AS_Pay_Vis2_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CD10).ToString("X2");
        public static string Global_AS_Pay3_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CD00).ToString("X2");
        public static string Global_AS_Pay_Vis3_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3CD18).ToString("X2");
        public static string Global_Franklin_PP_Cooldown_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3E130).ToString("X2");
        public static string Global_Franklin_PP_Payment_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3DF80).ToString("X2");
        public static string Global_Franklin_PP_Bonus_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x3DF88).ToString("X2");

        public static string Global_Arcade_Safe_Limit_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39218).ToString("X2");
        public static string Global_Arcade_Max_Income_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39220).ToString("X2");
        public static string Global_Arcade_Min_Income_Arcade_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39228).ToString("X2");
        public static string Global_Arcade_Max_Income_Arcade_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39230).ToString("X2");
        public static string Global_Arcade_Bonus_Income_1_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39240).ToString("X2");
        public static string Global_Arcade_Bonus_Income_2_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39248).ToString("X2");
        public static string Global_Arcade_Bonus_Income_3_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39250).ToString("X2");
        public static string Global_Arcade_Bonus_Income_4_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x39258).ToString("X2");
        public static string Global_Dart_Taking_Part_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x86D0).ToString("X2");
        public static string Global_Dart_Match_Win_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x86D6).ToString("X2");
        public static string Global_Dart_Bullseye_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x86C0).ToString("X2");
        public static string Global_Dart_Legs_Won_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x86C8).ToString("X2");
        public static string Global_sing_in_Shower_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0xDE00).ToString("X2");
        public static string Global_toggle_snow_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x9488).ToString("X2");
        public static string Global_halloween_Horns_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x178A0).ToString("X2");
    
        public static string Global_christmas_Horns_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x19B60).ToString("X2");
        public static string Global_Strip_Club_Shot_Price_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0xDC40).ToString("X2");

        public static int Global_Strip_Club_Shot_Price
        {
            get => MemLib.ReadInt(Global_Strip_Club_Shot_Price_);
            set => MemLib.WriteMemory(Global_Strip_Club_Shot_Price_, "int", value.ToString());
        }
        public static int Global_christmas_Horns
        {
            get => MemLib.ReadInt(Global_christmas_Horns_);
            set => MemLib.WriteMemory(Global_christmas_Horns_, "int", value.ToString());
        }
    
        public static int Global_halloween_Horns
        {
            get => MemLib.ReadInt(Global_halloween_Horns_);
            set => MemLib.WriteMemory(Global_halloween_Horns_, "int", value.ToString());
        }
        public static int Global_toggle_snow
        {
            get => MemLib.ReadInt(Global_toggle_snow_);
            set => MemLib.WriteMemory(Global_toggle_snow_, "int", value.ToString());
        }
        public static int Global_sing_in_Shower
        {
            get => MemLib.ReadInt(Global_sing_in_Shower_);
            set => MemLib.WriteMemory(Global_sing_in_Shower_, "int", value.ToString());
        }
        public static float Global_Dart_Legs_Won
        {
            get => MemLib.ReadFloat(Global_Dart_Legs_Won_);
            set => MemLib.WriteMemory(Global_Dart_Legs_Won_, "float", value.ToString());
        }
        public static float Global_Dart_Bullseye
        {
            get => MemLib.ReadFloat(Global_Dart_Bullseye_);
            set => MemLib.WriteMemory(Global_Dart_Bullseye_, "float", value.ToString());
        }
        public static float Global_Dart_Match_Win
        {
            get => MemLib.ReadFloat(Global_Dart_Match_Win_);
            set => MemLib.WriteMemory(Global_Dart_Match_Win_, "float", value.ToString());
        }
        public static float Global_Dart_Taking_Part
        {
            get => MemLib.ReadFloat(Global_Dart_Taking_Part_);
            set => MemLib.WriteMemory(Global_Dart_Taking_Part_, "float", value.ToString());
        }
        public static int Global_Arcade_Bonus_Income_4
        {
            get => MemLib.ReadInt(Global_Arcade_Bonus_Income_4_);
            set => MemLib.WriteMemory(Global_Arcade_Bonus_Income_4_, "int", value.ToString());
        }
        public static int Global_Arcade_Bonus_Income_3
        {
            get => MemLib.ReadInt(Global_Arcade_Bonus_Income_3_);
            set => MemLib.WriteMemory(Global_Arcade_Bonus_Income_3_, "int", value.ToString());
        }
        public static int Global_Arcade_Bonus_Income_2
        {
            get => MemLib.ReadInt(Global_Arcade_Bonus_Income_2_);
            set => MemLib.WriteMemory(Global_Arcade_Bonus_Income_2_, "int", value.ToString());
        }
        public static int Global_Arcade_Bonus_Income_1
        {
            get => MemLib.ReadInt(Global_Arcade_Bonus_Income_1_);
            set => MemLib.WriteMemory(Global_Arcade_Bonus_Income_1_, "int", value.ToString());
        }
        public static int Global_Arcade_Max_Income_Arcade
        {
            get => MemLib.ReadInt(Global_Arcade_Max_Income_Arcade_);
            set => MemLib.WriteMemory(Global_Arcade_Max_Income_Arcade_, "int", value.ToString());
        }
        public static int Global_Arcade_Min_Income_Arcade
        {
            get => MemLib.ReadInt(Global_Arcade_Min_Income_Arcade_);
            set => MemLib.WriteMemory(Global_Arcade_Min_Income_Arcade_, "int", value.ToString());
        }
        public static int Global_Arcade_Max_Income
        {
            get => MemLib.ReadInt(Global_Arcade_Max_Income_);
            set => MemLib.WriteMemory(Global_Arcade_Max_Income_, "int", value.ToString());
        }
        public static int Global_Arcade_Safe_Limit
        {
            get => MemLib.ReadInt(Global_Arcade_Safe_Limit_);
            set => MemLib.WriteMemory(Global_Arcade_Safe_Limit_, "int", value.ToString());
        }
        public static int Global_Franklin_PP_Bonus
        {
            get => MemLib.ReadInt(Global_Franklin_PP_Bonus_);
            set => MemLib.WriteMemory(Global_Franklin_PP_Bonus_, "int", value.ToString());
        }
        public static int Global_Franklin_PP_Payment
        {
            get => MemLib.ReadInt(Global_Franklin_PP_Payment_);
            set => MemLib.WriteMemory(Global_Franklin_PP_Payment_, "int", value.ToString());
        }
        public static int Global_Franklin_PP_Cooldown
        {
            get => MemLib.ReadInt(Global_Franklin_PP_Cooldown_);
            set => MemLib.WriteMemory(Global_Franklin_PP_Cooldown_, "int", value.ToString());
        }
        public static int Global_AS_Pay1
        {
            get => MemLib.ReadInt(Global_AS_Pay1_);
            set => MemLib.WriteMemory(Global_AS_Pay1_, "int", value.ToString());
        }
        public static int Global_AS_Pay_Vis1
        {
            get => MemLib.ReadInt(Global_AS_Pay_Vis1_);
            set => MemLib.WriteMemory(Global_AS_Pay_Vis1_, "int", value.ToString());
        }
        public static int Global_AS_Pay2
        {
            get => MemLib.ReadInt(Global_AS_Pay2_);
            set => MemLib.WriteMemory(Global_AS_Pay2_, "int", value.ToString());
        }
        public static int Global_AS_Pay_Vis2
        {
            get => MemLib.ReadInt(Global_AS_Pay_Vis2_);
            set => MemLib.WriteMemory(Global_AS_Pay_Vis2_, "int", value.ToString());
        }
        public static int Global_AS_Pay3
        {
            get => MemLib.ReadInt(Global_AS_Pay3_);
            set => MemLib.WriteMemory(Global_AS_Pay3_, "int", value.ToString());
        }
        public static int Global_AS_Pay_Vis3
        {
            get => MemLib.ReadInt(Global_AS_Pay_Vis3_);
            set => MemLib.WriteMemory(Global_AS_Pay_Vis3_, "int", value.ToString());
        }
        public static int Global_AS_cChance
        {
            get => MemLib.ReadInt(Global_AS_cChance_);
            set => MemLib.WriteMemory(Global_AS_cChance_, "int", value.ToString());
        }
        public static int Global_AS_vehCooldown
        {
            get => MemLib.ReadInt(Global_AS_vehCooldown_);
            set => MemLib.WriteMemory(Global_AS_vehCooldown_, "int", value.ToString());
        }
        public static int Global_JobRPCap
        {
            get => MemLib.ReadInt(Global_JobRPCap_);
            set => MemLib.WriteMemory(Global_JobRPCap_, "int", value.ToString());
        }
        public static int Global_CMFailMoney
        {
            get => MemLib.ReadInt(Global_CMFailMoney_);
            set => MemLib.WriteMemory(Global_CMFailMoney_, "int", value.ToString());
        }
        public static int Global_CMFailRP
        {
            get => MemLib.ReadInt(Global_CMFailRP_);
            set => MemLib.WriteMemory(Global_CMFailRP_, "int", value.ToString());
        }
        public static float GlobalRPValue
        {
            get => MemLib.ReadFloat(Global_RP_);
            set => MemLib.WriteMemory(Global_RP_, "float", value.ToString());
        }
    }
}
