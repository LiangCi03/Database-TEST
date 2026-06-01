using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace CommonUI.CustomControl
{
    public partial class SerialCtl : UserControl
    {
        public SerialCtl()
        {
            InitializeComponent();
        }

        #region 串口工位名称

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public override string Text
        {
            get
            {
                return grpSerial.Text;
            }
            set
            {



                grpSerial.Text = value;
            }
        }


        #endregion

        #region Port名称

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string PortName
        {
            get
            {
                return cmbPortName.Text;
            }
            set
            {

                if (!cmbPortName.Items.Contains(value.ToString()))
                {
                    cmbPortName.Items.Add(value.ToString());
                }
                cmbPortName.SelectedIndex = cmbPortName.Items.IndexOf(value.ToString());
            }
        }

        #endregion

        #region 波特率

       
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string  BaudRate
        {
            get
            {
                return cmbBaudRate.Text;
            }
            set
            {

                if (!cmbBaudRate.Items.Contains(value.ToString()))
                {
                    cmbBaudRate.Items.Add(value.ToString());
                }
                cmbBaudRate.SelectedIndex = cmbBaudRate.Items.IndexOf(value.ToString());
               
            }
        }

        #endregion

        #region 数据位

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string  DataBits
        {
            get
            {
                return cmbDatabits.Text;
            }
            set
            {

                if (!cmbDatabits.Items.Contains(value.ToString()))
                {
                    cmbDatabits.Items.Add(value.ToString());
                }
                cmbDatabits.SelectedIndex = cmbDatabits.Items.IndexOf(value.ToString());

            }
        }

        #endregion

        #region 停止位
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string StopBits
        {
            get
            {
                return cmbStopbits.Text;
            }
            set
            {
                if (!cmbStopbits.Items.Contains(value.ToString()))
                {
                    cmbStopbits.Items.Add(value.ToString());
                }
                cmbStopbits.SelectedIndex = cmbStopbits.Items.IndexOf(value.ToString());
            }
        }

        #endregion

        #region 校验位


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string  Paritys
        {
            get
            {
                return cmbParity.Text;
            }
            set
            {
                if (!cmbParity.Items.Contains(value.ToString()))
                {
                    cmbParity.Items.Add(value.ToString());
                }
                cmbParity.SelectedIndex = cmbParity.Items.IndexOf(value.ToString());
            }
        }

        #endregion

    }
}
