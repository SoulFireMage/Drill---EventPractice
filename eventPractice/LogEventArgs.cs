namespace eventPractice
    {
    public class LogEventArgs : System.EventArgs
        {
        private string _path;
        private string _content;
        

        public LogEventArgs(string path, string content)
            {
            _path = path;
            _content = content;
            }

        public string path { get { return _path; }  set { _path = value; } }
        public string content { get { return _content; }   set { _content = value; } }
        }
    } 