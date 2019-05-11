using System;

namespace CR
{
    class Item
    {
        public int id;
        public string name;
        public int maxCount;
        public int saleCount;
        public int price;

        public Item(int _id, string _name, int _maxCount, int _saleCount, int _price)
        {
            id = _id;
            name = _name;
            maxCount = _maxCount;
            saleCount = _saleCount;
            price = _price;
        }
    }
}
