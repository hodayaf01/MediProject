//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Association_Managment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Protocol
    {
        public long CodeProtocol { get; set; }
        public Nullable<long> CodeMeeting { get; set; }
        public string LinkProtocol { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> DeleteRow { get; set; }
        public string LinkSignedProtocol { get; set; }
    }
}
