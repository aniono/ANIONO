using System;

namespace DesignPatterns.DotNet
{
    public class BasicDispose : IDisposable
    {
        private bool disposed;
        private readonly BasicDispose resource;

        public BasicDispose() => this.resource = new BasicDispose();

        /// <summary>
        /// An alias for Dispose()
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (resource != null)
                    resource.Dispose();
            }

            disposed = true;
        }
    }
}