using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _4_kyu__Validate_Sudoku_with_size__NxN_
{
    class Sudoku
    {

        int[][] sudokuData;

        public Sudoku(int[][] sudokuData)
        {
            this.sudokuData = sudokuData;
        }

        public bool IsValid()
        {
            int int_max_count = 0;
            //row
            try
            {

                int_max_count = sudokuData[0].Length;

                for (int i = 0; i < int_max_count; i++)
                {

                    if (int_max_count != sudokuData[i].Length)
                    {
                        return false;
                    }

                    bool[] row_num_flag = new bool[int_max_count];

                    for (int j = 0; j < int_max_count; j++)
                    {
                        //row
                        if (row_num_flag[sudokuData[i][j] - 1] == true)
                        {
                            return false;
                        }
                        else
                        {
                            row_num_flag[sudokuData[i][j] - 1] = true;
                        }
                    }
                }
                //column
                for (int i = 0; i < int_max_count; i++)
                {

                    bool[] col_num_flag = new bool[int_max_count];

                    for (int j = 0; j < int_max_count; j++)
                    {

                        if (col_num_flag[sudokuData[j][i] - 1] == true)
                        {
                            return false;
                        }
                        else
                        {
                            col_num_flag[sudokuData[j][i] - 1] = true;
                        }

                    }
                }
                //N X N
                int i_little_squares = (int)Math.Sqrt(int_max_count);

                for (int i = 0; i < int_max_count; i += i_little_squares)
                {
                    int i_row_bound = i + i_little_squares;
                    int i_col_bound = i + i_little_squares;

                    bool[] nn_num_flag = new bool[int_max_count];

                    for (int i_row = i; i_row < i_row_bound; i_row++)
                    {
                        for (int i_col = i; i_col < i_col_bound; i_col++)
                        {
                            if (nn_num_flag[sudokuData[i_row][i_col] - 1] == true)
                            {
                                return false;
                            }
                            else
                            {
                                nn_num_flag[sudokuData[i_row][i_col] - 1] = true;
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


    class Program
    {

        static void Main()
        {
            var goodSudoku2 = new Sudoku(
            new int[][] {
      new int[] {1,4, 2,3},
      new int[] {3,2, 4,1},

      new int[] {4,1, 3,2},
      new int[] {2,3, 1,4}
    });

            goodSudoku2.IsValid();
        }
    }
}

