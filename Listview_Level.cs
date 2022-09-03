using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfMerge
{
    public partial class Listview_Level : Form
    {

        Dictionary<int, string> dict;
        public Listview_Level(Dictionary<int,string> dict)
        {
            
            InitializeComponent();
            this.dict = dict;
            this.listView1.toListView(dict);
           
            
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Listview_Level_Load(object sender, EventArgs e)
        {

        }


        private void btn_Export_Click(object sender, EventArgs e)
        {
            dict.Export();
        }

    }

    public static class ListViewExtension
    {
        public static ListView toListView<T,S>(this ListView LV, Dictionary<T,S> dict)
        {
            int i = 0;
            foreach (KeyValuePair<T,S> kvp in dict)
            {
                ListViewItem item = new ListViewItem(kvp.Key.ToString(), kvp.Value.ToString());
                item.Text = kvp.Key.ToString();
                item.SubItems.Add(kvp.Value.ToString());
                LV.Items.AddRange(new ListViewItem[] { item });
            }
            return LV;
        }
    }
}
