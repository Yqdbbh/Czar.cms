﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Czar.Cms.Core.Helper
{
    /// <summary>
    /// 验证码帮助类
    /// </summary>
    public class CaptchaHelper
    {
        public static string Letters { get; set; } = "2346789ABCDEFGHJKLMNPRTUVWXYZ";

        public static int CodeLength { get; set; } = 4;

        /// <summary>
        /// 生成随机码
        /// </summary>
        /// <returns></returns>
        public static string GenerateCaptchaCode()
        {
            var rand = new Random();
            var maxRan = Letters.Length - 1;
            var sb = new StringBuilder();
            for(int i = 0; i < CodeLength; i++)
            {
                var index = rand.Next(maxRan);
                sb.Append(Letters[index]);
            }

            return sb.ToString();
        }

        public static CaptchaResult GetImage(int width,int height,string captchaCode,bool drawBezier = false)
        {
            using (var baseMap = new Bitmap(width, height))
            using (var graph = Graphics.FromImage(baseMap))
            {
                var ran = new Random();
                graph.Clear(GetRandomLightColor());
                DrawCaptchaCode();
                DrawDisorderLine();
                AdjustRippleEffect();

                var ms = new MemoryStream();
                baseMap.Save(ms, ImageFormat.Png);

                return new CaptchaResult
                {
                    CaptchaCode = captchaCode,
                    CaptchaByteData = ms.ToArray(),
                    Timestamp = DateTime.UtcNow
                };

                Color GetRandomLightColor()
                {
                    int low = 180, high = 255;
                    var nRend = ran.Next(high) % (high - low) + low;
                    var nGreen = ran.Next(high) % (high - low) + low;
                    var nBlue = ran.Next(high) % (high - low) + low;
                    return Color.FromArgb(nRend, nGreen, nBlue);
                }

                void DrawCaptchaCode()
                {
                    var fontBrush = new SolidBrush(Color.Black);
                    var fontSize = GetFontSize(width, captchaCode.Length);
                    var font = new Font(FontFamily.GenericSerif,fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    for(var i = 0; i < captchaCode.Length; i++)
                    {
                        fontBrush.Color = GetRandomDeepColor();
                        var shiftPx = fontSize / 6;
                        float x = i * fontSize + ran.Next(-shiftPx + shiftPx) + ran.Next(-shiftPx + shiftPx);
                        var maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = ran.Next(0, maxY);
                        graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);

                    }
                }

                int GetFontSize(int imgWidth,int captchacodeCount)
                {
                    var avgSize = imgWidth / captchacodeCount;
                    return Convert.ToInt32(avgSize);
                }

                Color GetRandomDeepColor()
                {
                    int redlow = 160, greenlow = 100, bluelow = 160;
                    return Color.FromArgb(ran.Next(redlow), ran.Next(greenlow), ran.Next(bluelow));
                }

                void DrawDisorderLine()
                {
                    var linePen = new Pen(new SolidBrush(Color.Black), 3);
                    for (var i = 0; i < ran.Next(3, 5); i++)
                    {
                        linePen.Color = GetRandomDeepColor();

                        var startPoint = new Point(ran.Next(0, width), ran.Next(0, height));
                        var endPoint = new Point(ran.Next(0, width), ran.Next(0, height));
                        graph.DrawLine(linePen, startPoint, endPoint);

                        if (drawBezier)
                        {
                            var bezierPoint1 = new Point(ran.Next(0, width), ran.Next(0, height));
                            var bezierPoint2 = new Point(ran.Next(0, width), ran.Next(0, height));

                            graph.DrawBezier(linePen, startPoint, bezierPoint1, bezierPoint2, endPoint);
                        }
                    }
                }

                void AdjustRippleEffect()
                {
                    short nWave = 6;
                    var nWidth = baseMap.Width;
                    var nHeight = baseMap.Height;

                    var pt = new Point[nWidth, nHeight];

                    for (var x = 0; x < nWidth; ++x)
                    {
                        for (var y = 0; y < nHeight; ++y)
                        {
                            var xo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                            var yo = nWave * Math.Cos(2.0 * 3.1415 * x / 128.0);

                            var newX = x + xo;
                            var newY = y + yo;

                            if (newX > 0 && newX < nWidth)
                            {
                                pt[x, y].X = (int)newX;
                            }
                            else
                            {
                                pt[x, y].X = 0;
                            }


                            if (newY > 0 && newY < nHeight)
                            {
                                pt[x, y].Y = (int)newY;
                            }
                            else
                            {
                                pt[x, y].Y = 0;
                            }
                        }
                    }

                    var bSrc = (Bitmap)baseMap.Clone();

                    var bitmapData = baseMap.LockBits(new Rectangle(0, 0, baseMap.Width, baseMap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    var bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                    var scanline = bitmapData.Stride;

                    var scan0 = bitmapData.Scan0;
                    var srcScan0 = bmSrc.Scan0;

                    unsafe
                    {
                        var p = (byte*)(void*)scan0;
                        var pSrc = (byte*)(void*)srcScan0;

                        var nOffset = bitmapData.Stride - baseMap.Width * 3;

                        for (var y = 0; y < nHeight; ++y)
                        {
                            for (var x = 0; x < nWidth; ++x)
                            {
                                var xOffset = pt[x, y].X;
                                var yOffset = pt[x, y].Y;

                                if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                                {
                                    if (pSrc != null)
                                    {
                                        if (p != null)
                                        {
                                            p[0] = pSrc[yOffset * scanline + xOffset * 3];
                                            p[1] = pSrc[yOffset * scanline + xOffset * 3 + 1];
                                            p[2] = pSrc[yOffset * scanline + xOffset * 3 + 2];
                                        }
                                    }
                                }

                                p += 3;
                            }
                            p += nOffset;
                        }
                    }

                    baseMap.UnlockBits(bitmapData);
                    bSrc.UnlockBits(bmSrc);
                    bSrc.Dispose();
                }
            }
        }


    }


    public class CaptchaResult
    {
        public string CaptchaCode { get; set; }

        public byte[] CaptchaByteData { get; set; }

        public string CaptchaBase64Data => Convert.ToBase64String(CaptchaByteData);

        public DateTime Timestamp { get; set; }
    }

}
