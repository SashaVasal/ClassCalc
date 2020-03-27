using System;
using System.Linq;
using System.Windows.Forms;

namespace NewTrueCalc
{

    public class Calc
    {
        public double L_Number = 0, R_Number = 0, Memery = 0;
        public int count = 0;
        public bool print_operate = false;


        public bool CheckLast(string LabelText)
        {
            return (LabelText[LabelText.Length - 1] < 48 || LabelText[LabelText.Length - 1] > 57);        
        }
        public double LeftOperator(string LabelText)
        {

            return Convert.ToDouble(LabelText);
        }
        public double RightOperator(string LabelText)
        {
            int operant = 0;
            for (int i = 0; i < LabelText.Length; i++)
            {
                if (LabelText[i] == '/' || LabelText[i] == '*' || LabelText[i] == '+' || LabelText[i] == '-')
                {
                    if(i != 0)
                    {
                        operant = i;
                        break;
                    }
                   
                }
            }
            if (LabelText.Length == Convert.ToString(L_Number).Length + 1)
            {
                return 0;
            }
            else
            {
                if (CheckLast(LabelText))
                {
                    
                    return Convert.ToDouble(LabelText.Substring(operant +  1, LabelText.Length - Convert.ToString(L_Number).Length - 1));
                }
                else
                {
                    if(LabelText.Length != Convert.ToString(L_Number).Length)
                    {
                        return Convert.ToDouble(LabelText.Substring(operant + 1));
                    }
                    else
                    {
                        return 0;
                    }
                }
                
            }
            
        }
 
        public void AddOperation(string text)
        {
           
            if (!print_operate)
            {
                print_operate = true;
                if (CheckLast(text))
                {
                    text = text.Substring(0, text.Length - 1);
                    
                }
                L_Number = LeftOperator(text);

            }
           
            
        }
       
       
    
        public void Calculate(string Label)
        {
            if (Label == "") print_operate = false;

            if (CheckLast(Label) && Label[Label.Length-1] != '.')
            {
                count = 0;
            }

            if (print_operate)
            {
                R_Number = RightOperator(Label);
            }
            else
            {
                L_Number = LeftOperator(Label);
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
                    if(R_Number != 0)
                    {
                        L_Number /= R_Number;
                    }
                    else
                    {
                        L_Number = 0;
                    }          
                    break;
                case 4:
                    L_Number *= R_Number;                 
                    break;
            }
            print_operate = false;
            
        }
        public void Clear()
        {
            L_Number = 0;
            R_Number = 0;
            print_operate = false;
            count = 0;
        }
        public string CleanEntry()
        {
            string Label;
            print_operate = true;
            
         
           
            Label = Convert.ToString(L_Number);
            if (L_Number != 0 || R_Number != 0)
            {
                switch (count)
                {
                    case 1:
                        Label += '+';
                        break;
                    case 2:
                        Label += '-';
                        break;
                    case 3:
                        Label += '/';
                        break;
                    case 4:
                        Label += '*';
                        break;
                }
            }
            return Label;
        }
        public string AddPoint(string Label)
        {
            Label = Convert.ToString(Label);
            

            if (CheckLast(Label))
            {
                if (Label[Label.Length - 1] != '.') Label += "0";

            }
            if (!print_operate)
            {
                L_Number = LeftOperator(Label);
                if (L_Number == Math.Truncate(L_Number))
                {
                    if (!Label.Contains('.')) Label += '.';
                }
            }
            else
            {
                R_Number = RightOperator(Label);

                if (R_Number == Math.Truncate(R_Number))
                {
                    string q = Label.Substring(Convert.ToString(L_Number).Length);
                    if (!q.Contains('.')) Label += '.';
                }
            }

            return Label;
        }
        public void Button_MC()
        {
            Memery = 0;
        }
        public string MemGetResult()
        {
            return Convert.ToString(Memery);
        }
        public void Button_M_Plus(string Text)
        {
            if (!print_operate)
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
                    R_Number = RightOperator(Text);
                }
                Memery += R_Number;
            }

        }
        public void Button_M_Minus(string Text)
        {
            if (!print_operate)
            {

                L_Number = LeftOperator(Text); 
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
                    R_Number = RightOperator(Text);
                }
                Memery -= R_Number;
            }
        }
        public void Button_MS(string Text)
        {
            if (!print_operate)
            {

                L_Number = LeftOperator(Text);
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
                    R_Number = RightOperator(Text);
                }

                Memery = R_Number;
            }

        }
    } 
}
