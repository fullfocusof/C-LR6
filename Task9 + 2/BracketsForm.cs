using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Task9___2
{
    public partial class BracketsForm : Form
    {
        public BracketsForm()
        {
            InitializeComponent();
        }

        private void buttonExec_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string input = textBoxInput.Text;
            int cntOpen = 0;

            foreach (char c in input )
            {
                if(c == '(')
                {
                    cntOpen++;
                }
                else if(c == ')')
                {
                    cntOpen--;
                }
                else if(cntOpen == 0)
                {
                    sb.Append(c);
                }
            }

            labelResult.Text = sb.Length > 0 ? sb.ToString() : "<пустая строка>";
        }
    }
}
