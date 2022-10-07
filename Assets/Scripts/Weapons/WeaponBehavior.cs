using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponBehavior : MonoBehaviour
{
    float timer;
    [SerializeField ,Tooltip("How much to rotate the projectile in degrees from ")]
    float rotationOffset;
    [SerializeField]
    private WeaponDataContainer weaponData;
    int selectedFireMode;
    public GameObject playerGO;
    private Animator myAnimator;
    AudioSource myAud;
    public GameObject muzzleFlashSpawnGO; 
    public GameObject barrel;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Animator>() != null){
            
            myAnimator = gameObject.GetComponent<Animator>();

        }
        myAud = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        PreShoot();
        FMM(weaponData.fireModes);
    }

    void FMM(int[] fireModes){

        if(selectedFireMode <= fireModes.Length){
            if(Input.GetKeyDown(KeyCode.V)){
                selectedFireMode++;
            }
        }
        else if(selectedFireMode > fireModes.Length){
            selectedFireMode = 0;
        }
    }

    void PreShoot(){

        switch(selectedFireMode){

            case 0:
            if(Input.GetMouseButtonDown(0)){
                Shoot(weaponData.muzzleVelocity, weaponData.projectile);
            }
                break;
            case 1:
            if(Input.GetMouseButton(0) && timer > weaponData.shotDelay){
                Shoot(weaponData.muzzleVelocity, weaponData.projectile);
                    timer = 0;
            }
            else{
                timer += Time.deltaTime;
            }
            break;

        }

    }

    void Shoot(float muzzleVelocity, GameObject projectile){
        MuzzleFlash(weaponData.muzzleFlashPrefab);
        timer = 0;
        //set spawn location
        Vector3 spawnPos = barrel.transform.position;
        //get mouse location
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //setup direction to fire
        Vector3 fireDir = (mousePos - spawnPos).normalized;
        //make prefab real
        GameObject cloneProj = Instantiate(projectile, spawnPos, Quaternion.Euler(0, 0, Mathf.Atan2(fireDir.y, fireDir.x)  * Mathf.Rad2Deg + rotationOffset));
        //launch in desired direction
        cloneProj.GetComponent<Rigidbody2D>().velocity = fireDir * muzzleVelocity;
        myAud.PlayOneShot(weaponData.shootSound);
        MuzzleFlash(weaponData.muzzleFlashPrefab);

    }

    void RotateTowardsMouse(){
        //Find mouse pos
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Find rotation vector
        Vector3 rotVector = (mousePos - transform.position).normalized;
        //Find rotation value in float form
        float weaponRoationValue = Mathf.Atan2(rotVector.y, rotVector.x)  * Mathf.Rad2Deg + rotationOffset;
        //Apply rotation
        transform.rotation = Quaternion.Euler(0,0, weaponRoationValue);
        //Flip gun if rotation is > 180 
        myAnimator.SetFloat("Rotation", weaponRoationValue);

        if(playerGO != null)
        {
            transform.position = playerGO.transform.position + (mousePos - transform.position).normalized;
        }
    }

    void MuzzleFlash(GameObject muzzleFlashGO){
        Instantiate(muzzleFlashGO, muzzleFlashSpawnGO.transform.position, transform.rotation);
        muzzleFlashGO.transform.position = muzzleFlashSpawnGO.transform.position;
    }
}
