using UnityEngine;
using System.Collections;

public class EyeMove : MonoBehaviour {

	public Transform target;
	public float LerpRate;
	//public float RepeatRate;
	Vector3[] Points;
	 // Use this for initialization
	 void Start ()
	 {
	 	Points = new Vector3[50];

	 	for(int i = 0;i<Points.Length;i++){
	 		Vector3 temp = new Vector3(Random.Range(-2.0f, 2.2f) / 10.0f, 0, Random.Range(-2.2f, 2.2f)/ 10.0f);
	 		Points[i] = temp + target.localPosition;
	 	}

	 	Debug.Log(target.localPosition);
	 	//transform.position = Vector2.Lerp(transform.position, Points[0], 10);

	    StartCoroutine(LerpCube());
	 }
	 
	 /// <summary>
	 /// This will be responsible for selecting a random point that the box will interpolate to.
	 ///  A new random point will be selected only after the object has finished it's interpolation.
	 /// </summary>
	 private IEnumerator LerpCube()
	 {
	     // This will loop forever and continually lerp the box to random points.
	     while(true)
	     {
	         var randomIndex = Random.Range(0, Points.Length);
	         yield return StartCoroutine(LerpToPoint(Points[randomIndex]));
	         // Time to wait in seconds before we interpolate to the next point.
	         var randomTime = Random.Range(0.5f, 2.0f);
	         yield return new WaitForSeconds(randomTime);
	     }
	 }
	 
	 /// <summary>
	 /// This coroutine performs the interpolation and updates the objects position.
	 /// </summary>
	 /// <param name="destination">The desired position to interpolate the object to.</param>
	 private IEnumerator LerpToPoint(Vector3 destination)
	 {
	     var timeStep = 0.0f;
	     var startPoint = target.localPosition;

	     while(timeStep < 1.0f)
	     {
	         timeStep += Time.deltaTime / LerpRate;
	         target.localPosition = Vector3.Lerp(startPoint, destination, timeStep);
	         yield return null;
	     }
	 }
}
