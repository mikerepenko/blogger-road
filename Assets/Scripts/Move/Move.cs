using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public GameObject Model;
    public GameObject Score;

    public bool Jump;
    bool right;
    bool left;
    bool forward;
    bool back;

    float DeltaTime;
    float NowDeltaTime;
    float inJump = 1;
    float dragDistance;

    Vector3 PlayerStart;
    Vector3 PlayerEnd;
    Vector3 fp;
    Vector3 lp;

    void Start()
    {
        PlayerStart = transform.position;
        PlayerEnd = transform.position;
        dragDistance = Screen.height * 7 / 100;
    }

    void Update()
    {

        PlayerStart = transform.position;


        if (Input.GetKeyDown(KeyCode.UpArrow)) {
          if(GetComponentInChildren<IfWater>().Watter == true)
          {
              PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) - 10, transform.position.y, transform.position.z);
          }
          else
          {
              PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) - 10, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10));
          }
          DeltaTime = 1;
          NowDeltaTime = 0;
          Jump = true;
          Model.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
          if (!GetComponentInChildren<Right>().right)
          {
              if (!GetComponent<OnLog>().PlayerOnLog)
                  PlayerEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
              else
              {
                  PlayerEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z + 17.5f);
              }
              DeltaTime = 1;
              NowDeltaTime = 0;
              Jump = true;
              Model.transform.rotation = Quaternion.Euler(0, 180, 0);
          }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
          if (!GetComponentInChildren<Left>().left)
          {
              if (!GetComponent<OnLog>().PlayerOnLog)
                  PlayerEnd = new Vector3(transform.position.x, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10) - 10);
              else
              {
                  PlayerEnd = new Vector3(transform.position.x, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10) - 7.5f);
              }
              DeltaTime = 1;
              NowDeltaTime = 0;
              Jump = true;
              Model.transform.rotation = Quaternion.Euler(0, 0, 0);
          }
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended && Score.GetComponent<AwakeMenu>().ingame)
            {
                lp = touch.position;
                if ((Mathf.Abs(lp.x - fp.x) < dragDistance || Mathf.Abs(lp.y - fp.y) < dragDistance))
                {
                    if (!GetComponentInChildren<Forward>().forward)
                    {
                        if(GetComponentInChildren<IfWater>().Watter == true)
                        {
                            PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) - 10, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) - 10, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10));
                        }
                        DeltaTime = 1;
                        NowDeltaTime = 0;
                        Jump = true;
                        Model.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                if ((Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance))
                {//это перемещение
                    //проверяем, перемещение было вертикальным или горизонтальным
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //Если горизонтальное движение больше, чем вертикальное движение
                        if (lp.x > fp.x)  //Если движение было вправо
                        {   //Свайп вправо
                            if (!GetComponentInChildren<Right>().right)
                            {
                                if (!GetComponent<OnLog>().PlayerOnLog)
                                    PlayerEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
                                else
                                {
                                    PlayerEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z + 17.5f);
                                }
                                DeltaTime = 1;
                                NowDeltaTime = 0;
                                Jump = true;
                                Model.transform.rotation = Quaternion.Euler(0, 180, 0);
                            }
                        }
                        else
                        {
                            //Свайп влево
                            if (!GetComponentInChildren<Left>().left)
                            {
                                if (!GetComponent<OnLog>().PlayerOnLog)
                                    PlayerEnd = new Vector3(transform.position.x, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10) - 10);
                                else
                                {
                                    PlayerEnd = new Vector3(transform.position.x, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10) - 7.5f);
                                }
                                DeltaTime = 1;
                                NowDeltaTime = 0;
                                Jump = true;
                                Model.transform.rotation = Quaternion.Euler(0, 0, 0);
                            }
                        }
                    }
                    else
                    {   //Если вертикальное движение больше, чнм горизонтальное движение
                        if (lp.y > fp.y)  //Если движение вверх
                        {   //Свайп вверх
                            if (!GetComponentInChildren<Forward>().forward)
                            {
                                if (GetComponentInChildren<IfWater>().Watter == true)
                                {
                                    PlayerEnd = new Vector3((Mathf.Round(transform.position.x/10)*10) - 10, transform.position.y, transform.position.z);
                                }
                                else
                                {
                                    PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) - 10, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10));
                                }
                                DeltaTime = 1;
                                NowDeltaTime = 0;
                                Jump = true;
                                Model.transform.rotation = Quaternion.Euler(0, 90, 0);
                            }
                        }
                        else
                        {   //Свайп вниз
                            if (!GetComponentInChildren<Back>().back)
                            {
                                if (GetComponentInChildren<IfWaterBack>().Watter == true)
                                {
                                    PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) + 10, transform.position.y, transform.position.z);
                                }
                                else
                                {
                                    PlayerEnd = new Vector3((Mathf.Round(transform.position.x / 10) * 10) + 10, transform.position.y, (Mathf.Round(transform.position.z / 10) * 10));
                                }
                                DeltaTime = 1;
                                NowDeltaTime = 0;
                                Jump = true;
                                Model.transform.rotation = Quaternion.Euler(0, -90, 0);
                            }
                        }
                    }
                }
            }
        }


        if (Jump == true)
        {
            NowDeltaTime += Time.deltaTime * 3;
            inJump = NowDeltaTime / DeltaTime;
            transform.position = Vector3.Lerp(PlayerStart, PlayerEnd, inJump);
            if (inJump > 0.8f)
            {
                inJump = 1;
                transform.position = PlayerEnd;
                Jump = false;
            }
        }
    }
}
