using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : VillagerStats 
{
   
    protected override void Die()
    {
        SceneManager.LoadScene(3);
    }
   
}
