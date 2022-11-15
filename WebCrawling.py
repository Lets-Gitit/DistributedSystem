import requests
from bs4 import BeautifulSoup
import time

url = "https://www.wsj.com/search?query=fed&page=1"
headers = {"User-Agent" : "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36"}

f = open('Titles.txt', 'w', encoding='utf-8', newline='')
id = 0
k = 1
l = 10

for j in range(1, 2000) :
    print(url)
    res = requests.get(url, headers=headers)
    res.raise_for_status()

    soup = BeautifulSoup(res.text, "lxml")

    resultList = soup.find_all("span", class_="WSJTheme--headlineText--He1ANr9C")
    if(len(resultList) < 20) :
        continue

    for i in range(len(resultList)) :
        if resultList[i] == resultList[-1] :
            break
        id += 1
        resultList[i] = str(resultList[i])
        print(str(k) + ", " + resultList[i])
        f.write(resultList[i] + "\n")

    url = url.replace(str(k), str(k + 1))
    k += 1

f.close()

