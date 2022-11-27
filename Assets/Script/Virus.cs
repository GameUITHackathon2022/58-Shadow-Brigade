using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public HealthBar hbar;
    [SerializeField] private Player player;
    [SerializeField]
    private GameObject obj_virus;
    [SerializeField] private SpriteRenderer sprite_virus;
    private Animator animateVirus;
    private Rigidbody2D rb;
    public List<Sprite> AllSprite = new List<Sprite>();
    [SerializeField] private Unit unit;
    private int maxhp;
    private int currenthp;
    private float fMinX = 0.04f;
    private float fMaxX = 7.44f;
    private float fEnemyX = -50;
    private float fEnemyY = -50;
    private float fEnemyZ = -50;
    [SerializeField]
    private float speed;

    private int Direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        maxhp = 100 + unit.level * 50;
        currenthp = maxhp;
        hbar.setMaxHealth(maxhp);
        animateVirus = GetComponent<Animator>();
        animateVirus.SetBool("Alive", true);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void Setpos(Vector3 input)
    {
        fEnemyX = input.x;
        fEnemyY = input.y;
        fEnemyZ = input.z;
    }
    public void TakeDamage(float damage)
    {
        if (checkdie())
            return;
        currenthp -= (int)damage;
        Debug.Log(damage);
        StartCoroutine(BeingHurt());
        hbar.setHeath(currenthp);
        if (checkdie())
        {
            
            StartCoroutine(DeathandRespawn());
            StartCoroutine(TrashAppear());

        }  
    }
    private bool checkdie()
    {
        if (currenthp <= 0)
            return true;
        return false;
    }
    public void changeSprite(Sprite temp)
    {
        sprite_virus.sprite = temp;
    }
    public void Death()
    {
        animateVirus.SetBool("Alive", false);
    }
    private void Respawn()
    {
        unit.SpawnRandomE();
        unit.level++;
        player.UpdateMoney(50 * unit.level);
        DataManager.instance.saving.level = unit.level;
        Destroy(this.gameObject);
    }
    IEnumerator DeathandRespawn()
    {
        Death();
        yield return new WaitForSeconds(2);
        Respawn();
    }
    IEnumerator BeingHurt()
    {
        Color temp = obj_virus.GetComponent<SpriteRenderer>().color;
        obj_virus.GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        obj_virus.GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 1);
    }
    // Update is called once per frame
    private void Update()
    {
        switch (Direction)
        {
            case -1:
                // Moving Left
                if ( fEnemyX> fMinX)
                {
                    fEnemyX -= speed;
                }
                else
                {
                    // Hit left boundary, change direction
                    obj_virus.GetComponent<SpriteRenderer>().flipX = false;
                    Direction = 1;
                }
                break;

            case 1:
                // Moving Right
                if (fEnemyX < fMaxX)
                {
                    fEnemyX += speed;
                }
                else
                {
                    obj_virus.GetComponent<SpriteRenderer>().flipX = true;
                    Direction = -1;
                }
                break;
        }

        obj_virus.transform.localPosition = new Vector3(fEnemyX, fEnemyY, fEnemyZ);
    }

    public GameObject Trash;

    private GameObject trash1;

    private Rigidbody2D trashBody;
    IEnumerator TrashAppear()
    {
        trash1 = Instantiate(Trash, new Vector3(fEnemyX, fEnemyY - 1, fEnemyZ), Quaternion.identity);
        trashBody = trash1.GetComponent<Rigidbody2D>();
        trashBody.velocity = new Vector3(0, 6f, 0f);
        yield return new WaitForSeconds(2f);
        Destroy(trash1);
    }
}
