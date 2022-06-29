namespace OperatorOverloading
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        
        public Box(double length,double breadth,double height)
        {
            Length=length;
            Breadth=breadth;
            Height=height;
        }
        public Box(){ }
        public void CalculateVolume()
        {
            double volume = Length*Breadth*Height;
            Console.WriteLine($"Volume :{volume}");
        }
        public static Box operator +(Box box1,Box box2)
        {
            Box box3 = new Box();
            box3.Length = box1.Length+box2.Length;
            box3.Breadth = box1.Breadth+box1.Breadth;
            box3.Height = box1.Height+box2.Height;
            return box3;
        }
               
    }
}