using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaia_rabota
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
        }
        // Сортировка методом Шелла
        public double[] ShellSort(double[] arr, int n)
        {
            int comparasionCount = 0;
            int permutationCount = 0;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    // Cортировка подсписков
                    double temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                        comparasionCount++;
                        permutationCount++;
                    }

                    arr[j] = temp;
                    permutationCount++;
                }
            }
            textBox6.Text = Convert.ToString(comparasionCount);
            textBox7.Text = Convert.ToString(permutationCount);
            return arr;
        }
        // Закон распределения Logistic
        double Logistic(double A, double B)
        {
            int r_num;
            double root, right;
            Random rtd = new Random();
            r_num = rtd.Next();
            right = (double)r_num / (double)int.MaxValue + 1;
            root = 1/(1 + Math.Exp((A-right)/B));
            return root;
        }
        // Оценка коэфициентов
        void KramerMethod(long a11, long a12, long a13, long a21, long a22, long a23)
        {
            double det1 = a11 * a22 - a12 * a21;
            double det2 = a13 * a22 - a12 * a23;
            double det3 = a11 * a23 - a13 * a21;

            double a0 = det2 / det1;
            double a1 = det3 / det1;

            textBox15.Text = String.Format("{0,000000}", a0);
            textBox16.Text = String.Format("{0,000000}", a1);
            textBox25.Text = String.Format("{0,000000}", a0);
            textBox26.Text = String.Format("{0,000000}", a1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int A = Convert.ToInt32(textBox2.Text);
            int B = Convert.ToInt32(textBox3.Text);

            int z = -1;
            int h = -1;

            string arr_1 = String.Empty;
            string arr_2 = String.Empty;

            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = Logistic(A, B);
                arr_1 += Convert.ToString(h + 1) + ".    ";
                h = h + 1;
                arr_1 += result[i] + "\n";
            }

            richTextBox1.Text = arr_1;

            System.Diagnostics.Stopwatch st = new Stopwatch();
            st.Restart();

            result = ShellSort(result, n);

            st.Stop();

            for (int i = 0; i < n; i++)
            {
                arr_2 += Convert.ToString(z + 1) + ".    ";
                z = z + 1;
                arr_2 += result[i] + "\n";
            }
            richTextBox2.Text = arr_2;
            long elapsedMilliseconds = Math.Max(0L, st.ElapsedMilliseconds);
            String elapsedTime = String.Format("{0:0}", elapsedMilliseconds) + " мс";
            textBox5.Text = elapsedTime;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int x = 0;
            long y = 0;
            long x1 = 0;
            long y1 = 0;
            long xy = 0;
            int count = 9000;

            for (int i = 0; i <= 9; i++)
            {
                double[] arr = new double[count];

                for (int k = 0; k < count; k++)
                {
                    arr[k] = Logistic(5, 1);
                }

                System.Diagnostics.Stopwatch st = new Stopwatch();

                st.Restart();
                st.Start();

                ShellSort(arr, count);
                st.Stop();
                long elapsedMilliseconds = Math.Max(0, st.ElapsedMilliseconds);

                ListViewItem item1 = new ListViewItem(Convert.ToString(i+1));
                item1.SubItems.Add(Convert.ToString(count));
                item1.SubItems.Add(Convert.ToString(elapsedMilliseconds));
                item1.SubItems.Add(Convert.ToString(Convert.ToString(count * count)));
                item1.SubItems.Add(Convert.ToString(Convert.ToString(count * elapsedMilliseconds)));
                item1.SubItems.Add(Convert.ToString(Convert.ToString(elapsedMilliseconds * elapsedMilliseconds)));

                listView1.Items.AddRange(new ListViewItem[] { item1 });


                this.chart1.Series[0].Points.AddXY(count, elapsedMilliseconds);

                x += count;
                y += elapsedMilliseconds;
                x1 += count * count;
                y1 += elapsedMilliseconds * elapsedMilliseconds;
                xy += count * elapsedMilliseconds;
                count += 4000;
            }

            button1.Enabled = false;
            button2.Enabled = true;
            textBox27.Text = Convert.ToString(10);
            textBox28.Text = Convert.ToString(x);
            textBox29.Text = Convert.ToString(y);
            textBox30.Text = Convert.ToString(x1);
            textBox31.Text = Convert.ToString(xy);
            textBox32.Text = Convert.ToString(y1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            long m = Convert.ToInt32(textBox27.Text);
            long x = Convert.ToInt32(textBox28.Text);
            long y = Convert.ToInt32(textBox29.Text);
            long x1 = Convert.ToInt64(textBox30.Text);
            long xy = Convert.ToInt64(textBox31.Text);
            long y1 = Convert.ToInt64(textBox32.Text);

            double a0 = 0;
            double a1 = 0;

            textBox9.Text = textBox27.Text;
            textBox14.Text = textBox28.Text;
            textBox13.Text = textBox30.Text;
            textBox10.Text = textBox28.Text;
            textBox12.Text = textBox31.Text;
            textBox11.Text = textBox29.Text;

            textBox18.Text = textBox27.Text;
            textBox21.Text = textBox28.Text;
            textBox19.Text = textBox28.Text;
            textBox20.Text = textBox30.Text;
            textBox17.Text = textBox29.Text;
            textBox22.Text = textBox31.Text;

            double r = ((m * xy) - (x * y)) / (Math.Sqrt(((m * x1) - (x * x)) * ((m * y1) - (y * y))));
            double r2 = r * r;

            if (Math.Abs(r) > 0 && Math.Abs(r) <= 0.5)
            {
                richTextBox3.Text = "Коэффициент корреляции принадлежит интервалу [0;0.5] - связь слабая.";
            }
            if (Math.Abs(r) > 0.5 && Math.Abs(r) <= 0.8)
            {
                richTextBox3.Text = "Коэффициент корреляции принадлежит интервалу (0.5;0.8] - связь умеренная.";
            }
            if (Math.Abs(r) > 0 && Math.Abs(r) < 1)
            {
                richTextBox3.Text = "Коэффициент корреляции принадлежит интервалу (0.8;1] - связь сильная.";
            }

            KramerMethod(m, x, y, x, x1, xy);
            textBox23.Text = Convert.ToString(r);
            textBox24.Text = Convert.ToString(r2);
        }
    }
}
