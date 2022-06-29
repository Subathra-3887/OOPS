namespace TestProject;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Using a = new Using();
        int result= a.Add(10,20) ;
        Assert.AreEqual(30,result);
        double result1 = a.Sub(10.2,5.1);
        Assert.AreEqual(5.1,result1);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Using b= new Using();
        double result = b.Sub(10,2);
        Assert.AreEqual(8,result);
    }
}