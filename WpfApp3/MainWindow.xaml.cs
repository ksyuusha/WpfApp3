using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Установка плейсхолдера для TextBox'ов при запуске
            SetPlaceholder(TitleTextBox);
            SetPlaceholder(DescriptionTextBox);
        }

        // Метод для установки плейсхолдера
        private void SetPlaceholder(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Обработчик события получения фокуса
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        // Обработчик события потери фокуса
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // Пример обработчика для кнопки "Добавить задачу"
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;

            if (title == TitleTextBox.Tag.ToString() || description == DescriptionTextBox.Tag.ToString())
            {
                MessageBox.Show("Заполните все поля задачи.");
                return;
            }

            // Добавляем задачу в список
            TasksListBox.Items.Add($"{title}: {description}");

            // Очистка полей ввода и восстановление плейсхолдера
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            SetPlaceholder(TitleTextBox);
            SetPlaceholder(DescriptionTextBox);
        }
    }
}
