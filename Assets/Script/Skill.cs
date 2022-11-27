using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private string infomation;
    [SerializeField] private int level;
    [SerializeField] private int basecost;
    
    public string Getinfo()
    {
        return infomation;
    }
    public int Getlevel()
    {
        return level;
    }
    public long cost()
    {
        return (long)((float)basecost * 0.2f * level);
    }
    public void levelup()
    {
        level++;   
    }
}
