namespace RecipeGenerator.Settings
{
    public static class AppPaths
    {
        private static string dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
        public static string DataFolder
        {
            get
            {
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                }

                return dataFolder;
            }
        }

        private static string logFolder = Path.Combine(DataFolder, "Logs");

        public static string LogFolder
        {
            get
            {
                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }

                return logFolder;
            }
        }
    }
}
