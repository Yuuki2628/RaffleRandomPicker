using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RaffleRandomPicker
{
    public partial class FrmMain : Form
    {
        int entriesNumber = 0;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFile.FileName);
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        int entries;
                        int.TryParse(line.Substring(0, line.IndexOf('-')), out entries);
                        if(entries > 0)
                        {
                            string user = line.Substring(line.IndexOf('-') + 1);
                            for (int i = 0; i < entries; i++)
                            {
                                listView1.Items.Add(user);
                                entriesNumber++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message: " + ex.Message);
                }
            }
        }

        private void btnGetRandom_Click(object sender, EventArgs e)
        {
            Random g = new Random();
            string winner;
            int winningNumber = g.Next(0, entriesNumber);
            winner = listView1.Items[winningNumber].Text;
            MessageBox.Show("The winner is: " + winner, "Congratulations " + winner);
        }
    }
}
