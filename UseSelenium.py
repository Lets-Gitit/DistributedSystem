from selenium import webdriver

driver = webdriver.Chrome('C:\chromedriver_win32')

driver.implicitly_wait(3)

driver.get('https://www.wsj.com/search?query=fed&page=1')