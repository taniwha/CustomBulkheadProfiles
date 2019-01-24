/*
	BulkheadProfileLoader.cs

	Customized tooltips and icons for bulkhead profiles.

	Copyright (C) 2018 Bill Currie <bill@taniwha.org>

	Author: Bill Currie <bill@taniwha.org>
	Date: 2018/10/30

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	See the GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to:

		Free Software Foundation, Inc.
		59 Temple Place - Suite 330
		Boston, MA  02111-1307, USA

*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using KSP.IO;

namespace BulkheadProfiles {

	public class BulkheadProfileDataLoader : LoadingSystem
	{
		public bool done;
		public BulkheadProfileConfigs configs;

		IEnumerator LoadBulkheadProfileConfigs ()
		{
			var dbase = GameDatabase.Instance;
			var node_list = dbase.GetConfigNodes ("BulkheadProfileDefinition");
			for (int i = 0; i < node_list.Length; i++) {
				var node = node_list[i];
				if (node.HasValue ("name")) {
					var bp = new BulkheadProfileData (node);
					configs.Add (bp);
				}
			}
			done = true;
			configs = null;
			yield return null;
		}

		public override bool IsReady ()
		{
			return done;
		}

		public override float ProgressFraction ()
		{
			return 0;
		}

		public override string ProgressTitle ()
		{
			return "Custom Bulkhead Profiles";
		}

		public override void StartLoad ()
		{
			done = false;
			//Debug.Log ("[BulkheadProfileDataLoader] StartLoad");
			StartCoroutine (LoadBulkheadProfileConfigs ());
		}
	}
}
