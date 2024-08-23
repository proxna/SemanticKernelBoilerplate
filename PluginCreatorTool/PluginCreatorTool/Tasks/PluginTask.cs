namespace PluginCreatorTool.Tasks
{
    internal class PluginTask : ICreatorTasks
    {
        public bool Create(TaskParameters taskParameters)
        {
            string projectDirectory = DirectoryHelpers.GetPathToProjectDirectory();
            if (projectDirectory is null)
                return false;

            string pluginsDirectory = Path.Combine(projectDirectory, "Plugins");

            if (!Directory.Exists(pluginsDirectory))
            {
                Directory.CreateDirectory(pluginsDirectory);
            }

            if (!string.IsNullOrWhiteSpace(taskParameters.Name))
            {
                Console.WriteLine("ERROR: Name is required");
                return false;
            }

            string pluginDirectory = Path.Combine(pluginsDirectory, taskParameters.Name);

            if (Directory.Exists(pluginDirectory))
            {
                Console.WriteLine("ERROR: Plugin already exists. If you want to add function use addfunction instead");
                return false;
            }

            Directory.CreateDirectory(pluginDirectory);

            string functionDirectory = Path.Combine(pluginDirectory, string.IsNullOrWhiteSpace(taskParameters.Function) ? "Function" : taskParameters.Function);

            Directory.CreateDirectory(functionDirectory);

            File.Create(Path.Combine(functionDirectory, "skprompt.txt"));

            if (!string.IsNullOrWhiteSpace(taskParameters.Prompt))
            {
                File.WriteAllText(Path.Combine(functionDirectory, "skprompt.txt"), taskParameters.Prompt);
            }

            File.Create(Path.Combine(functionDirectory, "config.json"));

            File.Copy("Template\\config.json", Path.Combine(functionDirectory, "config.json"));

            Console.WriteLine($"Plugin {taskParameters.Name} created successfully");

            return true;
        }
    }
}
