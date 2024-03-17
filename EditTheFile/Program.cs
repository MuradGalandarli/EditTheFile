using System.IO;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Linq;


namespace OOP
{
    public class Program
    {
        static void Main()
        {


            const string Search = "C:\\Users\\LENOVO\\Desktop";
            const string WriteTXT = "D:\\.TXT";
            const string WriteDLL = "D:\\.DLL";





            foreach (string file in GetFiles(Search))
            {
                Console.WriteLine(file);

                string type = file.Split('.').Last().ToString();

                switch (type)
                {
                    case "txt":
                        if (File.Exists(file))
                        {
                            WriteFile(WriteTXT, file);
                        }
                        break;
                    case "dll":

                        {
                            WriteFile(WriteDLL, file);
                        }

                        break;


                        static void WriteFile(string WriteFilePath, string context)
                        {
                            string fileName = Path.GetFileName(context);
                            string destinationPath = Path.Combine(WriteFilePath, fileName);


                            if (!Directory.Exists(WriteFilePath))
                            {
                                Directory.CreateDirectory(WriteFilePath);
                            }


                            File.Copy(context, destinationPath, true);
                            Console.WriteLine("Dosya başarıyla kopyalandı.");

                        }
                }
            }
        }


        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }




        }
    }
}