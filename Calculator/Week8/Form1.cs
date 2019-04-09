using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week8
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool IsOperatorWork = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if(textBox_result.Text == "0")
            {
                textBox_result.Clear();
            }
            IsOperatorWork = false;
            Button button = (Button)sender;
            textBox_result.Text = textBox_result.Text + button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = double.Parse(textBox_result.Text);
            IsOperatorWork = true;
            textBox_result.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_result.Text = (resultValue + double.Parse(textBox_result.Text)).ToString();
                    break;
                case "-":
                    textBox_result.Text = (resultValue - double.Parse(textBox_result.Text)).ToString();
                    break;
                case "*":
                    textBox_result.Text = (resultValue * double.Parse(textBox_result.Text)).ToString();
                    break;
                case "/":
                    if((resultValue / double.Parse(textBox_result.Text)) == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        textBox_result.Text = (resultValue / double.Parse(textBox_result.Text)).ToString();
                    }
                    break;
                case "^":
                    textBox_result.Text = (Math.Pow(resultValue, double.Parse(textBox_result.Text))).ToString();
                    break;
                case "Mod":
                    textBox_result.Text = (resultValue % double.Parse(textBox_result.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void Sqrt(object sender, EventArgs e)
        {
            resultValue = double.Parse(textBox_result.Text);
            textBox_result.Text = Math.Sqrt(resultValue).ToString();
        }

        private void one_click(object sender, EventArgs e)
        {
            resultValue = double.Parse(textBox_result.Text);
            Button button = (Button)sender;
            switch (button.Text)
            {
                case "Cos":
                    textBox_result.Text = (Math.Cos(resultValue * Math.PI / 180)).ToString();
                    break;
                case "Sin":
                    textBox_result.Text = (Math.Sin(resultValue * Math.PI / 180)).ToString();
                    break;
                case "Tan":
                    textBox_result.Text = (Math.Tan(resultValue * Math.PI / 180)).ToString();
                    break;
                case "SQRT":
                    if(resultValue < 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        textBox_result.Text = Math.Sqrt(resultValue).ToString();
                    }
                    break;
                case "^2":
                    textBox_result.Text = (resultValue * resultValue).ToString();
                    break;
                case "Log":
                    if(resultValue < 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        textBox_result.Text = (Math.Log(resultValue)).ToString();
                    }
                    break;
                case "!":
                    if(resultValue < 0 || textBox_result.Text == "." || resultValue > 25)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        textBox_result.Text = (fact(Convert.ToInt32(resultValue))).ToString();
                    }
                    break;
                case "e^x":
                    textBox_result.Text = (Math.Pow(Math.E, resultValue)).ToString();
                    break;
                case "e":
                    textBox_result.Text = (Convert.ToDouble(Math.E)).ToString();
                    break;
                case "Pi":
                    textBox_result.Text = (Convert.ToDouble(Math.PI)).ToString();
                    break;
                case "+-":
                    textBox_result.Text = (resultValue * (-1)).ToString();
                    break;
                default:
                    break;
            }
        }

        public int fact(int n)
        {
            int res = 1;
            for(int i = 1; i <= n; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
