using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using goliath.pdf.MOD;
using goliath.pdf.DAL;

namespace goliath.pdf.NEG
{
    public class UserNEG
    {
        public UserMOD Find(int id)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.Find(id);
        }
    }
}
