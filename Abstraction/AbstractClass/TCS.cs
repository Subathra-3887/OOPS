using  System;
namespace AbstractClass
{
    public class TCS:AbstractBase
    {
        public override string Name { get{return name;} set{name = value;} } //Abstract property definition
        public override void Salary(int days) //Abstract method definition
        {
            Display();
            Amount = (double)days*300; //Calling Abstract Base class's normal method
            Console.WriteLine(Amount);
        }
    }
}