using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using static WBO.SigScan;
using static WBO.Bools;
using static WBO.Player;
using static WBO.Weapon;
using static WBO.Vehicle;
using static WBO.Globals;
using static WBO.Roulette;
using static WBO.AiHandling;
using static WBO.GetAddress;
using System.Globalization;

namespace WBO
{
    public partial class Menu : Form
    {
        ColorDialog colorDialog = new ColorDialog();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        Point dragCursorPoint;
        Point dragFormPoint;
        public Menu()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            CheckForIllegalCrossThreadCalls = false;
            Thread shm = new Thread(ShowHideMenu);
            shm.Start();
        }
        void ShowHideMenu()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.G) < 0 && showing == true) //HIDE
                {
                    this.Hide();
                    Process[] p = Process.GetProcessesByName("GTA5");
                    if (p.Length > 0)
                    {
                        SetForegroundWindow(p[0].MainWindowHandle);
                    }
                    showing = false;
                    Thread.Sleep(20);
                }
                else if (GetAsyncKeyState(Keys.G) < 0 && showing == false) // SHOW
                {
                    this.Show();
                    Cursor.Position = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
                    SetForegroundWindow(this.Handle);
                    this.Activate();
                    this.Focus();
                    showing = true;
                    Thread.Sleep(20);
                }
                else if (GetAsyncKeyState(Keys.Delete) < 0) // UNLOAD
                {
                    Environment.Exit(0);
                    Application.Exit();
                }
                Thread.Sleep(70);
            }
        }
        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }
        private void Menu_MouseUp(object sender, MouseEventArgs e) => isDragging = false;
        private void RainbowTimer_Tick(object sender, EventArgs e)
        {
            this.BackColor = GetRandomColor();
        }
        private Color GetRandomColor()
        {
            Random random = new Random();
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);
            return Color.FromArgb(r, g, b);
        }
        private void RainbowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RainbowTimer.Enabled = RainbowCheckbox.Checked;
            this.BackColor = RainbowCheckbox.Checked ? Color.Black : Color.Black;
        }
        private void GodmodeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleGodMode();
        }
        private void SuperJumpCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Thread SuperJump = new Thread(() =>
            {
                while (SuperJumpCheckbox.Checked)
                {
                    MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", SuperJumpCheckbox.Checked ? "64" : "0");
                }
            });

            if (SuperJumpCheckbox.Checked)
            {
                SuperJump.Start();
            }

        }
        private void ZombieJumpCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Thread ZombieJump = new Thread(() =>
            {
                while (ZombieJumpCheckbox.Checked)
                {
                    MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", ZombieJumpCheckbox.Checked ? "-1" : "0");
                }
            });
            if (ZombieJumpCheckbox.Checked)
            {
                ZombieJump.Start();
            }
        }
        private void ExplosiveMeleeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Thread FlamingFists = new Thread(() =>
            {
                while (ExplosiveMeleeCheckbox.Checked)
                {
                    MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", ExplosiveMeleeCheckbox.Checked ? "32" : "0");
                }
            });
            if (ExplosiveMeleeCheckbox.Checked)
            {
                FlamingFists.Start();
            }
        }
        private void UnloadMenuButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
        private void MenuBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
            }
        }
        private void MenuBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    tabPage.BackColor = colorDialog.Color;
                }
            }
        }
        private void MenuOpacity_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (double)MenuOpacity.Value / 100;
        }
        private void button27_Click(object sender, EventArgs e) => tabControl1.SelectTab(0);
        private void WeaponEditorOpen_Click(object sender, EventArgs e) => tabControl1.SelectTab(9);
        private void HandlingEditorOpen_Click(object sender, EventArgs e) => tabControl1.SelectTab(10);
        private void TrafficEditorOpen_Click(object sender, EventArgs e) => tabControl1.SelectTab(8);
        private void TrafficEditorClose_Click(object sender, EventArgs e) => tabControl1.SelectTab(3);
        private void WeaponEditorClose_Click(object sender, EventArgs e) => tabControl1.SelectTab(2);
        private void HandlingEditorClose_Click(object sender, EventArgs e) => tabControl1.SelectTab(3);
        private void PlayerPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(1);
        private void WeaponPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(2);
        private void VehiclePage_Click(object sender, EventArgs e) => tabControl1.SelectTab(3);
        private void TeleportPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(4);
        private void MoneyPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(5);
        private void WorldPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(6);
        private void SettingsPage_Click(object sender, EventArgs e) => tabControl1.SelectTab(7);
        private void UnloadMenu_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
        private void EmptyLobbyButton_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("GTA5")[0];
            process.Suspend();
            System.Threading.Thread.Sleep(10000);
            process.Resume();
        }
        private void ToggleLoopCheckBox_CheckedChanged(object sender, EventArgs e) => ToggleLooperEnabled();
        private void button5_Click(object sender, EventArgs e)
        {
            float[] values = new float[16];
            string[] keys = { s_min_brake_distance_, s_max_brake_distance_, s_max_speed_at_brake_distance_, s_absolute_min_speed_, a_min_brake_distance_, a_max_brake_distance_, a_max_speed_at_brake_distance_, a_absolute_min_speed_, c_min_brake_distance_, c_max_brake_distance_, c_max_speed_at_brake_distance_, c_absolute_min_speed_, t_min_brake_distance_, t_max_brake_distance_, t_max_speed_at_brake_distance_, t_absolute_min_speed_ };
            for (int i = 0; i < keys.Length; i++)
            {
                values[i] = MemLib.ReadFloat(CAIHandlingData + "+" + keys[i]);
            }
            s_min_brake_distance_1.Text = values[0].ToString("F2");
            s_max_brake_distance_1.Text = values[1].ToString("F2");
            s_max_speed_at_brake_distance_1.Text = values[2].ToString("F2");
            s_absolute_min_speed_1.Text = values[3].ToString("F2");
            a_min_brake_distance_3.Text = values[4].ToString("F2");
            a_max_brake_distance_3.Text = values[5].ToString("F2");
            a_max_speed_at_brake_distance_3.Text = values[6].ToString("F2");
            a_absolute_min_speed_3.Text = values[7].ToString("F2");
            c_min_brake_distance_2.Text = values[8].ToString("F2");
            c_max_brake_distance_2.Text = values[9].ToString("F2");
            c_max_speed_at_brake_distance_2.Text = values[10].ToString("F2");
            c_absolute_min_speed_2.Text = values[11].ToString("F2");
            t_min_brake_distance_4.Text = values[12].ToString("F2");
            t_max_brake_distance_4.Text = values[13].ToString("F2");
            t_max_speed_at_brake_distance_4.Text = values[14].ToString("F2");
            t_absolute_min_speed_4.Text = values[15].ToString("F2");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] textBoxes = { s_min_brake_distance_1.Text, s_max_brake_distance_1.Text, s_max_speed_at_brake_distance_1.Text,
                                  s_absolute_min_speed_1.Text, a_min_brake_distance_3.Text, a_max_brake_distance_3.Text,
                                  a_max_speed_at_brake_distance_3.Text, a_absolute_min_speed_3.Text, c_min_brake_distance_2.Text,
                                  c_max_brake_distance_2.Text, c_max_speed_at_brake_distance_2.Text, c_absolute_min_speed_2.Text,
                                  t_min_brake_distance_4.Text, t_max_brake_distance_4.Text, t_max_speed_at_brake_distance_4.Text,
                                  t_absolute_min_speed_4.Text };

            string[] offsets = { s_min_brake_distance_, s_max_brake_distance_, s_max_speed_at_brake_distance_,
                                 s_absolute_min_speed_, a_min_brake_distance_, a_max_brake_distance_,
                                 a_max_speed_at_brake_distance_, a_absolute_min_speed_, c_min_brake_distance_,
                                 c_max_brake_distance_, c_max_speed_at_brake_distance_, c_absolute_min_speed_,
                                 t_min_brake_distance_, t_max_brake_distance_, t_max_speed_at_brake_distance_,
                                 t_absolute_min_speed_ };

            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i] != "")
                    MemLib.WriteMemory(CAIHandlingData + "+" + offsets[i], "float", textBoxes[i]);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            s_max_brake_distance = 0;
            a_max_brake_distance = 0;
            c_max_brake_distance = 0;
            t_max_brake_distance = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //DEFAULT VALUES
            //Sports Car
            s_min_brake_distance = 10;
            s_max_brake_distance = 80;
            s_max_speed_at_brake_distance = 50;
            s_absolute_min_speed = 1;
            //Average Car
            a_min_brake_distance = 10;
            a_max_brake_distance = 80;
            a_max_speed_at_brake_distance = 30;
            a_absolute_min_speed = 1;
            //Crap
            c_min_brake_distance = 10;
            c_max_brake_distance = 100;
            c_max_speed_at_brake_distance = 30;
            c_absolute_min_speed = 1;
            //Trucks
            t_min_brake_distance = 10;
            t_max_brake_distance = 100;
            t_max_speed_at_brake_distance = 30;
            t_absolute_min_speed = 1;
        }
        private void SuicideButton_Click(object sender, EventArgs e)
        {
            player_health = 0;
            player_armor = 0;
        }
        private void HealButton_Click(object sender, EventArgs e)
        {
            player_health = 328;
            player_armor = 200;
        }
        private void RemoveWantedButton_Click(object sender, EventArgs e) => wanted_level = 0;
        private void MaxWantedButton_Click(object sender, EventArgs e) => wanted_level = 5;
        private void BGMods_Tick(object sender, EventArgs e)
        {
            wanted_level = WantedCheckBox.Checked ? 0 : wanted_level;
            player_collision = CollisionCheckBox.Checked ? -1 : player_collision;

            if (ARCx3.Checked)
            {
                Global_Arcade_Safe_Limit = 300000;
                Global_Arcade_Max_Income = 15000;
                Global_Arcade_Min_Income_Arcade = 600;
                Global_Arcade_Max_Income_Arcade = 750;
                Global_Arcade_Bonus_Income_1 = 375;
                Global_Arcade_Bonus_Income_2 = 375;
                Global_Arcade_Bonus_Income_3 = 1050;
                Global_Arcade_Bonus_Income_4 = 150;
            }
            if (RigTable.Checked)
            {
                roulette_table_bet = 40000;
                roulette_left_table = 37;
                roulette_right_table = 37;
            }
            if (ShowerRP.Checked)
            {
                Global_sing_in_Shower = 25000;
            }
            if (Frankcool.Checked)
            {
                Global_Franklin_PP_Cooldown = 600000;
            }
            if (WeatherTimeBP.Checked)
            {
                MemLib.WriteMemory(TimeBaseAddress + "+104", "int", "1");
                MemLib.WriteMemory(TimeBPBaseAddress, "int", "1");
            }
            if (DartRP.Checked)
            {
                Global_Dart_Taking_Part = 500;
                Global_Dart_Match_Win = 500;
                Global_Dart_Bullseye = 500;
                Global_Dart_Legs_Won = 500;
                Global_JobRPCap = 50000;
            }
            if (frankpaynbonus.Checked)
            {
                Global_Franklin_PP_Payment = 80000;
                Global_Franklin_PP_Bonus = 80000;
            }
            if (ASx4Del.Checked)
            {
                Global_AS_Pay1 = 80000;
                Global_AS_Pay_Vis1 = 80000;
                Global_AS_Pay2 = 100000;
                Global_AS_Pay_Vis2 = 100000;
                Global_AS_Pay3 = 120000;
                Global_AS_Pay_Vis3 = 120000;
            }
            if (CMFailBox.Checked)
            {
                Global_CMFailMoney = 170000;
                Global_CMFailRP = 30000;
                Global_JobRPCap = 30000;
            }
            if (ENhotkeys.Checked)
            {
                if (GetAsyncKeyState(Keys.NumPad0) < 0)
                {
                    player_health = 328;
                    player_armor = 200;
                }
                if (GetAsyncKeyState(Keys.NumPad1) < 0)
                {
                    player_health = 0;
                    player_armor = 0;
                }
                if (GetAsyncKeyState(Keys.NumPad7) < 0)
                {
                    G1_Click(sender, e);
                }
                if (GetAsyncKeyState(Keys.NumPad4) < 0)
                {
                    S1_Click(sender, e);
                }
                if (GetAsyncKeyState(Keys.NumPad9) < 0)
                {
                    G2_Click(sender, e);
                }
                if (GetAsyncKeyState(Keys.NumPad6) < 0)
                {
                    S2_Click(sender, e);
                }
                if (GetAsyncKeyState(Keys.NumPad2) < 0)
                {
                    RemoveWantedButton_Click(sender, e);
                }
                if (GetAsyncKeyState(Keys.NumPad3) < 0)
                {
                    MaxWantedButton_Click(sender, e);
                }
            }
        }
        private void Menu_Load(object sender, EventArgs e) => BGMods.Start();
        private void RunSpeedMult_Scroll(object sender, EventArgs e)
        {
            run_speed = RunSpeedMult.Value;
            swim_speed = RunSpeedMult.Value;
            stealth_speed = RunSpeedMult.Value;
        }
        private void UndeadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            player_max_health = UndeadCheckBox.Checked ? 0 : 328;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Sports Car
            s_min_brake_distance = 1;
            s_max_brake_distance = 1;
            s_max_speed_at_brake_distance = 100;
            s_absolute_min_speed = 100;
            //Average Car
            a_min_brake_distance = 1;
            a_max_brake_distance = 1;
            a_max_speed_at_brake_distance = 100;
            a_absolute_min_speed = 100;
            //Crap
            c_min_brake_distance = 1;
            c_max_brake_distance = 1;
            c_max_speed_at_brake_distance = 100;
            c_absolute_min_speed = 100;
            //Trucks
            t_min_brake_distance = 1;
            t_max_brake_distance = 1;
            t_max_speed_at_brake_distance = 100;
            t_absolute_min_speed = 100;
        }
        private void TPammu_Click(object sender, EventArgs e)
        {
            player_coord_x = 14;
            player_coord_y = -1121;
            player_coord_z = 29;
            player_visual_coord_x = 14;
            player_visual_coord_y = -1121;
            player_visual_coord_z = 29;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            player_coord_x = -721;
            player_visual_coord_x = -721;
            player_coord_y = -159;
            player_visual_coord_y = -159;
            player_coord_z = 38;
            player_visual_coord_z = 38;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            player_coord_x = -828;
            player_visual_coord_x = -828;
            player_coord_y = -191;
            player_visual_coord_y = -191;
            player_coord_z = 38;
            player_visual_coord_z = 38;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            player_coord_x = -1341;
            player_visual_coord_x = -1341;
            player_coord_y = -1280;
            player_visual_coord_y = -1280;
            player_coord_z = 5;
            player_visual_coord_z = 5;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            player_coord_x = -1159;
            player_visual_coord_x = -1159;
            player_coord_y = -1420;
            player_visual_coord_y = -1420;
            player_coord_z = 5;
            player_visual_coord_z = 5;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            player_coord_x = -1381;
            player_visual_coord_x = -1381;
            player_coord_y = 58;
            player_visual_coord_y = 58;
            player_coord_z = 54;
            player_visual_coord_z = 54;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            player_coord_x = 130;
            player_visual_coord_x = 130;
            player_coord_y = -202;
            player_visual_coord_y = -202;
            player_coord_z = 55;
            player_visual_coord_z = 55;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            player_coord_x = 414;
            player_visual_coord_x = 414;
            player_coord_y = -807;
            player_visual_coord_y = -807;
            player_coord_z = 30;
            player_visual_coord_z = 30;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            player_coord_x = 1996;
            player_visual_coord_x = 1996;
            player_coord_y = 3059;
            player_visual_coord_y = 3059;
            player_coord_z = 47;
            player_visual_coord_z = 47;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            player_coord_x = 88;
            player_visual_coord_x = 88;
            player_coord_y = -1392;
            player_visual_coord_y = -1392;
            player_coord_z = 29;
            player_visual_coord_z = 29;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            player_coord_x = 133;
            player_visual_coord_x = 133;
            player_coord_y = -1306;
            player_visual_coord_y = -1306;
            player_coord_z = 29;
            player_visual_coord_z = 29;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            player_coord_x = -371;
            player_visual_coord_x = -371;
            player_coord_y = -130;
            player_visual_coord_y = -130;
            player_coord_z = 38;
            player_visual_coord_z = 38;
            vehicle_coord_x = -371;
            vehicle_coord_y = -130;
            vehicle_coord_z = 38;

        }
        private void button25_Click(object sender, EventArgs e)
        {
            player_coord_x = 790;
            player_visual_coord_x = 790;
            player_coord_y = -1867;
            player_visual_coord_y = -1867;
            player_coord_z = 29;
            player_visual_coord_z = 29;
            vehicle_coord_x = 790;
            vehicle_coord_y = -1867;
            vehicle_coord_z = 29;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            player_coord_x = 120;
            player_visual_coord_x = 120;
            player_coord_y = 6613;
            player_visual_coord_y = 6613;
            player_coord_z = 31;
            player_visual_coord_z = 31;
            vehicle_coord_x = 120;
            vehicle_coord_y = 6613;
            vehicle_coord_z = 31;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            player_coord_x = -203;
            player_visual_coord_x = -203;
            player_coord_y = -1300;
            player_visual_coord_y = -1300;
            player_coord_z = 31;
            player_visual_coord_z = 31;
            vehicle_coord_x = -203;
            vehicle_coord_y = -1300;
            vehicle_coord_z = 31;
        }
        private void InfAmmoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InfAmmo = InfAmmoCheckBox.Checked ? 3 : 0;
        }
        private void Fists_Click(object sender, EventArgs e) => ImpactType = 2;
        private void Bullets_Click(object sender, EventArgs e) => ImpactType = 3;
        private void Explosions_Click(object sender, EventArgs e) => ImpactType = 5;
        private void Default_Click(object sender, EventArgs e) => ImpactExplosion = -1;
        private void Grenade_Click(object sender, EventArgs e) => ImpactExplosion = 5;
        private void Molotov_Click(object sender, EventArgs e) => ImpactExplosion = 3;
        private void EMP_Click(object sender, EventArgs e) => ImpactExplosion = 83;
        private void Water_Click(object sender, EventArgs e) => ImpactExplosion = 13;
        private void Flame_Click(object sender, EventArgs e) => ImpactExplosion = 12;
        private void Gas_Click(object sender, EventArgs e) => ImpactExplosion = 21;
        private void Railgun_Click(object sender, EventArgs e) => ImpactExplosion = 36;
        private void Raygun_Click(object sender, EventArgs e) => ImpactExplosion = 70;
        private void Orbital_Click(object sender, EventArgs e) => ImpactExplosion = 59;
        private void Blimp_Click(object sender, EventArgs e) => ImpactExplosion = 29;
        private void Flare_Click(object sender, EventArgs e) => ImpactExplosion = 22;
        private void Smoke_Click(object sender, EventArgs e) => ImpactExplosion = 20;
        private void Snowball_Click(object sender, EventArgs e) => ImpactExplosion = 39;
        private void Extinguisher_Click(object sender, EventArgs e) => ImpactExplosion = 24;
        private void button18_Click(object sender, EventArgs e)
        {
            if (ImpactTypeTextBox.Text != "")
                MemLib.WriteMemory(CWeaponInfo + "+" + ImpactExplosionOffset, "int", ImpactTypeTextBox.Text);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            PenetrationBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + PenetrationOffset).ToString("F2");
            SpreadBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + WeaponSpreadOffset).ToString("F2");
            BulletSpeedBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + BulletSpeedOffset).ToString("F2");
            PedForceBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + PedForceOffset).ToString("F2");
            VehForceBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + VehForceOffset).ToString("F2");
            HeliForceBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + HeliForceOffset).ToString("F2");
            BatchSpreadBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + BatchSpreadOffset).ToString("F2");
            DamageBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + m_damageOffset).ToString("F2");
            TBSBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + timebetweenshotOffset).ToString("F2");
            m_explosion_shake_amplitude_1.Text = MemLib.ReadFloat(CWeaponInfo + "+" + m_explosion_shake_amplitude_).ToString("F2");
            RecoilShakeBox.Text = MemLib.ReadFloat(CWeaponInfo + "+" + Recoil_shake_).ToString("F2");
        }
        private void button20_Click(object sender, EventArgs e)
        {
            string[] values = { PenetrationBox.Text, m_explosion_shake_amplitude_1.Text, SpreadBox.Text, BulletSpeedBox.Text, PedForceBox.Text, VehForceBox.Text,
                        HeliForceBox.Text, BatchSpreadBox.Text, DamageBox.Text, TBSBox.Text, RecoilShakeBox.Text };
            string[] offsets = { PenetrationOffset, m_explosion_shake_amplitude_, WeaponSpreadOffset, BulletSpeedOffset, PedForceOffset, VehForceOffset,
                        HeliForceOffset,BatchSpreadOffset, m_damageOffset, timebetweenshotOffset, Recoil_shake_ };
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != "")
                    MemLib.WriteMemory(CWeaponInfo + "+" + offsets[i], "float", values[i]);
            }
        }
        private void G1_Click(object sender, EventArgs e)
        {
            X1.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_x_).ToString("F2");
            Y1.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_y_).ToString("F2");
            Z1.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_z_).ToString("F2");
        }
        private void S1_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(CNavigation + "+" + player_coord_x_, "float", X1.Text);
            MemLib.WriteMemory(CNavigation + "+" + player_coord_y_, "float", Y1.Text);
            MemLib.WriteMemory(CNavigation + "+" + player_coord_z_, "float", Z1.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_x_, "float", X1.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_y_, "float", Y1.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_z_, "float", Z1.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_x_, "float", X1.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_y_, "float", Y1.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_z_, "float", Z1.Text);
        }
        private void G2_Click(object sender, EventArgs e)
        {
            X2.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_x_).ToString("F2");
            Y2.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_y_).ToString("F2");
            Z2.Text = MemLib.ReadFloat(CNavigation + "+" + player_coord_z_).ToString("F2");
        }
        private void S2_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(CNavigation + "+" + player_coord_x_, "float", X2.Text);
            MemLib.WriteMemory(CNavigation + "+" + player_coord_y_, "float", Y2.Text);
            MemLib.WriteMemory(CNavigation + "+" + player_coord_z_, "float", Z2.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_x_, "float", X2.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_y_, "float", Y2.Text);
            MemLib.WriteMemory(CPed + "+" + player_visual_coord_z_, "float", Z2.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_x_, "float", X2.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_y_, "float", Y2.Text);
            MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_z_, "float", Z2.Text);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            player_coord_x = -952;
            player_visual_coord_x = -952;
            player_coord_y = -571;
            player_visual_coord_y = -571;
            player_coord_z = 18;
            player_visual_coord_z = 18;
        }
        private void VGmod_CheckedChanged(object sender, EventArgs e)
        {
            Thread VehicleAutoHeal = new Thread(() =>
            {
                while (VGmod.Checked)
                {
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health1_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health2_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health3_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health4_, "float", "1000");
                }
            });
            if (VGmod.Checked)
            {
                VehicleAutoHeal.Start();
            }
        }
        private void PerfHandling_Click(object sender, EventArgs e)
        {
            vehicle_downshift = 25;
            vehicle_upshift = 25;
            vehicle_acceleration = 15;
            vehicle_gravity = 25;
            vehicle_mass = 15000;
            vehicle_traction_max = 3;
            vehicle_traction_min = 3;
            vehicle_drive_force = 10;
            vehicle_weapon_damage = 0;
            vehicle_engine_damage = 0;
            vehicle_deform_damage = 0;
            vehicle_collision_damage = 0;
            vehicle_brake_force = 10;
            vehicle_handbrake_force = 10;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            vehicle_mods = 864;
        }
        private void HealVeh_Click(object sender, EventArgs e)
        {
            vehicle_health1 = 1000;
            vehicle_health2 = 1000;
            vehicle_health3 = 1000;
            vehicle_health4 = 1000;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.unknowncheats.me/forum/index.php");
        }
        private void button28_Click(object sender, EventArgs e)
        {
            player_coord_x = 1143;
            player_coord_y = 261;
            player_coord_z = -51;
            player_visual_coord_x = 1143;
            player_visual_coord_y = 261;
            player_visual_coord_z = -51;
        }
        private void button29_Click(object sender, EventArgs e)
        {
            player_coord_x = 1114;
            player_coord_y = 220;
            player_coord_z = -49;
            player_visual_coord_x = 1114;
            player_visual_coord_y = 220;
            player_visual_coord_z = -49;
        }
        private void button30_Click(object sender, EventArgs e)
        {
            player_coord_x = 1104;
            player_coord_y = 204;
            player_coord_z = -49;
            player_visual_coord_x = 1104;
            player_visual_coord_y = 204;
            player_visual_coord_z = -49;
        }
        private void button31_Click(object sender, EventArgs e)
        {
            player_coord_x = 917;
            player_visual_coord_x = 917;
            player_coord_y = 50;
            player_visual_coord_y = 50;
            player_coord_z = 81;
            player_visual_coord_z = 81;
            vehicle_coord_x = 917;
            vehicle_coord_y = 50;
            vehicle_coord_z = 81;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Thread FireAmmo = new Thread(() =>
            {
                while (checkBox1.Checked)
                {
                    MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", checkBox1.Checked ? "16" : "0");
                }
            });
            if (checkBox1.Checked)
            {
                FireAmmo.Start();
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Thread ExplosiveAmmo = new Thread(() =>
            {
                while (checkBox2.Checked)
                {
                    MemLib.WriteMemory(CPlayerInfo + "+" + frame_flags_, "int", checkBox2.Checked ? "8" : "0");
                }
            });
            if (checkBox2.Checked)
            {
                ExplosiveAmmo.Start();
            }
        }
        private void SnowBox_CheckedChanged(object sender, EventArgs e)
        {
            Global_toggle_snow = SnowBox.Checked ? 1 : 0;
        }
        private void button32_Click(object sender, EventArgs e)
        {
            Global_christmas_Horns = 1;
            Global_halloween_Horns = 1;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                MemLib.WriteMemory(Global_Strip_Club_Shot_Price_, "int", textBox1.Text);
        }
        private void button34_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
             "EDIT SHOT PRICE AT STRIP CLUB" + "\n" + "\n" + "TO GET RID OF YOUR MONEY" + "\n" + "OR ENJOY SOME FREE DRINKS :)"
             );
        }
        private void button22_Click(object sender, EventArgs e)
        {
            DownshiftBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_downshift_).ToString("F2");
            UpshiftBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_upshift_).ToString("F2");
            BrakeBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_brake_force_).ToString("F2");
            HandbrakeBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_handbrake_force_).ToString("F2");
            AccelerationBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_acceleration_).ToString("F2");
            GravityBox.Text = MemLib.ReadFloat(CVehicle + "+" + vehicle_gravity_).ToString("F2");
            MassBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_mass_).ToString("F2");
            TractionMinBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_traction_min_).ToString("F2");
            TractionMaxBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_traction_max_).ToString("F2");
            DriveForceBox.Text = MemLib.ReadFloat(CHandlingData + "+" + vehicle_drive_force_).ToString("F2");
        }
        private void button35_Click(object sender, EventArgs e)
        {
            string[] values = { DownshiftBox.Text, UpshiftBox.Text, BrakeBox.Text, HandbrakeBox.Text, AccelerationBox.Text, MassBox.Text,
                        TractionMinBox.Text, TractionMaxBox.Text, DriveForceBox.Text };
            string[] offsets = { vehicle_downshift_, vehicle_upshift_, vehicle_brake_force_, vehicle_handbrake_force_, vehicle_acceleration_, vehicle_mass_,
                        vehicle_traction_min_,vehicle_traction_max_, vehicle_drive_force_ };
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != "")
                    MemLib.WriteMemory(CHandlingData + "+" + offsets[i], "float", values[i]);
                MemLib.WriteMemory(CVehicle + "+" + vehicle_gravity_, "float", GravityBox.Text);
            }
        }
        private void RagdollBox_CheckedChanged(object sender, EventArgs e)
        {
            Thread NoRagdoll = new Thread(() =>
            {
                while (RagdollBox.Checked)
                {
                    MemLib.WriteMemory(CPed + "+" + ragdoll_, "byte", RagdollBox.Checked ? "0" : "32");
                }
            });
            if (RagdollBox.Checked)
            {
                NoRagdoll.Start();
            }
        }
        private void SeatbeltBox_CheckedChanged(object sender, EventArgs e)
        {
            Thread Seatbelt = new Thread(() =>
            {
                while (SeatbeltBox.Checked)
                {
                    MemLib.WriteMemory(CPed + "+" + seatbelt_, "int", SeatbeltBox.Checked ? "201" : "200");
                }
            });
            if (SeatbeltBox.Checked)
            {
                Seatbelt.Start();
            }
        }
        private void button36_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "3");
        }
        private void button37_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "7");
            
        }
        private void button38_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "1");
           
        }
        private void button39_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "0");
          
        }
        private void button40_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "6");
            
        }
        private void button41_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "11");
            
        }
        private void button42_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "3");       
        }
        private void button43_Click(object sender, EventArgs e)
        {         
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "0");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");         
        }
        private void button44_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "12");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");          
        }
        private void button45_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "6");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");           
        }
        private void button46_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "18");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");         
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AmmoLooperEnabled();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            RainbowCarLooperEnabled();
            vehicle_color1_r = 255;
            vehicle_color1_g = 255;
            vehicle_color1_b = 255;
            vehicle_color2_r = 255;
            vehicle_color2_g = 255;
            vehicle_color2_b = 255;
        }
    }
}

