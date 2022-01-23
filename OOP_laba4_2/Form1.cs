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
        ModelA model1;
        ModelB model2;
        ModelC model3;

        public Form1()
        {
            InitializeComponent();

            model1 = new ModelA();
            model2 = new ModelB();
            model3 = new ModelC();
            model1.observers1 += new System.EventHandler(this.UpdateFromModel1);
            model2.observers2 += new System.EventHandler(this.UpdateFromModel2);
            model3.observers3 += new System.EventHandler(this.UpdateFromModel3);

            trackBar1.Scroll += trackBar1_Scroll;
            trackBar2.Scroll += trackBar2_Scroll;
            trackBar3.Scroll += trackBar3_Scroll;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model1.setValue(Decimal.ToInt32(trackBar1.Value));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model1.setValue(Decimal.ToInt32(numericUpDown1.Value));
        }     

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model1.setValue(Int32.Parse(textBox1.Text));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model2.setValue(Decimal.ToInt32(trackBar2.Value));
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model2.setValue(Int32.Parse(textBox2.Text));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model2.setValue(Decimal.ToInt32(numericUpDown2.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model3.setValue(Decimal.ToInt32(trackBar3.Value));
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model3.setValue(Int32.Parse(textBox3.Text));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model3.setValue(Decimal.ToInt32(numericUpDown3.Value));
        }

        private void UpdateFromModel1(object sender, EventArgs e)
        {
            textBox1.Text = model1.getValue().ToString();
            numericUpDown1.Value = model1.getValue();
            progressBar1.Value = model1.getValue();
            trackBar1.Value = Decimal.ToInt32(model1.getValue());                
        }

        private void UpdateFromModel2(object sender, EventArgs e)
        {
            textBox2.Text = model2.getValue().ToString();
            numericUpDown2.Value = model2.getValue();
            progressBar2.Value = model2.getValue();
            trackBar2.Value = Decimal.ToInt32(model2.getValue());
        }

        private void UpdateFromModel3(object sender, EventArgs e)
        {
            textBox3.Text = model3.getValue().ToString();
            numericUpDown3.Value = model3.getValue();
            progressBar3.Value = model3.getValue();
            trackBar3.Value = Decimal.ToInt32(model3.getValue());
        }

        
    }


    public class ModelA
    {
        private int value_1;
        public System.EventHandler observers1;
        
        public void setValue(int value_1)
        {
            if (value_1 % 2 == 1)
                this.value_1 = value_1 + 1;
            else
                this.value_1 = value_1;

            observers1.Invoke(this, null);            
        }
        public int getValue()
        {
            return value_1;
        }
    }

    public class ModelB
    {
        private int value_2;        
        public System.EventHandler observers2;

        public void setValue(int value_2)
        {
            if (value_2 % 2 == 1)
                this.value_2 = value_2 + 1;
            else
                this.value_2 = value_2;

            observers2.Invoke(this, null);
        }
        public int getValue()
        {
            return value_2;
        }
    }

    public class ModelC
    {
        private int value_3;
        public System.EventHandler observers3;

        public void setValue(int value_3)
        {
            if (value_3 % 2 == 1)
                this.value_3 = value_3 + 1;
            else
                this.value_3 = value_3;

            observers3.Invoke(this, null);
        }
        public int getValue()
        {
            return value_3;
        }
    }
}
