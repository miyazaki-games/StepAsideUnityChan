using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    public int startPos;
    public int goalPos;
    private int InstantiateCount = 0;

    private float posRange = 3.4f;
    private float speed;
    private float MoveLength = 0;
    private float MoveLengthLimit;

    public Rigidbody rb;

    public void Update()
    {
        speed = rb.velocity.magnitude;

        this.MoveLength += speed * Time.deltaTime;

        if (MoveLength > MoveLengthLimit)
        {
            if (InstantiateCount < 8)
            {
                for (int i = startPos; i < goalPos; i += 15)
                {
                    int num = Random.Range(1, 11);
                    if (num <= 2)
                    {
                        for (float j = -1; j <= 1; j += .4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                        }
                    }
                    else
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int item = Random.Range(1, 11);
                            int offsetZ = Random.Range(-5, 6);

                            if (1 <= item && item <= 6)
                            {
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                            }
                            else
                            {
                                GameObject car = Instantiate(carPrefab);
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                            }
                        }
                    }
                }
            }

            startPos += 41;
            goalPos += 40;
            MoveLengthLimit += 27.5f;
            InstantiateCount++;
        }
    }
}
