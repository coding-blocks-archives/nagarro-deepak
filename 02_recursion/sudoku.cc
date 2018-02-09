// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
#include <cmath>
using namespace std;
const int DIM = 9;

bool canPlace(int board[][DIM], int r, int c, int n, int curNum){
    for(int x = 0; x < n; ++x){
        if (board[r][x] == curNum) return false;
        if (board[x][c] == curNum) return false;
    }

    int rootn = sqrt(n);
    int subBoardR = r - r % rootn;
    int subBoardC = c - c % rootn;
    for(int i = subBoardR; i < subBoardR + rootn; ++i){
        for(int j = subBoardC; j < subBoardC + rootn; ++j){
            if (board[i][j] == curNum) return false;
        }
    }
    return true;
}


bool sudoku(int board[][DIM], int r, int c, int n){
    if (r >= n){
        return true;
    }

    if (c >= n){
        return sudoku(board, r + 1, 0, n);
    }

    if (board[r][c] != 0){
        // its a fixed cell
        return sudoku(board, r, c + 1, n);
    }

    for(int curNum = 1; curNum <= 9; ++curNum){
        if (canPlace(board, r, c, n, curNum)){
            board[r][c] = curNum;
            bool success = sudoku(board, r, c + 1, n);
            if (success) return true;
            board[r][c] = 0;    // restore the changes
        }
    }
    return false;
}

void printBoard(int board[][DIM], int n){
    for(int i = 0; i < n; ++i){
        for(int j = 0; j < n; ++j){
            cout << board[i][j] << " ";
        }
        cout << endl;
    }
}

int main() {
    int board[DIM][DIM] = {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 6, 0},
        {8, 0, 0, 0, 6, 0, 0, 0, 3},
        {4, 0, 0, 8, 0, 3, 0, 0, 1},
        {7, 0, 0, 0, 2, 0, 0, 0, 6},
        {0, 6, 0, 0, 0, 0, 2, 8, 0},
        {0, 0, 0, 4, 1, 9, 0, 0, 5},
        {0, 0, 0, 0, 8, 0, 0, 7, 9}
    };

    bool successful = sudoku(board, 0, 0, 9);
    if (successful){
        printBoard(board, 9);
    }
    else{
        cout << "this sudoku cant be solved\n";
    }

}