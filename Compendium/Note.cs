using System;
using System.Collections.Generic;

namespace Compendium.Model.Data
{
    public class Note
    {
        static long NextID = 1;
        public static readonly char SEPARATOR = (char)31;

        private Note() { }

        private List<String> _tags;
        private String _title;
        private String _body;
        private DateTime _updated;

        public long ID { get; }
        public DateTime Added { get; set; }
        public DateTime Updated { get => _updated;}
        public List<String> Tags { get => _tags; set { _tags = value; _updated = DateTime.Now; } }
        public String Title { get => _title; set { _title = value; _updated = DateTime.Now; } }
        public String Body { get => _body; set {_body = value; _updated = DateTime.Now; } }

        public Note(String title, String body, String[] tags, DateTime added)
        {
            ID = NextID++;
            Added = added;
            Tags = new List<String>();
            foreach (String tag in tags)
            {
                Tags.Add(tag);
            }
            Title = title;
            Body = body;
        }

        public Note(String title, String body, String[] tags) : this(title, body, tags, DateTime.Now) { }

        public override String ToString()
        {
            return ID.ToString() + SEPARATOR + Title + SEPARATOR + string.Join(";", Tags.ToArray()) + SEPARATOR + Added.ToString("dd/MM/yyyy h:mm tt") + SEPARATOR + Body + SEPARATOR + _updated.ToString("dd/MM/yyyy h:mm tt");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return (obj as Note).ID == ID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}