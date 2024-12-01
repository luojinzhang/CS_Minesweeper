using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silent_Hill
{
    public partial class SilentHillGame : Form
    {
        Cell[,] Table = new Cell[10, 10];
        int timeClock;
        public SilentHillGame()
        {
            InitializeComponent();
            timeClock = 0;
            Clock.Start();
        }
        private void SilentHillGame_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table[i, j] = new Cell();
                }
            }
            Program.newTable(Table);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table[i, j].Left = 50 + 50 * j;
                    Table[i, j].Top = 50 + 50 * i;
                    Table[i, j].Width = 50;
                    Table[i, j].Height = 50;
                    Table[i, j].MouseDown += new MouseEventHandler(this.SilentHillGame_Click);
                    Table[i, j].BackColor = Color.Violet;
                    Table[i, j].Parent = this;
                }
            }
        }
        void SilentHillGame_Click(object sender, MouseEventArgs e)
        {
            Cell Clicked = (Cell)sender;
            bool find = false;
            int m = 0, n = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Clicked == Table[i, j])
                    {
                        find = true;
                        n = j;
                        break;
                    }
                }
                if (find == true)
                {
                    m = i;
                    break;
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left && Table[m, n].Status == CellStatus.Idle)
            {
                Clicked.Text = Table[m, n].Value.ToString();
                Clicked.BackColor = Color.Transparent;
                Table[m, n].open();
                if (Table[m, n].Value == 0)
                {
                    Clicked.Text = null;
                    DetectExplosion(m, n);
                }
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right && Table[m, n].Status == CellStatus.Idle)
            {
                Table[m, n].flag();
                Table[m, n].BackColor = Color.Red;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right && Table[m, n].Status == CellStatus.Flag)
            {
                Table[m, n].BackColor = Color.Violet;
                Table[m, n].unFlag();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left && Clicked.Value == CellValue.Bomb && Clicked.Status == CellStatus.Open)
            {
                Clock.Stop();
                MessageBox.Show("You lost");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Table[i, j].Enabled = false;

                        if (Table[i, j].Value == CellValue.Bomb)
                        {
                            Table[i, j].BackColor = Color.Transparent;
                            Table[i, j].Text = Table[i, j].Value.ToString();
                        }
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ( Table[i,j].Status == CellStatus.Open)
                    {
                        count++;
                    }
                   
                }
            }
            if (count == Table.Length - 20)
            {
                Clock.Stop();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Table[i, j].Enabled = false;
                        Table[i, j].Text = Table[i, j].Value.ToString();
                        if (Table[i,j].Value == CellValue.Bomb)
                        {
                            Table[i, j].BackColor = Color.Red;
                        }
                    }
                }
                MessageBox.Show("You win" + ", your time: " + timeClock / 10);

            }
        }

        private void DetectExplosion(int m, int n)
        {
                Cell Temp;
                Temp = new Cell();

                if (m == 0)
                {
                    if (n + 1 <= 9 && Table[m, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n + 1);
                        }
                    }
                    if (n - 1 >= 0 && Table[m, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n - 1);
                        }
                    }
                    if (n - 1 >= 0 && Table[m + 1, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m+1, n - 1);
                        }
                    }
                    if (n + 1 <= 9 && Table[m + 1, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m +1, n + 1);
                        }
                    }
                    if (Table[m + 1, n].Status == CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m +1 , n);
                        }
                    }
                }
                else if (m == 9)
                {
                    if (n + 1 <= 9 && Table[m, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n + 1);
                        }
                    }
                    if (n - 1 >= 0 && Table[m, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n - 1);
                        }
                    }
                    if (n - 1 >= 0 && Table[m - 1, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m - 1 , n - 1);
                        }
                    }
                    if (n + 1 <= 9 && Table[m - 1, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m - 1, n + 1);
                        }
                    }
                    if (Table[m - 1, n].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m -1, n);
                        }
                    }
                }
                else
                {
                    if (n + 1 <= 9 && Table[m, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n + 1);
                        }
                    }
                    if ( n - 1 >= 0 && Table[m, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m, n  -1);
                        }
                    }
                    if (n - 1 >= 0 && Table[m - 1, n - 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m -1 , n - 1);
                        }
                    }
                    if (n + 1 <= 9 && Table[m - 1, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m -1 , n + 1);
                        }
                    }
                    if (Table[m - 1, n].Status == CellStatus.Idle)
                    {
                        Temp = Table[m - 1, n];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m -1 , n);
                        }
                    }
                    if (n - 1 >= 0 && Table[m + 1, n - 1].Status== CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n - 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m +1, n - 1);
                        }
                    }
                    if (n + 1 <= 9 && Table[m + 1, n + 1].Status == CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n + 1];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m +1 , n + 1);
                        }
                    }
                    if (Table[m + 1, n].Status == CellStatus.Idle)
                    {
                        Temp = Table[m + 1, n];
                        Explose(Temp);
                        if (Temp.Value == 0)
                        {
                            DetectExplosion(m + 1, n);
                        }
                    }
                }
        }
        private static void Explose(Cell Temp)
        {
            if (Temp.Status == CellStatus.Idle)
            {
                Temp.Text = Temp.Value.ToString();
                Temp.BackColor = Color.Transparent;
                Temp.open();
                if (Temp.Value == 0)
                {
                    Temp.Text = null;
                }
            }
            
        }
        private void Retry_Click(object sender, EventArgs e)
        {
            Clock.Stop();
            timeClock = 0;
            time.Text = "Time: " + timeClock;
            Clock.Start();
            for (int i = 0; i < 10 ; i++)
            {
                for (int j = 0 ; j < 10; j++)
                {
                    Table[i, j].Enabled = true;
                    Table[i, j].reset();
                    Table[i, j].Text = null;
                    Table[i, j].BackColor = Color.Violet;
                }
            }
        }
        private void New_Click(object sender, EventArgs e)
        {
            Clock.Stop();
            timeClock = 0;
            time.Text = "Time: " + timeClock;
            Clock.Start();

            Random rnd = new Random();
            int m, n;
            int BombCount = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table[i, j].Enabled = true;
                    Table[i, j].Status = CellStatus.Idle;
                    Table[i, j].Value = CellValue.Empty;
                    Table[i, j].Text = null;
                    Table[i, j].BackColor = Color.Violet;
                }
            }
            while (BombCount < 20)
            {
                m = rnd.Next(10);
                n = rnd.Next(10);
                if (Table[m, n].Value != CellValue.Bomb)
                {
                    Table[m, n].Value = CellValue.Bomb;
                    BombCount++;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Table[i, j].Value != CellValue.Bomb)
                    {
                        Table[i, j].Value = CellValue.Empty;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Table[i, j].Value == CellValue.Empty)
                    {
                        if (i == 0)
                        {
                            if (j + 1 <= 9 && Table[i, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i + 1, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j + 1 <= 9 && Table[i + 1, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (Table[i + 1, j].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                        }
                        else if (i == 9)
                        {
                            if (j + 1 <= 9 && Table[i, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i - 1, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j + 1 <= 9 && Table[i - 1, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (Table[i - 1, j].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                        }
                        else
                        {
                            if (j + 1 <= 9 && Table[i, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i - 1, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j + 1 <= 9 && Table[i - 1, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (Table[i - 1, j].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j - 1 >= 0 && Table[i + 1, j - 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (j + 1 <= 9 && Table[i + 1, j + 1].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                            if (Table[i + 1, j].Value == CellValue.Bomb)
                            {
                                count++;
                            }
                        }
                        Table[i, j].Value = (CellValue)count;
                        count = 0;
                    }
                }
            }
            
        }
        private void Clock_Tick(object sender, EventArgs e)
        {
            timeClock++;
            time.Text = "Time: " + timeClock/10;
        }
        
    }
}
