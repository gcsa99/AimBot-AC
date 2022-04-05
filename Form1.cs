using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Threading;

namespace AimBot
{ 
    public partial class Form1 : Form
    {
        #region Offsets

        string PlayerBase = "ac_client.exe+0x109B74";
        string EntityList = "ac_client.exe+0x110D90";
        string Health = ",0xF8";
        string X = ",0x4";
        string Y = ",0x8";
        string Z = ",0xC";
        string ViewY = ",0x44";
        string ViewX = ",0x40";
        
        #endregion

        Mem m = new Mem();


        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int PID = m.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                Thread AB = new Thread(Aimbot) { IsBackground = true };
                AB.Start(); 
            }
        }

        void Aimbot()
        {
            while (true)
            {
                GetLocal();



                Thread.Sleep(2);
            }
        }

        Player GetLocal()
        {
            var Player = new Player 
            { 
                X = m.ReadFloat(PlayerBase + X),
                Y = m.ReadFloat(PlayerBase + Y),
                Z = m.ReadFloat(PlayerBase + Z)


            };


            return Player;
        }

    }
}
