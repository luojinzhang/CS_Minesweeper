using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silent_Hill
{
    public enum CellStatus
    {
        Idle,
        Flag,
        Open,
    };
    public enum CellValue
    {
        Empty = -1,
        Bomb = -2,
        n1 = 1, 
        n2 = 2, 
        n3 = 3, 
        n4 = 4, 
        n5 = 5,
        n6 = 6, 
        n7 = 7,
        n8 = 8,
    };
    
    class Program
    {
        static Cell[,] Table = new Cell[10, 10];
        public static void newTable(Cell[,] paramTable)
        {
            Random rnd = new Random();
            int m, n;
            int BombCount = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Table[i, j] = new Cell();
                    Table[i, j].Value = CellValue.Empty;
                    Table[i, j].Status = CellStatus.Idle;
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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    paramTable[i, j] = Table[i, j];
                }
            }
        }
        static void Main(string[] args)
        {
            Cell[,] Table = new Cell[10,10] ;
            newTable(Table);
            Application.Run(new SilentHillGame());
        }

        
    }
}
