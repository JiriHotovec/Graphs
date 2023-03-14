using System;

namespace Czu.WeightedGraph.Core.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string msg) : base(msg)
        {
        }
    }
}