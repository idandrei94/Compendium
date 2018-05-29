using Compendium.Model;
using Compendium.Model.Filtering;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Compendium
{
    public class Controller : INotifyPropertyChanged
    {
        private IModel model;
        private String filepath;
        private String title;

        private bool _changed;

        public bool Changed { get => _changed; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public String[] Results => model.Results;

        private Controller(String filepath, IModel model)
        {
            this.filepath = filepath;
            this.model = model;
            _changed = false;
        }

        public Controller(String filepath, String title)
        {
            this.title = title;
            this.filepath = filepath;
            model = File.Exists(filepath) ? Controller.Open(filepath) : new ModelManager();
            File.Exists(filepath);
            _changed = false;
        }

        public static IModel Open(String filename)
        {
            IModel newModel = new ModelManager();
            newModel.Load(filename);
            return newModel;
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