using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Transform end;
    private float speed;
    private Vector3 direction;
    private Counter counter;
    public float maxLifeTime = 5f;
    private float lifeTime;

    private void Awake()
    {
        end = EndPoint.Instance.transform;
        counter = FindAnyObjectByType<Counter>();
    }

    public void Launch(float destinationOffsetRange)
    {
        speed = Random.Range(5, 10);
        lifeTime = maxLifeTime;

        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);

        Vector3 targetPos = new Vector3(end.position.x + offset, end.position.y, end.position.z);

        direction = (targetPos - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        LifeTime();
    }

    void LifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sable")) 
        {
            counter.counter++;
            gameObject.SetActive(false);
        }
    }
}