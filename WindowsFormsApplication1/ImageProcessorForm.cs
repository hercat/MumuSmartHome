using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using System.IO;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Filters.Photo;

namespace WindowsFormsApplication1
{
    public partial class ImageProcessorForm : Form
    {
        public ImageProcessorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            byte[] imageBytes = File.ReadAllBytes("balloon.jpg");
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).Alpha(50).BackgroundColor(Color.Red).Brightness(20).Constrain(new Size(500,500)).Save(outStream);
                    }
                    Image.FromStream(outStream).Save(string.Format("imageProcessor\\{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmss")));
                }
            }
        }
        /// <summary>
        /// Contrast
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes("balloon.jpg");
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).Contrast(25).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\Contrast.jpg");
                    }
                }
            }
        }
        /// <summary>
        /// crop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes("balloon.jpg");
            Rectangle rec = new Rectangle(100, 100, 300, 300);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).Crop(rec).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\Crop.jpg");
                    }
                }
            }

            CropLayer crop = new CropLayer(100, 100, 300, 300, CropMode.Pixels);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).Crop(crop).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\crop2.jpg");
                    }
                }
            }
        }
        /// <summary>
        /// DetectEdges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes("woman.jpg");
            //KayyaliEdgeFilter filter = new KayyaliEdgeFilter();
            //KirschEdgeFilter filter = new KirschEdgeFilter();
            //Laplacian3X3EdgeFilter filter = new Laplacian3X3EdgeFilter();
            //Laplacian5X5EdgeFilter filter = new Laplacian5X5EdgeFilter();
            //LaplacianOfGaussianEdgeFilter filter = new LaplacianOfGaussianEdgeFilter();
            //PrewittEdgeFilter filter = new PrewittEdgeFilter();
            //RobertsCrossEdgeFilter filter = new RobertsCrossEdgeFilter();
            //ScharrEdgeFilter filter = new ScharrEdgeFilter();
            SobelEdgeFilter filter = new SobelEdgeFilter();
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).DetectEdges(filter, false).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\DetectEdges_Sobel.jpg");
                    }
                }
            }
        }
        /// <summary>
        /// EntropyCrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes("beach.jpg");
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).EntropyCrop(128).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\EntropyCrop_128.jpg");
                    }
                }
            }
        }
        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes("new-york.jpg");             
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory factory = new ImageFactory())
                    {
                        factory.Load(ms).Filter(MatrixFilters.Sepia).Save(outStream);
                        Image.FromStream(outStream).Save("imageProcessor\\Filter_Sepia.jpg");
                    }
                }
            }
        }

    }
}
