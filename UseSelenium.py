from selenium import webdriver
from selenium.webdriver.common.by import By
import csv 

# 크롬 버전 106.0.5249.119
driver = webdriver.Chrome('ChromeDriver\chromedriver.exe')
url = 'https://www.wsj.com/search?query=fed&page=1'


f = open('Titles11.csv', 'w', encoding='utf-8', newline='')
wr = csv.writer(f)
wr.writerow(['id', 'title'])
id = 0

for i in range(1, 10) :
    print("now scraping :", url)
    driver.implicitly_wait(3)
    driver.get(url)
    res = driver.find_elements(By.CLASS_NAME, 'WSJTheme--headlineText--He1ANr9C')

    for j in range(len(res)) :
        id += 1
        res[j] = res[j].text
        print(j, res[j])
        wr.writerow([id, res[j]])
    
    url = url.replace(str(i), str(i + 1))

# print(res)
f.close()
driver.close()

# f = open('Titles10.csv', 'r', encoding='utf-8')
# rdr = csv.reader(f)
# for line in rdr:
#     print(line)