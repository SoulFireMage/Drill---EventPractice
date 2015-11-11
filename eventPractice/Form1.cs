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

namespace eventPractice
    {
    public partial class Form1 : Form
        {
        Dictionary<string, List<Point>> countryMoves = new Dictionary<string, List<Point>>();
        static string path = @"c:\temp\moves.xml";

        //Event Stuff
        public event EventHandler<LogEventArgs> RaiseLogEvent;

  
        private void LogWrite(object sender, LogEventArgs e)
            {
            safeFileStream.CreateFile(e.path, e.content);
            }

        public virtual void onRaiseLogEvent(LogEventArgs e)
            {
            EventHandler<LogEventArgs> handler = RaiseLogEvent;

            if (handler != null)
                {
                handler(this, e);
                }

            }
       //End event stuff
    public Form1()
            {
                InitializeComponent();
                var test = new List<string>() { "Section 1", "Section 2", "Section 3", "Section 4" };
                test.ForEach(x => CountriesComboBox.Items.Add(x));
                RaiseLogEvent += LogWrite;
             }

        private void CountriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (CountriesComboBox.SelectedItem != null) { button1.Enabled = true; } else { button1.Enabled = false; }
            }
        private void button1_Click(object sender, EventArgs e)
            {
            MessageBox.Show("I'm saving all your mouse tracks now!");

            StringBuilder sb = new StringBuilder();
            foreach( KeyValuePair<string, List<Point>> country in countryMoves)
                {
                sb.Append($"{country.Key} \n");
                country.Value.ForEach(x => sb.Append($"{x} \n"));
               
                }
        
            onRaiseLogEvent(new LogEventArgs(path, sb.ToString()));
          
            }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
             textBox1.Text += $"{e.X} - {e.Y} : \n ";
            if (CountriesComboBox.SelectedItem  != null) { 
            List<Point> temp = new List<Point>();
            Point p = new Point(e.X, e.Y);
            string Country = CountriesComboBox.SelectedItem.ToString();
             if (countryMoves.TryGetValue(Country, out temp) == false)
                {
                    temp = new List<Point>();
                    temp.Add(p);
                    countryMoves.Add(Country, temp);
                   
                   
                }
            else
                {
                    countryMoves[Country].Add(p);
                    }
            }
            }
        }
    }
