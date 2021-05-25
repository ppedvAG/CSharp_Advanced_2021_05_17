﻿using System;

namespace OperatorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Bruch
    {
        public int Zähler { get; set; }
        public int Nenner { get; set; }

        public Bruch (int Zähler, int Nenner)
        {
            this.Zähler = Zähler;
            this.Nenner = Nenner;
        }


        public static bool operator == (Bruch left, Bruch right)
        {
            if (left.Nenner != right.Nenner)
                return false;

            if (left.Zähler != right.Zähler)
                return false;

            return true;
        }
        public static bool operator != (Bruch left, Bruch right)
        {
            if (left.Nenner == right.Nenner)
                return false;

            if (left.Zähler == right.Zähler)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            Bruch bruchToCheck = (Bruch)obj;

            if (this.Nenner != bruchToCheck.Nenner)
                return false;

            if (this.Zähler != bruchToCheck.Zähler)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator >(Bruch left, Bruch right)
        {
            return true;
        }
        public static bool operator <(Bruch left, Bruch right)
        {
            return true;
        }




        public static bool operator >=(Bruch left, Bruch right)
        {
            return true;
        }
        public static bool operator <=(Bruch left, Bruch right)
        {
            return true;
        }


        public static Bruch operator *(Bruch left, int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }

        public static Bruch operator *(Bruch left, Bruch right)
        {
            return new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);
        }

    }
}
