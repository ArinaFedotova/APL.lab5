using System.Collections;
namespace LinearAlgebra;

public interface IMathVector : IEnumerable
{ 
    int Dimensions { get; } 
    double this[int i] { get; set; }
    double Length { get; }
    IMathVector SumNumber(double number);
    IMathVector SubNumber(double number);
    IMathVector MultiplyNumber(double number);
    IMathVector DivideNumber(double number);
    IMathVector Sum(IMathVector vector);
    IMathVector Sub(IMathVector vector);
    IMathVector Multiply(IMathVector vector);
    IMathVector Divide(IMathVector vector);
    double ScalarMultiply(IMathVector vector);
    double CalcDistance(IMathVector vector);
}