
namespace BNSfishing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.processTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.fishingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.windowCheckBox = new System.Windows.Forms.CheckBox();
            this.predefinedComboBox = new System.Windows.Forms.ComboBox();
            this.counterTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxCounter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEstimateTotal = new System.Windows.Forms.TextBox();
            this.textBoxEstimateRecent = new System.Windows.Forms.TextBox();
            this.textBoxAvgTotal = new System.Windows.Forms.TextBox();
            this.textBoxAvgRecent = new System.Windows.Forms.TextBox();
            this.textBoxStartedTime = new System.Windows.Forms.TextBox();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.groupBoxFishingMode = new System.Windows.Forms.GroupBox();
            this.radioButtonFastest = new System.Windows.Forms.RadioButton();
            this.radioButtonFaster = new System.Windows.Forms.RadioButton();
            this.radioButtonModerate = new System.Windows.Forms.RadioButton();
            this.radioButtonEmulate = new System.Windows.Forms.RadioButton();
            this.textBoxElapsed = new System.Windows.Forms.TextBox();
            this.textBoxLeftTime = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBoxFishingMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(0, 181);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(179, 42);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // processTextBox
            // 
            this.processTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.processTextBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.processTextBox.Location = new System.Drawing.Point(0, 0);
            this.processTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processTextBox.Name = "processTextBox";
            this.processTextBox.ReadOnly = true;
            this.processTextBox.Size = new System.Drawing.Size(521, 32);
            this.processTextBox.TabIndex = 1;
            this.processTextBox.Text = "BNSR";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(183, 181);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(179, 42);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusTextBox.Location = new System.Drawing.Point(0, 333);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(521, 93);
            this.statusTextBox.TabIndex = 3;
            // 
            // fishingBackgroundWorker
            // 
            this.fishingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fishingBackgroundWorker_DoWork);
            this.fishingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fishingBackgroundWorker_RunWorkerCompleted);
            // 
            // xTextBox
            // 
            this.xTextBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.xTextBox.Location = new System.Drawing.Point(38, 48);
            this.xTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(121, 32);
            this.xTextBox.TabIndex = 4;
            this.xTextBox.Text = "1152";
            // 
            // yTextBox
            // 
            this.yTextBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yTextBox.Location = new System.Drawing.Point(217, 48);
            this.yTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(121, 32);
            this.yTextBox.TabIndex = 5;
            this.yTextBox.Text = "678";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(181, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "y";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(521, 30);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 25);
            this.statusLabel.Text = "OK";
            // 
            // windowCheckBox
            // 
            this.windowCheckBox.AutoSize = true;
            this.windowCheckBox.Location = new System.Drawing.Point(357, 54);
            this.windowCheckBox.Name = "windowCheckBox";
            this.windowCheckBox.Size = new System.Drawing.Size(132, 24);
            this.windowCheckBox.TabIndex = 9;
            this.windowCheckBox.Text = "Windows Mode";
            this.windowCheckBox.UseVisualStyleBackColor = true;
            // 
            // predefinedComboBox
            // 
            this.predefinedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.predefinedComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.predefinedComboBox.FormattingEnabled = true;
            this.predefinedComboBox.Items.AddRange(new object[] {
            "Mouse",
            "1152, 678, [1920x1080 standard]",
            "1875, 929, [1920x1080 corner]",
            "1046, 580, [window, standard]",
            "1300, 694, [window, corner]"});
            this.predefinedComboBox.Location = new System.Drawing.Point(38, 91);
            this.predefinedComboBox.Name = "predefinedComboBox";
            this.predefinedComboBox.Size = new System.Drawing.Size(299, 28);
            this.predefinedComboBox.TabIndex = 10;
            this.predefinedComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // counterTextBox
            // 
            this.counterTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.counterTextBox.Location = new System.Drawing.Point(344, 91);
            this.counterTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.counterTextBox.Name = "counterTextBox";
            this.counterTextBox.Size = new System.Drawing.Size(173, 33);
            this.counterTextBox.TabIndex = 11;
            this.counterTextBox.Text = "1500";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(418, 263);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 32);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(418, 298);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 32);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxCounter
            // 
            this.textBoxCounter.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCounter.Location = new System.Drawing.Point(85, 229);
            this.textBoxCounter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxCounter.Name = "textBoxCounter";
            this.textBoxCounter.ReadOnly = true;
            this.textBoxCounter.Size = new System.Drawing.Size(71, 32);
            this.textBoxCounter.TabIndex = 17;
            this.textBoxCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Counter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Estimate (Total)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Estimate (Recent)";
            // 
            // textBoxEstimateTotal
            // 
            this.textBoxEstimateTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEstimateTotal.Location = new System.Drawing.Point(157, 263);
            this.textBoxEstimateTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxEstimateTotal.Name = "textBoxEstimateTotal";
            this.textBoxEstimateTotal.ReadOnly = true;
            this.textBoxEstimateTotal.Size = new System.Drawing.Size(141, 32);
            this.textBoxEstimateTotal.TabIndex = 27;
            this.textBoxEstimateTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxEstimateRecent
            // 
            this.textBoxEstimateRecent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEstimateRecent.Location = new System.Drawing.Point(157, 298);
            this.textBoxEstimateRecent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxEstimateRecent.Name = "textBoxEstimateRecent";
            this.textBoxEstimateRecent.ReadOnly = true;
            this.textBoxEstimateRecent.Size = new System.Drawing.Size(141, 32);
            this.textBoxEstimateRecent.TabIndex = 28;
            this.textBoxEstimateRecent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAvgTotal
            // 
            this.textBoxAvgTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAvgTotal.Location = new System.Drawing.Point(302, 263);
            this.textBoxAvgTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxAvgTotal.Name = "textBoxAvgTotal";
            this.textBoxAvgTotal.ReadOnly = true;
            this.textBoxAvgTotal.Size = new System.Drawing.Size(111, 32);
            this.textBoxAvgTotal.TabIndex = 29;
            this.textBoxAvgTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAvgRecent
            // 
            this.textBoxAvgRecent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAvgRecent.Location = new System.Drawing.Point(302, 298);
            this.textBoxAvgRecent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxAvgRecent.Name = "textBoxAvgRecent";
            this.textBoxAvgRecent.ReadOnly = true;
            this.textBoxAvgRecent.Size = new System.Drawing.Size(111, 32);
            this.textBoxAvgRecent.TabIndex = 30;
            this.textBoxAvgRecent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStartedTime
            // 
            this.textBoxStartedTime.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxStartedTime.Location = new System.Drawing.Point(160, 229);
            this.textBoxStartedTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxStartedTime.Name = "textBoxStartedTime";
            this.textBoxStartedTime.ReadOnly = true;
            this.textBoxStartedTime.Size = new System.Drawing.Size(80, 32);
            this.textBoxStartedTime.TabIndex = 31;
            this.textBoxStartedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentTime.Location = new System.Drawing.Point(370, 181);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(129, 38);
            this.labelCurrentTime.TabIndex = 32;
            this.labelCurrentTime.Text = "00:00:00";
            // 
            // groupBoxFishingMode
            // 
            this.groupBoxFishingMode.Controls.Add(this.radioButtonFastest);
            this.groupBoxFishingMode.Controls.Add(this.radioButtonFaster);
            this.groupBoxFishingMode.Controls.Add(this.radioButtonModerate);
            this.groupBoxFishingMode.Controls.Add(this.radioButtonEmulate);
            this.groupBoxFishingMode.Location = new System.Drawing.Point(11, 125);
            this.groupBoxFishingMode.Name = "groupBoxFishingMode";
            this.groupBoxFishingMode.Size = new System.Drawing.Size(506, 50);
            this.groupBoxFishingMode.TabIndex = 33;
            this.groupBoxFishingMode.TabStop = false;
            this.groupBoxFishingMode.Text = "Fishing Mode";
            // 
            // radioButtonFastest
            // 
            this.radioButtonFastest.AutoSize = true;
            this.radioButtonFastest.Location = new System.Drawing.Point(407, 20);
            this.radioButtonFastest.Name = "radioButtonFastest";
            this.radioButtonFastest.Size = new System.Drawing.Size(71, 24);
            this.radioButtonFastest.TabIndex = 3;
            this.radioButtonFastest.TabStop = true;
            this.radioButtonFastest.Text = "Fastest";
            this.radioButtonFastest.UseVisualStyleBackColor = true;
            this.radioButtonFastest.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonFaster
            // 
            this.radioButtonFaster.AutoSize = true;
            this.radioButtonFaster.Location = new System.Drawing.Point(300, 20);
            this.radioButtonFaster.Name = "radioButtonFaster";
            this.radioButtonFaster.Size = new System.Drawing.Size(65, 24);
            this.radioButtonFaster.TabIndex = 2;
            this.radioButtonFaster.TabStop = true;
            this.radioButtonFaster.Text = "Faster";
            this.radioButtonFaster.UseVisualStyleBackColor = true;
            this.radioButtonFaster.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonModerate
            // 
            this.radioButtonModerate.AutoSize = true;
            this.radioButtonModerate.Location = new System.Drawing.Point(170, 20);
            this.radioButtonModerate.Name = "radioButtonModerate";
            this.radioButtonModerate.Size = new System.Drawing.Size(92, 24);
            this.radioButtonModerate.TabIndex = 1;
            this.radioButtonModerate.TabStop = true;
            this.radioButtonModerate.Text = "Moderate";
            this.radioButtonModerate.UseVisualStyleBackColor = true;
            this.radioButtonModerate.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonEmulate
            // 
            this.radioButtonEmulate.AutoSize = true;
            this.radioButtonEmulate.Location = new System.Drawing.Point(64, 20);
            this.radioButtonEmulate.Name = "radioButtonEmulate";
            this.radioButtonEmulate.Size = new System.Drawing.Size(81, 24);
            this.radioButtonEmulate.TabIndex = 0;
            this.radioButtonEmulate.TabStop = true;
            this.radioButtonEmulate.Text = "Emulate";
            this.radioButtonEmulate.UseVisualStyleBackColor = true;
            this.radioButtonEmulate.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // textBoxElapsed
            // 
            this.textBoxElapsed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxElapsed.Location = new System.Drawing.Point(244, 229);
            this.textBoxElapsed.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxElapsed.Name = "textBoxElapsed";
            this.textBoxElapsed.ReadOnly = true;
            this.textBoxElapsed.Size = new System.Drawing.Size(148, 32);
            this.textBoxElapsed.TabIndex = 34;
            this.textBoxElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLeftTime
            // 
            this.textBoxLeftTime.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLeftTime.Location = new System.Drawing.Point(396, 229);
            this.textBoxLeftTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxLeftTime.Name = "textBoxLeftTime";
            this.textBoxLeftTime.ReadOnly = true;
            this.textBoxLeftTime.Size = new System.Drawing.Size(121, 32);
            this.textBoxLeftTime.TabIndex = 35;
            this.textBoxLeftTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 459);
            this.Controls.Add(this.textBoxLeftTime);
            this.Controls.Add(this.textBoxElapsed);
            this.Controls.Add(this.groupBoxFishingMode);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.textBoxStartedTime);
            this.Controls.Add(this.textBoxAvgRecent);
            this.Controls.Add(this.textBoxAvgTotal);
            this.Controls.Add(this.textBoxEstimateRecent);
            this.Controls.Add(this.textBoxEstimateTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCounter);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.counterTextBox);
            this.Controls.Add(this.predefinedComboBox);
            this.Controls.Add(this.windowCheckBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.processTextBox);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "BNS Fishing";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBoxFishingMode.ResumeLayout(false);
            this.groupBoxFishingMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox processTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.ComponentModel.BackgroundWorker fishingBackgroundWorker;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.CheckBox windowCheckBox;
        private System.Windows.Forms.ComboBox predefinedComboBox;
        private System.Windows.Forms.TextBox counterTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEstimateTotal;
        private System.Windows.Forms.TextBox textBoxEstimateRecent;
        private System.Windows.Forms.TextBox textBoxAvgTotal;
        private System.Windows.Forms.TextBox textBoxAvgRecent;
        private System.Windows.Forms.TextBox textBoxStartedTime;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.GroupBox groupBoxFishingMode;
        private System.Windows.Forms.RadioButton radioButtonFastest;
        private System.Windows.Forms.RadioButton radioButtonFaster;
        private System.Windows.Forms.RadioButton radioButtonModerate;
        private System.Windows.Forms.RadioButton radioButtonEmulate;
        private System.Windows.Forms.TextBox textBoxElapsed;
        private System.Windows.Forms.TextBox textBoxLeftTime;
    }
}

