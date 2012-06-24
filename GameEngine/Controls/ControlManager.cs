using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Controls
{
    public class ControlManager : List<Control>
    {
        int selectedControl;
        bool acceptInput = true;

        static SpriteFont spriteFont;

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }

        public bool AcceptInput
        {
            get { return acceptInput; }
            set { acceptInput = value; }
        }

        public event EventHandler FocusChanged;

        public ControlManager(SpriteFont spriteFont)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection) :
            base(collection)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (Count == 0)
                return;

            foreach (Control c in this.Where(c => c.Enabled))
            {
                c.Update(gameTime);
            }

            foreach (Control c in this.Where(c => c.HasFocus))
            {
                c.HandleInput(playerIndex);
                break;
            }

            if (!AcceptInput)
                return;

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.KeyPressed(Keys.Up))
                PreviousControl();

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.KeyPressed(Keys.Down))
                NextControl();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in this.Where(c => c.Visible))
            {
                c.Draw(spriteBatch);
            }
        }

        public void NextControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl++;

                if (selectedControl == Count)
                    selectedControl = 0;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (FocusChanged != null)
                        FocusChanged(this[selectedControl], null);

                    break;
                }
            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl--;

                if (selectedControl < 0)
                    selectedControl = Count - 1;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (FocusChanged != null)
                        FocusChanged(this[selectedControl], null);

                    break;
                }
            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }
    }
}