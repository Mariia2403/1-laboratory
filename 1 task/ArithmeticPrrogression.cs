using System;

namespace ConsoleApp2
{
    public class ArithmeticProgression
    {
        private double difference;
        private double firstTerm;
        private int nthTerm;
        private double[] arr;

        public ArithmeticProgression(double difference, double firstTerm, int nthTerm)
        {
            Difference = difference;
            FirstTerm = firstTerm;
            ProgressionTerm = nthTerm;

        }

        public ArithmeticProgression(double difference, double firstTerm, int num, int nthTerm)
        {
            Difference = difference;
            FirstTerm = firstTerm;
            ProgressionTerm = nthTerm;

            if (num <= 0 || num  > nthTerm)
            {
                throw new ArgumentException($"Term number must be greater than zero and less than {nthTerm}.");
            }
            else
            {
                this.arr = new double[nthTerm];

                int digit = 1;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = FirstTerm + Difference * (digit - 1);
                    digit++;
                }
            }
        }
        public double Difference
        {
            get
            {
                return difference;
            }
            set
            {

                difference = value;

            }

        }

        public double FirstTerm
        {
            get
            {
                return firstTerm;
            }
            set
            {
                firstTerm = value;
            }
        }

        public int ProgressionTerm
        {
            get
            {
                return nthTerm;
            }
            set
            {
                if (value > 0)
                {
                    nthTerm = value;
                }
                else
                {
                    throw new ArgumentException("Term number must be greater than zero.");
                }
            }
        }



        public void OutputArr()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public double this[int n]
        {
            get
            {

                if (n >= 0 && n <= arr.Length)
                {
                    return arr[n - 1];
                }
                else
                    throw new ArgumentException($"Term number must be within the range of 0 to {arr.Length} .");

            }
        }

        public double SumProgression(double difference, double firstTerm, int nthTerm)
        {
            double sum = ((2 * firstTerm + difference * (nthTerm - 1)) / 2) * nthTerm;
            return sum;
        }

    }


}


