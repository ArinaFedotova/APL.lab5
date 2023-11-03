using LinearAlgebra;

namespace VectorDemo;

public class Program
{
    public static void Main()
    {
        Tests test = new Tests();
        test.ConstructorTest();
        test.IndexatorGetTest();
        test.IndexatorSetTest();
        test.DimensionsTest();
        test.LengthTest();
        
        test.SumNumberTest();
        test.SubNumberTest();
        test.MultiplyNumberTest();
        test.DivideNumberTest();
        
        test.SumTest();
        test.SubTest();
        test.MultiplyTest();
        test.DivideTest();
        test.ScalarMultiplyTest();
        test.CalcDistanceTest();
    }
}