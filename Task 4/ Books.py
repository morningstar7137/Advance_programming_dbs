import requests                                   # Imports requests to fetch the webpage 
from bs4 import BeautifulSoup                     # Imports BeautifulSoup to parse HTML code 
import csv                                        # Imports csv to write and read files 

def scrape_books():                               # Defines the scraping function [cite: 84]
    # URL provided in the assignment requirements [cite: 83]
    url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html" 
    response = requests.get(url)                  # Fetches the webpage content [cite: 84]
    soup = BeautifulSoup(response.text, 'html.parser') # Parses the HTML content 
    
    # Finds all book elements marked as 'product_pod' [cite: 83]
    books = soup.find_all('article', class_='product_pod') 
    
    # Opens books.csv in write mode as required [cite: 85]
    with open('books.csv', 'w', newline='', encoding='utf-8') as f: 
        writer = csv.writer(f)                    # Creates a CSV writer object 
        writer.writerow(['Name', 'Rating', 'Price']) # Writes the header row [cite: 85]
        
        for book in books:                        # Loops through each found book [cite: 84]
            name = book.h3.a['title']             # Extracts the book name [cite: 83]
            price = book.find('p', class_='price_color').text # Extracts the price [cite: 83]
            # Extracts the rating class (e.g., "Three") [cite: 83]
            rating = book.find('p', class_='star-rating')['class'][1] 
            
            writer.writerow([name, rating, price])# Stores data in the CSV file [cite: 85]
            
def read_books():                                 # Defines function to display data [cite: 87]
    try:                                          # Starts a try block for robustness [cite: 105]
        with open('books.csv', 'r', encoding='utf-8') as f: # Opens the resulting CSV [cite: 87]
            reader = csv.reader(f)                # Creates a CSV reader object 
            print("--- Data Retrieved from CSV ---") # Header for terminal output [cite: 87]
            for row in reader:                    # Loops through CSV rows [cite: 87]
                print(f"{row[0]} | {row[1]} | {row[2]}") # Displays in terminal window [cite: 87]
    except Exception as e:                        # Catches any file errors
        print("Error reading file: " + str(e))    # Prints error message

if __name__ == '__main__':                        # Checks if script is run directly
    scrape_books()                                # Executes the scraping logic [cite: 84]
    print("Scraping complete. Reading file...\n") # Status message
    read_books()                                  # Displays final results [cite: 87]