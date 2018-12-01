using UnityEngine;
using UnityEngine.UI;

public class Bullet {

    private int bullet;
    public Text bulletText;

    public void setBulletText(Text bulletin)
    {
        bulletText = bulletin;
        bullet = 10;
    }

    public void UpdateBullet() {
        bulletText.text = "Bullet: " + bullet;
    }

    public void addBullet(int value) {
        bullet += value;
        UpdateBullet();
    }

    public int getBullet() {
        return bullet;
    }

}
