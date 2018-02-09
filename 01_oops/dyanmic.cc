// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

int* foo(){
    int x = 10;
    cout << "x " << x << endl;
    cout << "addOfx" << &x << endl;
    return &x;
}

int main(){
    int* y = foo();
    cout << "y: "<< y << endl;
    cout << "value@y" << *y << endl;   
}