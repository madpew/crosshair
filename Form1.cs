using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crosshair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.FixedToolWindow) return;

            if (x != 0 && y != 0)
            {
                this.Left = x;
                this.Top = y;
            }

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.BackColor = Color.White;
        }

        private int x, y;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Activate();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripMenuItem);

            switch(item.Tag as string)
            {
                case "1": this.BackgroundImage = Properties.Resources.cross1; break;
                case "2": this.BackgroundImage = Properties.Resources.cross2; break;
                case "3": this.BackgroundImage = Properties.Resources.cross3; break;
                case "4": this.BackgroundImage = Properties.Resources.cross4; break;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            x = this.Left;
            y = this.Top;

            var borderWidth = (this.Bounds.Width - this.ClientRectangle.Width) / 2;
            var borderHeight = this.Bounds.Height - this.ClientRectangle.Height - borderWidth;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Magenta;

            this.Left += borderWidth;
            this.Top += borderHeight;
        }
    }
}
