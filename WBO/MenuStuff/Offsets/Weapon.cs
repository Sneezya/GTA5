using static WBO.SigScan;
using static WBO.GetAddress;
using static WBO.Bools;

namespace WBO
{
    internal static class Weapon
    {
        public static void AmmoLooperEnabled()
        {
            IsAmmoLooperEnabled = !IsAmmoLooperEnabled;
        }


        public static string InfAmmoOffset = "78";
        public static string ImpactOffset = "20";
        public static string ImpactExplosionOffset = "24";
        public static string PenetrationOffset = "110";
        public static string WeaponSpreadOffset = "74";
        public static string BulletSpeedOffset = "11C";
        public static string PedForceOffset = "DC";
        public static string VehForceOffset = "E0";
        public static string HeliForceOffset = "E4";
        public static string BulletsinBatchOffset = "120";
        public static string BatchSpreadOffset = "124";
        public static string m_damageOffset = "B0";
        public static string timebetweenshotOffset = "13C";
        public static string m_explosion_shake_amplitude_ = "2F8";
        public static string Recoil_shake_ = "2F4";

        public static float Recoil_shake
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + Recoil_shake_);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + Recoil_shake_, "float", value.ToString());
        }
        public static float m_explosion_shake_amplitude
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + m_explosion_shake_amplitude_);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + m_explosion_shake_amplitude_, "float", value.ToString());
        }
        public static float timebetweenshots
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + timebetweenshotOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + timebetweenshotOffset, "float", value.ToString());
        }
       
        public static float m_damage
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + m_damageOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + m_damageOffset, "float", value.ToString());
        }
        public static float WeaponHeliForce
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + HeliForceOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + HeliForceOffset, "float", value.ToString());
        }
        public static int BulletsinBatch
        {
            get => MemLib.ReadInt(CWeaponInfo + "+" + BulletsinBatchOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + BulletsinBatchOffset, "int", value.ToString());
        }
        public static float BatchSpread
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + BatchSpreadOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + BatchSpreadOffset, "float", value.ToString());
        }
        public static float WeaponVehForce
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + VehForceOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + VehForceOffset, "float", value.ToString());
        }
        public static float WeaponPedForce
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + PedForceOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + PedForceOffset, "float", value.ToString());
        }
        public static int ImpactType
        {
            get => MemLib.ReadInt(CWeaponInfo + "+" + ImpactOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + ImpactOffset, "int", value.ToString());
        }
        public static float Penetration
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + PenetrationOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + PenetrationOffset, "float", value.ToString());
        }
        public static float BulletSpeed
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + BulletSpeedOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + BulletSpeedOffset, "float", value.ToString());
        }
        public static float WeaponSpread
        {
            get => MemLib.ReadFloat(CWeaponInfo + "+" + WeaponSpreadOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + WeaponSpreadOffset, "float", value.ToString());
        }
        public static int ImpactExplosion
        {
            get => MemLib.ReadInt(CWeaponInfo + "+" + ImpactExplosionOffset);
            set => MemLib.WriteMemory(CWeaponInfo + "+" + ImpactExplosionOffset, "int", value.ToString());
        }
        public static int InfAmmo
        {
            get => MemLib.ReadInt(CWeaponInventory + "+" + InfAmmoOffset);
            set => MemLib.WriteMemory(CWeaponInventory + "+" + InfAmmoOffset, "int", value.ToString());
        }


    }
}
