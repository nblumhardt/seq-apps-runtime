﻿using System;

namespace Seq.Apps
{
    /// <summary>
    /// Represents the Seq instance running the app.
    /// </summary>
    public class Host
    {
        /// <summary>
        /// Create a <see cref="Host"/>.
        /// </summary>
        /// <param name="instanceName">The name of the Seq instance, or null.</param>
        /// <param name="listenUris">The URIs at which the server is listening.</param>
        [Obsolete("Use the Host(baseUri, instanceName) constructor.")]
        public Host(string[] listenUris, string instanceName)
        {
            if (listenUris == null || listenUris.Length == 0)
            {
                throw new ArgumentException("At least 1 listen uri must be given.", nameof(listenUris));
            }

            InstanceName = instanceName;
            ListenUris = listenUris;
            BaseUri = listenUris[0];
        }
        
        /// <summary>
        /// Create a <see cref="Host"/>.
        /// </summary>
        /// <param name="instanceName">The name of the Seq instance, or null.</param>
        /// <param name="baseUri">The base URI that the server can be accessed on.</param>
        public Host(string baseUri, string instanceName)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
            InstanceName = instanceName;

            #pragma warning disable 612, 618 // Obsolete
            ListenUris = new [] { baseUri };
            #pragma warning restore 612, 618            
        }

        /// <summary>
        /// The name of the Seq instance, or null.
        /// </summary>
        public string InstanceName { get; }

        /// <summary>
        /// The URIs at which the server is listening.
        /// </summary>
        [Obsolete("Use BaseUri.")]
        public string[] ListenUris { get; }

        /// <summary>
        /// The base URI that the server can be accessed on.
        /// </summary>
        public string BaseUri { get; }
    }
}