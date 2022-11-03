import requests
from bs4 import BeautifulSoup
import csv 

url = "https://www.wsj.com/search?query=fed&page=1"
headers = {"User-Agent" : "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36"}

f = open('Titles.csv', 'w', encoding='utf-8', newline='')
wr = csv.writer(f)
wr.writerow(['id', 'title'])
id = 0

for j in range(1, 2) :
    print(url)
    res = requests.get(url, headers=headers)
    res.raise_for_status()

    soup = BeautifulSoup(res.text, "lxml")

    resultList = soup.find_all("span", class_="WSJTheme--headlineText--He1ANr9C")
   
    for i in range(len(resultList)) :
        id += 1
        resultList[i] = str(resultList[i])
        resultList[i] = resultList[i].replace('<span class="WSJTheme--headlineText--He1ANr9C">', '')
        resultList[i] = resultList[i].replace('</span>', '')
        print("ok")
        wr.writerow([id, resultList[i]])
        
    url = url.replace(str(j), str(j + 1))

f.close()

f = open('Titles.csv', 'r', encoding='utf-8')
rdr = csv.reader(f)
for line in rdr:
    print(line)
