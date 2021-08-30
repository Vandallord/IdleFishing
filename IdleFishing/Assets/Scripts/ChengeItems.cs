using System;
using UnityEngine;

public class ChengeItems : MonoBehaviour  
{
    /// <summary>
    /// this is done to save time. remake
    /// так сделано для экономии времени. переделать
    /// </summary>

    public string Cloth = "1";
    public string Rod = "1";

    private Sprite[] _spritesCloth;
    private Sprite[] _spritesHand;
    private Sprite[] _spritesRod;

    [SerializeField] private SpriteRenderer _imagePlayer;
    [SerializeField] private SpriteRenderer _imageRod;
    [SerializeField] private SpriteRenderer _imageHand;

    private string _pathClothItog;
    private string _pathCloth;

    private string _pathRodItog;
    private string _pathRod;

    private string _pathHandItog;

    void Awake()
    {
        Load();
    }

    private void Load()
    {
        _pathCloth = "player" + Cloth;
        _pathRod = "rod" + Rod;
        _pathHandItog = "hand" + Cloth;

        if (!_pathCloth.Equals(_pathClothItog))
        {
            _pathClothItog = _pathCloth;

            _spritesCloth = Resources.LoadAll<Sprite>(_pathClothItog);
            _spritesHand = Resources.LoadAll<Sprite>(_pathHandItog);
        }

        if (!_pathRod.Equals(_pathRodItog))
        {
            _pathRodItog = _pathRod;
            _spritesRod = Resources.LoadAll<Sprite>(_pathRodItog);
        }
    }

    void LateUpdate()
    {
        Load();

        var name = _imagePlayer.sprite.name;
        var sprite = Array.Find(_spritesCloth, item => item.name == name);
        if (sprite)
            _imagePlayer.sprite = sprite;

        var nameRod = _imageRod.sprite.name;
        var spriteRod = Array.Find(_spritesRod, item => item.name == nameRod);
        if (spriteRod)
            _imageRod.sprite = spriteRod;

        var spriteHand = Array.Find(_spritesHand, item => item.name == nameRod);
        if (spriteHand)
            _imageHand.sprite = spriteHand;
    }
}
