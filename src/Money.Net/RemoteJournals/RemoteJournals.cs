// 
//  Author:
//    angelstone 
// 
//  Copyright (c) 2010, angelstone
// 
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//     * Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;

using Money.Net.DB;

namespace Money.Net.RemoteJournal
{
	public static class RemoteJournals
	{
		private static readonly DateTime TIME_FUNC_BEGIN = new DateTime (1970, 1, 1, 0, 0, 0);
		#if TEST
		public const string READ_ALL_ENTRY_URL = "http://localhost:8080/entry/list";
		public const string BATCH_DELETE_ENTRY_URL = "http://localhost:8080/entry/batchDelete";
		#else
		public const string READ_ALL_ENTRY_URL = "http://accountdiary.appspot.com/entry/list";
		public const string BATCH_DELETE_ENTRY_URL = "http://accountdiary.appspot.com/entry/batchDelete";
		#endif

		public static void Sync ()
		{
			string entries_txt = DownloadRemoteJournals ();
			
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(Entry[]));
			
			Entry[] o = serializer.ReadObject (new System.IO.MemoryStream (Encoding.UTF8.GetBytes (entries_txt))) as Entry[];
			
			ImportEntries (o);
			
			DeleteRemoteJournals (o);
		}

		private static string DownloadRemoteJournals ()
		{
			string response = DoWebRequest (READ_ALL_ENTRY_URL);
			response = response.Replace ("\\u", "%u");
			
			return System.Web.HttpUtility.UrlDecode (response, Encoding.UTF8);
		}

		private static void ImportEntries (Entry[] entries)
		{
			try {
				Program.MoneyNetDS.AcceptChanges ();
				
				List<MoneyNetDS.RiChang_JiaoYiRow> newRows = new List<MoneyNetDS.RiChang_JiaoYiRow> ();
				StringBuilder sb = new StringBuilder ();
				
				foreach (Entry entry in entries) {
					DateTime payDate = TIME_FUNC_BEGIN + ToTimeSpan (entry.PayDate);
					
					if (payDate.Year == Program.GetDefaultYear ()) {
						if (sb.Length > 0)
							sb.Append (",");
						sb.Append ("'").Append (entry.Uid).Append ("'");
						
						if (entry.Deleted == null || string.Compare ("0", entry.Deleted) == 0) {
							MoneyNetDS.RiChang_JiaoYiRow newRow = Program.MoneyNetDS._RiChang_JiaoYi.NewRiChang_JiaoYiRow ();
							
							newRow.JiaoYi_FangXiang = entry.Type == 0;
							newRow.JiaoYi_FenLeiRow = FindFenLei (entry.Category);
							newRow.JiaoYi_FangShiRow = FindFangShi (entry.PayMethod);
							newRow.JiaoYi_Time = payDate;
							newRow.Jin_E = new decimal (entry.Amount);
							newRow.MiaoShu = entry.Description == null ? "" : entry.Description;
							newRow.MingCheng = entry.Name;
							newRow.Uid = entry.Uid;
							
							newRows.Add (newRow);
						}
					}
					
				}
				
				if (sb.Length > 0) {
					System.Data.DataRow[] rows = Program.MoneyNetDS._RiChang_JiaoYi.Select ("Uid in (" + sb.ToString () + ")");
					
					foreach (MoneyNetDS.RiChang_JiaoYiRow row in rows)
						row.Delete ();
				}
				
				foreach (MoneyNetDS.RiChang_JiaoYiRow row in newRows)
					Program.MoneyNetDS._RiChang_JiaoYi.Rows.Add (row);
				
				Program.MoneyNetDS.AcceptChanges ();
				
			} catch {
				Program.MoneyNetDS.RejectChanges ();
				throw;
			}
		}

		private static void DeleteRemoteJournals (Entry[] entries)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(string[]));
			
			List<string> results = new List<string> ();
			
			foreach (Entry e in entries) {
				results.Add (e.Uid);
			}
			
			System.IO.MemoryStream ms = new System.IO.MemoryStream ();
			
			serializer.WriteObject (ms, results.ToArray ());
			
			string data = Encoding.UTF8.GetString (ms.ToArray ());
			
			DoWebRequest (BATCH_DELETE_ENTRY_URL, "uids", data);
		}

		private static string DoWebRequest (string url, params string[] data)
		{
			WebClient wc = new WebClient ();
			
			if (data == null || data.Length == 0)
				return wc.DownloadString (url);
			
			System.Collections.Specialized.NameValueCollection values = new System.Collections.Specialized.NameValueCollection ();
			
			for (int i = 0; i < data.Length; i += 2) {
				values[data[i]] = data[i + 1];
			}
			
			return Encoding.UTF8.GetString (wc.UploadValues (url, values));
		}

		private static MoneyNetDS.JiaoYi_FangShiRow FindFangShi (string name)
		{
			foreach (MoneyNetDS.JiaoYi_FangShiRow row in Program.MoneyNetDS._JiaoYi_FangShi.Rows) {
				if (row.Name.Equals (name)) {
					return row;
				}
			}
			
			MoneyNetDS.JiaoYi_FangShiRow row1 = Program.MoneyNetDS._JiaoYi_FangShi.NewJiaoYi_FangShiRow ();
			
			row1.Name = name;
			
			Program.MoneyNetDS._JiaoYi_FangShi.Rows.Add (row1);
			
			return row1;
		}

		private static MoneyNetDS.JiaoYi_FenLeiRow FindFenLei (string name)
		{
			foreach (MoneyNetDS.JiaoYi_FenLeiRow row in Program.MoneyNetDS._JiaoYi_FenLei.Rows) {
				if (row.Name.Equals (name)) {
					return row;
				}
			}
			
			MoneyNetDS.JiaoYi_FenLeiRow row1 = Program.MoneyNetDS._JiaoYi_FenLei.NewJiaoYi_FenLeiRow ();
			
			row1.Name = name;
			
			Program.MoneyNetDS._JiaoYi_FenLei.Rows.Add (row1);
			
			return row1;
		}

		private static TimeSpan ToTimeSpan (long mills)
		{
			int mm = Convert.ToInt32 (mills % 1000);
			int seconds = Convert.ToInt32 ((mills / 1000) % 60);
			int minutes = Convert.ToInt32 ((mills / 1000 / 60) % 60);
			int hours = Convert.ToInt32 ((mills / 1000 / 60 / 60) % 24);
			int days = Convert.ToInt32 (mills / 1000 / 60 / 60 / 24);
			return new TimeSpan (days, hours, minutes, seconds, mm);
		}
		
	}
}

