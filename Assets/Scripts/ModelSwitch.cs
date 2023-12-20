using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitch : MonoBehaviour
{
    public int DefultChar;
    public int CurrentChar;
    public GameObject[] Characters;

    public GameObject CurrentModel;
    // Start is called before the first frame update
    void Start()
    {
        CurrentChar = DefultChar;
        GameObject newchar = Instantiate(Characters[CurrentChar], gameObject.transform);
        newchar.GetComponent<AnimationDriver>().PlayerScript = gameObject;
        CurrentModel = newchar;
    }

    // Update is called once per frame
    void Update()
    {

        //switches models;
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchPlayerModel();
        }
    }
    public void SwitchPlayerModel()
    {
        Destroy(CurrentModel);
        CurrentChar++;
        if (CurrentChar >= Characters.Length)
        {
            CurrentChar = 0;
        }
        GameObject newchar = Instantiate(Characters[CurrentChar], gameObject.transform);
        newchar.GetComponent<AnimationDriver>().PlayerScript = gameObject;
        CurrentModel = newchar;
    }
}
