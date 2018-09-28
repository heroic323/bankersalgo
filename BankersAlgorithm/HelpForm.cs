using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace BankersAlgorithm
{
    public partial class HelpForm : MetroForm
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            tileChecking.BackColor = MetroFramework.MetroColors.Yellow;
            tileAllocating.BackColor = MetroFramework.MetroColors.Green;
            tileAcquiring.BackColor = MetroFramework.MetroColors.Blue;
            tileRejecting.BackColor = MetroFramework.MetroColors.Red;
            tileEnd.BackColor = MetroFramework.MetroColors.Lime;
        }
    }
}
