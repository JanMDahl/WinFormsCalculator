using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = "";
        private string first = "";
        private string second = "";
        private char function = ' ';
        private double result = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void equalsButton_Click(object sender, EventArgs e) => Calculate();

        private void NumberButtonClicked(char c)
        {
            if ((display.Text == "0" && c == '0') || !char.IsDigit(c))
            {
                return;
            }

            display.Text = "";
            input += c;
            display.Text += input;
        }

        private void FunctionButtonClicked(char c)
        {
            function = c;
            first = input;
            input = "";
        }

        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            if (display.Text.StartsWith("-"))
            {
                display.Text = display.Text.Substring(1);
                input = display.Text;
                return;
            }

            display.Text = "-" + display.Text;
            input = display.Text;
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            if (input.Contains(","))
            {
                return;
            }

            display.Text = "";
            input += ",";
            display.Text += input;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            function = ' ';
            input = "";
            first = "";
            second = "";
            result = 0;
            display.Text = "0";
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (display.Text.Length == 1)
            {
                display.Text = "0";
                input = "";
                return;
            }

            display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            input = display.Text;
        }

        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '+':
                    function = '+';
                    first = input;
                    input = "";
                    return;
                case '-':
                    function = '-';
                    first = input;
                    input = "";
                    return;
                case '*':
                    function = '*';
                    first = input;
                    input = "";
                    return;
                case '/':
                    function = '/';
                    first = input;
                    input = "";
                    return;
                case '%':
                    function = '%';
                    first = input;
                    input = "";
                    return;
                case ',':
                    if (input.Contains(","))
                    {
                        return;
                    }

                    display.Text = "";
                    input += ",";
                    display.Text += input;
                    return;
                case '=':
                    Calculate();
                    return;
                case (char)Keys.Enter:
                    Calculate();
                    return;
                case (char)8:
                    backspaceButton_Click(sender, e);
                    return;
                case (char)27:
                    clearButton_Click(sender, e);
                    return;
                default:
                    break;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                return;
            }

            display.Text = "";
            input += e.KeyChar;
            display.Text += input;
        }

        private void Calculate()
        {
            second = input;

            var firstNum = String.IsNullOrEmpty(first) ? 0 : Convert.ToDouble(first);

            var secondNum = Convert.ToDouble(second);

            if (function == '+')
                result = firstNum + secondNum;

            else if (function == '-')
                result = firstNum - secondNum;

            else if (function == '*')
                result = firstNum * secondNum;

            else if (function == '/')
                result = firstNum / secondNum;

            else if (function == '%')
                result = firstNum % secondNum;

            display.Text = input = result.ToString();
        }
    }
}
