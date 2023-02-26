using static WBO.SigScan;
using static WBO.GetAddress;
using static WBO.Bools;

namespace WBO
{
    internal static class Vehicle
    {

        public static void RainbowCarLooperEnabled()
        {
            IsRainbowLooperEnabled = !IsRainbowLooperEnabled;
        }




        public static string vehicle_coord_x_ = "50";
        public static string vehicle_coord_y_ = "54";
        public static string vehicle_coord_z_ = "58";
        public static string vehicle_health1_ = "280";
        public static string vehicle_health2_ = "820";
        public static string vehicle_health3_ = "8E8";
        public static string vehicle_health4_ = "824";

        public static string vehicle_acceleration_ = "4C";
        public static string vehicle_downshift_ = "5C";
        public static string vehicle_upshift_ = "58";
        public static string vehicle_gravity_ = "C3C";
        public static string vehicle_mass_ = "C";
        public static string vehicle_traction_min_ = "90";
        public static string vehicle_traction_max_ = "88";
        public static string vehicle_drive_force_ = "60";
        public static string vehicle_weapon_damage_ = "F4";
        public static string vehicle_engine_damage_ = "FC";
        public static string vehicle_deform_damage_ = "F8";
        public static string vehicle_collision_damage_ = "F0";
        public static string vehicle_mods_ = "58B";
        public static string vehicle_brake_force_ = "6C";
        public static string vehicle_handbrake_force_ = "7C";

        public static string vehicle_color1_r_ = "A6";
        public static string vehicle_color1_g_ = "A5";
        public static string vehicle_color1_b_ = "A4";

        public static string vehicle_color2_r_ = "AA";
        public static string vehicle_color2_g_ = "A9";
        public static string vehicle_color2_b_ = "A8";
        public static int vehicle_color1_r
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color1_r_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color1_r_, "int", value.ToString());
        }
        public static int vehicle_color1_g
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color1_g_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color1_g_, "int", value.ToString());
        }
        public static int vehicle_color1_b
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color1_b_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color1_b_, "int", value.ToString());
        }
        public static int vehicle_color2_r
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color2_r_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color2_r_, "int", value.ToString());
        }
        public static int vehicle_color2_g
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color2_g_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color2_g_, "int", value.ToString());
        }
        public static int vehicle_color2_b
        {
            get => MemLib.ReadInt(CVehicleVisual + "+" + vehicle_color2_b_);
            set => MemLib.WriteMemory(CVehicleVisual + "+" + vehicle_color2_b_, "int", value.ToString());
        }
        public static float vehicle_brake_force
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_brake_force_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_brake_force_, "float", value.ToString());
        }
        public static float vehicle_handbrake_force
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_handbrake_force_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_handbrake_force_, "float", value.ToString());
        }
        public static int vehicle_mods
        {
            get => MemLib.ReadInt(CModelInfo + "+" + vehicle_mods_);
            set => MemLib.WriteMemory(CModelInfo + "+" + vehicle_mods_, "int", value.ToString());
        }
        public static float vehicle_collision_damage
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_collision_damage_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_collision_damage_, "float", value.ToString());
        }
        public static float vehicle_deform_damage
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_deform_damage_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_deform_damage_, "float", value.ToString());
        }
        public static float vehicle_engine_damage
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_engine_damage_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_engine_damage_, "float", value.ToString());
        }
        public static float vehicle_weapon_damage
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_weapon_damage_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_weapon_damage_, "float", value.ToString());
        }
        public static float vehicle_drive_force
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_drive_force_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_drive_force_, "float", value.ToString());
        }
        public static float vehicle_traction_max
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_traction_max_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_traction_max_, "float", value.ToString());
        }
        public static float vehicle_traction_min
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_traction_min_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_traction_min_, "float", value.ToString());
        }
        public static float vehicle_mass
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_mass_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_mass_, "float", value.ToString());
        }
        public static float vehicle_gravity
        {
            get => MemLib.ReadFloat(CVehicle + "+" + vehicle_gravity_);
            set => MemLib.WriteMemory(CVehicle + "+" + vehicle_gravity_, "float", value.ToString());
        }
        public static float vehicle_acceleration
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_acceleration_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_acceleration_, "float", value.ToString());
        }
        public static float vehicle_upshift
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_upshift_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_upshift_, "float", value.ToString());
        }
        public static float vehicle_downshift
        {
            get => MemLib.ReadFloat(CHandlingData + "+" + vehicle_downshift_);
            set => MemLib.WriteMemory(CHandlingData + "+" + vehicle_downshift_, "float", value.ToString());
        }

        public static float vehicle_health1
        {
            get => MemLib.ReadFloat(CVehicle + "+" + vehicle_health1_);
            set => MemLib.WriteMemory(CVehicle + "+" + vehicle_health1_, "float", value.ToString());
        }
        public static float vehicle_health2
        {
            get => MemLib.ReadFloat(CVehicle + "+" + vehicle_health2_);
            set => MemLib.WriteMemory(CVehicle + "+" + vehicle_health2_, "float", value.ToString());
        }
        public static float vehicle_health3
        {
            get => MemLib.ReadFloat(CVehicle + "+" + vehicle_health3_);
            set => MemLib.WriteMemory(CVehicle + "+" + vehicle_health3_, "float", value.ToString());
        }
        public static float vehicle_health4
        {
            get => MemLib.ReadFloat(CVehicle + "+" + vehicle_health4_);
            set => MemLib.WriteMemory(CVehicle + "+" + vehicle_health4_, "float", value.ToString());
        }



        public static float vehicle_coord_x
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_x_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_x_, "float", value.ToString());
        }
        public static float vehicle_coord_y
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_y_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_y_, "float", value.ToString());
        }
        public static float vehicle_coord_z
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_z_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_z_, "float", value.ToString());
        }








    }
}
