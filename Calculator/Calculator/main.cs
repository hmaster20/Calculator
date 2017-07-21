using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class main : Form
    {
        private double accumulator = 0;
        private char lastOperation;
        public main()
        {
            InitializeComponent();

            this.Icon = Calculator.Properties.Resources.calculator;
            this.Size = new Size(Size.Width - panel1.Width, Size.Height);
        }

        private void Operator_Pressed(object sender, EventArgs e)
        {
            // An operator was pressed; perform the last operation and store the new operator.
            char operation = (sender as Button).Text[0];
            if (operation == 'C')
            {
                accumulator = 0;
            }
            else
            {
                double currentValue = double.Parse(Display.Text);
                switch (lastOperation)
                {
                    case '+': accumulator += currentValue; break;
                    case '-': accumulator -= currentValue; break;
                    case '×': accumulator *= currentValue; break;
                    case '÷': accumulator /= currentValue; break;
                    default: accumulator = currentValue; break;
                }
            }

            lastOperation = operation;
            Display.Text = operation == '=' ? accumulator.ToString() : "0";
        }

        private void Number_Pressed(object sender, EventArgs e)
        {
            // Add it to the display.
            string number = (sender as Button).Text;
            Display.Text = Display.Text == "0" ? number : Display.Text + number;
        }


        private void SqrRoot(object sender, EventArgs e)
        {
            double number;
            if (double.TryParse(Display.Text, out number))
            {
                Display.Text = (Math.Sqrt(number)).ToString();
            }
        }

        private void Degree(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (opr1 / 2).ToString();
            }
        }

        private void Sin(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (Math.Sin(opr1 * Math.PI / 180)).ToString();
            }
        }

        private void Cos(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (Math.Cos(opr1 * Math.PI / 180)).ToString();
            }
        }

        private void Tan(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (Math.Tan(opr1 * Math.PI / 180)).ToString();
            }
        }

        private void CoTan(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (1 / Math.Tan(opr1 * Math.PI / 180)).ToString();
            }
        }

        private void lg(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (Math.Log10(opr1)).ToString();
            }
        }

        private void ln(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (Math.Log(opr1)).ToString();
            }
        }

        private void e(object sender, EventArgs e)
        {
            Display.Text = (Math.E).ToString();
        }
        private void pi(object sender, EventArgs e)
        {
            Display.Text = (Math.PI).ToString();
        }





        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

            int size = (checkBox1.Checked) ? (Size.Width + panel1.Width) : (Size.Width - panel1.Width);
            this.Size = new Size(size, Size.Height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
