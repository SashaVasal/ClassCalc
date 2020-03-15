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

        bool CheckLast()
        {
            if (Number.Text[Number.Text.Length - 1] < 48 || Number.Text[Number.Text.Length - 1] > 57)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        double NumberIs()
        {      
            return Convert.ToDouble(Number.Text.Substring(Convert.ToString(calc.L_Number).Length + 1));
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
        void AddOperation(char a)
        {
            Check();     
            calc.AddOperation(Number.Text);          
            Number.Text += a;
        }
        //Кнопки от 0 до 9
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
            calc.SetCount(1);
            AddOperation('+');
            
        }
        private void Button_minus_Click(object sender, EventArgs e)
        {
            calc.SetCount(2);
            AddOperation('-');
            
        }

        private void Button_del_Click(object sender, EventArgs e)
        {
            calc.SetCount(3);
            AddOperation('/');
            
        }

        private void Button_um_Click(object sender, EventArgs e)
        {
            calc.SetCount(4);
            AddOperation('*');
            
        }

        private void Button_rov_Click(object sender, EventArgs e)
        {
            calc.Button_rov_Click(Number.Text);
            if (double.IsPositiveInfinity(calc.L_Number) || double.IsNegativeInfinity(calc.L_Number)) { Number.Text = "ERROR"; }
                else
            {
                Number.Text = Convert.ToString(calc.L_Number);
            }                   
        }        
        private void Button_C_Click(object sender, EventArgs e)
        {
            calc.Button_C_Click();
            Button_NULL();           
           
        }
        private void Button_CE_Click(object sender, EventArgs e)
        {

            Button_NULL();
            calc.Button_CE_Click();
            Number.Text = Convert.ToString(calc.L_Number);
            if (calc.L_Number != 0 || calc.R_Number != 0)
            {
                switch (calc.count)
                {
                    case 1:
                        Number.Text += '+';
                        break;
                    case 2:
                        Number.Text += '-';
                        break;
                    case 3:
                        Number.Text += '/';
                        break;
                    case 4:
                        Number.Text += '*';
                        break;
                }
            }
        }
        private void Button_point_Click(object sender, EventArgs e)
        {
            Check();
            calc.Button_point_Click();

            if (calc.CheckLast(Number.Text))
            {
                if(Number.Text[Number.Text.Length - 1] != '.')Number.Text += "0";
                
            }
            if (!calc.Button_print)
            {
                calc.SetL_Number(Convert.ToDouble(Number.Text));
                if (calc.L_Number == Math.Truncate(calc.L_Number))
                {
                    if(!Number.Text.Contains('.'))Number.Text += '.';
                }
            }
            else
            {
                calc.SetR_Number(calc.NumberIs(Number.Text));
                
                if (calc.R_Number == Math.Truncate(calc.R_Number))
                {
                    string q = Number.Text.Substring(Convert.ToString(calc.L_Number).Length);
                    if(!q.Contains('.'))Number.Text += '.';
                }
            }
        }

        private void Button_MC(object sender, EventArgs e)
        {
            calc.Button_MC();          
        }
        private void Button_MR(object sender, EventArgs e)
        {
            Number.Text = Convert.ToString(calc.Memery);
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
