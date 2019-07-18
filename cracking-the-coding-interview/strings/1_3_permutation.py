def is_permutation(s1, s2):
    if len(s1) != len(s2):
        return False

    letters = [0 for _ in range(256)] # ASCII character set

    for i in range(len(s1)):
        letters[ord(s1[i])] += 1

    for c in range(len(s2)):
        if letters[ord(s2[c])] - 1 < 0:
            return False
    return True

print(is_permutation("abc", "acb"))        
print(is_permutation("abc", "aeb"))        