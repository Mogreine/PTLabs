using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string logText;
        private SortedList<Tuple<string, string>, Player> collection;

        public MainWindow()
        {
            collection = new SortedList<Tuple<string, string>, Player>();
            InitializeComponent();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            if (NameField.Text == "" || SurnameField.Text == "" || NicknameField.Text == "" || PositionField.Text == "" || SalaryField.Text == "")
            {
                MessageBox.Show(
                    "Необходимо ввести данные во все поля",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information,
                    MessageBoxResult.OK,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                Tuple<string, string> name = new Tuple<string, string>(NameField.Text, SurnameField.Text);
                if (!collection.ContainsKey(name))
                {
                    collection.Add(name, new Player(NameField.Text, SurnameField.Text, NicknameField.Text, PositionField.Text, SalaryField.Text));
                    LogField.Text += String.Format("Игрок {0} успешно добавлен\n", NicknameField.Text);
                }
                else
                {
                    LogField.Text += String.Format("Игрок {0} уже находится базе данных\n", NicknameField.Text);
                }
            }
        }

        private void ChangePlayerInfo(object sender, RoutedEventArgs e)
        {
            if (NameField.Text == "" || SurnameField.Text == "" || NicknameField.Text == "" || PositionField.Text == "" || SalaryField.Text == "")
            {
                MessageBox.Show(
                    "Необходимо ввести данные во все поля",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information,
                    MessageBoxResult.OK,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                Tuple<string, string> name = new Tuple<string, string>(NameField.Text, SurnameField.Text);
                if (collection.ContainsKey(name))
                {
                    collection[name] = new Player(name.Item1, name.Item2, NicknameField.Text, PositionField.Text, SalaryField.Text);
                    LogField.Text += String.Format("Изменения для игрока {0} {1} успешно применены\n", name.Item1, name.Item2);
                }
                else
                {
                    LogField.Text += String.Format("Игрок {0} {1} отсутствует в базе данных\n", name.Item1, name.Item2);
                }
            }
        }

        private void DeletePlayer(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show(
                "Вы уверены, что хотите удалить игрока из базы данных?", 
                "Удаление", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Information, 
                MessageBoxResult.OK, 
                MessageBoxOptions.DefaultDesktopOnly);
            if (res == MessageBoxResult.Yes)
            {
                Tuple<string, string> name = new Tuple<string, string>(NameField.Text, SurnameField.Text);
                if (collection.ContainsKey(name))
                {
                    collection.Remove(name);
                    LogField.Text += String.Format("Игрок {0} {1} успешно удален\n", name.Item1, name.Item2);
                }
                else
                {
                    LogField.Text += String.Format("Игрок {0} {1} отсутствует в базе данных\n", name.Item1, name.Item2);
                }
            }
        }

        private void PrintPlayers(object sender, RoutedEventArgs e)
        {
            if (collection.Count == 0)
            {
                LogField.Text += "Нет никаких игроков в базе данных";
            }
            else
            {
                logText = LogField.Text;
                LogField.Text = "";
                foreach (var player in collection)
                {
                    LogField.Text += String.Format("{0} {1} {2} {3} {4}\n", player.Value.Name, player.Value.Surname, player.Value.Nickname, player.Value.Position, player.Value.Salary);
                }
            }
        }

        private void PrintLog(object sender, RoutedEventArgs e)
        {
            if (logText != null)
            {
                LogField.Text = logText;
            }
            else
            {
                LogField.Text = "Логи пусты";
            }
        }


    }
}
