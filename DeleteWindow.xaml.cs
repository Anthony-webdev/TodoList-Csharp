using System.Windows;

namespace TodoList
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public Todo todo;
        public bool delete = false;

        public DeleteWindow(Todo selectedTodo)
        {
            todo = selectedTodo;
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SqliteDbAccess.DeleteTodo(todo);
            delete = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
