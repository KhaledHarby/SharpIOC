using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpIn.Windows.Test
{
    public partial class Form1 : Form
    {
        ILog ll;
        public Form1(ILog log)
        {
            InitializeComponent();
            ll = log;
            ll.Log("a");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
