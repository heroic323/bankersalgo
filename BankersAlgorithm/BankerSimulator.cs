#pragma warning disable
#define DEBUG
using BankersAlgorithm.BankersAlgorithmLib;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Security.Permissions;

namespace BankersAlgorithm
{
    public partial class BankerSimulator : MetroForm
    {
        List<Process> proc_cache;
        Banker banker;
        Resource res_cache;
        Thread animationThread;
        bool _showNeedMatrix = false;
        bool threadLock = false;
        public BankerSimulator()
        {
            InitializeComponent();
            banker = new Banker();
            banker.OnStateChanged += Translate;
            banker.SafeSequence.CollectionChanged += SafeSequence_CollectionChanged;
        }

        private void SafeSequence_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
#if DEBUG
            Console.WriteLine($"SS INDEX: {e.NewStartingIndex}");
#endif      
            if(banker.SafeSequence.Count>0)
            txtSafeSequence.Invoke((MethodInvoker)delegate {
                txtSafeSequence.Text += $"{e.NewItems[0].ToString()}  ";
            });  
        }

        #region MULTITHREAD_OPERATIONS
        private void Translate(object sender,ChangedStateArgs args)
        {
            if (threadLock != false)
            {
                string[] processNames = { "P1", "P2", "P3", "P4", "P5" };

                int move=0;
                if (_showNeedMatrix == true)
                    move = 200;

                int[,] dimension = new int[5, 2] { { 452, 72 }, { 452, 72 + 45 }, { 452, 72 + 45 * 2 }, { 452, 72 + 45 * 3 }, { 452, 72 + 45 * 4 } };
                animationTile.Invoke((MethodInvoker)delegate
                {
                    animationTile.Text = banker.STATE.ToString();
                    for (int i = 0; i < 5; i++)
                    {
                        if (args.CurrentProcess.Process_Name == processNames[i])
                        {
                            animationTile.Location = new Point(dimension[i, 0]+move, dimension[i, 1]);
                        }
                    }   

                        switch (banker.STATE)
                        {
                            case BankerState.Checking:
                                {
                                    animationTile.BackColor = MetroFramework.MetroColors.Yellow;
                                    break;
                                }
                            case BankerState.Allocating:
                                {
                                    animationTile.BackColor = MetroFramework.MetroColors.Green;
                                    break;
                                }
                            case BankerState.Acquiring:
                                {
                                    animationTile.BackColor = MetroFramework.MetroColors.Blue;
                                    Invoke((MethodInvoker)delegate
                                    {
                                        txtTotalResourceA.Text = (int.Parse(txtTotalResourceA.Text) + args.CurrentProcess.Allocation[0]).ToString();
                                        txtTotalResourceB.Text = (int.Parse(txtTotalResourceB.Text) + args.CurrentProcess.Allocation[1]).ToString();
                                        txtTotalResourceC.Text = (int.Parse(txtTotalResourceC.Text) + args.CurrentProcess.Allocation[2]).ToString();

                                        switch (args.CurrentProcess.Process_Name)
                                        {
                                            case "P1":
                                                Invoke((MethodInvoker)delegate { pnlP1.BackColor = MetroFramework.MetroColors.Silver; });
                                                break;
                                            case "P2":
                                                Invoke((MethodInvoker)delegate { pnlP2.BackColor = MetroFramework.MetroColors.Silver; });
                                                break;
                                            case "P3":
                                                Invoke((MethodInvoker)delegate { pnlP3.BackColor = MetroFramework.MetroColors.Silver; });
                                                break;
                                            case "P4":
                                                Invoke((MethodInvoker)delegate { pnlP4.BackColor = MetroFramework.MetroColors.Silver; });
                                                break;
                                            case "P5":
                                                Invoke((MethodInvoker)delegate { pnlP5.BackColor = MetroFramework.MetroColors.Silver; });
                                                break;

                                        }

                                    });
                                    break;
                                }
                            case BankerState.Rejecting:
                                {
                                    animationTile.BackColor = MetroFramework.MetroColors.Red;
                                    break;
                                }
                            case BankerState.End:
                                {
                                    animationTile.BackColor = MetroFramework.MetroColors.Lime;
                                    break;
                                }
                        }
                   });
            }
        }

        private void Animate()
        {
            Process.Process_Count = 0;
            ConstructMatrices();
            try
            {
                if (banker.SafeSequence.Count != 0)
                    banker.SafeSequence.Clear();
#if DEBUG
                Console.WriteLine($"RUNNING THREAD: {Thread.CurrentThread.Name}");
#endif

                if (Banker.IsProcessAllocatable(proc_cache, res_cache))
                {

                    while (proc_cache.Any(p => p.IsFinished == false))
                    {
                        Invoke((MethodInvoker)delegate { animationTile.Location = new Point(452,34); });
                        foreach (Process p in proc_cache)
                        {
                            if (p.IsFinished == false)
                            {
                                banker.AllocateResource(res_cache, p, (int.Parse(txtAnimationDelay.Text))*1000 );
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MetroFramework.MetroMessageBox.Show(this, err.Message, "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateThread()
        {
            ThreadStart ths = new ThreadStart(Animate);
            animationThread = new Thread(ths);
            animationThread.Name = "ANIMATION_THREAD";
        
            threadLock = true;
            btnStop.Enabled = true;

            animationThread.Start();
        }
        [SecurityPermission(SecurityAction.Demand,ControlThread =true)]
        private void KillThread()
        {
            if (threadLock == true)
            {
                animationThread.Abort();
                threadLock = false;

                animationTile.Location = new Point(452, 34);
                animationTile.Text = "";
                animationTile.BackColor = MetroFramework.MetroColors.White;
                txtSafeSequence.Text = "";

                txtTotalResourceA.Text = txtTotalResourceB.Text = txtTotalResourceC.Text = "";
                txtP1_Need_A.Text = txtP1_Need_B.Text = txtP1_Need_C.Text = "";
                txtP2_Need_A.Text = txtP2_Need_B.Text = txtP2_Need_C.Text = "";
                txtP3_Need_A.Text = txtP3_Need_B.Text = txtP3_Need_C.Text = "";
                txtP4_Need_A.Text = txtP4_Need_B.Text = txtP4_Need_C.Text = "";
                txtP5_Need_A.Text = txtP5_Need_B.Text = txtP5_Need_C.Text = "";

                pnlP1.BackColor = pnlP2.BackColor = pnlP3.BackColor = pnlP4.BackColor = pnlP5.BackColor = MetroFramework.MetroColors.White;
                btnStop.Enabled = false;
            }
        }
        #endregion

        //PREVENTS NON NUMERIC INPUTS
        #region ERROR_MECHANISM

        private void txtP2_Max_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAvailableResA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void ConstructMatrices()
        {
            proc_cache = new List<Process>();
            res_cache = new Resource(int.Parse(txtAvailableResA.Text), int.Parse(txtAvailableResB.Text), int.Parse(txtAvailableResC.Text));
            Process p1 = new Process(new int[] { int.Parse(txtP1_Alloc_A.Text), int.Parse(txtP1_Alloc_B.Text), int.Parse(txtP1_Alloc_C.Text) },
                new int[] { int.Parse(txtP1_Max_A.Text), int.Parse(txtP1_Max_B.Text), int.Parse(txtP1_Max_C.Text) });



            Process p2 = new Process(new int[] { int.Parse(txtP2_Alloc_A.Text), int.Parse(txtP2_Alloc_B.Text), int.Parse(txtP2_Alloc_C.Text) },
                new int[] { int.Parse(txtP2_Max_A.Text), int.Parse(txtP2_Max_B.Text), int.Parse(txtP2_Max_C.Text) });
       
            Process p3 = new Process(new int[] { int.Parse(txtP3_Alloc_A.Text), int.Parse(txtP3_Alloc_B.Text), int.Parse(txtP3_Alloc_C.Text) },
                new int[] { int.Parse(txtP3_Max_A.Text), int.Parse(txtP3_Max_B.Text), int.Parse(txtP3_Max_C.Text) });

            Process p4 = new Process(new int[] { int.Parse(txtP4_Alloc_A.Text), int.Parse(txtP4_Alloc_B.Text), int.Parse(txtP4_Alloc_C.Text) },
                new int[] { int.Parse(txtP4_Max_A.Text), int.Parse(txtP4_Max_B.Text), int.Parse(txtP4_Max_C.Text) });

            Process p5 = new Process(new int[] { int.Parse(txtP5_Alloc_A.Text), int.Parse(txtP5_Alloc_B.Text), int.Parse(txtP5_Alloc_C.Text) },
                new int[] { int.Parse(txtP5_Max_A.Text), int.Parse(txtP5_Max_B.Text), int.Parse(txtP5_Max_C.Text) });

            proc_cache.AddRange(new Process[] { p1, p2, p3, p4, p5 });

            Invoke((MethodInvoker)delegate {
                txtP1_Need_A.Text = p1[0].ToString(); txtP1_Need_B.Text = p1[1].ToString(); txtP1_Need_C.Text = p1[2].ToString();
                txtP2_Need_A.Text = p2[0].ToString(); txtP2_Need_B.Text = p2[1].ToString(); txtP2_Need_C.Text = p2[2].ToString();
                txtP3_Need_A.Text = p3[0].ToString(); txtP3_Need_B.Text = p3[1].ToString(); txtP3_Need_C.Text = p3[2].ToString();
                txtP4_Need_A.Text = p4[0].ToString(); txtP4_Need_B.Text = p4[1].ToString(); txtP4_Need_C.Text = p4[2].ToString();
                txtP5_Need_A.Text = p5[0].ToString(); txtP5_Need_B.Text = p5[1].ToString(); txtP5_Need_C.Text = p5[2].ToString();
            });
        }

        #region BUTTON_CLICK EVENTS
        //ANIMATION BUTTONS
        #region ANIM_BUTTONS
        private void btnIncreaseAnimationSpeed_Click(object sender, EventArgs e)
        {
            txtAnimationDelay.Text = (int.Parse(txtAnimationDelay.Text) + 1).ToString();
        }

        private void btnDecreaseAnimationSpeed_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtAnimationDelay.Text)>0)
                txtAnimationDelay.Text = (int.Parse(txtAnimationDelay.Text) - 1).ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (threadLock)
            {
                KillThread();
                sprStopDelay.Visible = true;
                System.Windows.Forms.Timer tmrThreadKilling = new System.Windows.Forms.Timer();
                tmrThreadKilling.Interval = 2000;
                tmrThreadKilling.Tick += (s, args) => { sprStopDelay.Visible = false; };
                tmrThreadKilling.Start();
            }


        }
        private void btnSimulate_Click(object sender, EventArgs e)
        {
            if (!threadLock)
            {
                try
                {
                    txtTotalResourceA.Text = txtAvailableResA.Text; txtTotalResourceB.Text = txtAvailableResB.Text; txtTotalResourceC.Text = txtAvailableResC.Text;
                    CreateThread();
                }
                catch(Exception exc)
                {
                    MetroFramework.MetroMessageBox.Show(this, exc.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "ALREADY ON SIMULATION\nPLEASE PRESS THE STOP BUTTON TO RESIMULATE", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        #endregion
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
        #endregion

        private void tglShowNeedMatrix_CheckedChanged(object sender, EventArgs e)
        {
             if(_showNeedMatrix==false)
            {
                _showNeedMatrix = true;
               pnlNeedMatrix.Visible = true;
             }
            else
            {
                _showNeedMatrix = false;
                pnlNeedMatrix.Visible = false;
            }
        }
    }
}
