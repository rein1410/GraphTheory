using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GraphTheory
{
    public partial class Form1 : Form
    {
        public const int MAX = 100;
        int sodinh;//so dinh do thi
        int[,] a = new int[MAX, MAX]; //ma tran ke
       
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("Graphs");
        }

        private void writeGr_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo đồ thị dựa trên richTextBox, tên đặt bằng thời gian tao.
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Graphs\\" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now));
                sw.WriteLine(richTextBox1.Text.Trim('\r', '\n'));
                sw.Close();
                StatusLbl.Text = "Tạo Graph thành công !";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readGr_Click(object sender, EventArgs e)
        {
            try
            {
                //Đọc đồ thị và dán dữ liệu vào richTextBox.
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = File.ReadAllText(ofd.FileName);
                        StreamReader sr = new StreamReader(ofd.FileName);
                        sodinh = Convert.ToInt32(sr.ReadLine());
                        string input = sr.ReadToEnd().Trim('\r', '\n');
                        int i = 0; int j = 0;
                        a = new int[sodinh, sodinh];
                        foreach (var row in input.Split('\n'))
                        {
                            j = 0;
                            foreach (var col in row.Trim().Split(' '))
                            {
                                a[i, j] = int.Parse(col.Trim());
                                j++;
                            }
                            i++;
                        }
                        dinh.Text = "Số Đỉnh: " + sodinh.ToString();
                        mat.Text = "Ma Trận: " + "\n" + input;
                    }
                }
                StatusLbl.Text = "Đọc file thành công. ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
