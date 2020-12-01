using System;

namespace Tree
{
    public class TrieNode
    {
        public TrieNode[] Edges { get; set; }
        public string Meaning { get; set; }
        public bool IsTerminal { get; set; }

        public TrieNode()
        {
            Edges = new TrieNode[26];
            for (int i = 0; i < Edges.Length; i++)
            {
                Edges[i] = null;
            }

            IsTerminal = false;
            Meaning = null;
        }
    }
}