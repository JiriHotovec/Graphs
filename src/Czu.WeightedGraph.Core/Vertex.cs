using System;
using Czu.WeightedGraph.Core.Exceptions;

namespace Czu.WeightedGraph.Core
{
    public readonly struct Vertex : IEquatable<Vertex>
    {
        public const int NameMaxLength = 255;

        public Vertex(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ModelException($"{nameof(name)} cannot be empty");
            }

            if (name.Length > NameMaxLength)
            {
                throw new ModelException($"{nameof(name)} length must be less or equal than {NameMaxLength} chars");
            }

            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;

        public static implicit operator string(Vertex vertex)
        {
            return vertex.Name;
        }

        public bool Equals(Vertex other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is Vertex other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !left.Equals(right);
        }
    }
}