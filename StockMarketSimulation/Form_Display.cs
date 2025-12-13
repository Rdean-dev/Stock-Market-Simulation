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
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace Stock_Market_Simulation
{

    public partial class Form_Display : Form
    {
        //List containing all candlestick data loaded from the file
        List<aSmartCandlestick> listOfCandlesticks;

        //List containing candlestick data filtered by selected date range
        public List<aSmartCandlestick> filteredCandlesticks;

        //List for simulating real-time candlestick display
        List <aSmartCandlestick> simulatedCandlesticks = new List<aSmartCandlestick>();

        // Index for tracking simulation progress
        int simulationIndex = 0;

        // List of pattern recognizers
        List<Recognizer> LOR = new List<Recognizer>();

        // List of recognition results for each pattern and variant
        List<List<int>> listOfResults = new List<List<int>>();

        //Stores the ticker symbol extracted from the filename
        public String ticker;

        //Stores the computed minimum and maximumj values for the Y-axis
        public decimal minY;
        public decimal maxY;

        public Form_Display()
        {
            InitializeComponent();
            string defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockData", "demo.csv");


            initializeRecognizers(); // Initializes recognizers

        }

        /// <summary>
        /// Constructor that inistializes a new instance of the Form_Display class,
        /// loading candlestick data from the specified file and displaying it within the selected date range.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Form_Display(string filePath, DateTime startDate, DateTime endDate) 
        {
            //Initializes all UI components and controls
            InitializeComponent();
            string defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockData", "demo.csv");


            initializeRecognizers();

            //Extracts the ticker symbol from the filename
            ticker = Path.GetFileNameWithoutExtension(filePath);

            //Sets the form tile to the ticker name
            this.Text = ticker;
            
            //Sets the filename in the openFileDialog to the filename provided by the user
            openFileDialog_fileSelector.FileName = filePath;

            //Sets the start and end dates in the date time pickers
            dateTimePicker_StartDate.Value = startDate;
            dateTimePicker_EndDate.Value = endDate;

            //Reads all candlestick data from the chosen file
            readCandlestickFile();

            //Filters the candlestick list by the start and end dates
            filterCandlesticksByDate();

            //Adjusts the Axis Y's minimum and maximum
            normalizeChart();

            //Displays the OHLC and Volume Charts and data grid view
            displayChart();

            //Applys recognizers to filtered candlesticks
            addRecognizers();
            

        }
        /// <summary>
        /// Initializes the recognizer objects
        /// </summary>
        private void initializeRecognizers()
        {
            //Adds all candlestick pattern recognizers
            LOR.Add(new Recognizer_Doji());
            LOR.Add(new Recognizer_EngulfingPattern());
            LOR.Add(new Recognizer_Hammers());
            LOR.Add(new Recognizer_Haramis());
            LOR.Add(new Recognizer_InvertedHammers());
            LOR.Add(new Recognizer_Marubozus());


            //comboBox_recognizerPatterns.Items.Clear();

            //Adds the pattern names and variants to the combobox

            foreach (Recognizer r in LOR)
            {
                comboBox_recognizerPatterns.Items.Add(r.patternName);
                comboBox_recognizerPatterns.Items.Add(r.patternVariant1);
                comboBox_recognizerPatterns.Items.Add(r.patternVariant2);
            }
        }
        /// <summary>
        /// Applies all recognizers to the filtered candlestick list
        /// </summary>
        private void addRecognizers()
        {
            //Clear previous results
            listOfResults.Clear();

            //Iterates through each recognizer object in LOR list
            foreach (Recognizer r in LOR)
            {
                //Apply recognizer to every candlestick in the filtered list
                for (int i = 0; i < filteredCandlesticks.Count; i++)
                {
                    //calls the recognizer function on each candlestick
                    r.recognize(filteredCandlesticks, i);
                }

                //Stores results for the main pattern and its variants
                listOfResults.Add(r.patternIndices);
                listOfResults.Add(r.variant1Indices);
                listOfResults.Add(r.variant2Indices);

            }
            
        }



    

            
        

        /// <summary>
        /// Event Handler for Update button that refreshes the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            refreshDisplay(); //Updates the chart and data grid view
        }

        /// <summary>
        /// Event Handler for Select a Ticker File button that opens the file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_fileSelector_Click(object sender, EventArgs e)
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
            //Extracts the ticker symbol from the filename
            ticker = Path.GetFileNameWithoutExtension(openFileDialog_fileSelector.FileName);

            //Sets the form tile to the ticker name
            this.Text = ticker;

            //Reads all candlestick data from the chosen file
            readCandlestickFile();
            
            //Filters the candlestick list by the start and end dates
            filterCandlesticksByDate();

            //Adjusts the Axis Y's minimum and maximum
            normalizeChart();

            //Displays the OHLC and Volume Charts and data grid view
            displayChart();

            //Applys recognizers to filtered candlesticks
            addRecognizers();
            
        }

        /// <summary>
        /// Reads a csv file and converts it into a list of Type aCandlestick 
        /// </summary>
        /// <param name="tickerFile"></param>
        /// <returns></returns>
        private List<aSmartCandlestick> readCandlestickFile(String tickerFile)
        {
            //Declares a list to hold candlesticks objects
            List<aSmartCandlestick> candlesticks = null;

            //Variable to hold the raw file content
            String text;

            //new StreamReader instance within a using statement 
            using (StreamReader reader = new StreamReader(tickerFile))
            {
                //read the text from the file
                text = reader.ReadToEnd();
            }
            
            //Define newline as the line separator
            char[] lineDelimiter = new char[] { '\n' };

            //Split the file text into individual lines and remove empty lines
            String[] lines = text.Split(lineDelimiter, StringSplitOptions.RemoveEmptyEntries);

            //Initialize the candlesticks list based on number of lines
            candlesticks = new List<aSmartCandlestick>(lines.Length);

            //Loop through all lines starting from index 1 skipping the header
            for (int i = 1; i < lines.Length; i++)
            {
                //Read each line
                String line = lines[i];

                //Create a new candlestick object from the line
                aSmartCandlestick c = new aSmartCandlestick(line);

                // Add the candlestick to the list
                candlesticks.Add(c);
            }
            
            //Returns the completed list
            return candlesticks;

        }

        /// <summary>
        /// Overloaded method: Reads the selected file into memory and enables the update button
        /// </summary>
        void readCandlestickFile()
        {
            //Load all candlesticks from the chosen file
            listOfCandlesticks = readCandlestickFile(openFileDialog_fileSelector.FileName);

            //Enables the Update button
            button_Update.Enabled = true;

            //grabs the first two candlesticks to ensure the data is sorted in ascending order
            aSmartCandlestick firstCandlestick = listOfCandlesticks[0];
            aSmartCandlestick secondCandlestick = listOfCandlesticks[1];

            //If the first date is later than the second date, reverse the list
            if (firstCandlestick.Date > secondCandlestick.Date)
            {
                //Reverses the list
                listOfCandlesticks.Reverse();
            }

        }

        /// <summary>
        /// Filters a given list of candlesticks between two dates
        /// </summary>
        /// <param name="unfilteredList"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<aSmartCandlestick> filterCandlesticksByDate(List<aSmartCandlestick> unfilteredList, DateTime startDate, DateTime endDate)
        {
            //Uses LINQ to select only the candlesticks within the given date range
            return(unfilteredList.Where(c => c.Date >= startDate && c.Date <= endDate).ToList());
        }

        /// <summary>
        /// Filters the listOfCandlesticks using values from date pickers
        /// </summary>
        void filterCandlesticksByDate()
        {
            filteredCandlesticks = filterCandlesticksByDate(listOfCandlesticks, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);

        }

        /// <summary>
        /// Calculates the Y-axis limits (Minimum and Maximum) based on filtered candlestick data
        /// </summary>
        /// <param name="filteredList"></param>
        public void normalizeChart(List<aSmartCandlestick> filteredList)
        {
            //Finds lowest value among the filtered candlesticks
            decimal minValue = filteredList.Min(c => c.Low);

            //Finds highest value among the filtered candlesticks
            decimal maxValue = filteredList.Max(c => c.High);

            //Calculates 2% padding
            decimal padding = (maxValue - minValue) * 0.02m;

            //Computes Y-axis minimum value
            minY = minValue - padding;

            //Computes Y-axis maximum value
            maxY = maxValue + padding;
        }

        /// <summary>
        /// Overloaded normalizeChart that applies limits to the chart
        /// </summary>
        void normalizeChart() 
        {
            //Calls the first normalizeChart to calculate Y-axis limits
            normalizeChart(filteredCandlesticks);
            
            // Initialize Axis Type yAxis to access the Y-axis of the chart_OHLCV OHLC area
            Axis yAxis = chart_OHLCV.ChartAreas["ChartArea_OHLC"].AxisY;

            //Applys the rounded maximum limits to yAxis
            yAxis.Minimum = Math.Floor((double)minY);

            //Applys the rounded minimum limits to yAxis
            yAxis.Maximum = Math.Ceiling((double)maxY);
        }
        
        /// <summary>
        /// Displays the charts and data grid using the filtered candlestick list
        /// </summary>
        /// <param name="filteredList"></param>
        public void displayChart(List<aSmartCandlestick> filteredList)
        { 
            //Bind the candlestick list to the UI binding source
            aCandlestickBindingSource.DataSource = filteredList;

            //Normalizes chart before displaying
            normalizeChart();
            

            //Binds the filtered data to the chart
            chart_OHLCV.DataSource = filteredList;

            //Binds data
            chart_OHLCV.DataBind();


            //Clears any existing chart titles
            chart_OHLCV.Titles.Clear();

            //Adds a new chart title
            chart_OHLCV.Titles.Add(ticker + "\n\n " + dateTimePicker_StartDate.Value.ToShortDateString() + " - " + dateTimePicker_EndDate.Value.ToShortDateString());

            //Displays the form with the updated chart
            this.Show();

        }

        /// <summary>
        /// Overloaded displayChart with no parameters
        /// </summary>
        void displayChart()
        {
            //calls the public displayChart
            displayChart(filteredCandlesticks);

        }

        /// <summary>
        /// Updates the chart and grid when the user presses Update button
        /// </summary>
        private void refreshDisplay() 
        {
            //Applys the current date range filters
            filterCandlesticksByDate();


            //ReNormalizes the filteredList Data
            normalizeChart();

            //Rebinds the filtered data to the chart
            chart_OHLCV.DataSource = filteredCandlesticks;

            //Clears any existing chart titles
            chart_OHLCV.Titles.Clear();

            //Adds a new chart title
            chart_OHLCV.Titles.Add(ticker + "\n\n " + dateTimePicker_StartDate.Value.ToShortDateString() + " - " + dateTimePicker_EndDate.Value.ToShortDateString());

            //Displays the form with the updated chart
            this.Show();

        }
        /// <summary>
        /// Event Handler for Simulate button that starts simulation of candlestick display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Simulate_Click(object sender, EventArgs e)
        {
            //Clear any previously simulated candlesticks
            simulatedCandlesticks.Clear();
            // Reset simulation index to start from the beginning
            simulationIndex = 0;

            // Bind an empty list to the chart for simulation
            chart_OHLCV.DataSource = simulatedCandlesticks;

            // Start the simulation timer to add candlesticks over time
            timer_Simulate.Start();
        }
        /// <summary>
        /// Event Handler for simulate timer tick and adds next candlestick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Simulate_Tick(object sender, EventArgs e)
        {
            // Stop timer temporarily to prevent overlapping ticks
            timer_Simulate.Stop();

            // Add the next candlestick to the chart
            displayNextCandlestick();

            // Continue simulation if there are more candlesticks remaining
            if (simulatedCandlesticks.Count < filteredCandlesticks.Count)
                timer_Simulate.Start();
        }
        /// <summary>
        /// Adds the next candlestick to the simulated chart
        /// </summary>
        private void displayNextCandlestick() 
        {
            // Get next candlestick
            aSmartCandlestick nextCandlestick = filteredCandlesticks[simulationIndex++];

            // Add it to the simulated list
            simulatedCandlesticks.Add(nextCandlestick);

            //Normalize simulated candlestick
            normalizeChart(simulatedCandlesticks);
            
            // Refresh the chart to show the new candlestick
            chart_OHLCV.DataBind();
            
        
        }
        /// <summary>
        /// Adds rectangle annotations for selected pattern indices
        /// </summary>
        /// <param name="indices"></param>
        private void addAnnotations(List<int> indices)
        {
            // Remove any existing annotations
            chart_OHLCV.Annotations.Clear();

            //Iterate through provided list of indices
            foreach (int n in indices)
            {
                // Get the DataPoint in the series corresponding to the pattern index
                DataPoint dp = chart_OHLCV.Series["Series_OHLC"].Points[n];

                // Create a rectangle annotation for the candlestick
                RectangleAnnotation rectAnnotation = new RectangleAnnotation
                {
                    // Use chart X-axis
                    AxisX = chart_OHLCV.ChartAreas[0].AxisX,
                    // Use chart Y-axis
                    AxisY = chart_OHLCV.ChartAreas[0].AxisY,
                    // Attach to the data point
                    AnchorDataPoint = dp,
                    // Width in chart units
                    Width = 1,
                    // Height in chart units
                    Height = 4,
                    // Border thickness
                    LineWidth = 2,
                    // Border color
                    LineColor = Color.Yellow,
                    // Fill color
                    BackColor = Color.Yellow,
                    
                };



                // Add annotation to chart
                chart_OHLCV.Annotations.Add(rectAnnotation);
                
            }
        }
        /// <summary>
        /// Event Handler for Scroll Bar to adjust timer interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar_timerInterval_Scroll(object sender, ScrollEventArgs e)
        {
            // Update text box to match scroll bar
            textBox_scrollBox.Text = hScrollBar_timerInterval.Value.ToString();

            // Update timer interval accordingly
            timer_Simulate.Interval = hScrollBar_timerInterval.Value;
 
        }
        /// <summary>
        /// Event Handler for text box change to sync scroll bar and timer interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_scrollBox_TextChanged(object sender, EventArgs e)
        {
            // Parse text box input
            if (int.TryParse(textBox_scrollBox.Text, out int value))
            {
                // Ensure value is within scroll bar range
                if (value >= hScrollBar_timerInterval.Minimum && value <= hScrollBar_timerInterval.Maximum) 
                {
                    // Update scroll bar
                    hScrollBar_timerInterval.Value = value;

                    // Update simulation timer
                    timer_Simulate.Interval = value;
                }
            }
            
        }
        /// <summary>
        /// Event Handler for selceting a pattern in the combobox
        /// Displays rectangle annotations for selected pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_recognizerPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected index
            int selectedIndex = comboBox_recognizerPatterns.SelectedIndex;
            // Do nothing if no selection
            if (selectedIndex < 0) return;

            // Get list of indices for selected pattern

            List<int> indices = listOfResults[selectedIndex];

            // Clear previous annotations
            chart_OHLCV.Annotations.Clear();

            // Add new annotations for selected pattern
            addAnnotations(indices);
        }
    }
}
