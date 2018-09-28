using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankersAlgorithm.BankersAlgorithmLib
{
    //Main Class That Handles the Resources and Processes
    public enum BankerState
    {
        Checking,
        Allocating,
        Acquiring,
        Rejecting,
        End
    }
    public class ChangedStateArgs : EventArgs
    {
        public Process CurrentProcess { get; set; }
        public ChangedStateArgs(Process process)
        {
            CurrentProcess = process;
        }
    }

    public class Banker
    {
        private static int MAX_RANGE = 3;
        public ObservableCollection<string> SafeSequence
        {
            get;
            private set;
        }  


        private BankerState _state;
        private int _transitionSpeed;
        private Process _currentProcess;
        public BankerState STATE
        {
            get { return _state; }
            set
            {
                _state = value;
                System.Threading.Thread.Sleep(_transitionSpeed);
                if(OnStateChanged!=null)
                    OnStateChanged(this,new ChangedStateArgs(_currentProcess));

            }
        }


        public EventHandler<ChangedStateArgs> OnStateChanged;


        public Banker()
        {
            SafeSequence = new ObservableCollection<string>();
            _transitionSpeed = 0;
        }
        
        public static bool IsProcessSafe(Resource res,Process proc)
        {
            for (int i=0;i<MAX_RANGE;i++)
            {
                if (proc[i] > res[i])
                    return false;
            }
            return true;
        }

        //RECHECK ARGUMENTS
        public void AllocateResource(Resource res, Process proc)
        {      
            if (IsProcessSafe(res, proc))
            {
                if (proc.IsFinished == false)
                {
                    res.FreeAllocation(proc);
            
                }
            }
        }

        public void AllocateResource(Resource res, Process proc,int transitionSpeed)
        {
            _currentProcess = proc;
            _transitionSpeed = transitionSpeed;
            STATE = BankerState.Checking;
            if (IsProcessSafe(res, proc))
            {
                if (proc.IsFinished == false)
                {
                    STATE = BankerState.Allocating;

                    res.FreeAllocation(proc);
                    STATE = BankerState.Acquiring;
                    SafeSequence.Add(proc.Process_Name);
                    STATE = BankerState.End;
                }
                else
                {
                    STATE = BankerState.Rejecting;
                    STATE = BankerState.End;
                }
            }
            else
            {
                STATE = BankerState.Rejecting;
                STATE = BankerState.End;
            }

            _transitionSpeed = 0;
        }

        public static bool IsProcessAllocatable(IEnumerable<Process> procList,Resource res)
        {
            int[] currentAllocation = new int[3];

            for (int i = 0; i < 3; i++)
            {
                currentAllocation[i] += res[i];
            }

            foreach (Process proc in procList)
            {
                for(int i=0;i<3;i++)
                { 
                    currentAllocation[i] += proc.Allocation[i];
                }
            }

#if DEBUG
            Console.WriteLine($"{currentAllocation[0]} : {currentAllocation[1]} : {currentAllocation[2]}");
#endif
            foreach (Process proc in procList)
            {
                for(int i=0;i<3;i++)
                {
                    if(proc[i]>currentAllocation[i])
                        throw new ArgumentOutOfRangeException("THE TOTAL NUMBER OF RESOURCES IS INADEQUATE. PLEASE ENSURE THE VALUES ARE WITHIN THE CAPACITY OF THE RESOURCES");
                }
            }
            
            return true;
        }

   
    }
}
