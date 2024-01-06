using System;
using System.Collections.Generic;

public class HashTable
{
    private readonly LinkedList<int>[] items;
    private static readonly double A = ((Math.Sqrt(5) - 1) / 2) % 10;  // a jest liczbą pierwszą
    private static readonly int B = 7;  // b jest liczbą pierwszą

    public HashTable(int size)
    {
        items = new LinkedList<int>[size];
    }

    public void Add(int item)
    {
        int position = GetArrayPosition(item);
        LinkedList<int> linkedList = GetLinkedList(position);
        linkedList.AddLast(item);
    }

    public bool Find(int item)
    {
        int position = GetArrayPosition(item);
        LinkedList<int> linkedList = GetLinkedList(position);
        return linkedList.Contains(item);
    }

    public void DisplayElementsBeforeHashing(int[] elements)
    {
        Console.WriteLine("Elementy przed haszowaniem:");
        foreach (var element in elements)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    public void DisplayElementsAfterHashing()
    {
        Console.WriteLine("\nElementy po haszowaniu:");
        for (int i = 0; i < items.Length; i++)
        {
            Console.Write($"Slot {i}: ");
            if (items[i] != null)
            {
                foreach (var item in items[i])
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }
    }

    private int GetArrayPosition(int item)
    {
        double temp = (A * item) % B;
        int position = (int)(temp % items.Length);
        return Math.Abs(position);
    }

    private LinkedList<int> GetLinkedList(int position)
    {
        LinkedList<int> linkedList = items[position];
        if (linkedList == null)
        {
            linkedList = new LinkedList<int>();
            items[position] = linkedList;
        }

        return linkedList;
    }
}

public class Program
{
    public static void Main()
    {
        int[] elements = new int[100];

        for (int i = 0; i < 100; i++)
        {
            elements[i] = i;
        }

        // Tworzenie nowej tablicy haszującej
        HashTable hashTable = new HashTable(10);

        // Wyświetlanie elementów przed haszowaniem
        hashTable.DisplayElementsBeforeHashing(elements);

        // Dodawanie elementów do tablicy haszującej
        foreach (var element in elements)
        {
            hashTable.Add(element);
        }

        // Wyświetlanie elementów po haszowaniu
        hashTable.DisplayElementsAfterHashing();

        // Wyszukiwanie elementów w tablicy haszującej
        Console.WriteLine("\nCzy 1 istnieje? " + hashTable.Find(1));  // Zwraca true
        Console.WriteLine("Czy 101 istnieje? " + hashTable.Find(101));  // Zwraca false
    }
}
