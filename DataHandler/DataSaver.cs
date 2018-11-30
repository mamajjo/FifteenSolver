using System.IO;

namespace DataHandler
{
    public static class DataSaver
    {
        public static void SaveText(string dataToSave, string filePath)
        {
            using (StreamWriter sW = File.AppendText(filePath))
            {
                sW.Write(dataToSave);
            }
        }
    }
}