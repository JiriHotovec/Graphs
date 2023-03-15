using System;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public readonly struct Weight : IEquatable<Weight>
    {
        public const int WeightMin = 1;
        public const int WeightMax = 1000000;

        public Weight(int value)
        {
            if (value < WeightMin)
            {
                throw new ModelException($"{nameof(value)} must be greater or equal than {WeightMin}");
            }

            if (value > WeightMax)
            {
                throw new ModelException($"{nameof(value)} must be less than {WeightMax}");
            }

            Value = value;
        }

        public int Value { get; }

        public override string ToString() => $"{Value}";

        public static implicit operator int(Weight weight)
        {
            return weight.Value;
        }

        public bool Equals(Weight other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Weight other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Weight left, Weight right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Weight left, Weight right)
        {
            return !left.Equals(right);
        }
    }
}