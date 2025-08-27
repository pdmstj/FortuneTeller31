using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortuneTeller31
{
    public partial class FortuneTeller : Form
    {
        List<string> result;
        public FortuneTeller()
        {
            InitializeComponent();
        }

        private void LoadResults()
        {
            try
            {
                string filename = "results.csv";
                result = File.ReadAllLines(filename).ToList();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"파일이 없어요.\n{ex.Message}", "파일이 없는 오류!");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"권한이 없어요.\n{ex.Message}", "파일 권한 오류!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알 수 없는 오류가 발생했어요.\n{ex.Message}", "알 수 없는 오류!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadResults();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbBirthday_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 상담내역불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistory form = Application.OpenForms["FormHistory"] as FormHistory;
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new FormHistory();
                form.Show();
            }
        }

        private string GetFortune()
        {
            Random random = new Random();
            int index = random.Next(0, result.Count);
            return result[index];
        }


        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void 포춘텔러정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            string birthday = tbBirthday.Text;
            string birthtime = tbBirthtime.Text;
            string result = GetFortune();
            string saju = result.Split('|')[0];
            string message = result.Split('|')[1];
            tbResult.Text = birthday + " " + birthtime + Environment.NewLine
                + saju + Environment.NewLine
                + message;

        }
    }
}
