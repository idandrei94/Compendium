using Compendium.Model.Data;
using Compendium.Model.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Compendium.Model
{
    class ModelManager : IModel
    {
        private List<Note> notes = new List<Note>();
        private bool isChanged = true;
        private String[] _results = null;

        public String[] Results { get => (isChanged)  ? (_results = Filter()) :  _results; } 

        public List<Func<Note, bool>> Filters { get; } = new List<Func<Note, bool>>();

        public int Count { get => notes.Count; }

        public String Name { get; set; }

        public Note this[int index] {
            get
            {
                try
                {
                    return notes[index];
                } catch (Exception e)
                {
                    throw e;
                }
            }
        }
        
        public ModelManager()
        {
        }

        public string Add(String title, String body, String[] tags, DateTime? added = null)
        {
            Note note = new Note(title, body, tags, added ?? DateTime.Now);
            notes.Add(note);
            isChanged = true;
            return note.ToString();
        }

        public int Remove(long ID)
        {
            notes = notes.Where(x => x.ID != ID).ToList<Note>();
            isChanged = true;
            return notes.Count;
        }

        public void Save(string filename)
        {
            Console.WriteLine("Saving to {0}", filename);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));

            using (var writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, notes);
            }
        }

        public int Load(string filename)
        {
            notes = new List<Note>();
            Name = filename;
            try
            {
                XDocument notesXML = XDocument.Load(filename);
                notes =
                    notesXML.Root.Elements("Note")
                        .Select(n => new Note(
                            (string)n.Element("Title"),
                            (string)n.Element("Body"),
                            n.Element("Tags").Elements().Select(t => (string)t).ToArray<String>(),
                            DateTime.Parse((string)n.Element("Added"))
                        )).ToList();
            }
            catch(Exception)
            {
            }
            isChanged = true;
            return notes.Count;
        }

        public IEnumerator<String> GetEnumerator() => notes.Select(x => x.ToString()).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => notes.Select(x => x.ToString()).GetEnumerator();

        public string[] Filter()
        {
            isChanged = false;
            return notes.AsParallel().Where(
                n => Filters.Aggregate(
                    true, (acc, val) => acc && val(n) )
                       ).Select(n => n.ToString()).ToArray();
        }
        
        public int RemoveFilter(int filterIndex)
        {
            Filters.RemoveAt(filterIndex);
            isChanged = true;
            return Filters.Count;
        }

        public int AddFilter(NoteFilterFactory.FilterType type, String arg)
        {
            Filters.Add(NoteFilterFactory.Filter(type, arg));
            isChanged = true;
            return Filters.Count;
        }

        public int AddFilter( NoteFilterFactory.FilterType type, DateTime arg)
        {
            Filters.Add(NoteFilterFactory.Filter(type, arg));
            isChanged = true;
            return Filters.Count;
        }

        public String AlterNote(String noteString)
        {
            String[] splitData = noteString.Split(Note.SEPARATOR);
            foreach(Note n in notes)
            {
                if(n.ID == long.Parse(splitData[0]))
                {
                    n.Title = splitData[1];
                    n.Tags.Clear();
                    foreach(String tag in splitData[2].Split(';'))
                    {
                        n.Tags.Add(tag);
                    }
                    n.Added = DateTime.ParseExact(splitData[3], "dd/MM/yyyy h:mm tt", null);
                    n.Body = splitData[4];
                    isChanged = true;
                    return n.ToString();
                }
            }
            isChanged = true;
            return "";
        }
    }
}