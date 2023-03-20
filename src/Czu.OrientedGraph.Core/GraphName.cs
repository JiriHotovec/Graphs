using System;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public sealed class GraphName : IEquatable<GraphName>
    {
        public const int NameMaxLength = 255;

        public GraphName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ModelException($"Graph name cannot be empty");
            }

            if (value.Length > NameMaxLength)
            {
                throw new ModelException($"Graph name length must be equal or less than {NameMaxLength} chars");
            }

            Value = value;
        }

        public string Value { get; }

        public override string ToString() => Value;

        public static implicit operator string(GraphName vertex)
        {
            return vertex.Value;
        }

        public bool Equals(GraphName other)
        {
            return string.Equals(Value, other?.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is GraphName other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
        }

        public static bool operator ==(GraphName left, GraphName right)
        {
            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(GraphName left, GraphName right)
        {
            return !left?.Equals(right) ?? false;
        }
    }
}