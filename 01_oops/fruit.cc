// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

class Fruit {
private:
    int origin;
    int color;
    // int* price;
public:
    Fruit(int c, int o) {
        origin = o;
        color = c;
        // price = new int;
        // (*price) = 10;
    }

    Fruit(int o) {
        origin = o;
        // color = c;
    }

    void setColor(int c) {
        color = c;
    }

    int getColor() {
        return this->color;
    }

};


/*void setFruit(Fruit& F, int col, int ori){
    F.color = col;
    F.origin = ori;
}*/



class Mango : public Fruit {
    int type;
public:
    Mango(int c, int t, int o): Fruit(c, o) {
        // origin = o;
        // Fruit(1, 2);
        type = t;
    }

    int getType() {
        return type;
    }
};


int main() {
    // Fruit f1(7, 123);
    // int ans = f1.getColor();
    // cout << ans;

    Mango M(1, 2, 3);
    cout << sizeof(Mango);
}