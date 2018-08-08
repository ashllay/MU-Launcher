using System;
using IniParser.Model.Configuration;
using IniParser.Model.Formatting;

namespace IniParser.Model
{
	public class IniData : ICloneable
	{
		public IniData() : this(new SectionDataCollection())
		{
		}

		public IniData(SectionDataCollection sdc)
		{
			this._sections = (SectionDataCollection)sdc.Clone();
			this.Global = new KeyDataCollection();
			this.SectionKeySeparator = '.';
		}

		public IniData(IniData ori) : this(ori.Sections)
		{
			this.Global = (KeyDataCollection)ori.Global.Clone();
			this.Configuration = ori.Configuration.Clone();
		}

		public IniParserConfiguration Configuration
		{
			get
			{
				bool flag = this._configuration == null;
				if (flag)
				{
					this._configuration = new IniParserConfiguration();
				}
				return this._configuration;
			}
			set
			{
				this._configuration = value.Clone();
			}
		}

		public KeyDataCollection Global { get; protected set; }

		public KeyDataCollection this[string sectionName]
		{
			get
			{
				bool flag = !this._sections.ContainsSection(sectionName);
				if (flag)
				{
					bool allowCreateSectionsOnFly = this.Configuration.AllowCreateSectionsOnFly;
					if (!allowCreateSectionsOnFly)
					{
						return null;
					}
					this._sections.AddSection(sectionName);
				}
				return this._sections[sectionName];
			}
		}

		public SectionDataCollection Sections
		{
			get
			{
				return this._sections;
			}
			set
			{
				this._sections = value;
			}
		}

		public char SectionKeySeparator { get; set; }

		public override string ToString()
		{
			return this.ToString(new DefaultIniDataFormatter(this.Configuration));
		}

		public virtual string ToString(IIniDataFormatter formatter)
		{
			return formatter.IniDataToString(this);
		}

		public object Clone()
		{
			return new IniData(this);
		}

		public void ClearAllComments()
		{
			this.Global.ClearComments();
			foreach (SectionData sectionData in this.Sections)
			{
				sectionData.ClearComments();
			}
		}

		public void Merge(IniData toMergeIniData)
		{
			bool flag = toMergeIniData == null;
			if (!flag)
			{
				this.Global.Merge(toMergeIniData.Global);
				this.Sections.Merge(toMergeIniData.Sections);
			}
		}

		public bool TryGetKey(string key, out string value)
		{
			value = string.Empty;
			bool flag = string.IsNullOrEmpty(key);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string[] array = key.Split(new char[]
				{
					this.SectionKeySeparator
				});
				int num = array.Length - 1;
				bool flag2 = num > 1;
				if (flag2)
				{
					throw new ArgumentException("key contains multiple separators", "key");
				}
				bool flag3 = num == 0;
				if (flag3)
				{
					bool flag4 = !this.Global.ContainsKey(key);
					if (flag4)
					{
						result = false;
					}
					else
					{
						value = this.Global[key];
						result = true;
					}
				}
				else
				{
					string text = array[0];
					key = array[1];
					bool flag5 = !this._sections.ContainsSection(text);
					if (flag5)
					{
						result = false;
					}
					else
					{
						KeyDataCollection keyDataCollection = this._sections[text];
						bool flag6 = !keyDataCollection.ContainsKey(key);
						if (flag6)
						{
							result = false;
						}
						else
						{
							value = keyDataCollection[key];
							result = true;
						}
					}
				}
			}
			return result;
		}

		public string GetKey(string key)
		{
			string text;
			return this.TryGetKey(key, out text) ? text : null;
		}

		private void MergeSection(SectionData otherSection)
		{
			bool flag = !this.Sections.ContainsSection(otherSection.SectionName);
			if (flag)
			{
				this.Sections.AddSection(otherSection.SectionName);
			}
			this.Sections.GetSectionData(otherSection.SectionName).Merge(otherSection);
		}

		private void MergeGlobal(KeyDataCollection globals)
		{
			foreach (KeyData keyData in globals)
			{
				this.Global[keyData.KeyName] = keyData.Value;
			}
		}

		private SectionDataCollection _sections;

		private IniParserConfiguration _configuration;
	}
}
