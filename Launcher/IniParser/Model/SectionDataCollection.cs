// Decompiled with JetBrains decompiler
// Type: IniParser.Model.SectionDataCollection
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22173523-8172-4BD6-ADA2-E262638E8664
// Assembly location: D:\dev\launcher\Client\Launcher.exe

using System;
using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
    public class SectionDataCollection : ICloneable, IEnumerable<SectionData>, IEnumerable
    {
        private IEqualityComparer<string> _searchComparer;
        private readonly Dictionary<string, SectionData> _sectionData;

        public SectionDataCollection()
          : this((IEqualityComparer<string>)EqualityComparer<string>.Default)
        {
        }

        public SectionDataCollection(IEqualityComparer<string> searchComparer)
        {
            this._searchComparer = searchComparer;
            this._sectionData = new Dictionary<string, SectionData>(this._searchComparer);
        }

        public SectionDataCollection(SectionDataCollection ori, IEqualityComparer<string> searchComparer)
        {
            this._searchComparer = searchComparer ?? (IEqualityComparer<string>)EqualityComparer<string>.Default;
            this._sectionData = new Dictionary<string, SectionData>(this._searchComparer);
            foreach (SectionData sectionData in ori)
                this._sectionData.Add(sectionData.SectionName, (SectionData)sectionData.Clone());
        }

        public int Count
        {
            get
            {
                return this._sectionData.Count;
            }
        }

        public KeyDataCollection this[string sectionName]
        {
            get
            {
                if (this._sectionData.ContainsKey(sectionName))
                    return this._sectionData[sectionName].Keys;
                return (KeyDataCollection)null;
            }
        }

        public bool AddSection(string keyName)
        {
            if (this.ContainsSection(keyName))
                return false;
            this._sectionData.Add(keyName, new SectionData(keyName, this._searchComparer));
            return true;
        }

        public void Add(SectionData data)
        {
            if (this.ContainsSection(data.SectionName))
                this.SetSectionData(data.SectionName, new SectionData(data, this._searchComparer));
            else
                this._sectionData.Add(data.SectionName, new SectionData(data, this._searchComparer));
        }

        public void Clear()
        {
            this._sectionData.Clear();
        }

        public bool ContainsSection(string keyName)
        {
            return this._sectionData.ContainsKey(keyName);
        }

        public SectionData GetSectionData(string sectionName)
        {
            if (this._sectionData.ContainsKey(sectionName))
                return this._sectionData[sectionName];
            return (SectionData)null;
        }

        public void Merge(SectionDataCollection sectionsToMerge)
        {
            foreach (SectionData sectionData in sectionsToMerge)
            {
                if (this.GetSectionData(sectionData.SectionName) == null)
                    this.AddSection(sectionData.SectionName);
                this[sectionData.SectionName].Merge(sectionData.Keys);
            }
        }

        public void SetSectionData(string sectionName, SectionData data)
        {
            if (data == null)
                return;
            this._sectionData[sectionName] = data;
        }

        public bool RemoveSection(string keyName)
        {
            return this._sectionData.Remove(keyName);
        }

        public IEnumerator<SectionData> GetEnumerator()
        {
            foreach (string key in this._sectionData.Keys)
            {
                string sectionName = key;
                yield return this._sectionData[sectionName];
                sectionName = (string)null;
            }
            Dictionary<string, SectionData>.KeyCollection.Enumerator enumerator = new Dictionary<string, SectionData>.KeyCollection.Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        public object Clone()
        {
            return (object)new SectionDataCollection(this, this._searchComparer);
        }
    }
}
