namespace FlashBuild
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FillRandomData = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupList = new System.Windows.Forms.TreeView();
            this.GroupRemove = new System.Windows.Forms.Button();
            this.GroupAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SaveLen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DataList = new System.Windows.Forms.ListBox();
            this.DataAdd = new System.Windows.Forms.Button();
            this.DataUp = new System.Windows.Forms.Button();
            this.DataDown = new System.Windows.Forms.Button();
            this.DataRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveMode
            // 
            this.SaveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SaveMode.FormattingEnabled = true;
            this.SaveMode.Items.AddRange(new object[] {
            "无",
            "数据分块",
            "字符顺序索引"});
            this.SaveMode.Location = new System.Drawing.Point(64, 13);
            this.SaveMode.Name = "SaveMode";
            this.SaveMode.Size = new System.Drawing.Size(80, 20);
            this.SaveMode.TabIndex = 2;
            this.SaveMode.SelectedIndexChanged += new System.EventHandler(this.SaveMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "存储方式:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FillRandomData);
            this.groupBox1.Controls.Add(this.SaveMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(305, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 57);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // FillRandomData
            // 
            this.FillRandomData.AutoSize = true;
            this.FillRandomData.Location = new System.Drawing.Point(8, 35);
            this.FillRandomData.Name = "FillRandomData";
            this.FillRandomData.Size = new System.Drawing.Size(108, 16);
            this.FillRandomData.TabIndex = 4;
            this.FillRandomData.Text = "空位填充随机值";
            this.FillRandomData.UseVisualStyleBackColor = true;
            this.FillRandomData.CheckedChanged += new System.EventHandler(this.FillRandomData_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GroupList);
            this.groupBox2.Controls.Add(this.GroupRemove);
            this.groupBox2.Controls.Add(this.GroupAdd);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(5, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据组";
            // 
            // GroupList
            // 
            this.GroupList.Font = new System.Drawing.Font("宋体", 16F);
            this.GroupList.Location = new System.Drawing.Point(7, 15);
            this.GroupList.Name = "GroupList";
            this.GroupList.ShowLines = false;
            this.GroupList.ShowPlusMinus = false;
            this.GroupList.ShowRootLines = false;
            this.GroupList.Size = new System.Drawing.Size(199, 124);
            this.GroupList.TabIndex = 2;
            this.GroupList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.GroupList_ItemDrag);
            this.GroupList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GroupList_AfterSelect);
            // 
            // GroupRemove
            // 
            this.GroupRemove.Location = new System.Drawing.Point(212, 46);
            this.GroupRemove.Name = "GroupRemove";
            this.GroupRemove.Size = new System.Drawing.Size(75, 23);
            this.GroupRemove.TabIndex = 1;
            this.GroupRemove.Text = "删除";
            this.GroupRemove.UseVisualStyleBackColor = true;
            this.GroupRemove.Click += new System.EventHandler(this.GroupRemove_Click);
            // 
            // GroupAdd
            // 
            this.GroupAdd.Location = new System.Drawing.Point(212, 17);
            this.GroupAdd.Name = "GroupAdd";
            this.GroupAdd.Size = new System.Drawing.Size(75, 23);
            this.GroupAdd.TabIndex = 1;
            this.GroupAdd.Text = "添加";
            this.GroupAdd.UseVisualStyleBackColor = true;
            this.GroupAdd.Click += new System.EventHandler(this.GroupAdd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveFileButton);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.SaveLen);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.SaveOffset);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.SaveAddr);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(305, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 239);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "数据预览:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(8, 113);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(194, 119);
            this.textBox4.TabIndex = 8;
            // 
            // SaveLen
            // 
            this.SaveLen.Location = new System.Drawing.Point(111, 71);
            this.SaveLen.Name = "SaveLen";
            this.SaveLen.Size = new System.Drawing.Size(91, 21);
            this.SaveLen.TabIndex = 6;
            this.SaveLen.TextChanged += new System.EventHandler(this.SaveLen_TextChanged);
            this.SaveLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputInt);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据长度:";
            // 
            // SaveOffset
            // 
            this.SaveOffset.Location = new System.Drawing.Point(8, 72);
            this.SaveOffset.Name = "SaveOffset";
            this.SaveOffset.Size = new System.Drawing.Size(91, 21);
            this.SaveOffset.TabIndex = 4;
            this.SaveOffset.TextChanged += new System.EventHandler(this.SaveOffset_TextChanged);
            this.SaveOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputInt);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "偏移量:";
            // 
            // SaveAddr
            // 
            this.SaveAddr.Location = new System.Drawing.Point(8, 32);
            this.SaveAddr.Name = "SaveAddr";
            this.SaveAddr.Size = new System.Drawing.Size(194, 21);
            this.SaveAddr.TabIndex = 1;
            this.SaveAddr.TextChanged += new System.EventHandler(this.SaveAddr_TextChanged);
            this.SaveAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputInt);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "储存地址:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DataList);
            this.groupBox4.Controls.Add(this.DataAdd);
            this.groupBox4.Controls.Add(this.DataUp);
            this.groupBox4.Controls.Add(this.DataDown);
            this.groupBox4.Controls.Add(this.DataRemove);
            this.groupBox4.Location = new System.Drawing.Point(5, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(294, 146);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据";
            // 
            // DataList
            // 
            this.DataList.AllowDrop = true;
            this.DataList.FormattingEnabled = true;
            this.DataList.ItemHeight = 12;
            this.DataList.Location = new System.Drawing.Point(6, 15);
            this.DataList.Name = "DataList";
            this.DataList.Size = new System.Drawing.Size(201, 124);
            this.DataList.TabIndex = 0;
            this.DataList.SelectedIndexChanged += new System.EventHandler(this.DataList_SelectedIndexChanged);
            this.DataList.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataList_DragDrop);
            this.DataList.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataList_DragEnter);
            // 
            // DataAdd
            // 
            this.DataAdd.Location = new System.Drawing.Point(213, 20);
            this.DataAdd.Name = "DataAdd";
            this.DataAdd.Size = new System.Drawing.Size(75, 23);
            this.DataAdd.TabIndex = 0;
            this.DataAdd.Text = "添加";
            this.DataAdd.UseVisualStyleBackColor = true;
            this.DataAdd.Click += new System.EventHandler(this.DataAdd_Click);
            // 
            // DataUp
            // 
            this.DataUp.Location = new System.Drawing.Point(213, 49);
            this.DataUp.Name = "DataUp";
            this.DataUp.Size = new System.Drawing.Size(75, 23);
            this.DataUp.TabIndex = 0;
            this.DataUp.Text = "上移";
            this.DataUp.UseVisualStyleBackColor = true;
            this.DataUp.Click += new System.EventHandler(this.DataUp_Click);
            // 
            // DataDown
            // 
            this.DataDown.Location = new System.Drawing.Point(213, 78);
            this.DataDown.Name = "DataDown";
            this.DataDown.Size = new System.Drawing.Size(75, 23);
            this.DataDown.TabIndex = 0;
            this.DataDown.Text = "下移";
            this.DataDown.UseVisualStyleBackColor = true;
            this.DataDown.Click += new System.EventHandler(this.DataDown_Click);
            // 
            // DataRemove
            // 
            this.DataRemove.Location = new System.Drawing.Point(212, 107);
            this.DataRemove.Name = "DataRemove";
            this.DataRemove.Size = new System.Drawing.Size(75, 23);
            this.DataRemove.TabIndex = 0;
            this.DataRemove.Text = "删除";
            this.DataRemove.UseVisualStyleBackColor = true;
            this.DataRemove.Click += new System.EventHandler(this.DataRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 307);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Flash数据生成";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox SaveMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox FillRandomData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button GroupRemove;
        private System.Windows.Forms.Button GroupAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox SaveLen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SaveOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SaveAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox DataList;
        private System.Windows.Forms.Button DataAdd;
        private System.Windows.Forms.Button DataUp;
        private System.Windows.Forms.Button DataDown;
        private System.Windows.Forms.Button DataRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TreeView GroupList;
    }
}

