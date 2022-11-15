file = open('Titles2.txt', 'w', encoding='utf-8')
file2 = open('Titles copy.txt', 'r', encoding='utf-8')

lines = file2.readlines()
print(lines)
lines = list(set(lines))
print(lines)

for line in lines:
	file.write(line)
   
file.close()
file2.close()