/*
	BulkheadProfiles.cs

	Optimal circularization burn periapsis from hyperbolic trajectory.

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

using KSP.UI.Screens;

namespace BulkheadProfiles {

	[KSPAddon (KSPAddon.Startup.EditorAny, false)]
	public class BulkheadProfiles : MonoBehaviour
	{
		void onGUIEditorToolbarReady ()
		{
			var pcfilters = PartCategorizer.Instance.filters;
			for (int i = pcfilters.Count; i-- > 0; ) {
				var cat = pcfilters[i];
				var button = cat.button;
				Debug.Log ($"[BulkheadProfiles] {button.categoryName}");
				if (button.categoryName == "Filter by Cross-Section Profile") {
					Debug.Log ($"  found it");
				}
			}
		}

		void Awake ()
		{
			GameEvents.onGUIEditorToolbarReady.Add (onGUIEditorToolbarReady);
		}

		void OnDestroy ()
		{
			GameEvents.onGUIEditorToolbarReady.Remove (onGUIEditorToolbarReady);
		}
	}
}
