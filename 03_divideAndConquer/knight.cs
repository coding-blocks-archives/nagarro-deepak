using System;
namespace nagarro_deepak{
    public class knight
    {
        static bool canPlace(int[,] board, int r, int c){
            return (r >= 0 && r < board.GetLength(0)) &&
                   (c >= 0 && c < board.GetLength(1)) &&
                   board[r,c] == 0;
        }

        static bool solveKnightMoves(int[,] board, int r, int c, int moveNo){
            if (moveNo >= 64){
                return true;
            }

            // int[] rowDir = {+2, +1, -1, -2, -2, -1, +1, +2};
            // int[] colDir = {+1, +2, +2, +1, -1, -2, -2, -1};

            int[] rowDir = {-1, -2, -2, -1, +1, +2, +2 ,+1};
            int[] colDir = {+2, +1, -1, -2, -2, -1 , +1, +2};

            // int[] rowDir = {-1, -2, -2, -1, +1, +2, +2, +1};
            // int[] colDir = {-2, -1, +1, +2, +2, +1, -1, -2};
            
            for(int dir = 0; dir < 8; ++dir){
                int nextCellRow = r + rowDir[dir];
                int nextCellCol = c + colDir[dir];
                if(canPlace(board, nextCellRow, nextCellCol)){
                    board[nextCellRow, nextCellCol] = moveNo;
                    bool success = solveKnightMoves(board, nextCellRow, nextCellCol, moveNo + 1);
                    if (success){
                        return true;
                    }
                    board[nextCellRow, nextCellCol] = 0;
                }
            }
            return false;
        }

        static void printBoard(int[,] board){
            for(int i = 0; i < board.GetLength(0); ++i){
                for(int j = 0; j < board.GetLength(1); ++j){
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void main2(){
            int DIM = 8;
            int[,] board = new int[DIM,DIM];
            board[0,0] = -1;
            bool success = solveKnightMoves(board, 0, 0, 1);
            if (success){
                printBoard(board);
            }else{
                Console.WriteLine("Try some other dimension");
            }
        }
    }
}