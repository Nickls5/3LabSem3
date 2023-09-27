using System;
using System.Collections.Generic;


namespace Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Vector vec1 = new Vector(5, -13, 23);
            Vector vec2 = new Vector(24, 5, -12);

            Console.WriteLine($"Вектор1: {vec1.x} {vec1.y} {vec1.z}");
            Console.WriteLine($"Вектор2: {vec2.x} {vec2.y} {vec2.z}");
            Vector vec3 = vec1 + vec2;
            Console.WriteLine($"Сумма векторов:  {vec3.x} {vec3.y} {vec3.z} ");
            Vector vec4 = vec1 * 2;
            Console.WriteLine($"Производение Вектора1 * 2:  {vec4.x} {vec4.y} {vec4.z}");
            double prod = vec1 * vec2;
            Console.WriteLine($"Произведение Вектор1 * Вектор2:  {prod}");
            bool Equal = vec1 == vec2;
            Console.WriteLine($"Вектор1 равен Вектору2? - {Equal}");
            bool NotEqual = vec1 != vec2;
            Console.WriteLine($"Вектор1 не равен Вектору2? - {NotEqual}");
            bool Bigger = vec1 < vec2;
            Console.WriteLine($"Вектор1 больше Вектора2? - {Bigger}");
            bool Smaller = vec1 > vec2;
            Console.WriteLine($"Вектор1 больше Вектора2? - {Bigger}");
        }
    }

    public struct Vector
    {
        public double x, y, z;

        public Vector (double x1, double y1, double z1)
        {
            this.x = x1;
            this.y = y1;
            this.z = z1;
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator *(Vector v1, double d)
        {
            return new Vector(v1.x*d, v1.y*d, v1.z*d);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.x*v2.x+v1.y*v2.y+v1.z*v2.z;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z; 
        }

        public static bool operator != (Vector v1, Vector v2)
        {
            return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
        }

        private double LenghtVec ()
        {
            return Math.Sqrt(x*x + y*y + z*z);
        }

        public static bool operator < (Vector v1 , Vector v2)
        {
            return v1.LenghtVec() < v2.LenghtVec();
        }

        public static bool operator > (Vector v1 , Vector v2)
        {
            return v1.LenghtVec() > v2.LenghtVec();
        }
    }
}
