using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silent_Hill
{
    public class Cell : Button
    {
        CellStatus status;
        Cell[,] Table = new Cell [10, 10];
        public CellStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        CellValue value;

        public CellValue Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Cell ()
        {

        }
        
        public Cell(Cell[,] newCell)
        {
            Random rnd = new Random();
            int m, n;
            int BombCount = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table[i, j] = new Cell();
                    Table[i, j].Status = CellStatus.Idle;
                }
            }
            while (BombCount < 30)
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
            for (int i =0; i< 10; i++)
            {
                for (int j = 0; j < 10; j++ )
                {
                    newCell[i, j] = Table[i, j];
                }
            }
        }
        public void open()
        {
            if (status != CellStatus.Flag)
            { 
                status = CellStatus.Open;
            }
        }
        public void flag()
        {
            if (status != CellStatus.Open)
            {
                status = CellStatus.Flag;
            }
        }
        public void unFlag()
        {
            if(status != CellStatus.Open)
            {
                status = CellStatus.Idle;
            }
        }
        public void reset()
        {
            status = CellStatus.Idle;
        }
    }
}
