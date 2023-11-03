using LinearAlgebra;

namespace VectorDemo
{
    public class Tests
    {
        MathVector mVector1 = new MathVector();
        MathVector mVector2 = new MathVector(2, 3); 
        MathVector mVector3 = new MathVector(4, 6); 
        public void ConstructorTest()
        {
            Console.WriteLine("1. Constructor test: ");
            Console.WriteLine($"\tVector1 was created: {mVector1.ToString()}");
            Console.WriteLine($"\tVector2 was created: {mVector2.ToString()}");
        }
        
        public void IndexatorGetTest()
        {
            Console.WriteLine("\n2. Indexator get test: ");
            try
            {
                Console.WriteLine($"\tVector2[0] = {mVector2[0]}");
                Console.WriteLine($"\tVector2[1] = {mVector2[1]}");
                Console.Write("\tVector1[0] = ");
                Console.WriteLine(mVector1[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void IndexatorSetTest()
        {
            Console.WriteLine("\n3. Indexator set test: ");
            try
            {
                Console.WriteLine($"\tVector2[0] = {mVector2[0]}");
                mVector2[0] = 1;
                Console.WriteLine($"\tVector2[0] = {mVector2[0]}\n");

                Console.WriteLine("\tSet Vector2[-1] to 1");
                mVector1[-1] = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\tError: {e.Message}");
            }
        }

        public void DimensionsTest()
        {
            Console.WriteLine("\n4. Dimensions test: ");
            Console.WriteLine($"\tVector1.Dimensions = {mVector1.Dimensions}");
            Console.WriteLine($"\tVector2.Dimensions = {mVector2.Dimensions}");
        }

        public void LengthTest()
        {
            Console.WriteLine("\n5. Length test: ");
            Console.WriteLine($"\tVector1.Length = {mVector1.Length}");
            Console.WriteLine($"\tVector2.Length = {mVector2.Length}");
        }

        public void SumNumberTest()
        {
            Console.WriteLine("\n6. SumNumber test: ");
            var mVector4 = mVector2.SumNumber(1);
            Console.WriteLine($"\tVector: {mVector2.ToString()} + Number: -1 = Vector: {mVector4}");
                        
            Console.WriteLine("\tBy operator +");
            Console.WriteLine($"\tVector: {mVector2.ToString()} + Number: 3 = Vector: {mVector2 + 3}");
            
            mVector4 = mVector1.SumNumber(3);
            Console.WriteLine($"\tVector: {mVector1.ToString()} + Number: 3 = Vector: {mVector4}");
        }
        
        public void SubNumberTest()
        {
            Console.WriteLine("\n7. SubNumber test: ");
            var mVector4 = mVector2.SubNumber(1);
            Console.WriteLine($"\tVector: {mVector2.ToString()} - Number: 1 = Vector: {mVector4}");
            
            Console.WriteLine("\tBy operator -");
            Console.WriteLine($"\tVector: {mVector2.ToString()} - Number: 3 = Vector: {mVector2 - 3}");
            
            Console.WriteLine($"\tVector: {mVector1.ToString()} - Number: 3 = Vector: {mVector1 - 3}");
        }

        public void MultiplyNumberTest()
        {
            Console.WriteLine("\n8. MultiplyNumber test: ");
            var mVector4 = mVector2.MultiplyNumber(2);
            Console.WriteLine($"\tVector: {mVector2.ToString()} * Number: 2 = Vector: {mVector4}");
            Console.WriteLine("\tBy operator *");
            Console.WriteLine($"\tVector: {mVector2.ToString()} * Number: 2 = {mVector2 * 2}");
            
            mVector4 = mVector2.MultiplyNumber(0);
            Console.WriteLine($"\tVector: {mVector2.ToString()} * Number: 0 = Vector: {mVector4}");
            
            mVector4 = mVector1.MultiplyNumber(0);
            Console.WriteLine($"\tVector: {mVector1.ToString()} * Number: 0 = Vector: {mVector4}");
        }
        
        public void DivideNumberTest()
        {
            Console.WriteLine("\n9. DivideNumber test: ");
            try
            {
                var mVector4 = mVector2.DivideNumber(3);
                Console.WriteLine($"\tVector: {mVector2.ToString()} / Number: 3 = Vector: {mVector4}");
                Console.WriteLine("\tBy operator /");
                Console.WriteLine($"\tVector: {mVector2.ToString()} / Number: 3 = {mVector2 / 3}");

                mVector4 = mVector1.DivideNumber(1);
                Console.WriteLine($"\tVector: {mVector1.ToString()} / Number: 1 = Vector: {mVector4}");
                
                Console.Write($"\tVector: {mVector2.ToString()} / Number: 0 = ");
                mVector4 = mVector2.DivideNumber(0);
                Console.WriteLine($"Vector: {mVector4}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void SumTest()
        {
            Console.WriteLine("\n10. Sum test: ");
            try
            {
                var vector1 = new MathVector(1, 3, 4);
                var vector2 = new MathVector(-1, 0, 4);
                var vector3 = vector1.Sum(vector2);
                Console.WriteLine($"\tVector: {vector1.ToString()} + Vector: {vector2.ToString()} = Vector: {vector3}");
                Console.WriteLine("\tBy operator +");
                Console.WriteLine($"\tVector: {vector1.ToString()} + Vector: {vector2.ToString()} = {vector1 + vector2}");
                
                var vector4 = new MathVector();
                Console.WriteLine("\tBy operator +");
                Console.Write($"\tVector: {vector1.ToString()} + Vector: {vector4.ToString()} = ");
                vector3 = vector1 + vector4;
                Console.WriteLine(vector3);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void SubTest()
        {
            Console.WriteLine("\n10. Sub test: ");
            try
            {
                var vector1 = new MathVector(1, 3, 4);
                var vector2 = new MathVector(-1, 0, 4);
                var vector3 = vector1.Sub(vector2);
                Console.WriteLine($"\tVector: {vector1.ToString()} - Vector: {vector2.ToString()} = Vector: {vector3}");
                Console.WriteLine("\tBy operator -");
                Console.WriteLine($"\tVector: {vector1.ToString()} - Vector: {vector2.ToString()} = {vector1 - vector2}");

                
                IMathVector vector4 = new MathVector();
                Console.Write($"\tVector: {vector1.ToString()} - Vector: {vector4.ToString()} = ");
                vector3 = vector1.Sub(vector4);
                Console.WriteLine(vector3);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void MultiplyTest()
        {
            Console.WriteLine("\n12. Multiply test: ");
            try
            {
                var vector1 = new MathVector(1, 3, 4);
                var vector2 = new MathVector(-1, 0, 4);
                var vector3 = vector1.Multiply(vector2);
                Console.WriteLine($"\tVector: {vector1.ToString()} * Vector: {vector2.ToString()} = Vector: {vector3}");
                Console.WriteLine("\tBy operator *");
                Console.WriteLine($"\tVector: {vector1.ToString()} * Vector: {vector2.ToString()} = {vector1 * vector2}");

                
                IMathVector vector4 = new MathVector(-1, 0);
                Console.Write($"\tVector: {vector1.ToString()} * Vector: {vector4.ToString()} = ");
                vector3 = vector1.Multiply(vector4);
                Console.WriteLine(vector3);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void DivideTest()
        {
            Console.WriteLine("\n13. Divide test: ");
            try
            {
                var vector1 = new MathVector(1, 3, 4, 5);
                var vector2 = new MathVector(-1, 2, 2, 5);
                var vector3 = vector1.Divide(vector2);
                Console.WriteLine($"\tVector: {vector1.ToString()} / Vector: {vector2.ToString()} = Vector: {vector3}");
                Console.WriteLine("\tBy operator /");
                Console.WriteLine($"\tVector: {vector1.ToString()} / Vector: {vector2.ToString()} = {vector1 / vector2}");

                
                IMathVector vector4 = new MathVector(-1, 2, 0, 3);
                Console.Write($"\tVector: {vector1.ToString()} / Vector: {vector4.ToString()} = ");
                vector3 = vector1.Divide(vector4);
                Console.WriteLine(vector3);
                
                // IMathVector vector4 = new MathVector(-1, 0);
                // Console.Write($"\tVector: {vector1.ToString()} / Vector: {vector4.ToString()} = ");
                // vector3 = vector1.Divide(vector4);
                // Console.WriteLine(vector3);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void ScalarMultiplyTest()
        {
            Console.WriteLine("\n14. ScalarMultiply test: ");
            try
            {
                var vector1 = new MathVector(1, 3, 4);
                var vector2 = new MathVector(-1, 0, 4);
                Console.WriteLine($"\tVector: {vector1.ToString()} % Vector: {vector2.ToString()} = {vector1.ScalarMultiply(vector2)}");
                Console.WriteLine("\tBy operator %");
                Console.WriteLine($"\tVector: {vector1.ToString()} % Vector: {vector2.ToString()} = {vector1 % vector2}");

                IMathVector vector4 = new MathVector(-1, 0);
                Console.Write($"\tVector: {vector1.ToString()} * Vector: {vector4.ToString()} = ");
                double result = vector1.ScalarMultiply(vector4);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        
        public void CalcDistanceTest()
        {
            Console.WriteLine("\n15. CalcDistance test: ");
            try
            {
                IMathVector vector1 = new MathVector(1, 3, 4);
                IMathVector vector2 = new MathVector(-1, 0, 4);
                Console.WriteLine($"\tD(Vector: {vector1.ToString()}, Vector: {vector2.ToString()}) = {vector1.CalcDistance(vector2)}");
                
                IMathVector vector4 = new MathVector(-1, 0);
                Console.Write($"\tD(Vector: {vector1.ToString()}, Vector: {vector4.ToString()}) = ");
                double result = vector1.CalcDistance(vector4);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}