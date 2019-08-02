def replace_spaces(s):
    new_s = []

    is_continious_spaces = False
    for c in s:
        if c != ' ':
            new_s += c
            is_continious_spaces = False
        elif c == ' ' and not is_continious_spaces:
            new_s += '%20'
            is_continious_spaces = True
    
    return ''.join(new_s)

print(replace_spaces('Mr John Smith    '))