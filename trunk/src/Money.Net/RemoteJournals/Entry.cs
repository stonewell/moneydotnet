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
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Money.Net.RemoteJournal
{
	[DataContract]
	public class EntryList : List<Entry> {
	}
	
	[DataContract]
	public class Entry
	{
		#region Properties
		[DataMember(Name="type")]
		public int Type { get; set; }
		[DataMember(Name="name")]
		public string Name { get; set; }
		[DataMember(Name="category")]
		public string Category { get; set; }
		[DataMember(Name="pay_method")]
		public string PayMethod { get; set; }
		[DataMember(Name="pay_date")]
		public long PayDate { get; set; }
		[DataMember(Name="create_date")]
		public long CreateDate { get; set; }
		[DataMember(Name="amount")]
		public double Amount { get; set; }
		[DataMember(Name="description")]
		public string Description { get; set; }
		[DataMember(Name="uid")]
		public string Uid { get; set; }
		[DataMember(Name="deleted")]
		public string Deleted { get; set; }
		#endregion

		public Entry ()
		{
		}

		public static void Main(string[] args) {
			System.IO.FileStream fs = new System.IO.FileStream("/home/angelstone/1.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);
			 
			var serializer = new DataContractJsonSerializer(typeof(Entry[]));
			
			Entry[] o = serializer.ReadObject(fs) as Entry[];
			
			foreach(Entry e in o) {
			  System.Console.WriteLine(e.Name);
			}
			
			RemoteJournals.Sync();
		}
	}
}

