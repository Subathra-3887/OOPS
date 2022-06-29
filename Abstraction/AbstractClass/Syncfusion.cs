using System;
namespace AbstractClass
{
    public class Syncfusion:AbstractBase
    {
        public override string Name { get{return name;} set{name = value;} } //Abstract property definition
        public override void Salary(int days) //Abstract method definition
        {
            Display();
            Amount = (double)days*500;
            Console.WriteLine(Amount);
        }
        
    }
}