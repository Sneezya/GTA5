using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using static WBO.SigScan;
using static WBO.Tasks;
using static WBO.Bools;
using static WBO.Player;
using static WBO.GetAddress;
using System.Threading;

namespace WBO
{
    public partial class Information : Form
    {            
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        public Information()
        {      
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.AllowTransparency = true;
            this.BackColor = Color.Wheat;
            CheckForIllegalCrossThreadCalls = false;
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            Thread shh = new Thread(ShowHideHotkeys);
            shh.Start();
            int initialStyle = Imps.GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x8000 | 0x20);
            var T = "";
            Task.Run(async () =>
            {
                while (true)
                {
                    if (GTA_PROCESS != null)
                    {
                        if (GTA_PROCESS.HasExited)
                        {
                            GTA_PROCESS = null;
                            IsProcessOpen = false;
                        }
                    }
                    AttemptOpenProcess();
                    AutoRP_Loop();
                    Ammo_Loop();
                    RainbowCar_Loop();
                    T = IsProcessOpen ? MemLib.mProc.Process.ProcessName.ToString() + " Menu Loaded ! " : "Please Open GTA5 !";
                    if (ConnectionText.Text != T)
                        ConnectionText.Text = T;
                    ConnectionText.ForeColor = IsProcessOpen ? Color.Green : Color.Red;
                    await Task.Delay(100);
                }
            });
        }
        void ShowHideHotkeys()
             {
            while (true)
            {
                if (GetAsyncKeyState(Keys.F5) < 0 && HotkeysShowing == true) //HIDE
                {
                    panel1.Hide();

                    HotkeysShowing = false;
                    Thread.Sleep(20);
                }
                else if (GetAsyncKeyState(Keys.F5) < 0 && HotkeysShowing == false) // SHOW
                {
                    panel1.Show();
                    HotkeysShowing = true;
                    Thread.Sleep(20);
                }            
                Thread.Sleep(70);
            }
        }
        private void Information_Load(object sender, EventArgs e)
        {
            Menu MenuForm = new Menu();
            MenuForm.Show();
            InfoBGMods.Start();
            panel1.Hide();
        
        }
        private void InfoBGMods_Tick(object sender, EventArgs e)
        {
            WelcomeLabel.Text = iRockstarID;
            ArmorLabel.Text = "Armor : " + MemLib.ReadFloat(CPed + "+" + player_armor_).ToString("F2");
            HealthLabel.Text = "Health : " + MemLib.ReadFloat(CPed + "+" + player_health_).ToString("F2");
            PosX.Text = "Pos X : " + MemLib.ReadFloat(CNavigation + "+" + player_coord_x_).ToString("F2");
            PosY.Text = "Pos Y : " + MemLib.ReadFloat(CNavigation + "+" + player_coord_y_).ToString("F2");
            PosZ.Text = "Pos Z : " + MemLib.ReadFloat(CNavigation + "+" + player_coord_z_).ToString("F2");
        }
    }
}
