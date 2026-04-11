import requests                                    
from bs4 import BeautifulSoup                    
import csv                                         

def scrape_books():                               # Defines the scraping function [cite: 84]
    # Provided URL
    url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html" 
    response = requests.get(url)                  
    soup = BeautifulSoup(response.text, 'html.parser') 
    
    # Finds all book elements marked as 'product_pod'
    books = soup.find_all('article', class_='product_pod') 
    
    # Opens books.csv in write mode
    with open('books.csv', 'w', newline='', encoding='utf-8') as f: 
        writer = csv.writer(f)                    
        writer.writerow(['Name', 'Rating', 'Price']) 
        
        for book in books:                        # Loops through each found book 
            name = book.h3.a['title']             # Extracts the book name 
            price = book.find('p', class_='price_color').text # Extracts the price
            # Extracts the rating class
            rating = book.find('p', class_='star-rating')['class'][1] 
            
            writer.writerow([name, rating, price])# Stores data in the CSV file
            
def read_books():                                 # Defines function to display data [cite: 87]
    try:                                          
        with open('books.csv', 'r', encoding='utf-8') as f: # Opens the resulting CSV [cite: 87]
            reader = csv.reader(f)              
            print("--- Data Retrieved from CSV ---") 
            for row in reader:                    
                print(f"{row[0]} | {row[1]} | {row[2]}") # Displays in terminal window [cite: 87]
    except Exception as e:                        
        print("Error reading file: " + str(e))    

if __name__ == '__main__':                        # Checks if script is run directly
    scrape_books()                                
    print("Scraping complete. Reading file...\n") 
    read_books()                                  # Displays final results
