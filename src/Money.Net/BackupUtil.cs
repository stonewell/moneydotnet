using System;
using System.Collections.Generic;
using System.Text;

using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace Money.Net
{
    public class BackupUtil
    {
        public const string BACKUP_DAY_FILE_PREFIX = "Money.Net.Backup";
        public const string BACKUP_CONFIG_DAY_FILE_PREFIX = "Money.Net.Config.Backup";
        public const int DAY_BACKUP_COUNT = 7;

        public static void DoBackupData(string prefix, string filename)
        {
            if (!File.Exists(filename))
                return;

            string backupFileName =
                string.Format("{0}-{1}.zip", prefix, DateTime.Now.ToString("yyyyMMdd"));

            backupFileName = 
                Path.Combine(Path.GetDirectoryName(filename), backupFileName);

            ZipFile s = null;

            if (File.Exists(backupFileName))
            {
                s = new ZipFile(backupFileName);
            }
            else
            {
                s = ZipFile.Create(backupFileName);
            }

            byte[] buffer = new byte[4096];

            // Using GetFileName makes the result compatible with XP
            // as the resulting path is not absolute.
            string entryName = 
                string.Format("{0}-{1}", Path.GetFileName(filename),
                DateTime.Now.ToString("HHmmss"));

            s.UseZip64 = UseZip64.Off;
            s.BeginUpdate();
            s.Add(filename, entryName);
            s.CommitUpdate();

            // Close is important to wrap things up and unlock the file.
            s.Close();

            DoRemoveOutofDateBackup(prefix, Path.GetDirectoryName(filename), backupFileName);
        }

        private static void DoRemoveOutofDateBackup(string prefix, string dirname, string updateFileName)
        {
            string search_pattern = 
                string.Format("{0}-*.zip", prefix);

            string[] files = 
                Directory.GetFiles(dirname, search_pattern);

            if (files.Length > DAY_BACKUP_COUNT)
            {
                SortedList<string, string> list = new SortedList<string, string>();

                foreach (string file in files)
                {
                    list.Add(file, file);
                }

                IEnumerator<KeyValuePair<string, string>> it = list.GetEnumerator();

                for (int i = 0; i < files.Length - DAY_BACKUP_COUNT && it.MoveNext(); i++)
                {
                    string file = it.Current.Key;

                    if (!file.Equals(updateFileName))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}
