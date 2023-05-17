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

namespace Notepad
{
    public partial class Form1 : Form
    {
        string filename = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog.FileName!=null)
                {
                    string filename=saveFileDialog.FileName;

                    StreamWriter streamWriter = new StreamWriter(filename);

                    streamWriter.Write(txtMain.Text);

                    streamWriter.Close();
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();   

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog.FileName!=null) 
                {
                     filename=openFileDialog.FileName;

                    StreamReader streamreader = new StreamReader(filename);
                    txtMain.Text = streamreader.ReadToEnd();

                    streamreader.Close();
                }

            }

          
        }

        private void Updatestatus()
        {
            lblcol.Text="col:"+txtMain.Text.Length.ToString();


        }

        private void txtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            Updatestatus();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show(File.GetCreationTime(filename).ToString());
        }
    }
}
