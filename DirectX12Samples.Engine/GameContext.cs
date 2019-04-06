namespace DirectX12Samples.Engine
{
    public enum AppContextType
    {
        CoreWindow,
        Xaml,
        Holographic,
        WinForms
    }

    public abstract class GameContext
    {
        public AppContextType ContextType { get; protected set; }

        public int RequestedHeight { get; private protected set; }

        public int RequestedWidth { get; private protected set; }
    }

    public abstract class GameContext<TControl> : GameContext
    {
        public TControl Control { get; private protected set; }

        protected GameContext(TControl control, int requestedWidth = 0, int requestedHeight = 0)
        {
            Control = control;
            RequestedWidth = requestedWidth;
            RequestedHeight = requestedHeight;
        }
    }

#if WINDOWS_UWP
    public class GameContextCoreWindow : GameContext<Windows.UI.Core.CoreWindow>
    {
        public GameContextCoreWindow(Windows.UI.Core.CoreWindow? control = null, int requestedWidth = 0, int requestedHeight = 0)
            : base(control ?? Windows.UI.Core.CoreWindow.GetForCurrentThread(), requestedWidth, requestedHeight)
        {
            ContextType = AppContextType.CoreWindow;
        }
    }

    public class GameContextXaml : GameContext<Windows.UI.Xaml.Controls.SwapChainPanel>
    {
        public GameContextXaml(Windows.UI.Xaml.Controls.SwapChainPanel control, int requestedWidth = 0, int requestedHeight = 0)
            : base(control, requestedWidth, requestedHeight)
        {
            ContextType = AppContextType.Xaml;
        }
    }
#endif

#if NETCOREAPP
    public class GameContextWinForms : GameContext<System.Windows.Forms.Control>
    {
        public GameContextWinForms(System.Windows.Forms.Control? control = null, int requestedWidth = 0, int requestedHeight = 0)
            : base(control ?? new System.Windows.Forms.Form(), requestedWidth, requestedHeight)
        {
            ContextType = AppContextType.WinForms;
        }
    }
#endif
}
