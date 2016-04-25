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

namespace FlashBuild
{
    public partial class Form1 : Form
    {
        int LastGroupSelect;
        GroupInfo LastGroupInfo;

        interface BuildData
        {
            byte[] build();
            void build(Stream fs);
        }



        class GroupInfo:BuildData
        {
            public List<DataInfo> objList=new List<DataInfo>();
            public string name;
            public int lenght=0;
            public bool fillrandom=false;
            public int buildmode=0;
            public byte maskcode = 0xff;
            //public byte[] data;
            public GroupInfo(string name)
            {
                this.name = name;
            }

            public override string ToString()
            {
                return name;
            }

            byte[] BuildData.build()
            {
                throw new NotImplementedException();
            }

            public void build(Stream fs)
            {
                int lastaddr = 0;
                Random rand = new Random();
                foreach (DataInfo info in objList)
                {
                    if (info.lenght == 0)
                        continue;
                    if (lastaddr < info.addr)
                    {
                        if (fillrandom)
                            for (int i = lastaddr; i < info.addr; i++)
                                fs.WriteByte((byte)rand.Next());
                        else
                            for (int i = lastaddr; i < info.addr; i++)
                                fs.WriteByte(maskcode);
                    }
                    if ((info.lenght) <= (info.data.Length- info.offset))
                    {
                        fs.Write(info.data, info.offset, info.lenght);
                    }
                    else
                    {
                        fs.Write(info.data, info.offset, info.data.Length - info.offset);
                        if (fillrandom)
                            for (int i = info.data.Length - info.offset; i < info.lenght; i++)
                                fs.WriteByte((byte)rand.Next());
                        else
                            for (int i = info.data.Length - info.offset; i < info.lenght; i++)
                                fs.WriteByte(maskcode);
                    }
                    lastaddr = info.addr+info.lenght;
                }
            }
        }

        class DataInfo
        {
            public string name;
            public byte[] data;
            public int pos;
            public int addr;
            public int offset;
            public int lenght;
            public int size;
            public DataInfo(string name,byte[] v)
            {
                this.name = name;
                data = v;
                if(v==null)
                    size = lenght = 0;
                else
                    size = lenght = data.Length;
                pos = offset = 0;
            }

            public override string ToString()
            {
                return string.Format("[{0}] - {1}",name,size);
            }

        }

        class DataInfoEx:DataInfo
        {
            public DataInfoEx(GroupInfo g):base(g.name,null)
            {
                base.lenght = g.lenght;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveMode.SelectedIndex = 0;
            TreeNode Node = new TreeNode("分组1");
            Node.Tag = new GroupInfo("分组1");
            GroupList.Nodes.Add(Node);
            GroupList.SelectedNode = GroupList.Nodes[0];
        }

        void AddData(string path)
        {
            int index = path.LastIndexOf('\\');
            string name;
            if (index == -1)
                name = path;
            else
                name = path.Substring(index + 1);
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                AddData(of.SafeFileName, data);
                fs.Close();
            }
            catch(Exception e) { MessageBox.Show("打开文件发生错误\r\n"+e.ToString()); }
        }

        int UpdateData()
        {
            int last=0;
            foreach(DataInfo info in DataList.Items)
            {
                if (info == null) continue;
                info.addr = last;
                //if (info.size - info.offset < 0) info.lenght = 0;
                last = info.addr + info.lenght;
            }
            return last;
        }

        int CheckData()
        {
            int last = 0;
            for (int i = 0; i < DataList.Items.Count; i++)
            {
                DataInfo info = DataList.Items[i] as DataInfo;
                if (info == null) continue;
                int value = info.size - info.offset;
                if (value < 0)
                    return i;
                if (last > info.addr)
                    return i;
                last = info.addr;
            }
            return -1;
        }

        void AddData(string name,byte[] data)
        {
            DataInfo info = new DataInfo(name, data);
            DataList.Items.Add(info);
            DataList.SelectedIndex = DataList.Items.Count - 1;
        }

        OpenFileDialog of = new OpenFileDialog();
        private void DataAdd_Click(object sender, EventArgs e)
        {
            if (GroupList.SelectedNode == null) return;
            of.Filter = "数据文件(*.dat)|*.dat";
            if (of.ShowDialog() == DialogResult.OK)
            {
                AddData(of.FileName);
                UpdateData();
            }
        }

        private void DataList_DragDrop(object sender, DragEventArgs e)
        {
            object o= e.Data.GetData(DataFormats.FileDrop);
            if (o != null)
            {
                string path = ((System.Array)o).GetValue(0).ToString();
                AddData(path);
            }
            o = e.Data.GetData(typeof(GroupInfo));
            if (o != null)
            {
                MemoryStream ms = new MemoryStream();
                ((GroupInfo)o).build(ms);
                AddData(((GroupInfo)o).name,ms.ToArray());
                ms.Dispose();
                //AddData(((GroupInfo)o).name，)
                //DataList.Items.Add(info);
                //DataList.SelectedIndex = DataList.Items.Count - 1;
            }
        }

        private void DataList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link; //重要代码：表明是链接类型的数据，比如文件路径
            else if (e.Data.GetDataPresent(typeof(GroupInfo)))
                e.Effect = DragDropEffects.Move; //重要代码：表明是链接类型的数据，比如文件路径
            else e.Effect = DragDropEffects.None;
        }

        private void DataRemove_Click(object sender, EventArgs e)
        {
            if (DataList.SelectedIndex == -1) return;
            DataList.Items.RemoveAt(DataList.SelectedIndex);
            if (DataList.Items.Count != 0)
            {
                DataList.SelectedIndex = DataList.Items.Count - 1;
                UpdateData();
            }
        }

        private void DataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(DataList.SelectedItem is DataInfo))
            {
                SaveAddr.Text = "";
                SaveOffset.Text = "";
                SaveLen.Text = "";
                return;
            }
            DataInfo info = ((DataInfo)DataList.SelectedItem);
            SaveAddr.Text = info.addr.ToString();
            SaveOffset.Text = info.offset.ToString();
            SaveLen.Text = info.lenght.ToString();
        }

        private void InputInt(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void SaveAddr_TextChanged(object sender, EventArgs e)
        {
            if (!(DataList.SelectedItem is DataInfo))
                return;
            DataInfo info = ((DataInfo)DataList.SelectedItem);
            try
            {
                info.addr=int.Parse(SaveAddr.Text);
            }
            catch
            {
                info.addr = info.pos;
            }
        }

        private void SaveOffset_TextChanged(object sender, EventArgs e)
        {
            if (!(DataList.SelectedItem is DataInfo))
                return;
            DataInfo info = ((DataInfo)DataList.SelectedItem);
            try
            {
                info.offset = int.Parse(SaveOffset.Text);
            }
            catch
            {
                info.offset = 0;
            }
        }

        private void SaveLen_TextChanged(object sender, EventArgs e)
        {
            if (!(DataList.SelectedItem is DataInfo))
                return;
            DataInfo info = ((DataInfo)DataList.SelectedItem);
            try
            {
                info.lenght = int.Parse(SaveLen.Text);
            }
            catch
            {
                info.lenght = info.data.Length;
            }
        }

        private void DataUp_Click(object sender, EventArgs e)
        {
            int index = DataList.SelectedIndex;
            if (index == -1) return;
            if (index != 0)
            {
                object o = DataList.SelectedItem;
                DataList.Items.RemoveAt(index);
                DataList.Items.Insert(index - 1, o);
                UpdateData();
            }
        }

        private void DataDown_Click(object sender, EventArgs e)
        {
            int index = DataList.SelectedIndex;
            if (index == -1) return;
            if (index < DataList.Items.Count-1)
            {
                object o = DataList.SelectedItem;
                DataList.Items.RemoveAt(index);
                DataList.Items.Insert(index+1, o);
                UpdateData();
            }
        }
        int groupcount = 2;
        private void GroupAdd_Click(object sender, EventArgs e)
        {
            TreeNode Node = new TreeNode();
            Node.Tag = new GroupInfo("分组" + groupcount++);
            Node.Text = ((GroupInfo)Node.Tag).name;
            GroupList.Nodes.Add(Node);
        }

        private void GroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GroupRemove_Click(object sender, EventArgs e)
        {
            if (GroupList.SelectedNode == null) return;
            if (GroupList.Nodes.Count == 1) return;
            GroupList.SelectedNode.Remove();
            GroupList.SelectedNode = GroupList.Nodes[GroupList.Nodes.Count - 1];
        }

        private void GroupList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GroupList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (LastGroupInfo != null)
            {
                LastGroupInfo.objList.Clear();
                foreach (DataInfo info in DataList.Items)
                    LastGroupInfo.objList.Add(info);
                LastGroupInfo.lenght=UpdateData();
            }
            LastGroupInfo = (GroupInfo)GroupList.SelectedNode.Tag;
            DataList.Items.Clear();
            SaveMode.SelectedIndex = LastGroupInfo.buildmode;
            FillRandomData.Checked = LastGroupInfo.fillrandom;
            foreach (DataInfo info in LastGroupInfo.objList)
                DataList.Items.Add(info);
        }

        private void GroupList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            GroupList.DoDragDrop(GroupList.SelectedNode.Tag, DragDropEffects.Move);
        }

        private void FillRandomData_CheckedChanged(object sender, EventArgs e)
        {
            if (GroupList.SelectedNode == null) return;
            ((GroupInfo)GroupList.SelectedNode.Tag).fillrandom = FillRandomData.Checked;
        }

        private void SaveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GroupList.SelectedNode == null) return;
            ((GroupInfo)GroupList.SelectedNode.Tag).buildmode = SaveMode.SelectedIndex;
        }

        SaveFileDialog sf = new SaveFileDialog();
        private void SaveFileButton(object sender, EventArgs e)
        {
            if (GroupList.SelectedNode == null) return;
            GroupList_AfterSelect(null,null);
            if (((GroupInfo)GroupList.SelectedNode.Tag).objList.Count == 0) return;
            int code;
            if ((code=CheckData())!=-1)
            {
                MessageBox.Show("第"+(code+1)+"个数据设置错误！");
                return;
            }
            sf.Filter = "数据文件(*.dat)|*.dat";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs=null;
                try
                {
                    fs = new FileStream(sf.FileName, FileMode.Create);
                    ((BuildData)GroupList.SelectedNode.Tag).build(fs);
                    fs.Flush();
                    fs.Close();
                    MessageBox.Show("生成成功!");
                }
                catch (Exception msg)
                {
                    if(fs!=null)
                        fs.Close();
                    MessageBox.Show(msg.ToString());
                }
            }
        }
    }
}
