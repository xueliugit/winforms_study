using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multithread01
{
    public partial class Form1 : Form
    {
        SynchronizationContext SyncContext = null;
        Thread thread1 = null;
        public Form1()
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;
        }

        private void change(object str)
        {
            this.label1.Text = str.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ParameterizedThreadStart(change2));
            thread1.IsBackground = true;
            thread1.Start("hello");
        }

        private void change2(object str)
        {
            SyncContext.Post(change, str);
        }
    }
}
