using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace goliath.licensecapture.MOD
{
    public class License
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _service;

        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }
        private string _issued;

        public string Issued
        {
            get { return _issued; }
            set { _issued = value; }
        }
        private string _use;

        public string Use
        {
            get { return _use; }
            set { _use = value; }
        }
        private string _users;

        public string Users
        {
            get { return _users; }
            set { _users = value; }
        }
        private string _marchine;

        public string Marchine
        {
            get { return _marchine; }
            set { _marchine = value; }
        }
        private string _dateStart;

        public string DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        private string _hours;

        public string Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        private string _createdDate;

        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

    }
}
