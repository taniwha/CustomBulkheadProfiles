/*
	BulkheadProfileConfigs.cs

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

	[KSPAddon(KSPAddon.Startup.Instantly, false)]
	public class BulkheadProfileConfigs: MonoBehaviour
	{
		public static Dictionary<string, BulkheadProfileData> BulkheadProfiles;

		void Awake ()
		{
			BulkheadProfiles = new Dictionary <string, BulkheadProfileData> ();
			
			var loaders = LoadingScreen.Instance.loaders;
			if (loaders != null) {
				for (int i = 0; i < loaders.Count; i++) {
					if (loaders[i] is BulkheadProfileDataLoader) {
						(loaders[i] as BulkheadProfileDataLoader).done = false;
						break;
					}
					if (loaders[i] is PartLoader) {
						var go = new GameObject ();
						var l = go.AddComponent<BulkheadProfileDataLoader> ();
						l.configs = this;
						loaders.Insert (i, l);
						break;
					}
				}
			}
		}

		public void Add (BulkheadProfileData bp)
		{
			//Debug.Log($"[BulkheadProfileConfigs] Add {bp.name}, {KSPUtil.PrintModuleName (bp.name)}");
			BulkheadProfiles[KSPUtil.PrintModuleName (bp.name)] = bp;
		}
	}
}
