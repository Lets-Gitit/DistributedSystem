from selenium import webdriver
from selenium.webdriver.common.by import By
import requests
from bs4 import BeautifulSoup
import time

# 크롬 버전 106.0.5249.119
options = webdriver.ChromeOptions()
options.add_argument('--ignore-certificate-errors-spki-list')
options.add_argument('--ignore-ssl-errors')
driver = webdriver.Chrome('ChromeDriver\chromedriver.exe', chrome_options=options)

url = "https://www.whitehouse.gov/briefing-room/statements-releases/2022/11/21/statement-by-nsc-spokesperson-adrienne-watson-on-national-security-advisor-jake-sullivans-meeting-with-lieutenant-general-aviv-kohavi-chief-of-the-general-staff-of-the-israel-defense-fo/"
f = open('sample2.txt', 'w', encoding='utf-8')
driver.get(url)
driver.implicitly_wait(3)

html = driver.page_source
soup = BeautifulSoup(html, "lxml")
article = soup.find_all("section", class_ = "body-content")
article = str(article)
new = article.strip()
f.write(new)

driver.close()
f.close()






