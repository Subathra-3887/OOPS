using System.Collections;
namespace CollegeStudentUpdated
{
    public partial class List<T>:IEnumerable,IEnumerator
    {
        private int Position = -1;
        public IEnumerator GetEnumerator()
        {
            return(IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(Position<Count-1)
            {
                ++Position;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            Position=-1;
        }
        public object Current
        {
            get
            {
                return Array[Position];
            }
        }
    }
}
