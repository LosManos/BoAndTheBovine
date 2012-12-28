namespace BoAndTheBovineClient
{
    /// <summary>This is the Viewmodel for the Settings dialogue.
    /// </summary>
    internal class SettingsDialogueViewModel : ViewModelBase
    {
        private string _version ;

        /// <summary>This property is the version of the client as by
        /// http://stackoverflow.com/questions/909555/how-can-i-get-the-assembly-file-version
        /// </summary>
        public string Version
        {
            get { return _version; }
            set
            {
                if (_version != value)
                {
                    _version = value;
                    RaisePropertyChanged("version");
                }
            }
        }

        internal static SettingsDialogueViewModel Create(string version)
        {
            return new SettingsDialogueViewModel().Set(version);
        }

        private SettingsDialogueViewModel Set(string version)
        {
            this.Version = version;
            return this;
        }
    }
}
