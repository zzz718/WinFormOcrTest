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
        private void button1_Click(object sender, EventArgs e)
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
                    //��ȡ�ļ����е������ļ�
                    string[] fileNames = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    //���������ļ���������Ocrʶ�𷽷�������ʶ�������浽�µ��ļ��У�����ʾ�ļ���
                    foreach (string fileName in fileNames)
                    {
                        listBox1.Items.Add(Path.GetFileName(fileName));
                        keys.Add(fileName);
                        newName = ocr.GetFilePath(fileName);
                        file.Add(fileName, newName);
                    }
                }
                textBox3.Text = DateTime.Now.ToString();
                GC.Collect();
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
    }
}
