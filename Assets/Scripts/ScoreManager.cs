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
        Time.text = time.ToString();
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
        if (ducks) {
            t = DucksSaved;
            bird = "Ducks   ";  
            s.Append(bird,0,bird.Length);
            //DucksSaved.text = "Ducks:   " + birdsSaved + "/" + birdsTotal;
        }
        else
        {
            t = ChickensSaved;
            bird = "Chickens    ";
            s.Append(bird, 0, bird.Length);
            //ChickensSaved.text = "Chickens: " + birdsSaved + "/" + birdsTotal;
        }

        s.Append(birdsSaved + "/" + birdsTotal);
        t.text = s.ToString();
    }

}
