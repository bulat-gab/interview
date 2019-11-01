from LinkedList import LinkedList

def find_kth_last(l, from_):
    current = l.head
    result = []

    i = 1
    while current is not None:
        if i >= from_:
            result.append(current.data)

        current = current.next
        i += 1

    return result



l = LinkedList.get_sample(10)

expected = [6, 7, 8, 9]
actual = find_kth_last(l, 7) # [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

print(actual)

assert len(expected) == len(actual)
assert expected == actual