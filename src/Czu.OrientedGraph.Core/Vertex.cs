using System;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public sealed class Vertex : IEquatable<Vertex>
    {
        public const int NameMaxLength = 255;

        public Vertex(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ModelException("Vertex name cannot be empty");
            }

            if (name.Length > NameMaxLength)
            {
                throw new ModelException($"Vertex name length must be equal or less than {NameMaxLength} chars");
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