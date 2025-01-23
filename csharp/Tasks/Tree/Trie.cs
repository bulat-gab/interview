using Tree;

namespace Tasks.Tree
{
    public class Trie
    {
        private TrieNode _head;

        /** Initialize your data structure here. */
        public Trie()
        {
            _head = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var cur = _head;

            foreach (var ch in word)
            {
                var code = (int)ch - (int)'a';
                if (cur.Edges[code] == null)
                {
                    cur.Edges[code] = new TrieNode();
                }

                cur = cur.Edges[code];
            }

            cur.IsTerminal = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var cur = _head;
            foreach (var ch in word)
            {
                var code = (int)ch - (int)'a';
                if (cur.Edges[code] == null)
                {
                    return false;
                }

                cur = cur.Edges[code];

            }

            return cur.IsTerminal;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var cur = _head;
            foreach (var ch in prefix)
            {
                var code = (int)ch - (int)'a';
                if (cur.Edges[code] == null)
                {
                    return false;
                }

                cur = cur.Edges[code];

            }

            return true;
        }
    }
}

// ReSharper disable once InvalidXmlDocComment
/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */