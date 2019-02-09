using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyTerraria.UI
{
    abstract class UIBase : Transformable, Drawable
    {
        public UIBase OldParent = null;                     // Предыдущий родитель до перетаскивания элемента
        public UIBase Parent = null;                        // Родитель

        public new Vector2i Position
        {
            get { return (Vector2i)base.Position; }
            set { base.Position = (Vector2f)value; }
        }
        public new Vector2i Origin
        {
            get { return (Vector2i)base.Origin; }
            set { base.Origin = (Vector2f)value; }
        }
        public Vector2i GlobalPosition
        {
            get
            {
                if (Parent == null)
                    return Position;
                else
                    return Parent.GlobalPosition;
            }
        }
        public Vector2i GlobalOrigin
        {
            get
            {
                if (Parent == null)
                    return Origin;
                else
                    return Parent.GlobalOrigin;
            }
        }

        public int Width
        {
            get { return (int)rectShape.Size.X; }
            set { rectShape.Size = new Vector2f(value, rectShape.Size.Y); }
        }
        public int Height
        {
            get { return (int)rectShape.Size.Y; }
            set { rectShape.Size = new Vector2f(rectShape.Size.X, value); }
        }
        public Vector2i Size
        {
            get { return (Vector2i)rectShape.Size; }
            set { rectShape.Size = (Vector2f)value; }
        }

        public bool IsAllowDrag = false;    // Разрешено перетаскивать UI мышью?
        public Vector2i DragOffset { get; private set; }

        protected RectangleShape rectShape;

        public virtual void UpdateOver(Vector2i mousePos)
        {
            var localMousePos = mousePos - GlobalPosition + GlobalOrigin;

            if (rectShape.GetLocalBounds().Contains(localMousePos.X, localMousePos.Y))
            {
                if (UIManager.Drag == null)
                {
                    if (IsAllowDrag && Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        UIManager.Drag = this;
                        DragOffset = mousePos - GlobalPosition;
                        OnDragBegin();
                    }
                }

                if (UIManager.Drag != this)
                    UIManager.Over = this;
            }
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);


        }

        // Когда текущий элемент начинают тащить мышкой
        public virtual void OnDragBegin()
        {
            OldParent = Parent;

            Parent = null;
        }

        // Когда на текущий элемент сбрасывают другой
        public virtual void OnDrop(UIBase ui)
        {
        }

        // Когда невозможно сбросить текущий элемент куда то и нужно отменить все изменения
        public virtual void OnCancelDrag()
        {
            Parent = OldParent;
            Position = new Vector2i();
        }
    }
}
