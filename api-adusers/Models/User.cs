using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_adusers.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Displayname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SortName { get; set; }
        public string Ou { get; set; }
        public string Program { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Extension { get; set; }
        public string Title { get; set; }
        public string GroupList { get; set; }
        public List<string> Groups { get; set; }
        public DateTime? Passwordlastset { get; set; }
        public DateTime? Lastlogin { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Deletiondate { get; set; }
        public string Notes { get; set; }
        public bool? Expirable { get; set; }
        public DateTime? Lastupdate { get; set; }
        public bool? Active { get; set; }

        public User(Users user)
        {
            Id = user.Id;
            Username = user.Username;
            Displayname = user.Displayname;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Ou = user.Ou;
            Program = user.Program;
            Office = user.Office;
            Email = user.Email;
            Extension = user.Extension;
            Title = user.Title;
            GroupList = user.GroupList;
            Passwordlastset = user.Passwordlastset;
            Lastlogin = user.Lastlogin;
            Deleted = user.Deleted;
            Deletiondate = user.Deletiondate;
            Notes = user.Notes;
            Expirable = user.Expirable;
            Lastupdate = user.Lastupdate;
            Active = user.Active;

            Groups = new List<string>();

            try
            {
                if (GroupList != null)
                {
                    foreach (string group in GroupList.Split(',').ToList().Where(g => g.Contains("CN=")).ToList())
                    {
                        Groups.Add(group.Replace("CN=", "").Trim());
                    }
                }
            } catch { }

            try
            {
                if (Firstname != null)
                {
                    SortName = Lastname + ", " + Firstname;
                }
                else
                {
                    SortName = Lastname;
                }
            } catch { }
        }
    }
}
