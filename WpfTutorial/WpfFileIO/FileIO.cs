using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //for StreamReader, File

namespace WpfFileIO
{
    class FileIO
    {
        public string PathFolder { get; set; } 
        DirectoryInfo dir;
        List<string> listContents;

        public FileIO()
        {
            PathFolder = @"C://FileTestFolder";
            dir = new DirectoryInfo(PathFolder);
            listContents = new List<string>();
        }

        public void CreateDirectory()
        {
            if (!dir.Exists) dir.Create();
        }
        
        public bool IsFileExist(string nameFile)
        {
            if(dir.Exists)
            {
                foreach(FileInfo file in dir.GetFiles())
                {
                    if (file.Extension.ToLower().CompareTo(".txt") == 0 &&
                        file.Name.Substring(0, file.Name.Length - ".txt".Length) == nameFile) return true;
                }
            }
            return false;
        }

        public void CreateTextFile(string nameFile)
        {
            if (dir.Exists)
            {
                if(!IsFileExist(nameFile))
                {
                    File.WriteAllText(PathFolder + "/" + nameFile + ".txt", null);
                }
            }
            else return;
        }

        public void ReadTextFile(string nameFile)
        {
            if (dir.Exists && IsFileExist(nameFile))
            {
                StreamReader file = new StreamReader(PathFolder + "/" + nameFile + ".txt");
                string line;
                listContents.Clear();
                while((line = file.ReadLine()) != null)
                {
                    listContents.Add(line);
                }
                file.Close();
            }
            else return;
        }

        public void AddLineInFile(string nameFile, string content)
        {
            if (dir.Exists && IsFileExist(nameFile))
            {
                ReadTextFile(nameFile);
                listContents.Add(content);
                string[] arrContents = listContents.ToArray();
                File.WriteAllLines(PathFolder + "/" + nameFile + ".txt", arrContents);
            }
            else return;
        }
    }
}
