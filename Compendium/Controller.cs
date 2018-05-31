using Compendium.Model;
using Compendium.Model.Filtering;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Compendium
{
    public class Controller : INotifyPropertyChanged
    {
        private IModel model;
        private String filepath;
        private String title;

        public String Title { get => title; }
        public String Filepath { get => filepath; }

        private bool _changed;

        public bool Changed { get => _changed; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public String[] Results { get => model.Results.AsParallel().Select(n => n.ToString()).ToArray(); }
        public int ResultCount { get => model.Results.Count(); }

        public String[] ResultRange(int from, int to)
        {
            String[] ret = new String[to - from];
            for(int i=0; i<ret.Length;++i)
            {
                ret[i] = model.Results[i + from].ToString();
            }
            return ret;
        }

        public Controller(String filepath, String title)
        {
            this.title = title;
            this.filepath = filepath;
            model = new ModelManager();
            _changed = false;
        }

        public void Open(Action error)
        {
            model.Load_Async(filepath, () =>
            {
                OnPropertyChanged("Results");
            }, error);
        }

        public int Save()
        {
            _changed = false;
            model.Save(filepath);
            return model.Count;
        }

        public int RemoveFilter(int filterIndex)
        {
            int ret = model.RemoveFilter(filterIndex);
            OnPropertyChanged("Results");
            return ret;
        }

        public int AddFilter(NoteFilterFactory.FilterType type, String arg)
        {
            int ret = model.AddFilter(type, arg);
            OnPropertyChanged("Results");
            return ret;
        }

        public int AddFilter(NoteFilterFactory.FilterType type, DateTime arg)
        {
            int ret = model.AddFilter(type, arg);
            OnPropertyChanged("Results");
            return ret;
        }

        public String AddNote(String title, String body, String[] tags, DateTime? added = null)
        {
            _changed = true;
            String ret = model.Add(title, body, tags, added);
            OnPropertyChanged("Results");
            return ret;
        }

        public int RemoveNote(long ID)
        {
            _changed = true;
            int ret = model.Remove(ID);
            OnPropertyChanged("Results");
            return ret;
        }

        public String AlterNote(String noteString)
        {
            _changed = true;
            String ret =  model.AlterNote(noteString);
            OnPropertyChanged("Results");
            return ret;
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}