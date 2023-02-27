using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLauncher
{
	public class Directories
	{		
		public static string Appdata { get{ return $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}"; } }

        public static string LocalAppdata { get { return $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}"; } }

        public static string Documents { get { return $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}"; } }

        public static string tNPLauncher { get { return Documents + "\\tNPLauncher"; } }

        public static string DefaultInstallLocation { get { return tNPLauncher + "\\Game\\"; } }

		public static string ConfigLocation { get { return tNPLauncher + "\\Config.json"; } }
    }
}
