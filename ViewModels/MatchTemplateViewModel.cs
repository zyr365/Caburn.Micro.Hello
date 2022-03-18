using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using PropertyChanged;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class MatchTemplateViewModel: Screen,IViewModel
    {
        public ImageSource TemplateImage { get; set; }
        public string TemplateImagePath { get; set; }
        public ImageSource MarkImage { get; set; }
        public string  MarkImagePath { get; set; }
        public string ResultString { get; set; }
        public MatchTemplateViewModel()
        {
            DisplayName = "MatchTemplate";
        }
        public  void  MatchTemplate()
        {
            Mat src = CvInvoke.Imread(TemplateImagePath, LoadImageType.AnyColor);//从本地读取图片
            Mat result = src.Clone();

            Mat tempImg = CvInvoke.Imread(MarkImagePath, LoadImageType.AnyColor);
            int matchImg_rows = src.Rows - tempImg.Rows + 1;
            int matchImg_cols = src.Cols - tempImg.Cols + 1;
            Mat matchImg = new Mat(matchImg_rows, matchImg_rows, DepthType.Cv32F, 1); //存储匹配结果
             #region 模板匹配参数说明
            ////采用系数匹配法，匹配值越大越接近准确图像。
            ////IInputArray image：输入待搜索的图像。图像类型为8位或32位浮点类型。设图像的大小为[W, H]。
            ////IInputArray templ：输入模板图像，类型与待搜索图像类型一致，并且大小不能大于待搜索图像。设图像大小为[w, h]。
            ////IOutputArray result：输出匹配的结果，单通道，32位浮点类型且大小为[W - w + 1, H - h + 1]。
            ////TemplateMatchingType method：枚举类型标识符，表示匹配算法类型。
            ////Sqdiff = 0 平方差匹配，最好的匹配为 0。
            ////SqdiffNormed = 1 归一化平方差匹配，最好效果为 0。
            ////Ccorr = 2 相关匹配法，数值越大效果越好。
            ////CcorrNormed = 3 归一化相关匹配法，数值越大效果越好。
            ////Ccoeff = 4 系数匹配法，数值越大效果越好。
            ////CcoeffNormed = 5 归一化系数匹配法，数值越大效果越好。
            #endregion
            CvInvoke.MatchTemplate(src, tempImg, matchImg, TemplateMatchingType.CcoeffNormed);
            #region 归一化函数参数说明
            ////IInputArray src：输入数据。
            ////IOutputArray dst：进行归一化后输出数据。
            ////double alpha = 1; 归一化后的最大值，默认为 1。
            ////double beta = 0：归一化后的最小值，默认为 0。
            #endregion
            CvInvoke.Normalize(matchImg, matchImg, 0, 1, NormType.MinMax, matchImg.Depth); //归一化
            double minValue = 0.0, maxValue = 0.0;
            Point minLoc = new Point();
            Point maxLoc = new Point();
            #region 极值函数参数说明
            ////IInputArray arr：输入数组。
            ////ref double minVal：输出数组中的最小值。
            ////ref double maxVal; 输出数组中的最大值。
            ////ref Point minLoc：输出最小值的坐标。
            ////ref Point maxLoc; 输出最大值的坐标。
            ////IInputArray mask = null：蒙版。
            #endregion
            CvInvoke.MinMaxLoc(matchImg, ref minValue, ref maxValue, ref minLoc, ref maxLoc);

            StringBuilder tb_result = new StringBuilder();
            tb_result.Append("min=" + minValue + ",max=" + maxValue);
            tb_result.Append(Environment.NewLine);
            tb_result.Append("最小值坐标：\n" + minLoc.ToString());
            tb_result.Append(Environment.NewLine);
            tb_result.Append("最大值坐标：\n" + maxLoc.ToString());
            ResultString = tb_result.ToString();
            //Console.WriteLine(tb_result);
            CvInvoke.Rectangle(src, new Rectangle(maxLoc, tempImg.Size), new MCvScalar(0, 0, 255), 3);//绘制矩形，匹配得到的效果。

            CvInvoke.Imshow("result", src);
            CvInvoke.WaitKey(0);
        }

        /// <summary>
        /// 加载模板图片
        /// </summary>
        public void LoadTemplateImage()
        {
            TemplateImage = LoadImage(ImageLoadType.TemplateImage);
        }

        /// <summary>
        /// 加载标记图片
        /// </summary>
        public void LoadMarkImage()
        {
            MarkImage = LoadImage(ImageLoadType.MarkImage);
        }
        public ImageSource LoadImage(ImageLoadType imageType)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图片|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            openFileDialog1.FilterIndex = 1;//当前使用第二个过滤字符串
            openFileDialog1.RestoreDirectory = true;//对话框关闭时恢复原目录
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "选择文件";
            ImageSource iSouce = null;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    iSouce = LoadImageFreeze(openFileDialog1.FileName);//加载显示完成需要释放
                    switch(imageType)
                    {
                        case ImageLoadType.MarkImage:
                            MarkImagePath = openFileDialog1.FileName;break;
                        case ImageLoadType.TemplateImage:
                            TemplateImagePath = openFileDialog1.FileName; break;
                        default: break;
                    }
                    return iSouce;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MatchTemplateViewModel]:Load() execute error:{ex}");
                return null;
            }
        }

        /// <summary>
        /// 图片加载显示完成后释放
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static BitmapImage LoadImageFreeze(string imagePath)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                if (File.Exists(imagePath))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;

                    using (Stream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                    {
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();
                        bitmap.Freeze();
                    }
                }
                return bitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
