using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    abstract public class Component
    {
        private BaseObject _baseObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize (BaseObject baseObject)
        {
            _baseObject = baseObject;
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject.GetComponent<TComponentType>(ComponentType);
        }

        public int GetOwnerId()
        {
            return _baseObject.id;
        }

        public void RemoveMe()
        {
            _baseObject.RemoveComponent(this);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
