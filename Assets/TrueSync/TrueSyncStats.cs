using System;
using System.Collections.Generic;
using UnityEngine;

namespace TrueSync
{
	[AddComponentMenu("")]
	public class TrueSyncStats : MonoBehaviour
	{
		private class StatsUI
		{
			public Color color;

			public float maxValue;

			public bool isAvg;

			public string description;

			public StatsUI(string description, Color color, float maxValue, bool isAvg)
			{
				this.description = description;
				this.color = color;
				this.maxValue = maxValue;
				this.isAvg = isAvg;
			}
		}

		private static Color COLOR_GREEN = new Color(0f, 0.6f, 0f);

		private static Color COLOR_YELLOW = new Color(1f, 0.549019635f, 0f);

		[HideInInspector]
		internal AbstractLockstep lockstep;

		public int width = 200;

		public int height = 200;

		public int marginLeft = 0;

		public int marginRight = 20;

		private Texture2D bgTexture;

		private int globalTextWidth = 150;

		private float barWidth;

		private Dictionary<string, TrueSyncStats.StatsUI> statsUI = new Dictionary<string, TrueSyncStats.StatsUI>();

		public AbstractLockstep Lockstep
		{
			set
			{
				this.lockstep = value;
			}
		}

		public void Start()
		{
			this.barWidth = (float)((this.width - this.marginLeft) / (this.lockstep.compoundStats.bufferStats.size - 2));
			this.bgTexture = new Texture2D(1, 1);
			this.bgTexture.SetPixel(0, 0, Color.get_white());
			this.statsUI["ping"] = new TrueSyncStats.StatsUI("Ping", Color.get_black(), 500f, true);
			this.statsUI["missed_frames"] = new TrueSyncStats.StatsUI("Missed Frames", TrueSyncStats.COLOR_YELLOW, 100f, false);
			this.statsUI["rollback"] = new TrueSyncStats.StatsUI("Rollbacks", Color.get_magenta(), 100f, false);
			this.statsUI["simulated_frames"] = new TrueSyncStats.StatsUI("Sim. Frames", Color.get_blue(), 100f, false);
			this.statsUI["panic"] = new TrueSyncStats.StatsUI("Panic", Color.get_red(), 100f, false);
			this.statsUI["players"] = new TrueSyncStats.StatsUI("Active Players", Color.get_black(), 100f, false);
		}

		public void OnGUI()
		{
			GUI.set_color(new Color(1f, 1f, 1f, 0.75f));
			GUI.DrawTexture(new Rect(0f, 0f, (float)(this.width + this.globalTextWidth), (float)(this.height + 1)), this.bgTexture, 0);
			GUI.set_color(Color.get_white());
			this.DrawAxis();
			this.DrawLine("ping");
			this.DrawLine("simulated_frames");
			this.DrawLine("rollback");
			this.DrawLine("missed_frames");
			int num = 5;
			this.DrawOfflineMode(ref num);
			this.DrawGlobalInfo(ref num, "simulated_frames");
			this.DrawGlobalInfo(ref num, "ping");
			this.DrawGlobalInfo(ref num, "rollback");
			this.DrawGlobalInfo(ref num, "missed_frames");
			this.DrawGlobalInfo(ref num, "players");
			bool flag = this.lockstep.compoundStats.globalStats.GetInfo("panic").count > 0L;
			if (flag)
			{
				this.DrawGlobalInfo(ref num, "panic");
			}
			this.DrawChecksum();
		}

		private void DrawAxis()
		{
			Drawing.DrawLine(new Vector2((float)this.marginLeft, (float)this.height), new Vector2((float)this.width, (float)this.height));
		}

		private void DrawLine(string statsKey)
		{
			GUI.get_skin().get_label().set_alignment(4);
			Color color = this.statsUI[statsKey].color;
			float maxValue = this.statsUI[statsKey].maxValue;
			int num = (this.lockstep.compoundStats.bufferStats.currentIndex + 1) % this.lockstep.compoundStats.bufferStats.size;
			CountInfo info = this.lockstep.compoundStats.bufferStats.buffer[num].GetInfo(statsKey);
			float num2 = this.statsUI[statsKey].isAvg ? info.average() : ((float)info.count);
			Vector2 pointA = new Vector2((float)this.marginLeft, (float)this.height * (1f - Mathf.Min(num2 / maxValue, 1f)));
			for (int i = 2; i <= this.lockstep.compoundStats.bufferStats.size - 1; i++)
			{
				int num3 = (this.lockstep.compoundStats.bufferStats.currentIndex + i) % this.lockstep.compoundStats.bufferStats.size;
				CountInfo info2 = this.lockstep.compoundStats.bufferStats.buffer[num3].GetInfo(statsKey);
				num2 = (this.statsUI[statsKey].isAvg ? info2.average() : ((float)info2.count));
				Vector2 vector = new Vector2((float)this.marginLeft + this.barWidth * (float)(i - 1), (float)this.height * (1f - Mathf.Min(num2 / maxValue, 1f)));
				Drawing.DrawLine(pointA, vector, color);
				pointA = vector;
			}
		}

		private void DrawGlobalInfo(ref int posBaseY, string statsKey)
		{
			GUI.get_skin().get_label().set_alignment(3);
			GUI.set_contentColor(this.statsUI[statsKey].color);
			CountInfo countInfo = null;
			bool flag = statsKey == "players";
			if (flag)
			{
				countInfo = new CountInfo();
				countInfo.count = 0L;
				foreach (TSPlayer current in this.lockstep.Players.Values)
				{
					bool flag2 = !current.dropped;
					if (flag2)
					{
						countInfo.count += 1L;
					}
				}
			}
			else
			{
				countInfo = this.lockstep.compoundStats.globalStats.GetInfo(statsKey);
			}
			string arg = this.statsUI[statsKey].isAvg ? countInfo.averageFormatted() : string.Concat(countInfo.count);
			GUI.Label(new Rect((float)(this.width + this.marginRight), (float)posBaseY, (float)this.globalTextWidth, 20f), string.Format("{0}: {1}", this.statsUI[statsKey].description, arg));
			posBaseY += 20;
		}

		private void DrawOfflineMode(ref int posBaseY)
		{
			bool flag = this.lockstep.communicator != null;
			if (!flag)
			{
				GUI.get_skin().get_label().set_alignment(3);
				GUI.set_contentColor(this.lockstep.checksumOk ? TrueSyncStats.COLOR_GREEN : Color.get_red());
				GUI.Label(new Rect((float)(this.width + this.marginRight), (float)posBaseY, (float)this.globalTextWidth, 20f), "Offilne Mode");
				posBaseY += 20;
			}
		}

		private void DrawChecksum()
		{
			GUI.get_skin().get_label().set_alignment(3);
			GUI.set_contentColor(this.lockstep.checksumOk ? TrueSyncStats.COLOR_GREEN : Color.get_red());
			GUI.Label(new Rect((float)(this.width + this.marginRight), (float)(this.height - 20), (float)this.globalTextWidth, 20f), string.Format("Checksum: {0}", this.lockstep.checksumOk ? "OK" : "NOK"));
		}
	}
}
