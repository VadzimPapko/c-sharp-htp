//Two dimensional array
int[,] array = new int[3, 2] { {11, 34  }, {35, 36 }, { 64, 45} };
foreach (var item in array)
{
    Console.WriteLine($"{item}", item);
}

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write(array[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}


//Clone Sample
var clone = array.Clone() as int[,];
Array.Clear(clone, 0, clone.GetLength(0) * clone.GetLength(1));
foreach (var item in clone)
{
    Console.WriteLine(item);
}

foreach (var item in array)
{
    Console.WriteLine(item);
}