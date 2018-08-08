using System;

namespace IniParser.Model
{
	public class IniDataCaseInsensitive : IniData
	{
		public IniDataCaseInsensitive() : base(new SectionDataCollection(StringComparer.OrdinalIgnoreCase))
		{
			base.Global = new KeyDataCollection(StringComparer.OrdinalIgnoreCase);
		}

		public IniDataCaseInsensitive(SectionDataCollection sdc) : base(new SectionDataCollection(sdc, StringComparer.OrdinalIgnoreCase))
		{
			base.Global = new KeyDataCollection(StringComparer.OrdinalIgnoreCase);
		}

		public IniDataCaseInsensitive(IniData ori) : this(new SectionDataCollection(ori.Sections, StringComparer.OrdinalIgnoreCase))
		{
			base.Global = (KeyDataCollection)ori.Global.Clone();
			base.Configuration = ori.Configuration.Clone();
		}
	}
}
