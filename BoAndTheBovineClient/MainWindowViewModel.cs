namespace BoAndTheBovineClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _actual;
        private string _actualPathAndFilename;
        private string _expected;
        private string _expectedPathAndFilename;
        private bool _isMultiLine;
        private bool _isSingleLine;
        private string _fromVs2012;
        private string _result;

        public MainWindowViewModel()
        {
            _isMultiLine = ! IsSingleLine;  //  No change event is raised.  Is this correct behaviour?
        }

        public string Actual
        {
            get { return _actual; }
            set
            {
                if (_actual != value)
                {
                    _actual = value;
                    RaisePropertyChanged("Actual");
                    IsMultiLine = _actual.Contains("\n");
                }
            }
        }

        public string ActualPathAndFilename
        {
            get { return _actualPathAndFilename; }
            set
            {
                if (_actualPathAndFilename != value)
                {
                    _actualPathAndFilename = value;
                    RaisePropertyChanged("ActualPathAndFilename");
                }
            }
        }

        public string Expected
        { 
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

        public string ExpectedPathAndFilename
        {
            get { return _expectedPathAndFilename; }
            set
            {
                if (_expectedPathAndFilename  != value)
                {
                    _expectedPathAndFilename = value;
                    RaisePropertyChanged("ExpectedPathAndFilename");
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

        public bool IsMultiLine
        {
            get { return _isMultiLine; }
            set
            {
                if (_isMultiLine != value)
                {
                    _isMultiLine = value;
                    RaisePropertyChanged("IsMultiLine");
                    IsSingleLine = !_isMultiLine;
                }
            }
        }

        public bool IsSingleLine
        {
            get { return _isSingleLine; }
            set
            {
                if ( _isSingleLine != value)
                {
                    _isSingleLine = value;
                    RaisePropertyChanged("IsSingleLIne");
                    IsMultiLine = !_isSingleLine;
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
