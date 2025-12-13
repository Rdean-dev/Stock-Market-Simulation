namespace Stock_Market_Simulation
{
    partial class Form_Display
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.button_fileSelector = new System.Windows.Forms.Button();
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chart_OHLCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Simulate = new System.Windows.Forms.Button();
            this.timer_Simulate = new System.Windows.Forms.Timer(this.components);
            this.comboBox_recognizerPatterns = new System.Windows.Forms.ComboBox();
            this.hScrollBar_timerInterval = new System.Windows.Forms.HScrollBar();
            this.textBox_scrollBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_fileSelector
            // 
            this.openFileDialog_fileSelector.DefaultExt = "CSV";
            this.openFileDialog_fileSelector.Filter = "All Files|*.csv|Daily|*Day.csv|Weekly|*Week.csv|Monthly|*Month.csv";
            this.openFileDialog_fileSelector.Multiselect = true;
            this.openFileDialog_fileSelector.ReadOnlyChecked = true;
            this.openFileDialog_fileSelector.ShowReadOnly = true;
            this.openFileDialog_fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_fileSelector_FileOk);
            // 
            // button_fileSelector
            // 
            this.button_fileSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_fileSelector.Location = new System.Drawing.Point(688, 13);
            this.button_fileSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_fileSelector.Name = "button_fileSelector";
            this.button_fileSelector.Size = new System.Drawing.Size(123, 41);
            this.button_fileSelector.TabIndex = 0;
            this.button_fileSelector.Text = "Select a Ticker";
            this.button_fileSelector.UseVisualStyleBackColor = false;
            this.button_fileSelector.Click += new System.EventHandler(this.button_fileSelector_Click);
            // 
            // chart_OHLCV
            // 
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.AlignWithChartArea = "ChartArea_OHLC";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_OHLCV.ChartAreas.Add(chartArea3);
            this.chart_OHLCV.ChartAreas.Add(chartArea4);
            this.chart_OHLCV.Location = new System.Drawing.Point(-3, 122);
            this.chart_OHLCV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart_OHLCV.Name = "chart_OHLCV";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.DarkBlue;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=0\\, 192\\, 0";
            series3.IsXValueIndexed = true;
            series3.Name = "Series_OHLC";
            series3.ShadowColor = System.Drawing.Color.Gray;
            series3.XValueMember = "Date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "High,Low,Open,Close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.IsXValueIndexed = true;
            series4.Name = "Series_Volume";
            series4.XValueMember = "Date";
            series4.YValueMembers = "Volume";
            this.chart_OHLCV.Series.Add(series3);
            this.chart_OHLCV.Series.Add(series4);
            this.chart_OHLCV.Size = new System.Drawing.Size(1046, 396);
            this.chart_OHLCV.TabIndex = 2;
            this.chart_OHLCV.Text = "chart1";
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(123, 23);
            this.dateTimePicker_StartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker_StartDate.TabIndex = 3;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2021, 1, 28, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(428, 23);
            this.dateTimePicker_EndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(192, 20);
            this.dateTimePicker_EndDate.TabIndex = 4;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2021, 2, 28, 0, 0, 0, 0);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(50, 23);
            this.label_StartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(58, 13);
            this.label_StartDate.TabIndex = 5;
            this.label_StartDate.Text = "Start Date:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(352, 28);
            this.label_EndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(55, 13);
            this.label_EndDate.TabIndex = 6;
            this.label_EndDate.Text = "End Date:";
            // 
            // button_Update
            // 
            this.button_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Update.Enabled = false;
            this.button_Update.Location = new System.Drawing.Point(882, 12);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(123, 44);
            this.button_Update.TabIndex = 7;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = false;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Simulate
            // 
            this.button_Simulate.BackColor = System.Drawing.Color.Red;
            this.button_Simulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_Simulate.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Simulate.Location = new System.Drawing.Point(882, 66);
            this.button_Simulate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Simulate.Name = "button_Simulate";
            this.button_Simulate.Size = new System.Drawing.Size(123, 44);
            this.button_Simulate.TabIndex = 8;
            this.button_Simulate.Text = "Simulate";
            this.button_Simulate.UseVisualStyleBackColor = false;
            this.button_Simulate.Click += new System.EventHandler(this.button_Simulate_Click);
            // 
            // timer_Simulate
            // 
            this.timer_Simulate.Interval = 1000;
            this.timer_Simulate.Tick += new System.EventHandler(this.timer_Simulate_Tick);
            // 
            // comboBox_recognizerPatterns
            // 
            this.comboBox_recognizerPatterns.FormattingEnabled = true;
            this.comboBox_recognizerPatterns.Location = new System.Drawing.Point(720, 81);
            this.comboBox_recognizerPatterns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_recognizerPatterns.Name = "comboBox_recognizerPatterns";
            this.comboBox_recognizerPatterns.Size = new System.Drawing.Size(92, 21);
            this.comboBox_recognizerPatterns.TabIndex = 9;
            this.comboBox_recognizerPatterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_recognizerPatterns_SelectedIndexChanged);
            // 
            // hScrollBar_timerInterval
            // 
            this.hScrollBar_timerInterval.Location = new System.Drawing.Point(259, 81);
            this.hScrollBar_timerInterval.Maximum = 2000;
            this.hScrollBar_timerInterval.Minimum = 100;
            this.hScrollBar_timerInterval.Name = "hScrollBar_timerInterval";
            this.hScrollBar_timerInterval.Size = new System.Drawing.Size(230, 20);
            this.hScrollBar_timerInterval.SmallChange = 10;
            this.hScrollBar_timerInterval.TabIndex = 11;
            this.hScrollBar_timerInterval.Value = 100;
            this.hScrollBar_timerInterval.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_timerInterval_Scroll);
            // 
            // textBox_scrollBox
            // 
            this.textBox_scrollBox.Location = new System.Drawing.Point(93, 81);
            this.textBox_scrollBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_scrollBox.Name = "textBox_scrollBox";
            this.textBox_scrollBox.Size = new System.Drawing.Size(108, 20);
            this.textBox_scrollBox.TabIndex = 12;
            this.textBox_scrollBox.TextChanged += new System.EventHandler(this.textBox_scrollBox_TextChanged);
            // 
            // Form_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 523);
            this.Controls.Add(this.textBox_scrollBox);
            this.Controls.Add(this.hScrollBar_timerInterval);
            this.Controls.Add(this.comboBox_recognizerPatterns);
            this.Controls.Add(this.button_Simulate);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.chart_OHLCV);
            this.Controls.Add(this.button_fileSelector);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Display";
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_fileSelector;
        private System.Windows.Forms.Button button_fileSelector;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLCV;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.BindingSource aCandlestickBindingSource;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Simulate;
        private System.Windows.Forms.Timer timer_Simulate;
        private System.Windows.Forms.ComboBox comboBox_recognizerPatterns;
        private System.Windows.Forms.HScrollBar hScrollBar_timerInterval;
        private System.Windows.Forms.TextBox textBox_scrollBox;
    }
}

