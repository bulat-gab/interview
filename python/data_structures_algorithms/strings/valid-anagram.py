from collections import Counter

def isAnagram(s: str, t: str) -> bool:
        sc = Counter(s)
        tc = Counter(t)

        return sc == tc

if __name__ == "__main__":
    print(isAnagram("a", ""))