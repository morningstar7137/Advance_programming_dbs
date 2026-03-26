import socket                                     # Imports the socket module for network connections
import json                                       # Imports the json module to handle data formatting
import random                                     # Imports the random module to generate registration IDs

def run_server():                                 # Defines the main server function
    host = '127.0.0.1'                            # Sets the server address to localhost
    port = 5001                                   # Sets the port number for the connection
    
    server_socket = socket.socket()               # Creates a new TCP socket object
    server_socket.bind((host, port))              # Binds the socket to the host and port
    server_socket.listen(1)                       # Listens for incoming connections (1 max)
    
    print("Server is waiting for client on port 5000...") # Prints a waiting message on the terminal
    conn, address = server_socket.accept()        # Accepts the client connection
    print("Connection established from: " + str(address)) # Prints the connected client's address
    
    while True:                                   # Starts an infinite loop to receive data
        try:                                      # Starts a try block for exception handling
            data = conn.recv(1024).decode()       # Receives data from client and decodes it
            if not data:                          # Checks if the received data is empty
                break                             # Breaks the loop if no data is received
            
            print("Received customer data! Saving to database...") # Confirms data receipt
            customer = json.loads(data)           # Converts the received JSON string to a dictionary
            reg_num = "ED" + str(random.randint(1000, 9999)) # Generates a random registration number
            customer['RegNo'] = reg_num           # Adds the registration number to the dictionary
            
            with open("database.json", "a") as f: # Opens database.json in append mode to store data
                json.dump(customer, f)            # Writes the customer dictionary to the JSON file
                f.write("\n")                     # Writes a new line for the next database entry
                
            conn.send(reg_num.encode())           # Sends the unique registration number back to client
            print(f"Registration {reg_num} sent to client.\n") # Confirms ID was sent
        except Exception as e:                    # Catches any errors during the process
            print("Error: " + str(e))             # Prints the error message to the terminal
            break                                 # Breaks the loop if an error occurs
            
    conn.close()                                  # Closes the connection with the client

if __name__ == '__main__':                        # Checks if the script is run directly
    run_server()                                  # Calls the run_server function to start