using UnityEngine;

public class Room 
{
    public int type;
    public Vector2 gridPos;
    public bool left, right, top, bot;
    public Room(int type,Vector2 gridPos)
    {
        this.type = type;
        this.gridPos = gridPos;
    }

}
