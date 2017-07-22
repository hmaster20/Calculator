using Calculator.Properties;
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
        List<Label> lb;

        private double accumulator = 0;
        private char lastOperation;
        public main()
        {
            InitializeComponent();

            this.Icon = Calculator.Properties.Resources.calculator;
            this.Size = new Size(Size.Width - panel1.Width, Size.Height);

            lb = new List<Label>();
            lb.Add(RoundF);
            lb.Add(Round4);
            lb.Add(Round2);
            lb.Add(Round1);
            lb.Add(Round0);
            lb.Add(RoundAdd);

            CustomizedToolTip ToolT = new CustomizedToolTip();
            ToolT.SetToolTip(bSin, " ");
            ToolT.SetToolTip(bCos, " ");
            ToolT.SetToolTip(bTan, " ");
            ToolT.SetToolTip(bCtg, " ");

            ToolT.AutomaticDelay = 500;
            ToolT.AutoPopDelay = 25000;
            ToolT.AutoSize = false;
            ToolT.BorderColor = Color.Black;

            //ToolT.Size = new Size(Resources.sin.Size.Width, Resources.sin.Size.Height);
            bSin.Tag = Resources.sin;
            bCos.Tag = Resources.cos;
            bTan.Tag = Resources.tg;
            bCtg.Tag = Resources.ctg;

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
                string value = (Display.Text.Contains('.')) ? (Display.Text.Replace('.', ',')) : Display.Text;

                double number;
                if (double.TryParse(value, out number))
                //if (double.TryParse(Display.Text, out number))
                {
                    double currentValue = number;
                    switch (lastOperation)
                    {
                        case '+': accumulator += currentValue; break;
                        case '-': accumulator -= currentValue; break;
                        case '×': accumulator *= currentValue; break;
                        case '÷': accumulator /= currentValue; break;
                        default: accumulator = currentValue; break;
                    }

                }

                //double currentValue = double.Parse(Display.Text);
                //switch (lastOperation)
                //{
                //    case '+': accumulator += currentValue; break;
                //    case '-': accumulator -= currentValue; break;
                //    case '×': accumulator *= currentValue; break;
                //    case '÷': accumulator /= currentValue; break;
                //    default: accumulator = currentValue; break;
                //}
            }

            lastOperation = operation;
            //Display.Text = operation == '=' ? accumulator.ToString() : "0";
            //Display.Text = operation == '=' ? Round().ToString().Replace(',', '.') : "0";
            Display.Text = operation == '=' ? Rounding() : "0";
        }


        private string Rounding()
        {
            double count;

            switch (trackBar2.Value)
            {
                case 0: count = RoundUp(); break;
                case 1: count = RoundDown(); break;
                case 2: count = Round(); break;

                default: count = Round(); break;
            }


            return count.ToString().Replace(',', '.');
            //Math.Ceiling
        }


        private double RoundUp()
        {
            double count;
            switch (trackBar1.Value)
            {
                case 0: count = accumulator; break; //F
                case 1: count = Math.Round(accumulator, 4, MidpointRounding.ToEven); break;  //4
                case 2: count = Math.Round(accumulator, 2, MidpointRounding.ToEven); break;  //2
                case 3: count = Math.Round(accumulator, 1, MidpointRounding.ToEven); break;
                case 4: count = Math.Round(accumulator, 0, MidpointRounding.ToEven); break;
                default: count = accumulator; break;
            }
            return count;
        }


        private double RoundDown()
        {
            double count;
            switch (trackBar1.Value)
            {
                case 0: count = accumulator; break; //F
                case 1: count = Math.Round(accumulator, 4, MidpointRounding.AwayFromZero); break;  //4
                case 2: count = Math.Round(accumulator, 2, MidpointRounding.AwayFromZero); break;  //2
                case 3: count = Math.Round(accumulator, 1, MidpointRounding.AwayFromZero); break;
                case 4: count = Math.Round(accumulator, 0, MidpointRounding.AwayFromZero); break;
                default: count = accumulator; break;
            }
            return count;
        }

        private double Round()
        {
            double count;
            switch (trackBar1.Value)
            {
                case 0: count = accumulator; break; //F
                case 1: count = Math.Round(accumulator, 4); break;  //4
                case 2: count = Math.Round(accumulator, 2); break;  //2
                case 3: count = Math.Round(accumulator, 1); break;
                case 4: count = Math.Round(accumulator, 0); break;
                default: count = accumulator; break;
            }
            return count;
        }

        private void Number_Pressed(object sender, EventArgs e)
        {
            // Обработка ввода чисел
            string number = (sender as Button).Text;

            if (number == "." && Display.Text.Contains('.')) return;

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

        private void Fact(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(Display.Text, out count))
            {
                //for (int i = 2; i <= Convert.ToInt32(tb_Calc.Text); i++)

                if (count < 0)
                {
                    MessageBox.Show("неверно указано число");
                    return;
                }

                if (count == 0)
                {
                    Display.Text = "1";
                    return;
                }

                int a = 1;
                for (int i = 2; i <= count; i++)
                {
                    a = a * i;
                }
                Display.Text = a.ToString();
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
            lb.ForEach(x => x.Enabled = false);
            lb[trackBar1.Value].Enabled = true;
        }
    }
}

