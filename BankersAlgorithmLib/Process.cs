using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace BankersAlgorithm.BankersAlgorithmLib
{
    public class Process 
    {
        public static int Process_Count=0;
        private const int RESOURCE_RANGE=3;

        private bool isFinished;
        private string process_name;
        private int []allocation;
        private int[] maximum;
        private int[] need;

        #region PROPERTIES
        public string Process_Name
        {
            get
            {
                return this.process_name;
            }
        }

        public int[] Allocation {
            get
            {
                return this.allocation;
            }
        }

      
        public int[] Maximum
        {
            get
            {
                return maximum;
            }
        }

        public int[] Need
        {
            get
            {
                return need;
            }
        }

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }

            set
            {
                isFinished = value;
            }
        }

        #endregion

        //INIT MATRICES
        [ListBindable(BindableSupport.Yes)]
        [Description("Initialize size of process matrix 1x3")]
        public Process(int[] alloc,int[]max)
        {
            if (alloc.Length == 3 && max.Length==3)
            {
                this.allocation = new int[RESOURCE_RANGE];
                this.maximum = new int[RESOURCE_RANGE];
                this.need = new int[RESOURCE_RANGE];
                for (int i = 0; i < 3; i++)
                {
                    this.allocation[i] = alloc[i];
                    this.maximum[i] = max[i];

                    this.need[i] = this.maximum[i] - this.allocation[i];
                }
                Process_Count += 1;
                process_name = "P" + Process_Count.ToString();
            }
            else
                throw new IndexOutOfRangeException("INVALID PROCESS SIZE EXCEPTION");
        }
        
        public int this[int index]
        {
            get
            {
                if (index <= RESOURCE_RANGE && index >= 0)
                    return need[index];
                else
                {
                    return -1000;
                    throw new IndexOutOfRangeException("INVALID PROCESS SIZE EXCEPTION");
                }
            }
        }

     


    }
}
