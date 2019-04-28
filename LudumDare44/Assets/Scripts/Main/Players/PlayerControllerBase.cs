using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    public float SecondsLeft { get; protected set; }

    public Vector3 Direction { get; protected set; }

    protected virtual void Start()
    {
        this.SecondsLeft = 60;
    }

    protected virtual void Update()
    {
        SecondsLeft -= Time.deltaTime;
        if (SecondsLeft <= 0)
        {            
            this.OnKill();
        }
    }

    public virtual void OnKill()
    {
        Destroy(this.gameObject);
    }

    public virtual void Shoot()
    {
        SecondsLeft -= 5;

        var bulletObject = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
        bulletObject.transform.position = this.transform.position;
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.Shoot(this.Direction, this);
    }

    public void AddTime(float seconds)
    {
        SecondsLeft += seconds;
    }
}
