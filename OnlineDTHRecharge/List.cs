using System;
namespace OnlineDTHRecharge
{
    public partial class List<T>
    {
        private T[] Array { get; set; }
        private int _count;
        private int _capacity;
        public int Count { get{return _count;}}
        public int Capacity { get {return _capacity;} }
        
        public T this[int i]
        {
            get
            {
                return Array[i];
            }
        }
        public List()
        {
            Array = new T[1];
            _count =0;
            _capacity=1;
        }
        public List(int size)
        {
            _count =0;
            _capacity=size*2;
            Array = new T[_capacity];
        }
        public void AddElement(T a)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            Array[_count]=a;
            _count++;
        }
        public void GrowSize()
        {
            T[] temp = new T [_capacity*2];
            for (int i =0;i<_capacity;i++)
            {
                temp[i]=Array[i];
            }
            Array = temp;
            _capacity=_capacity*2;
        }
    }
}