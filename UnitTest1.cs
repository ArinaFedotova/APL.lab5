using ArgumentException = System.ArgumentException;

namespace MathVectorTest;
using LinearAlgebra;

public class Tests
{
    private MathVector mVectorEmp  = new MathVector();
    private MathVector mVector = new MathVector(2, 3);
    
    [Test]
    public void Constructor_EmptyVector()
    {
        Assert.That(mVectorEmp.ToString(), Is.EqualTo("[]"));
    }

    [Test]
    public void Constructor_VectorWithParams()
    {
        Assert.That(mVector.ToString(), Is.EqualTo("[2, 3]"));
    }

    [Test]
    public void Indexator_GetExistElem()
    {
        var elem = mVector[0];
        
        Assert.That(elem.ToString(), Is.EqualTo("2"));
    }
    
    [Test]
    public void Indexator_GetNotExistElem_OverTheRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var d = mVector[mVector.Dimensions];
        });
    }
    
    [Test]
    public void Indexator_GetNotExistElem_Negative()
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var d = mVector[-1];
        });
    }

    [Test]
    public void Indexator_SetByCorrectIndex()
    {
        MathVector mVector = new MathVector(2, 3);
        mVector[0] = 0;
        
        Assert.That(mVector[0].ToString(), Is.EqualTo("0"));
    }
    
    [Test]
    public void Indexator_SetByIncorrectIndex_OverTheRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            mVector[mVector.Dimensions] = 1;
        });
    }
    
    [Test]
    public void Indexator_SetByIncorrectIndex_Negative()
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            mVector[-1] = 1;
        });
    }

    [Test]
    public void Dimensions_NotEmptyVector()
    {
        var result = mVector.Dimensions;
        
        Assert.AreEqual(2, result);
    }
    
    [Test]
    public void Dimensions_EmptyVector()
    {
        var result = mVectorEmp.Dimensions;
        
        Assert.AreEqual(0, result);
    }
    
    [Test]
    public void Length_NotEmptyVector()
    {
        double expected_result = Math.Sqrt(2 * 2 + 3 * 3);

        double result = mVector.Length;
        
        Assert.AreEqual(expected_result, result);
    }
    
    [Test]
    public void Length_EmptyVector()
    {
        var result = mVectorEmp.Length;
        
        Assert.AreEqual(0, result);
    }

    [Test]
    public void SumNumber_EmptyVectorPlusNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector.SumNumber(2);
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void SumNumber_VectorPlusZero()
    {
        MathVector mVector = new MathVector(1, 2);

        var result = mVector.SumNumber(0);
        
        Assert.AreEqual(mVector, result);

    }
    
    [Test]
    public void SumNumber_VectorPlusNegNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(0, 1);

        var result = mVector.SumNumber(-1);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void SumNumber_VectorPlusNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(3, 4);

        var result = mVector.SumNumber(2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void SubNumber_EmptyVectorMinusNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector.SubNumber(2);
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void SubNumber_VectorMinusZero()
    {
        MathVector mVector = new MathVector(1, 2);

        var result = mVector.SubNumber(0);
        
        Assert.AreEqual(mVector, result);

    }
    
    [Test]
    public void SubNumber_VectorMinusNegNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(2, 3);

        var result = mVector.SubNumber(-1);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void SubNumber_VectorMinusNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(-1, 0);

        var result = mVector.SubNumber(2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void MultiplyNumber_EmptyVectorMultiplyNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector.MultiplyNumber(2);
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void MultiplyNumber_VectorMultiplyZero()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(0, 0);

        var result = mVector.MultiplyNumber(0);
        
        Assert.AreEqual(expected_res, result);

    }
    
    [Test]
    public void MultiplyNumber_VectorMultiplyNegNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(-1, -2);

        var result = mVector.MultiplyNumber(-1);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void MultiplyNumber_VectorMultiplyNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(2, 4);

        var result = mVector.MultiplyNumber(2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void DivideNumber_EmptyVectorDivideNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector.DivideNumber(2);
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void DivideNumber_VectorDivideZero()
    {
        MathVector mVector = new MathVector(1, 2);
        
        Assert.Throws<InvalidOperationException>(() => mVector.DivideNumber(0));

    }
    
    [Test]
    public void DivideNumber_VectorDivideNegNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(-1, -2);

        var result = mVector.DivideNumber(-1);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void DivideNumber_VectorDivideNum()
    {
        MathVector mVector = new MathVector(14, 12);
        MathVector expected_res = new MathVector(7, 6);

        var result = mVector.DivideNumber(2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorSum_EmptyVectorPlusNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector + 2;
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void OperatorSum_VectorPlusZero()
    {
        MathVector mVector = new MathVector(1, 2);

        var result = mVector + 0;
        
        Assert.AreEqual(mVector, result);

    }
    
    [Test]
    public void OperatorSum_VectorPlusNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(3, 4);

        var result = mVector + 2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorSub_EmptyVectorMinusNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector - 2;
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void OperatorSub_VectorMinusZero()
    {
        MathVector mVector = new MathVector(1, 2);

        var result = mVector - 0;
        
        Assert.AreEqual(mVector, result);

    }
    
    [Test]
    public void OperatorSub_VectorMinusNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(-1, 0);

        var result = mVector - 2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorMult_EmptyVectorMultiplyNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector * 2;
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void OperatorMult_VectorMultiplyZero()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(0, 0);

        var result = mVector * 0;
        
        Assert.AreEqual(expected_res, result);

    }
    
    [Test]
    public void OperatorMult_VectorMultiplyNum()
    {
        MathVector mVector = new MathVector(1, 2);
        MathVector expected_res = new MathVector(2, 4);

        var result = mVector * 2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorDiv_EmptyVectorDivideNum()
    {
        MathVector mVector = new MathVector();

        var result = mVector / 2;
        
        Assert.AreEqual(mVector, result);
    }
    
    [Test]
    public void OperatorDiv_VectorDivideZero()
    {
        MathVector mVector = new MathVector(1, 2);
        
        Assert.Throws<InvalidOperationException>(() =>
        {
            var res = (mVector / 0);
        });

    }
    
    [Test]
    public void OperatorDiv_VectorDivideNum()
    {
        MathVector mVector = new MathVector(14, 12);
        MathVector expected_res = new MathVector(7, 6);

        var result = mVector / 2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void Sum_VectorPlusVectorWithDiffDemension()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector();

        Assert.Throws<ArgumentException>(() =>
        {
            mVector1.Sum(mVector2);
        });
    }
    
    [Test]
    public void Sum_VectorPlusVector()
    {
        MathVector mVector1 = new MathVector(3, 10);
        MathVector mVector2 = new MathVector(1, 2);
        MathVector expected_res = new MathVector(4, 12);

        var result = mVector1.Sum(mVector2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void Sub_VectorMinusVectorWithDiffDemension()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector();

        Assert.Throws<ArgumentException>(() =>
        {
            mVector1.Sub(mVector2);
        });

    }
    
    [Test]
    public void Sub_VectorMinusVector()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(3, 0);
        MathVector expected_res = new MathVector(-2, 2);

        var result = mVector1.Sub(mVector2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void Multiply_VectorMultiplyVectorWithDiffDemension()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(1, 2, 4);

        Assert.Throws<ArgumentException>(() =>
        {
            mVector1.Multiply(mVector2);
        });
    }
    
    [Test]
    public void Multiply_VectorMultiplyVector()
    {
        MathVector mVector1 = new MathVector(1, 3);
        MathVector mVector2 = new MathVector(4, 2);
        MathVector expected_res = new MathVector(4, 6);

        var result = mVector1.Multiply(mVector2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void Divide_VectorDivideVectorWithDiffDemension()
    {
        MathVector mVector1 = new MathVector(2);
        MathVector mVector2 = new MathVector();

        Assert.Throws<ArgumentException>(() =>
        {
            mVector1.Divide(mVector2);
        });
    }
    
    [Test]
    public void Divide_VectorDivideVectorWithZero()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(1, 0);
        
        Assert.Throws<InvalidOperationException>(() =>
        {
            mVector1.Divide(mVector2);
        });
    }
    
    [Test]
    public void Divide_VectorDivideVectorAllEmpty()
    {
        MathVector mVector1 = new MathVector();
        MathVector mVector2 = new MathVector();
        MathVector expected_res = new MathVector();

        var result = mVector1.Divide(mVector2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void Divide_VectorDivideVector()
    {
        MathVector mVector1 = new MathVector(14, 18);
        MathVector mVector2 = new MathVector(7, 6);
        MathVector expected_res = new MathVector(2, 3);

        var result = mVector1.Divide(mVector2);
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorSum_VectorPlusVectorDiffDemension()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(1, 2, 3);

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1 + mVector2;
        });

    }
    
    [Test]
    public void OperatorSum_VectorPlusVector()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(2, 1);
        MathVector expected_res = new MathVector(3, 3);

        var result = mVector1 + mVector2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorSub_VectorMinusVectorDiffDemension()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(1);

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1 - mVector2;
        });

    }
    
    [Test]
    public void OperatorSub_VectorMinusVector()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(0, 3);
        MathVector expected_res = new MathVector(1, -1);

        var result = mVector1 - mVector2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorMult_VectorMultiplyEmptyVector()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector();

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1 * mVector2;
        });
    }
    
    [Test]
    public void OperatorMult_VectorMultiplyVector()
    {
        MathVector mVector1 = new MathVector(1, 2);
        MathVector mVector2 = new MathVector(-1, 3);
        MathVector expected_res = new MathVector(-1, 6);

        var result = mVector1 * mVector2;
        
        Assert.AreEqual(expected_res, result);
    }
    
    [Test]
    public void OperatorDiv_EmptyVectorDivideVector()
    {
        MathVector mVector1 = new MathVector();
        MathVector mVector2 = new MathVector(2, 3);
        
        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1 / mVector2;
        });
    }
    
    [Test]
    public void OperatorDiv_VectorDivideVector()
    {
        MathVector mVector1 = new MathVector(14, 12);
        MathVector mVector2 = new MathVector(2, 2);
        MathVector expected_res = new MathVector(7, 6);

        var result = mVector1 / mVector2;
        
        Assert.AreEqual(expected_res, result);
    }

    [Test]
    public void ScalarMultiply_VectorAndVector()
    {
        var mVector1 = new MathVector(1, 3, 4);
        var mVector2 = new MathVector(-1, 0, 4);
        var expected_result = 15;

        var result = mVector1.ScalarMultiply(mVector2);
        
        Assert.AreEqual(expected_result, result);
    }
    
    [Test]
    public void ScalarMultiply_VectorAndVectorWithDiffDemension()
    {
        var mVector1 = new MathVector(1, 4);
        var mVector2 = new MathVector(-1, 0, 4);

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1.ScalarMultiply(mVector2);
        });
    }
    
    [Test]
    public void OperatorScalar_VectorAndVector()
    {
        var mVector1 = new MathVector(1, 3, 4);
        var mVector2 = new MathVector(-1, 0, 4);
        var expected_result = 15;

        var result = mVector1 % mVector2;
        
        Assert.AreEqual(expected_result, result);
    }
    
    [Test]
    public void OperatorScalar_VectorAndVectorAllEmpty()
    {
        var mVector1 = new MathVector();
        var mVector2 = new MathVector();
        var expected_result = 0;

        var result = mVector1 % mVector2;
        
        Assert.AreEqual(expected_result, result);
    }
    
    [Test]
    public void OperatorScalar_VectorAndVectorWithDiffDemension()
    {
        var mVector1 = new MathVector(1, 4);
        var mVector2 = new MathVector(-1, 0, 4);

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1 % mVector2;
        });
    }

    [Test]
    public void CalcDistance_VectorAndVectorWithDiffDemension()
    {
        var mVector1 = new MathVector(1, 4);
        var mVector2 = new MathVector(-1, 0, 4);

        Assert.Throws<ArgumentException>(() =>
        {
            var result = mVector1.CalcDistance(mVector2);
        });
    }
    
    [Test]
    public void CalcDistance_VectorAndVectorAllEmpty()
    {
        var mVector1 = new MathVector();
        var mVector2 = new MathVector();
        var expected_result = 0;

        var result = mVector1.CalcDistance(mVector2);

        Assert.AreEqual(expected_result, result);
    }
    
    [Test]
    public void CalcDistance_VectorAndVector()
    {
        var mVector1 = new MathVector(1, 4, 3);
        var mVector2 = new MathVector(-1, 0, 4);
        var expected_result = Math.Sqrt(4 + 16 + 1);

        var result = mVector1.CalcDistance(mVector2);

        Assert.AreEqual(expected_result, result);
    }
}