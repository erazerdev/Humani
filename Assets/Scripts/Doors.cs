using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour
{

	public float timeleft = 0;

	public RaycastHit hit;

	public Transform currentdoor;

	public bool open;

	public bool IsOpeningDoor;

	public Transform cam;

	public LayerMask mask;

	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && timeleft == 0.0f)
			CheckDoor ();
	}

	public void CheckDoor()
	{
		if(Physics.Raycast(cam.position, cam.forward, out hit, 5, mask))
		{
			open = false;
			if(hit.transform.localRotation.eulerAngles.y > 45)
				open = true;

			IsOpeningDoor = true;
		    currentdoor = hit.transform;

		}
	}
	
}

