N = int(input())



if N is 0:
	print(0)
	
else:
	previous = None

	for i in range(N):
		current = int(input())
		if current is not previous:
			print(current)
			previous = current
		