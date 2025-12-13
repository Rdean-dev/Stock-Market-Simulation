namespace Stock_Market_Simulation
{
    partial class Form_home
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.button_LoadTicker = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.chart_FirstOHLCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_FirstOHLCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_fileSelector
            // 
            this.openFileDialog_fileSelector.DefaultExt = "CSV";
            this.openFileDialog_fileSelector.FileName = "LoadTicker";
            this.openFileDialog_fileSelector.Filter = "All Files|*.csv|Daily|*Day.csv|Weekly|*Week.csv|Monthly|*Month.csv";
            this.openFileDialog_fileSelector.Multiselect = true;
            this.openFileDialog_fileSelector.ReadOnlyChecked = true;
            this.openFileDialog_fileSelector.ShowReadOnly = true;
            this.openFileDialog_fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_fileSelector_FileOk);
            // 
            // button_LoadTicker
            // 
            this.button_LoadTicker.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_LoadTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LoadTicker.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_LoadTicker.Location = new System.Drawing.Point(346, 36);
            this.button_LoadTicker.Margin = new System.Windows.Forms.Padding(2);
            this.button_LoadTicker.Name = "button_LoadTicker";
            this.button_LoadTicker.Size = new System.Drawing.Size(116, 36);
            this.button_LoadTicker.TabIndex = 0;
            this.button_LoadTicker.Text = "Load Ticker";
            this.button_LoadTicker.UseVisualStyleBackColor = false;
            this.button_LoadTicker.Click += new System.EventHandler(this.button_LoadTicker_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(134, 46);
            this.dateTimePicker_StartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker_StartDate.TabIndex = 1;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2023, 3, 28, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(562, 46);
            this.dateTimePicker_EndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(192, 20);
            this.dateTimePicker_EndDate.TabIndex = 2;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2023, 5, 28, 0, 0, 0, 0);
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EndDate.Location = new System.Drawing.Point(478, 46);
            this.label_EndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(69, 18);
            this.label_EndDate.TabIndex = 3;
            this.label_EndDate.Text = "End Date";
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StartDate.Location = new System.Drawing.Point(44, 46);
            this.label_StartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(74, 18);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start Date";
            // 
            // chart_FirstOHLCV
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_FirstOHLCV.ChartAreas.Add(chartArea1);
            this.chart_FirstOHLCV.ChartAreas.Add(chartArea2);
            this.chart_FirstOHLCV.Location = new System.Drawing.Point(11, 108);
            this.chart_FirstOHLCV.Margin = new System.Windows.Forms.Padding(2);
            this.chart_FirstOHLCV.Name = "chart_FirstOHLCV";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.DarkBlue;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=0\\, 192\\, 0";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_OHLC";
            series1.ShadowColor = System.Drawing.Color.Gray;
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.YValueMembers = "Volume";
            this.chart_FirstOHLCV.Series.Add(series1);
            this.chart_FirstOHLCV.Series.Add(series2);
            this.chart_FirstOHLCV.Size = new System.Drawing.Size(778, 423);
            this.chart_FirstOHLCV.TabIndex = 5;
            this.chart_FirstOHLCV.Text = "chart1";
            // 
            // Form_home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 540);
            this.Controls.Add(this.chart_FirstOHLCV);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_LoadTicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_home";
            this.Text = "Form_home";
            ((System.ComponentModel.ISupportInitialize)(this.chart_FirstOHLCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_fileSelector;
        private System.Windows.Forms.Button button_LoadTicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_FirstOHLCV;
        private System.Windows.Forms.BindingSource aCandlestickBindingSource;
    }
}