using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject obj_player;
    [SerializeField] private List<Virus> viruses = new List<Virus>();
    public int level;
    void Start()
    {
        SpawnRandomE();
        level = DataManager.instance.saving.level;
        
}
    public void SpawnRandomE()
    {
        Virus virus1 = Instantiate(viruses[Random.Range(0, viruses.Count)]);
        Vector3 temp = new Vector3(5, 1.2f, 10f);
        virus1.Setpos(temp);
    }
    // Update is called once per frame
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                float damage_taken = player.Attack();
                hit.collider.GetComponent<Virus>().TakeDamage(damage_taken);
                Debug.Log(hit.collider);
                
            }
        }
    }
}
