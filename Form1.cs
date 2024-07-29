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
            //调用Ocr识别方法
            using (Ocr ocr = new Ocr())
            {
                string newName = "";
                //设置描述信息
                folderBrowserDialog1.Description = "选择文件夹";
                //设置根目录为桌面
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
                //设置不显示新增文件夹按钮
                folderBrowserDialog1.ShowNewFolderButton = false;
                //如果选择好文件夹，并且点击确定按钮，则显示文件夹路径
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = DateTime.Now.ToString();
                    //将选择好的文件夹路径显示在文本框中
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                    //获取文件夹中的所有文件绝对路径
                    string[] fileNames = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    //遍历所有文件，并调用Ocr识别方法，并将识别结果保存到新的文件中，并显示文件名

                    string endTime = "";
                    //启动计时器
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Restart();
                    //添加任务到任务列表
                    List<Task<string>> tasks = new List<Task<string>>();
                    foreach (string fileName in fileNames)
                    {
                        listBox1.Items.Add(Path.GetFileName(fileName));
                        keys.Add(fileName);
                        //调用Ocr识别方法，并将识别结果保存到新的文件中，并返回文件名
                        var t = Task.Run<string>(() => { return ocr.GetFilePath(fileName); });
                        tasks.Add(t);
                    }
                    foreach (var task in tasks)
                    {
                        var result = await task;
                        if (result != null)
                        {
                            //获取文件名
                            file.Add(keys[tasks.IndexOf(task)], result);
                        }
                    }
                    stopwatch.Stop();
                    Invoke(new Action(() =>
                    {
                        textBox3.Text = "耗时：" + stopwatch.Elapsed.TotalSeconds.ToString() + "秒";

                    }
                    ));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //遍历所有文件，并调用Ocr识别方法，并将识别结果保存到新的文件中，并显示文件名
                foreach (string fileName in keys)
                {
                    if (System.IO.File.Exists(fileName))
                    {
                        FileInfo fi = new FileInfo(fileName);
                        //防止文件名重复
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
            textBox4.Text = "选中项的内容为\r\n";
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                //逐条读取选中项的内容
                textBox4.Text += listBox2.SelectedItems[i].ToString() + "\r\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
        //全选
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBox2.Items.Count; i++)
            {
                this.listBox2.SetSelected(i, true);
            }
        }
    }
}
