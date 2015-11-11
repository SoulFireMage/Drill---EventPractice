using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace eventPractice
    {
    public static class safeFileStream
        {
        public static void CreateFile(string fileName, string content)
            {
            FileStream fs = null;
            UnicodeEncoding uni = new UnicodeEncoding();
            byte[] contents = uni.GetBytes(content);
            try
                {
                fs = new FileStream(fileName, FileMode.OpenOrCreate);
                using (StreamWriter sr = new StreamWriter(fs))
                    {
                    fs.Write(contents,0,contents.Length);
                    }
                }
            finally
                {
                if (fs != null)
                    {
                    fs.Dispose();
                    }
                }
                }
          
            }
        }
   
