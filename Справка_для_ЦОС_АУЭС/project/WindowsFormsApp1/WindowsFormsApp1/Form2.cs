using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;



namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public string dir;
        public string dir1;
        public string save_place = "C:\\";
        public string check, school;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Проверяем наличие файла
            if (File.Exists(dir))
            {
                //Создаём приложение.
                Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                //Открываем книгу.                                                                                                                                                       
                Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(dir, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Выбираем таблицу(лист).
                Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
                //Очищаем поля
                // textBox1.Clear();
                

                {
                    Excel.Range range, datebirth, lastname, name, otchestvo, kurs, form_study, address, group, facultet, school1;
                    range = ObjWorkSheet.get_Range("A:DY").Find(textBox1.Text, LookAt: Excel.XlLookAt.xlWhole);
                    datebirth = ObjWorkSheet.get_Range("A:DY").Find("Дата рождения", LookAt: Excel.XlLookAt.xlWhole);
                    lastname = ObjWorkSheet.get_Range("A:DY").Find("Фамилия", LookAt: Excel.XlLookAt.xlWhole);
                    name = ObjWorkSheet.get_Range("A:DY").Find("Имя", LookAt: Excel.XlLookAt.xlWhole);
                    otchestvo = ObjWorkSheet.get_Range("A:DY").Find("Отчество", LookAt: Excel.XlLookAt.xlWhole);
                    kurs = ObjWorkSheet.get_Range("A:DY").Find("Курс", LookAt: Excel.XlLookAt.xlWhole);
                    form_study = ObjWorkSheet.get_Range("A:DY").Find("Форма обучения", LookAt: Excel.XlLookAt.xlWhole);
                    address = ObjWorkSheet.get_Range("A:DY").Find("Адрес", LookAt: Excel.XlLookAt.xlWhole);
                    group = ObjWorkSheet.get_Range("A:DY").Find("	ID группы	", LookAt: Excel.XlLookAt.xlWhole);
                    facultet = ObjWorkSheet.get_Range("A:DY").Find("Факультет", LookAt: Excel.XlLookAt.xlWhole);
                    school1 = ObjWorkSheet.get_Range("A:DY").Find("Образование", LookAt: Excel.XlLookAt.xlWhole);


                    try
                    { //Добавляем текст из нужных ячеек.
                        textBox2.Text = ObjWorkSheet.get_Range(GetExcelColumnName(lastname.Column) + range.Row.ToString()).Value2;
                        textBox3.Text = ObjWorkSheet.get_Range(GetExcelColumnName(name.Column) + range.Row.ToString()).Value2;
                        textBox4.Text = ObjWorkSheet.get_Range(GetExcelColumnName(otchestvo.Column) + range.Row.ToString()).Value2;
                        textBox5.Text = ObjWorkSheet.get_Range(GetExcelColumnName(datebirth.Column) + range.Row.ToString()).Value2;
                        textBox7.Text = ObjWorkSheet.get_Range(GetExcelColumnName(kurs.Column) + range.Row.ToString()).Value2;
                        textBox8.Text = ObjWorkSheet.get_Range(GetExcelColumnName(form_study.Column) + range.Row.ToString()).Value2;
                        textBox10.Text = ObjWorkSheet.get_Range(GetExcelColumnName(address.Column) + range.Row.ToString()).Value2;
                        textBox16.Text = ObjWorkSheet.get_Range(GetExcelColumnName(facultet.Column) + range.Row.ToString()).Value2;
                        textBox17.Text = ObjWorkSheet.get_Range(GetExcelColumnName(group.Column) + range.Row.ToString()).Value2;
                        school = ObjWorkSheet.get_Range(GetExcelColumnName(school1.Column) + range.Row.ToString()).Value2;

                        // textBox17.Text = ObjWorkSheet.get_Range(GetExcelColumnName(group.Column) + range.Row.ToString()).Value2;
                        //это чтобы форма прорисовывалась (не подвисала)...
                        System.Windows.Forms.Application.DoEvents();

                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(
                       "Номер транскрипта отсутсвует в базе", "Ошибка"
                   );
                        
                    }

                    //Удаляем приложение (выходим из экселя) - ато будет висеть в процессах!
                    ObjWorkBook.Close();
                    ObjExcel.Quit();



                }
            }
            else
            {
                MessageBox.Show(
                    "Файл не выбран или отсутсвует в каталоге", "Ошибка"
                );
            }

        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        private void Prilozhenie4()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + ",";
            Doc.Bookmarks["DOB"].Range.Text = textBox5.Text + " г.";
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text;
            Doc.Bookmarks["FORM"].Range.Text = textBox8.Text;
            Doc.Bookmarks["YEAR"].Range.Text = textBox9.Text;
            Doc.Bookmarks["ADDRESS"].Range.Text = textBox10.Text;
            Doc.Bookmarks["TERM"].Range.Text = textBox11.Text;
            Doc.Bookmarks["START"].Range.Text = textBox12.Text;
            Doc.Bookmarks["END"].Range.Text = textBox13.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;
            Doc.Bookmarks["SIGNATURE1FIO"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox4.Text + " " + comboBox6.Text;
            Doc.Bookmarks["SIGNATURE2FIO"].Range.Text = comboBox7.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void Prilozhenie6()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + ",";
            Doc.Bookmarks["DOB"].Range.Text = textBox5.Text + " г.";
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text;
            Doc.Bookmarks["FORM"].Range.Text = textBox8.Text;
            Doc.Bookmarks["YEAR"].Range.Text = textBox9.Text;
            Doc.Bookmarks["ADDRESS"].Range.Text = textBox10.Text;
            Doc.Bookmarks["TERM"].Range.Text = textBox11.Text;
            Doc.Bookmarks["START"].Range.Text = textBox12.Text;
            Doc.Bookmarks["END"].Range.Text = textBox13.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;
            Doc.Bookmarks["SIGNATURE1FIO"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox4.Text + " " + comboBox6.Text;
            Doc.Bookmarks["SIGNATURE2FIO"].Range.Text = comboBox7.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void Prilozhenie9()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + ",";
            Doc.Bookmarks["DOB"].Range.Text = textBox5.Text + " г.";
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text;
            Doc.Bookmarks["FORM"].Range.Text = textBox8.Text;
            Doc.Bookmarks["YEAR"].Range.Text = textBox9.Text;
            Doc.Bookmarks["ADDRESS"].Range.Text = textBox10.Text;
            Doc.Bookmarks["TERM"].Range.Text = textBox11.Text;
            Doc.Bookmarks["START"].Range.Text = textBox12.Text;
            Doc.Bookmarks["END"].Range.Text = textBox13.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;
            Doc.Bookmarks["SIGNATURE1FIO"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox4.Text + " " + comboBox6.Text;
            Doc.Bookmarks["SIGNATURE2FIO"].Range.Text = comboBox7.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void Prilozhenie2()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + ",";
            Doc.Bookmarks["DOB"].Range.Text = textBox5.Text + " г.";
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text;
            Doc.Bookmarks["FORM"].Range.Text = textBox8.Text;
            Doc.Bookmarks["YEAR"].Range.Text = textBox9.Text;
            Doc.Bookmarks["ADDRESS"].Range.Text = textBox10.Text;
            Doc.Bookmarks["TERM"].Range.Text = textBox11.Text;
            Doc.Bookmarks["START"].Range.Text = textBox12.Text;
            Doc.Bookmarks["END"].Range.Text = textBox13.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;
            Doc.Bookmarks["SIGNATURE1FIO"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox4.Text + " " + comboBox6.Text;
            Doc.Bookmarks["SIGNATURE2FIO"].Range.Text = comboBox7.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void Prilozhenie2_1()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text+ ",";
            Doc.Bookmarks["DOB"].Range.Text = textBox5.Text + " г.";
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text;
            Doc.Bookmarks["FORM"].Range.Text = textBox8.Text;
            Doc.Bookmarks["YEAR"].Range.Text = textBox9.Text;
            Doc.Bookmarks["ADDRESS"].Range.Text = textBox10.Text;
            Doc.Bookmarks["TERM"].Range.Text = textBox11.Text;
            Doc.Bookmarks["START"].Range.Text = textBox12.Text;
            Doc.Bookmarks["END"].Range.Text = textBox13.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;
            Doc.Bookmarks["SIGNATURE1FIO"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox4.Text + " " + comboBox6.Text;
            Doc.Bookmarks["SIGNATURE2FIO"].Range.Text = comboBox7.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void Prilozhenie3()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
            Doc.Bookmarks["DOB1"].Range.Text = textBox5.Text;
            Doc.Bookmarks["DOB2"].Range.Text = textBox5.Text;
            Doc.Bookmarks["COURSE1"].Range.Text = textBox7.Text;
            Doc.Bookmarks["COURSE2"].Range.Text = textBox7.Text;
            Doc.Bookmarks["INSTITUTE1"].Range.Text = textBox16.Text;
            Doc.Bookmarks["INSTITUTE2"].Range.Text = textBox16.Text;
            Doc.Bookmarks["START1"].Range.Text = textBox20.Text;
            Doc.Bookmarks["START2"].Range.Text = textBox20.Text;
            Doc.Bookmarks["END1"].Range.Text = textBox21.Text;
            Doc.Bookmarks["END2"].Range.Text = textBox6.Text;
            Doc.Bookmarks["SIGNATURE1"].Range.Text = comboBox1.Text;          
            Doc.Bookmarks["SIGNATURE2"].Range.Text = comboBox3.Text;
            Doc.Bookmarks["UDO"].Range.Text = textBox23.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void StudSpravka()
        {
            Word.Application ObjWord = new Word.Application();
            Document Doc = ObjWord.Documents.Add(dir1);
            Doc.Bookmarks["FIO"].Range.Text = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;     
            Doc.Bookmarks["COURSE"].Range.Text = textBox7.Text+" курс, группа " + textBox17.Text;
            Doc.Bookmarks["INSTITUTE"].Range.Text = textBox16.Text+ ", ";
            Doc.Bookmarks["OBJECT"].Range.Text = "в " + textBox18.Text;
            Doc.SaveAs(FileName: save_place + "\\" + textBox2.Text + "_" + textBox3.Text + "_" + comboBox5.Text + "_For_print.docx");
            Doc.Close();
            ObjWord.Quit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dir = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    save_place = dialog.SelectedPath;

                    if (comboBox5.SelectedIndex == 0)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie4.docx";
                        Prilozhenie4();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 1)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie6.docx";
                        Prilozhenie6();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 2)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie9.docx";
                        Prilozhenie9();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 3)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie2.docx";
                        Prilozhenie2();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 4)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie2-1.docx";
                        Prilozhenie2_1();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 5)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Prilozhenie3.docx";
                        Prilozhenie3();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else if (comboBox5.SelectedIndex == 6)
                    {
                        dir1 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\StudSpravka.docx";
                        StudSpravka();
                        MessageBox.Show(
                               "Справка успешно создана!", "Сообщение"
                           );
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Выбран неправильный шаблон, попробуйте снова!", "Ошибка"
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Не выбран каталог для сохранения!", "Ошибка"
                    );
                }

        }



        private void Clear()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear();
            textBox11.Clear(); textBox12.Clear(); textBox13.Clear();
            textBox16.Clear(); textBox17.Clear(); textBox18.Clear(); textBox20.Clear();
            textBox21.Clear(); textBox23.Clear(); textBox6.Clear();
        }
       

        

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Приложение №4" || comboBox5.Text == "Приложение №6" || comboBox5.Text == "Приложение №2" || comboBox5.Text == "Приложение №2-1" || comboBox5.Text == "Приложение №9")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label16.Visible = false;
                comboBox1.Visible = true;
                comboBox4.Visible = true;
                comboBox3.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                textBox16.Visible = false;
                label15.Visible = false;
                textBox17.Visible = false;
                comboBox2.Visible = false;
                label17.Visible = false;
                textBox18.Visible = false;
                label18.Visible = false;
                textBox20.Visible = false;
                label19.Visible = false;
                label22.Visible = false;
                textBox21.Visible = false;
                label21.Visible = false;
                textBox23.Visible = false;
                label20.Visible = false;
                textBox6.Visible = false;

            }
           else if (comboBox5.Text == "Справка для школ и организаций")// Here
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                comboBox1.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox6.Visible=false;
                comboBox7.Visible = false;
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox16.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label15.Visible = true;
                textBox17.Visible = true;
                label16.Visible = true;
                comboBox2.Visible = true;
                label17.Visible = true;
                textBox18.Visible = true;
                label18.Visible = false;
                textBox20.Visible = false;
                label19.Visible = false;
                label22.Visible = false;
                textBox21.Visible = false;
                label21.Visible = false;
                textBox23.Visible = false;
                label20.Visible = false;
                textBox6.Visible = false;
            }
            else if (comboBox5.Text == "Справка на военную кафедру")// Here
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox16.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                comboBox1.Visible = true;
                comboBox4.Visible = false;
                comboBox3.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                label15.Visible = true;
                textBox17.Visible = true;
                label16.Visible = true;
                comboBox2.Visible = false;
                label17.Visible = false;
                textBox18.Visible = false;
                label18.Visible = true;
                textBox20.Visible = true;
                label19.Visible = true;
                label22.Visible = true;
                textBox21.Visible = true;
                textBox20.Visible = true;
                label21.Visible = true;
                textBox23.Visible = true;
                label20.Visible = true;
                textBox6.Visible = true;
            }
            else
            {
                button1.Visible = false;
                label15.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label16.Visible = false;
                comboBox1.Visible = false;
                comboBox4.Visible = false;
                comboBox3.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                label19.Visible = false;
                label22.Visible = false;
                label21.Visible = false;
                textBox23.Visible = false;
                textBox21.Visible = false;
                label20.Visible = false;
                textBox6.Visible = false;
            }
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Школа")
            {
                textBox18.Text = school;

            }
        }

        private void textBox1_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Form2_Load(object sender, EventArgs e) {
            string dir2 = AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\Signature.xlsx";
            string signature;
            Microsoft.Office.Interop.Excel.Application ObjExcel1 = new Microsoft.Office.Interop.Excel.Application();
            //Открываем книгу.                                                                                                                                                       
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook1 = ObjExcel1.Workbooks.Open(dir2, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Выбираем таблицу(лист).
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet1;
            ObjWorkSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook1.Sheets[1];
            int i = 2;
            while (ObjWorkSheet1.get_Range(GetExcelColumnName(1) + i.ToString()).Value2 != null)
            {
                signature = ObjWorkSheet1.get_Range(GetExcelColumnName(1) + i.ToString()).Value2;
                comboBox1.Items.Add(signature);
                comboBox4.Items.Add(signature);
                i++;
            }
            i = 2;
            while (ObjWorkSheet1.get_Range(GetExcelColumnName(2) + i.ToString()).Value2 != null)
            {
                signature = ObjWorkSheet1.get_Range(GetExcelColumnName(2) + i.ToString()).Value2;
                comboBox6.Items.Add(signature);
                i++;
            }
            i = 2;
            while (ObjWorkSheet1.get_Range(GetExcelColumnName(3) + i.ToString()).Value2 != null)
            {
                signature = ObjWorkSheet1.get_Range(GetExcelColumnName(3) + i.ToString()).Value2;
                comboBox3.Items.Add(signature);
                comboBox7.Items.Add(signature);
                i++;
            }
            ObjWorkBook1.Close();
            ObjExcel1.Quit();
        }
    }
}
