using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D24ModuleInstaller
{
    internal class Program
    {
        static Assembly assembly = Assembly.GetExecutingAssembly();
        static string CurrentName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        static string DefualtNcaLayerPath = "\\AppData\\Roaming\\NCALayer\\bundles\\";
        static string DesktopName = CurrentName.Substring(0, CurrentName.IndexOf('\\'));
        static string pathtoResource = "D24ModuleInstaller.kz.dogovor24.module_1.0.3.jar";
        static string pathToImage = "D24ModuleInstaller.dogovor24-logo.png";
        static string DiskSpace = "C:\\Users\\";
        static string logo = "\r\n██████╗░░█████╗░░██████╗░░█████╗░██╗░░░██╗░█████╗░██████╗░░░░░░░██████╗░░░██╗██╗\r\n██╔══██╗██╔══██╗██╔════╝░██╔══██╗██║░░░██║██╔══██╗██╔══██╗░░░░░░╚════██╗░██╔╝██║\r\n██║░░██║██║░░██║██║░░██╗░██║░░██║╚██╗░██╔╝██║░░██║██████╔╝█████╗░░███╔═╝██╔╝░██║\r\n██║░░██║██║░░██║██║░░╚██╗██║░░██║░╚████╔╝░██║░░██║██╔══██╗╚════╝██╔══╝░░███████║\r\n██████╔╝╚█████╔╝╚██████╔╝╚█████╔╝░░╚██╔╝░░╚█████╔╝██║░░██║░░░░░░███████╗╚════██║\r\n╚═════╝░░╚════╝░░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝░░░░░░╚══════╝░░░░░╚═╝";
        static void Main(string[] args)
        {
            try
            {
                TryToInstallImage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(logo);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Поиск стандартной директории NCALayer...");
            TryToInstallInDefaultPath();
            // TO DO Somthing
            Console.Read();
        }
        static void TryToInstallInDefaultPath()
        {
            string username = CurrentName.Replace(DesktopName + "\\", "");
            string fullpath = DiskSpace + username + DefualtNcaLayerPath;
            string filepath = Path.GetFullPath("kz.dogovor24.module_1.0.3.jar");
            if (Directory.Exists(fullpath))
            {
                Console.WriteLine("Стандартная директория найдена!");
                Console.WriteLine("Экспорт модуля kz.dogovor24.module...");
                try
                {
                    using (var stream = assembly.GetManifestResourceStream(pathtoResource))
                    {
                        var file = UseStreamDotReadMethod(stream);
                        SaveByteArrayToFileWithStaticMethod(file, fullpath);
                    }
                }
               catch(Exception ex)
                {

                }
            }
            else
            {
                Console.WriteLine("Стандартная директория НЕ найдена, ищем другую...");
            }

        }
        static void TryToInstallImage()
        {
            string imagePath = Path.GetFullPath("dogovor24-logo.png");

            using (Stream stream = assembly.GetManifestResourceStream(pathToImage))
            {
                Bitmap bitmap = new Bitmap(stream);




                int consoleWidth = 120;
                int consoleHeight = 60;


                int blockWidth = bitmap.Width / consoleWidth;
                int blockHeight = bitmap.Height / consoleHeight;
                for (int y = 0; y < bitmap.Height; y += blockHeight)
                {
                    for (int x = 0; x < bitmap.Width; x += blockWidth)
                    {
                        int totalIntensity = 0;
                        int pixelCount = 0;
                        for (int j = 0; j < blockHeight; j++)
                        {
                            for (int i = 0; i < blockWidth; i++)
                            {
                                int px = x + i;
                                int py = y + j;
                                if (px >= bitmap.Width) px = bitmap.Width - 1;
                                if (py >= bitmap.Height) py = bitmap.Height - 1;
                                Color color = bitmap.GetPixel(px, py);
                                int intensity = (color.R + color.G + color.B) / 3;
                                totalIntensity += intensity;
                                pixelCount++;
                            }
                        }
                        int averageIntensity = totalIntensity / pixelCount;
                        char character;
                        if (averageIntensity < 25)
                        {
                            character = '@';
                        }
                        else if (averageIntensity < 50)
                        {
                            character = '#';
                        }
                        else if (averageIntensity < 75)
                        {
                            character = '&';
                        }
                        else if (averageIntensity < 100)
                        {
                            character = '$';
                        }
                        else if (averageIntensity < 125)
                        {
                            character = ' ';
                        }
                        else if (averageIntensity < 150)
                        {
                            character = '░';


                        }
                        else if (averageIntensity < 175)
                        {
                            character = '░';


                        }
                        else if (averageIntensity < 175)
                        {
                            character = '.';

                        }
                        else
                        {
                            //character = '░';
                            character = '█';

                        }
                        ConsoleColor consoleColor;

                        if (averageIntensity < 25)
                        {
                            consoleColor = ConsoleColor.White;
                        }
                        else if (averageIntensity < 50)
                        {
                            consoleColor = ConsoleColor.Gray;
                        }
                        else if (averageIntensity < 75)
                        {
                            consoleColor = ConsoleColor.DarkGray;
                        }
                        else if (averageIntensity < 100)
                        {
                            consoleColor = ConsoleColor.Blue;
                            // consoleColor = ConsoleColor.DarkYellow;
                        }
                        else if (averageIntensity < 125)
                        {
                            consoleColor = ConsoleColor.Blue;
                            //consoleColor = ConsoleColor.Yellow;
                        }
                        else if (averageIntensity < 150)
                        {
                            consoleColor = ConsoleColor.White;
                            //consoleColor = ConsoleColor.DarkGreen;
                        }
                        else if (averageIntensity < 175)
                        {
                            consoleColor = ConsoleColor.White;
                            //consoleColor = ConsoleColor.Green;
                        }
                        else if (averageIntensity < 175)
                        {
                            consoleColor = ConsoleColor.White;
                            consoleColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            consoleColor = ConsoleColor.White;

                        }
                        Console.ForegroundColor = consoleColor;
                        Console.Write(character);


                    }


                }
            }
        }
        static byte[] UseStreamDotReadMethod(Stream stream)
        {
            byte[] bytes;
            List<byte> totalStream = new List<byte>();
            byte[] buffer = new byte[32];
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalStream.AddRange(buffer.Take(read));
            }
            bytes = totalStream.ToArray();
            Console.WriteLine("Экспорт модуля завершен!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.WriteLine("░░░░░░ВЫПОЛНИТЕ ПЕРЕЗАПУСК ПРОГРАММЫ NCALayer!░░░░░░");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите любую клавишу для выхода");
            return bytes;
        }
       static void SaveByteArrayToFileWithStaticMethod(byte[] data, string filePath)
 => File.WriteAllBytes(filePath + "kz.dogovor24.module_1.0.3.jar", data);
    }
}
