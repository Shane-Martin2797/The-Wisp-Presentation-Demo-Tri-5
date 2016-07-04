using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

    Collider2D potentialBody;

    GameObject body;

    public float timeForPossesion;
    public Color posColor;
    Color normColor;
    float curPosTime;

    Movement playerMovement;
    Movement posessedMovement;
    SpriteRenderer rend;

    void Awake()
    {
        playerMovement = GetComponent<Movement>();

        rend = GetComponent<SpriteRenderer>();
        normColor = rend.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(potentialBody == null && col.tag == "entity")
        {
            potentialBody = col;
            curPosTime = timeForPossesion;
        }
    }

    void EnterBody()
    {
        body = potentialBody.gameObject;

        potentialBody = null;

        posessedMovement = body.GetComponent<EnemyController>().Possess();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && body != null)
        {
            transform.position = posessedMovement.transform.position;
            posessedMovement.GetComponent<EnemyController>().Release();
            posessedMovement = null;
            body = null;
            GetComponent<Rigidbody2D>().velocity = Vector3.left * 20;
            rend.color = normColor;
        }

        if (body != null)
            return;

        if (potentialBody == null)
            return;

        if (curPosTime > 0)
        {
            curPosTime -= Time.deltaTime;
            rend.color = normColor * curPosTime / timeForPossesion +posColor * (timeForPossesion - curPosTime) / timeForPossesion;
        }
        else
        {
            EnterBody();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(potentialBody != null)
        {
            potentialBody = null;
            rend.color = normColor;
        }
    }

    void FixedUpdate()
    {
        if (body != null)
            posessedMovement.UpdateMovement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        else
            playerMovement.UpdateMovement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}
