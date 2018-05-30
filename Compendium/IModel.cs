using Compendium.Model.Data;
using Compendium.Model.Filtering;
using System;
using System.Collections.Generic;

namespace Compendium.Model
{
    public interface IModel : IEnumerable<String>
    {

        List<Func<Note, bool>> Filters { get; }

        Note[] Results { get; }

        String Name { get; set; }

        int Count { get; }

        Note this[int index] { get; }
        String Add(String title, String body, String[] tags, DateTime? added = null);
        int Remove(long ID);
        void Save(String filename);
        void Load(String filename);
        void Load_Async(string filename, Action callback);

        int RemoveFilter(int filterIndex);

        int AddFilter(NoteFilterFactory.FilterType type, String arg);

        int AddFilter(NoteFilterFactory.FilterType type, DateTime arg);

        String AlterNote(String noteString);
    }
}