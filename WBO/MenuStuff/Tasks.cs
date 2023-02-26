using System;
using System.Threading.Tasks;
using static WBO.Player;
using static WBO.Globals;
using static WBO.Bools;
using static WBO.Weapon;
using static WBO.Vehicle;
using static WBO.SigScan;

namespace WBO
{
    internal static class Tasks
    {



        public static async Task AttemptOpenProcess()
        {
            if (!IsProcessOpen && !IsConnectionAttempting)
            {
                IsConnectionAttempting = true;
                if (MemLib.OpenProcess("GTA5"))
                {
                    IsProcessOpen = true;
                    await ConnectWorld();
                    GTA_PROCESS = MemLib.mProc.Process;
                }
                IsConnectionAttempting = false;
            }
        }


        public static async Task Ammo_Loop()
        {
            if (IsAmmoLooperEnabled && !Ammo_Loop_IsLooping)

            {
                if (IsAmmoLooperEnabled && !Ammo_Loop_IsLooping)
                {
                    Ammo_Loop_IsLooping = true;
                    ImpactExplosion = -1;
                    ImpactType = 5;


                    while (true)
                    {
                        ImpactExplosion = new Random().Next(0, 99);
                        await Task.Delay(25);

                        //Reset Impact
                        if (!IsAmmoLooperEnabled)
                        {
                            ImpactExplosion = -1;
                            ImpactType = 3;
                            Ammo_Loop_IsLooping = false;
                            break;
                        }
                    }
                }
                else
                {
                }
            }
        }
        public static async Task RainbowCar_Loop()
        {
            if (IsRainbowLooperEnabled && !Rainbow_Loop_IsLooping)

            {
                if (IsRainbowLooperEnabled && !Rainbow_Loop_IsLooping)
                {
                    Rainbow_Loop_IsLooping = true;
                   

                    while (true)
                    {
                        vehicle_color1_r = (byte)new Random(1).Next(0, 255);
                        await Task.Delay(5);
                        vehicle_color1_g = (byte)new Random(2).Next(0, 255);
                        await Task.Delay(5);
                        vehicle_color1_b = (byte)new Random(3).Next(0, 255);
                        await Task.Delay(5);
                        vehicle_color2_r = (byte)new Random(4).Next(0, 255);
                        await Task.Delay(5);
                        vehicle_color2_g = (byte)new Random(5).Next(0, 255);
                        await Task.Delay(5);
                        vehicle_color2_b = (byte)new Random(6).Next(0, 255);
                        await Task.Delay(5);

                       

                        //Reset Impact
                        if (!IsRainbowLooperEnabled)
                        {
                            
                            Rainbow_Loop_IsLooping = false;
                            break;
                        }
                    }
                }
                else
                {
                }
            }
        }




        public static async Task AutoRP_Loop()
        {
            if (IsLooperEnabled && !AutoRP_Loop_IsLooping)
            {
                AutoRP_Loop_IsLooping = true;
                GlobalRPValue = 250f;
                wanted_level = 1;
                await Task.Delay(1000);
                wanted_level = 0;
                await Task.Delay(1000);
                //Reset RP State!
                GlobalRPValue = 1;
                AutoRP_Loop_IsLooping = false;
            }
            else
            {
            }
        }

    }
}
