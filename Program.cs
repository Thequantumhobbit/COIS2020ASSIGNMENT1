using System;
using System.Collections.Generic;
using System.Data;
using TermCreation;
using Task3; 

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

            Polynomial Poly1 = new Polynomial();





         


            



        }
    }
}


namespace TermCreation

{

    public interface IComparable                  // Standard interface
    {
        int CompareTo(Object obj);               // Implicitly public and virtual
    }
    public class Term : IComparable  // The term class implements the Icompareable interface to be used in the CompareTo method 
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

       public int CompareTo(Object obj) // Returns -1,0, or 1 if the exponent of the current term is less than, equal to, or greater than the exponent of obj
        {

            Term f = obj as Term;
            if (Exponent < f.Exponent)
            {
                return -1; 
            }
            if (Exponent == f.Exponent)
            {
                return 0;
            }
            if (Exponent > f.Exponent)
            {
                return 1;
            }
            else
            {
                throw new ArgumentException("Object is not a Term ");
            }



        }
        

        public override string ToString()
        {

            return Coefficient + "x^" + Exponent;

        }
    }
}

namespace Task3
{

    public interface IContainer<T>
    {
        void MakeEmpty();  // Reset an instance to empty
        bool Empty();      // Test if an instance is empty 
        int Size();        // Return the number of items in an instance
    }

    //-----------------------------------------------------------------------------

    public interface IList<T> : IContainer<T>
    {
        void Insert(T item, int p);    // Place item at position p in the list
        void Remove(int p);            // Remove item at position p from the list
        T Retrieve(int p);             // Retrieve item at position p in the list
    }


    public class Polynomial
    {
        private int capacity;          // Maximum number of items in a list
        private int count;             // Number of items in the list
        private Term[] P;            // Array of items 
                                     // Items are stored beginning at position 0

        public Polynomial(int size) // Creates the polynomial array 
        {
            capacity = size;
            count = 0;
            P = new Term[size];

            P[0] = Term(0.0, 0); 
        }

        public Polynomial() : this(100) { } // Creates the array if a size is not given 

        public void AddTerm(Term item, int p) // Add a term to the polynomial 
        {
            int i;
            if (count < capacity && (p >= 0 && p <= count))
            {
                // Shift items from A[p..count-1] up one position

                for (i = count - 1; i >= p; i--)
                {
                    P[i + 1] = P[i];
                }
                P[p] = item;
                count++;
            }
        }
    }

}


/*
public class Node<T>
{
    public T Item { get; set; }
    public Node<T> Next { get; set; }

    public Node(T item, Node<T> next)
    {
        Item = item;
        Next = next;

    }
}


    public class Polynomial
    {

        // A reference to the first node of a singly linked list 
        private Node<Term> front;


    // Creates the polynomial 
    public Polynomial()
    {

    }
    */

    /*
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