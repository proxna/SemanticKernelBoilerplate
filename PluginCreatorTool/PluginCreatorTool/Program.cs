using PluginCreatorTool;
using PluginCreatorTool.Tasks;

string functionName = args[0];

ICreatorTasks task = functionName switch
{
    "addplugin" => new PluginTask(),
    "addfunction" => new FunctionTask(),
    _ => null
};

if (task is null)
{
    Console.WriteLine("Invalid function name.");
    return;
}

task.Create(TaskParameters.Parse(args[1..]));