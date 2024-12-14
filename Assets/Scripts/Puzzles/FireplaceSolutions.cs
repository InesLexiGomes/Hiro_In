using UnityEngine;

public class FireplaceSolutions :MonoBehaviour
{
    public readonly bool[][] libraArray = new bool[][]
    {
        new bool[]
        {
            true, false, true, false, false,
            false, false, false, true, false,
            true, false, false, false, true,
            false, false, false, false, false,
            false, true, false, false, false
        },

        new bool[]
        {
            true, true, false, false, false,
            false, false, true, false, false,
            true, false, false, true, false,
            false, false, false, false, false,
            false, true, false, false, false
        },

        new bool[]
        {
            false, true, true, false, false,
            false, false, false, true, false,
            false, true, false, false, true,
            false, false, false, false, false,
            false, false, true, false, false
        },

        new bool[]
        {
            true, false, true, false, false,
            false, false, false, false, false,
            true, false, false, true, false,
            false, false, false, false, false,
            false, true, false, false, true
        },

        new bool[]
        {
            true, false, true, false, false,
            false, false, false, true, false,
            true, false, false, false, true,
            false, false, false, false, false,
            false, false, true, false, false
        },

        new bool[]
        {
            true, false, true, false, false,
            false, false, false, true, false,
            true, false, false, false, true,
            false, true, false, false, false,
            false, false, false, false, false
        }
};

    public readonly bool[][] cancerArray = new bool[][]
    {
        new bool[]
        {
            false, false, true, false, false,
            false, false, false, false, false,
            false, false, true, false, false,
            false, false, true, false, false,
            false, false, true, true, false
        },

        new bool[]
        {
            false, false, false, true, false,
            false, false, false, false, false,
            false, false, false, true, false,
            false, false, false, true, false,
            false, false, false, true, true
        },

        new bool[]
        {
            false, true, false, false, false,
            false, false, false, false, false,
            false, true, false, false, false,
            false, true, false, false, false,
            false, true, true, false, false
        },

        new bool[]
        {
            true, false, false, false, false,
            false, false, false, false, false,
            true, false, false, false, false,
            true, false, false, false, false,
            true, true, false, false, false
        }
    };

    public readonly bool[][] ariesArray = new bool[][]
    {
        new bool[]
        {
            true, false, false, false, false,
            false, false, true, false, false,
            false, false, false, false, false,
            false, false, true, false, false,
            false, true, false, false, false
        },

        new bool[]
        {
            false, true, false, false, false,
            false, false, false, true, false,
            false, false, false, false, false,
            false, false, false, true, false,
            false, false, true, false, false
        },

        new bool[]
        {
            false, false, true, false, false,
            false, false, false, false, true,
            false, false, false, false, false,
            false, false, false, false, true,
            false, false, false, true, false
        },

        new bool[]
        {
            true, false, false, false, false,
            false, false, true, false, false,
            false, false, false, false, false,
            false, false, true, false, false,
            true, false, false, false, false
        },

        new bool[]
        {
            false, true, false, false, false,
            false, false, false, true, false,
            false, false, false, false, false,
            false, false, false, true, false,
            false, true, false, false, false
        },

        new bool[]
        {
            false, false, true, false, false,
            false, false, false, false, true,
            false, false, false, false, false,
            false, false, false, false, true,
            false, false, true, false, false
        }
    };
}
