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
        int n;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            // кол-во строчек
            dataGridView1.RowCount = 1;

            // кол-во столбцов
            dataGridView1.ColumnCount = 5;

            // значение для numericUpDown
            numericUpDown1.Value = 5; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // заполнение названия ячеек
            for (int i = 0; i < dataGridView1.ColumnCount; i++) 
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = 1;

            // устанавливаем количество колонок
            dataGridView1.ColumnCount = n; 
            for (int i = 0; i < n; i++)
            {
                // строка заголовков столбцов
                dataGridView1.Columns[i].Name = (i + 1).ToString();  
                if (radioButton2.Checked)
                {
                    // заполняет таблицу случайными значениями
                    dataGridView1.Rows[0].Cells[i].Value = r.Next(0, 100);  
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // возможность изменять вручную ячейки
            dataGridView1.ReadOnly = false; 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // возможность только смотреть и читать ячейки без изменений вручную
            dataGridView1.ReadOnly = true; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            n = Convert.ToInt32(numericUpDown1.Value);
            for (int i = 0; i < n; i++)
                dataGridView1.Rows[0].Cells[i].Value = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // локальный массив
                int[] arr = new int[dataGridView1.ColumnCount];

                // заполнение массива
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    arr[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);

                // поиск первого минимального значения
                int min2 = Class1.Min(arr, out int min1);

                // вывод первого минимального элемента
                label1.Text = "Первый элемент: " + (min1 + 1).ToString() + " значение = " + min2.ToString();

                // поиск второго минимального значения
                int min4 = Class1.MinSecond(arr, out int min3); 
                int min5 = 0;
                if (min4 == min2)
                {
                    // если последний элемент массива равен первому минимальному значению, то вызывается данный метод, для поиска второго минимального значения
                    min5 = Class1.MinSecondHelp(arr, out min3); 
                }

                // вывод второго минимального элемента
                if (min4 != min2)
                    label1.Text += "\nВторой элемент: " + (min3 + 1).ToString() + " значение = " + min4.ToString();
                else
                    label1.Text += "\nВторой элемент: " + (min3 + 1).ToString() + " значение = " + min5.ToString();

                // заполнение и расчет до первого минмиального значения
                dataGridView2.RowCount = dataGridView1.RowCount;
                dataGridView2.ColumnCount = dataGridView1.ColumnCount;
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    dataGridView2.Columns[i].Name = (i + 1).ToString();
                    dataGridView2.Rows[0].Cells[i].Value = dataGridView1.Rows[0].Cells[i].Value;
                }
                for (int i = 0; i < min1; i++)
                {
                    dataGridView2.Rows[0].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[0].Cells[i].Value) * 2;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            if(n == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            dataGridView1.RowCount = 1;

            // устанавливаем количество колонок
            dataGridView1.ColumnCount = n; 
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // разрешает использовать символы от 0 до 9.
            if (e.KeyChar >= '0' && e.KeyChar <= '9') 
                return;

            // разрешает использовать backspace.
            if (e.KeyChar == (char)Keys.Back) 
                return;
            // разрешает использовать Enter.
            if (e.KeyChar == (char)Keys.Enter) 
                return;

            // если условия не совпадают ничего не вводить.
            e.KeyChar = '\0'; 
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // разрешает использовать символы от 0 до 9.
            if (e.KeyChar >= '0' && e.KeyChar <= '9') 
                return;

            // разрешает использовать backspace.
            if (e.KeyChar == (char)Keys.Back) 
                return;

            // разрешает использовать Enter.
            if (e.KeyChar == (char)Keys.Enter) 
                return;

            // если условия не совпадают ничего не вводить.
            e.KeyChar = '\0'; 
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
        }
    }
}
