using Autodesk.Revit.UI;

namespace NewProject
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            ListContainerFilesAsync();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public async void ListContainerFilesAsync()
        {
            await BlobClientTester.ListContainerFiles();
        }
    }
}
