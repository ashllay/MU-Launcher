// Decompiled with JetBrains decompiler
// Type: IniParser.Model.KeyDataCollection
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System;
using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
    public class KeyDataCollection : ICloneable, IEnumerable<KeyData>, IEnumerable
    {
        private IEqualityComparer<string> _searchComparer;
        private readonly Dictionary<string, KeyData> _keyData;

        public KeyDataCollection()
          : this((IEqualityComparer<string>)EqualityComparer<string>.Default)
        {
        }

        public KeyDataCollection(IEqualityComparer<string> searchComparer)
        {
            this._searchComparer = searchComparer;
            this._keyData = new Dictionary<string, KeyData>(this._searchComparer);
        }

        public KeyDataCollection(KeyDataCollection ori, IEqualityComparer<string> searchComparer)
          : this(searchComparer)
        {
            foreach (KeyData keyData in ori)
            {
                if (this._keyData.ContainsKey(keyData.KeyName))
                    this._keyData[keyData.KeyName] = (KeyData)keyData.Clone();
                else
                    this._keyData.Add(keyData.KeyName, (KeyData)keyData.Clone());
            }
        }

        public string this[string keyName]
        {
            get
            {
                if (this._keyData.ContainsKey(keyName))
                    return this._keyData[keyName].Value;
                return (string)null;
            }
            set
            {
                if (!this._keyData.ContainsKey(keyName))
                    this.AddKey(keyName);
                this._keyData[keyName].Value = value;
            }
        }

        public int Count
        {
            get
            {
                return this._keyData.Count;
            }
        }

        public bool AddKey(string keyName)
        {
            if (this._keyData.ContainsKey(keyName))
                return false;
            this._keyData.Add(keyName, new KeyData(keyName));
            return true;
        }

        [Obsolete("Pottentially buggy method! Use AddKey(KeyData keyData) instead (See comments in code for an explanation of the bug)")]
        public bool AddKey(string keyName, KeyData keyData)
        {
            if (!this.AddKey(keyName))
                return false;
            this._keyData[keyName] = keyData;
            return true;
        }

        public bool AddKey(KeyData keyData)
        {
            if (!this.AddKey(keyData.KeyName))
                return false;
            this._keyData[keyData.KeyName] = keyData;
            return true;
        }

        public bool AddKey(string keyName, string keyValue)
        {
            if (!this.AddKey(keyName))
                return false;
            this._keyData[keyName].Value = keyValue;
            return true;
        }

        public void ClearComments()
        {
            foreach (KeyData keyData in this)
                keyData.Comments.Clear();
        }

        public bool ContainsKey(string keyName)
        {
            return this._keyData.ContainsKey(keyName);
        }

        public KeyData GetKeyData(string keyName)
        {
            if (this._keyData.ContainsKey(keyName))
                return this._keyData[keyName];
            return (KeyData)null;
        }

        public void Merge(KeyDataCollection keyDataToMerge)
        {
            foreach (KeyData keyData in keyDataToMerge)
            {
                this.AddKey(keyData.KeyName);
                this.GetKeyData(keyData.KeyName).Comments.AddRange((IEnumerable<string>)keyData.Comments);
                this[keyData.KeyName] = keyData.Value;
            }
        }

        public void RemoveAllKeys()
        {
            this._keyData.Clear();
        }

        public bool RemoveKey(string keyName)
        {
            return this._keyData.Remove(keyName);
        }

        public void SetKeyData(KeyData data)
        {
            if (data == null)
                return;
            if (this._keyData.ContainsKey(data.KeyName))
                this.RemoveKey(data.KeyName);
            this.AddKey(data);
        }

        public IEnumerator<KeyData> GetEnumerator()
        {
            foreach (string key1 in this._keyData.Keys)
            {
                string key = key1;
                yield return this._keyData[key];
                key = (string)null;
            }
            Dictionary<string, KeyData>.KeyCollection.Enumerator enumerator = new Dictionary<string, KeyData>.KeyCollection.Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _keyData.GetEnumerator();
        }

        public object Clone()
        {
            return (object)new KeyDataCollection(this, this._searchComparer);
        }

        internal KeyData GetLast()
        {
            KeyData keyData = (KeyData)null;
            if (this._keyData.Keys.Count <= 0)
                return keyData;
            foreach (string key in this._keyData.Keys)
                keyData = this._keyData[key];
            return keyData;
        }
    }
}
