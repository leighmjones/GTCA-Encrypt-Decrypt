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

namespace GTCA_Encrypt
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

       

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //string variable to hold the text file
                string Contents = "";

                //Opens a file
                FileStream InputFile = File.Open(openFileDialog1.FileName, FileMode.Open);


                //Reads file until the end
                while (InputFile.Position < InputFile.Length)
                {

                    char chrLetter = (char)InputFile.ReadByte();
                    Contents += chrLetter.ToString();
                    
                    //Enables the encrypt button once the textbox is populated
                    button1.Enabled = true;
                }
                //displays text file to textbox
                textBox1.Text = Contents.ToString();
                //Close the file
                InputFile.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                long Key = 0;

                //Variable to hold text file
                string EncryptedString = "";

                //Random object to generate random numbers for key
                Random rand = new Random();

                Key = rand.Next(1, 2 ^ 47);

                //Encryption loop
                foreach (char letter in textBox1.Text)
                {
                    char EncryptedLetter = (char)(letter + Key);
                    EncryptedString += EncryptedLetter.ToString();

                }

                //Populates textbox
                textBox1.Text = Key + "\r\n" + EncryptedString;
                button1.Enabled = false;


            }
            catch
            {
                //Handles exceptions
                MessageBox.Show("Please upload a text file first.");
            }
        }

       

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFile.ShowDialog();

            //StreamWriter outputFile;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = new StreamWriter(saveFile.FileName);
                writer.Write(textBox1.Text);
                writer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            button1.Enabled = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
