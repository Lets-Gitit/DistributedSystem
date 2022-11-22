from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
import requests
from bs4 import BeautifulSoup
import time

# 크롬 버전 106.0.5249.119
options = webdriver.ChromeOptions()
options.add_argument('--ignore-certificate-errors-spki-list')
options.add_argument('--ignore-ssl-errors')
driver = webdriver.Chrome('ChromeDriver\chromedriver.exe', chrome_options=options)

id = 1121
page = 113

for i in range(300) :
    url = "https://www.whitehouse.gov/briefing-room/statements-releases/page/" + str(page) + "/"
    driver.get(url)
    print("now crawling page" + str(page))
    driver.implicitly_wait(3)

    for j in range(1,11) :
        res = driver.find_element(By.XPATH, '//*[@id="content"]/section[1]/div/div/div[1]/div[2]/article[' + str(j) + ']/h2/a').send_keys(Keys.ENTER)
        driver.implicitly_wait(3)
        print("now crawling article" + str(j) + " from page" + str(page))
        html = driver.page_source
        soup = BeautifulSoup(html, "lxml")
        article = soup.find_all("section", class_ = "body-content")
        article = str(article)

        txtname = "./articles2/article" + str(id) +".txt"
        f = open(txtname, 'w', encoding='utf-8')
        f.write(article)
        print("now writing articles to " + txtname)
        id += 1

        driver.back()

    page += 1
    print()
    


driver.close()
f.close()