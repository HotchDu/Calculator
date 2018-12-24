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
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        double dblNumA = 0;
        double dblNumB = 0;
        static string oper = "";
        static bool point = false;
        int dotNum = 0;
        double dblNum = 0;
        bool takeEqual = true;

        private void DisPlay(int num)
        {
            //显示要考虑的问题： 是否包含小数，是否存在数字在显示屏幕上
            if(point)
            {
                dotNum++;
                if(num == 0)
                {
                    Tex_ShowResult.Text += "0";
                }
                if(num != 0)
                {
                    Tex_ShowResult.Text = Convert.ToString(Convert.ToDouble(Tex_ShowResult)) + num / (Math.Pow(10, dotNum));
                }
            }
            else //不包含小数点
            {

                //Tex_ShowResult.Text = Tex_ShowResult.Text.Substring(0, Tex_ShowResult.Text.Length - 1);
                Tex_ShowResult.Text = Convert.ToString(Convert.ToDouble(Tex_ShowResult.Text) * 10 + num);
                Tex_ShowResult.Text += ".";
            }
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            //加法，累加多个数字
            //int temp = 0;
            //temp += int.Parse(Tex_ShowResult.Text);
            operat("+");
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            //对于数字，只要显示数字即可
            //Tex_ShowResult.Text = Btn_1.Text;
            DisPlay(1);
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            DisPlay(0);
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            DisPlay(2);
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            DisPlay(3);
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            DisPlay(4);
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            DisPlay(5);
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            DisPlay(6);
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            DisPlay(7);
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            DisPlay(8);
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            DisPlay(9);
        }

        private void operat(string sign)
        {
            dblNumA = double.Parse(Tex_ShowResult.Text);
            point = false;
            Tex_ShowResult.Text = "0.";
            oper = sign;
            takeEqual = true;
        }

        private void Btn_Div_Click(object sender, EventArgs e)
        {
            operat("/");
        }

        private void Btn_Mul_Click(object sender, EventArgs e)
        {
            operat("x");
        }

        private void Btn_Sub_Click(object sender, EventArgs e)
        {
            operat("-");
        }

        private void Btn_Mod_Click(object sender, EventArgs e)
        {
            operat("%");
        }

        private void Btn_Sign_Click(object sender, EventArgs e)
        {
            Tex_ShowResult.Text = Convert.ToString(double.Parse(Tex_ShowResult.Text) * -1);
        }

        private void Btn_Eq_Click(object sender, EventArgs e)
        {
            if(takeEqual)
            {
                dblNum = dblNumB = double.Parse(Tex_ShowResult.Text);
                if(oper == "+")
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA + dblNumB);
                }
                if (oper == "-")
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA - dblNumB);
                }
                if (oper == "x")
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA * dblNumB);
                }
                if (oper == "/")
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
                }
                if (oper == "+")
                {
                    if (dblNumB == 0)
                    {
                        MessageBox.Show("除数为零，非法操作！");
                    }
                    else
                    {
                        Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
                    }                    
                }
                if (oper == "%")
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA % dblNumB);
                }
                else if (double.Parse(Tex_ShowResult.Text) == Convert.ToInt64(double.Parse(Tex_ShowResult.Text)) &&
                     0 != double.Parse(Tex_ShowResult.Text))
                {
                    Tex_ShowResult.Text += ".";
                }
                else WorkLikeFront();
                takeEqual = false;
            }

            
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Tex_ShowResult.Text = "0";
            oper = "";
            point = false;
            dotNum = 0;
            dblNumA = 0;
            takeEqual = true;
        }


        private void WorkLikeFront()
        {
            double dblNumB2 = double.Parse(Tex_ShowResult.Text);
            if (oper == "+")
            {
                Tex_ShowResult.Text = Convert.ToString(dblNumA + dblNumB);
            }
            if (oper == "-")
            {
                Tex_ShowResult.Text = Convert.ToString(dblNumA - dblNumB);
            }
            if (oper == "x")
            {
                Tex_ShowResult.Text = Convert.ToString(dblNumA * dblNumB);
            }
            if (oper == "/")
            {
                Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
            }
            if (oper == "+")
            {
                if (dblNumB == 0)
                {
                    MessageBox.Show("除数为零，非法操作！");
                }
                else
                {
                    Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
                }
            }
            if (oper == "%")
            {
                Tex_ShowResult.Text = Convert.ToString(dblNumA % dblNumB);
            }
            else if (double.Parse(Tex_ShowResult.Text) == Convert.ToInt64(double.Parse(Tex_ShowResult.Text)) &&
                 0 != double.Parse(Tex_ShowResult.Text))
            {
                Tex_ShowResult.Text += ".";
            }
        }
    }
}
