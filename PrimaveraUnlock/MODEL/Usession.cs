using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public class Usession
    {
        private decimal _sessionId;

        public decimal SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        private DateTime _loginTime;

        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        private DateTime _lastActiveTime;

        public DateTime LastActiveTime
        {
            get { return _lastActiveTime; }
            set { _lastActiveTime = value; }
        }
        private string _hostName;

        public string HostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }
        private string _appName;

        public string AppName
        {
            get { return _appName; }
            set { _appName = value; }
        }
        private string _osUserName;

        public string OsUserName
        {
            get { return _osUserName; }
            set { _osUserName = value; }
        }
        private string _updateUser;

        public string UpdateUser
        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }  
    }
}
