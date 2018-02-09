// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

class Fruit {
private:
    int origin;
protected:
    int color;
public:
    Fruit(int c, int o) {
        origin = o;
        color = c;
    }

    void setColor(int c) {
        color = c;
    }

    int getColor() {
        return this->color;
    }

};

class Mango {
    int type;
public:
    Mango(int c, int t, int o): Fruit(c, o) {
        color = c;
        type = t;
    }

    int getType() {
        return type;
    }
};


int main() {
    // Mango M(1, 2, 3);
    // // M.color = 20;
    // cout << sizeof(Mango);

    
    Fruit* c  = new Mango(1,2,3);
    Mango* g  = new Fruit(1,2)

}