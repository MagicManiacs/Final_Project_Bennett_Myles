using UnityEngine;
using System.Collections;

public class CollisionStack : MonoBehaviour {

    public GameObject[] HitList;
    Stack HitStack;

	// Use this for initialization
	void Start () {
        HitStack = new Stack();
	}
	
	// Update is called once per frame
	void Update () {
	    if(HitStack.Count > 0)
        {
            GameObject lastObject = HitStack.Peek() as GameObject;

            Debug.DrawLine(transform.position, 
                lastObject.transform.position, Color.red);

            if(HitList[0] == lastObject)
            {
                StartCoroutine("popTheStack");
            }
        }
	}

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger " + c.gameObject.name);
        // Debug.Log("Trigger " + c.gameObject.tag);

        if (!HitStack.Contains(c.gameObject))
        {
            HitStack.Push(c.gameObject);

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);
        }
    }

    IEnumerable popTheStack()
    {
        yield return new WaitForSeconds(2);

        if(HitStack.Count > 0)
        {
            HitStack.Pop();

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);

            StopCoroutine("popTheStack");
        }
    }
}
