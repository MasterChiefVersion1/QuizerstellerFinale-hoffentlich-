using System;
using System.Collections.Generic;
using System.Text;

namespace quizersteller2
{
    public class Question
    {
        public int variant = 1;
        public string text { get; set; }

        public Question(int _variant, string _text)
        {
            text = _text;
            variant = _variant;
        }

    }
}
