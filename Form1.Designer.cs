namespace WinFormOcrTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            button3 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(99, 38);
            button1.Name = "button1";
            button1.Size = new Size(83, 23);
            button1.TabIndex = 0;
            button1.Text = "选择文件夹";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(364, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 89);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 2;
            label1.Text = "源文件列表：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 89);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 3;
            label2.Text = "修改后文件列表";
            // 
            // button2
            // 
            button2.Location = new Point(616, 61);
            button2.Name = "button2";
            button2.Size = new Size(145, 23);
            button2.TabIndex = 6;
            button2.Text = "批量修改名字";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(12, 110);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(394, 191);
            listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Location = new Point(412, 110);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(376, 191);
            listBox2.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(616, 32);
            button3.Name = "button3";
            button3.Size = new Size(145, 23);
            button3.TabIndex = 9;
            button3.Text = "显示修改后的名字";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(50, 302);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(432, 302);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(261, 23);
            textBox3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Button button3;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
