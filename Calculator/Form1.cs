using System;
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
        static string oper = string.Empty;
        static bool point = false;
        //int dotNum = 0;
        //double dblNum = 0;
        bool takeEqual = false;

        private void DisPlay(int num)
        {
            //显示要考虑的问题： 是否包含小数，是否存在数字在显示屏幕上
            if(point)
            {
                //dotNum++;
                if (Tex_ShowResult.Text == "0")
                {
                    Tex_ShowResult.Text = "0." + num.ToString();
                }
                else
                {
                    Tex_ShowResult.Text = Tex_ShowResult.Text + "." + num.ToString();
                }
                point = false;
                //if (Tex_ShowResult.Text != "0")
                //{

                //    //Tex_ShowResult.Text = Convert.ToString(Convert.ToDouble(Tex_ShowResult)) + num / (Math.Pow(10, dotNum));
                //}
            }
            else //不包含小数点
            {
                if (Tex_ShowResult.Text == "0")
                {
                    Tex_ShowResult.Text = num.ToString();

                }
                else
                {
                    if (takeEqual == true)
                    {
                        Tex_ShowResult.Text = num.ToString();
                        takeEqual = false;
                    }
                    else
                    {
                        Tex_ShowResult.Text += num.ToString();
                    }

                }
                //Tex_ShowResult.Text = Tex_ShowResult.Text.Substring(0, Tex_ShowResult.Text.Length - 1);
                //Tex_ShowResult.Text = Convert.ToString(Convert.ToDouble(Tex_ShowResult.Text) * 10 + num);
                //Tex_ShowResult.Text += ".";
            }
        }             
        private void Btn_0_Click(object sender, EventArgs e)
        {
            DisPlay(0);
        }
        private void Btn_1_Click(object sender, EventArgs e)
        {
            //对于数字，只要显示数字即可
            //Tex_ShowResult.Text = Btn_1.Text;
            DisPlay(1);
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
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Operat("+");
        }
        private void Btn_Div_Click(object sender, EventArgs e)
        {
            Operat("/");
        }    
        private void Btn_Mul_Click(object sender, EventArgs e)
        {
            Operat("x");
        }
        private void Btn_Sub_Click(object sender, EventArgs e)
        {
            Operat("-");
        }
        private void Btn_Mod_Click(object sender, EventArgs e)
        {
            Operat("%");
        }
        private void Btn_Sign_Click(object sender, EventArgs e)
        {
            Tex_ShowResult.Text = Convert.ToString(double.Parse(Tex_ShowResult.Text) * -1);
        }
        
        /// <summary>
        /// 操作符定义
        /// </summary>
        /// <param name="sign"></param>
        private void Operat(string sign)
        {
            dblNumA = double.Parse(Tex_ShowResult.Text);
            point = false;
            //Tex_ShowResult.Text = "0";
            oper = sign;
            takeEqual = true;
        }
        private void Btn_Eq_Click(object sender, EventArgs e)
        {
            //if(takeEqual)
            //{
                //dblNum = dblNumB = double.Parse(Tex_ShowResult.Text);
            dblNumB = double.Parse(Tex_ShowResult.Text);
            switch(oper)
            {
                case "+": Tex_ShowResult.Text = (dblNumA + dblNumB).ToString();
                    break;
                case "-": Tex_ShowResult.Text = (dblNumA - dblNumB).ToString();
                    break;
                case "x": Tex_ShowResult.Text = (dblNumA * dblNumB).ToString();
                    break;
                case "/":
                    if (dblNumB == 0)
                    {
                        MessageBox.Show("除数为零，操作不合法！");
                    }
                    else
                    {
                        Tex_ShowResult.Text = (dblNumA / dblNumB).ToString();
                    }
                    break;
                case "%":
                    Tex_ShowResult.Text = (dblNumA % dblNumB).ToString();
                    break;
            }
                
                
                //else if (double.Parse(Tex_ShowResult.Text) == Convert.ToInt64(double.Parse(Tex_ShowResult.Text)) &&
                //     0 != double.Parse(Tex_ShowResult.Text))
                //{
                //    Tex_ShowResult.Text += ".";
                //}
                //else WorkLikeFront();
                takeEqual = false;
            //}            
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Tex_ShowResult.Text = "0";
            oper = string.Empty;
            point = false;
            dblNumA = 0;
            takeEqual = false;
        }

        /// <summary>
        /// 连续敲击等号，会进行同样的操作
        /// </summary>
        //private void WorkLikeFront()
        //{
        //    double dblNumB2 = double.Parse(Tex_ShowResult.Text);
        //    if (oper == "+")
        //    {
        //        Tex_ShowResult.Text = Convert.ToString(dblNumA + dblNumB);
        //    }
        //    if (oper == "-")
        //    {
        //        Tex_ShowResult.Text = Convert.ToString(dblNumA - dblNumB);
        //    }
        //    if (oper == "x")
        //    {
        //        Tex_ShowResult.Text = Convert.ToString(dblNumA * dblNumB);
        //    }
        //    if (oper == "/")
        //    {
        //        Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
        //    }
        //    if (oper == "+")
        //    {
        //        if (dblNumB == 0)
        //        {
        //            MessageBox.Show("除数为零，非法操作！");
        //        }
        //        else
        //        {
        //            Tex_ShowResult.Text = Convert.ToString(dblNumA / dblNumB);
        //        }
        //    }
        //    if (oper == "%")
        //    {
        //        Tex_ShowResult.Text = Convert.ToString(dblNumA % dblNumB);
        //    }
        //    else if (double.Parse(Tex_ShowResult.Text) == Convert.ToInt64(double.Parse(Tex_ShowResult.Text)) &&
        //         0 != double.Parse(Tex_ShowResult.Text))
        //    {
        //        Tex_ShowResult.Text += ".";
        //    }
        //}

        /// <summary>
        /// 小数点的使用，要考虑的问题，不可重复使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Dot_Click(object sender, EventArgs e)
        {
            if (Tex_ShowResult.Text.Contains("."))
            {
                point = false;
            }
            else
            {
                point = true;
            }
            
        }
    }
}
