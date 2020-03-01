using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        public int Length {get; private set;}
        private int Start { get; set; }
        private double[] Data { get; set; }

        public Indexer(double[] input, int start, int length)
        {
            // <Input argument check>
            if (input.Length == 0)
            {
                throw new FormatException();
            }
            // </Input argument check>

            // <Start argument check>
            if (start < 0 || start > input.Length)
            {
                throw new ArgumentException();
            }
            else
            {
                Start = start;
            }
            // <Start argument check>

            // <Length argument check>
            if (length > input.Length || start + length > input.Length || length < 0 )
            {
                throw new ArgumentException();
            }
            else
            {
                Length = length;
            }
            // </Length argument check>

            Data = input;
        }
        public double this[int index]
        {
            get {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return Data[index + Start];
                // implement length-check
            }
            set {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                Data[index + Start] = value;
            }
        }
    }
}
