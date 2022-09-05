// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//String
string txt = "";
String txt2 = "";

Char symbol1 = 'N';
char symbol2 = '?';  

//Int
int num1 = 0;
Int32 num2 = 0;

double num3 = 34.4;
Double num4 = 23.4;
Console.WriteLine(num3.GetType());

float @float = 0.23f;
decimal @decimal = 0.23m;

byte b1 = 255;

//Boolean
bool logic1 = false;
Boolean logic2 = false;

//Convention for variables
//good
int num5 = 0;
int _num5 = 0;
int @int = 0;
int personAge = 0;

//bad
//int 3num4 = 0;
//int Num2;

//C# Strongly typed!!!

//Other types
Console.WriteLine("Today is " + DateTime.Today.DayOfWeek);
Console.WriteLine("Time is " + DateTime.Now);


//Work with numbers
decimal @decimal1 = 145.568m;
var result = @decimal1 * 100;
var result1 = (long)@decimal1 * 100;
Console.WriteLine("Decimal");
Console.WriteLine(result);
Console.WriteLine(result1);
