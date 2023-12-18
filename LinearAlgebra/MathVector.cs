using System.Collections;

namespace LinearAlgebra
{
    //Имплементация - реализация всех методов, описанных в интерфейсе
    public class MathVector : IMathVector
    {
        private double[] _mVector;
        //Иммутабельность - объект, который не может быть изменен после создания
        public MathVector(params double[] mVector)
        {
            _mVector = mVector;
        }

        /// <summary>
        /// Индексатор для доступа к элементам вектора. Нумерация с нуля.
        /// </summary>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i > Dimensions)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                return _mVector[i];
            }
            set
            {
                if (i < 0 || i > Dimensions)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                _mVector[i] = value;
            }
        }

        /// <summary>
        /// Получить размерность вектора (количество координат).
        /// </summary>
        public int Dimensions => _mVector.Length;

        /// <summary>Рассчитать длину (модуль) вектора.</summary>
        public double Length
        {
            get
            {
                double sum = _mVector.Sum(t => t * t);
                return Math.Sqrt(sum);
            }
        }

        /// <summary>Покомпонентное сложение с числом.</summary>
        public IMathVector SumNumber(double number)
        {
            double[] newVector = new double[Dimensions];
            //_mVector[0] = 5;
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] + number;
            }

            return new MathVector(newVector);
        }

        /// <summary>Покомпонентное вычитание с числом.</summary>
        public IMathVector SubNumber(double number)
        {
            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] - number;
            }

            return new MathVector(newVector);
        }

        /// <summary>Покомпонентное умножение на число.</summary>
        public IMathVector MultiplyNumber(double number)
        {
            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] * number;
            }

            return new MathVector(newVector);
        }

        /// <summary>Покомпонентное деление на число.</summary>
        public IMathVector DivideNumber(double number)
        {
            if (number == 0)
            {
                throw new InvalidOperationException("Can not divide by zero");
            }

            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] / number;
            }

            return new MathVector(newVector);
        }

        /// <summary>Сложение с другим вектором.</summary>
        public IMathVector Sum(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] + vector[i];
            }

            return new MathVector(newVector);
        }

        /// <summary>Вычитание с другим вектором.</summary>
        public IMathVector Sub(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] - vector[i];
            }

            return new MathVector(newVector);
        }

        /// <summary>Покомпонентное умножение с другим вектором.</summary>
        public IMathVector Multiply(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                newVector[i] = _mVector[i] * vector[i];
            }

            return new MathVector(newVector);
        }

        /// <summary>Покомпонентное деление с другим вектором.</summary>
        public IMathVector Divide(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double[] newVector = new double[Dimensions];
            for (int i = 0; i < Dimensions; i++)
            {
                if (vector[i] == 0)
                {
                    throw new InvalidOperationException("Can not divide by zero");
                }

                newVector[i] = _mVector[i] / vector[i];
            }

            return new MathVector(newVector);
        }

        /// <summary>Скалярное умножение на другой вектор.</summary>
        public double ScalarMultiply(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double res = 0;
            for (int i = 0; i < Dimensions; i++)
            {
                res += vector[i] * _mVector[i];
            }

            return res;
        }

        /// <summary>
        /// Вычислить Евклидово расстояние до другого вектора.
        /// </summary>
        public double CalcDistance(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
            {
                throw new ArgumentException("Vectors must have the same number of Dimensions");
            }

            double distance = 0;
            for (int i = 0; i < Dimensions; i++)
            {
                distance += double.Pow(vector[i] - _mVector[i], 2);
            }

            return Math.Sqrt(distance);
        }

        public IEnumerator GetEnumerator()
        {
            return _mVector.GetEnumerator();
        }

        public static IMathVector operator +(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2);
        }

        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        public static IMathVector operator -(MathVector vector1, MathVector vector2)
        {
            return vector1.Sub(vector2);
        }

        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector.SubNumber(number);
        }

        public static IMathVector operator *(MathVector vector1, MathVector vector2)
        {
            return vector1.Multiply(vector2);
        }

        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        public static IMathVector operator /(MathVector vector1, MathVector vector2)
        {
            return vector1.Divide(vector2);
        }

        public static IMathVector operator /(MathVector vector, double number)
        {
            return vector.DivideNumber(number);
        }

        public static double operator %(MathVector vector1, MathVector vector2)
        {
            return vector1.ScalarMultiply(vector2);
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _mVector)}]";
        }

    }
}
