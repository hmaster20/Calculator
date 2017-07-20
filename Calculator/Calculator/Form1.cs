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
    public partial class Form1 : Form
    {
        private double accumulator = 0;
        private char lastOperation;
        public Form1()
        {
            InitializeComponent();
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

        private void btnByTwo_Click(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (opr1 / 2).ToString();
            }
        }

        private void btnByFour_Click(object sender, EventArgs e)
        {
            double opr1;
            if (double.TryParse(Display.Text, out opr1))
            {
                Display.Text = (opr1 / 4).ToString();
            }
        }
    }
}
