using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public List<String> Variants = new List<String>();


        public Question(string text, string answer, string var1, string var2, string var3, string var4)
        {
            Text = text;
            Answer = answer;
            Variants = new List<String> { var1, var2, var3, var4 };
        }


    }
}
