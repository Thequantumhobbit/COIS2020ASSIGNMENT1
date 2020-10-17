
using System;
using System.Collections.Generic;
//using System.Data;
//using System.Array;
//using System.Collections.ilist;
using TermCreation;
using Task3;
using NodeClass;

namespace COIS2020Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Please enter the coefficent for the first term in the polynomial");
            double coeff = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the exponent for the first term in the polynmial");
            int exp = Convert.ToInt32(Console.ReadLine());

            Term Term1 = new Term(coeff, exp);


            Console.WriteLine("Please enter the value at which you would like your polynomail evaluated at");
            double y = Convert.ToDouble(Console.ReadLine());




            Console.WriteLine("The current term in the polynomial is: " + Term1.ToString());


            Console.WriteLine("This term evaluates to: " + Term1.Evaluate(y));
         
            Term test2 = new Term(-2.2, 2);
            Term test1 = new Term(1.1, 1);
            Term test3 = new Term(3.3, 3);

/*
            Node<Term> p;

            p = new Node<Term>();

            Polynomial<Term> L1;

            L1 = new Polynomial<Term>();

            L1.AddTerm(test1, 1);

            Console.WriteLine("I will now try to print out L1"); 
            L1.Print(); 

           */
            
            
           

            Polynomial Poly1 = new Polynomial(); // Create a new polynmial from the array version 

            Poly1.AddTerm(test2); // Add three terms to poly 1 
            Poly1.AddTerm(test1);
            Poly1.AddTerm(test3);

            Term test4 = new Term(4.4, 4); // create a 4th term to add to poly 1

            Poly1.AddTerm(test4); // Add the 4th term to poly1 

            Poly1.Print(); // Print out poly1 to show that poly 1 was created and the terms were added to it 

     
            Console.WriteLine("Please enter the value at which you would like to be evaluate with"); //  Get user input for the polynomial to be evaluated at
            double z = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("This term evaluates to: " + Poly1.Evaluate(z)); // Evalute Poly1 at the user inputted value 



            Term addtest1 = new Term(5.5, 5); // create new terms to be added to a new polynomial for the operation override testing 
            Term addtest2 = new Term(6.6, 6);
            Term addtest3 = new Term(1.5, 2);

            Polynomial Poly2 = new Polynomial(); // create the second polynomail 

            Poly2.AddTerm(addtest2); // add terms to poly 2
            Poly2.AddTerm(addtest1);
            Poly2.AddTerm(addtest3);

            


            Poly2.Print(); // print out poly2 
            Console.WriteLine("\n");

            Polynomial Poly3 = new Polynomial(); // create a polynomail to hold the new polynomail that will occur from + operations 
            Poly3 = Poly1 + Poly2; // add poly 1 and 2 and store the new polynomial in poly 3 

            Poly3.Print(); // print out poly 3

            /*

            Console.WriteLine("\n");

            Polynomial Poly4 = new Polynomial();
            Polynomial Poly5 = new Polynomial();
            Polynomial Poly6 = new Polynomial();

            Term multiplytest1 = new Term(5.0, 2);
            Term multiplytest2 = new Term(1.0, 4);
            Term multiplytest3 = new Term(3.0, 3);
            Term multiplytest4 = new Term(3.0, 2);

            Poly5.AddTerm(multiplytest1);
            Poly5.AddTerm(multiplytest2);

            Poly5.Print();
            Console.WriteLine("\n");

            Poly6.AddTerm(multiplytest3);
            Poly6.AddTerm(multiplytest4);

            Poly6.Print();
            Console.WriteLine("\n");

            Poly4 = Poly5 * Poly6;
            Poly4.Print();
            */

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
        private double Coefficient { get; set; } // get, set for coefficient 
        private double Atx; // vairable to evalute a term at 
        private int Exponent; // Expoenent variable to be used in multiple methods 

        public int GetExpo() // get exponent method
        {
            return Exponent;
        }

        public void SetExpo(int expo) // set exponent method 
        {
            Exponent = expo;
        }

        public double GetCoeff() // get coefficient 
        {
            return Coefficient;
        }

        public void SetCoeff(double coeff) // set coefficient 
        {
            Coefficient = coeff;
        }
       
        public Term(double coefficient, int exponent)  // Creates a term with the given coefficient and exponent
        {
            Coefficient = coefficient;
            Exponent = exponent;

            
            if (Exponent < 0)// Argument out of range work around 
            {
                Console.WriteLine("The exponent you entered was negative, it has been changed to 0.");
                Exponent = 0;

            }
            else if (Exponent > 99)
            {
                Console.WriteLine("The exponent you entered was too large, it has been changed to 99.");
                Exponent = 99;

            }


            Console.WriteLine("This is the new term you created: " + Coefficient + "x" + "^" + Exponent);

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
            int j = i - 1;
            Term current = P[i];
            Term after = P[j];



            while (j != -1)
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

                    for (int k = i; k < count - 1; k++)
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
            Polynomial hold = new Polynomial();

            for (int i = 0; i <= p.GetCount(); i++)
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
            double answer = 0;


            for (int i = 0; i <= count; i++)
            {


                Double termans = Math.Pow(x, P[i].GetExpo()) * P[i].GetCoeff();
                answer += termans;
            }




            return answer;
        }


        public static Polynomial operator *(Polynomial p, Polynomial q)
        {
            Polynomial hold2 = new Polynomial();
            double tempC = 0, coeffp = 0, coeffq = 0;
            int tempE = 0, expop = 0, expoq = 0;

            for (int i = 0; i <= p.GetCount() - 1; i++)
            {

                coeffp = p.P[i].GetCoeff();
                expop = p.P[i].GetExpo();


                for (int l = 0; l <= q.GetCount(); l++)
                {
                    Term temp1 = new Term(q.P[l].GetCoeff(), q.P[l].GetExpo());

                    coeffq = q.P[l].GetCoeff();
                    expoq = q.P[l].GetExpo();

                    tempC = coeffp * coeffq;
                    tempE = expop + expoq;
                    Term temp3 = new Term(tempC, tempE);



                    hold2.AddTerm(temp3);
                }

            }

            int m = hold2.GetCount();
            double zero = hold2.P[m].GetCoeff();


            do
            {

                zero = hold2.P[m].GetCoeff();

                if (zero != 0)
                {
                    hold2.P[m].SetCoeff((hold2.P[m].GetCoeff()) / 2);
                }






                m--;
            } while (zero == 0);


            return hold2;

        }


        public void Print()
        {

            for (int i = 0; i <= count; i++)
            {
                if (P[i].GetCoeff() != 0)
                {
                    Console.Write(P[i]);

                    if ((i != count) && (P[i + 1].GetCoeff() != 0))
                    {
                        Console.Write(" + ");
                    }
                }

            }
            Console.WriteLine("");
        }


    }

}

namespace NodeClass // New namespace for all node classes 
{

    public interface IContainer<Term>
    {
        void MakeEmpty();  // Reset an instance to empty
        bool Empty();      // Test if an instance is empty 
        int Size();        // Return the number of items in an instance
    }

    //-----------------------------------------
    public interface IList<Term> : IContainer<Term>
    {
        void Insert(Term item, int p);    // Place item at position p in the list
        void Remove(int p);            // Remove item at position p from the list
        Term Retrieve(int p);             // Retrieve item at position p in the list
    }
    // -------------------------------------------------

    public class Node<Term> 
    {
        public Term Item { get; set; }
        public Node<Term> Next { get; set; }

        public Node ()
        {
            Next = null; 
        }
        public Node(Term item, Node<Term> next)
        {
            Item = item;
            Next = next;
        }
    }
    public class Polynomial<Term> : IList <Term> 
    {
       
        private Node<Term> head; // Reference to the front of the list 
        private int count; // Counts how many items are in the list 
        int p = 0;

    
        public Polynomial() // Creates an empty list 
        {
                MakeEmpty();

        }
        
        public void AddTerm(Term t, int p) //Inserts term t into the current polynomial in its proper order, if a term with the same exponent already exisits then the two terms are added together
        {
            //  Node<item> toAddf = new Node<item>();

            int i;
            Term item = t;
            Node<Term> curr = head;

            if (p >= 0 && p <= count)            
            {
                for (i = 0; i <= p - 1; i++)     
                    curr = curr.Next;

                curr.Next = new Node<Term>(item, curr.Next);
                count++;
            }
            // else do nothing
        }

        public void MakeEmpty() //  used to create the empty linked list
        {
            head = new Node<Term>(default(Term), null);
            count = 0;
        }

        public bool Empty()
        {
            return count == 0;
        }

     
        public int Size()
        {
            return count;
        }

        
        public void Print() // Print out the node linked list
        {
            Node<Term> curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Item + " ");
            }
            Console.WriteLine();
        }
        public void Insert(Term item, int p)
        {
            int i;
            Node<Term> curr = head;

            if (p >= 0 && p <= count)            // Is p correct (in bounds)?
            {
                for (i = 0; i <= p - 1; i++)     // Move to penultimate node
                    curr = curr.Next;

                curr.Next = new Node<Term>(item, curr.Next); 
                count++;
            }
            // else do nothing
        }

        // Time complexity: O(n)
        public void Remove(int p)
        {
            int i;
            Node<Term> curr = head;

            if (p >= 0 && p <= count - 1)         // Is p correct?
            {
                for (i = 0; i <= p - 1; i++)
                    curr = curr.Next;

                curr.Next = curr.Next.Next;       // Reference around the removed item
                count--;
            }
            // else do nothing
        }

        // Time complexity: O(n)
        public Term Retrieve(int p)
        {
            int i;
            Node<Term> curr = head;

            if (p >= 0 && p <= count - 1)
            {
                for (i = 0; i <= p; i++)
                    curr = curr.Next;

                return curr.Item;
            }
            else
                return default(Term);
        }

    }
}

    
