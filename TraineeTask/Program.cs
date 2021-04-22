using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TraineeTask
{
    //Algoritms Task
    public static class RailFenceCipher
    {
        public static string Encode(string cleartext, int rails)
        {

            var lines = new List<StringBuilder>();
            for (int i = 0; i < rails; i++)
            {
                lines.Add(new StringBuilder());
            }
            int currentLine = 0;
            int direction = 1;

            for (int i = 0; i < cleartext.Length; i++)
            {
                lines[currentLine].Append(cleartext[i]);

                if (currentLine == 0)
                    direction = 1;
                if (currentLine == rails - 1)
                    direction = -1;

                currentLine += direction;

            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rails; i++)
            {
                result.Append(lines[i].ToString());
            }
            return result.ToString();
        }
        public static string Decode(string codetext, int rails)
        {
            var lines = new List<StringBuilder>();

            for (int i = 0; i < rails; i++)
            {
                lines.Add(new StringBuilder());
            }

            int[] lineLenght = Enumerable.Repeat(0, rails).ToArray();

            int currentLine = 0;
            int direction = 1;
            for (int i = 0; i < codetext.Length; i++)
            {
                lineLenght[currentLine]++;
                if (currentLine == 0)
                    direction = 1;
                if (currentLine == rails - 1)
                    direction = -1;

                currentLine += direction;
            }

            int currentChar = 0;
            for (int line = 0; line < rails; line++)
            {
                for (int c = 0; c < lineLenght[line]; c++)
                {
                    lines[line].Append(codetext[currentChar]);
                    currentChar++;
                }
            }


            StringBuilder result = new StringBuilder();
            currentLine = 0;
            direction = 1;

            int[] currentReadLine = Enumerable.Repeat(0, rails).ToArray();
            for (int i = 0; i < codetext.Length; i++)
            {
                result.Append(lines[currentLine][currentReadLine[currentLine]]);
                currentReadLine[currentLine]++;


                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == rails - 1)
                    direction = -1;

                currentLine += direction;
            }
            return result.ToString();
        }




        //OOP Task
        public class Shape : IComparable<Shape>
        {
            public double Area { get; set; }
            public int CompareTo(Shape other)
            {
                return this.Area.CompareTo(other.Area);
            }
        }
        public class Square : Shape
        {
            public Square(double side)
            {
                Area = side * side;
            }
        }
        public class Rectangle : Shape
        {
            public Rectangle(double width, double height)
            {
                Area = width * height;
            }
        }
        public class Triangle : Shape
        {
            public Triangle(double Base, double height)
            {
                Area = (Base * height) / 2;
            }
        }
        public class Circle : Shape
        {
            public Circle(double radius)
            {
                Area = (radius * radius) * Math.PI;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
