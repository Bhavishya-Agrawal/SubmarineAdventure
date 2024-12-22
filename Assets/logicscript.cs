using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logicscript : MonoBehaviour
{
    public int playerscore;
    public Text score;
    public GameObject gameoverscreen;
    [ContextMenu("Scored!!")]
    public void addscore(int scoretoadd){
        playerscore+=scoretoadd;
        score.text=playerscore.ToString();
    }
    public void restartgame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover(){
        gameoverscreen.SetActive(true);
    }
}
