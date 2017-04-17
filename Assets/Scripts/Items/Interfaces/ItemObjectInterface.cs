using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
	
	public interface ItemObjectInterface {
		string ItemName { get; set; }
		int ItemValue { get; set; }
		int ItemWeight { get; set; }
		ItemQuality ItemQuality { get; set; }
	}

}