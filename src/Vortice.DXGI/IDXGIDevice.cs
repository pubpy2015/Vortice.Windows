// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using SharpGen.Runtime;

namespace Vortice.DXGI
{
    public partial class IDXGIDevice
    {
        /// <inheritdoc/>
        protected override unsafe void Dispose(bool disposing)
        {
            if (disposing)
            {
                ReleaseDevice();
            }
            base.Dispose(disposing);
        }

        private void ReleaseDevice()
        {
            if (Adapter__ != null)
            {
                // Don't use Dispose() in order to avoid circular references
                ((IUnknown)Adapter__).Release();
                Adapter__ = null;
            }
        }

        public IDXGISurface CreateSurface(IntPtr sharedResource)
        {
            if (sharedResource == IntPtr.Zero)
                throw new ArgumentNullException(nameof(sharedResource), "Invalid shared resource handle");

            return CreateSurface(null, 1, 0, new SharedResource { Handle = sharedResource });
        }

        public IDXGISurface CreateSurface(SurfaceDescription description, int numSurfaces, Usage usage)
        {
            return CreateSurface(description, numSurfaces, (int)usage, null);
        }

        public Result QueryResourceResidency(IUnknown[] resources, Residency[] residencyStatus)
        {
            return QueryResourceResidency(resources, residencyStatus, resources.Length);
        }
    }
}
