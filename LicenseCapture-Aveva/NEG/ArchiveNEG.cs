using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace goliath.licensecapture.NEG
{
    public class ArchiveNEG
    {
        public void CaptureArchive()
        {
            goliath.licensecapture.DAL.ArchiveDAL obj = new goliath.licensecapture.DAL.ArchiveDAL();
            obj.GenerateArchive();
        }
    }
}
