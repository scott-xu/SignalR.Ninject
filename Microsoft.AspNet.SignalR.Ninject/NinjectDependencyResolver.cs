namespace Microsoft.AspNet.SignalR.Ninject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.SignalR;
    using global::Ninject;

    /// <summary>
    /// The Ninject dependency resolver.
    /// </summary>
    public class NinjectDependencyResolver : DefaultDependencyResolver
    {
        /// <summary>
        /// The kernel.
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class.
        /// </summary>
        /// <param name="kernel">The kernel. </param>
        /// <exception cref="ArgumentNullException">kernel should not null </exception>
        public NinjectDependencyResolver(IKernel kernel) 
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            this.kernel = kernel;
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">The service type. </param>
        /// <returns>The service <see cref="object"/>. </returns>
        public override object GetService(Type serviceType) 
        {
            return this.kernel.TryGet(serviceType) ?? base.GetService(serviceType);
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">The service type. </param>
        /// <returns>The service <see cref="IEnumerable"/>. </returns>
        public override IEnumerable<object> GetServices(Type serviceType) 
        {
            return this.kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}
