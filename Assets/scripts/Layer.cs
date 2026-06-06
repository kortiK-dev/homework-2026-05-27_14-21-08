using UnityEngine;

public static class Layer
{
    public const string Playernamelayer = "player";
    public const string enemynamelayer = "enemy";
    public const string bulletnamelayer = "bullet";

    public static readonly int playerlayer = LayerMask.NameToLayer(Playernamelayer );
     public static readonly int bulletlayer = LayerMask.NameToLayer(bulletnamelayer );

     public static bool Inbullet(GameObject gameObject)
    {
        return gameObject.layer == bulletlayer;
    }
}