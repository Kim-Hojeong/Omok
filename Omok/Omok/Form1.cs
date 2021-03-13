using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omok
{
    public partial class Form1 : Form
    {
        bool IsStart;
        int Player;
        public Form1()
        {
            InitializeComponent();

            IsStart = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            for (int y = 0; y < 19; y++)
            {
                for (int x = 0; x < 19; x++)
                {
                    Point st, ed;

                    st = new Point(x * 40 + 40, y * 40 + 40);
                    ed = new Point(x * 40 + 40, 19 * 40);

                    g.DrawLine(Pens.Black, st, ed);

                    st = new Point(x * 40 + 40, y * 40 + 40);
                    ed = new Point(19 * 40, y * 40 + 40);

                    g.DrawLine(Pens.Black, st, ed);
                }
            }

            g.Dispose();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsStart == false)
                return;

            Graphics g = panel1.CreateGraphics();

            Point pt = new Point(((e.X + 20) / 40) * 40, ((e.Y + 20) / 40) * 40);

            Rectangle rect = new Rectangle(pt.X - 15, pt.Y - 15, 30, 30);

            if (Player == 0)
                g.FillEllipse(Brushes.Black, rect);
            else
                g.FillEllipse(Brushes.White, rect);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IsStart = true;

            Player = 0;

            MessageBox.Show("시작합니다.");

            txtTurn.Text = string.Format("Player{0}", Player + 1);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (IsStart == false)
                return;

            Player++;

            Player %= 2;

            txtTurn.Text = string.Format("Player{0}", Player + 1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료합니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            this.Close();
        }
    }
}
