using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sirena
{
    /// <summary>
    /// Provides a pool of Sirena tcp clients that can be used
    /// for asynchronous(and synchronous if needed) messaging with
    /// the Sirena server.
    /// </summary>
    public sealed class SirenaClientPool
    {
        private readonly SirenaClientSettings clientSettings;

        private ConcurrentQueue<SirenaClient> clients;

        /// <summary>
        /// Gets the Sirena Client pool size.
        /// </summary>
        public Int32 ClientPoolSize
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the free client count that not
        /// being used in requests at the moment.
        /// </summary>
        public Int32 FreeClientCount
        {
            get
            {
                return clients.Count;
            }
        }

        private Int32 _pollingDelay = 50;
        /// <summary>
        /// Gets or sets the delay (in milliseconds) between attempts to get
        /// a free Sirena client in the pool.
        /// </summary>
        /// <remarks>
        /// The mimimum value is 50.
        /// If a given value is less than 50 it will
        /// be replaces with 50.
        /// </remarks>
        public Int32 PollingDelay
        {
            get
            {
                return _pollingDelay;
            }
            set
            {
                value = (value > 50) ? value : 50;
                _pollingDelay = value;
            }
        }

        /// <summary>
        /// Initializes an instance of the SirenaClientPool class.
        /// </summary>
        /// <param name="poolSize">The Sirena client maximum pool size.</param>
        /// <param name="clientSettings">The settings that will be applied during communication.</param>
        public SirenaClientPool(Int32 poolSize, SirenaClientSettings clientSettings)
        {
            if (poolSize <= 0 || poolSize > Int32.MaxValue)
            {
                throw new ArgumentOutOfRangeException("poolSize");
            }
            if (clientSettings == null)
            {
                throw new ArgumentNullException("clientSettings can not be null");
            }

            this.clientSettings = clientSettings;
            clients = new ConcurrentQueue<SirenaClient>();
            ClientPoolSize = poolSize;
            InitializeClients();
        }

        private void InitializeClients()
        {
            for (var i = 0; i < ClientPoolSize; i++)
            {
                var client = new SirenaClient(clientSettings);
                clients.Enqueue(client);
            }
        }

        private Boolean TryGetFreeClient(out SirenaClient client)
        {
            var result = default(Boolean);
            client = default(SirenaClient);

            result = clients.TryDequeue(out client);
            return result;
        }

        private void PutBackClient(SirenaClient client)
        {
            clients.Enqueue(client);
        }

        /// <summary>
        /// Asynchronously queues a request in the SirenaClientPool instance.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <param name="connectionMode">The connection mode used for sending the request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        [Obsolete("Use QueueRequestAsync<TDtoRequest, TDtoResponse> instead.")]
        public async Task<String> QueueRequestAsync(String requestData, ConnectionMode connectionMode = ConnectionMode.Plain)
        {
            var client = default(SirenaClient);
            var attemptCount = 3;

            try
            {
                var task = Task.Factory.StartNew<SirenaClient>(() =>
                    {
                        var result = default(SirenaClient);
                        while (true)
                        {
                            if (TryGetFreeClient(out result))
                            {
                                break;
                            }
                            else
                            {
                                Thread.Sleep(PollingDelay);
                            }
                        }

                        return result;
                    });

                client = await task;

                // Try to send the request to the sirena server.
                // If any exception occurred resend the request
                // while attempts count more than 0, otherwise
                // rethrow an exception gotten during the request
                // sending.
                while (true)
                {
                    try
                    {
                        if (!client.IsConnected) await client.ConnectAsync();
                        var response = await client.SendRequestAsync(requestData, connectionMode);
                        return response;
                    }
                    catch (IOException e)
                    {
                        if (attemptCount == 0)
                        {
                            throw e;
                        }

                        client = new SirenaClient(clientSettings);
                        attemptCount--;
                    }
                }
            }
            finally
            {
                //Try to put back client.
                if (client != null && client.IsConnected)
                {
                    PutBackClient(client);
                }
                else
                {
                    PutBackClient(new SirenaClient(clientSettings));
                }
            }
        }

        /// <summary>
        /// Asynchronously queues a request in the SirenaClientPool instance.
        /// </summary>
        /// <typeparam name="TDtoRequest">The dto request type.</typeparam>
        /// <typeparam name="TDtoResponse">The dto response type.</typeparam>
        /// <param name="dtoRequest">The dto request to send.</param>
        /// <param name="connectionMode">The connection mode used for sending the request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<TDtoResponse> QueueRequestAsync<TDtoRequest, TDtoResponse>(TDtoRequest dtoRequest, ConnectionMode connectionMode = ConnectionMode.Plain)
            where TDtoRequest : DtoRequest
            where TDtoResponse : DtoResponse
        {
            var client = default(SirenaClient);
            var attemptCount = 3;

            try
            {
                var task = Task.Factory.StartNew<SirenaClient>(() =>
                {
                    var result = default(SirenaClient);
                    while (true)
                    {
                        if (TryGetFreeClient(out result))
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(PollingDelay);
                        }
                    }

                    return result;
                });

                client = await task;

                // Try to send the request to the sirena server.
                // If any exception occurred resend the request
                // while the attempt count more than 0, otherwise
                // rethrow an exception gotten during the request
                // sending.
                while (true)
                {
                    try
                    {
                        if (!client.IsConnected) await client.ConnectAsync();
                        var dtoResponse = await client.SendRequestAsync<TDtoRequest, TDtoResponse>(dtoRequest, connectionMode);
                        return dtoResponse;
                    }
                    catch (IOException e)
                    {
                        if (attemptCount == 0)
                        {
                            throw;
                        }

                        client = new SirenaClient(clientSettings);
                        attemptCount--;
                    }
                }
            }
            finally
            {
                //Try to put back client.
                if (client != null && client.IsConnected)
                {
                    PutBackClient(client);
                }
                else
                {
                    PutBackClient(new SirenaClient(clientSettings));
                }
            }
        }

        /// <summary>
        /// Asynchronously queues a KeyInfoRequest object in the SirenaClientPool instance.
        /// </summary>
        /// <param name="keyInfoRequest">The KeyInfoRequest request to send.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<KeyInfoResponse> QueueRequestAsync(KeyInfoRequest keyInfoRequest)
        {
            return await QueueRequestAsync<KeyInfoRequest, KeyInfoResponse>(keyInfoRequest);
        }

        /// <summary>
        /// Asynchronously queues a ScheduleRequest object in the SirenaClientPool instance.
        /// </summary>
        /// <param name="keyInfoRequest">The ScheduleRequest request to send.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<ScheduleResponse> QueueRequestAsync(ScheduleRequest scheduleRequest)
        {
            return await QueueRequestAsync<ScheduleRequest, ScheduleResponse>(scheduleRequest);
        }

        /// <summary>
        /// Asynchronously queues a AvailabilityRequest object in the SirenaClientPool instance.
        /// </summary>
        /// <param name="availabilityRequest">The AvailabilityRequest object to send.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<AvailabilityResponse> QueueRequestAsync(AvailabilityRequest availabilityRequest)
        {
            return await QueueRequestAsync<AvailabilityRequest, AvailabilityResponse>(availabilityRequest);
        }

        /// <summary>
        /// Asynchronously queues a FaresRequest object in the SirenaClientPool instance.
        /// </summary>
        /// <param name="faresRequest">The FaresRequest object to send.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<FaresResponse> QueueRequestAsync(FaresRequest faresRequest)
        {
            return await QueueRequestAsync<FaresRequest, FaresResponse>(faresRequest);
        }

        /// <summary>
        /// Asynchronously queues a FareremarkRequest object in the SirenaClientPool instance
        /// </summary>
        /// <param name="fareremarkRequest">The FareremarkRequest object to send.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task<FareremarkResponse> QueueRequestAsync(FareremarkRequest fareremarkRequest)
        {
            return await QueueRequestAsync<FareremarkRequest, FareremarkResponse>(fareremarkRequest);
        }

        /// <summary>
        /// Closes all clients.
        /// </summary>
        public void CloseClients()
        {
            lock (clients)
            {
                foreach (var client in clients)
                {
                    client.Close();
                }
            }
        }
    }
}
