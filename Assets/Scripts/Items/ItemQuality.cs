using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {

	public class ItemQuality : ItemQualityInterface {

		[SerializeField]string name;
		[SerializeField]string color;


		ItemQuality() {
			name = "Common";
			color = "White";
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Color {
			get { return color; }
			set { color = value; }
		}


	}

}