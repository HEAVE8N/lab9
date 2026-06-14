using System;
using System.Windows;

namespace PracticeC_
{
    public partial class MainWindow : Window
    {
        private LineSegment currentSegment;

        public MainWindow()
        {
            InitializeComponent();
            AddToLog("Приложение запущено");
        }

        private void AddToLog(string message)
        {
            lstLog.Items.Insert(0, $"{DateTime.Now:HH:mm:ss} - {message}");
            if (lstLog.Items.Count > 50)
                lstLog.Items.RemoveAt(lstLog.Items.Count - 1);
        }

        private void UpdateDisplay()
        {
            if (currentSegment != null)
            {
                txtCurrentSegment.Text = $"Текущий отрезок: {currentSegment.ToString()} (длина: {(!currentSegment):F2})";
                txtX.Text = currentSegment.X.ToString();
                txtY.Text = currentSegment.Y.ToString();
            }
            else
            {
                txtCurrentSegment.Text = "Текущий отрезок: не создан";
            }
        }

        private LineSegment GetCurrentSegment()
        {
            if (currentSegment == null)
            {
                MessageBox.Show("Сначала создайте отрезок!", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            return currentSegment;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(txtX.Text);
                double y = double.Parse(txtY.Text);

                currentSegment = new LineSegment(x, y);
                AddToLog($"Создан отрезок: {currentSegment.ToString()}");
                UpdateDisplay();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDefault_Click(object sender, RoutedEventArgs e)
        {
            currentSegment = new LineSegment();
            AddToLog($"Создан отрезок по умолчанию: {currentSegment.ToString()}");
            UpdateDisplay();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (GetCurrentSegment() == null)
            {
                return;
            }

                currentSegment = new LineSegment(currentSegment);
            AddToLog($"Создана копия отрезка: {currentSegment.ToString()}");
            UpdateDisplay();
        }

        private void BtnLength_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

            double length = !segment;
            txtLength.Text = $"Длина = {length:F2}";
            AddToLog($"Вычислена длина: {!segment:F2}");
        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

            segment++;
            currentSegment = segment;
            AddToLog($"Выполнен ++: {currentSegment.ToString()}");
            UpdateDisplay();
        }

        private void BtnAddInt_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

            if (int.TryParse(txtAddValue.Text, out int value))
            {
                currentSegment = segment + value;
                AddToLog($"Прибавлено {value} к отрезку: {currentSegment.ToString()}");
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Введите целое число!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCompare_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

                if (int.TryParse(txtCompareValue.Text, out int value))
            {
                bool resultLess = segment < value;
                bool resultGreater = segment > value;

                string message = $"Оператор < : segment < {value} = {resultLess}\n" +
                                $"Оператор > : segment > {value} = {resultGreater}\n\n" +
                                $"Число {value} {(resultLess ? "попадает" : "НЕ попадает")} в отрезок {segment.ToString()}";

                MessageBox.Show(message, "Результат сравнения (операторы < и >)",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                AddToLog($"Проверка через операторы < и > с числом {value}: <={resultLess}, >={resultGreater}");
            }
            else
            {
                MessageBox.Show("Введите целое число!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCast_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

                int intCast = (int)segment;
            double doubleCast = (double)segment;

            txtCast.Text = $"(int) = {intCast} (целая часть X), (double) = {doubleCast:F2} (координата Y)";
            AddToLog($"Приведение типов: (int)={intCast}, (double)={doubleCast:F2}");
        }

        private void BtnContains_Click(object sender, RoutedEventArgs e)
        {
            var segment = GetCurrentSegment();
            if (segment == null)
            {
                return;
            }

                if (double.TryParse(txtContainsValue.Text, out double value))
            {
                bool contains = segment.Contains(value);
                MessageBox.Show($"Метод Contains: число {value} {(contains ? "попадает" : "не попадает")} в отрезок {segment.ToString()}",
                    "Результат проверки (метод Contains)", MessageBoxButton.OK,
                    contains ? MessageBoxImage.Information : MessageBoxImage.Warning);
                AddToLog($"Проверка через метод Contains с числом {value}: {contains}");
            }
            else
            {
                MessageBox.Show("Введите корректное число!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}