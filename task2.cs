using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
     class Program
     {
          static void Main(string[] args)
          {
          }
     }


  public class Node<T>
{
public T Item {get;set;}
public Node<T> Next; {get;set;}

public Node (T item, Node<T> next)
{
     Item = item;
     Next = item.next;

}

public class Polynomial 
{

// A reference to the first node of a singly linked list 
private Node<Term>front;

// Creates the polynomial 
public Polynomial ()
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
            if ((0 >=exponent) && (exponent <= 99))
            {
                Coefficiant = coefficiant;
                Exponent= exponent;
               // SetSigns();
            }
            else
               {
                throw new ArgumentException("Denominator is 0");
               }

}

//Inserts term t into the current polynomial in its proper order, if a term with the same exponent already exisits then the two terms are added together
public void AddTerm (Term t) 
{
\\ We have to code this 
}

//Adds polynomials p and q to yield a new polynomial 
public static Polynomial operator + (Polynomial p, Polynomial q 
{
// We have to code this 
}

// Multiplies polynomials p and q to yeild a new polynomial 
public static Polynomial operator * (Polynomial p, Polynomial q) 
{
// We need to code this
}

// Evaluates the current polynomial at x 
public double Evaluate (double x) 
{
// We need to code this
}

// Prints current polynomial 
public void Print()
{
// We need to code this
}

}



}
