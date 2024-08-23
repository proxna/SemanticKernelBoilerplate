string functionName = args[0];

switch (functionName)
{
    case "addplugin":
        Console.WriteLine("Adding plugin...");
        break;
    case "addfunction":
        Console.WriteLine("Adding function...");
        break;
    default:
        Console.WriteLine("Invalid function name.");
        break;
}