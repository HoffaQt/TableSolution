using TableApp.Table;

internal static class Program
{
    private static TableLogic Init()
    {
        bool valid = false;
        List<int> initValues = new();

        while (!valid)
        {
            Console.WriteLine("Enter the width height and starting coordinates without seperators e.g. \"4422\"");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                initValues = input.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
                if (initValues.Count == 4)
                    valid = true;
            }
        }

        return new TableLogic(initValues[0], initValues[1], initValues[2], initValues[3]);
    }

    public static void Main()
    {
        TableLogic table = Init();

        Console.WriteLine("0 = quit simulation and print results \r\n1 = move forward one step\r\n2 = move backwards one step\r\n3 = rotate clockwise 90 degrees (eg north to east)\r\n4 = rotate counterclockwise 90 degrees (eg west to south)");

        bool exit = false;
        while (!exit)
        {
            var inputs = Console.ReadLine().ToList();

            inputs.ForEach(input => {
                switch (input)
                {
                    case '0':
                    Console.WriteLine(table.Result);
                    exit = true;
                    break;

                    case '1':
                    if (!table.MoveObjectNode(true))
                    {
                        Console.WriteLine(table.Result);
                        exit = true;
                    }
                    break;

                    case '2':
                    if (!table.MoveObjectNode(false))
                    {
                        Console.WriteLine(table.Result);
                        exit = true;
                    }
                    break;

                    case '3':
                    table.RotateObjectNode(true);
                    break;

                    case '4':
                    table.RotateObjectNode(false);
                    break;

                    default:
                    Console.WriteLine("Invalid input");
                    break;
                }
            });
        }
        Console.ReadLine();
    }

}