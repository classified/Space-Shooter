using UnityEngine;
using System.Collections;

namespace BridgeJTOC {
	public static class Bridge  {
		public static string highScoreName;
		public static int scoreBridge;
		public static int killsBridge;
		public static bool ObjectState = false;

		public static void setHighScoreName(string name)
		{
			highScoreName = name;

		}
		public static void setObjectState(bool objects)
		{
			ObjectState = objects;
		}
		public static void setScore(int scr)
		{
			scoreBridge = scr;
		}
		public static void setKill(int down)
		{
			killsBridge = down;
		}
	}
}
