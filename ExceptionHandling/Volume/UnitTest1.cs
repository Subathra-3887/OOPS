namespace Volume;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Using obj = new Using();
        double result = obj.Volume(2,2);
        Assert.AreEqual(25.12,result);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Using obj1 =new Using();
        double result1 = obj1.Volume(2.4,3.2);
        Assert.AreEqual(57.87648,result1);
    }
}