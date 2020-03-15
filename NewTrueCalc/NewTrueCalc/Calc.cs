using System;
using System.Linq;
using System.Windows.Forms;

namespace NewTrueCalc
{

    public class Calc
    {
        public double L_Number = 0, R_Number = 0, Memery = 0;
        public int count = 0;
        public bool Button_print = false;

        public bool CheckLast(string LabelText)
        {
            if (LabelText[LabelText.Length - 1] < 48 || LabelText[LabelText.Length - 1] > 57)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double NumberIs(string LabelText)
        {
            if(LabelText.Length == Convert.ToString(L_Number).Length + 1) { return 0; }
            else
            {
                return Convert.ToDouble(LabelText.Substring(Convert.ToString(L_Number).Length + 1));
            }
            
        }
        public Calc() { }

        public double Square(double a)
        {
            return a * a;
        }

        public void AddOperation(string text)
        {
            
            Button_print = true;
            if (CheckLast(text))
            {
                text = text.Substring(0, text.Length - 1);
                L_Number = Convert.ToDouble(text);
            }
            else
            {
                L_Number = Convert.ToDouble(text);
            }
        }
        public void SetCount(int a)
        {
            count = a;
        }
        public void SetPrint(bool a)
        {
            Button_print = a;
        }
        public void SetL_Number(double a)
        {
            L_Number = a;
        }
        public void SetR_Number(double a)
        {
            R_Number = a;
        }
        public void Button_rov_Click(string Label)
        {
            if (Label == "") Button_print = false;
            if (Button_print) { R_Number = NumberIs(Label); }
            else {
                L_Number = Convert.ToDouble(Label);
            };

            switch (count)
            {
                case 1:
                    L_Number += R_Number;
                    
                    break;
                case 2:
                    L_Number -= R_Number;
                    
                    break;
                case 3:                 
                    L_Number /= R_Number;          
                    break;
                case 4:
                    L_Number *= R_Number;                 
                    break;
            }
            Button_print = false;
            
        }
        public void Button_C_Click()
        {
            SetL_Number(0);
            SetR_Number(0);
            SetPrint(false);
            count = 0;
        }
        public void Button_CE_Click()
        {
            
            Button_print = true;
            R_Number = 0;
        }
        public void Button_point_Click()
        {

        }
        public void Button_MC()
        {
            Memery = 0;
        }
        public void Button_MR(string Text)
        {
            Text = Convert.ToString(Memery);
        }
        public void Button_M_Plus(string Text)
        {
            if (!Button_print)
            {

                L_Number = Convert.ToDouble(Text);
                Memery += L_Number;
            }
            else
            {
                if (CheckLast(Text))
                {
                    R_Number = 0;
                }
                else
                {
                    R_Number = NumberIs(Text);
                }
                Memery += R_Number;
            }

        }
        public void Button_M_Minus(string Text)
        {
            if (!Button_print)
            {

                L_Number = Convert.ToDouble(Text);
                Memery -= L_Number;
            }
            else
            {
                if (CheckLast(Text))
                {
                    R_Number = 0;
                }
                else
                {
                    R_Number = NumberIs(Text);
                }
                Memery -= R_Number;
            }
        }
        public void Button_MS(string Text)
        {
            if (!Button_print)
            {

                L_Number = Convert.ToDouble(Text);
                Memery = L_Number;
            }
            else
            {
                if (CheckLast(Text))
                {
                    R_Number = 0;
                }
                else
                {
                    R_Number = NumberIs(Text);
                }

                Memery = R_Number;
            }

        }
    } 
}
