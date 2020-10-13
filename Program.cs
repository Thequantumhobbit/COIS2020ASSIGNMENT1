using System;
using System.Collections.Generic;
using System.Data;
using Task_2;

namespace COIS2020Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

         

            Console.WriteLine("Please enter the coefficent for the first term in the polynomial");
            double coeff = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the exponent for the first term in the polynmial");
           int exp =Convert.ToInt32( Console.ReadLine());

            Term Term1 = new Term(coeff, exp);
           

            Console.WriteLine("Please enter the value at which you would like your polynomail evaluated at");
            double y = Convert.ToDouble(Console.ReadLine());

           Console.WriteLine( Term1.Evaluate(y));

            Console.WriteLine("The current term in the polynomial is" + Term1.ToString());




         


            



        }
    }
}


namespace Task_2
{

    public interface IComparable                  // Standard interface
    {
        int CompareTo(Object obj);               // Implicitly public and virtual
    }
    public class Term  // The term class implements the Icompareable interface to be used in the CompareTo method 
    {
        private double Coefficient { get; set; }
        private double Atx;
        private int Exponent { get; set; }


        // Creates a term with the given coefficient and exponent
        public Term(double coefficient, int exponent)
        {
            Coefficient = coefficient;
            Exponent = exponent;

            // Put the argument out of range exception below 
             if (Exponent <0)
             {
                throw new ArgumentOutOfRangeException("The expoenent entered was negative");

             }
            if (Exponent > 99)
            {
                throw new ArgumentOutOfRangeException("The expoenent entered was to large");

            }
            else
            {

                Console.WriteLine("This is what has made it to the class Term");
                Console.WriteLine(Coefficient);
                Console.WriteLine(Exponent);
            }

        }
        public double Evaluate(double x)  //Evaluates the current term at x which is a user inputted value sent down from the main program
        {
            Atx = x;

            Double value = (Math.Pow(Atx, Exponent) * Coefficient); // calculate the polynomial evaluated at the value x, use the Math method to do the exponenet operation

            return value; //  return the value that is calculate back to main so it can be displayed for the user

        }

       /* public int CompareTo(Object obj) // Returns -1,0, or 1 if the exponent of the current term is less than, equal to, or greater than the exponent of obj
        {


        }
        */

        public override string ToString()
        {

            return Coefficient + "x^" + Exponent;

        }
    }
}


/*
public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next; {get;set;}

    public Node(T item, Node<T> next)
    {
        Item = item;
        Next = item.next;

    }

    public class Polynomial
    {

        // A reference to the first node of a singly linked list 
        private Node<Term> front;

        // Creates the polynomial 
        public Polynomial()
        {
            public Polynomial()                     // Zero parameters
            {
                Poly(0, 1);
            }

            public Polynomial(double coefficient)              // One parameter
            {
                Poly(coefficient, 1);
            }

            public Polynomial (double coefficiant, int exponent)    // Denominator
            {
                Poly(coefficiant, exponent);
            }


            private void Poly(double coefficiant, int exponent)
            {
                if ((0 >= exponent) && (exponent <= 99))
                {
                    Coefficiant = coefficiant;
                    Exponent = exponent;
                    // SetSigns();
                }
                else
                {
                    throw new ArgumentException("Denominator is 0");
                }

            }

            //Inserts term t into the current polynomial in its proper order, if a term with the same exponent already exisits then the two terms are added together
            public void AddTerm(Term t)
            {
\\ We have to code this
            }

//Adds polynomials p and q to yield a new polynomial 
        public static Polynomial operator +(Polynomial p, Polynomial q 
{
// We have to code this 
}
    /*
    // Multiplies polynomials p and q to yeild a new polynomial 
    public static Polynomial operator *(Polynomial p, Polynomial q)
    {
        // We need to code this
    }

    // Evaluates the current polynomial at x 
    public double Evaluate(double x)
    {
        // We need to code this
    }

    // Prints current polynomial 
    public void Print()
    {
        // We need to code this
    }

    */