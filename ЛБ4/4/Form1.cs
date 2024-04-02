namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Введіть довільну кількість чисел масиву розділених комою ' , ' (після останнього числа кома не потрібна) :";
            label2.Text = "Результат: ";
            label3.Text = " ";
            button1.Text = "Обчислити";

            label4.Text = "Введіть довільну кількість чисел для двовимірного масиву розділених комою ' , '\n (після останнього числа кома не потрібна) :";
            label5.Text = "1.";
            label6.Text = "2.";
            label7.Text = "Введіть порядкові номери чисел з двохвимірного масиву: ";
            label8.Text = "1.";
            label9.Text = "2.";
            label10.Text = "Результат: ";
            label11.Text = " ";
            button2.Text = "Обчислити";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] elements = textBox1.Text.Split(',');
            double[] array;
            List<double> tempList = new List<double>();

            foreach (var element in elements)
            {
                if (double.TryParse(element.Trim(), out double number))
                {
                    tempList.Add(number);
                }
                else
                {
                    MessageBox.Show("Зітріть кому після останнього числа!");
                    return;
                }
            }

            array = tempList.ToArray();

            int maxIndex = FindMaxIndex(array);
            label3.Text = $"Номер максимального елемента масиву: {maxIndex}\n";

            double product = FindProductBetweenZeros(array);
            label3.Text += $"Добуток елементів масиву між першим і другим нульовими елементами: {product}\n";

            TransformArray(array);

            label3.Text += "Масив після перетворення:\n";
            foreach (var item in array)
            {
                label3.Text += item + " ";
            }
        }
        static int FindMaxIndex(double[] array)
        {
            double max = array[0];
            int maxIndex = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i + 1;
                }
            }
            return maxIndex;
        }

        static double FindProductBetweenZeros(double[] array)
        {
            int firstZeroIndex = Array.IndexOf(array, 0);
            if (firstZeroIndex == -1)
                return 0;

            int secondZeroIndex = Array.IndexOf(array, 0, firstZeroIndex + 1);
            if (secondZeroIndex == -1)
                return 0;

            double product = 1;
            for (int i = firstZeroIndex + 1; i < secondZeroIndex; i++)
            {
                product *= array[i];
            }
            return product;
        }

        static void TransformArray(double[] array)
        {
            int halfLength = array.Length / 2;
            for (int i = 0; i < halfLength; i++)
            {
                if (i % 2 != 0)
                {
                    double temp = array[i];
                    array[i] = array[halfLength + i];
                    array[halfLength + i] = temp;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] array = Create2DArray();

            int row1 = 0;
            int row2 = 1;
            int column1 = int.Parse(textBox4.Text);
            int column2 = int.Parse(textBox5.Text);

            double difference = CalculateDifference(array, row1, column1, row2, column2);
            double geometricMean = CalculateGeometricMean(array, row1, column1, row2, column2);

            label11.Text = $"Різниця: {difference}\nСереднє геометричне: {geometricMean}";
        }
        private int[,] Create2DArray()
        {
            string[] row1Elements = textBox2.Text.Split(',');
            string[] row2Elements = textBox3.Text.Split(',');

            int maxLength = Math.Max(row1Elements.Length, row2Elements.Length);
            int[,] array = new int[2, maxLength + 1];

            for (int i = 0; i < maxLength; i++)
            {
                if (i < row1Elements.Length)
                    array[0, i + 1] = int.Parse(row1Elements[i]);

                if (i < row2Elements.Length)
                    array[1, i + 1] = int.Parse(row2Elements[i]);
            }

            return array;
        }
        private double CalculateDifference(int[,] array, int row1, int column1, int row2, int column2)
        {
            return Math.Abs(array[row1, column1] - array[row2, column2]);
        }

        private double CalculateGeometricMean(int[,] array, int row1, int column1, int row2, int column2)
        {
            double product = array[row1, column1] * array[row2, column2];
            return Math.Sqrt(product);
        }
    }
}
