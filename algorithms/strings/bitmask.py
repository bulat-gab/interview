mask = 0

word = "abcdz"

for c in word:
    mask |= (1 << ord(c) - ord('a'))

print(mask)