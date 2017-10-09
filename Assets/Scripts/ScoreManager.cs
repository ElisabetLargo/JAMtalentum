using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;

using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text DucksSaved, ChickensSaved, Time;
    public Gradient color;
    public void UpdateTime(float time)
    {
        int mins = (int)time / 60;
        int secs = (int)((time/60f - mins) *60);
        Time.text = mins + "m" + secs + "s";
       // Time.text = time.ToString();
    }

    /// <summary>
    /// typeofBird: true = ducks , false = chickens
    /// </summary>
    /// <param name="birdsSaved"></param>
    /// <param name="birdsTotal"></param>
    /// <param name="typeofBird"></param>
    public void updatebirds(ref int birdsSaved, ref int birdsTotal,bool ducks)
    {
        Text t;
        StringBuilder s = new StringBuilder();
        string bird;
        if (ducks)
        {
            t = DucksSaved; 
        }
        else
        {
            t = ChickensSaved;
        }

        s.Append(birdsSaved + "/" + birdsTotal);
        t.text = s.ToString();
    }

}
