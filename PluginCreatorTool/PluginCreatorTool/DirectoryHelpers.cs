namespace PluginCreatorTool
{
    internal class DirectoryHelpers
    {
        public static string GetPathToProjectDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // Check if current directory contains a csproj file
            string[] csprojFiles = Directory.GetFiles(currentDirectory, "*.csproj");
            if (csprojFiles.Length > 0)
            {
                return currentDirectory;
            }

            // Check if current directory contains a sln file
            string[] slnFiles = Directory.GetFiles(currentDirectory, "*.sln");
            if (slnFiles.Length > 0)
            {
                string[] folders = Directory.GetDirectories(currentDirectory);
                foreach (string folder in folders)
                {
                    string folderName = Path.GetFileName(folder);
                    if (folderName.EndsWith("Kernel"))
                    {
                        return folder;
                    }
                }

                Console.WriteLine("ERROR: Cound not find Kernel project");
            }
            else
            {
                Console.WriteLine("ERROR: Could not find a project or solution file in the current directory.");
            }

            return null;
        }
    }
}
