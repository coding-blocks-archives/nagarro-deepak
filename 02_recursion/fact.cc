// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

int fact(int n){
    if (n <= 0){
        return 1;
    }

    int nMinusFact = fact(n - 1);
    return nMinusFact * n;
}

void incPrint(int n){
    if (n <= 0){
        return;
    }

    incPrint(n - 1);
    cout << " " << n;
}

void decPrint(int n){
    if (n <= 0) return;

    cout << n << " ";
    decPrint(n - 1);
}

void printDigit(int digit){
    switch(digit){
        case 0 :
            cout << "zero";
            break;
        case 1 : 
            cout << "one";
            break;
        case 2 : 
            cout << "two";
            break; 
    }
}


void printNum(int num){
    if (num <= 0){
        return;
    }

    int unitDigit = num % 10;
    int remNum = num / 10;
    printNum(remNum);
    cout << " ";    // two zero four|
    printDigit(unitDigit);
}

void bubbleSort(int arr[], int be, int en){
    if (be > en){
        return;
    }

    bubbleSort(arr, be + 1, en);

    if (arr[be] > arr[be + 1] && be + 1 <= en){
        swap(arr[be], arr[be + 1]);
        bubbleSort(arr, be + 1, en);
    }
}

void towerOfHanoi(int n, char src, char dest, char helper){
    if (n == 0){
        return;
    }

    towerOfHanoi(n -1 , src, helper, dest);
    cout << "Disc " << n << " :" << src << "-->" << dest << endl;
    towerOfHanoi(n - 1, helper, dest, src);
}



int main(){
    int n = 07;
    // int n = 7;

    // cin >> n;
    // int ans = fact(n);
    // cout << ans;

    // cin >> n;
    // // incPrint(n);
    // decPrint(n);

    // cin >> n;
    // printNum(n);

    cin >> n;
    towerOfHanoi(n, 'A', 'B', 'C');

    return 0;   
}