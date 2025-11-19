using System.Xml.Serialization;

namespace KontrolRabRunec;

using System;
using System.Collections.Generic;
using System.Linq;

[XmlInclude(typeof(NoteBook))]

[XmlInclude(typeof(TextBook))]
[Serializable]
public abstract class Item : IComparable<Item>
{
    public int Weight { get; set; }
    protected Item(){}

    protected Item(int weight)
    {
        if (weight <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be greater than zero");
        }

        Weight = weight;
    }

    public int CompareTo(Item other)
    {
        if (other == null)
        {
            return 1;
        }

        return Weight.CompareTo(other.Weight);
    }

    public override string ToString()
    {
        return $"Weight {Weight}";
    }
}