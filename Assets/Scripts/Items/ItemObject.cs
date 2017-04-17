using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {

	public class ItemObject : ItemObjectInterface {

		[SerializeField]string name;
		[SerializeField]int value;
		[SerializeField]int weight;
		[SerializeField]ItemQuality quality;

		public string ItemName {
			get { return name; }
			set { name = value; }
		}

		public int ItemValue {
			get { return value; }
			set { this.value = value; }
		}

		public int ItemWeight {
			get { return weight; }
			set { weight = value; }
		}

		public ItemQuality ItemQuality {
			get { return quality; }
			set { quality = value; }
		}



	}

}