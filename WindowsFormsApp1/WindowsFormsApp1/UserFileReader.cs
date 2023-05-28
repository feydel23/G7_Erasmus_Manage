using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    internal class UserFileReader
    {
        public string fileText;
        public UserFileReader(string t_fileText)
        {
            fileText = t_fileText;
        }

        public string ReadFile(string file)
        {
            string data;
            string text = System.IO.File.ReadAllText(file);
            data = UserFileReader.ReadToEnd();
            Console.WriteLine(data);
            UserFileReader.Close();
            return text;
        }
    }
}
