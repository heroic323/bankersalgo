#define DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankersAlgorithm.BankersAlgorithmLib
{
    public class Resource
    {
        private const int RESOURCE_RANGE = 3;
        private int[] available;

        [Description("Initialize Size of Resource Matrix 1x3")]
        [DefaultValue(new int[] { 3,3,2})]
        public Resource(int x=3,int y=3,int z=2)
        {
            available = new int[3] { x, y, z };

        }
        public Resource(Resource res)
        {
            available = new int[3] { res[0], res[1], res[2] };
        }
        public void FreeAllocation(Process proc)
        {
            for (int i = 0; i < 3; i++)
                this.available[i] += proc.Allocation[i];
            proc.IsFinished = true;
#if DEBUG
            Console.WriteLine($"PROC NAME: {proc.Process_Name}");
#endif

        }

        public int this[int index]
        {
            get
            {
                if (index <= RESOURCE_RANGE && index >= 0)
                    return available[index];
                else
                {
                    return -1000;
                    throw new IndexOutOfRangeException("INVALID RESOURCE SIZE EXCEPTION");
                }
            }
        }

    }
}
