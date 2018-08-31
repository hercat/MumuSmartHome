using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ItextSharpForm : Form
    {
        public ItextSharpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 创建页面大小为A4的Pdf文件
            //var doc = new Document(PageSize.A4);
            //PdfWriter.GetInstance(doc, new FileStream("pdf/test.pdf", FileMode.Create));
            //doc.Open();
            //doc.Add(new Paragraph("My first Pdf!"));
            //doc.Add(new Paragraph("Second pdf paragraph..."));
            //doc.Close();
            #endregion

            #region 设置页面大小为100像素*300像素（即1.39英尺*4.17英尺）
            //var doc = new Document(new iTextSharp.text.Rectangle(100f, 300f));
            //PdfWriter.GetInstance(doc, new FileStream("pdf/test2.pdf", FileMode.Create));
            //doc.Open();
            //doc.Add(new Paragraph("This is a custom size."));
            //doc.Close();
            #endregion

            #region 设置页面大小并设置页面背景色
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(180f, 200f);
            //rec.BackgroundColor = new CMYKColor(25, 90, 25, 0);
            rec.BackgroundColor = new BaseColor(Color.FromArgb(191, 64, 124));
            var doc = new Document(rec);
            PdfWriter.GetInstance(doc, new FileStream("pdf/test3.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("This is a custom size with a background color."));
            doc.Close();
            #endregion
        }
        /// <summary>
        /// 使用字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            #region
            //var doc = new Document(PageSize.A4);
            //BaseFont basefont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font font = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.RED);
            //PdfWriter.GetInstance(doc, new FileStream("pdf/test4.pdf", FileMode.Create));
            //doc.Open();
            //doc.Add(new Paragraph("This is a Read Font test using Times Roman.", font));
            //doc.Add(new Paragraph("This is a default Font test."));
            //doc.Close();
            #endregion

            #region
            int totalFonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            StringBuilder sb = new StringBuilder();
            foreach (string name in FontFactory.RegisteredFonts)
            {
                sb.Append(string.Format("{0}\n", name));
            }
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("pdf/test5.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(string.Format("Total Fonts:{0}", totalFonts)));
            doc.Add(new Paragraph(sb.ToString()));
            doc.Close();
            #endregion


        }
    }
}
