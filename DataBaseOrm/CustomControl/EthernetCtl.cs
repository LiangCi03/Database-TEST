using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonUI.CustomControl
{
    public partial class EthernetCtl : UserControl
    {
        public EthernetCtl()
        {
            InitializeComponent();
        }

        #region 网口工位名称

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public override string Text
        {
            get
            {
                return grpEthernet.Text;
            }
            set
            {
                grpEthernet.Text = value;
            }
        }

        #endregion

        #region IP地址

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string IP
        {
            get
            {
                return cmbIP.Text;
            }
            set
            {
 
                if (!cmbIP.Items.Contains(value.ToString()))
                {
                    cmbIP.Items.Add(value.ToString());
                }
                cmbIP.SelectedIndex = cmbIP.Items.IndexOf(value.ToString());
            }
        }

        #endregion

        #region 端口号


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("自定义属性")]
        public string Port
        {
            get
            {
                return txtPort.Text;
            }
            set
            {
                txtPort.Text = value;
            }
        }

        #endregion

    }
}
