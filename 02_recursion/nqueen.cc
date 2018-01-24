// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

const int DIM = 10;

void setBoard(char board[][DIM], int n) {
    for (int r = 0; r < n; ++r) {
        for (int c = 0; c < n; ++c) {
            board[r][c] = 'X';
        }
    }
}

bool canPlace(char board[][DIM], int n, int r, int c) {
    // check for row and col
    for (int x = 0; x  < n; ++x) {
        if (board[x][c] == 'Q') return false;
        if (board[r][x] == 'Q') return false;
    }

    // along the diagonal
    int rowDir[] = { -1, -1, +1, +1};
    int colDir[] = { -1, +1, +1, -1};

    for(int dir = 0; dir < 4; ++dir){
        for(int dist = 0; dist < n; ++dist){
            int nextRow = r + rowDir[dir] * dist; 
            int nextCol = c + colDir[dir] * dist;
            if (nextRow >= 0 && nextRow < n &&
                nextCol >= 0 && nextCol < n && 
                board[nextRow][nextCol] == 'Q'){
                return false;
            }
        }
    }
    return true;
}

bool nqueen(char board[][DIM], int n, int r) {
    if (r == n) {
        return true;
    }

    for (int c = 0; c < n; ++c) {
        if (canPlace(board, n, r, c)) {
            board[r][c] = 'Q';
            bool success = nqueen(board, n, r + 1);
            if (success) {
                return true;
            }
            board[r][c] = 'X';  // reset the changes made above
        }
    }
    return false;
}

void printBoard(char board[][DIM], int n){
    for(int i = 0; i < n; ++i){
        for(int c = 0; c  < n; ++c){
            cout << board[i][c] << " ";
        }
        cout << endl;
    }
}


int main() {
    char board[DIM][DIM];
    int n;
    cin >> n;  // no of queens
    setBoard(board, n);

    bool isSuccessful = nqueen(board, n, 0);
    if (isSuccessful) {
        printBoard(board, n);
    }
    else {
        cout << "Sorry Man!! Try some other place!!";
    }
}