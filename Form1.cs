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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace ZhouZiyang0325Project3CLSApp
{
    public partial class Form1 : Form
    {
        private Icon m_info = new Icon(SystemIcons.Information, 40, 40);
        private Icon m_error = new Icon(SystemIcons.Error, 40, 40);

        private Icon m_ready = new Icon(SystemIcons.WinLogo, 40, 40);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid ProcessedFile Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile, "");
            watchDir.EnableRaisingEvents = true;
            watchDir.Path = txtSource.Text;

            icuNotify.Icon = m_ready;
            icuNotify.Visible =true;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if(Directory.Exists(txtSource.Text))
            {
                txtSource.BackColor = Color.White;
            }
            else
                txtSource.BackColor = Color.Pink;
        }

        private void txtDest_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDest.Text))
            {
                txtDest.BackColor = Color.White;
            }
            else
                txtDest.BackColor = Color.Pink;
        }

        private void txtProcessedFile_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtProcessedFile.Text))
            {
                txtProcessedFile.BackColor = Color.White;
            }
            else
                txtProcessedFile.BackColor = Color.Pink;
        }

        private void mnuConfigure_Click(object sender, EventArgs e)
        {
            icuNotify.Visible = false;
            this.ShowInTaskbar=true;
            this.Show();
        }
        /*/
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        /*/


        private void icuNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            icuNotify.Visible=false;
            this.ShowInTaskbar=true;
            this.Show();
        }

        /*/
        private void watchDir_Created(object sender, FileSystemEventArgs e)
        {
            watchDir.EnableRaisingEvents = false;
            icuNotify.Text = "Processed:" + e.Name; 
            //to access the word application
            Microsoft.Office.Interop.Word.Application.wdApp =new Microsoft.Office.Interop.Word.Application();
            object.optional = System.Reflection.Missing.Value;
            XmlTextWriter xmlTextWriter = new XmlTextWriter(txtDest.Text + "summary.xml", null);
            try
            {
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                object filename = e.Name;
                doc = WdApplyQuickStyleSets.Documents.Open(ref filename, ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,);
                Microsoft.Office.Interop.Word.Range wdRange;
                wdRange = doc.Paragraphs[2].Range;
                

            }
        }
        /*/


    }

}
