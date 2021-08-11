using System;

namespace dnMisp
{
    [Serializable]
    internal class RestConsumerException 
        : Exception
    {
        public RestConsumerException(Exception e) 
            : base($"Misp query issue: {e.Message}", e)
        {
        }
    }
}