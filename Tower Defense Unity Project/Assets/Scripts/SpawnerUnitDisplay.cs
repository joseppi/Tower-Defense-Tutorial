using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerUnitDisplay : MonoBehaviour
{
    public GameObject redBarracksUI;
    public GameObject blueBarracksUI;
    public GameObject yellowBarracksUI;

    public List<GameObject> uiElementList;

    public WaveSpawner spawner;

    int currentRound = -1;
    

    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRound != StatsPlayer.Rounds) //This needs optimization
        {
            UpdateUnitDisplay();
            currentRound = StatsPlayer.Rounds;
        }
    }

    public void UpdateUnitDisplay()
    {
        if (GameObject.FindGameObjectsWithTag("Icon").Length > 0)
        {
            GameObject[] childerns = GameObject.FindGameObjectsWithTag("Icon");
            for (int i = 0; i < childerns.Length; i++)
            {
                Destroy(childerns[i]);
            }
            uiElementList.Clear();
        }

        for (int i = StatsPlayer.playerBarracks.Count - 1; i >= 0; i--) //Iterate backwards
        {
            if (StatsPlayer.playerBarracks[i].GetComponent<PlayerBarracks>().farmWave.GetUnit().name.Contains("Tough"))
            {
                GameObject instance = Instantiate<GameObject>(redBarracksUI, this.gameObject.transform);
                redBarracksUI.GetComponent<UnitDisplayElement>().barracksIndex = i;
                uiElementList.Add(redBarracksUI);
            }
            if (StatsPlayer.playerBarracks[i].GetComponent<PlayerBarracks>().farmWave.GetUnit().name.Contains("Simple"))
            {
                GameObject instance = Instantiate<GameObject>(blueBarracksUI, this.gameObject.transform);
                blueBarracksUI.GetComponent<UnitDisplayElement>().barracksIndex = i;
                //Debug.Log(i.ToString());
                //Debug.Log(StatsPlayer.playerBarracks[i].GetComponent<PlayerBarracks>().GetInstanceID().ToString());
                uiElementList.Add(blueBarracksUI);
            }
            if (StatsPlayer.playerBarracks[i].GetComponent<PlayerBarracks>().farmWave.GetUnit().name.Contains("Fast"))
            {
                GameObject instance = Instantiate<GameObject>(yellowBarracksUI, this.gameObject.transform);
                yellowBarracksUI.GetComponent<UnitDisplayElement>().barracksIndex = i;
                uiElementList.Add(yellowBarracksUI);
            }

        }
    }
}
