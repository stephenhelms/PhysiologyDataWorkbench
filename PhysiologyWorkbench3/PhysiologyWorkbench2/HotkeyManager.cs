using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench
{
    [Serializable]
    public class HotkeyManager : Component
    {
        public event EventHandler HotkeyMappingsChanged;
        public event EventHandler ActionsChanged;

        private SortedList<Keys, string> _HotkeyMappings = new SortedList<Keys,string>();
        public IDictionary<Keys, string> HotkeyMappings
        {
            get { return _HotkeyMappings; }
        }

        [NonSerialized]
        private SortedList<string, System.Threading.ThreadStart> _Actions = new SortedList<string,System.Threading.ThreadStart>();
        public IDictionary<string, System.Threading.ThreadStart> Actions
        {
            get { return _Actions; }
        }

        public static string PersistenceFilePath
        {
            get
            {
                return Properties.Settings.Default.HotkeyManagerPersistenceFilePath;
            }
        }
        public static bool PersistenceFileExists
        {
            get
            {
                return File.Exists(PersistenceFilePath);
            }
        }

        public HotkeyManager()
        {
            
        }

        public virtual void SaveHotkeys()
        {
            FileStream fileStream = null;
            using(fileStream = File.Open(PersistenceFilePath, FileMode.OpenOrCreate)) {
                SaveHotkeys(fileStream);
            }
        }
        public virtual void SaveHotkeys(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(stream) {
                formatter.Serialize(stream, _HotkeyMappings);
            }
        }
        public virtual void RestoreSavedHotkeys()
        {
            if (!PersistenceFileExists) return;

            using(FileStream fileStream = File.OpenRead(PersistenceFilePath)) 
            {
                RestoreSavedHotkeys(fileStream);
            }
        }
        public virtual void RestoreSavedHotkeys(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                _HotkeyMappings = binaryFormatter.Deserialize(stream) as SortedList<Keys,string>;
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                _HotkeyMappings = new SortedList<Keys, string>();
            }
            finally
            {
                stream.Close();
            }
            if (HotkeyMappingsChanged != null) HotkeyMappingsChanged(this, EventArgs.Empty);
            if (ActionsChanged != null) ActionsChanged(this, EventArgs.Empty);
        }

        public virtual void RegisterAction(string name, System.Threading.ThreadStart action)
        {
            if (!_Actions.ContainsKey(name))
            {
                _Actions.Add(name, action);
                if (ActionsChanged != null) ActionsChanged(this, EventArgs.Empty);
            }
        }
        public virtual void DeregisterAction(string name)
        {
            if (_Actions.ContainsKey(name))
            {
                _Actions.Remove(name);
                if (ActionsChanged != null) ActionsChanged(this, EventArgs.Empty);
            }
        }
        public virtual void SetHotkey(Keys hotkey, string actionName)
        {
            if (_Actions.ContainsKey(actionName))
                if (!_HotkeyMappings.ContainsKey(hotkey))
                {
                    _HotkeyMappings.Add(hotkey, actionName);
                    if (HotkeyMappingsChanged != null) HotkeyMappingsChanged(this, EventArgs.Empty);
                }
                else MessageBox.Show("Hotkey " + hotkey.ToString() + " already in use.");
        }
        public virtual void RemoveHotkey(Keys hotkey)
        {
            if(_HotkeyMappings.ContainsKey(hotkey))
                _HotkeyMappings.Remove(hotkey);
        }
        public virtual void RemoveHotkey(string actionName)
        {
            if (_HotkeyMappings.ContainsValue(actionName))
                foreach (Keys key in _HotkeyMappings.Keys)
                    if (_HotkeyMappings[key] == actionName)
                        _HotkeyMappings.Remove(key);
        }

        public virtual void ProcessKeyDownEvent(KeyEventArgs e)
        {
            if (HotkeyMappings.ContainsKey(e.KeyCode | e.Modifiers))
                try
                {
                    Actions[HotkeyMappings[e.KeyCode | e.Modifiers]].BeginInvoke(null, null);
                    e.Handled = true;
                }
                catch (Exception x) { ; }
        }
    }

    public interface IHotkeyManagerUser
    {
        HotkeyManager HotkeyManager { get; }	
    }
}
