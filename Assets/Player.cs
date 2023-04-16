using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject[] playerCharacters;

    [SerializeField]
    float[] speeds = { 1f, 2f, 4f };

    int SpeedIndex { get; set; } = 0;
    float CurrentSpeed { get => speeds[SpeedIndex]; }

    int CharacterIndex { get; set; } = 0;
    GameObject CurrentCharacter { get => playerCharacters[CharacterIndex]; }

    static readonly KeyCode[] NUMBER_KEYS =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    // Start is called before the first frame update
    void Start()
    {
        SetCharacter(0);
    }

    void SetCharacter(int index)
    {
        CharacterIndex = index;
        foreach (GameObject chara in playerCharacters) chara.SetActive(false);
        CurrentCharacter.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += new Vector3(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector3(0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(1, 0);
        }

        transform.position += dir.normalized * CurrentSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpeedIndex++;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sr.color = Random.ColorHSV();
            }
        }

        for (int i = 0; i < playerCharacters.Length; i++)
        {
            if (Input.GetKeyDown(NUMBER_KEYS[i]))
            {
                SetCharacter(i);
            }
        }
    }
}
