using Newtonsoft.Json;
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

namespace ChangeLogGen
{
    public partial class Form1 : Form
    {
        private Changelog _changelog;
        private readonly string _logfile = "data/changelog.json";
        public Form1()
        {
            InitializeComponent();

            Start();

        }

        void Start()
        {
            
            if(File.Exists(_logfile))
            {
                _changelog = JsonConvert.DeserializeObject<Changelog>(File.ReadAllText(_logfile));
                
            }
            else
            {
                _changelog = new Changelog();
            }


        
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string _version = textBox1.Text ;
            string _date;
            List<string> _cmds = new List<string>();

            if (checkBox1.Checked)
                _date = DateTime.Now.ToShortDateString();
            else
                _date = textBox2.Text;

            foreach(string l in richTextBox1.Lines)
                _cmds.Add(l);

            _changelog.versions.Add(new Version(_version, _date, _cmds));

            _changelog.versions.Reverse();

            File.WriteAllText(_logfile, JsonConvert.SerializeObject(_changelog,Formatting.Indented));


            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";

        }
    }
}
