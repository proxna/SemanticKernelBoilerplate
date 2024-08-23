namespace PluginCreatorTool.Tasks
{
    internal class FunctionTask : ICreatorTasks
    {
        public bool Create(TaskParameters taskParameters)
        {
            string projectDirectory = DirectoryHelpers.GetPathToProjectDirectory();
            if (projectDirectory is null)
                return false;

            string pluginsDirectory = Path.Combine(projectDirectory, "Plugins");

            if (!Directory.Exists(pluginsDirectory))
            {
                Console.WriteLine("ERROR: Plugins directory does not exist");
                return false;
            }

            if(string.IsNullOrWhiteSpace(taskParameters.Plugin))
            {
                Console.WriteLine("ERROR: Plugin name is required");
                return false;
            }

            string pluginDirectory = Path.Combine(pluginsDirectory, taskParameters.Plugin);

            if (!Directory.Exists(pluginDirectory))
            {
                Console.WriteLine("ERROR: Plugin does not exist");
                return false;
            }

            if(string.IsNullOrWhiteSpace(taskParameters.Name))
            {
                Console.WriteLine("ERROR: Function name is required");
                return false;
            }

            string functionDirectory = Path.Combine(pluginDirectory, taskParameters.Name);

            Directory.CreateDirectory(functionDirectory);

            File.Create(Path.Combine(functionDirectory, "skprompt.txt"));

            if (!string.IsNullOrWhiteSpace(taskParameters.Prompt))
            {
                File.WriteAllText(Path.Combine(functionDirectory, "skprompt.txt"), taskParameters.Prompt);
            }

            File.Create(Path.Combine(functionDirectory, "config.json"));

            File.Copy("Template\\config.json", Path.Combine(functionDirectory, "config.json"));

            Console.WriteLine($"Function {taskParameters.Name} created successfully");

            return true;
        }
    }
}
