using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task10
{
    public partial class StarStringForm : Form
    {
        public StarStringForm()
        {
            InitializeComponent();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sbInput = new StringBuilder(textBoxInput.Text);
            char prevC = sbInput.Length > 0 ? sbInput[0] : ' ';
            int ID = 0;

            foreach (char c in textBoxInput.Text)
            {
                if(prevC != c)
                {
                    sbInput.Insert(ID, '*');
                    ID += 2;
                }
                else
                {
                    ID++;
                }
                prevC = c;
            }

            labelResult.Text = sbInput.ToString();
            labelResult.Location = new Point(ClientSize.Width / 2 - labelResult.Width / 2, labelResult.Location.Y);

        }

        private void StarStringForm_Load(object sender, EventArgs e)
        {

        }
    }
}
