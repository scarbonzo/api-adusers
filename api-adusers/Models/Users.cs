using System;
using System.Collections.Generic;

namespace api_adusers.Models
{
    public partial class Users
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Displayname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Ou { get; set; }
        public string Program { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Extension { get; set; }
        public string Title { get; set; }
        public string GroupList { get; set; }
        public DateTime? Passwordlastset { get; set; }
        public DateTime? Lastlogin { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Deletiondate { get; set; }
        public string Notes { get; set; }
        public bool? Expirable { get; set; }
        public DateTime? Lastupdate { get; set; }
        public bool? Active { get; set; }
    }
}
