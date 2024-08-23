namespace PluginCreatorTool
{
    internal class TaskParameters
    {
        public string Name { get; set; }

        public string Prompt { get; set; }

        public string Plugin { get; set; }

        public string Function { get; set; }

        public static TaskParameters Parse(string[] args)
        {
            TaskParameters taskParameters = new TaskParameters();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    switch (args[i])
                    {
                        case "-name":
                            taskParameters.Name = args[i + 1];
                            break;
                        case "-prompt":
                            taskParameters.Prompt = args[i + 1];
                            break;
                        case "-plugin":
                            taskParameters.Plugin = args[i + 1];
                            break;
                        case "-function":
                            taskParameters.Function = args[i + 1];
                            break;
                    }
                }
            }

            return taskParameters;
        }
    }
}
