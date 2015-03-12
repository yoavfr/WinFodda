using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fodda
{
    class TransferredItemsStore
    {
        private HashSet<String> Items { get; set; }
        private String m_storeName = null;
        private string FileStoreName 
        { 
            get
            {
                if (m_storeName == null)
                {
                    m_storeName = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fodda"), "Tansferred.txt");
                }
                return m_storeName;
            }
        }
        private int maxFiles = 2000;

        public TransferredItemsStore()
        {
            Items = new HashSet<string>();
        }

        internal void Load()
        {

            if (File.Exists(FileStoreName))
            {
                String line;
                using (StreamReader reader = new StreamReader(FileStoreName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        Items.Add(line);
                    }
                }
            }
        }

        internal void Store()
        {
            List<string> lines = Items.OrderBy(name => name).ToList();
            string directoryName = new FileInfo(FileStoreName).DirectoryName;
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            using (StreamWriter writer = new StreamWriter(FileStoreName, true))
            {
                for (int i=Math.Max(lines.Count-maxFiles, 0); i< lines.Count; i++)
                {
                    writer.WriteLine(lines[i]);
                }
            }
        }

        internal void Add(DateTime dateTime, string fileName)
        {
            Items.Add(ToFullName(dateTime, fileName));
        }

        internal bool Contains(DateTime dateTime, string fileName)
        {
            return Items.Contains(ToFullName(dateTime, fileName));
        }

        private static String ToFullName(DateTime dateTime, string fileName)
        {
            return String.Format("{0} {1}", dateTime.Ticks, fileName);
        }
    }
}
