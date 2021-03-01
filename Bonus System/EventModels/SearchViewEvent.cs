using System;
using System.Collections.Generic;
using System.Text;

namespace Bonus_System.EventModels
{
    public class SearchViewEvent
    {
        private string _textDesc;
        private string _subText;


        public string TextDesc
        {
            get { return _textDesc; }
            set
            {
                _textDesc = value;
            }
        }
        public string SubText
        {
            get { return _subText; }
            set
            {
                _subText = value;
            }
        }


        public SearchViewEvent(string textDesc, string subText)
        {
            TextDesc = textDesc;
            SubText = subText;
        }

    }
}
