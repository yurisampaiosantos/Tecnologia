using System;
using System.Collections.Generic;

//====================================================================

namespace DTO
{
    //====================================================================
    public class CollectionLoggedUserDTO : List<LoggedUserDTO> { }
    //====================================================================
    public class LoggedUserDTO
    {
        //====================================================================
        public string Domain { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        //====================================================================
    }
}