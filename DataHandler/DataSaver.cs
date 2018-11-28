using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public static class DataSaver
    {
        public static void SaveText(string dataToSave, string filePath)
        {
            //File.Delete(filePath);
            using (StreamWriter sW = File.AppendText(filePath))
            {
                sW.Write(dataToSave);
            }
        }
    }
}
