// See https://aka.ms/new-console-template for more information
Console.WriteLine("Well Hello There!");
Console.WriteLine("The current time is " + DateTime.Now);

// Type your username and press enter
Console.WriteLine("Enter your name:");


// Create a string variable and get user input from the keyboard and store it in the variable
string userName = Console.ReadLine();

// Print the value of the variable (userName), which will display the input value
Console.WriteLine("Username is: " + userName);

Console.WriteLine("Enter your age:");
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Your age is: " + age);