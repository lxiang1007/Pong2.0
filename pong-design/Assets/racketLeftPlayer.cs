<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class racketLeftPlayer : MonoBehaviour {

	Controller controller;
	Queue queue;
	int fcount = 0;
	Frame TheFirstOne;
	Frame TheSecondOne;
	Vector TheFirstMovement;

	// Use this for initialization
	void Start () {
		queue = new Queue();
		
	}

    // Update is called once per frame
    void Update() {
		controller = new Controller ();

		if (fcount == 0) {
			TheFirstOne = controller.Frame ();
			TheSecondOne = controller.Frame (1);
			TheFirstMovement = TheFirstOne.Translation (TheSecondOne);
			fcount++;
		}


		Frame current = controller.Frame ();
		Frame previous = controller.Frame (1);
		int i = 0;

		Vector linearMovement = current.Translation (previous);
		queue.Enqueue (linearMovement.y);

		if(queue.Count >= 10) {
			queue.Dequeue();
		}
				

		foreach (var num in queue) {
			if ((float.Parse(num.ToString()) > 0.1) || (float.Parse(num.ToString()) < -0.1)) {
				i++;
			}
			if (i>8){
				if (Input.GetKey("up")||(linearMovement.y > TheFirstMovement.y))
				{
					Debug.Log ("The Y value is:" + linearMovement.y);
					transform.position = new Vector3(transform.position.x + 0.35f, 0.0f, transform.position.z);
				}
				if (Input.GetKey("down")||(linearMovement.y < TheFirstMovement.y))
				{
					Debug.Log ("The Y value is:" + linearMovement.y);
					transform.position = new Vector3(transform.position.x - 0.35f, 0.0f, transform.position.z);
				}
			}
		}
        
		/*
        // control with mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(ray.GetPoint(10f).x, 0.0f, transform.position.z);
        */

        // control with keyboard



    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketLeftPlayer : MonoBehaviour {

    

// Use this for initialization
void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        //controlMouse();
        controlKeyboard();
    
    }

    void controlMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(ray.GetPoint(10f).x, 0.0f, transform.position.z);
    }

    void controlKeyboard()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKey("up") && transform.position.x < 7.5)
        {
           
            transform.position = new Vector3(transform.position.x + 0.2f, 0.0f, transform.position.z);
            Debug.Log(transform.position.x);
        }
        if (Input.GetKey("down") && transform.position.x > -7.5)
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 0.0f, transform.position.z);
            Debug.Log(transform.position.x);
        }
        
       
    }
}
>>>>>>> 73616af13450c97734d9e680f708638e71554dcb
