namespace Dota
{
    using System;
    using System.IO;
    using System.Text;

    public class File
    {
        public File(string fileName)
        {
            this.FileName = fileName;
        }
        public string FileName { get; private set; }

        public void LoadMap()
        {
            using (StreamReader sr = new StreamReader(this.FileName, Encoding.UTF8.IsBrowserDisplay))
            {
                string str = sr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine(str);                
            }
        }
    }
}
