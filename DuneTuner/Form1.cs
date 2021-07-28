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
    public partial class Form1 : Form
    {
        #region Private properties

        //Instantiate the Phidget interface kit
        static InterfaceKit ifKit = new InterfaceKit();

        //Set the inital values of the sensor sensitivity
        static int s1TripAt = 200;
        static int s2TripAt = 200;
        static int s3TripAt = 200;
        static int s4TripAt = 200;
        static int s5TripAt = 200;

        //sensor status
        static bool s1IsTripped = false;
        static bool s2IsTripped = false;
        static bool s3IsTripped = false;
        static bool s4IsTripped = false;
        static bool s5IsTripped = false;

        //...
        static DateTime s1Tripped = DateTime.MinValue;
        static DateTime s2Tripped = DateTime.MinValue;
        static DateTime s3Tripped = DateTime.MinValue;
        static DateTime s4Tripped = DateTime.MinValue;
        static DateTime s5Tripped = DateTime.MinValue;

        //...
        static bool isNewRun = false;
        static bool isStaged = false;
        static bool isLaunched = false;
        static bool isRedlighted = false;

        //...
        System.Timers.Timer stagedCountdown = new System.Timers.Timer();

        //
        DateTime startReactionTime = DateTime.MinValue;
        DateTime endReactionTime = DateTime.MinValue;
        
        //
        DateTime startRun = DateTime.MinValue;
        DateTime endRun = DateTime.MinValue;

        //light tree
        System.Timers.Timer preStage = new System.Timers.Timer();
        System.Timers.Timer stage = new System.Timers.Timer();
        System.Timers.Timer set1 = new System.Timers.Timer();
        System.Timers.Timer set2 = new System.Timers.Timer();
        System.Timers.Timer set3 = new System.Timers.Timer();
        System.Timers.Timer drag = new System.Timers.Timer();
        System.Timers.Timer redLight = new System.Timers.Timer();

        //Connection string
        string conn = "Server=.;Database=DuneTuner;Trusted_Connection=Yes;";

        #endregion

        /* ZedGraph - Text axis
         * 
         * ZedGraph also handles a text axis. This is an axis in which 
         * the tic labels are arbitrary, user supplied text strings 
         * instead of value labels. Internally, a text axis is handled 
         * using ordinal values just like an ordinary axis. In this 
         * case, the first major label has a value of 1.0, the second 
         * major label has a value of 2.0, etc. It is permissible to 
         * use fractional values if you want to place points in-between 
         * the labels. 
         * 
         * To make a text axis, you set Axis.Type = AxisType.Text. This 
         * informs ZedGraph to use the labels supplied by the user in 
         * Axis.Scale.TextLabels. The number of labels will determine 
         * the axis range. That is, 10 labels means the axis will be 
         * ranged from 1.0 to 10.0. Optionally, when you add a curve to 
         * ZedGraph, you can just skip any value array that is 
         * associated with a text axis. A default array of ordinal 
         * values will be generated. For example, if the XAxis is of 
         * type Text with 10 labels, you can add a curve, leaving the 
         * X array null, and an X array will be generated internally 
         * with values from 1.0 to 10.0. The bar chart below shows the 
         * usage of the AxisType.Text.
         */

        //Attach interface kit events and open listener for USB PNP
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load form defaults
            s1sensitivity.Text = s1TripAt.ToString();
            s2sensitivity.Text = s2TripAt.ToString();
            s3sensitivity.Text = s3TripAt.ToString();
            s4sensitivity.Text = s4TripAt.ToString();
            s5sensitivity.Text = s5TripAt.ToString();

            //Pass the form control through the CreateGraph method to
            //add data to it.
            //CreateGraph(zedGraphControl1);

            //This allows you to arrow up and down on previous runs
            DataBind_previousRunSelectionDropDownList(sender, e);
            //previousRunSelection.Focus();

            //Interface kit events
            ifKit.Attach += new AttachEventHandler(ifKit_Attach);
            ifKit.Detach += new DetachEventHandler(ifKit_Detach);
            ifKit.Error += new ErrorEventHandler(ifKit_Error);
            ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);

            //Listen for the USB connection
            ifKit.open();

            //Let's disable the form until the kit is attached
            if (ifKit.Attached == false)
            {
                mainPanel.Enabled = false;
                //MessageBox.Show("Please attach the USB cable to the PC and control board.");
            }
            else
            {
                mainPanel.Enabled = true;
            }

            //set UI elements
            CreateGraph(zedGraphControl1);
            saveRunButton.Enabled = false; //eanbled when we have run data
            deleteSelectedRun.Enabled = false;

            //set up light tree timers
            preStage.Elapsed += new ElapsedEventHandler(preStage_Elapsed);
            stage.Elapsed += new ElapsedEventHandler(stage_Elapsed);
            set1.Elapsed += new ElapsedEventHandler(set1_Elapsed);
            set2.Elapsed += new ElapsedEventHandler(set2_Elapsed);
            set3.Elapsed += new ElapsedEventHandler(set3_Elapsed);
            drag.Elapsed += new ElapsedEventHandler(drag_Elapsed);
            redLight.Elapsed += new ElapsedEventHandler(redLight_Elapsed);

            preStage.Interval = ((1) * 1); //turn on when tripped
            stage.Interval = ((1) * 1); //turn on when tripped
            set1.Interval = ((2000) * 1); // on after 2 seconds
            set2.Interval = ((400) * 1); //on after .400 second
            set3.Interval = ((400) * 1); //on after .400 second
            drag.Interval = ((400) * 1); //on after .400 second
            redLight.Interval = ((1) * 1); //turns on when tripped
        }

        //isStaged
        protected void stagedCountdown_Elapsed(object sender, ElapsedEventArgs e)
        {
            isNewRun = true;
            stagedCountdown.Stop();
        }

        //light tree timer events
        protected void preStage_Elapsed(object sender, ElapsedEventArgs e)
        {
            prestageLabel.BackColor = Color.Yellow;
            prestageLabel.ForeColor = Color.Yellow;
            preStage.Stop();
            ifKit.outputs[0] = true;
        }
        protected void stage_Elapsed(object sender, ElapsedEventArgs e)
        {
            stageLabel.BackColor = Color.Yellow;
            stageLabel.ForeColor = Color.Yellow;
            stage.Stop();
            set1.Start();
            ifKit.outputs[1] = true;
        }
        protected void set1_Elapsed(object sender, ElapsedEventArgs e)
        {
            set1Label.BackColor = Color.Orange;
            set1Label.ForeColor = Color.Orange;
            set1.Stop();
            set2.Start();
            ifKit.outputs[2] = true;
        }
        protected void set2_Elapsed(object sender, ElapsedEventArgs e)
        {
            set2Label.BackColor = Color.Orange;
            set2Label.ForeColor = Color.Orange;
            set2.Stop();
            set3.Start();
            ifKit.outputs[3] = true;
        }
        protected void set3_Elapsed(object sender, ElapsedEventArgs e)
        {
            set3Label.BackColor = Color.Orange;
            set3Label.ForeColor = Color.Orange;
            set3.Stop();
            drag.Start();
            ifKit.outputs[4] = true;

            startReactionTime = DateTime.Now;
        }
        protected void drag_Elapsed(object sender, ElapsedEventArgs e)
        {
            dragLabel.BackColor = Color.Green;
            dragLabel.ForeColor = Color.Green;
            drag.Stop();
            ifKit.outputs[5] = true;
        }
        protected void redLight_Elapsed(object sender, ElapsedEventArgs e)
        {
            redlightLabel.BackColor = Color.Red;
            redlightLabel.ForeColor = Color.Red;
            redLight.Stop();
            ifKit.outputs[6] = true;
        }

        //lock sensor trip values
        private void setSensorValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (setSensorValuesCheckBox.Checked == true)
            {
                s1sensitivity.ReadOnly = true;
                s2sensitivity.ReadOnly = true;
                s3sensitivity.ReadOnly = true;
                s4sensitivity.ReadOnly = true;
                s5sensitivity.ReadOnly = true;

                set1Sensitivity.Enabled = false;
                set2Sensitivity.Enabled = false;
                set3Sensitivity.Enabled = false;
                set4Sensitivity.Enabled = false;
                set5Sensitivity.Enabled = false;
            }
            else
            {
                s1sensitivity.ReadOnly = false;
                s2sensitivity.ReadOnly = false;
                s3sensitivity.ReadOnly = false;
                s4sensitivity.ReadOnly = false;
                s5sensitivity.ReadOnly = false;

                set1Sensitivity.Enabled = true;
                set2Sensitivity.Enabled = true;
                set3Sensitivity.Enabled = true;
                set4Sensitivity.Enabled = true;
                set5Sensitivity.Enabled = true;
            }
        }

        #region Interfacekit methods
        
        //Interfacekit events
        protected void ifKit_Attach(object sender, AttachEventArgs e)
        {
            //e.Device.SerialNumber.ToString()
            mainPanel.Enabled = true;
            connectionlabel.Text = "Connected.";
            connectionlabel.ForeColor = Color.Green;

            //set sensor lighttree outputs:
            ifKit.outputs[0] = false; //prestage
            ifKit.outputs[1] = false; //stage
            ifKit.outputs[2] = false; //1
            ifKit.outputs[3] = false; //2
            ifKit.outputs[4] = false; //3
            ifKit.outputs[5] = false; //greenlight
            ifKit.outputs[6] = false; //redlight
        }
        protected void ifKit_Detach(object sender, DetachEventArgs e)
        {
            connectionlabel.Text = "Not Connected.";
            connectionlabel.ForeColor = Color.Red;
            mainPanel.Enabled = false;
        }
        protected void ifKit_Error(object sender, ErrorEventArgs e)
        {
            mainPanel.Enabled = false;
            MessageBox.Show(e.Description);
            mainPanel.Enabled = true;
        }

        //The big kahuna
        protected void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
        {
            try
            {
                //update the UI with all the sensors values
                s1value.Text = ifKit.sensors[0].Value.ToString();
                s2value.Text = ifKit.sensors[1].Value.ToString();
                s3value.Text = ifKit.sensors[2].Value.ToString();
                s4value.Text = ifKit.sensors[3].Value.ToString();
                s5value.Text = ifKit.sensors[4].Value.ToString();

                //record sensor tripped state if it bounced over the threshold value
                int s = 0;
                int i = 0;

                //prestage
                s = ifKit.sensors[0].Value;
                i = s1TripAt;
                if (s < i)
                {
                    if (s1IsTripped == false)
                    {
                        s1IsTripped = true;
                        preStage.Start();
                        //if (s1Tripped == DateTime.MinValue)
                        //{
                        //    s1Tripped = DateTime.Now; //hey buddy, who cares about this one? reaction time? nope...
                        //}
                    }
                }

                //staged
                s = ifKit.sensors[1].Value;
                i = s2TripAt;
                if (s < i)
                {
                    if (s2IsTripped == false)
                    {
                        s2IsTripped = true;
                        stage.Start();
                    }
                }

                //launched
                if (s > i && isNewRun == true) //isNewRun only gets set to true when the stagecountdown timer is started from a good "stage
                {
                    isLaunched = true;
                    //record the time only when it is launched
                    if (s2Tripped == DateTime.MinValue)
                    {
                        s2Tripped = DateTime.Now;
                        endReactionTime = DateTime.Now;

                        if (startReactionTime > DateTime.MinValue && endReactionTime > DateTime.MinValue)
                        {
                            TimeSpan reactionTime = endReactionTime.Subtract(startReactionTime);
                            //MessageBox.Show(reactionTime.TotalMilliseconds.ToString());
                            int reactionMS = 0;
                            double reactionTotMS = reactionTime.TotalMilliseconds;
                            reactionMS = Convert.ToInt32(reactionTotMS);
                            //int reactionMS = int.Parse(double.Parse(reactionTime.TotalMilliseconds.ToString()).ToString());

                            //MessageBox.Show(reactionMS.ToString());

                            if (reactionMS > 400) //reaction time must be greater than 400 MS or redlight
                            {
                                //drag.Start(); //enabled for in house testing
                            }
                            else
                            {
                                redLight.Start();
                            }
                        }
                    }
                }

                //60 foot
                s = ifKit.sensors[2].Value;
                i = s3TripAt;
                if (s < i)
                {
                    if (s3IsTripped == false)
                    {
                        s3IsTripped = true;
                        s3Tripped = DateTime.Now;
                    }
                }

                //300 foot start
                s = ifKit.sensors[3].Value;
                i = s4TripAt;
                if (s < i)
                {
                    if (s4IsTripped == false)
                    {
                        s4IsTripped = true;
                        s4Tripped = DateTime.Now;
                    }
                }

                //300 foot end
                s = ifKit.sensors[4].Value;
                i = s5TripAt;
                if (s < i)
                {
                    if (s5IsTripped == false)
                    {
                        s5IsTripped = true;
                        s5Tripped = DateTime.Now;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
                    ex.Source + Environment.NewLine + Environment.NewLine +
                    ex.InnerException + Environment.NewLine + Environment.NewLine +
                    ex.StackTrace);
            }

            //show times in UI
            CalculateTimes();
        }

        //Sensor Configuration
        private void set1Sensitivity_Click_1(object sender, EventArgs e)
        {
            if (s1sensitivity.Text != "")
            {
                s1TripAt = Convert.ToInt32(s1sensitivity.Text);

                if (s1sensitivity.ReadOnly == true)
                    s1sensitivity.ReadOnly = false;
                else
                    s1sensitivity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Sensitivity cannot be blank!");
            }
        }
        private void set2Sensitivity_Click_1(object sender, EventArgs e)
        {
            if (s2sensitivity.Text != "")
            {
                s2TripAt = Convert.ToInt32(s2sensitivity.Text);

                if (s2sensitivity.ReadOnly == true)
                    s2sensitivity.ReadOnly = false;
                else
                    s2sensitivity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Sensitivity cannot be blank!");
            }
        }
        private void set3Sensitivity_Click_1(object sender, EventArgs e)
        {
            if (s3sensitivity.Text != "")
            {
                s3TripAt = Convert.ToInt32(s3sensitivity.Text);

                if (s3sensitivity.ReadOnly == true)
                    s3sensitivity.ReadOnly = false;
                else
                    s3sensitivity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Sensitivity cannot be blank!");
            }
        }
        private void set4Sensitivity_Click_1(object sender, EventArgs e)
        {
            if (s4sensitivity.Text != "")
            {
                s4TripAt = Convert.ToInt32(s4sensitivity.Text);

                if (s4sensitivity.ReadOnly == true)
                    s4sensitivity.ReadOnly = false;
                else
                    s4sensitivity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Sensitivity cannot be blank!");
            }
        }
        private void set5Sensitivity_Click_1(object sender, EventArgs e)
        {
            if (s5sensitivity.Text != "")
            {
                s5TripAt = Convert.ToInt32(s5sensitivity.Text);

                if (s5sensitivity.ReadOnly == true)
                    s5sensitivity.ReadOnly = false;
                else
                    s5sensitivity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Sensitivity cannot be blank!");
            }
        }
        
        #endregion

        //http://www.staginglight.com/guide/react.html

        //drag logic
        protected void CalculateTimes()
        {
            try
            {
                //prestage
                if (RunStage1Time.Text == "")
                {
                    if (s1IsTripped == true)
                    {
                        RunStage1Time.Text = "Ready";
                        //TimeSpan duration = s2Tripped - s1Tripped;
                        //duration.TotalMilliseconds.ToString();
                    }
                }

                //stage
                if (RunStage2Time.Text == "")
                {
                    if (s1IsTripped == true && s2IsTripped == true)
                    {
                        if (RunStage1Time.Text == "Ready")
                        {
                            RunStage2Time.Text = "Staged";
                        }
                    }
                }

                //ready to drag
                if (RunStage1Time.Text == "Ready" && RunStage2Time.Text == "Staged")
                {
                    isStaged = true;
                    RunStage1Time.Text = "0";

                    //count down to new drag time, when tripped then we are "recording the sensors"
                    stagedCountdown.Elapsed += new ElapsedEventHandler(stagedCountdown_Elapsed);
                    stagedCountdown.Interval = ((400) * 1); // .4 seconds
                    stagedCountdown.Start();
                }

                //launched
                if (RunStage1Time.Text == "0" && RunStage2Time.Text == "Staged" && isNewRun == true && isLaunched == true)
                {
                    //when isNewRun is true we know that any changes to s1 and s2 after that means a launch has occured
                    //anything after this should be part of the drag
                    RunStage1Time.Text = "Running!";
                    RunStage2Time.Text = "0";

                    startRun = DateTime.Now;

                    TimeSpan reactionTime = endReactionTime.Subtract(startReactionTime);
                    FinalReactionTime.Text = reactionTime.TotalMilliseconds.ToString();
                }

                //60 foot
                if (Run60FootTime.Text == "" && isNewRun == true)
                {
                    if (s1IsTripped == true && s2IsTripped == true && s3IsTripped == true)
                    {
                        TimeSpan duration = s3Tripped.Subtract(s2Tripped);
                        Run60FootTime.Text = duration.TotalMilliseconds.ToString();
                        Final60FootTime.Text = duration.TotalSeconds.ToString();
                    }
                }

                //300 foot start
                if (Run300FootTimeStart.Text == "" && isNewRun == true)
                {
                    if (s1IsTripped == true && s2IsTripped == true && s3IsTripped == true && s4IsTripped == true)
                    {
                        TimeSpan duration = s4Tripped.Subtract(s3Tripped);
                        Run300FootTimeStart.Text = duration.TotalMilliseconds.ToString();
                        Final300FootTime.Text = duration.TotalSeconds.ToString();
                    }
                }

                //300 foot stop
                if (Run300FootTimeEnd.Text == "" && isNewRun == true)
                {
                    if (s1IsTripped == true && s2IsTripped == true && s3IsTripped == true && s4IsTripped == true && s5IsTripped == true)
                    {
                        TimeSpan duration = s5Tripped.Subtract(s4Tripped);
                        Run300FootTimeEnd.Text = duration.TotalMilliseconds.ToString();

                        double t = duration.TotalMilliseconds;
                        double d = 10;
                        double feetpermile = 5280;
                        double millisecondsperhour = 3600000;

                        FinalMPH.Text = String.Format("{0:0.00}", ((d / feetpermile) / (t / millisecondsperhour)));

                        /*
                         * equation = 
                         * 
                         * [distance in feet(d)] / [5280 feet in a mile]) 
                         * 
                         * divided by 
                         * 
                         * [time in milliseconds(t)] / [3600000 millisecons in an hour]
                         * 
                         * gives you MPH with feet and milliseconds
                         * 
                         */

                        endRun = DateTime.Now;

                        TimeSpan runTotal = endRun.Subtract(startRun);
                        Final300FootTime.Text = String.Format("{0:0.00}", runTotal.TotalSeconds.ToString());

                        //if we get this far then it is a good run and we can save it
                        saveRunButton.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
                    ex.Source + Environment.NewLine + Environment.NewLine +
                    ex.InnerException + Environment.NewLine + Environment.NewLine +
                    ex.StackTrace);
            }
        }

        //Current Drag
        private void dragButton_Click(object sender, EventArgs e)
        {
            //isNewRun = true;
        }
        private void saveRunButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal rs1 = decimal.Parse("0");
                decimal rs2 = decimal.Parse(RunStage2Time.Text);
                decimal r60 = decimal.Parse(Run60FootTime.Text);
                decimal r300s = decimal.Parse(Run300FootTimeStart.Text);
                decimal r300e = decimal.Parse(Run300FootTimeEnd.Text);
                string name = RunNameTextBox.Text;
                string notes = RunNotesTextBox.Text;
                int temp = Convert.ToInt32(double.Parse(FinalReactionTime.Text));
                decimal frt = decimal.Parse("." + temp.ToString());
                decimal f60 = decimal.Parse(Final60FootTime.Text);
                decimal f300 = decimal.Parse(Final300FootTime.Text);
                decimal fmph = decimal.Parse(FinalMPH.Text);


                string sql = @"INSERT INTO DT_Runs 
                         (stage1Time, stage2Time, sixtyFootTime, EndTimeStart, EndTimeEnd, Name, Notes, FinalReactionTime, FinalSixtyFootTime, FinalEndTime, FinalMPH) 
                          VALUES 
                         (@rs1, @rs2, @r60, @r300s, @r300e, @name, @notes, @frt, @f60, @f300, @fmph)";

                try
                {
                    SqlConnection cnx = new SqlConnection(conn);
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnx);
                    cmd.Parameters.Add(new SqlParameter("@rs1", rs1));
                    cmd.Parameters.Add(new SqlParameter("@rs2", rs2));
                    cmd.Parameters.Add(new SqlParameter("@r60", r60));
                    cmd.Parameters.Add(new SqlParameter("@r300s", r300s));
                    cmd.Parameters.Add(new SqlParameter("@r300e", r300e));
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@notes", notes));
                    cmd.Parameters.Add(new SqlParameter("@frt", frt));
                    cmd.Parameters.Add(new SqlParameter("@f60", f60));
                    cmd.Parameters.Add(new SqlParameter("@f300", f300));
                    cmd.Parameters.Add(new SqlParameter("@fmph", fmph));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cnx.Close();
                    cnx.Dispose();

                    //Reset the form controls
                    RunStage1Time.Text = String.Empty;
                    RunStage2Time.Text = String.Empty;
                    Run60FootTime.Text = String.Empty;
                    Run300FootTimeStart.Text = String.Empty;
                    Run300FootTimeEnd.Text = String.Empty;

                    RunNameTextBox.Text = String.Empty;
                    RunNotesTextBox.Text = String.Empty;

                    FinalReactionTime.Text = String.Empty;
                    Final60FootTime.Text = String.Empty;
                    Final300FootTime.Text = String.Empty;
                    FinalMPH.Text = String.Empty;

                    RunNotesTextBox.Text = String.Empty;

                    //Add new record back into the DDL
                    DataBind_previousRunSelectionDropDownList(sender, e);

                    //reset the graph
                    CreateGraph(zedGraphControl1);

                    //reset the light tree
                    ifKit.outputs[0] = false;
                    ifKit.outputs[1] = false;
                    ifKit.outputs[2] = false;
                    ifKit.outputs[3] = false;
                    ifKit.outputs[4] = false;
                    ifKit.outputs[5] = false;
                    ifKit.outputs[6] = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data to the database." + "\n\n" + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting the values to save to the database." + "\n\n" + ex.Message.ToString());
            }

        }
        private void startResetButton_Click_1(object sender, EventArgs e)
        {
            //Reset the form controls
            RunStage1Time.Text = String.Empty;
            RunStage2Time.Text = String.Empty;
            Run60FootTime.Text = String.Empty;
            Run300FootTimeStart.Text = String.Empty;
            Run300FootTimeEnd.Text = String.Empty;

            RunNameTextBox.Text = String.Empty;
            RunNotesTextBox.Text = String.Empty;

            FinalReactionTime.Text = String.Empty;
            Final60FootTime.Text = String.Empty;
            Final300FootTime.Text = String.Empty;
            FinalMPH.Text = String.Empty;

            RunNotesTextBox.Text = String.Empty;

            //Add new record back into the DDL
            DataBind_previousRunSelectionDropDownList(sender, e);

            //reset the global variables
            s1IsTripped = false;
            s2IsTripped = false;
            s3IsTripped = false;
            s4IsTripped = false;
            s5IsTripped = false;
            s1Tripped = DateTime.MinValue;
            s2Tripped = DateTime.MinValue;
            s3Tripped = DateTime.MinValue;
            s4Tripped = DateTime.MinValue;
            s5Tripped = DateTime.MinValue;
            isNewRun = false;
            isStaged = false;
            isLaunched = false;
            isRedlighted = false;
            startReactionTime = DateTime.MinValue;
            endReactionTime = DateTime.MinValue;
            startRun = DateTime.MinValue;
            endRun = DateTime.MinValue;

            //reset light tree
            prestageLabel.BackColor = Color.Black;
            prestageLabel.ForeColor = Color.Black;
            stageLabel.BackColor = Color.Black;
            stageLabel.ForeColor = Color.Black;
            set1Label.BackColor = Color.Black;
            set1Label.ForeColor = Color.Black;
            set2Label.BackColor = Color.Black;
            set2Label.ForeColor = Color.Black;
            set3Label.BackColor = Color.Black;
            set3Label.ForeColor = Color.Black;
            dragLabel.BackColor = Color.Black;
            dragLabel.ForeColor = Color.Black;
            redlightLabel.BackColor = Color.Black;
            redlightLabel.ForeColor = Color.Black;

            //reset the graph
            CreateGraph(zedGraphControl1);

            //reset the light tree
            ifKit.outputs[0] = false;
            ifKit.outputs[1] = false;
            ifKit.outputs[2] = false;
            ifKit.outputs[3] = false;
            ifKit.outputs[4] = false;
            ifKit.outputs[5] = false;
            ifKit.outputs[6] = false;
        }

        //Previous runs
        private void deleteSelectedRun_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //delete selected run from the DB
            int result = 0;
            string selectedRun = ((DataRowView)previousRunSelectionBox.SelectedItem)["runID"].ToString();
            if (selectedRun != null && Convert.ToInt32(selectedRun) > 0)
            {
                try
                {
                    SqlConnection cnx = new SqlConnection(conn);
                    cnx.Open();
                    SqlDataAdapter da = new SqlDataAdapter("DELETE FROM DT_Runs WHERE runID = '" + selectedRun + "'", cnx);
                    da.SelectCommand.CommandType = CommandType.Text;
                    SqlCommand cmd = da.SelectCommand;
                    result = cmd.ExecuteNonQuery();
                    da.Dispose();
                    cmd.Dispose();
                    cnx.Close(); cnx.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting data from the database ONINDEXCHANGE." + "\n\n" + ex.Message.ToString());
                }
            }

            if (result > 0)
            {
                //Reset the form controls
                RunStage1Time.Text = String.Empty;
                RunStage2Time.Text = String.Empty;
                Run60FootTime.Text = String.Empty;
                Run300FootTimeStart.Text = String.Empty;
                Run300FootTimeEnd.Text = String.Empty;

                RunNameTextBox.Text = String.Empty;
                RunNotesTextBox.Text = String.Empty;

                FinalReactionTime.Text = String.Empty;
                Final60FootTime.Text = String.Empty;
                Final300FootTime.Text = String.Empty;
                FinalMPH.Text = String.Empty;

                RunNotesTextBox.Text = String.Empty;

                //Add new record back into the DDL
                DataBind_previousRunSelectionDropDownList(sender, e);

                //reset the graph
                CreateGraph(zedGraphControl1);
            }
            else
            {
                MessageBox.Show("Unable to delete record from the database.");
            }
        }

        //Drop down list events / methods
        private void DataBind_previousRunSelectionDropDownList(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //previousRunSelection.DataSource = null;

            try
            {
                SqlConnection cnx = new SqlConnection(conn);
                cnx.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT runID, Name FROM DT_Runs", cnx);
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(ds);
                da.Dispose();
                cnx.Close(); cnx.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting previous runs from the database." + "\n\n" + ex.Message.ToString());
            }

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                //previousRunSelection.ValueMember = ds.Tables[0].Columns["runID"].ToString();
                //previousRunSelection.DisplayMember = ds.Tables[0].Columns["Name"].ToString();
                //previousRunSelection.DataSource = ds.Tables[0];

                previousRunSelectionBox.ValueMember = ds.Tables[0].Columns["runID"].ToString();
                previousRunSelectionBox.DisplayMember = ds.Tables[0].Columns["Name"].ToString();
                previousRunSelectionBox.DataSource = ds.Tables[0];
            }
        }
        private void previousRunSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previousRunSelectionBox.SelectedIndex != 0)
            {

                DataSet ds = new DataSet();

                if (previousRunSelectionBox.SelectedIndex > -1)
                {
                    //works on load
                    string selectedRun = ((DataRowView)previousRunSelectionBox.SelectedItem)["runID"].ToString();
                    //works after load
                    //string selectedRun = previousRunSelection.Items[previousRunSelection.SelectedIndex].ToString();
                    if (selectedRun != null && Convert.ToInt32(selectedRun) > 0)
                    {
                        try
                        {
                            SqlConnection cnx = new SqlConnection(conn);
                            cnx.Open();
                            SqlDataAdapter da = new SqlDataAdapter("SELECT runID, stage1Time, stage2Time, sixtyFootTime, EndTimeStart, EndTimeEnd, Name, Notes, FinalReactionTime, FinalSixtyFootTime, FinalEndTime, FinalMPH FROM DT_Runs WHERE runID = '" + selectedRun + "'", cnx);
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.Fill(ds);
                            da.Dispose();
                            cnx.Close(); cnx.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error getting data from the database ONINDEXCHANGE." + "\n\n" + ex.Message.ToString());
                        }
                    }
                }

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count == 1)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            RunStage1Time.Text = String.Format("{0:0}", row["stage1Time"]);
                            RunStage2Time.Text = String.Format("{0:0}", row["stage2Time"]);
                            Run60FootTime.Text = String.Format("{0:0}", row["sixtyFootTime"]);
                            Run300FootTimeStart.Text = String.Format("{0:0}", row["EndTimeStart"]);
                            Run300FootTimeEnd.Text = String.Format("{0:0}", row["EndTimeEnd"]);

                            RunNameTextBox.Text = row["Name"].ToString();
                            RunNotesTextBox.Text = row["Notes"].ToString();

                            FinalReactionTime.Text = String.Format("{0:.000}", row["FinalReactionTime"]);
                            Final60FootTime.Text = String.Format("{0:0.00}", row["FinalSixtyFootTime"]);
                            Final300FootTime.Text = String.Format("{0:0.00}", row["FinalEndTime"]);
                            FinalMPH.Text = String.Format("{0:0.00}", row["FinalMPH"]);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Selectiong returned more than one record!");
                    }
                }

                CreateGraph(zedGraphControl1);

                saveRunButton.Enabled = false;
                deleteSelectedRun.Enabled = true;

                RunNameTextBox.ReadOnly = true;
                RunNotesTextBox.ReadOnly = true;
            }
            else
            {
                //saveRunButton.Enabled = true; //nope, only when we have good data
                deleteSelectedRun.Enabled = false;

                RunStage1Time.Text = String.Empty;
                RunStage2Time.Text = String.Empty;
                Run60FootTime.Text = String.Empty;
                Run300FootTimeStart.Text = String.Empty;
                Run300FootTimeEnd.Text = String.Empty;

                RunNameTextBox.Text = String.Empty;
                RunNotesTextBox.Text = String.Empty;

                FinalReactionTime.Text = String.Empty;
                Final60FootTime.Text = String.Empty;
                Final300FootTime.Text = String.Empty;
                FinalMPH.Text = String.Empty;

                RunNotesTextBox.Text = String.Empty;

                CreateGraph(zedGraphControl1);

                RunNameTextBox.ReadOnly = false;
                RunNotesTextBox.ReadOnly = false;
            }
        }

        private void lightTestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lightTestCheckBox.Checked == true)
            {
                ifKit.outputs[0] = true;
                ifKit.outputs[1] = true;
                ifKit.outputs[2] = true;
                ifKit.outputs[3] = true;
                ifKit.outputs[4] = true;
                ifKit.outputs[5] = true;
                ifKit.outputs[6] = true;
            }
            else
            {
                ifKit.outputs[0] = false;
                ifKit.outputs[1] = false;
                ifKit.outputs[2] = false;
                ifKit.outputs[3] = false;
                ifKit.outputs[4] = false;
                ifKit.outputs[5] = false;
                ifKit.outputs[6] = false;
            }
        }
        
        //Graph
        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = new GraphPane();

            // Set the titles and axis labels
            myPane.Title.Text = "Course Graph";
            myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = "Distance";
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.Text = "Seconds";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();

            //double doesn't work, for a line you need a list
            if (FinalReactionTime.Text != "")
            {
                if (Final60FootTime.Text != "")
                {
                    if (Final300FootTime.Text != "")
                    {
                        list.Add(1, double.Parse(FinalReactionTime.Text));
                        list.Add(2, double.Parse(Final60FootTime.Text));
                        list.Add(3, double.Parse(Final300FootTime.Text));
                    }
                }
            }

            //X data points
            string[] x = { "Reaction Time", "60 Foot", "300 Foot" };

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = x;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // disable the legend
            myPane.Legend.IsVisible = false;

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("Data Markers", list, Color.Blue, SymbolType.Circle);

            myPane.YAxis.Scale.MajorStep = 1;
            myPane.YAxis.Scale.MinorStep = .5;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            // Add some text inside the above box to indicate "Peak Range"
            TextObj myText = new TextObj("Peak Range", 5, 5);
            myText.Location.CoordinateFrame = CoordType.AxisXYScale;
            myText.Location.AlignH = AlignH.Right;
            myText.Location.AlignV = AlignV.Center;
            myText.FontSpec.IsItalic = true;
            myText.FontSpec.IsBold = false;
            myText.FontSpec.Fill.IsVisible = false;
            myText.FontSpec.Border.IsVisible = false;
            myPane.GraphObjList.Add(myText);

            //set some overall properties
            zgc.IsShowContextMenu = true;
            zgc.IsShowPointValues = true;
            zgc.IsAntiAlias = true;

            //update the graph UI
            myPane.Rect = new System.Drawing.RectangleF(0, 0, 736, 262);
            zgc.GraphPane = myPane;
            zgc.AxisChange();
            zgc.Refresh();
        }

        //Application exit
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ifKit.Attached == true)
            {
                ifKit.close();
                ifKit = null;
            }
            Application.Exit();
        }

        private void testSensorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SensorConfigForm configForm = new SensorConfigForm();

            if (testSensorsCheckBox.Checked == true)
            {
                ifKit.close();
                configForm.Show();
            }
            else
            {
                Form1_Load(sender, e);
            }
            
        }
    }
}
