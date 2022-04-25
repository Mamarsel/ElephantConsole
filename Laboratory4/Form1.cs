using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory4
{
    public partial class Form1 : Form
    {
        private Stack<Operator> operators = new Stack<Operator>();

        private Stack<Operand> operands = new Stack<Operand>();
        bool so = false; bool sc = false;

        private bool IsNotOperation(char item)
        {
            if (!(item == 'C' || item == 'D' || item == 'M' || item == ',' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.LightGreen, 2f);
            Init.bitmap = bitmap;
            Init.pen = pen;
            Init.pictureBox = pictureBox1;
        }
        private int ConvertCharToInt(object item)
        {
            
                return Convert.ToInt32(Convert.ToString(item)); 
            
        }
        bool flag = true;
        Elephant elephant;
        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'C')
            {
                try
                {
                    int s = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int y = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int x = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    string name = Convert.ToString(operands.Peek().value);
                    elephant = new Elephant(s, y, x, name);
                    op = new Operator(elephant.Draw, 'C');
                    ShapeContain.AddFigure(elephant);
                    op.operatorMethod();
                    comboBox1.Items.Add("Создание фигуры " + name);
                }
                catch { }
            }
            if (op.symbolOperator == 'M')
            {
                try
                {
                    int y = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    int x = Convert.ToInt32(Convert.ToString(operands.Pop().value));
                    string name = Convert.ToString(operands.Pop().value);
                    if (ShapeContain.FindFigure(name) != null)
                    { 
                        string CB = "Перемещение фигуры  " + name;
                        comboBox1.Items.Add(CB);
                        ShapeContain.FindFigure(name).MoveTo(y, x);
                    }
                    
                }
                catch { }
            }
            if (op.symbolOperator == 'D')
            {
               
                try
                {
                    string name = Convert.ToString(operands.Pop().value);
                    if (ShapeContain.FindFigure(name) != null)
                    {
                        
                        ShapeContain.FindFigure(name).DeleteF(ShapeContain.FindFigure(name), false);
                        comboBox1.Items.Add("Удаление фигуры " + name);
                    }
                }
                catch { }  
            }

        }
        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    operators = new Stack<Operator>();
                    operands = new Stack<Operand>();
                    for (int i = 0; i < textBoxInputString.Text.Length; i++)
                    {
                        if (IsNotOperation(textBoxInputString.Text[i]))
                        {
                            if (!(Char.IsDigit(textBoxInputString.Text[i])))
                            {
                                this.operands.Push(new Operand(textBoxInputString.Text[i]));
                                continue;
                            }
                            else if (Char.IsDigit(textBoxInputString.Text[i]))
                            {
                                if (flag)
                                {
                                    this.operands.Push(new Operand(textBoxInputString.Text[i]));
                                }
                                else
                                {
                                    if (!(Char.IsDigit(textBoxInputString.Text[i - 1])))
                                    {
                                        this.operands.Push(new Operand(ConvertCharToInt(textBoxInputString.Text[i])));
                                        continue;
                                    }
                                    this.operands.Push(new Operand(ConvertCharToInt(this.operands.Pop().value) * 10 + ConvertCharToInt(textBoxInputString.Text[i]))); 
                                }
                                flag = false;
                                continue;
                            }
                        }
                        else if (textBoxInputString.Text[i] == ',')
                        {
                            flag = true;
                            continue;
                        }
                        else if (textBoxInputString.Text[i] == 'C')
                        {
                            this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (textBoxInputString.Text[i] == 'M')
                        {
                            this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (textBoxInputString.Text[i] == 'D')
                        {
                            this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (textBoxInputString.Text[i] == '(')
                        {
                            so = true;
                        }
                        else if (textBoxInputString.Text[i] == ')')
                        {
                            sc = true;
                        }
                        else { MessageBox.Show("Введите правильно а"); }
                    }

                    if (!so || !sc) 
                    {MessageBox.Show("no"); return; }
                    so = false; sc = false;

                        SelectingPerformingOperation(operators.Peek());



                        
            }

        }
        bool Dop = true;

        private void textBoxInputString_TextChanged(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num = rand.Next(0, 26);
            char let = (char)('a' + num);
            int x = rand.Next(400); int y = rand.Next(400); int s = rand.Next(100);
            if (Dop)
            {
                if (textBoxInputString.Text[0] == 'C')
                {
                    textBoxInputString.Text = "C" + '(' + Convert.ToString(let) + ',' + Convert.ToString(x) + ',' + Convert.ToString(y) + ',' + Convert.ToString(s) + ')'; ;
                    Dop = false;
                }

                else if (textBoxInputString.Text[0] == 'M')
                {
                    textBoxInputString.Text = "M" + '(' + Convert.ToString(let) + ',' + Convert.ToString(x) + ',' + Convert.ToString(y) + ')';
                    Dop = false;
                }

                else if (textBoxInputString.Text[0] == 'D')
                {
                    textBoxInputString.Text = "D" + '(' + Convert.ToString(let) + ')';
                    Dop = false;
                }
            }
            
        }
    }
}
