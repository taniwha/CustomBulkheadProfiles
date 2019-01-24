/*
	BulkheadProfiles.cs

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
using RUI.Icons.Selectable;

using KSP.UI.Screens;

namespace BulkheadProfiles {

	public class BulkheadProfileData
	{
		public string name;
		public string displayName;
		public Icon icon;

		public BulkheadProfileData (ConfigNode node)
		{
			name = node.GetValue ("name");
			displayName = node.GetValue ("displayName");
			string nTexName = node.GetValue ("normalIcon");
			string sTexName = node.GetValue ("selectedIcon");
			var nTex = GameDatabase.Instance.GetTexture (nTexName, false);
			var sTex = GameDatabase.Instance.GetTexture (sTexName, false);
			if (nTex != null && sTex != null) {
				icon = new Icon (name, nTex, sTex, true);
			} else if (nTex != null) {
				icon = new Icon (name, nTex, nTex, true);
			} else if (sTex != null) {
				icon = new Icon (name, sTex, sTex, true);
			}
			//Debug.Log ($"[BulkheadProfileData] {name} {displayName} {nTexName} {sTexName} {icon}");
		}
	}
}
