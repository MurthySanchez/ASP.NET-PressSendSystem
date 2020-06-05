using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Murthy.Web.Account
{
    public partial class VF : System.Web.UI.Page
    {
        /// <summary>
            /// 创建随机生成的验证码，可以为数字或字母
            /// </summary>
            /// <returns></returns>
        private string GenerateCheckCode()
        {
            int number = 0;
            char code;
            string checkcode = string.Empty;

            // 随机生成数字，并转换成5个数字或字母
            System.Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10)); // 数字
                else
                    code = (char)('A' + (char)(number % 26)); // 字母

                checkcode += code.ToString();
            }
            Response.Cookies.Add(new HttpCookie("CheckCode", checkcode));
            return checkcode;
        }

        /// <summary>
            /// 创建随机验证的图片，包括背景色和前景色
            /// </summary>
            /// <param name="checkcode"></param>
        private void CreateCheckCodeImage(string checkcode)
        {
            if (checkcode == null || checkcode.Trim() == string.Empty)
                return;

            Bitmap image = new Bitmap((int)Math.Ceiling((checkcode.Length * 12.8)), 24);
            Graphics grp = Graphics.FromImage(image);

            try
            {
                // 产生随机生成码
                Random random = new Random();

                // 清空图片背景色
                grp.Clear(Color.White);

                // 画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    grp.DrawLine(new Pen(Color.SpringGreen), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                grp.DrawString(checkcode, font, brush, 2, 2);

                // 画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                // 画图片的边框线
                grp.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                // 清除类对象(Graphics和Bitmap)
                grp.Dispose();
                image.Dispose();
                grp = null;
                image = null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CreateCheckCodeImage(GenerateCheckCode());


        }
    }
}