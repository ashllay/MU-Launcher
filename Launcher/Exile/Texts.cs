// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Texts
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System.Collections.Generic;

namespace Launcher.Exile
{
    internal class Texts
    {
        private static Dictionary<string, string> Text = new Dictionary<string, string>()
    {
      {
        "UNKNOWNERROR",
        "Cannot connect to server: \n{0}"
      },
      {
        "MISSINGBINARY",
        "This file is corrupt or missing {0}."
      },
      {
        "CANNOTSTART",
        "Unable to start Main.exe, please run Lancher as Administrator."
      },
      {
        "NONETWORK",
        "The update server is not responding or is not running right now."
      },
      {
        "CONNECTING",
        "Connecting to server."
      },
      {
        "LISTDOWNLOAD",
        "Analyzing patch info.."
      },
      {
        "CHECKFILE",
        "Initializing.."
      },
      {
        "DOWNLOADFILE",
        "Downloading: {0}"
      },
      {
        "COMPLETEPROGRESS",
        "Updated: {0}%"
      },
      {
        "CURRENTPROGRESS",
        "Downloading: {0}%  |  {1} kb/s"
      },
      {
        "CHECKCOMPLETE",
        "Ready to start."
      },
      {
        "DOWNLOADCOMPLETE",
        "Ready to start."
      },
      {
        "DOWNLOADSPEED",
        "{0} kb/s"
      }
    };

        public static string GetText(string Key, params object[] Arguments)
        {
            foreach (KeyValuePair<string, string> keyValuePair in Texts.Text)
            {
                if (keyValuePair.Key == Key)
                    return string.Format(keyValuePair.Value, Arguments);
            }
            return (string)null;
        }
    }
}
