using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using Phidgets;
using Phidgets.Events;
using System.Data.SqlClient;
using System.Configuration;
using System.Timers;

namespace DuneTuner
{
    public partial class SensorConfigForm : Form
    {
        //Instantiate the Phidget interface kit
        static InterfaceKit ifKit2 = new InterfaceKit();

        public SensorConfigForm()
        {
            InitializeComponent();

            try
            {
                if (ifKit2 != null)
                {
                    ifKit2.Attach += new AttachEventHandler(ifKit2_Attach);
                    ifKit2.Detach += new DetachEventHandler(ifKit2_Detach);
                    ifKit2.Error += new ErrorEventHandler(ifKit2_Error);
                    ifKit2.SensorChange += new SensorChangeEventHandler(ifKit2_SensorChange);

                    ifKit2.open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Source + ex.StackTrace);
            }
        }

        private void SensorConfigForm_Load(object sender, EventArgs e)
        {
            //
        }

        protected void ifKit2_SensorChange(object sender, SensorChangeEventArgs e)
        {
            try
            {
                label1.Text = ifKit2.sensors[0].Value.ToString();
                label2.Text = ifKit2.sensors[1].Value.ToString();
                label3.Text = ifKit2.sensors[2].Value.ToString();
                label4.Text = ifKit2.sensors[3].Value.ToString();
                label5.Text = ifKit2.sensors[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
                    ex.Source + Environment.NewLine + Environment.NewLine +
                    ex.InnerException + Environment.NewLine + Environment.NewLine +
                    ex.StackTrace);
            }
        }

        protected void ifKit2_Attach(object sender, AttachEventArgs e)
        {
            //
        }
        protected void ifKit2_Detach(object sender, DetachEventArgs e)
        {
            //
        }
        protected void ifKit2_Error(object sender, ErrorEventArgs e)
        {
            //
        }

        private void SensorConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ifKit2 != null)
            {
                ifKit2.close();
                ifKit2 = null;
            }
        }
    }
}
