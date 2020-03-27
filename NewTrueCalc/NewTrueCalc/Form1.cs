using System;
using System.Linq;
using System.Windows.Forms;

namespace NewTrueCalc
{

    public partial class Form1 : Form
    {
        

        Calc calc = new Calc();
        
        public Form1() {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e) { }

        public void Check()
        {
            if (Number.Text == "ERROR")
            {
                Button_NULL();
            }
        }
        void Button_NULL()
        {
            Number.Text = "0";
        }
        

        void Add_Digit(char a)
        {
            Check();
            if (Number.Text == "0") Number.Text = Convert.ToString(a); else Number.Text += a;
        }
        void AddOperation(char a, object sender, EventArgs e)
        {
            Check();
            if (calc.print_operate)
            {
                Eq_Click(sender, e);
            }
            
            calc.AddOperation(Number.Text);
            if (Number.Text[Number.Text.Length - 1] >= 48 && Number.Text[Number.Text.Length - 1] <= 57)
            {
                Number.Text += a;
            }
            else
            {
                Number.Text = Number.Text.Substring(0, Number.Text.Length - 1) + a;
            }
            
        }
        
        private void Button_1_Click(object sender, EventArgs e)
        {
            Add_Digit('1');
        }
        private void Button_2_Click(object sender, EventArgs e)
        {
            Add_Digit('2');
        }
        private void Button_3_Click(object sender, EventArgs e)
        {
            Add_Digit('3');
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            Add_Digit('4');
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            Add_Digit('5');
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            Add_Digit('6');
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            Add_Digit('7');
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            Add_Digit('8');
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            Add_Digit('9');
        }
        private void Button_0_Click(object sender, EventArgs e)
        {
            Add_Digit('0');
        }

        //Операции

        private void Button_plus_Click(object sender, EventArgs e)
        {
            
            AddOperation('+',sender,e);
            calc.count = 1;
        }
        private void Button_minus_Click(object sender, EventArgs e)
        {
           
            AddOperation('-', sender, e);
            calc.count = 2;
        }

        private void Button_del_Click(object sender, EventArgs e)
        {
           
            AddOperation('/', sender, e);
            calc.count = 3;
        }

        private void Button_multi_Click(object sender, EventArgs e)
        {
            
            AddOperation('*', sender, e);
            calc.count = 4;
        }

        private void Eq_Click(object sender, EventArgs e)
        {
            calc.Calculate(Number.Text);
            if (double.IsPositiveInfinity(calc.L_Number) || double.IsNegativeInfinity(calc.L_Number)) {
                Number.Text = "ERROR";
            }
            else
            {
                Number.Text = Convert.ToString(calc.L_Number);
            }                   
        }        
        private void Button_C_Click(object sender, EventArgs e)
        {
            calc.Clear();
            Button_NULL();           
           
        }
        private void Button_CE_Click(object sender, EventArgs e)
        {

            Button_NULL();
            
            Number.Text = calc.CleanEntry();
            
        }
        private void Button_point_Click(object sender, EventArgs e)
        {
            Check();
            Number.Text = calc.AddPoint(Number.Text);

            
        }

        private void Button_MC(object sender, EventArgs e)
        {
            Number.Text = calc.MemGetResult();          
        }
        private void Button_MR(object sender, EventArgs e)
        {
            Number.Text = calc.MemGetResult();
        }
        private void Button_M_Plus(object sender, EventArgs e)
        {
            calc.Button_M_Plus(Number.Text);
        }
        private void Button_M_Minus(object sender, EventArgs e)
        {
            calc.Button_M_Minus(Number.Text);
        }
        private void Button_MS(object sender, EventArgs e)
        {
            calc.Button_MS(Number.Text);
            

        }
    }
}
