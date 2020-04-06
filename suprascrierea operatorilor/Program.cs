using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suprascrierea_operatorilor
{
    class C //numere complexe
    {
        double r, i;

        public C() // constructor fara parametri 
        {
            r = 0;
            i = 0;
        }
        public C(double parteReala, double parteImaginara) // constructor suprascris pentru a adauga valori predefinite unei variabile de tip compex
        {
            r = parteReala;
            i = parteImaginara;
        }
        public C Suma(C a) // metoda Suma care face adunarea a doua numere complexe
        {
            C toReturn = new C();
            toReturn.r = r + a.r;
            toReturn.i = i + a.i;
            return toReturn;
        }
        public static C Suma(C a, C b) // metoda Suma suprascrisa
        {
            C toReturn = new C();
            toReturn.r = a.r + b.r;
            toReturn.i = a.i + b.i;
            return toReturn;
        }
        public C Produs(C a) // metoda Produs care face inmultirea a doua numere complexe
        {
            C toReturn = new C();
            toReturn.r = r * a.r - i * a.i;
            toReturn.i = r * a.i + i * a.r;
            return toReturn;
        }
        public static C Produs(C a, C b) // metoda Produs suprascrisa
        {
            C toReturn = new C();
            toReturn.r = a.r * b.r - a.i * b.i;
            toReturn.i = a.r * b.i + a.i * b.r;
            return toReturn;
        }
        public static C operator +(C a, C b) // operatorul + suprascris pentru a apela metoda Suma
        {
            return Suma(a, b);
        }
        public static C operator *(C a, C b) // operatorul * suprascris pentru a apela metoda Produs
        {
            return Produs(a, b);
        }
        public static bool operator ==(C a, C b) // operatorul == suprascris pentru a reflecta egalitatea dintre doua numere complexe
        {
            if (a.r == b.r && a.i == b.i)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(C a, C b) // operatorul != suprascris pentru a reflecta inegalitatea
        {
            if (a.r != b.r || a.i != b.i)
            {
                return true;
            }
            return false;
        }

        public override string ToString() // metoda ToString suprascrisa pentru a afisa un numar complex in format string
        {
            string toReturn = "";
            bool ok = false;
            if (r != 0)
            {
                toReturn += r;
                ok = true;
            }
            if (i != 0)
            {
                if (ok)
                {
                    toReturn += " + ";
                }
                toReturn += i + "i";
                ok = true;
            }
            if (!ok)
                return "0";
            return toReturn;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            C a = new C(0, 5);
            C b = new C(5, 0);
            C c = new C(5, 5);
            C d = new C(0, 0);
            Console.WriteLine("a = {0}\nb = {1}\nc = {2}\nd = {3}", a, b, c, d);
            Console.WriteLine();
            Console.WriteLine("a+b = {0}", a + b);
            Console.WriteLine("a*b = {0}", a * b);
            Console.WriteLine("(a+b) == c \"{0}\"", (a + b) == c);
            Console.WriteLine("d != a \"{0}\"", d != a);

            Console.ReadKey();
        }
    }
}
