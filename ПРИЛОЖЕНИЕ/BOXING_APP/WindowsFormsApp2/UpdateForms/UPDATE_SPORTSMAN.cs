﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2.UpdateForms
{
    public partial class UPDATE_SPORTSMAN : Form
    {
        string[] mass = new string[] { "ФАМИЛИЯ", "ИМЯ", "ОТЧЕСТВО", "ДАТА_РОЖДЕНИЯ", "ПОЛ", "КАТЕГОРИЯ_ВЕСА", "НОМЕР_ГРУППЫ", "НОМЕР_ТРЕНЕРА", "МИН_КОЛ_ЧАС", "ПРИОРИТЕТ", "НОМЕР_ТЕЛЕФОНА", "НОМЕР_ПАРЫ", "ЛОГИН", "ПАРОЛЬ" };
        string del;
        string combo;
        string val;
        int intval;
        DateTime dateval;
        char charval;
        int delInt;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();

        public UPDATE_SPORTSMAN()
        {
            InitializeComponent();
            comboBox1.DataSource = mass;
            command.Connection = MyConDB.Connection;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void sd()
        {
            table.Clear();
            command.CommandText = "SELECT * FROM СПОРТСМЕНЫ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectAll();
        }
        private void UPDATE_SPORTSMAN_Load(object sender, EventArgs e)
        {
            sd();
        }
        private void UPDATE_SPORTSMAN_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyConDB.CloseConnection();
            this.Dispose();
            Array.Clear(mass, 0, 13);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //"ФАМИЛИЯ" 1, "ИМЯ" 2, "ОТЧЕСТВО" 3, "ДАТА_РОЖДЕНИЯ" 4, "ПОЛ" 5, "КАТЕГОРИЯ_ВЕСА" 6, "НОМЕР_ГРУППЫ" 7, "НОМЕР_ТРЕНЕРА" 8, "МИН_КОЛ_ЧАС" 9, "ПРИОРИТЕТ" 10, "НОМЕР_ТЕЛЕФОНА" 11, "НОМЕР_ПАРЫ" 12, "ЛОГИН" 13, "ПАРОЛЬ" 14
                if (comboBox1.Text.ToString() == mass[0].ToString() || comboBox1.Text.ToString() == mass[1].ToString() || comboBox1.Text == mass[2].ToString() || comboBox1.Text == mass[5].ToString() || comboBox1.Text == mass[9].ToString() || comboBox1.Text == mass[10].ToString() || comboBox1.Text == mass[12].ToString() || comboBox1.Text == mass[13].ToString())
                {
                    //varchar
                    del = НОМЕР.Text.ToString();
                    delInt = int.Parse(del);
                    combo = comboBox1.Text.ToString();
                    val = ЗНАЧЕНИЕ.Text.ToString();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE СПОРТСМЕНЫ SET " + comboBox1.Text + " = @ff1 WHERE НОМЕР_СПОРТСМЕНА = @num";
                    command.Parameters.Add("@ff1", SqlDbType.VarChar).Value = val;
                    command.Parameters.Add("@num", SqlDbType.Int).Value = delInt;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (comboBox1.Text == mass[6] || comboBox1.Text == mass[7] || comboBox1.Text == mass[8] || comboBox1.Text == mass[11])
                {
                    //int
                    del = НОМЕР.Text.ToString();
                    delInt = int.Parse(del);
                    combo = comboBox1.Text.ToString();
                    val = ЗНАЧЕНИЕ.Text.ToString();
                    intval = int.Parse(val);

                    command.CommandText = "UPDATE СПОРТСМЕНЫ SET " + comboBox1.Text + " = @ff1 WHERE НОМЕР_СПОРТСМЕНА = @num";
                    command.Parameters.Add("ff1", SqlDbType.Int).Value = intval;
                    command.Parameters.Add("num", SqlDbType.Int).Value = delInt;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (comboBox1.Text == mass[3])
                {
                    //date
                    del = НОМЕР.Text.ToString();
                    delInt = int.Parse(del);
                    combo = comboBox1.Text.ToString();
                    val = ЗНАЧЕНИЕ.Text.ToString();
                    intval = int.Parse(val);
                    dateval = DateTime.Parse(val);

                    command.CommandText = "UPDATE СПОРТСМЕНЫ SET " + comboBox1.Text + " = @ff1 WHERE НОМЕР_СПОРТСМЕНА = @num";
                    command.Parameters.Add("ff1", SqlDbType.Date).Value = intval;
                    command.Parameters.Add("num", SqlDbType.Int).Value = delInt;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (comboBox1.Text == mass[4])
                {
                    //char
                    del = НОМЕР.Text.ToString();
                    delInt = int.Parse(del);
                    combo = comboBox1.Text.ToString();
                    val = ЗНАЧЕНИЕ.Text.ToString();
                    charval = char.Parse(val);

                    command.CommandText = "UPDATE СПОРТСМЕНЫ SET " + comboBox1.Text + " = @ff1 WHERE НОМЕР_СПОРТСМЕНА = @num";
                    command.Parameters.Add("ff1", SqlDbType.Char).Value = charval;
                    command.Parameters.Add("num", SqlDbType.Int).Value = delInt;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                sd();
                MessageBox.Show("Запись успешно изменена!", "Статус изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка: запись не была изменена", "Статус изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
