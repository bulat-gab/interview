def compres(s):
    l = len(s)
    news_s = []

    i = 0
    while i < l-1:
        current_char = s[i]

        j = i + 1
        counter = 1
        while j < l and s[j] == current_char:
            counter +=1
            j += 1
        news_s += current_char + str(counter)
        i += counter
    
    return ''.join(news_s)

print(compres('aabcccccaaa'))
assert compres('aabcccccaaa') == 'a2b1c5a3'
