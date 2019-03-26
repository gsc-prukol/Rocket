using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketlLauncher : MonoBehaviour, IPointerClickHandler
{
    public GameObject rocketPrefab;
    public GameObject targetHit;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject rocket = Instantiate(rocketPrefab);
        Rocket scriptRocket = rocket.GetComponent<Rocket>();
        rocket.transform.position = new Vector2(0f, 0f);
        scriptRocket.targetHit = targetHit;
        point.GetComponent<Point>().moving = false;
    }


}
