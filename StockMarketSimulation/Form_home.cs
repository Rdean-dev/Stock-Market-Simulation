using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Market_Simulation
{
    public partial class Form_home : Form
    {
        public Form_home()
        {

            InitializeComponent();
            string defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockData", "demo.csv");

        }

        /// <summary>
        /// Event Handler for Select a Ticker File button that opens the file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LoadTicker_Click(object sender, EventArgs e)
        {
            //Displays the file dialog
            openFileDialog_fileSelector.ShowDialog();
        }

        /// <summary>
        /// Event Handler triggered when a file is selected successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            //Gets the number of files selected by the user
            int numberOfFiles = openFileDialog_fileSelector.FileNames.Length;

            // Gets the start and end dates from the date pickers
            DateTime startDate = dateTimePicker_StartDate.Value;
            DateTime endDate = dateTimePicker_EndDate.Value;

            //Stores the selected file names in a list type string
            String[] filenames = openFileDialog_fileSelector.FileNames;
            
            //Iterates through each selected file and opens a new Form_Display window
            for (int i = 0; i < numberOfFiles;  i++)
            {
                //Creates a new Form_Display instance with the selected file and date range
                Form_Display df = new Form_Display(filenames[i], startDate, endDate);

                //displays the first stock chart on the main form
                if (i == 0) {

                    displayChart(df);
                }
            
                 //Displays the form to the user
                 df.Show();
                
            }
        }
        /// <summary>
        /// Displays the charts and data grid using the filtered candlestick list
        /// </summary>
        /// <param name="displayform"></param>
        private void displayChart(Form_Display displayform)
        {

            //Normalizes chart before displaying
            normalizeChart(displayform);

            //Rebinds the filtered data to the chart
            chart_FirstOHLCV.DataSource = displayform.filteredCandlesticks;

            //Refreshes the chart
            chart_FirstOHLCV.DataBind();

            //Clears any existing chart titles
            chart_FirstOHLCV.Titles.Clear();

            //Adds a new chart title
            chart_FirstOHLCV.Titles.Add(displayform.ticker + "\n\n " + dateTimePicker_StartDate.Value.ToShortDateString() + " - " + dateTimePicker_EndDate.Value.ToShortDateString());

            //Displays the form with the updated chart
            this.Show();

        }
        /// <summary>
        /// Overloaded normalizeChart that applies limits to the chart
        /// </summary>
        /// <param name="display_form"></param>
        void normalizeChart(Form_Display display_form)
        {
            //Calls the first normalizeChart to calculate Y-axis limits
            display_form.normalizeChart(display_form.filteredCandlesticks);

            // Initialize Axis Type yAxis to access the Y-axis of the chart_OHLCV OHLC area
            Axis yAxis = chart_FirstOHLCV.ChartAreas["ChartArea_OHLC"].AxisY;

            //Applys the rounded maximum limits to yAxis
            yAxis.Minimum = Math.Floor((double)display_form.minY);

            //Applys the rounded minimum limits to yAxis
            yAxis.Maximum = Math.Ceiling((double)display_form.maxY);
        }
    }
}
