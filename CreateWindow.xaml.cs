using System.Windows;

namespace TodoList
{
    public partial class CreateWindow : Window
    {
        public Todo todo = new Todo();
        public bool create = false;
        public CreateWindow()
        {
            InitializeComponent();
            addTodoGrid.DataContext = todo;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (todo.Description == "")
            {
                _ = MessageBox.Show("La description ne peut pas être vide");
                return;
            }
            SqliteDbAccess.SaveTodo(todo);
            create = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
