using Compendium.Model.Data;
using Compendium.Model.Filtering;
using System;
using System.Collections.Generic;

namespace Compendium.Model
{
    public interface IModel : IEnumerable<String>
    {

        List<Func<Note, bool>> Filters { get; }

        String[] Results { get; }

        String Name { get; set; }

        int Count { get; }

        Note this[int index] { get; }
        String Add(String title, String body, String[] tags, DateTime? added = null);
        int Remove(long ID);
        void Save(String filename);
        int Load(String filename);

        String[] Filter();

        int RemoveFilter(int filterIndex);

        int AddFilter(NoteFilterFactory.FilterType type, String arg);

        int AddFilter(NoteFilterFactory.FilterType type, DateTime arg);

        String AlterNote(String noteString);
    }
}