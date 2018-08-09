// Decompiled with JetBrains decompiler
// Type: IniParser.Exceptions.ParsingException
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System;
using System.Reflection;

namespace IniParser.Exceptions
{
    public class ParsingException : Exception
    {
        public Version LibVersion { get; private set; }

        public int LineNumber { get; private set; }

        public string LineValue { get; private set; }

        public ParsingException(string msg)
          : this(msg, 0, string.Empty, (Exception)null)
        {
        }

        public ParsingException(string msg, Exception innerException)
          : this(msg, 0, string.Empty, innerException)
        {
        }

        public ParsingException(string msg, int lineNumber, string lineValue)
          : this(msg, lineNumber, lineValue, (Exception)null)
        {
        }

        public ParsingException(string msg, int lineNumber, string lineValue, Exception innerException)
          : base(string.Format("{0} while parsing line number {1} with value '{2}' - IniParser version: {3}", (object)msg, (object)lineNumber, (object)lineValue, (object)Assembly.GetExecutingAssembly().GetName().Version), innerException)
        {
            this.LibVersion = Assembly.GetExecutingAssembly().GetName().Version;
            this.LineNumber = lineNumber;
            this.LineValue = lineValue;
        }
    }
}
