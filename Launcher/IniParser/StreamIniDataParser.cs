// Decompiled with JetBrains decompiler
// Type: IniParser.StreamIniDataParser
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using IniParser.Model;
using IniParser.Model.Formatting;
using IniParser.Parser;
using System;
using System.IO;

namespace IniParser
{
    public class StreamIniDataParser
    {
        public IniDataParser Parser { get; protected set; }

        public StreamIniDataParser()
          : this(new IniDataParser())
        {
        }

        public StreamIniDataParser(IniDataParser parser)
        {
            this.Parser = parser;
        }

        public IniData ReadData(StreamReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            return this.Parser.Parse(reader.ReadToEnd());
        }

        public void WriteData(StreamWriter writer, IniData iniData)
        {
            if (iniData == null)
                throw new ArgumentNullException(nameof(iniData));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            writer.Write(iniData.ToString());
        }

        public void WriteData(StreamWriter writer, IniData iniData, IIniDataFormatter formatter)
        {
            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));
            if (iniData == null)
                throw new ArgumentNullException(nameof(iniData));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            writer.Write(iniData.ToString(formatter));
        }
    }
}
