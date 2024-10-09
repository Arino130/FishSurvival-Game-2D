using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public Config config;
    private void Start()
    {
        config = new Config(
            1000
        );
    }
    public class Config
    {
        public int coinInit = 0;
        public Config(int coinInit)
        {
            this.coinInit = coinInit;
        }
    }
}