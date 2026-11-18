using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;
using NCalc;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;

namespace Calculator2._01
{
    public partial class Form1 : Form
    {
        double x, y, z;
        int operation, op;
        bool opex = false;
        string a;
        double[] inputVals ;
        float zoom = 1f;
        Point lastMouse;
        bool drag = false;
        float xOffset = 0;
        float yOffset = 0;
        List<Expression> funcs = new List<Expression>();
        List<Pen> pens = new List<Pen>();
        public Form1()
        {
            InitializeComponent();
            InitializeGraph();
            this.MouseWheel += pictureBox1_MouseWheel;
        }
        private void Deselect()
        {
            this.ActiveControl = null;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ActiveControl == textBox2 && e.KeyCode == Keys.Enter)
            {
                button36_Click(sender, e);
                e.Handled = true;
            }
            if (this.ActiveControl == textBox2) return;
            if (e.KeyCode == Keys.Enter)
            {
                CalculateResult();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {
                button2_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {
                button3_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {
                button4_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {
                button5_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {
                button6_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {
                button7_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {
                button8_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                button9_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {
                button10_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                button13_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                button15_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.Oem2)
            {
                button16_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.ShiftKey && e.KeyCode == Keys.D8)
            {
                button14_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                button18_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                button20_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                button21_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.T)
            {
                button22_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.C)
            {
                button24_Click(sender, e);
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)//1
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "1";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "1";
            }
            Deselect();
        }
        private void button2_Click(object sender, EventArgs e)//2
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "2";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "2";
            }
            Deselect();
        }
        private void button18_Click(object sender, EventArgs e)//AC
        {
            a = "";
            x = 0;
            y = 0;
            operation = 0;
            textBox1.Clear();
            Deselect();
        }
        private void button3_Click(object sender, EventArgs e)//3
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "3";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "3";
            }
            Deselect();
        }
        private void button4_Click(object sender, EventArgs e)//4
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "4";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "4";
            }
            Deselect();
        }
        private void button5_Click(object sender, EventArgs e)//5
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "5";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "5";
            }
            Deselect();
        }
        private void button6_Click(object sender, EventArgs e)//6
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "6";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "6";
            }
            Deselect();
        }
        private void button7_Click(object sender, EventArgs e)//7
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "7";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "7";
            }
            Deselect();
        }
        private void button8_Click(object sender, EventArgs e)//8
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "8";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "8";
            }
            Deselect();
        }
        private void button9_Click(object sender, EventArgs e)//9
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "9";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "9";
            }
            Deselect();
        }
        private void button10_Click(object sender, EventArgs e)//0
        {
            if (operation <= 4 || operation == 15)
            {
                textBox1.Text = "";
                a += "0";
                textBox1.Text = a;
            }
            else
            {
                textBox1.Text += "0";
            }
            Deselect();
        }
        private void button13_Click(object sender, EventArgs e)//add
        {
            if (opex == false && op <= 4 || opex == false && op == 15)
            {
                x = Convert.ToDouble(a);
                textBox1.Clear();
                operation = 1;
                opex = true;
                a = "";
                op = 1;
            }
            else if (opex == true && op <= 4 || opex == true && op == 15)
            {
                switch (op)
                {
                    case 1:
                        x = Convert.ToDouble(a) + x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 1;
                        break;
                    case 2:
                        x = Convert.ToDouble(a) * x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 1;
                        break;
                    case 3:
                        x = x / Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 1;
                        break;
                    case 4:
                        x = x - Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 1;
                        break;
                    case 15:
                        x = Math.Pow(x, Convert.ToDouble(textBox1.Text));
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 1;
                        break;
                    default:
                        textBox1.Text += "+";
                        break;
                }
                op = 1;
            }
            else
            {
                textBox1.Text += "+";
            }
            Deselect();
        }
        private void button14_Click(object sender, EventArgs e)//mult
        {
            if (opex == false && op <= 4 || opex == false && op == 15)
            {
                x = Convert.ToDouble(a);
                textBox1.Clear();
                operation = 3;
                opex = true;
                a = "";
                op = 2;
            }
            else if (opex == true && op <= 4 || opex == true && op == 15)
            {
                switch (op)
                {
                    case 1:
                        x = Convert.ToDouble(a) + x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 3;
                        break;
                    case 2:
                        x = Convert.ToDouble(a) * x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 3;
                        break;
                    case 3:
                        x = z / Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 3;
                        break;
                    case 4:
                        x = x - Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 3;
                        break;
                    case 15:
                        x = Math.Pow(x, Convert.ToDouble(textBox1.Text));
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 3;
                        break;
                    default:
                        textBox1.Text += "×";
                        break;
                }
                op = 2;
            }
            else
            {
                textBox1.Text += "x";
            }
            Deselect();
        }
        private void button16_Click(object sender, EventArgs e)//div
        {
            if (opex == false && op <= 4 || opex == false && op == 15)
            {
                x = Convert.ToDouble(a);
                textBox1.Clear();
                operation = 4;
                opex = true;
                a = "";
                op = 3;
            }
            else if (opex == true && op <= 4 || opex == true && op == 15)
            {
                switch (op)
                {
                    case 1:
                        x = Convert.ToDouble(a) + x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 4;
                        break;
                    case 2:
                        x = Convert.ToDouble(a) * x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 4;
                        break;
                    case 3:
                        x = x / Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 4;
                        break;
                    case 4:
                        x = x - Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 4;
                        break;
                    case 15:
                        x = Math.Pow(x, Convert.ToDouble(textBox1.Text));
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 4;
                        break;
                    default:
                        textBox1.Text += "÷";
                        break;
                }
                op = 3;
            }
            else
            {
                textBox1.Text += "÷";
            }
            Deselect();
        }
        private void button15_Click(object sender, EventArgs e)//sub
        {

            if (opex == false && op <= 4 || opex == false && op == 15)
            {
                x = Convert.ToDouble(a);
                textBox1.Clear();
                operation = 2;
                opex = true;
                a = "";
                op = 4;
            }
            else if (opex == true && op <= 4 || opex == true && op == 15)
            {
                switch (op)
                {
                    case 1:
                        x = Convert.ToDouble(a) + x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 2;
                        break;
                    case 2:
                        x = Convert.ToDouble(a) * x;
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 2;
                        break;
                    case 3:
                        x = x / Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 2;
                        break;
                    case 4:
                        x = x - Convert.ToDouble(a);
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 2;
                        break;
                    case 15:
                        x = Math.Pow(x, Convert.ToDouble(textBox1.Text));
                        textBox1.Clear();
                        textBox1.Text = x.ToString();
                        a = "";
                        operation = 2;
                        break;
                    default:
                        textBox1.Text += "-";
                        break;
                }
                op = 4;
            }
            else
            {
                textBox1.Text += "-";
            }
            Deselect();
        }
        private void CalculateResult()
        {
            textBox1.Text.Replace("e", Math.E.ToString());
            textBox1.Text.Replace("π", Math.PI.ToString());
            textBox1.Text.Replace("÷", "/");
            textBox1.Text.Replace("x", "*");
            textBox1.Text.Replace("sin(", "Math.Sin(");
            switch (operation)
            {
                case 1:
                    y = Convert.ToDouble(textBox1.Text);
                    z = x + y;
                    break;
                case 2:
                    y = Convert.ToDouble(textBox1.Text);
                    z = x - y;
                    break;
                case 3:
                    y = Convert.ToDouble(textBox1.Text);
                    z = x * y;
                    break;
                case 4:
                    y = Convert.ToDouble(textBox1.Text);
                    if (y == 0)
                    {
                        MessageBox.Show("YOU ARE GIVING ME THE CREEPS DUDE");
                        return;
                    }
                    else
                    {
                        z = x / y;
                    }
                    break;
                case 5:
                    string insin = "";
                    DataTable table = new DataTable();
                    insin = textBox1.Text.Replace("sin(", "").Replace(")", "");
                    x = Convert.ToDouble(table.Compute(insin, ""));
                    z = Math.Sin(x * Math.PI / 180);
                    if (Math.Abs(z) < 1E-10) z = 0;
                    textBox1.Text = z.ToString();
                    break;
                case 6:
                    string incos = "";
                    DataTable tb = new DataTable();
                    incos = textBox1.Text.Replace("cos(", "").Replace(")", "");
                    x = Convert.ToDouble(tb.Compute(incos, ""));
                    z = Math.Cos(x * Math.PI / 180);
                    if (Math.Abs(z) < 1E-10) z = 0;
                    textBox1.Text = z.ToString();
                    break;
                case 7:
                    string intan = "";
                    DataTable dt = new DataTable();
                    intan = textBox1.Text.Replace("tan(", "").Replace(")", "");
                    x = Convert.ToDouble(dt.Compute(intan, ""));
                    if (x % 90 == 0)
                    {
                        MessageBox.Show("ACCESS TO INFINITY DENIED");
                    }
                    else
                    {
                        z = Math.Tan(x * Math.PI / 180);
                        if (Math.Abs(z) < 1E-10) z = 0;
                        textBox1.Text = z.ToString();
                    }
                    break;
                case 8:
                    string incot = "";
                    DataTable cot = new DataTable();
                    incot = textBox1.Text.Replace("cot(", "").Replace(")", "");
                    x = Convert.ToDouble(cot.Compute(incot, ""));
                    if (x % 180 == 0)
                    {
                        MessageBox.Show("YOU ARE GIVING ME THE CREEPS DUDE");
                    }
                    else
                    {
                        z = 1 / Math.Tan(x * Math.PI / 180);
                        if (Math.Abs(z) < 1E-10) z = 0;
                        textBox1.Text = z.ToString();
                    }
                    break;
                case 9:
                    string insec = "";
                    DataTable sec = new DataTable();
                    insec = textBox1.Text.Replace("sec(", "").Replace(")", "");
                    x = Convert.ToDouble(sec.Compute(insec, ""));
                    if (x % 90 == 0)
                    {
                        MessageBox.Show("NO MORE INFINITIES DZMO PLZ");
                    }
                    else
                    {
                        z = 1 / Math.Cos(x * Math.PI / 180);
                        if (Math.Abs(z) < 1E-10) z = 0;
                        textBox1.Text = z.ToString();
                    }
                    break;
                case 10:
                    string incsc = "";
                    DataTable csc = new DataTable();
                    incsc = textBox1.Text.Replace("csc(", "").Replace(")", "");
                    x = Convert.ToDouble(csc.Compute(incsc, ""));
                    if (x % 180 == 0)
                    {
                        MessageBox.Show("STOP SCARING ME BROOOO");
                    }
                    else
                    {
                        z = 1 / Math.Sin(x * Math.PI / 180);
                        if (Math.Abs(z) < 1E-10) z = 0;
                        textBox1.Text = z.ToString();
                    }
                    break;
                case 11:
                    string inlog = textBox1.Text.Replace("log(", "").Replace(")", "");
                    string[] val = inlog.Split(',');
                    string inlogx = val[0];
                    string inlogy = val[1];
                    DataTable logx = new DataTable();
                    DataTable logy = new DataTable();
                    if (val.Length != 2)
                    {
                        MessageBox.Show("AAAARRRRRRRRRRRRRRRRRRRRRRRRRRAAAAAAA");
                    }
                    else
                    {
                        x = Convert.ToDouble(logx.Compute(inlogx, ""));
                        y = Convert.ToDouble(logy.Compute(inlogy, ""));
                    }
                    if (x < 0 || y < 0 || x == 1)
                    {
                        MessageBox.Show("ERRORROROROROROROROROR");
                    }
                    else
                        z = Math.Log(x, y);
                    break;
                case 12:
                    string inln = textBox1.Text.Replace("ln(", "").Replace(")", "");
                    DataTable ln = new DataTable();
                    x = Convert.ToDouble(ln.Compute(inln, ""));
                    z = Math.Log(x, Math.E);
                    break;
                case 13:
                    string inabs = textBox1.Text.Replace("abs(", "").Replace(")", "");
                    DataTable abs = new DataTable();
                    x = Convert.ToDouble(abs.Compute(inabs, ""));
                    z = Math.Abs(x);
                    break;
                case 14:
                    string inroot = textBox1.Text.Replace("√(", "").Replace(")", "");
                    DataTable root = new DataTable();
                    x = Convert.ToDouble(root.Compute(inroot, ""));
                    z = Math.Sqrt(x);
                    break;
                case 15:
                    y = Convert.ToDouble(textBox1.Text);
                    z = Math.Pow(x, y);
                    break;
                case 16:
                    Random random = new Random();
                    z = random.NextDouble();
                    break;
                case 17:
                    string infact = textBox1.Text.Replace("!", "");
                    DataTable fact = new DataTable();
                    x = Convert.ToDouble(fact.Compute(infact, ""));
                    if (x < 0 || x % 1 != 0)
                    {
                        MessageBox.Show("WILL YOU FACTORIAL ME?");
                    }
                    else
                    {
                        z = 1;
                        for (int i = 1; i <= (int)x; i++)
                        {
                            z *= i;
                        }
                    }
                            break;
            }
            textBox1.Text = z.ToString();
            opex = false;
        }
        private void button19_Click(object sender, EventArgs e)//=
        {
            CalculateResult();
            Deselect();
            x = y = op = operation = 0;
            a = "";
            opex = false;
        }
        private void button11_Click(object sender, EventArgs e)//Dec
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
            else
            {
                MessageBox.Show("YOU'VE HAD ENOUGH DOTS TODAY JIMMY");
            }
            Deselect();
        }

        private void button20_Click(object sender, EventArgs e)//Del
        {
            if (textBox1.Text.Length >= 1)
        { 
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
            else
            {
                MessageBox.Show("ISN'T THAT CLEAN ENOUGH FOR YOU?!!?!?1?!?!?!");
            }
            Deselect();
        }

        private void button17_Click(object sender, EventArgs e)//π
        {
            textBox1.Text += "π";
            Deselect();
        }

        private void button35_Click(object sender, EventArgs e)//Rnd16
        {
            opex = true;
            operation = 16;
            textBox1.Text +="#Rnd";
            op = 16;
            Deselect();
        }

        private void button34_Click(object sender, EventArgs e)//Ans
        {
            textBox1.Text += z.ToString();
            Deselect();
        }

        private void button27_Click(object sender, EventArgs e)//(
        {
            textBox1.Text += "(";
            Deselect();
        }
        private void button28_Click(object sender, EventArgs e)//)
        {
            textBox1.Text += ")";
            Deselect();
        }
        private void button29_Click(object sender, EventArgs e)//log 11
        {
            opex = true;
            textBox1.Text += "log(";
            operation = 11;
            op = 11;
            Deselect();
        }
        private void button24_Click(object sender, EventArgs e)//cos 6
        {
            opex = true;
            textBox1.Text += "cos(";
            operation = 6;
            op = 6;
            Deselect();
        }
        private void button22_Click(object sender, EventArgs e)//tan 7
        {
            opex = true;
            textBox1.Text += "tan(";
            operation = 7;
            op = 7;
            Deselect();
        }
        private void button23_Click(object sender, EventArgs e)//sec 9
        {
            opex = true;
            textBox1.Text += "sec(";
            operation = 9;
            op = 9;
            Deselect();
        }

        private void button25_Click(object sender, EventArgs e)//cot 8
        {
            opex = true;
            textBox1.Text += "cot(";
            operation = 8;
            op = 8;
            Deselect();
        }
        private void button26_Click(object sender, EventArgs e)//csc 10
        {
            opex = true;
            textBox1.Text += "csc(";
            operation = 10;
            op = 10;
            Deselect();
        }
        private void button30_Click(object sender, EventArgs e)//ln 12
        {
            opex = true;
            textBox1.Text += "ln(";
            operation = 12;
            op = 12;
            Deselect();
        }
        private void button31_Click(object sender, EventArgs e)//Abs 13
        {
            opex = true;
            textBox1.Text += "abs(";
            operation = 13;
            op = 13;
            Deselect();
        }
        private void button32_Click(object sender, EventArgs e)//sqrt 14
        {
            opex = true;
            textBox1.Text += "√(";
            operation = 14;
            op = 14;
            Deselect();
        }
        private void button33_Click(object sender, EventArgs e)// exp 15
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("HOW TO COMPUTE EMPTYNESS TO SOMETHINGNESS DZMAO!!!");
            }
            else
            {
                if (opex == false && op <= 4 || opex == false && op == 15)
                {
                    x = Convert.ToDouble(a);
                    textBox1.Clear();
                    operation = 15;
                    opex = true;
                    a = "";
                    op = 15;
                }
                else if (opex == true && op <= 4 || opex == true && op == 15)
                {
                    switch (op)
                    {
                        case 1:
                            x = Convert.ToDouble(a) + x;
                            textBox1.Clear();
                            textBox1.Text = x.ToString();
                            a = "";
                            operation = 15;
                            break;
                        case 2:
                            x = Convert.ToDouble(a) * x;
                            textBox1.Clear();
                            textBox1.Text = x.ToString();
                            a = "";
                            operation = 15;
                            break;
                        case 3:
                            x = x / Convert.ToDouble(a);
                            textBox1.Clear();
                            textBox1.Text = x.ToString();
                            a = "";
                            operation = 15;
                            break;
                        case 4:
                            x = x - Convert.ToDouble(a);
                            textBox1.Clear();
                            textBox1.Text = x.ToString();
                            a = "";
                            operation = 15;
                            break;
                        case 15:
                            x = Math.Pow(x, Convert.ToDouble(textBox1.Text));
                            textBox1.Clear();
                            textBox1.Text = x.ToString();
                            a = "";
                            operation = 15;
                            break;
                        default:
                            textBox1.Text += "÷";
                            break;
                    }
                    op = 15;
                }
                else textBox1.Text += "^";
            }
            Deselect();
        }
        private void button41_Click(object sender, EventArgs e)
        {
            operation = 17;
            opex = true;
            textBox1.Text += "!";
            op = 17;
            Deselect();
        }
        private void button12_Click(object sender, EventArgs e)//e
        {
            textBox1.Text += Math.E;
            Deselect();
        }
        private void button21_Click(object sender, EventArgs e)//sin 5
        {
            opex = true;
            textBox1.Text = "sin(";
            operation = 5;
            op = 5;
            Deselect();
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)//txtbox
        {

        }
        private void Form1_Load(object sender, EventArgs e)// BG
        {

        }
        private void pictureBox1_Click_1(object sender, EventArgs e)// screen
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)// Gtxtbox
        {

        }
        private void button_37_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
            else
            {
                MessageBox.Show("NO MORE BACKSPACES FOR YOU!");
            }
        }
        private void button38_Click(object sender, EventArgs e)
        {
            funcs.Clear();
            pictureBox1.Invalidate();
        }
        double Factorial(double n)
        {
            if (n < 0 || n != Math.Floor(n))
            {
                throw new Exception("WILL YOU BE MY FACTOR    IAL?");
            }
            double result = 1;
            for (int i = 1; i <= n; i++) result *= i;
            return result;
        }
        private void InitializeGraph()
        {
            pictureBox1.BackColor = Color.White;
            pictureBox1.Paint += PictureBox1_Paint;
            StartPosition = FormStartPosition.CenterScreen;
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            pictureBox1.Focus();
            pictureBox1.MouseEnter += (s, e) => pictureBox1.Focus();
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom *= e.Delta > 0 ? 1.1f : 0.9f;
            if (zoom < 0.01) zoom = 0.01f;
            if (zoom > 100f) zoom = 100f;
            pictureBox1.Invalidate();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            funcs.Clear();
            pens.Clear();
            string[] lines = textBox2.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            Color[] color = { Color.Salmon, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown, Color.Magenta, Color.Cyan, Color.SeaGreen, Color.Red };
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    string fix = lines[i].Trim().ToLower();
                    if (fix.StartsWith("y=")) fix = fix.Substring(2);
                    fix = fix.Replace("arcsin(", "Asin(")
                             .Replace("arccos(", "Acos(")
                             .Replace("arctan(", "Atan(")
                             .Replace("arccot(", "Acot(")
                             .Replace("arcsec(", "Asec(")
                             .Replace("arccsc(", "Acsc(")
                             .Replace("sinh(", "Sinh(")
                             .Replace("cosh(", "Cosh(")
                             .Replace("tanh(", "Tanh(")
                             .Replace("coth(", "Coth(")
                             .Replace("sech(", "Sech(")
                             .Replace("csch(", "Csch(")
                             .Replace("sin(", "Sin(")
                             .Replace("cos(", "Cos(")
                             .Replace("tan(", "Tan(")
                             .Replace("cot(", "(1 / Tan(")
                             .Replace("sec(", "(1 / Cos(")
                             .Replace("csc(", "(1 / Sin(")
                             .Replace("log(", "Log(")
                             .Replace("ln(", "Ln(")
                             .Replace("abs(", "Abs(")
                             .Replace("√(", "Sqrt(")
                             .Replace("π", "Pi")
                             .Replace("X", "x");
                    int open = fix.Count(c => c == '(');
                    int close = fix.Count(c => c == ')');
                    if (open - close > 0) fix += new string(')', open - close);
                    fix = Regex.Replace(fix, @"(\d)([a-z\(])", "$1*$2");
                    fix = Regex.Replace(fix, @"(\))(\d|[a-z])", "$1*$2");
                    fix = Regex.Replace(fix, @"\)\(", ")*(");
                    fix = Regex.Replace(fix, @"e\^\(([^)]+)\)", "Exp($1)");
                    fix = Regex.Replace(fix, @"e\^([a-zA-Z0-9\.]+)", "Exp($1)");
                    fix = Regex.Replace(fix, @"(e|Pi)([a-zA-Z\(])", "$1*$2");
                    fix = Regex.Replace(fix, @"\|([^|]+)\|", "Abs($1)");
                    fix = Regex.Replace(fix, @"(\([^()]+|[a-zA-Z0-9\.]+)\^(\([^()]+\)|[a-zA-Z0-9\.]+)", "Pow($1,$2)");
                    fix = Regex.Replace(fix, @"(\d)\!", "Factorial($1)");
                    fix = Regex.Replace(fix, @"\by\b|f\(x\)| =", "");
                    Expression exp = new Expression(fix, EvaluateOptions.IgnoreCase);
                    exp.EvaluateFunction += (name, args) =>
                    {
                        if (name.Equals("Factorial", StringComparison.OrdinalIgnoreCase))
                        {
                            double fact = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Factorial(fact);
                        }
                        else if (name.Equals("Acot", StringComparison.OrdinalIgnoreCase))
                        {
                            double acot = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Atan2(1, acot);
                        }
                        else if (name.Equals("Asec", StringComparison.OrdinalIgnoreCase))
                        {
                            double asec = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Acos(1 / asec);
                        }
                        else if (name.Equals("Acsc", StringComparison.OrdinalIgnoreCase))
                        {
                            double acsc = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Asin(1 / acsc);
                        }
                        else if (name.Equals("Ln", StringComparison.OrdinalIgnoreCase))
                        {
                            double ln = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Log(ln);
                        }
                        else if (name.Equals("Sinh", StringComparison.OrdinalIgnoreCase))
                        {
                            double sinh = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Sinh(sinh);
                        }
                        else if (name.Equals("Cosh", StringComparison.OrdinalIgnoreCase))
                        {
                            double cosh = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Cosh(cosh);
                        }
                        else if (name.Equals("Tanh", StringComparison.OrdinalIgnoreCase))
                        {
                            double tanh = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = Math.Tanh(tanh);
                        }
                        else if (name.Equals("Coth", StringComparison.OrdinalIgnoreCase))
                        {
                            double coth = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = 1 / Math.Tanh(coth);
                        }
                        else if (name.Equals("Sech", StringComparison.OrdinalIgnoreCase))
                        {
                            double sech = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = 1 / Math.Cosh(sech);
                        }
                        else if (name.Equals("Csch", StringComparison.OrdinalIgnoreCase))
                        {
                            double csch = Convert.ToDouble(args.Parameters[0].Evaluate());
                            args.Result = 1 / Math.Sinh(csch);
                        }
                    };
                    exp.Parameters["x"] = 1.0;
                    var test = exp.Evaluate();
                    funcs.Add(exp);
                    pens.Add(new Pen(color[i % color.Length], 2));
                    pictureBox1.Invalidate();
                }
                catch
                {
                    MessageBox.Show($"AM I A GRAPHING CALCULATOR?{"\r\n"} YES. {"\r\n"}AM I PROGRAMMED TO DRAW ANY FUNCTION? {"\r\n"}YES.{"\r\n"} DO I PLAN ON DRAWING FUNCTION {i + 1},EVENTHOUGH IT WILL BREAK ME MENTALLY, PHYSICALLY, EMOTIONALLY AND WILL MAKE ME CRY, JUST BECAUSE YOU ARE TOO LAZY TO USE YOU TEENY TINY DZALIAN PATARA BRAIN?!{"\r\n"} NOPE, NOT GONNA HAPPEN{"\r\n"} USE THAT ORGAN INSIDE YOUR HEAD BRO!!!!!");
                }
            }
            inputVals = Enumerable.Range(-pictureBox1.Width * 2, pictureBox1.Width * 4).Select(i => (double)i / 5.0).ToArray();
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            lastMouse = e.Location;
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void button39_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            xOffset = 0;
            yOffset = 0;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drag) return;
            xOffset += e.X - lastMouse.X;
            yOffset += e.Y - lastMouse.Y;
            lastMouse = e.Location;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            lastMouse = e.Location;
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float xScale = 50f * zoom;
            float yScale = 50f * zoom;
            float xCentre = pictureBox1.Width / 2f + xOffset;
            float yCentre = pictureBox1.Height / 2f + yOffset;
            double[] step = {0.1, 0.2, 0.5, 1, 2, 5, 10 , 20, 50, 100, 200, 500, 1000};
            double gridStep = step.First(s => s * xScale >= 50);
            if (gridStep == 0) gridStep = step.Last();
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (double gx = -pictureBox1.Width; gx < pictureBox1.Width; gx += gridStep)
            {
                float dx = xCentre + (float)(gx * xScale);
                g.DrawLine(new Pen(Color.LightGray, 3), dx, 0, dx, pictureBox1.Height);
            }
                for (double gy = -pictureBox1.Height; gy < pictureBox1.Height; gy += gridStep)
                {
                    float dy = yCentre + (float)(gy * yScale);
                    g.DrawLine(new Pen(Color.LightGray, 3), 0, dy, pictureBox1.Width, dy);
                }
                e.Graphics.DrawLine(new Pen(Color.Black, 4), xCentre, 0, xCentre, pictureBox1.Height);
                e.Graphics.DrawLine(new Pen(Color.Black, 4), -pictureBox1.Width, yCentre, pictureBox1.Width, yCentre);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.DarkSlateBlue, 2);
            for (int f = 0; f < funcs.Count; f++)
            {
                var func = funcs[f];
                var penFunc = pens[f];
                for (int px = 0; px < pictureBox1.Width - 1; px++)
                {
                    double x = (px - xCentre) / xScale;
                    func.Parameters["x"] = x;
                    double y;
                    try
                    {
                        y = Convert.ToDouble(func.Evaluate());
                    }
                    catch
                    {
                        continue;
                    }
                    if (double.IsNaN(y) || double.IsInfinity(y))
                    {
                        continue;
                    }
                    float dy = yCentre - (float)(y * yScale);
                    func.Parameters["x"] = (px + 1 - xCentre) / xScale;
                    double y1;
                    try
                    {
                        y1 = Convert.ToDouble(func.Evaluate());
                    }
                    catch
                    {
                        continue;
                    }
                    if (double.IsNaN(y1) || double.IsInfinity(y1))
                    {
                        continue;
                    }
                    float dy1 = yCentre - (float)(y1 * yScale);
                    if (Math.Abs(dy - dy1) > pictureBox1.Height)
                    {
                        continue;
                    }
                    try
                    {
                        e.Graphics.DrawLine(penFunc, px, dy, px + 1, dy1);
                    }
                    catch
                    {
                        MessageBox.Show($"AM I A GRAPHING CALCULATOR?{"\r\n"} YES. {"\r\n"}AM I PROGRAMMED TO DRAW ANY FUNCTION? {"\r\n"}YES.{"\r\n"} DO I PLAN ON DRAWING THE FUNCTION THAT YOUR MAJESTY JUST TYPED INTO MY TERRETORY ,EVENTHOUGH IT WILL BREAK ME MENTALLY, PHYSICALLY, EMOTIONALLY AND WILL MAKE ME CRY, JUST BECAUSE YOU ARE TOO LAZY TO USE YOU TEENY TINY DZALIAN PATARA BRAIN?!{"\r\n"} NOPE, NOT GONNA HAPPEN{"\r\n"} USE THAT ORGAN INSIDE YOUR HEAD BRO!!!!!");
                        break;
                    }
                }
            }
        }
    }
}