using System.Windows;

namespace TodoList
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Todo todo;
        public bool update = false;

        public EditWindow(Todo selectedTodo)
        {
            todo = selectedTodo;
            InitializeComponent();
            editTodoGrid.DataContext = todo;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {


            if (todo.Description == "")
            {
                _ = MessageBox.Show("La description ne peut pas être vide");
                return;
            }
            SqliteDbAccess.UpdateTodo(todo);
            update = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
