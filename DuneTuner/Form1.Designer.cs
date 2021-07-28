namespace DuneTuner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.previousRunSelectionBox = new System.Windows.Forms.ListBox();
            this.deleteSelectedRun = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.redlightLabel = new System.Windows.Forms.Label();
            this.dragLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.set3Label = new System.Windows.Forms.Label();
            this.RunDateTimeLabel = new System.Windows.Forms.Label();
            this.set2Label = new System.Windows.Forms.Label();
            this.set1Label = new System.Windows.Forms.Label();
            this.RunNameTextBox = new System.Windows.Forms.TextBox();
            this.prestageLabel = new System.Windows.Forms.Label();
            this.stageLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.RunNotesTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.startResetButton = new System.Windows.Forms.Button();
            this.FinalMPH = new System.Windows.Forms.TextBox();
            this.Final300FootTime = new System.Windows.Forms.TextBox();
            this.Final60FootTime = new System.Windows.Forms.TextBox();
            this.FinalReactionTime = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Run300FootTimeEnd = new System.Windows.Forms.TextBox();
            this.Run300FootTimeStart = new System.Windows.Forms.TextBox();
            this.Run60FootTime = new System.Windows.Forms.TextBox();
            this.RunStage2Time = new System.Windows.Forms.TextBox();
            this.RunStage1Time = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saveRunButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lightTestCheckBox = new System.Windows.Forms.CheckBox();
            this.setSensorValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.connectionlabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.set5Sensitivity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.set4Sensitivity = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.set3Sensitivity = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.set2Sensitivity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.set1Sensitivity = new System.Windows.Forms.Button();
            this.s1value = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.s5sensitivity = new System.Windows.Forms.TextBox();
            this.s2value = new System.Windows.Forms.TextBox();
            this.s4sensitivity = new System.Windows.Forms.TextBox();
            this.s3value = new System.Windows.Forms.TextBox();
            this.s3sensitivity = new System.Windows.Forms.TextBox();
            this.s4value = new System.Windows.Forms.TextBox();
            this.s2sensitivity = new System.Windows.Forms.TextBox();
            this.s5value = new System.Windows.Forms.TextBox();
            this.s1sensitivity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.testSensorsCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.previousRunSelectionBox);
            this.mainPanel.Controls.Add(this.deleteSelectedRun);
            this.mainPanel.Controls.Add(this.groupBox3);
            this.mainPanel.Controls.Add(this.label18);
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(775, 661);
            this.mainPanel.TabIndex = 0;
            // 
            // previousRunSelectionBox
            // 
            this.previousRunSelectionBox.FormattingEnabled = true;
            this.previousRunSelectionBox.Location = new System.Drawing.Point(219, 296);
            this.previousRunSelectionBox.Name = "previousRunSelectionBox";
            this.previousRunSelectionBox.Size = new System.Drawing.Size(479, 56);
            this.previousRunSelectionBox.TabIndex = 12;
            this.previousRunSelectionBox.SelectedIndexChanged += new System.EventHandler(this.previousRunSelectionBox_SelectedIndexChanged);
            // 
            // deleteSelectedRun
            // 
            this.deleteSelectedRun.AutoSize = true;
            this.deleteSelectedRun.Enabled = false;
            this.deleteSelectedRun.Location = new System.Drawing.Point(704, 304);
            this.deleteSelectedRun.Name = "deleteSelectedRun";
            this.deleteSelectedRun.Size = new System.Drawing.Size(38, 13);
            this.deleteSelectedRun.TabIndex = 11;
            this.deleteSelectedRun.TabStop = true;
            this.deleteSelectedRun.Text = "Delete";
            this.deleteSelectedRun.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteSelectedRun_LinkClicked_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zedGraphControl1);
            this.groupBox3.Location = new System.Drawing.Point(-3, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 296);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Course Chart";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(9, 19);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(736, 262);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(15, 304);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Select a previous run to view the details:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.redlightLabel);
            this.groupBox2.Controls.Add(this.dragLabel);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.set3Label);
            this.groupBox2.Controls.Add(this.RunDateTimeLabel);
            this.groupBox2.Controls.Add(this.set2Label);
            this.groupBox2.Controls.Add(this.set1Label);
            this.groupBox2.Controls.Add(this.RunNameTextBox);
            this.groupBox2.Controls.Add(this.prestageLabel);
            this.groupBox2.Controls.Add(this.stageLabel);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.RunNotesTextBox);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.startResetButton);
            this.groupBox2.Controls.Add(this.FinalMPH);
            this.groupBox2.Controls.Add(this.Final300FootTime);
            this.groupBox2.Controls.Add(this.Final60FootTime);
            this.groupBox2.Controls.Add(this.FinalReactionTime);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.Run300FootTimeEnd);
            this.groupBox2.Controls.Add(this.Run300FootTimeStart);
            this.groupBox2.Controls.Add(this.Run60FootTime);
            this.groupBox2.Controls.Add(this.RunStage2Time);
            this.groupBox2.Controls.Add(this.RunStage1Time);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.saveRunButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 287);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Run";
            // 
            // redlightLabel
            // 
            this.redlightLabel.AutoSize = true;
            this.redlightLabel.BackColor = System.Drawing.Color.Black;
            this.redlightLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redlightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redlightLabel.ForeColor = System.Drawing.Color.Black;
            this.redlightLabel.Location = new System.Drawing.Point(15, 191);
            this.redlightLabel.Name = "redlightLabel";
            this.redlightLabel.Size = new System.Drawing.Size(14, 19);
            this.redlightLabel.TabIndex = 32;
            this.redlightLabel.Text = ".";
            this.redlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dragLabel
            // 
            this.dragLabel.AutoSize = true;
            this.dragLabel.BackColor = System.Drawing.Color.Black;
            this.dragLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dragLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dragLabel.ForeColor = System.Drawing.Color.Black;
            this.dragLabel.Location = new System.Drawing.Point(15, 172);
            this.dragLabel.Name = "dragLabel";
            this.dragLabel.Size = new System.Drawing.Size(14, 19);
            this.dragLabel.TabIndex = 31;
            this.dragLabel.Text = ".";
            this.dragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(245, 166);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 25;
            this.label21.Text = "Run Date-Time";
            // 
            // set3Label
            // 
            this.set3Label.AutoSize = true;
            this.set3Label.BackColor = System.Drawing.Color.Black;
            this.set3Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set3Label.ForeColor = System.Drawing.Color.Black;
            this.set3Label.Location = new System.Drawing.Point(15, 153);
            this.set3Label.Name = "set3Label";
            this.set3Label.Size = new System.Drawing.Size(14, 19);
            this.set3Label.TabIndex = 30;
            this.set3Label.Text = ".";
            this.set3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunDateTimeLabel
            // 
            this.RunDateTimeLabel.AutoSize = true;
            this.RunDateTimeLabel.Location = new System.Drawing.Point(327, 166);
            this.RunDateTimeLabel.Name = "RunDateTimeLabel";
            this.RunDateTimeLabel.Size = new System.Drawing.Size(47, 13);
            this.RunDateTimeLabel.TabIndex = 24;
            this.RunDateTimeLabel.Text = "datetime";
            // 
            // set2Label
            // 
            this.set2Label.AutoSize = true;
            this.set2Label.BackColor = System.Drawing.Color.Black;
            this.set2Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set2Label.ForeColor = System.Drawing.Color.Black;
            this.set2Label.Location = new System.Drawing.Point(15, 134);
            this.set2Label.Name = "set2Label";
            this.set2Label.Size = new System.Drawing.Size(14, 19);
            this.set2Label.TabIndex = 29;
            this.set2Label.Text = ".";
            this.set2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // set1Label
            // 
            this.set1Label.AutoSize = true;
            this.set1Label.BackColor = System.Drawing.Color.Black;
            this.set1Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set1Label.ForeColor = System.Drawing.Color.Black;
            this.set1Label.Location = new System.Drawing.Point(15, 115);
            this.set1Label.Name = "set1Label";
            this.set1Label.Size = new System.Drawing.Size(14, 19);
            this.set1Label.TabIndex = 28;
            this.set1Label.Text = ".";
            this.set1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunNameTextBox
            // 
            this.RunNameTextBox.Location = new System.Drawing.Point(119, 163);
            this.RunNameTextBox.Name = "RunNameTextBox";
            this.RunNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.RunNameTextBox.TabIndex = 23;
            // 
            // prestageLabel
            // 
            this.prestageLabel.AutoSize = true;
            this.prestageLabel.BackColor = System.Drawing.Color.Black;
            this.prestageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prestageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prestageLabel.ForeColor = System.Drawing.Color.Black;
            this.prestageLabel.Location = new System.Drawing.Point(15, 77);
            this.prestageLabel.Name = "prestageLabel";
            this.prestageLabel.Size = new System.Drawing.Size(14, 19);
            this.prestageLabel.TabIndex = 22;
            this.prestageLabel.Text = ".";
            this.prestageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stageLabel
            // 
            this.stageLabel.AutoSize = true;
            this.stageLabel.BackColor = System.Drawing.Color.Black;
            this.stageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageLabel.ForeColor = System.Drawing.Color.Black;
            this.stageLabel.Location = new System.Drawing.Point(15, 96);
            this.stageLabel.Name = "stageLabel";
            this.stageLabel.Size = new System.Drawing.Size(14, 19);
            this.stageLabel.TabIndex = 27;
            this.stageLabel.Text = ".";
            this.stageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(47, 166);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Rider Name:";
            // 
            // RunNotesTextBox
            // 
            this.RunNotesTextBox.Location = new System.Drawing.Point(119, 189);
            this.RunNotesTextBox.Multiline = true;
            this.RunNotesTextBox.Name = "RunNotesTextBox";
            this.RunNotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RunNotesTextBox.Size = new System.Drawing.Size(335, 73);
            this.RunNotesTextBox.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(44, 201);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Setup Notes:";
            // 
            // startResetButton
            // 
            this.startResetButton.Location = new System.Drawing.Point(375, 24);
            this.startResetButton.Name = "startResetButton";
            this.startResetButton.Size = new System.Drawing.Size(79, 23);
            this.startResetButton.TabIndex = 11;
            this.startResetButton.Text = "Stop/Reset";
            this.startResetButton.UseVisualStyleBackColor = true;
            this.startResetButton.Click += new System.EventHandler(this.startResetButton_Click_1);
            // 
            // FinalMPH
            // 
            this.FinalMPH.Location = new System.Drawing.Point(354, 131);
            this.FinalMPH.Name = "FinalMPH";
            this.FinalMPH.ReadOnly = true;
            this.FinalMPH.Size = new System.Drawing.Size(100, 20);
            this.FinalMPH.TabIndex = 19;
            // 
            // Final300FootTime
            // 
            this.Final300FootTime.Location = new System.Drawing.Point(354, 105);
            this.Final300FootTime.Name = "Final300FootTime";
            this.Final300FootTime.ReadOnly = true;
            this.Final300FootTime.Size = new System.Drawing.Size(100, 20);
            this.Final300FootTime.TabIndex = 18;
            // 
            // Final60FootTime
            // 
            this.Final60FootTime.Location = new System.Drawing.Point(354, 79);
            this.Final60FootTime.Name = "Final60FootTime";
            this.Final60FootTime.ReadOnly = true;
            this.Final60FootTime.Size = new System.Drawing.Size(100, 20);
            this.Final60FootTime.TabIndex = 17;
            // 
            // FinalReactionTime
            // 
            this.FinalReactionTime.Location = new System.Drawing.Point(354, 53);
            this.FinalReactionTime.Name = "FinalReactionTime";
            this.FinalReactionTime.ReadOnly = true;
            this.FinalReactionTime.Size = new System.Drawing.Size(100, 20);
            this.FinalReactionTime.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(297, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Final MPH:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(252, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "300 Foot Time [sec]:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(258, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "60 Foot Time [sec]:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(246, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Reaction Time [sec]:";
            // 
            // Run300FootTimeEnd
            // 
            this.Run300FootTimeEnd.Location = new System.Drawing.Point(119, 133);
            this.Run300FootTimeEnd.Name = "Run300FootTimeEnd";
            this.Run300FootTimeEnd.ReadOnly = true;
            this.Run300FootTimeEnd.Size = new System.Drawing.Size(100, 20);
            this.Run300FootTimeEnd.TabIndex = 10;
            // 
            // Run300FootTimeStart
            // 
            this.Run300FootTimeStart.Location = new System.Drawing.Point(119, 107);
            this.Run300FootTimeStart.Name = "Run300FootTimeStart";
            this.Run300FootTimeStart.ReadOnly = true;
            this.Run300FootTimeStart.Size = new System.Drawing.Size(100, 20);
            this.Run300FootTimeStart.TabIndex = 9;
            // 
            // Run60FootTime
            // 
            this.Run60FootTime.Location = new System.Drawing.Point(119, 81);
            this.Run60FootTime.Name = "Run60FootTime";
            this.Run60FootTime.ReadOnly = true;
            this.Run60FootTime.Size = new System.Drawing.Size(100, 20);
            this.Run60FootTime.TabIndex = 8;
            // 
            // RunStage2Time
            // 
            this.RunStage2Time.Location = new System.Drawing.Point(119, 55);
            this.RunStage2Time.Name = "RunStage2Time";
            this.RunStage2Time.ReadOnly = true;
            this.RunStage2Time.Size = new System.Drawing.Size(100, 20);
            this.RunStage2Time.TabIndex = 7;
            // 
            // RunStage1Time
            // 
            this.RunStage1Time.Location = new System.Drawing.Point(119, 29);
            this.RunStage1Time.Name = "RunStage1Time";
            this.RunStage1Time.ReadOnly = true;
            this.RunStage1Time.Size = new System.Drawing.Size(100, 20);
            this.RunStage1Time.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "300 foot end";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "300 foot start";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "60 foot time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Stage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "PreStage";
            // 
            // saveRunButton
            // 
            this.saveRunButton.Location = new System.Drawing.Point(391, 156);
            this.saveRunButton.Name = "saveRunButton";
            this.saveRunButton.Size = new System.Drawing.Size(63, 23);
            this.saveRunButton.TabIndex = 0;
            this.saveRunButton.Text = "Save Run";
            this.saveRunButton.UseVisualStyleBackColor = true;
            this.saveRunButton.Click += new System.EventHandler(this.saveRunButton_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.testSensorsCheckBox);
            this.groupBox1.Controls.Add(this.lightTestCheckBox);
            this.groupBox1.Controls.Add(this.setSensorValuesCheckBox);
            this.groupBox1.Controls.Add(this.connectionlabel);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.set5Sensitivity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.set4Sensitivity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.set3Sensitivity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.set2Sensitivity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.set1Sensitivity);
            this.groupBox1.Controls.Add(this.s1value);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.s5sensitivity);
            this.groupBox1.Controls.Add(this.s2value);
            this.groupBox1.Controls.Add(this.s4sensitivity);
            this.groupBox1.Controls.Add(this.s3value);
            this.groupBox1.Controls.Add(this.s3sensitivity);
            this.groupBox1.Controls.Add(this.s4value);
            this.groupBox1.Controls.Add(this.s2sensitivity);
            this.groupBox1.Controls.Add(this.s5value);
            this.groupBox1.Controls.Add(this.s1sensitivity);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(487, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 287);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Configuration";
            // 
            // lightTestCheckBox
            // 
            this.lightTestCheckBox.AutoSize = true;
            this.lightTestCheckBox.Location = new System.Drawing.Point(40, 245);
            this.lightTestCheckBox.Name = "lightTestCheckBox";
            this.lightTestCheckBox.Size = new System.Drawing.Size(98, 17);
            this.lightTestCheckBox.TabIndex = 23;
            this.lightTestCheckBox.Text = "Test Light Tree";
            this.lightTestCheckBox.UseVisualStyleBackColor = true;
            this.lightTestCheckBox.CheckedChanged += new System.EventHandler(this.lightTestCheckBox_CheckedChanged);
            // 
            // setSensorValuesCheckBox
            // 
            this.setSensorValuesCheckBox.AutoSize = true;
            this.setSensorValuesCheckBox.Location = new System.Drawing.Point(205, 70);
            this.setSensorValuesCheckBox.Name = "setSensorValuesCheckBox";
            this.setSensorValuesCheckBox.Size = new System.Drawing.Size(42, 17);
            this.setSensorValuesCheckBox.TabIndex = 22;
            this.setSensorValuesCheckBox.Text = "Set";
            this.setSensorValuesCheckBox.UseVisualStyleBackColor = true;
            this.setSensorValuesCheckBox.CheckedChanged += new System.EventHandler(this.setSensorValuesCheckBox_CheckedChanged);
            // 
            // connectionlabel
            // 
            this.connectionlabel.AutoSize = true;
            this.connectionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionlabel.ForeColor = System.Drawing.Color.Red;
            this.connectionlabel.Location = new System.Drawing.Point(120, 43);
            this.connectionlabel.Name = "connectionlabel";
            this.connectionlabel.Size = new System.Drawing.Size(96, 13);
            this.connectionlabel.TabIndex = 21;
            this.connectionlabel.Text = "Not Connected.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(77, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Status:";
            // 
            // set5Sensitivity
            // 
            this.set5Sensitivity.Location = new System.Drawing.Point(200, 197);
            this.set5Sensitivity.Name = "set5Sensitivity";
            this.set5Sensitivity.Size = new System.Drawing.Size(39, 23);
            this.set5Sensitivity.TabIndex = 19;
            this.set5Sensitivity.Text = "Set";
            this.set5Sensitivity.UseVisualStyleBackColor = true;
            this.set5Sensitivity.Click += new System.EventHandler(this.set5Sensitivity_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sensor 1";
            // 
            // set4Sensitivity
            // 
            this.set4Sensitivity.Location = new System.Drawing.Point(200, 171);
            this.set4Sensitivity.Name = "set4Sensitivity";
            this.set4Sensitivity.Size = new System.Drawing.Size(39, 23);
            this.set4Sensitivity.TabIndex = 18;
            this.set4Sensitivity.Text = "Set";
            this.set4Sensitivity.UseVisualStyleBackColor = true;
            this.set4Sensitivity.Click += new System.EventHandler(this.set4Sensitivity_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sensor 2";
            // 
            // set3Sensitivity
            // 
            this.set3Sensitivity.Location = new System.Drawing.Point(200, 145);
            this.set3Sensitivity.Name = "set3Sensitivity";
            this.set3Sensitivity.Size = new System.Drawing.Size(39, 23);
            this.set3Sensitivity.TabIndex = 17;
            this.set3Sensitivity.Text = "Set";
            this.set3Sensitivity.UseVisualStyleBackColor = true;
            this.set3Sensitivity.Click += new System.EventHandler(this.set3Sensitivity_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sensor 3";
            // 
            // set2Sensitivity
            // 
            this.set2Sensitivity.Location = new System.Drawing.Point(200, 119);
            this.set2Sensitivity.Name = "set2Sensitivity";
            this.set2Sensitivity.Size = new System.Drawing.Size(39, 23);
            this.set2Sensitivity.TabIndex = 16;
            this.set2Sensitivity.Text = "Set";
            this.set2Sensitivity.UseVisualStyleBackColor = true;
            this.set2Sensitivity.Click += new System.EventHandler(this.set2Sensitivity_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sensor 4";
            // 
            // set1Sensitivity
            // 
            this.set1Sensitivity.Location = new System.Drawing.Point(200, 93);
            this.set1Sensitivity.Name = "set1Sensitivity";
            this.set1Sensitivity.Size = new System.Drawing.Size(39, 23);
            this.set1Sensitivity.TabIndex = 15;
            this.set1Sensitivity.Text = "Set";
            this.set1Sensitivity.UseVisualStyleBackColor = true;
            this.set1Sensitivity.Click += new System.EventHandler(this.set1Sensitivity_Click_1);
            // 
            // s1value
            // 
            this.s1value.Location = new System.Drawing.Point(88, 95);
            this.s1value.Name = "s1value";
            this.s1value.ReadOnly = true;
            this.s1value.Size = new System.Drawing.Size(50, 20);
            this.s1value.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Sensetivity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sensor 5";
            // 
            // s5sensitivity
            // 
            this.s5sensitivity.Location = new System.Drawing.Point(144, 199);
            this.s5sensitivity.Name = "s5sensitivity";
            this.s5sensitivity.Size = new System.Drawing.Size(50, 20);
            this.s5sensitivity.TabIndex = 13;
            // 
            // s2value
            // 
            this.s2value.Location = new System.Drawing.Point(88, 121);
            this.s2value.Name = "s2value";
            this.s2value.ReadOnly = true;
            this.s2value.Size = new System.Drawing.Size(50, 20);
            this.s2value.TabIndex = 5;
            // 
            // s4sensitivity
            // 
            this.s4sensitivity.Location = new System.Drawing.Point(144, 173);
            this.s4sensitivity.Name = "s4sensitivity";
            this.s4sensitivity.Size = new System.Drawing.Size(50, 20);
            this.s4sensitivity.TabIndex = 12;
            // 
            // s3value
            // 
            this.s3value.Location = new System.Drawing.Point(88, 147);
            this.s3value.Name = "s3value";
            this.s3value.ReadOnly = true;
            this.s3value.Size = new System.Drawing.Size(50, 20);
            this.s3value.TabIndex = 6;
            // 
            // s3sensitivity
            // 
            this.s3sensitivity.Location = new System.Drawing.Point(144, 147);
            this.s3sensitivity.Name = "s3sensitivity";
            this.s3sensitivity.Size = new System.Drawing.Size(50, 20);
            this.s3sensitivity.TabIndex = 11;
            // 
            // s4value
            // 
            this.s4value.Location = new System.Drawing.Point(88, 173);
            this.s4value.Name = "s4value";
            this.s4value.ReadOnly = true;
            this.s4value.Size = new System.Drawing.Size(50, 20);
            this.s4value.TabIndex = 7;
            // 
            // s2sensitivity
            // 
            this.s2sensitivity.Location = new System.Drawing.Point(144, 121);
            this.s2sensitivity.Name = "s2sensitivity";
            this.s2sensitivity.Size = new System.Drawing.Size(50, 20);
            this.s2sensitivity.TabIndex = 10;
            // 
            // s5value
            // 
            this.s5value.Location = new System.Drawing.Point(88, 199);
            this.s5value.Name = "s5value";
            this.s5value.ReadOnly = true;
            this.s5value.Size = new System.Drawing.Size(50, 20);
            this.s5value.TabIndex = 8;
            // 
            // s1sensitivity
            // 
            this.s1sensitivity.Location = new System.Drawing.Point(144, 95);
            this.s1sensitivity.Name = "s1sensitivity";
            this.s1sensitivity.Size = new System.Drawing.Size(50, 20);
            this.s1sensitivity.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Value";
            // 
            // testSensorsCheckBox
            // 
            this.testSensorsCheckBox.AutoSize = true;
            this.testSensorsCheckBox.Location = new System.Drawing.Point(144, 245);
            this.testSensorsCheckBox.Name = "testSensorsCheckBox";
            this.testSensorsCheckBox.Size = new System.Drawing.Size(88, 17);
            this.testSensorsCheckBox.TabIndex = 24;
            this.testSensorsCheckBox.Text = "Test Sensors";
            this.testSensorsCheckBox.UseVisualStyleBackColor = true;
            this.testSensorsCheckBox.CheckedChanged += new System.EventHandler(this.testSensorsCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(797, 686);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(813, 722);
            this.MinimumSize = new System.Drawing.Size(813, 722);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "robault.com - - - Drag Tuner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.LinkLabel deleteSelectedRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RunNotesTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button startResetButton;
        private System.Windows.Forms.TextBox FinalMPH;
        private System.Windows.Forms.TextBox Final300FootTime;
        private System.Windows.Forms.TextBox Final60FootTime;
        private System.Windows.Forms.TextBox FinalReactionTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Run300FootTimeEnd;
        private System.Windows.Forms.TextBox Run300FootTimeStart;
        private System.Windows.Forms.TextBox Run60FootTime;
        private System.Windows.Forms.TextBox RunStage2Time;
        private System.Windows.Forms.TextBox RunStage1Time;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveRunButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label connectionlabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button set5Sensitivity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button set4Sensitivity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button set3Sensitivity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button set2Sensitivity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button set1Sensitivity;
        private System.Windows.Forms.TextBox s1value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox s5sensitivity;
        private System.Windows.Forms.TextBox s2value;
        private System.Windows.Forms.TextBox s4sensitivity;
        private System.Windows.Forms.TextBox s3value;
        private System.Windows.Forms.TextBox s3sensitivity;
        private System.Windows.Forms.TextBox s4value;
        private System.Windows.Forms.TextBox s2sensitivity;
        private System.Windows.Forms.TextBox s5value;
        private System.Windows.Forms.TextBox s1sensitivity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label RunDateTimeLabel;
        private System.Windows.Forms.TextBox RunNameTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox previousRunSelectionBox;
        private System.Windows.Forms.Label prestageLabel;
        private System.Windows.Forms.Label stageLabel;
        private System.Windows.Forms.Label set1Label;
        private System.Windows.Forms.Label set2Label;
        private System.Windows.Forms.Label set3Label;
        private System.Windows.Forms.Label dragLabel;
        private System.Windows.Forms.Label redlightLabel;
        private System.Windows.Forms.CheckBox setSensorValuesCheckBox;
        private System.Windows.Forms.CheckBox lightTestCheckBox;
        private System.Windows.Forms.CheckBox testSensorsCheckBox;


    }
}

