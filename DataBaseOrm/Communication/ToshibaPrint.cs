using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOSHIBA_TEC_PRINT_CLASS;
using DataBaseOrm;
namespace CommonUI.Communication
{
    public class ToshibaPrint
    {
        TOSHIBA_TEC_PRINT_CLASS.Printer printTEC = new TOSHIBA_TEC_PRINT_CLASS.Printer();
        public int iCutInterval = 0;
        
        public bool connect(string ip, int port)
        {
            try
            {
                bool setLanFlag = printTEC.SetConnectMethod(TOSHIBA_TEC_PRINT_CLASS.Printer.ConnectMethod.LAN);
                if (setLanFlag)
                {
                    bool setPrintipFlag = printTEC.SetPrinterIP(ip, port);
                    if (setPrintipFlag)
                    {
                        bool status = printTEC.OpenConnect();
                        if (status)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("设置打印机ip端口错误");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("设置打印机Lan连接有误");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("错误信息：" + e.ToString());
                return false;
            }

        }

        public bool disConnect()
        {
            try
            {
                bool status = printTEC.CloseConnect();
                if (status)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("错误信息：" + e.ToString());
                return false;
            }

        }

        //private void butGetPrintState_Click(object sender, EventArgs e)
        //{
        //    string ret = printTEC.GetPrinterStatus();
        //    string labstate = "";
        //    switch (ret)
        //    {
        //        case "-1":
        //        case "-2":
        //        case "-3":
        //            labstate = "异常";
        //            break;
        //        case "00":
        //            labstate = "正常";
        //            break;
        //        case "02":
        //            labstate = "正常,打印中";
        //            break;

        //        case "01":
        //        case "15":
        //            labstate = "打印头打开";
        //            break;
        //        case "05":
        //            labstate = "等待剥离";
        //            break;
        //        case "04":
        //            labstate = "暂停";
        //            break;
        //        case "06":
        //            labstate = "指令错误";
        //            break;
        //        case "07":
        //            labstate = "串口错误";
        //            break;
        //        case "11":
        //            labstate = "卡纸";
        //            break;
        //        case "12":
        //            labstate = "切到错误";
        //            break;
        //        case "13":
        //            labstate = "缺纸";
        //            break;
        //        case "14":
        //            labstate = "缺碳带";
        //            break;
        //        case "17":
        //            labstate = "打印头损坏";
        //            break;
        //        case "18":
        //            labstate = "打印头过热";
        //            break;

        //        case "21":
        //            labstate = "碳带错误";
        //            break;
        //        case "22":
        //            labstate = "回卷器错误";
        //            break;
        //        case "27":
        //            labstate = "碳带即将用尽,正常";
        //            break;
        //        case "28":
        //            labstate = "碳带即将用尽,暂停";
        //            break;
        //        case "29":
        //            labstate = "碳带即将用尽,正常打印中";
        //            break;
        //        case "61":
        //        case "62":
        //        case "65":
        //            labstate = "RFID错误";
        //            break;
        //        default:
        //            labstate = "其他";
        //            break;

        //    }
        //    //labState.Text = labstate;

        //}

        /// <summary>
        /// 设置标签参数
        /// </summary>
        /// <returns></returns>
        public bool SetLabelParams()
        {
            try
            {
                iCutInterval = GlobalsVar._labelDao;
                float height = GlobalsVar._lableHight;
                float width = GlobalsVar._lableWidth;
                float gap = GlobalsVar._lableGap;
                bool status = printTEC.SetLabelSize(width, height, gap);
                if (status)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //    private void SetPrintBasicSetting()
        //    {
        //        if (this.txtLabelHight.Text.Length == 0)
        //        {
        //            MessageBox.Show("必须输入标签高度");
        //            txtLabelHight.Focus();
        //            return;
        //        }
        //        if (this.txtLabelWidth.Text.Length == 0)
        //        {
        //            MessageBox.Show("必须输入标签宽度");
        //            txtLabelWidth.Focus();
        //            return;
        //        }
        //        if (this.txtLabelGap.Text.Length == 0)
        //        {
        //            MessageBox.Show("必须输入标签间隙");
        //            txtLabelGap.Focus();
        //            return;
        //        }
        //       float height = float.Parse(txtLabelHight.Text);
        //        float width = float.Parse(txtLabelWidth.Text);
        //        float gap = float.Parse(txtLabelGap.Text);

        //        //printTEC.SetLabelSize(height, width, gap);//旧代码
        //        printTEC.SetLabelSize(width, height, gap);//新代码

        //       if (nudDensity.Value == 0)
        //        {
        //            //return;
        //        }
        //        else
        //        {
        //            if (cmbPrintMode.SelectedIndex == 0)
        //            {
        //                printTEC.SetPrintDensity(Convert.ToInt32(nudDensity.Value), Printer.PrintMode.Direct);
        //            }
        //            else
        //            {
        //                printTEC.SetPrintDensity(Convert.ToInt32(nudDensity.Value), Printer.PrintMode.Transfer);
        //            }


        //        }


        //    }




        //    public void PrintIssue()
        //    {

        //        int iAmount = int.Parse(txtPrintAmount.Text.Trim());
        //        int iCutInterval = int.Parse(txtCutInterval.Text.Trim());
        //        Printer.SensorType enumSensorType = (Printer.SensorType)cmbSensor.SelectedIndex;
        //        Printer.FeedMode enumFeedMode = (Printer.FeedMode)cmbFeedMode.SelectedIndex;
        //        Printer.PrintSpeed enumPrintSpeed = (Printer.PrintSpeed)cmbPrintSpeed.SelectedIndex;
        //        Printer.RibbonUsed enumRibbonUsed = (Printer.RibbonUsed)cmbPrintMode.SelectedIndex;
        //        Printer.PrintDirection enumPrintDirection = (Printer.PrintDirection)cmbPrintDirection.SelectedIndex;

        //        printTEC.SetPrintAmount(iAmount, iCutInterval, enumSensorType,
        //enumFeedMode,
        //enumPrintSpeed,
        //enumRibbonUsed,
        //enumPrintDirection);
        //        printTEC.PrintLabel();
        //    }







        public string ConvertASCIItoHex(string ImportStr)
        {
            string hexstring = ImportStr.Trim();
            if (hexstring.Length == 0)
            {

                return "";
            }
            byte[] array = System.Text.Encoding.ASCII.GetBytes(hexstring.Trim());
            string str = null;
            for (int i = 0; i < array.Length; i++)
            {
                int asciicode = (int)(array[i]);
                str += Convert.ToString(asciicode, 16);
            }
            return str;
        }
        public void PrintLabel(int labelCount)
        {

            SetLabelParams();
            string strInstallPosition = GlobalsVar._strInstallPosition; //基本固定，但是客户可能变更
            string strPartNumber = GlobalsVar._strPartNumber;    //SUK 目前有194,197,198 3个
            string strPartSKU = GlobalsVar._strPartSKU;  //基本固定，但是客户可能变更
            string strCountry = GlobalsVar._strCountry;//基本固定
            string strCountryCode = GlobalsVar._strCountryCode;//基本固定
            string strBarcode = GlobalsVar._strBarcode;//系列号，每个标签不同

            //string strRFID = "535257 5A2919406 4E344B43 101F0";
            string strRFID = "";
            if (strBarcode.Length == 20)
            {
                strRFID += ConvertASCIItoHex("S" + strBarcode.Substring(0, 2));
                strRFID += strBarcode.Substring(2, 9);
                strRFID += ConvertASCIItoHex(strBarcode.Substring(11, 4));
                strRFID += strBarcode.Substring(15, 5);
                strRFID = strRFID.ToUpper();
                GlobalsVar.rfidList.Add(strRFID);
            }
            else
            {
                return;
            }


            //if (nudDensity.Value == 0)
            //{
            //    return;
            //}
            //else
            //{
            //    if (cmbPrintMode.SelectedIndex == 0)
            //    {
            //        printTEC.SetPrintDensity(Convert.ToInt32(nudDensity.Value), Printer.PrintMode.Direct);
            //    }
            //    else
            //    {
            //        printTEC.SetPrintDensity(Convert.ToInt32(nudDensity.Value), Printer.PrintMode.Transfer);
            //    }
            //}

            printTEC.AddBitMapFontText(0032, 0052, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.External01, "H");//BMW logo 固定
            printTEC.AddBitMapFontText(0159, 0050, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Large, strInstallPosition);
            printTEC.AddBitMapFontText(0092, 0073, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Large, strPartNumber);//SKU 
            printTEC.AddBitMapFontText(0112, 0098, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Large, strPartSKU);
            printTEC.AddBitMapFontText(0142, 0122, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Large, strCountry);
            printTEC.AddBitMapFontText(0020, 0145, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Large, strCountryCode);

            printTEC.AddBitMapFontText(0147, 0179, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Medium, "Serial #:");//固定
            printTEC.AddBitMapFontText(0212, 0179, 5, 5, TOSHIBA_TEC_PRINT_CLASS.Printer.FontType.Helvetica_Medium, strBarcode);//序列号

            printTEC.AddRFIDData(strRFID);//RFID序列号

            printTEC.AddBarcodeDataMatrix(0318, 0035, 20, 6, 04, TOSHIBA_TEC_PRINT_CLASS.Printer.Rotational.Rotational_0, 18, 18, strBarcode);//二维码序列号

            printTEC.SetPrintAmount(labelCount, iCutInterval, Printer.SensorType.Transmissive_With_Preprinted_Label,
            Printer.FeedMode.Batch, Printer.PrintSpeed.IPS4, Printer.RibbonUsed.WithRibbon_NoSaving, Printer.PrintDirection.Botom_First);

            printTEC.PrintLabel();
        }

        //    private void button19_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.AddBarcode(40, 40, Printer.BarcodeType.JAN13, Printer.DigitCheckType.Check 2, Printer.Rotational.Rotational_0, 30, 0, 20, false, 0, "211234567891");
        //        printTEC.AddBarcode(40, 50, Printer.BarcodeType.Code93, Printer.DigitCheckType.Check_With_Auto_Attachment_1, 3, Printer.Rotational.Rotational_0, 15, 0, 0, true, 0, "4923456");
        //        PrintIssue();
        //    }

        //    private void button6_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.AddBarcodeEAN8_JAN8(40, 40, 2, 20, TOSHIBA_TEC_PRINT_CLASS.Printer.Rotational.Rotational_0, true, "4923456");
        //        printTEC.AddBitMapFontText(200, 200, 25, 25, Printer.FontType.Chinese, "中国");
        //        PrintIssue();
        //    }
















        //    private void button39_Click(object sender, EventArgs e)
        //    {
        //        printTEC.ClearPrintCommand();
        //    }



        //    private void button28_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        printTEC.AddBarcode2(40, 40, Printer.BarcodeType.CODE39_full_ASCII, Printer.DigitCheckType.NoCheck, 4, 6, 10, 14, 4, Printer.Rotational.Rotational_0, 40, 0, false, 0, "12345678");
        //        PrintIssue();
        //    }














        //    private void button5_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.AddOutlineFontText(40, 40, 10, 10, Printer.OutLineFontType.BRUSH738, Printer.Rotational.Rotational_90, Printer.PrintAttribution.Boxed, Printer.PrintAlignment.Center, "Hello World!");
        //        printTEC.AddBitMapFontText(50, 50, 20, 20, Printer.FontType.Times_Roman_Small, "Hello World");
        //        PrintIssue();
        //    }

        //    private void button47_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.AddOutlineFontText(40, 40, 10, 10, Printer.OutLineFontType.DUTCH801, Printer.Rotational.Rotational_90, Printer.PrintAttribution.Boxed, Printer.PrintAlignment.Center, "Hello World!");
        //        printTEC.AddBitMapFontText(50, 800, 10, 10, Printer.FontType.Presentation_Bold, Printer.Rotational.Rotational_90, Printer.PrintAttribution.Strike, Printer.PrintAlignment.Right, "Hello World");
        //        PrintIssue();
        //    }

        //    private void button48_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.AddOutlineFontText(40, 40, 10, 10, Printer.OutLineFontType.GOTHIC725, Printer.Rotational.Rotational_90, Printer.PrintAttribution.Boxed, Printer.PrintAlignment.Center, "Hello World!");
        //        printTEC.AddBitMapFontText(400, 200, 15, 10, Printer.FontType.Times_Roman_Large_Bold, Printer.Rotational.Rotational_180, Printer.PrintAttribution.Reverse, Printer.PrintAlignment.Center, "Hello World");

        //        PrintIssue();
        //    }

        //    private void button49_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        printTEC.AddOutlineFontText(100, 300, 20, 20, Printer.OutLineFontType.BRUSH738, "Hello World");

        //        PrintIssue();
        //    }

        //    private void button50_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        printTEC.AddOutlineFontText(500, 300, 10, 10, Printer.OutLineFontType.Price_Font1, Printer.Rotational.Rotational_0, Printer.PrintAttribution.Black, Printer.PrintAlignment.Right, "99.99");

        //        PrintIssue();
        //    }






        //    public static string CreateGRF(int X, int Y, string filename)
        //    {
        //        Bitmap bmp = null;
        //        BitmapData imgData = null;
        //        byte[] pixels;
        //        int x, y, width, height, imgwidth;
        //        StringBuilder sb;
        //        IntPtr ptr;

        //        try
        //        {
        //            bmp = new Bitmap(filename);
        //            imgData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
        //            width = (bmp.Width + 7) / 8;
        //            imgwidth = bmp.Width;
        //            height = bmp.Height;
        //            pixels = new byte[width];
        //            sb = new StringBuilder(width * bmp.Height * 2);
        //            ptr = imgData.Scan0;
        //            //for (y = 0; y < bmp.Height; y++)
        //            //{
        //            //    Marshal.Copy(ptr, pixels, 0, width);
        //            //    for (x = 0; x < width; x++)
        //            //        sb.AppendFormat("{0:X2}", (byte)~pixels[x]);
        //            //    ptr = (IntPtr)(ptr.ToInt64() + imgData.Stride);
        //            //}
        //            byte[] bitmapFileData = System.IO.File.ReadAllBytes(filename);
        //            int fileSize = bitmapFileData.Length;

        //            Bitmap ImgTemp = new Bitmap(filename);
        //            Size ImgSize = ImgTemp.Size;
        //            ImgTemp.Dispose();

        //            int iwidth = ImgSize.Width;
        //            int iheight = ImgSize.Height;
        //            int bitmapDataOffset = 62; // 62 = header of the image
        //            int bitmapDataLength = fileSize - 62;// 8160;    

        //            double widthInBytes = Math.Ceiling(iwidth / 8.0);

        //            // Copy over the actual bitmap data from the bitmap file.
        //            // This represents the bitmap data without the header information.
        //            byte[] bitmap = new byte[bitmapDataLength];
        //            Buffer.BlockCopy(bitmapFileData, bitmapDataOffset, bitmap, 0, (bitmapDataLength));

        //            // Invert bitmap colors
        //            for (int i = 0; i < bitmapDataLength; i++)
        //            {
        //                bitmap[i] ^= 0xFF;
        //            }
        //            string ZPLImageDataString = BitConverter.ToString(bitmap).Replace("-", string.Empty);
        //            int aa = 0;

        //        }
        //        finally
        //        {
        //            if (bmp != null)
        //            {
        //                if (imgData != null) bmp.UnlockBits(imgData);
        //                bmp.Dispose();
        //            }
        //        }
        //        string retString = "{SG;" + X.ToString().PadLeft(4, '0') + "," + Y.ToString().PadLeft(4, '0') + ","
        //            + imgwidth.ToString().PadLeft(4, '0') + "," + height.ToString().PadLeft(4, '0') + ",1，" + sb.ToString() + "|}";

        //        return retString;
        //    }

        //    private void button7_Click(object sender, EventArgs e)
        //    {


        //    }

        //    private void button43_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        //printTEC.RFIDPrinterSetting(10,1,0,2,3,4,5,6,false);

        //        //PrintIssue();
        //    }

        //    private void button2_Click(object sender, EventArgs e)
        //    {
        //        SetPrintBasicSetting();
        //        for (int i = 0; i < 10; i++)
        //        {
        //            printTEC.ClearGraphic();


        //            printTEC.AddBitMapFontText(200, 200, 25, 25, Printer.FontType.Chinese, "RFID打印");
        //            printTEC.AddRFIDData("4039383736353433", 2, 2);
        //        }

        //        PrintIssue();
        //    }



    }
}

