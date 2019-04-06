using System;
using System.Drawing;

namespace DirectX12Samples.Engine
{
    public abstract class GameWindow : IDisposable
    {
        private readonly Game game;

        protected GameWindow(Game game)
        {
            this.game = game;
        }

        public static GameWindow Create(Game game)
        {
#if WINDOWS_UWP
            return new GameWindowUwp(game);
#elif NETCOREAPP
            return new GameWindowWinForms(game);
#endif
        }

        public event EventHandler SizeChanged;

        public abstract Rectangle ClientBounds { get; }

        public abstract WindowHandle NativeWindow { get; }

        public virtual void Dispose()
        {
        }

        internal abstract void Run();

        protected void OnSizeChanged(object sender, EventArgs e)
        {
            SizeChanged?.Invoke(sender, e);
        }

        protected void Tick()
        {
            game.Tick();
        }
    }
}
