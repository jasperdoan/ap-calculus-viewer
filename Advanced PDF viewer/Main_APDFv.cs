using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_PDF_viewer
{
    public partial class MainWindow : Form
    {
        private const int cGrip = 16;
        private const int cCaption = 31;
        private bool isCollapsed1 = true , isCollapsed2 = false, isCollapsed3 = true, isCollapsed4 = true;
        private string finalDirectory = @"C:\Program Files (x86)\APC\APCSetUp\";

        // <> <> <> <> Main Window  <> <> <> <> //
        public MainWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        // <> <> <> <> Tab menu <> <> <> <> //
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.RoyalBlue, rc);
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }/* // Dragger
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }*/
            }
            base.WndProc(ref m);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    axAcroPDF1.src = ofd.FileName;
                }
            }
        }

        // <> <> <> <> Main Window's Components & Methods <> <> <> <> //
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = finalDirectory + @"Papers\" + "null.pdf";
            yearSearch.Text = "";
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void jasplloydgmailcomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void minM_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = finalDirectory + @"Papers\" + "null.pdf";
            yearSearch.Text = "";
        }

        // <> <> <> <> Button animations <> <> <> <> //
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                samplePanel.Height += 10;
                if (samplePanel.Size == samplePanel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = false;
                }
            }
            else 
            {
                samplePanel.Height -= 10;
                if (samplePanel.Size == samplePanel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed1 = true;
                }
            }
        }

        private void yearList_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                typeQPanel.Height += 10;
                if (typeQPanel.Size == typeQPanel.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                typeQPanel.Height -= 10;
                if (typeQPanel.Size == typeQPanel.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed3)
            {
                guideLinesPanel.Height += 10;
                if (guideLinesPanel.Size == guideLinesPanel.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed3 = false;
                }
            }
            else
            {
                guideLinesPanel.Height -= 10;
                if (guideLinesPanel.Size == guideLinesPanel.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed3 = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isCollapsed4)
            {
                panelReview.Height += 15;
                if (panelReview.Size == panelReview.MaximumSize)
                {
                    timer4.Stop();
                    isCollapsed4 = false;
                }
            }
            else
            {
                panelReview.Height -= 15;
                if (panelReview.Size == panelReview.MinimumSize)
                {
                    timer4.Stop();
                    isCollapsed4 = true;
                }
            }
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        // <> <> <> <> Functions & Methods <> <> <> <> //
        private void yearSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchYear_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                string filename = "frq_" + yearSearch.Text + ".pdf";
                string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                string pathfilename = string.Concat(path, filename);
                axAcroPDF1.src = pathfilename;
            }
        }

        private void freeResponse_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string filename = "frq_" + yearSearch.Text + ".pdf";
                string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                string pathfilename = string.Concat(path, filename);
                axAcroPDF1.src = pathfilename;
            }
        }

        private void scoringGuideLinesButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string filename = "sg_" + yearSearch.Text + ".pdf";
                string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                string pathfilename = string.Concat(path, filename);
                axAcroPDF1.src = pathfilename;
            }
        }

        private void chiefReaderReportButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int temp = Int32.Parse(yearSearch.Text);
                if (temp >= 2001)
                {
                    string filename = "r_" + @"(" + yearSearch.Text.Substring(2, 2) + ").pdf";
                    string path = finalDirectory + @"Papers\" + @"report\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("No Scoring Distribution file is found before 2001", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void scoringStatsButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int temp = Int32.Parse(yearSearch.Text);
                if (temp >= 2003)
                {
                    string filename = "stats_" + @"(" + yearSearch.Text.Substring(2, 2) + ").pdf";
                    string path = finalDirectory + @"Papers\" + @"stats\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("No Scoring Distribution file is found before 2003", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void scoringDistribution_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int temp = Int32.Parse(yearSearch.Text);
                if (temp >= 2002)
                {
                    string filename = "sd_" + @"(" + yearSearch.Text.Substring(2,2) + ").pdf";
                    string path = finalDirectory + @"Papers\" + @"Scoring Distribution\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("No Scoring Distribution file is found before 2002", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void unit1_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit1.pdf");
        }

        private void unit2_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit2.pdf");
        }

        private void unit3_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit3.pdf");
        }

        private void unit4_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit4.pdf");
        }

        private void unit5_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit5.pdf");
        }

        private void unit6_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit6.pdf");
        }

        private void unit7_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit7.pdf");
        }

        private void unit8_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\" + @"Unit Study Guides\", "unit8.pdf");
        }

        private void tldr_Click(object sender, EventArgs e)
        {
            axAcroPDF1.src = string.Concat(finalDirectory + @"Papers\", "tldr.pdf");
        }

        private void sample1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                string filename = "s_" + yearSearch.Text + @" (" + 1 + ").pdf";
                string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                string pathfilename = string.Concat(path, filename);
                axAcroPDF1.src = pathfilename;
            }
        }

        private void sample2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!yearSearch.Text.Equals("2005"))
                {
                    string filename = "s_" + yearSearch.Text + @" (" + 2 + ").pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("All sample questions for 2005 is in Sample Paper 1", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void sample3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!yearSearch.Text.Equals("2005"))
                {
                    string filename = "s_" + yearSearch.Text + @" (" + 3 + ").pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("All sample questions for 2005 is in Sample Paper 1", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void sample4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!yearSearch.Text.Equals("2005"))
                {
                    string filename = "s_" + yearSearch.Text + @" (" + 4 + ").pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("All sample questions for 2005 is in Sample Paper 1", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void sample5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!yearSearch.Text.Equals("2005"))
                {
                    string filename = "s_" + yearSearch.Text + @" (" + 5 + ").pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("All sample questions for 2005 is in Sample Paper 1", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void sample6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!yearSearch.Text.Equals("2005"))
                {
                    string filename = "s_" + yearSearch.Text + @" (" + 6 + ").pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    axAcroPDF1.src = pathfilename;
                }
                else
                {
                    MessageBox.Show("All sample questions for 2005 is in Sample Paper 1", "Can't find path {NULL_OBJECT}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void multipleChoiceButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchPaper_Click(object sender, EventArgs e)
        {
            string filename = "frq_" + yearSearch.Text + ".pdf";
            string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
            string pathfilename = string.Concat(path, filename);
            axAcroPDF1.src = pathfilename;
        }

        private void openSelectedFile_Click(object sender, EventArgs e)
        {
            string unitcheck = finalDirectory + @"Papers\" + @"Unit Study Guides\";
            bool flag = false;
            int unit = 0;

            //Factor 1

            for (int i = 1; i < 9; i++) 
            {
                if (axAcroPDF1.Equals(unitcheck + @"unit\" + i + ".pdf")) 
                {
                    flag = true;
                    unit = i;
                    break;
                }
            }
            if (flag == true) 
            {
                System.Diagnostics.Process.Start(unitcheck + @"unit\" + unit + ".pdf");
            }
            else if (flag = false && String.IsNullOrEmpty(yearSearch.Text))
            {
                MessageBox.Show("Enter a year please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string temp = axAcroPDF1.src;
                if (temp == null && !String.IsNullOrEmpty(yearSearch.Text) && yearSearch.Text.Length == 4)
                {
                    string filename = "frq_" + yearSearch.Text + ".pdf";
                    string path = finalDirectory + @"Papers\" + yearSearch.Text + @"\";
                    string pathfilename = string.Concat(path, filename);
                    System.Diagnostics.Process.Start(pathfilename);
                } else 
                {
                    if (temp == null)
                    {
                        System.Diagnostics.Process.Start(finalDirectory + @"Papers\" + @"null.pdf");
                    }
                    else 
                    {
                        System.Diagnostics.Process.Start(temp);
                    }
                }
            }
        }
    }
}