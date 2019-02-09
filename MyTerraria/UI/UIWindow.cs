using SFML.Graphics;
using SFML.System;

namespace MyTerraria.UI
{
    class UIWindow : UIBase
    {
        public const int TITLE_BAR_HEIGHT = 25;

        public bool IsVisibleTitleBar = true;                       // Рисовать заголовочную часть окна?
        public Color BodyColor = new Color(80, 80, 80, 127);        // Цвет заливки формы
        public Color TitleColor = new Color(60, 60, 60, 127);       // Цвет заливки заголовочной части
        public Color TitleColorOver = new Color(60, 60, 60, 255);   // Цвет заливки заголовочной части при наведении курсора мыши

        RectangleShape rectShapeTitleBar;

        public UIWindow()
        {
            rectShape = new RectangleShape(new Vector2f(400, 300));
            rectShapeTitleBar = new RectangleShape(new Vector2f(rectShape.Size.X, TITLE_BAR_HEIGHT));

            ApplyColors();
        }

        public void ApplyColors()
        {
            rectShape.FillColor = BodyColor;
            rectShapeTitleBar.FillColor = (UIManager.Over == this || UIManager.Drag == this) ? TitleColorOver : TitleColor;
        }

        public override void UpdateOver(Vector2i mousePos)
        {
            base.UpdateOver(mousePos);

            if (IsVisibleTitleBar)
            {
                var localMousePos = mousePos - GlobalPosition + GlobalOrigin;
                IsAllowDrag = UIManager.Drag == this || rectShapeTitleBar.GetLocalBounds().Contains(localMousePos.X, localMousePos.Y);
            }
        }

        public override void Update()
        {
            base.Update();

            ApplyColors();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            states.Transform *= Transform;

            if (IsVisibleTitleBar)
                target.Draw(rectShapeTitleBar, states);
        }

        public override void OnCancelDrag()
        {
        }
    }
}
