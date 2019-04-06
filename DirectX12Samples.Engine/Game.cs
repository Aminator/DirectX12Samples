using System;
using System.Numerics;
using System.Threading;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D12;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

using Device = SharpDX.Direct3D12.Device;
using Resource = SharpDX.Direct3D12.Resource;

namespace DirectX12Samples.Engine
{
    public class Game : IDisposable
    {
        private readonly object tickLock = new object();

        public Game(GameContext gameContext)
        {
            Context = gameContext;

            Window = GameWindow.Create(this);
        }

        public GameContext Context { get; }

        public GameWindow Window { get; }

        public virtual void Dispose()
        {
        }

        public void Run()
        {
            Initialize();
            LoadContent();

            Window.Run();
        }

        public void Tick()
        {
            lock (tickLock)
            {
                Update();
                Draw();
            }
        }

        protected void Initialize()
        {
        }

        protected virtual void LoadContent()
        {
        }

        protected void Update()
        {
        }

        protected void Draw()
        {
        }

        private void RecordCommandList(GraphicsCommandList commandList)
        {
        }

        private void WaitForPreviousFrame()
        {
        }

        private SwapChain3 CreateSwapChain()
        {
            return null;
        }

        private unsafe IntPtr CreateConstantBufferView<T>(in T data) where T : unmanaged
        {
            return IntPtr.Zero;
        }

        private IntPtr CreateConstantBufferView(int bufferSize)
        {
            return IntPtr.Zero;
        }
    }
}
