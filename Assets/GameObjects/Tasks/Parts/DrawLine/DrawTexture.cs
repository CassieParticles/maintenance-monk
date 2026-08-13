using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DrawLine
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DrawTexture : MonoBehaviour
    {
        private const int _pixelsPerUnit = 100;
        private Texture2D _texture;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer =  GetComponent<SpriteRenderer>();
        }

        //X,Y - Middle of texture, width/height - size in units
        public void InitTexture(Vector2 centre, Vector2 size)
        {
            transform.position = centre;
            _texture = new Texture2D((int)(size.x * _pixelsPerUnit), (int)(size.y * _pixelsPerUnit), TextureFormat.RGBA32, false);

            for (int y = 0; y < _texture.height; y++)
            {
                for (int x = 0; x < _texture.width; x++)
                {
                    _texture.SetPixel(x,y,Color.clear);
                }
            }
            _texture.Apply();
            
            _spriteRenderer.sprite = Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), new Vector2(0.5f,0.5f),100.0f);
            _spriteRenderer.sortingOrder = 1;
        }

        public void Draw(Vector2 position, float radius, Color color)
        {
            //Transform relative to texture position
            position -= (Vector2)transform.position;

            for (int x = (int)(-radius * 100); x < (int)(radius * 100); x++)
            {
                for (int y = (int)(-radius * 100); y < (int)(radius * 100); y++)
                {
                    //Make it circular
                    if (x * x + y * y > (radius * 100) * (radius * 100))
                    {
                        continue;
                    }

                    //Get position on texture
                    Vector2Int pixelPosition = new Vector2Int(x, y);
                    pixelPosition.x += (int)(position.x * 100);
                    pixelPosition.y += (int)(position.y * 100);
                    
                    pixelPosition.x -= _texture.width / 2;
                    pixelPosition.y -= _texture.height / 2;
                    
                    _texture.SetPixel(pixelPosition.x,pixelPosition.y,color);
                }
            }
            
            _texture.Apply();
        }
    }
}