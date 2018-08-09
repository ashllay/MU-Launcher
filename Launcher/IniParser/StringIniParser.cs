// Decompiled with JetBrains decompiler
// Type: IniParser.StringIniParser
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using IniParser.Model;
using IniParser.Parser;
using System;

namespace IniParser
{
    [Obsolete("Use class IniDataParser instead. See remarks comments in this class.")]
    public class StringIniParser
    {
        public IniDataParser Parser { get; protected set; }

        public StringIniParser()
          : this(new IniDataParser())
        {
        }

        public StringIniParser(IniDataParser parser)
        {
            this.Parser = parser;
        }

        public IniData ParseString(string dataStr)
        {
            return this.Parser.Parse(dataStr);
        }

        public string WriteString(IniData iniData)
        {
            return iniData.ToString();
        }
    }
}
