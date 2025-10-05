namespace TodoListApplication;

class Program
{
    static void Main(string[] args)
    {
        Introduction introduction = new Introduction();
        TodoDatabase todoDatabase = new TodoDatabase();
        AddTodo addTodo = new AddTodo("", todoDatabase);
        SeeTodo seeTodo = new SeeTodo(todoDatabase);
        RemoveTodo removeTodo = new RemoveTodo(0, todoDatabase, seeTodo);
        User user = new User(seeTodo, removeTodo, addTodo, introduction);
        user.userchoice();

    }

    public class Introduction
    {
        public string Print()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");
            string userInput = Console.ReadLine().ToLower();
            return userInput;

        }
    }
    public class TodoDatabase
    {
        public List<string> Todos = new List<string>();
    }
    public class AddTodo
    {
        private TodoDatabase todoDatabase;
        public string Description { get; set; }

        public AddTodo(string description, TodoDatabase db)
        {
            Description = description;
            todoDatabase = db; 
            
            
        }

        public void AddingTodos()
        {
            Console.WriteLine("Enter the description");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Description cannot be empty");
            }

            Description = input;
            todoDatabase.Todos.Add(Description);
            Console.WriteLine("Todos have been added successfully");
        }
        

    }
    public class SeeTodo
    {
        private TodoDatabase todoDatabase;

        public SeeTodo(TodoDatabase db)
        {
            todoDatabase = db;
        }
        public void ShowingTodos()
        {
            Console.WriteLine("Here are the list of all todos");
            for (int i = 0; i < todoDatabase.Todos.Count; i++)
            {
                Console.WriteLine($"Todos: {i+1}: {todoDatabase.Todos[i]}");
            }
        }
    }
    public class RemoveTodo
    {
        public int _index { get; set; }
        private TodoDatabase todoDatabase;
        private SeeTodo seeTodo;

        public RemoveTodo(int index, TodoDatabase db, SeeTodo show)
        {
            todoDatabase = db;
            _index = index;
            seeTodo = show;
        }
        public void RemovingTodos()
        {
            Console.WriteLine("Here are your todos");
            seeTodo.ShowingTodos();
            Console.WriteLine("Tell me the number you want to remove the TODO");
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > todoDatabase.Todos.Count)
            {
                throw new ArgumentException("Invalid number.");
            }
            todoDatabase.Todos.RemoveAt(input-1);
            Console.WriteLine("Todos have been removed successfully");
        }
    }
    public class User
    {
        private SeeTodo _seeTodo;
        private RemoveTodo _removeTodo;
        private AddTodo _addTodo;
        private Introduction _introduction;

        public User(SeeTodo seeTodo, RemoveTodo removeTodo, AddTodo addTodo, Introduction introduction)
        {
            _seeTodo = seeTodo;
            _removeTodo = removeTodo;
            _addTodo = addTodo;
            _introduction = introduction;
        }

        public bool userchoice()
        {
            
            bool exitProgram = false;
            while (!exitProgram)
            {
                string choice = _introduction.Print();


                if (choice == "s")
                {
                    _seeTodo.ShowingTodos();
                }
                else if (choice == "a")
                {
                    _addTodo.AddingTodos();

                }
                else if (choice == "r")
                {
                    _removeTodo.RemovingTodos();
                }
                else if (choice == "e")
                {
                    Console.WriteLine("Program has been terminated");
                    exitProgram = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
                
            }

            return false;

        }
    }
}