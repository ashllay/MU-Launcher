// Decompiled with JetBrains decompiler
// Type: IniParser.Model.SectionData
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22173523-8172-4BD6-ADA2-E262638E8664
// Assembly location: D:\dev\launcher\Client\Launcher.exe

using System;
using System.Collections.Generic;

namespace IniParser.Model
{
    public class SectionData : ICloneable
    {
        private List<string> _trailingComments = new List<string>();
        private IEqualityComparer<string> _searchComparer;
        private List<string> _leadingComments;
        private KeyDataCollection _keyDataCollection;
        private string _sectionName;

        public SectionData(string sectionName)
          : this(sectionName, (IEqualityComparer<string>)EqualityComparer<string>.Default)
        {
        }

        public SectionData(string sectionName, IEqualityComparer<string> searchComparer)
        {
            this._searchComparer = searchComparer;
            if (string.IsNullOrEmpty(sectionName))
                throw new ArgumentException("section name can not be empty");
            this._leadingComments = new List<string>();
            this._keyDataCollection = new KeyDataCollection(this._searchComparer);
            this.SectionName = sectionName;
        }

        public SectionData(SectionData ori, IEqualityComparer<string> searchComparer = null)
        {
            this.SectionName = ori.SectionName;
            this._searchComparer = searchComparer;
            this._leadingComments = new List<string>((IEnumerable<string>)ori._leadingComments);
            this._keyDataCollection = new KeyDataCollection(ori._keyDataCollection, searchComparer ?? ori._searchComparer);
        }

        public void ClearComments()
        {
            this.Keys.ClearComments();
        }

        public void ClearKeyData()
        {
            this.Keys.RemoveAllKeys();
        }

        public void Merge(SectionData toMergeSection)
        {
        }

        public string SectionName
        {
            get
            {
                return this._sectionName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                this._sectionName = value;
            }
        }

        [Obsolete("Do not use this property, use property Comments instead")]
        public List<string> LeadingComments
        {
            get
            {
                return this._leadingComments;
            }
            internal set
            {
                this._leadingComments = new List<string>((IEnumerable<string>)value);
            }
        }

        public List<string> Comments
        {
            get
            {
                return this._leadingComments;
            }
        }

        [Obsolete("Do not use this property, use property Comments instead")]
        public List<string> TrailingComments
        {
            get
            {
                return this._trailingComments;
            }
            internal set
            {
                this._trailingComments = new List<string>((IEnumerable<string>)value);
            }
        }

        public KeyDataCollection Keys
        {
            get
            {
                return this._keyDataCollection;
            }
            set
            {
                this._keyDataCollection = value;
            }
        }

        public object Clone()
        {
            return (object)new SectionData(this, (IEqualityComparer<string>)null);
        }
    }
}
