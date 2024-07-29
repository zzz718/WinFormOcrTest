using System.Diagnostics;

namespace WinFormOcrTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, string> file = new();
        List<string> keys = new();
        private async void button1_Click(object sender, EventArgs e)
        {
            //����Ocrʶ�𷽷�
            using (Ocr ocr = new Ocr())
            {
                string newName = "";
                //����������Ϣ
                folderBrowserDialog1.Description = "ѡ���ļ���";
                //���ø�Ŀ¼Ϊ����
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
                //���ò���ʾ�����ļ��а�ť
                folderBrowserDialog1.ShowNewFolderButton = false;
                //���ѡ����ļ��У����ҵ��ȷ����ť������ʾ�ļ���·��
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = DateTime.Now.ToString();
                    //��ѡ��õ��ļ���·����ʾ���ı�����
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                    //��ȡ�ļ����е������ļ�����·��
                    string[] fileNames = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    //���������ļ���������Ocrʶ�𷽷�������ʶ�������浽�µ��ļ��У�����ʾ�ļ���

                    string endTime = "";
                    //������ʱ��
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Restart();
                    //������������б�
                    List<Task<string>> tasks = new List<Task<string>>();
                    foreach (string fileName in fileNames)
                    {
                        listBox1.Items.Add(Path.GetFileName(fileName));
                        keys.Add(fileName);
                        //����Ocrʶ�𷽷�������ʶ�������浽�µ��ļ��У��������ļ���
                        var t = Task.Run<string>(() => { return ocr.GetFilePath(fileName); });
                        tasks.Add(t);
                    }
                    foreach (var task in tasks)
                    {
                        var result = await task;
                        if (result != null)
                        {
                            //��ȡ�ļ���
                            file.Add(keys[tasks.IndexOf(task)], result);
                        }
                    }
                    stopwatch.Stop();
                    Invoke(new Action(() =>
                    {
                        textBox3.Text = "��ʱ��" + stopwatch.Elapsed.TotalSeconds.ToString() + "��";

                    }
                    ));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //���������ļ���������Ocrʶ�𷽷�������ʶ�������浽�µ��ļ��У�����ʾ�ļ���
                foreach (string fileName in keys)
                {
                    if (System.IO.File.Exists(fileName))
                    {
                        FileInfo fi = new FileInfo(fileName);
                        //��ֹ�ļ����ظ�
                        if (!File.Exists(textBox1.Text + "\\" + file.GetValueOrDefault(fileName) + ".jpg"))
                        {
                            fi.MoveTo(textBox1.Text + "\\" + file.GetValueOrDefault(fileName) + ".jpg");
                        }

                    }
                    listBox2.Items.Add(file.GetValueOrDefault(fileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string fileName in keys)
            {
                listBox2.Items.Add(file.GetValueOrDefault(fileName));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.Text = "ѡ���������Ϊ\r\n";
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                //������ȡѡ���������
                textBox4.Text += listBox2.SelectedItems[i].ToString() + "\r\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
        //ȫѡ
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBox2.Items.Count; i++)
            {
                this.listBox2.SetSelected(i, true);
            }
        }
    }
}
