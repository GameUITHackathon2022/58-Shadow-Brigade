using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    private int attackdamage = 20;
    private int percentdamage = 0;
    private Animator animate_player;
    [SerializeField] private Unit unit;
    public int levelskill1;
    public int levelskill2;
    public long money;

    [SerializeField]
    private Virus virus;

    void Start()
    {
        animate_player = gameObject.GetComponent<Animator>();
        money = DataManager.instance.saving.money;
        levelskill1 = DataManager.instance.saving.levelskill1;
        levelskill2 = DataManager.instance.saving.levelskill2;
        attackdamage = levelskill1 * 10;
        percentdamage = levelskill2 * 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            DataManager.instance.SaveData();
        }
    }
    public void init(Unit input)
    {
        unit = input;
    }
    // Update is called once per frame
    public float Attack()
    {
        StartCoroutine(Shoot());
        return (float)attackdamage * (100 + (float)percentdamage) / 100;
    }
    IEnumerator Shoot()
    {
        animate_player.SetBool("Shoot", true);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.3f);
        animate_player.SetBool("Shoot", false);
    }
    public void UpdateMoney(long m_money)
    {
        money += m_money;
        DataManager.instance.saving.money = money;
    }
    public void IncreaseAD()
    {
        if (money >= 30 * unit.level)
        {
            levelskill1++;
            DataManager.instance.saving.levelskill1 = levelskill1;
            Debug.Log(DataManager.instance.saving.levelskill1);
            UpdateMoney(-levelskill1 * 30);
            attackdamage = levelskill1 * 10;
        }
    }
    public void IncreaseAD_percent()
    {
        if (money >= 30 * unit.level)
        {
            
            levelskill2++;
            DataManager.instance.saving.levelskill2 = levelskill2;
            UpdateMoney(-unit.level * 30);
            percentdamage = levelskill2 * 2;
        }
    }

    public int getAttackDamage()
    {
        return attackdamage;
    }
}
