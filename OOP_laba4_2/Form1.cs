using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_laba4_2
{
    public partial class Form1 : Form
    {
        Model model;//модель
        
        public Form1()
        {
            InitializeComponent();

            model = new Model();//создаем модель

            //подписываемся на обновление модели
            model.observers1 += new System.EventHandler(this.UpdateFromModel1);
            model.observers2 += new System.EventHandler(this.UpdateFromModel2);
            model.observers3 += new System.EventHandler(this.UpdateFromModel3);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValue_1(Decimal.ToInt32(trackBar1.Value));//переплавляем значение в модель
        }

        
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (numericUpDown1.Text == "")
                {
                    model.setValue_1(10);
                }
                else
                {
                    model.setValue_1(Int32.Parse(numericUpDown1.Text));
                }
            }
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "")
            {
                model.setValue_1(10);
            }
            else
            {
                model.setValue_1(Int32.Parse(numericUpDown1.Text));
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                if (textBox1.Text == "")
                {
                    model.setValue_1(10);
                }
                else
                {
                    model.setValue_1(Int32.Parse(textBox1.Text));
                }
            }
        }

        

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValue_2(Decimal.ToInt32(trackBar2.Value));
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == "")
                {
                    model.setValue_2(50);
                }
                else
                {
                    model.setValue_2(Int32.Parse(textBox2.Text));
                }
            }
        }

        

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (numericUpDown2.Text == "")
                {
                    model.setValue_2(50);
                }
                else
                {
                    model.setValue_2(Int32.Parse(numericUpDown2.Text));
                }
            }
        }

        private void numericUpDown2_Leave(object sender, EventArgs e)
        {
            if (numericUpDown2.Text == "")
            {
                model.setValue_2(50);
            }
            else
            {
                model.setValue_2(Int32.Parse(numericUpDown2.Text));
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValue_3(Decimal.ToInt32(trackBar3.Value));
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text == "")
                {
                    model.setValue_3(90);
                }
                else
                {
                    model.setValue_3(Int32.Parse(textBox3.Text));
                }
            }
        }
       

        private void numericUpDown3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (numericUpDown3.Text == "")
                {
                    model.setValue_3(90);
                }
                else
                {
                    model.setValue_3(Int32.Parse(numericUpDown3.Text));
                }
            }
        }

        private void numericUpDown3_Leave(object sender, EventArgs e)
        {
            if (numericUpDown3.Text == "")
            {
                model.setValue_3(90);
            }
            else
            {
                model.setValue_3(Int32.Parse(numericUpDown3.Text));
            }
        }

        private void UpdateFromModel1(object sender, EventArgs e)
        {
            textBox1.Text = model.getValue_1().ToString();
            numericUpDown1.Value = model.getValue_1();
            progressBar1.Value = model.getValue_1();
            trackBar1.Value = Decimal.ToInt32(model.getValue_1());                
        }

        private void UpdateFromModel2(object sender, EventArgs e)
        {
            textBox2.Text = model.getValue_2().ToString();
            numericUpDown2.Value = model.getValue_2();
            progressBar2.Value = model.getValue_2();
            trackBar2.Value = Decimal.ToInt32(model.getValue_2());
        }

        private void UpdateFromModel3(object sender, EventArgs e)
        {
            textBox3.Text = model.getValue_3().ToString();
            numericUpDown3.Value = model.getValue_3();
            progressBar3.Value = model.getValue_3();
            trackBar3.Value = Decimal.ToInt32(model.getValue_3());
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                model.setValue_1(10);
            }
            else
            {
                model.setValue_1(Int32.Parse(textBox1.Text));
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                model.setValue_2(50);
            }
            else
            {
                model.setValue_2(Int32.Parse(textBox2.Text));
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                model.setValue_3(90);
            }
            else
            {
                model.setValue_3(Int32.Parse(textBox3.Text));
            }
        }
    }


    public class Model
    {
        private int value_1= 10, value_2=50, value_3=90;

        public System.EventHandler observers1;
        public System.EventHandler observers2;
        public System.EventHandler observers3;

        public void setValue_1(int value_1)
        {
            if (value_1 >= 0 && value_1 <= 100)
            {
                this.value_1 = value_1;                
                if (this.value_1 >= this.value_2)
                {
                    this.value_2 = this.value_1;                    
                    if (this.value_1 >= this.value_3)
                    {
                        this.value_3 = this.value_1;                        
                    }
                }
            }
            
            if (value_1 >= 0 && value_1 <= 100)
            {
                observers1.Invoke(this, null);
                observers2.Invoke(this, null);
                observers3.Invoke(this, null);
            }
            
        }

        public int getValue_1()
        {
            return value_1;
        }
        

        public void setValue_2(int value_2)
        {            
            if (value_2 >= value_1 && value_2 <= value_3)
            {
                this.value_2 = value_2;
            }
            observers2.Invoke(this, null);
        }

        public int getValue_2()
        {
            return value_2;
        }


        public void setValue_3(int value_3)
        {
            if (value_3 >= 0 && value_3 <= 100)
            {
                this.value_3 = value_3;                
                if (this.value_3 <= this.value_2)
                {
                    this.value_2 = this.value_3;                    
                    if (this.value_3 <= this.value_1)
                    {
                        this.value_1 = this.value_3;                        
                    }
                }
            }

            if (value_3 >= 0 && value_3 <= 100)
            {
                observers1.Invoke(this, null);
                observers2.Invoke(this, null);
                observers3.Invoke(this, null);
            }
        }

        public int getValue_3()
        {
            return value_3;
        }
    }
}
