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
    public partial class Cal : Form
    {
        /*private Rectangle displayBox;
        private Rectangle oneB;
        private Rectangle twoB;
        private Rectangle threeB;
        private Rectangle fourB;
        private Rectangle fiveB;
        private Rectangle sixB;
        private Rectangle sevenB;
        private Rectangle eightB;
        private Rectangle nineB;
        private Rectangle zeroB;
        private Rectangle plusB;
        private Rectangle minusB;
        private Rectangle divideB;
        private Rectangle multB;
        private Rectangle squireB;
        private Rectangle plusMinusB;
        private Rectangle dotB;*/

        string displayText = "";
        string valueAAO = "0";
        int stkO = 0;
        double zerow = 1;
        double afterEqual = 0;
        string currentOperation = "";
        string previousOperation = "";
        string stuckOperator = "";
        string history = "";
        bool Operation = true;
        bool fraction = false;

        double calculation = 0;
        double displayValue = 0;

        public Cal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Display_KeyPress("7");
        }

        private void Cal_Load(object sender, EventArgs e)
        {

        }

        private void Cal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void One_Click(object sender, EventArgs e)
        {
            Display_KeyPress("1");
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Display_KeyPress("2");
        }

        private void Three_Click(object sender, EventArgs e)
        {
            Display_KeyPress("3");
        }

        private void Four_Click(object sender, EventArgs e)
        {
            Display_KeyPress("4");
        }

        private void Five_Click(object sender, EventArgs e)
        {
            Display_KeyPress("5");
        }

        private void Six_Click(object sender, EventArgs e)
        {
            Display_KeyPress("6");
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            Display_KeyPress("8");
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            Display_KeyPress("9");
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            if ((displayText == "")||(displayText == "0"))
            {
                displayText = "0";
                valueAAO = "0";
                Display.Text = displayText + "\r\n\r\n\r\n\r\n" + calculation;
                previousOperation = currentOperation;
                Operation = false;
            }
            else
            {
                Display_KeyPress("0");
            }
        }

        private void Display_KeyPress(string buttonPressed)
        {
            displayText += buttonPressed;
            valueAAO += buttonPressed;
            Display.Text = displayText;
            previousOperation = currentOperation;
            Operation = false;
        }

        private void ClearScreen_Click(object sender, EventArgs e)
        {
            displayText = "";
            valueAAO = "0";
            stkO = 0;
            zerow = 1;
            Display.Text = "0";
            afterEqual = 0;
            displayValue = 0;
            calculation = 0;
            currentOperation = "";
            previousOperation = "";
            stuckOperator = "";
            Operation = true;
            fraction = false;
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            //calculation *= -1;
            if (previousOperation == "=")
            {
                afterEqual *= -1;
                 /*string minusCheck = afterEqual.ToString();
                if (minusCheck[0] == '-')
                {
                    //Display.Text = "-(" + displayText + ")" + "\r\n\r\n\r\n\r\n" + calculation;
                    Display.Text = "-(" + displayText + ")" + "\r\n\r\n\r\n\r\n" + afterEqual;
                }
                else
                {
                    Display_String("");
                } */
                Display.Text = " " + "\r\n\r\n\r\n\r\n" + afterEqual;
            }
            //string minusCheck = calculation.ToString();
            /*string minusCheck = afterEqual.ToString();
            if (minusCheck[0] == '-')
            {
                //Display.Text = "-(" + displayText + ")" + "\r\n\r\n\r\n\r\n" + calculation;
                Display.Text = "-(" + displayText + ")" + "\r\n\r\n\r\n\r\n" + afterEqual;
            }
            else
            {
                Display_String("");
            }*/
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            zerow = double.Parse(valueAAO);
            stkO = 0;

            if (previousOperation == "<=")
            {
                calculation = Convert.ToDouble(valueAAO);
                valueAAO = "0";

            }
            else if(previousOperation=="%")
            {
                displayText = afterEqual.ToString();
                calculation = afterEqual;
                currentOperation = "+";
            }
            else if (previousOperation == "=")
            {
                if (valueAAO == "0")
                {
                    displayText = afterEqual.ToString();
                    calculation = afterEqual;
                }
                else
                {
                    calculation = Convert.ToDouble(valueAAO);
                    valueAAO = "0";
                    previousOperation = "+";
                }
                currentOperation = "+";
            }

            if (Display.Text=="0")
            {
                displayText = "0";
            }
            else if(Operation==false)
            {
                if (previousOperation == "-")
                {
                    calculation -= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("+");
                }
                else if (previousOperation == "x")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                    }

                    calculation *= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("+");
                }
                else if (previousOperation == "/")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                        zerow = 1;
                    }

                    if (zerow == 0)
                    {
                        Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                        displayText = ""; //newly added on aug 22!
                        currentOperation = "="; //newly added on aug 22!
                        //Operation = false;
                    }
                    else
                    {
                        calculation /= Convert.ToDouble(valueAAO);
                        Arithmatic_Operations("+");
                    }
                }
                else
                {
                    calculation += Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("+");
                }

                Operation = true;
            }

            fraction = false;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            zerow = double.Parse(valueAAO);

            //if ((displayText != "") && (currentOperation != ""))//older
            if ((displayText != "") && (currentOperation != "")&&(currentOperation!="$")&& (currentOperation != "%"))//newer dengerous!!
            {
                if (Operation == false)
                {
                    if (previousOperation == "+")
                    {
                        calculation += Convert.ToDouble(valueAAO);
                        Equal_Operation_False();
                    }
                    else if (previousOperation == "-")
                    {
                        calculation -= Convert.ToDouble(valueAAO);
                        Equal_Operation_False();
                    }
                    else if (previousOperation == "x")
                    {
                        if (valueAAO == "0")
                        {
                            valueAAO = "1";
                        }

                        calculation *= Convert.ToDouble(valueAAO);
                        Equal_Operation_False();
                    }
                    else if (previousOperation == "/")
                    {
                        if (valueAAO == "0")
                        {
                            valueAAO = "1";
                            zerow = 1;
                        }

                        if (zerow == 0)
                        {
                            Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                            displayText = ""; //newly added on aug 22!
                            currentOperation = "="; //newly added on aug 22!
                        }
                        else
                        {
                            calculation /= Convert.ToDouble(valueAAO);
                            Equal_Operation_False();
                        }
                    }
                    else if (previousOperation == "")
                    {
                        calculation += Convert.ToDouble(valueAAO);
                        Equal_Operation_False();
                    }
                }
                else if (Operation == true)    //newly added else if .......... might be dengerous!!
                {
                    if ((currentOperation == "+")||(stuckOperator=="+"))
                    {
                        displayText += calculation.ToString();
                        calculation += calculation;
                        Equal_Operation_True("+");
                    }
                    else if ((currentOperation == "-") || (stuckOperator == "-"))
                    {
                        displayText += calculation.ToString();
                        calculation -= calculation;
                        Equal_Operation_True("-");
                    }
                    else if ((currentOperation == "x") || (stuckOperator == "x"))
                    {
                        displayText += calculation.ToString();
                        calculation *= calculation;
                        Equal_Operation_True("x");
                    }
                    else if ((currentOperation == "/") || (stuckOperator == "/"))
                    {
                        displayText += calculation.ToString();
                        if (calculation == 0)
                        {
                            Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                            displayText = ""; //newly added on aug 22!
                            //currentOperation = "="; //newly added on aug 22!
                        }
                        else
                        {
                            calculation /= calculation;
                            Equal_Operation_True("/");
                        }
                    }
                }

                previousOperation = "=";
                if (stkO < 1)
                {
                    stuckOperator = currentOperation;
                    stkO++;
                }

                currentOperation = "=";
            }
            else if (currentOperation == "")
            {
                Display.Text = displayText + "\r\n\r\n\r\n\r\n" + Convert.ToDouble(valueAAO);
            }
            else if(previousOperation=="=")
            {
                calculation = Convert.ToDouble(valueAAO);
                Display.Text = displayText + "\r\n\r\n\r\n\r\n" + Convert.ToDouble(valueAAO);
            }
            else if (currentOperation == "%")  //newly added might be dengerous!!
            {
                string concatS = calculation + "% of " + Convert.ToDouble(valueAAO) + " is : ";
                calculation = calculation * Convert.ToDouble(valueAAO);
                calculation /= 100;
                currentOperation = "="; //added 22aug,2017!!!!!
                previousOperation = "=";
                Display.Text = concatS + "\r\n\r\n\r\n\r\n" + calculation;
                history += concatS + " " + calculation + "\r\n";
                afterEqual = calculation;
                calculation = 0;
                displayText = "";
                valueAAO = "0";
            }
        }

        private void Equal_Operation_True(string sign)
        {
            Display_String(sign);
            displayText += sign;
            afterEqual = calculation;
            valueAAO = "0";
        }

        private void Equal_Operation_False()
        {
            displayValue = calculation;
            Display_String("");
            afterEqual = calculation;
            history += displayText + " = " + afterEqual + "\r\n";
            calculation = 0;
            valueAAO = "0";
            displayText = "";
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            zerow = double.Parse(valueAAO);
            stkO = 0;

            if (previousOperation == "<=")
            {
                calculation = Convert.ToDouble(valueAAO);
                valueAAO = "0";
            }
            else if (previousOperation == "=")
            {
                if (valueAAO == "0")
                {
                    displayText = afterEqual.ToString();
                    calculation = afterEqual;
                }
                else
                {
                    calculation = Convert.ToDouble(valueAAO);
                    valueAAO = "0";
                    previousOperation = "-";
                }
                currentOperation = "-";
            }

            if (Display.Text == "0")
            {
                displayText = "0";
            }
            else if (Operation == false)
            {
                if (previousOperation == "+")
                {
                    calculation += Convert.ToDouble(valueAAO);

                    Arithmatic_Operations("-");
                }
                else if (previousOperation == "x")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                    }

                    calculation *= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("-");
                }
                else if (previousOperation == "/")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                        zerow = 1;
                    }

                    if (zerow == 0)
                    {
                        Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                        displayText = ""; //newly added on aug 22!
                        currentOperation = "="; //newly added on aug 22!
                    }
                    else
                    {
                        calculation /= Convert.ToDouble(valueAAO);
                        Arithmatic_Operations("-");
                    }
                }
                else
                {
                    if (previousOperation == "")
                    {
                        calculation = Convert.ToDouble(valueAAO);
                        valueAAO = "0";
                    }

                    calculation -= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("-");
                }

                Operation = true;
            }

            fraction = false;
        }

        private void Multiple_Click(object sender, EventArgs e)
        {
            zerow = double.Parse(valueAAO);
            stkO = 0;

            if (previousOperation == "<=")
            {
                calculation = Convert.ToDouble(valueAAO);
                valueAAO = "0";
            }
            else if (previousOperation == "%")
            {
                displayText = afterEqual.ToString();
                calculation = afterEqual;
                currentOperation = "x";
            }
            else if (previousOperation == "=")
            {
                if (valueAAO == "0")
                {
                    displayText = afterEqual.ToString();
                    calculation = afterEqual;
                }
                else
                {
                    calculation = Convert.ToDouble(valueAAO);
                    valueAAO = "0";
                }
                currentOperation = "x";
            }

            if (Display.Text == "0")
            {
                displayText = "0";
            }
            else if (Operation == false)
            {
                if (previousOperation=="")
                {
                    calculation = 1;
                }

                if(previousOperation == "/")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                        zerow = 1;
                    }

                    if (zerow == 0)
                    {
                        Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                        displayText = ""; //newly added on aug 22!
                        currentOperation = "="; //newly added on aug 22!
                    }
                    else
                    {
                        calculation /= Convert.ToDouble(valueAAO);
                        displayValue = calculation;
                        valueAAO = "0";
                        currentOperation = "x";
                    }
                }
                if (previousOperation == "-")
                {
                    calculation -= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("x");
                }
                else if (previousOperation == "+")
                {
                    calculation += Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("x");
                }
                else
                {
                    if (previousOperation == "")
                    {
                        calculation = 1;
                    }

                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                    }

                    calculation *= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("x");
                }

                Operation = true;
            }

            fraction = false;
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            zerow = double.Parse(valueAAO);
            stkO = 0;

            if (previousOperation=="<=")
            {
                calculation = Convert.ToDouble(valueAAO);
                valueAAO = "0";
            }
            else if (previousOperation == "%")
            {
                displayText = afterEqual.ToString();
                calculation = afterEqual;
                currentOperation = "/";
            }
            else if (previousOperation == "=")
            {
                if (valueAAO == "0")
                {
                    displayText = afterEqual.ToString();
                    calculation = afterEqual;
                }
                else
                {
                    calculation = Convert.ToDouble(valueAAO);
                    valueAAO = "0";
                    previousOperation = "/";
                }
                currentOperation = "/";
            }

            if (displayText == "")
            {
                displayText = "0";
            }
            else if (Operation == false)
            {
                if (previousOperation == "x")
                {
                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                    }

                    calculation *= Convert.ToDouble(valueAAO);
                    displayValue = calculation;
                    valueAAO = "0";
                    currentOperation = "/";
                }
                if (previousOperation == "-")
                {
                    calculation -= Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("/");
                }
                else if (previousOperation == "+")
                {
                    calculation += Convert.ToDouble(valueAAO);
                    Arithmatic_Operations("/");
                }
                else
                {
                    if (previousOperation == "")
                    {
                        if (currentOperation == "SRFTP")
                        {
                            zerow = 1;
                        }
                        else
                        {
                            calculation = Convert.ToDouble(valueAAO);
                            valueAAO = "1";
                            zerow = 1;
                        }
                    }

                    if (valueAAO == "0")
                    {
                        valueAAO = "1";
                        zerow = 1;
                    }

                    if (zerow == 0)
                    {
                        Display.Text = displayText + "\r\n\r\n\r\n\r\n" + "Cannot Divide by Zero!!";
                        displayText = ""; //newly added on aug 22!
                        currentOperation = "="; //newly added on aug 22!
                    }
                    else
                    {
                        calculation /= Convert.ToDouble(valueAAO);
                        Arithmatic_Operations("/");
                    }
                }

                Operation = true;
            }

            fraction = false;
        }


        private void Arithmatic_Operations(string sign)
        {
            displayValue = calculation;
            afterEqual = calculation;
            Display_String(sign);
            displayText += sign;
            valueAAO = "0";
            currentOperation = sign;
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            if (previousOperation == "=")
            {
                displayText = afterEqual.ToString();
                displayText += "$";
                valueAAO = calculation.ToString();
                previousOperation = "<=";
                Operation = false;
            }
            if (displayText != "")
            {
                int dspTL = displayText.Length;
                dspTL--;
                string newDS = "";
                string newValS = "";
                string eValueAAO = "0";
                string tnB = "";
                char eraserOperation = '@';
                double newVal = 0;

                if (!Char.IsDigit(displayText[dspTL])&&(displayText[dspTL]!='$')&&(displayText[dspTL] != '.'))
                {
                    for (int m = dspTL - 1; m >= 0; m--)
                    {
                        if (Char.IsDigit(displayText[m]) || (displayText[m] == '.'))
                        {
                            newDS += displayText[m];
                        }
                        else
                        {
                            eraserOperation = displayText[m];
                            break;
                        }
                    }

                    for (int z = newDS.Length - 1; z >= 0; z--)
                    {
                        newValS += newDS[z];
                    }

                    newVal = Convert.ToDouble(newValS);

                    if (eraserOperation == 'x')
                    {
                        calculation /= newVal;
                        valueAAO = newValS;
                        previousOperation = "x";
                        currentOperation = "x";
                    }
                    else if (eraserOperation == '/')
                    {
                        calculation *= newVal;
                        valueAAO = newValS;
                        previousOperation = "/";
                        currentOperation = "/";
                    }
                    else if (eraserOperation == '+')
                    {
                        calculation -= newVal;
                        valueAAO = newValS;
                        previousOperation = "+";
                        currentOperation = "+";
                    }
                    else if (eraserOperation == '-')
                    {
                        calculation += newVal;
                        valueAAO = newValS;
                        previousOperation = "-";
                        currentOperation = "-";
                    }

                    Operation = false;
                }
                else
                {
                    int valL = valueAAO.Length;
                    valL--;

                    for (int s = 0; s < valL; s++)
                    {
                        eValueAAO += valueAAO[s];
                    }
                    valueAAO = eValueAAO;
                }

                if(displayText[dspTL]=='.')
                {
                    fraction = false;
                }

                for (int z = 0; z < dspTL; z++)
                {
                    tnB += displayText[z];
                }
                displayText = tnB;

                if (previousOperation == "<=")
                {
                    valueAAO = displayText;
                }
                Display_String("");
            }
            else
            {
                displayText = "";
                valueAAO = "0";
                stkO = 0;
                zerow = 1;
                Display.Text = "0";
                afterEqual = 0;
                displayValue = 0;
                calculation = 0;
                currentOperation = "";
                previousOperation = "";
                stuckOperator = "";
                Operation = true;
                fraction = false;
            }
        }

        private void Zero_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == (char)Keys.NumPad0)
            {
                //Zero_Click(null, null);
                Zero.PerformClick();
                e.Handled = true;
            }*/
        }

        private void One_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(" key pressed");
            if (e.KeyChar == (char)Keys.D1)
            {
                One_Click(null, null);
                MessageBox.Show("1 key pressed");
            }
            if (e.KeyChar == 1)
            {
                MessageBox.Show("1 key pressed");
            }
            Display_KeyPress("1");
        }

        private void Squire_Click(object sender, EventArgs e)
        {
            if (previousOperation == "")
            {
                calculation = Convert.ToDouble(valueAAO);
                calculation *= calculation;
                afterEqual = calculation;
                valueAAO = calculation.ToString();
                Display.Text = displayText + "^2" + "\r\n\r\n\r\n\r\n" + calculation;
                history += displayText + "^2  = " + afterEqual + "\r\n";
                displayText = "";
                currentOperation = "="; //added on aug 22,2017!!!!
                previousOperation = "=";
                valueAAO = "0";
            }
            else if(Operation==false)
            {
                if ((previousOperation == "=")||(previousOperation=="%")) //new logic
                {
                    double aE = 0;
                    if (valueAAO == "0")
                    {
                        aE = afterEqual;
                        afterEqual *= afterEqual;
                    }
                    else
                    {
                        aE = Convert.ToDouble(valueAAO);
                        afterEqual=aE;
                        afterEqual *= afterEqual;
                    }
                    currentOperation = "=";
                    previousOperation = "=";
                    Display.Text = aE.ToString() + "^2" + "\r\n\r\n\r\n\r\n" + afterEqual;
                    history += aE.ToString() + "^2  = " + afterEqual + "\r\n";
                    displayText = "";
                    valueAAO = "0";
                }
                else //if (Operation == false)
                {
                    double squire = Convert.ToDouble(valueAAO);
                    string newDS = "";
                    int newDSL = 0;
                    squire *= squire;
                    int dTLen = displayText.Length;
                    dTLen--;
                    for(int m=dTLen;m>0;m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for(int m=0;m<=newDSL;m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += squire.ToString();
                    valueAAO = squire.ToString();
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + squire;
                }
            }
        }

        private void Display_String(string sign)
        {
            Display.Text = displayText + sign + "\r\n\r\n\r\n\r\n" + calculation;   
        }

        private void RootOver_Click(object sender, EventArgs e)
        {
            double SqrtNumber = 0;

            if (previousOperation == "")
            { 
                calculation = Convert.ToDouble(valueAAO);
                SqrtNumber = Math.Sqrt(calculation);
                calculation = SqrtNumber;
                //afterEqual = calculation;
                Display.Text = "√" + displayText + "\r\n\r\n\r\n\r\n" + calculation;
                history += "√" + displayText + " = " + afterEqual + "\r\n";
                previousOperation = "√";
                displayText = calculation.ToString();
                valueAAO = "0";
            }
            else if (Operation == false)
            {
                if (previousOperation == "=") //new logic
                {
                    double aE = afterEqual;
                    SqrtNumber = Math.Sqrt(afterEqual);
                    afterEqual = SqrtNumber;
                    Display.Text = "√" + aE.ToString() + "\r\n\r\n\r\n\r\n" + afterEqual;
                    history += "√" + aE.ToString() + " = " + afterEqual + "\r\n";
                    displayText = afterEqual.ToString();
                    valueAAO = "0";
                }
                else //if (Operation == false)
                {
                    SqrtNumber= Convert.ToDouble(valueAAO);
                    SqrtNumber = Math.Sqrt(SqrtNumber);
                    string newDS = "";
                    int newDSL = 0;
                    int dTLen = displayText.Length;
                    dTLen--;
                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += SqrtNumber.ToString();
                    valueAAO = SqrtNumber.ToString();
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + SqrtNumber;
                }
            }
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            if (fraction == false)
            {
                Display_KeyPress(".");
                fraction = true;
            }
        }

        private void ToThePoer_Click(object sender, EventArgs e)
        {
            if (previousOperation == "")
            {
                calculation = Convert.ToInt32(valueAAO);
                Display.Text = displayText + "^2" + "\r\n\r\n\r\n\r\n" + calculation;
                previousOperation = "^";
                valueAAO = "0";
            }
            else if (Operation == false)
            {
                if (valueAAO == "0")
                {
                    calculation *= calculation;
                    previousOperation = "=";
                    Display.Text = displayText + "^2" + "\r\n\r\n\r\n\r\n" + calculation;
                    displayText = calculation.ToString();
                    valueAAO = "0";
                }
                /*else if (previousOperation == "=")
                {
                    calculation *= calculation;
                    //currentOperation = "^";
                    //displayText = calculation.ToString();

                    previousOperation = "";
                    Display.Text = displayText + "^2" + "\r\n\r\n\r\n\r\n" + calculation;
                    valueAAO = "0";
                    displayText = calculation.ToString();
                    //calculation = 0;
                }
                else //if (Operation == false)
                {
                    //int squire = Convert.ToInt32(valueAAO);
                    double squire = Convert.ToDouble(valueAAO);
                    string newDS = "";
                    int newDSL = 0;
                    squire *= squire;
                    int dTLen = displayText.Length;
                    dTLen--;
                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += squire.ToString();
                    valueAAO = squire.ToString();
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + squire;
                }*/
            }

            //currentOperation = "SRFTP"; //Might be dengerous in adding!!!
        }

        private void Factorial_Click(object sender, EventArgs e)
        {
            double loop = 0;

            if (previousOperation == "")
            {
                calculation = 1;
                for (double m = double.Parse(valueAAO); m >=1; m--)
                {
                    calculation *= m;
                }
                valueAAO = calculation.ToString();
                Display.Text = displayText + "!" + "\r\n\r\n\r\n\r\n" + calculation;
                history += displayText + "!  = " + afterEqual + "\r\n";
                displayText = calculation.ToString();
                previousOperation = "!";
                valueAAO = "0";
            }
            else if (Operation == false)
            {
                //if (valueAAO == "0") //older logic!!!
                if (previousOperation == "=") //new logic
                {
                    double aE = afterEqual;
                    loop = afterEqual;
                    afterEqual = 1;

                    for (double m = loop; m >= 1; m--)
                    {
                        afterEqual *= m;
                    }
                    Display.Text = aE.ToString() + "!" + "\r\n\r\n\r\n\r\n" + afterEqual;
                    history += aE.ToString() + "!  = " + afterEqual + "\r\n";
                    displayText = afterEqual.ToString();
                    valueAAO = "0";
                }
                else //if (Operation == false)
                {
                    loop= Convert.ToDouble(valueAAO);
                    string newDS = "";
                    int newDSL = 0;
                    double valFac = 1;

                    for (double m = loop; m >= 1; m--)
                    {
                        valFac *= m;
                    }
                    int dTLen = displayText.Length;
                    dTLen--;
                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += valFac.ToString();
                    valueAAO = valFac.ToString();
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + valFac;
                }
            }
        }

        private void Percentage_Click(object sender, EventArgs e)
        {
            if(Operation==false)
            {
                double percentage = 0;

                if (currentOperation == "")
                {
                    calculation = Convert.ToDouble(valueAAO);
                    Display.Text = displayText + "% of " + "\r\n\r\n\r\n\r\n" + calculation;
                    //history += displayText + "!  = " + afterEqual + "\n";
                    valueAAO = "0";
                    displayText = "";
                    currentOperation = "%";
                    Operation = true;
                }
                else if ((previousOperation == "%")||(previousOperation == "="))//new!
                {
                    double per = 0;
                    percentage = afterEqual * Convert.ToDouble(valueAAO);
                    percentage /= 100;
                    per = Convert.ToDouble(valueAAO);
                    currentOperation = "=";
                    Display.Text = per + "% of " + afterEqual + "  is : " + "\r\n\r\n\r\n\r\n" + percentage;
                    history += per + "% of " + afterEqual + "  is : " + " " + percentage + "\r\n";
                    afterEqual = percentage;
                    valueAAO = "0";
                    displayText = "";
                }
                else if (previousOperation == "+")
                {
                    percentage = calculation * Convert.ToDouble(valueAAO);
                    percentage /= 100;

                    string newDS = "";
                    int newDSL = 0;
                    int dTLen = displayText.Length;
                    dTLen--;

                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += percentage.ToString();
                    calculation += percentage;
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + percentage;
                    valueAAO = "0";
                }
                else if (previousOperation == "-")
                {
                    percentage = calculation * Convert.ToDouble(valueAAO);
                    percentage /= 100;
                    string newDS = "";
                    int newDSL = 0;
                    int dTLen = displayText.Length;
                    dTLen--;

                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += percentage.ToString();
                    calculation -= percentage;
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + percentage;
                    valueAAO = "0";
                }
                else if (previousOperation == "x")
                {
                    percentage = calculation * Convert.ToDouble(valueAAO);
                    percentage /= 100;
                    string newDS = "";
                    int newDSL = 0;
                    int dTLen = displayText.Length;
                    dTLen--;

                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += percentage.ToString();
                    calculation *= percentage;
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + percentage;
                    valueAAO = "0";
                }
                else if (previousOperation == "/")
                {
                    percentage = calculation * Convert.ToDouble(valueAAO);
                    percentage /= 100;
                    string newDS = "";
                    int newDSL = 0;
                    int dTLen = displayText.Length;
                    dTLen--;

                    for (int m = dTLen; m > 0; m--)
                    {
                        if (!Char.IsDigit(displayText[m]))
                        {
                            newDSL = m;
                            break;
                        }
                    }

                    for (int m = 0; m <= newDSL; m++)
                    {
                        newDS += displayText[m];
                    }
                    displayText = newDS;
                    displayText += percentage.ToString();
                    calculation /= percentage;
                    Display.Text = displayText + "\r\n\r\n\r\n\r\n" + percentage;
                    valueAAO = "0";
                }
            }
        }

        private void Display_TextChanged(object sender, EventArgs e)
        {

        }

        private void History_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Recent Calculation : \n\n"+history);
            Display.Text = "Recent Calculation : \r\n" + history;
        }

        private void One_ControlAdded(object sender, ControlEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.NumPad7)
            //{
               // button1_Click(null, null);
            //}
        }

        private void Cal_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(" key pressed");
            if (e.KeyChar == (char)Keys.D1)
            {
                One_Click(null, null);
                MessageBox.Show("1 key pressed");
            }
        }
    }
}
