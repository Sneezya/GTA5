using static WBO.SigScan;

namespace WBO
{
    internal static class GetAddress
    {

        public static string WeatherADDR => MemLib.ReadLong(WeatherBaseAddress + 4).ToString("X2");
        public static string WorldPTR => MemLib.ReadLong(WorldBaseAddress).ToString("X2");
        public static string GameArrayPTR => MemLib.ReadLong(GameArrayBaseAddress).ToString("X2");
        public static string Roulette1 => MemLib.ReadLong(GameArrayPTR + "+30").ToString("X2");
        public static string Roulette2 => MemLib.ReadLong(Roulette1 + "+8").ToString("X2");
        public static string Roulette3 => MemLib.ReadLong(Roulette2 + "+108").ToString("X2");
        public static string CPed => MemLib.ReadLong(WorldPTR + "+8").ToString("X2");
        public static string CPlayerInfo => MemLib.ReadLong(CPed + "+10A8").ToString("X2");
        public static string CWeaponInventory => MemLib.ReadLong(CPed + "+10B0").ToString("X2");
        public static string CPedWeaponManager => MemLib.ReadLong(CPed + "+10B8").ToString("X2");
        public static string CNavigation => MemLib.ReadLong(CPed + "+30").ToString("X2");
        public static string CModelInfo => MemLib.ReadLong(CVehicle + "+20").ToString("X2");
        public static string CWeaponInfo => MemLib.ReadLong(CPedWeaponManager + "+20").ToString("X2");
        public static string CHandlingData => MemLib.ReadLong(CVehicle + "+918").ToString("X2");
        public static string CVehicleDrawHandler => MemLib.ReadLong(CVehicle + "+48").ToString("X2");
        public static string CVehicleVisual => MemLib.ReadLong(CVehicleDrawHandler + "+20").ToString("X2");
        public static string CAIHandlingData => MemLib.ReadLong(CHandlingData + "+150").ToString("X2");
        public static string CVehicle => MemLib.ReadLong(CPed + "+D10").ToString("X2");
        public static string CVehicleStuff => MemLib.ReadLong(CVehicle + "+30").ToString("X2");
        public static string Collision1 => MemLib.ReadLong(CPed + "+30").ToString("X2");
        public static string Collision2 => MemLib.ReadLong(Collision1 + "+10").ToString("X2");
        public static string Collision3 => MemLib.ReadLong(Collision2 + "+20").ToString("X2");
        public static string Collision4 => MemLib.ReadLong(Collision3 + "+70").ToString("X2");
        public static string Collision5 => MemLib.ReadLong(Collision4 + "+0").ToString("X2");

        

    }
}
