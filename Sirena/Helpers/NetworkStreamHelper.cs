using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Sirena.Helpers
{
    /// <summary>
    /// Provides helper methods for the NetworkStream class.
    /// </summary>
    public static class NetworkStreamHelper
    {
        /// <summary>
        /// Asynchronously reads a byte array from the NetworkStream object.
        /// </summary>
        /// <param name="stream">The NetworkStream object to read.</param>
        /// <param name="count">The byte array size to read.</param>
        /// <param name="dataChunkSize">The data chunk size that used for reading chunks from the stream.</param>
        /// <returns>Returns a task presents the asynchronious array read operation.</returns>
        public static async Task<Byte[]> ReadBytesAsync(this NetworkStream stream, Int32 count, Int32 dataChunkSize = 512)
        {
            if (count <= 0)
            {
                throw new ArgumentException("count should not be less 1");
            }
            if (dataChunkSize <= 0)
            {
                throw new ArgumentException("dataChunkSize should not be less 1");
            }

            var dataChunk = new Byte[dataChunkSize];
            var destination = new List<Byte>(count);
            var currentBytesRead = 0;
            var remainedBytesToRead = count;
            var bytesToRead = 0;
            var done = false;

            while (!done)
            {
                bytesToRead = remainedBytesToRead > dataChunk.Length ? dataChunk.Length : remainedBytesToRead;
                currentBytesRead = await stream.ReadAsync(dataChunk, 0, bytesToRead);
                destination.AddRange(dataChunk.Take(currentBytesRead));
                remainedBytesToRead -= currentBytesRead;
                done = remainedBytesToRead == 0;
            }

            return destination.ToArray();
        }
    }
}
