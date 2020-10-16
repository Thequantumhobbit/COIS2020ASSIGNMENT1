using System;
using System.Collections.Generic;
//using System.Data;
//using System.Array;
//using System.Collections.ilist;
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

            Console.WriteLine("\n");
            Console.WriteLine("Please enter the exponent for the first term in the polynmial");
            int exp = Convert.ToInt32(Console.ReadLine());

            Term Term1 = new Term(coeff, exp);

            Console.WriteLine("\n");
            Console.WriteLine("Please enter the value at which you would like your polynomail evaluated at");
            double y = Convert.ToDouble(Console.ReadLine());


            

            Console.WriteLine("The current term in the polynomial is: " + Term1.ToString());

            
            Console.WriteLine("This term evaluates to: "+Term1.Evaluate(y));

            Term test2 = new Term(-2.2, 2);
            Term test1 = new Term(1.1, 1);
            Term test3 = new Term(3.3, 3);

            

            Polynomial Poly1 = new Polynomial();

            

           Poly1.AddTerm(test2);
           Poly1.AddTerm(test1);
           Poly1.AddTerm(test3);

           


           

            Term test4 = new Term(4.4, 4);

            Poly1.AddTerm(test4);

            

            Poly1.Print();


            Console.WriteLine("\n");
            Console.WriteLine("Please enter the value at which you would like to be evaluate with");
            double z = Convert.ToDouble(Console.ReadLine());



            Console.WriteLine("This term evaluates to: " + Poly1.Evaluate(z));



            Console.WriteLine("\n");
            Console.WriteLine("\n");



            Term addtest1 = new Term(5.5, 5);
            Term addtest2= new Term(6.6, 6);
            Term addtest3 = new Term(1.5, 2);



            Polynomial Poly2 = new Polynomial();



            Poly2.AddTerm(addtest2);
            Poly2.AddTerm(addtest1);
            Poly2.AddTerm(addtest3);

            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Poly2.Print();

            Polynomial Poly3 = new Polynomial();
            Poly3 = Poly1 + Poly2;

            Poly3.Print();

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
        private int Exponent;

        public int GetExpo()
        {
            return Exponent;
        }

        public void SetExpo(int expo)
        {
            Exponent = expo;
        }

        public double GetCoeff()
        {
            return Coefficient;
        }

        public void SetCoeff(double coeff)
        {
            Coefficient = coeff;
        }
        // Creates a term with the given coefficient and exponent
        public Term(double coefficient, int exponent)
        {
            Coefficient = coefficient;
            Exponent = exponent;

            // Put the argument out of range exception below 
            if (Exponent < 0)
            {
                Console.WriteLine("The exponent you entered was negative, it has been changed to 0.");
                Exponent = 0;

            }
            else if (Exponent > 99)
            {
                Console.WriteLine("The exponent you entered was too large, it has been changed to 99.");
                Exponent = 99;

            }

            
            Console.WriteLine("This is the new term you created: "+ Coefficient + "x" + "^" + Exponent);
            



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

           // double y = this.Atx;
            return Coefficient + "x" + "^" + Exponent;
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
       // private int capacity;          // Maximum number of items in a list
        private int count; // Number of items in the list
        private int next = 0;
        private Term[] P;            // Array of items 
                    // Items are stored beginning at position 0

        public Polynomial() // Creates the polynomial array 
        {
           P = new Term[50];
            
            count = 0;


            P[0] = new Term(0.0, 0);
            next++;
            
        }

       

        public int GetCount()
        {
            return count;
        }

        public Term GetIndex(int index)
        {
            return P[index];
        }

        public void Grow(int newsize)
        {
            Array.Resize(ref P, newsize);
        }



        public void AddTerm(Term term)
        {
            /*
            if(next>=P.Length)
            {
                int g = P.Length * 2;
                Grow(g);
            }
            */
            

            P[next] = term;
            next++;
            count++;

            
            int i = count;
            int j = i-1;
            Term current = P[i];
            Term after = P[j];

            

            while (j!=-1)
            {
                
                current = P[i];
                after = P[j];

                if (current.GetExpo() > after.GetExpo())
                {
                    
                    int temp = current.GetExpo();
                    current.SetExpo(after.GetExpo());
                    after.SetExpo(temp);

                    double temp2 = current.GetCoeff();
                    current.SetCoeff(after.GetCoeff());
                    after.SetCoeff(temp2);

                    
                   

                }

                ////////////////////
                
                 if (current.GetExpo() == after.GetExpo())
                {

                    double temp1 = after.GetCoeff();
                    double temp2 = current.GetCoeff();
                    double temp3 = temp1 + temp2;
                    after.SetCoeff(temp3);

                   for (int k = i; k<count-1;k++)
                    {
                        P[k] = P[k + 1];
                       
                    }

                       


                }

                else
                
                //////////////////

                    i--;
                    j--;

                   
                }

                

            

        }


        public static Polynomial operator +(Polynomial p, Polynomial q)
        {
             Polynomial hold=new Polynomial();

            for (int i=0; i<= p.GetCount();i++)
            {
                Term temp = new Term(p.P[i].GetCoeff(), p.P[i].GetExpo());

                hold.AddTerm(temp);
            }

            for (int i = 0; i <= q.GetCount(); i++)
            {
                Term temp = new Term(q.P[i].GetCoeff(), q.P[i].GetExpo());

                hold.AddTerm(temp);
            }

            return hold;
        }



        public double Evaluate(double x)
        {
            double answer=0;


            for (int i = 0; i <= count; i++)
            {

               
                Double termans = Math.Pow(x, P[i].GetExpo()) * P[i].GetCoeff();
                answer += termans;
            }
            



            return answer;
        }


        public void Print()
        {

            for (int i = 0; i <= count; i++)
            {
                if (P[i].GetCoeff() != 0)
                {
                    Console.Write(P[i]);

                    if ((i != count)&& (P[i+1].GetCoeff() != 0))
                    {
                        Console.Write(" + ");
                    }
                }

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
