using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXPSIApp.FModels
{
    /// <summary>
    /// 下拉项
    /// </summary>
    public class ComboBoxItem
    {
        public string Text { set; get; }
        public int Value { set; get; }

        public ComboBoxItem(string text,int val)
        {
            this.Text = text;
            this.Value = val;
        }
        public override string ToString()
        {
            return Text;
        }
       public int GetValue()
        {
            return Value;
        }
    }
}
