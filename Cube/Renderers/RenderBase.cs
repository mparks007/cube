using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeSolver.Core;
using System.Drawing;

namespace CubeSolver.Renderers
{
    abstract class RenderBase : IRenderer
    {
        protected bool disposed = false;
        protected Cube cube;
        protected int pieceSize;

        public RenderBase(Cube cube, int pieceSize)
        {
            this.cube = cube;
            this.pieceSize = pieceSize;
        }

        public virtual void Render()
        {
            throw new NotImplementedException("Should use derived classes for Render.");
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
        
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
