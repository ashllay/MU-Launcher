using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Model.Configuration;

namespace IniParser.Parser
{
	public class IniDataParser
	{
		public IniDataParser() : this(new IniParserConfiguration())
		{
		}

		public IniDataParser(IniParserConfiguration parserConfiguration)
		{
			bool flag = parserConfiguration == null;
			if (flag)
			{
				throw new ArgumentNullException("parserConfiguration");
			}
			this.Configuration = parserConfiguration;
			this._errorExceptions = new List<Exception>();
		}

		public virtual IniParserConfiguration Configuration { get; protected set; }

		public bool HasError
		{
			get
			{
				return this._errorExceptions.Count > 0;
			}
		}

		public ReadOnlyCollection<Exception> Errors
		{
			get
			{
				return this._errorExceptions.AsReadOnly();
			}
		}

		public IniData Parse(string iniDataString)
		{
			IniData iniData = this.Configuration.CaseInsensitive ? new IniDataCaseInsensitive() : new IniData();
			iniData.Configuration = this.Configuration.Clone();
			bool flag = string.IsNullOrEmpty(iniDataString);
			IniData result;
			if (flag)
			{
				result = iniData;
			}
			else
			{
				this._errorExceptions.Clear();
				this._currentCommentListTemp.Clear();
				this._currentSectionNameTemp = null;
				try
				{
					string[] array = iniDataString.Split(new string[]
					{
						"\n",
						"\r\n"
					}, StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i];
						bool flag2 = text.Trim() == string.Empty;
						if (!flag2)
						{
							try
							{
								this.ProcessLine(text, iniData);
							}
							catch (Exception ex)
							{
								ParsingException ex2 = new ParsingException(ex.Message, i + 1, text, ex);
								bool throwExceptionsOnError = this.Configuration.ThrowExceptionsOnError;
								if (throwExceptionsOnError)
								{
									throw ex2;
								}
								this._errorExceptions.Add(ex2);
							}
						}
					}
					bool flag3 = this._currentCommentListTemp.Count > 0;
					if (flag3)
					{
						bool flag4 = iniData.Sections.Count > 0;
						if (!flag4)
						{
							bool flag5 = iniData.Global.Count > 0;
							if (flag5)
							{
								iniData.Global.GetLast().Comments.AddRange(this._currentCommentListTemp);
							}
						}
						this._currentCommentListTemp.Clear();
					}
				}
				catch (Exception item)
				{
					this._errorExceptions.Add(item);
					bool throwExceptionsOnError2 = this.Configuration.ThrowExceptionsOnError;
					if (throwExceptionsOnError2)
					{
						throw;
					}
				}
				bool hasError = this.HasError;
				if (hasError)
				{
					result = null;
				}
				else
				{
					result = (IniData)iniData.Clone();
				}
			}
			return result;
		}

		protected virtual bool LineContainsAComment(string line)
		{
			return !string.IsNullOrEmpty(line) && this.Configuration.CommentRegex.Match(line).Success;
		}

		protected virtual bool LineMatchesASection(string line)
		{
			return !string.IsNullOrEmpty(line) && this.Configuration.SectionRegex.Match(line).Success;
		}

		protected virtual bool LineMatchesAKeyValuePair(string line)
		{
			return !string.IsNullOrEmpty(line) && line.Contains(this.Configuration.KeyValueAssigmentChar.ToString());
		}

		protected virtual string ExtractComment(string line)
		{
			string text = this.Configuration.CommentRegex.Match(line).Value.Trim();
			this._currentCommentListTemp.Add(text.Substring(1, text.Length - 1));
			return line.Replace(text, "").Trim();
		}

		protected virtual void ProcessLine(string currentLine, IniData currentIniData)
		{
			currentLine = currentLine.Trim();
			bool flag = this.LineContainsAComment(currentLine);
			if (flag)
			{
				currentLine = this.ExtractComment(currentLine);
			}
			bool flag2 = currentLine == string.Empty;
			if (!flag2)
			{
				bool flag3 = this.LineMatchesASection(currentLine);
				if (flag3)
				{
					this.ProcessSection(currentLine, currentIniData);
				}
				else
				{
					bool flag4 = this.LineMatchesAKeyValuePair(currentLine);
					if (flag4)
					{
						this.ProcessKeyValuePair(currentLine, currentIniData);
					}
					else
					{
						bool skipInvalidLines = this.Configuration.SkipInvalidLines;
						if (!skipInvalidLines)
						{
							throw new ParsingException("Unknown file format. Couldn't parse the line: '" + currentLine + "'.");
						}
					}
				}
			}
		}

		protected virtual void ProcessSection(string line, IniData currentIniData)
		{
			string text = this.Configuration.SectionRegex.Match(line).Value.Trim();
			text = text.Substring(1, text.Length - 2).Trim();
			bool flag = text == string.Empty;
			if (flag)
			{
				throw new ParsingException("Section name is empty");
			}
			this._currentSectionNameTemp = text;
			bool flag2 = currentIniData.Sections.ContainsSection(text);
			if (flag2)
			{
				bool allowDuplicateSections = this.Configuration.AllowDuplicateSections;
				if (!allowDuplicateSections)
				{
					throw new ParsingException(string.Format("Duplicate section with name '{0}' on line '{1}'", text, line));
				}
			}
			else
			{
				currentIniData.Sections.AddSection(text);
				this._currentCommentListTemp.Clear();
			}
		}

		protected virtual void ProcessKeyValuePair(string line, IniData currentIniData)
		{
			string text = this.ExtractKey(line);
			bool flag = string.IsNullOrEmpty(text) && this.Configuration.SkipInvalidLines;
			if (!flag)
			{
				string value = this.ExtractValue(line);
				bool flag2 = string.IsNullOrEmpty(this._currentSectionNameTemp);
				if (flag2)
				{
					bool flag3 = !this.Configuration.AllowKeysWithoutSection;
					if (flag3)
					{
						throw new ParsingException("key value pairs must be enclosed in a section");
					}
					this.AddKeyToKeyValueCollection(text, value, currentIniData.Global, "global");
				}
				else
				{
					SectionData sectionData = currentIniData.Sections.GetSectionData(this._currentSectionNameTemp);
					this.AddKeyToKeyValueCollection(text, value, sectionData.Keys, this._currentSectionNameTemp);
				}
			}
		}

		protected virtual string ExtractKey(string s)
		{
			int length = s.IndexOf(this.Configuration.KeyValueAssigmentChar, 0);
			return s.Substring(0, length).Trim();
		}

		protected virtual string ExtractValue(string s)
		{
			int num = s.IndexOf(this.Configuration.KeyValueAssigmentChar, 0);
			return s.Substring(num + 1, s.Length - num - 1).Trim();
		}

		protected virtual void HandleDuplicatedKeyInCollection(string key, string value, KeyDataCollection keyDataCollection, string sectionName)
		{
			bool flag = !this.Configuration.AllowDuplicateKeys;
			if (flag)
			{
				throw new ParsingException(string.Format("Duplicated key '{0}' found in section '{1}", key, sectionName));
			}
			bool overrideDuplicateKeys = this.Configuration.OverrideDuplicateKeys;
			if (overrideDuplicateKeys)
			{
				keyDataCollection[key] = value;
			}
		}

		private void AddKeyToKeyValueCollection(string key, string value, KeyDataCollection keyDataCollection, string sectionName)
		{
			bool flag = keyDataCollection.ContainsKey(key);
			if (flag)
			{
				this.HandleDuplicatedKeyInCollection(key, value, keyDataCollection, sectionName);
			}
			else
			{
				keyDataCollection.AddKey(key, value);
			}
			keyDataCollection.GetKeyData(key).Comments = this._currentCommentListTemp;
			this._currentCommentListTemp.Clear();
		}

		private List<Exception> _errorExceptions;

		private readonly List<string> _currentCommentListTemp = new List<string>();

		private string _currentSectionNameTemp;
	}
}
