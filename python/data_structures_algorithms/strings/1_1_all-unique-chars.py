def is_all_chars_unique(s):
    if len(s) > 256: 
        return False

    char_set = [False for _ in range(256)]
    for i in range(len(s)):
        val = ord(s[i])
        if char_set[val] == True:
            return False
        char_set[val] = True
    return True

print(is_all_chars_unique("abac"))