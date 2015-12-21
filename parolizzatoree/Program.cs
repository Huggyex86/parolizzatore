using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace parolizzatoree
{
    class Program
    {
        static string starterWord;
        static void Main(string[] args)
        {
            Console.Write("Quando vuoi lo terminiamo sto programma???: ");
            starterWord = Console.ReadLine().ToLower();
            Thread work = new Thread(worker);
            work.Start();
            
        }

        static void worker()
        {
            string robone = "";
            string googleBase = onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord +"\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=10").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=20").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=30").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=40").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=50").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=60").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=70").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=80").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=90").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=100").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //googleBase += onlineFileContent("https://www.google.it/search?biw=1920&bih=971&q=\"" + starterWord + "\"&nfpr=1&sa=X&ved=0CBsQvgUoAWoVChMIwsTh7p3lxwIVAtkaCh1CwQT4&start=110").Replace("<cite class=\"_Rm\">", "<cite>").Replace("<cite class=\"kv\">", "<cite>");
            //&start=10
            string[] splitty = googleBase.Split(new string[] { "</cite>" }, StringSplitOptions.None);
            for (int i = 0; i < splitty.Length; i++){
                try
                {
                    splitty[i] = splitty[i].Split(new string[] { "<cite>" }, StringSplitOptions.None)[1].Replace("</b>", "").Replace("<b>", "");
                    if (splitty[i].IndexOf("http") != 0)
                        splitty[i] = "http://" + splitty[i];
                }
                catch { }
            }

            for (int i = 0; i < splitty.Length; i++ )
            {
                Console.Write("#");
                string[] cosini = onlineFileContent(splitty[i]).ToLower().Replace('<', ' ').Replace('>', ' ').Replace('"', ' ').Replace('\'', ' ').Split(new string[] { starterWord + " " }, StringSplitOptions.None);
                for (int x = 1; x <= cosini.Length; x++)
                {
                    try
                    {
                        string coso = cosini[x].Split(' ')[0];
                        if (robone.IndexOf(coso) == -1)
                        {
                            if (coso != "")
                            {
                                Console.WriteLine();
                                Console.WriteLine(coso);
                                robone += coso;
                            }
                        }
                        //Console.ReadLine();
                    }
                    catch { }
                }
            }
            Console.WriteLine("END!");
            Console.ReadLine();
        }

        static string onlineFileContent(string link)
        {
            try
            {
                WebClient client = new WebClient();
                System.IO.Stream stream = client.OpenRead(link);
                System.IO.StreamReader reader = new System.IO.StreamReader(stream);
                String content = reader.ReadToEnd();
                if (content == null)
                    return "";
                //MessageBox.Show(content); 
                return content;
            }
            catch
            {
                return "";
            }
        }
    }
}
