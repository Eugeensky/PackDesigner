using PackDesigner.BL;
using PackDesigner.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace PackDesigner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to draw beer pack");
            Console.ReadKey();
            DrawPack(@"..\..\Files\BeerPack.xml");
           
        }
        static void DrawPack(string xmlPath)
        {
            try
            {
                Document doc = new XMLParser().Deserialize(xmlPath);

                using (Bitmap bitmap = new Bitmap(doc.OriginalDocumentWidth, doc.OriginalDocumentHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Pen pen = new Pen(Brushes.Black, 5);
                        RectangleService rectangleService = new RectangleService();
                        var rectangles = rectangleService.GetRectangles(doc.RootX, doc.RootY, doc.Panel);
                        graphics.DrawRectangles(pen, rectangles.ToArray());
                    }
                    string imgPath = $"..\\..\\Files\\image{(int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds}.png";
                    bitmap.Save(imgPath);
                    Process.Start(imgPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
