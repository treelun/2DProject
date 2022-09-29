using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EagleAmmoFire : MonoBehaviour
{
    public GameObject ammoPrefab;

    static List<GameObject> ammoPool;

    public int poolSize;

    public float weaponVelocity;

    Enemy_Eagle_Controller EEC;

    float delta;

    public Vector3 RandomPosition;

    private void Awake()
    {
        if (ammoPool == null)
        {
            ammoPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject ammoObject = Instantiate(ammoPrefab);
                ammoObject.SetActive(false);
                ammoPool.Add(ammoObject);
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        EEC = GetComponent<Enemy_Eagle_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(OnFire());
       
    }

    GameObject SpawnAmmo(Vector3 location)
    {
        //미리 인스턴스화 시킨 오브젝트의 풀(ammoPool)을 반복
        foreach (GameObject ammo in ammoPool)
        {
            //오브젝트가 비활성화 상태인가?
            if (ammo.activeSelf == false)
            {
                //그럼 활성화 시켜
                ammo.SetActive(true);

                //위치는 location이야(발사한거처럼 보이게할 위치 즉 캐릭터의 위치)
                ammo.transform.position = location;

                //활성화시킨 ammo 리턴해줘
                return ammo;
            }
        }
        //비활성화 오브젝트가없어? 그럼 null 리턴해줘
        return null;
    }

    void fireAmmo()
    {
        //마우스의 위치를 가져옴 마우스는 화면공간을 사용하므로
        //화면 공간의 마우스위치를 월드공간위치로 변환해줌
        float ranX = Random.Range(40, 50);
        
        RandomPosition = new Vector3(ranX, -1, 0);
        //SpawnAmmo를 이용하여 List로 만든 objectpool중에 비활성화 된놈을 찾는다.
        //위치는 캐릭터가 발사하는거 처럼 보여야 하므로 캐릭터의 위치를 넣어준다.
        GameObject ammo = SpawnAmmo(transform.position);

        //ammo가 null이 아닌가? 활성화 되지 않은 오브젝트가 있는가?
        if (ammo != null)
        {
            //AmmoVector에서 구현한 Flyammo를 사용하기위해 AmmoVector를 담아줌
            AmmoVector ammoVectorScript = ammo.GetComponent<AmmoVector>();

            //weaponVelocity는 에디터에서 값을 입력한다.
            //travelDuration은 object가 목표지점까지 도달하는 시간이였다.
            //weaponVelocity에 2.0f값을 주면 1.0/2.0 = 0.5가 되므로
            //총알은 0.5초만에 목표지점에 도달한다.
            float travelDuration = 1.0f / weaponVelocity;

            //AmmoVector에서 만든 FlyAmmo 메서드를 가져온다.
            //목표지점은 랜덤 위치, 속도는...? 시간으로 넣어주었다. 계산을 하면 하겠지만 귀찮다.
            StartCoroutine(ammoVectorScript.FlyAmmo(RandomPosition, travelDuration));
        }


    }
    public IEnumerator OnFire()
    {
        yield return null;
        delta += Time.deltaTime;
        while (EEC.isMove == true && delta > 0.5)
        {
            
           
                fireAmmo();
                delta = 0;
            
            yield return null;
        }
    }


}
