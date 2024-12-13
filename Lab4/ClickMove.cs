using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private AgentMove moveAgent;
    // Start is called before the first frame update
    void Start()
    {
        moveAgent = GetComponent<AgentMove>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) { 
        
            moveAgent.MoveTo(hit.point);
        }

    }
}
