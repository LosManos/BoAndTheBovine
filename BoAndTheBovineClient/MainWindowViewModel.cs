using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoAndTheBovineClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _actual;
        private string _expected;
        private string _fromVs2012;
        private string _result;

        public string Actual
        {
            get { return _actual; }
            set
            {
                if (_actual != value)
                {
                    _actual = value;
                    RaisePropertyChanged("Actual");
                }
            }
        }
        public string Expected { 
            get{ return _expected;}
            set
            {
                if (_expected != value)
                {
                    _expected = value;
                    RaisePropertyChanged("Expected");
                }
            }
        }

        public string FromVS2012
        {
            get { return _fromVs2012; }
            set
            {
                if (_fromVs2012 != value)
                {
                    _fromVs2012 = value;
                    RaisePropertyChanged("FromVS2012");
                }
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    RaisePropertyChanged("Result");
                }
            }
        }

    }
}
