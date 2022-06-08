using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public List<GameObject> Animations;

    public static Client instance;

    public GameObject order;

    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        order = GameObject.FindGameObjectWithTag("order");
        Cooking.instance.client = this;
        StartCoroutine(Walk());
    }

    private void OnMouseDown()
    {
        if (!Cooking.instance.client)
        {
            Cooking.instance.client = this;
        }
        order.GetComponent<Order>().Ordering();
    }

    private IEnumerator Walk()
    {
        Animations[0].SetActive(true);
        StartCoroutine(Move());
        yield return new WaitForSeconds(2);
        Animations[0].SetActive(false);
        Animations[1].SetActive(true);
    }

    private IEnumerator Move()
    {
        Vector3 endpos = new Vector3(-2.35f, transform.position.y, transform.position.z);
        while (transform.position != endpos)
        {
            transform.position = Vector3.Lerp(transform.position, endpos, 3 * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}