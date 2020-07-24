using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
	
	public enum Effects {

	};

	public enum Symptoms{
		falta_de_ar,
		febre,
		tosse,
		morte,
		SARs
	};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0)) {
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
            if (Physics.Raycast(ray, out hit)) {
				print(hit.transform.name);
			}
        }
    }

}
