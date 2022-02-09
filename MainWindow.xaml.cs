using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TodoList
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Todo> Todos;
        public MainWindow()
        {
            InitializeComponent();
            LoadTodos();
        }

        public void LoadTodos()
        {
            todosList.ItemsSource = SqliteDbAccess.LoadTodos();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Todo selectedTodo = (sender as FrameworkElement).DataContext as Todo;
            CheckBox cb = sender as CheckBox;
            selectedTodo.Status = cb.IsChecked == true ? 1 : 0;
            SqliteDbAccess.UpdateTodo(selectedTodo);
        }

        private void OpenCreateWindow_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            _ = createWindow.ShowDialog();
            // si il y a creation, recharger la todolist
            if (createWindow.create)
            {
                LoadTodos();
            }
        }

        private void OpenEditWindow_Click(object sender, RoutedEventArgs e)
        {
            Todo todo = (Todo)todosList.SelectedItem;
            if (todo == null)
            {
                _ = MessageBox.Show("Aucune tâche selectionnée");
                return;
            }
            EditWindow editWindow = new EditWindow(todo) { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            _ = editWindow.ShowDialog();
            // si il y a modification, recharger la todolist
            if (editWindow.update)
            {
                LoadTodos();
            }
        }

        private void OpenDeleteWindow_Click(object sender, RoutedEventArgs e)
        {
            Todo todo = (Todo)todosList.SelectedItem;
            if (todo == null)
            {
                _ = MessageBox.Show("Aucune tâche selectionnée");
                return;
            }
            DeleteWindow deleteWindow = new DeleteWindow(todo) { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            _ = deleteWindow.ShowDialog();
            // si il y a suppression, recharger la todolist
            if (deleteWindow.delete)
            {
                LoadTodos();
            }
        }

        private void todosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
