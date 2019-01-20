using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
            Console.WriteLine("Inter text for conclusion:");
            var text = Console.ReadLine();
            Console.WriteLine(value: "Choos print type:");
            Console.WriteLine(value: "1-Console");
            Console.WriteLine(value: "2-File");
            Console.WriteLine(value: "3-Image");
            var type = Console.ReadLine();
            Printer printer;
            switch (type)
            {
                case "1":
                    printer = new ConsolePrinter(text, ConsoleColor.Blue);
                    printer.Print();
                    break;
                case "2":
                    printer = new FilePrinter(text, fileName: "TEST");
                    printer.Print();
                    break;
                case "3":
                    printer = new ImagePrinter(text, Color.DarkRed, Color.AliceBlue);
                    printer.Print();
                    break;
                default:
                    break;
            }
        }
        public abstract class Printer
        {
            public string PrintingText { get; set; }
            public Printer(string text)
            {
                PrintingText = text;
            }
            public abstract void Print();
        }

        public class ConsolePrinter : Printer
        {
            private ConsoleColor _color { get; set; }
            public ConsolePrinter(string text, ConsoleColor color) : base(text)
            {
                _color = color;
            }
            public override void Print()
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(PrintingText);
                Console.ResetColor();
            }
        }
        public class ImagePrinter : Printer
        {
            public Font font = new Font("Arial", 50);
            public Color textColor { get; set; }
            public Color backColor { get; set; }
            public ImagePrinter(string text, Color textColor, Color backColor) : base(text)
            {
                this.textColor = textColor;
                this.backColor = backColor;
            }
            public override void Print()
            {
                using (Image img = new Bitmap(1000, 1000))
                {
                    Graphics drawing = Graphics.FromImage(img);
                    //закрасить фон
                    drawing.Clear(backColor);
                    //залить текст цветом
                    Brush textBrush = new SolidBrush(textColor);
                    drawing.DrawString(PrintingText, font, textBrush, 30, 30);

                    img.Save("D:\\image1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                Console.WriteLine("The text successfully saved to the picture");
            }
        }
        public class FilePrinter : Printer
        {
            public string FileName { get; set; }
            private string path;
            public FilePrinter(string text, string fileName) : base(text)
            {
                FileName = fileName;
                path = $@"D:\{FileName}.txt";
            }

            public override void Print()
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(PrintingText);
                    Console.WriteLine("The text file was successfully recorded");
                }
            }
        }
    }
}
