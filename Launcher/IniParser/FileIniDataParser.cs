// Decompiled with JetBrains decompiler
// Type: IniParser.FileIniDataParser
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Parser;
using System;
using System.IO;
using System.Text;

namespace IniParser
{
    public class FileIniDataParser : StreamIniDataParser
    {
        public FileIniDataParser()
        {
        }

        public FileIniDataParser(IniDataParser parser)
          : base(parser)
        {
            this.Parser = parser;
        }

        [Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
        public IniData LoadFile(string filePath)
        {
            return this.ReadFile(filePath);
        }

        [Obsolete("Please use ReadFile method instead of this one as is more semantically accurate")]
        public IniData LoadFile(string filePath, Encoding fileEncoding)
        {
            return this.ReadFile(filePath, fileEncoding);
        }

        public IniData ReadFile(string filePath)
        {
            return this.ReadFile(filePath, Encoding.ASCII);
        }

        public IniData ReadFile(string filePath, Encoding fileEncoding)
        {
            if (filePath == string.Empty)
                throw new ArgumentException("Bad filename.");
            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader((Stream)fileStream, fileEncoding))
                        return this.ReadData(reader);
                }
            }
            catch (IOException ex)
            {
                throw new ParsingException(string.Format("Could not parse file {0}", (object)filePath), (Exception)ex);
            }
        }

        [Obsolete("Please use WriteFile method instead of this one as is more semantically accurate")]
        public void SaveFile(string filePath, IniData parsedData)
        {
            this.WriteFile(filePath, parsedData, Encoding.UTF8);
        }

        public void WriteFile(string filePath, IniData parsedData, Encoding fileEncoding = null)
        {
            if (fileEncoding == null)
                fileEncoding = Encoding.UTF8;
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Bad filename.");
            if (parsedData == null)
                throw new ArgumentNullException(nameof(parsedData));
            using (FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter((Stream)fileStream, fileEncoding))
                    this.WriteData(writer, parsedData);
            }
        }
    }
}
