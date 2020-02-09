//Christopher Brinkley and Morgan Davis
//MMC215 Pooling Assignment
//2/14/20
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectSpawner(){
    void FixedUpdate(){
        
        ObjectPooler.Instance.SpawnFromPool("Cube", transform.position, Quaternion.identity); //Creates the object from the pool into the program
    }
}