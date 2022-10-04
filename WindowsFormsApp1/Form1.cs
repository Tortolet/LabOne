using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false; // выключить кнопку по умолчанию
            button2.Enabled = false; // выключить кнопку по умолчанию
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // при изменении текстбокса блокирование/разблокирование кнопки + обнуления результат.
        {
            label2.Text = "";
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') // разрешает использовать символы от 0 до 9.
                return;
            if (e.KeyChar == (char)Keys.Back) // разрешает использовать backspace.
                return;
            e.KeyChar = '\0'; // если условия не совпадают ничего не вводить.
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            int number;
            number = Convert.ToInt32(textBox1.Text);
            label2.Text = Convert.ToString(S.checkSimpleNumber(number) ? "Это простое число." : "Это не простое число."); // вывод метода по определению простого числа
            // исключения
            if (number == 1)
            {
                label2.Text = "Единица не является ни простым число, ни составным.";
            }
            if (number == 0)
            {
                label2.Text = "Ноль не является ни простым число, ни составным.";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                button2.Enabled = true;
            }
            else
                button2.Enabled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') // разрешает использовать символы от 0 до 9.
                return;
            if (e.KeyChar == (char)Keys.Back) // разрешает использовать backspace.
                return;
            e.KeyChar = '\0'; // если условия не совпадают ничего не вводить.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = ""; // пр повторном нажатии на кнопку обновляет результат.
            int a, b;
            string text = "";
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            a = Convert.ToInt32(textBox2.Text);
            b = Convert.ToInt32(textBox3.Text);
            try
            {
                // метод для вывода простых чисел в диапозоне.
                int[] arrayX = S.checkSimpleNumberInterval(a, b);
                for (int i = 0; i < arrayX.Length; i++)
                {
                    text += arrayX[i].ToString() + ", ";
                }
                textBox4.Text = text.Remove(text.Length - 2) + '.';
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
