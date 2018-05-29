using Compendium.Model.Data;
using System;

namespace Compendium.Model.Filtering
{
    public class NoteFilterFactory
    {
        public enum FilterType
        {
            TAG,
            TAG_INVERTED,
            DATE_BEFORE,
            DATE_AFTER,
            KEYWORD
        }

        // return a delegate(note : Note) : boolean
        public static Func<Note, bool> Filter(FilterType type, String arg)
        {
            switch (type)
            {
                case NoteFilterFactory.FilterType.TAG:
                    return new Func<Note, bool>((n) => n.Tags.Contains(arg));
                case NoteFilterFactory.FilterType.TAG_INVERTED:
                    return new Func<Note, bool>((n) => !n.Tags.Contains(arg));
                case NoteFilterFactory.FilterType.DATE_AFTER:
                    throw new InvalidCastException("Unable to cast String tag to DateTime for a DATE_AFTER filter.");
                case NoteFilterFactory.FilterType.DATE_BEFORE:
                    throw new InvalidCastException("Unable to cast String tag to DateTime for a DATE_BEFORE filter.");
                case NoteFilterFactory.FilterType.KEYWORD:
                    return new Func<Note, bool>((n) => n.Body.Contains(arg) || n.Title.Contains(arg));
                default:
                    return new Func<Note, bool>((n) => true);
            }
        }

        public static Func<Note, bool> Filter(FilterType type, DateTime arg)
        {
            switch (type)
            {
                case NoteFilterFactory.FilterType.TAG:
                    throw new InvalidCastException("Unable to cast DateTime object to String tag for a TAG filter.");
                case NoteFilterFactory.FilterType.TAG_INVERTED:
                    throw new InvalidCastException("Unable to cast DateTime object to String tag for a TAG_INVERTED filter.");
                case NoteFilterFactory.FilterType.DATE_AFTER:
                    return new Func<Note, bool>((n) => n.Added >= arg);
                case NoteFilterFactory.FilterType.DATE_BEFORE:
                    return new Func<Note, bool>((n) => n.Added <= arg);
                case NoteFilterFactory.FilterType.KEYWORD:
                    throw new InvalidCastException("Unable to cast DateTime object to String tag for a KEYWORD filter.");
                default:
                    return new Func<Note, bool>((n) => true);
            }
        }
    }
}